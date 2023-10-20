﻿using ClipboardTool.Properties;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace ClipboardTool
{
    public class ProcessText
    {
        MainForm mainForm;
        public ProcessText(MainForm parent)
        {
            mainForm = parent;
        }

        public string ProcessTextVariables(string customText, bool forceClipboardUpdate = false)
        {
            if (customText == null) return String.Empty;
            string plainText = String.Empty;
            string? richText = String.Empty;

            int padNumber = 1;
            string clip = Clipboard.GetText();

            // replace text in clipboard string. place first to allow for other processing on the result text. Uses mem slots 1 & 2
            if (customText.Contains("$rep"))
            {
                ReplaceText(ref customText, ref clip);
            }

            // get mem slot data first, so you can run other processing on it
            if (customText.Contains("$m"))
            {
                customText = MemSlotText(customText);
            }

            // date and time
            customText = customText.Replace("$d", DateTime.Now.ToShortDateString());
            customText = customText.Replace("$t", DateTime.Now.ToShortTimeString());

            // clipboard, case conversion
            if (customText.Contains("$c"))
            {
                customText = ClipBoardCase(customText, clip);
            }

            // pad number with leading zeroes
            if (customText.Contains("$n"))
            {
                PadNumber(ref customText, ref padNumber);
            }

            // output counter number
            customText = customText.Replace("$i", mainForm.NumberSpinner.ToString().PadLeft(padNumber, '0'));

            // output counter number, then increment it
            if (customText.Contains("$+"))
            {
                customText = customText.Replace("$+", mainForm.NumberSpinner.ToString().PadLeft(padNumber, '0'));
                mainForm.NumberSpinner++;
            }

            // output counter number, then decrement it
            if (customText.Contains("$-"))
            {
                customText = customText.Replace("$-", mainForm.NumberSpinner.ToString().PadLeft(padNumber, '0'));
                mainForm.NumberSpinner--;
            }

            // Excel double quote fix
            if (customText.Contains("$eq"))
            {
                customText = ExcelQuotes(customText);
            }

            // split text in mem slot 1, output lines by counter number
            if (customText.Contains("$v"))
            {
                customText = SeparatorList(customText);
            }

            // split lines in main textbox, output lines by counter number
            if (customText.Contains("$list"))
            {
                customText = ListSplit(customText);
            }

            //"$prompt Popup prompt to fill in a value\n" + // testing if the control can revert back to the active application
            if (customText.Contains("$prompt"))
            {
                customText = PromptForText(customText);
            }

            // debug hotkey output
            if (customText.Contains("$Debug"))
            {
                var path = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath;
                string debug = path;
                customText = customText.Replace("$Debug", debug);
            }

            if (customText.Contains("$RTF"))
            {
                customText = customText.Replace("$RTF", "");
                (richText, plainText) = ConvertToRichText(customText);                
            }
            else
            {
                plainText = customText;
                richText = null;
            }

            if (plainText.Length < 1)
            {
                return "";
            }
            else
            {
                mainForm.SetClipBoard(plainText, richText, forceClipboardUpdate);
                return customText;
            }
        }

        string rtfHeader = @"{\rtf1\ansi ";
        string colorBlack = @"\red0\green0\blue0;";
        string colorWhite = @"\red255\green255\blue255;";
        string colorGray = @"\red180\green180\blue180;";
        string colorRed = @"\red255\green0\blue0;";
        string colorGreen = @"\red0\green255\blue0;";
        string colorBlue = @"\red0\green0\blue255;";

        private string colorTable()
        {
            return @"{\colortbl;" + colorBlack + colorWhite + colorGray + colorRed + colorGreen + colorBlue + Settings.Default.RTFcolors + @"}";
        }

        // example: @"{\f1\cb1\cf2 This is colored text. The background is color 1 and the foreground is color 2.}";

        public (string, string) ConvertToRichText(string plainText)
        {
            //https://www.biblioscape.com/rtf15_spec.htm
            Debug.WriteLine("Parsing Rich Text");

            RichTextBox rtfBox = new RichTextBox();
            StringBuilder builder = new StringBuilder();
            string plainTextResult = "";
            string richTextResult = "";
            string tagStart = "<";
            string tagEnd = ">";
            string escapeTag = "\\";
            string escapeTemp = "¤";
            
            plainText = plainText.Replace(escapeTag + tagStart, escapeTemp);
            plainText = plainText.Replace(Environment.NewLine, @"\par "); // add line breaks that RTF ignores back in
            string[] segments = plainText.Split(tagStart);
            if (segments.Length > 0)
            {
                foreach (string segment in segments)
                {
                    string segmentUnEscaped = segment.Replace(escapeTemp, tagStart);
                    segmentUnEscaped = segmentUnEscaped.Replace(escapeTag+tagEnd, escapeTemp);

                    string[] tagAndText = segmentUnEscaped.Split(tagEnd, 2);
                    string? tag = null;
                    string? text = null;
                    if (tagAndText.Length == 1)
                        text = tagAndText[0].Replace(escapeTemp, tagEnd);
                    if (tagAndText.Length > 1)
                    {
                        tag = tagAndText[0];
                        text = tagAndText[1].Replace(escapeTemp, tagEnd);
                    }
                        

                    if (tag!= null && text != null)
                    {
                        switch (tag)
                        {
                            case "b": // bold
                                //rtfBox.SelectionFont = new Font(rtfBox.Font, FontStyle.Bold);
                                SetRTFTag(builder, text, @"\b ", @"\b0 ");
                                break;
                            case "i": // italic
                                //rtfBox.SelectionFont = new Font(rtfBox.Font, FontStyle.Bold);
                                SetRTFTag(builder, text, @"\i ", @"\i0 ");
                                break;
                            case "strike": // strikethrough
                                SetRTFTag(builder, text, @"\strike ", @"\strike0 ");
                                break;
                            case "ul": // underline
                                SetRTFTag(builder, text, @"\ul ", @"\ul0 ");
                                break;
                            case "ulw": // underlined words, but spaces are not
                                SetRTFTag(builder, text, @"\ulw ", @"\ulw0 ");
                                break;
                            case "plain": // plain (remove formatting)
                                SetRTFTag(builder, text, @"\plain ", @"");
                                break;
                            case "black":
                                SetRTFTag(builder, text, @"\cf1 ", @"");
                                break;
                            case "white":
                                SetRTFTag(builder, text, @"\cf2 ", @"");
                                break;
                            case "gray":
                                SetRTFTag(builder, text, @"\cf3 ", @"");
                                break;
                            case "red":
                                SetRTFTag(builder, text, @"\cf4 ", @"");
                                break;
                            case "green":
                                SetRTFTag(builder, text, @"\cf5 ", @"");
                                break;
                            case "blue":
                                SetRTFTag(builder, text, @"\cf6 ", @"");
                                break;
                            case "fontsr":
                                if (OperatingSystem.IsWindows())
                                {
                                    //Debug.WriteLine("Setting font to Serif");
                                    rtfBox.Font = new Font(FontFamily.GenericSerif, 11f);
                                    builder.Append(text);
                                }
                                break;
                            case "fontss":
                                if (OperatingSystem.IsWindows())
                                {
                                    //Debug.WriteLine("Setting font to Sans Serif");
                                    rtfBox.Font = new Font(FontFamily.GenericSansSerif, 11f);
                                    builder.Append(text);
                                }
                                break;
                            case "fontms":
                                if (OperatingSystem.IsWindows())
                                {
                                    //Debug.WriteLine("Setting font to Monospace");
                                    rtfBox.Font = new Font(FontFamily.GenericMonospace, 11f);
                                    builder.Append(text);
                                }
                                break;
                            default: 
                                if (tagAndText[0].Length > 0) // unknown RTF code, pass it on
                                {
                                    //Debug.WriteLine("Unknown RTF code, pass it on : " + tagAndText[0]);
                                    SetRTFTag(builder, text, @"\" + tagAndText[0] + " ", @"");
                                }
                                else builder.Append(text); // empy tag <>: regular text
                                break;
                        }
                    }
                    else
                    {
                        //Debug.WriteLine("no tag in tagAndText, appending unsplit value: " + text);
                        if (segment.Length > 0)
                            builder.Append(text);
                    }
                    
                    rtfBox.Rtf = rtfHeader + colorTable() + builder.ToString() + @"}"; // removed space in @" }";
                    richTextResult = rtfBox.Rtf;
                }
            }
            
            plainTextResult = rtfBox.Text;
            rtfBox.Dispose();
            return (richTextResult, plainTextResult);
        }

        private static void SetRTFTag(StringBuilder builder, string text, string start, string end)
        {
            if (text.Length > 0)
            {
                builder.Append(start);
                builder.Append(text);
                builder.Append(end);
            }
        }

        private static string ClipBoardCase(string customText, string clip)
        {
            customText = customText.Replace("$cp", clip);
            customText = customText.Replace("$cl", clip.ToLower());
            customText = customText.Replace("$cu", clip.ToUpper());
            return customText;
        }

        private string PromptForText(string customText)
        {
            TextPrompt prompt = new TextPrompt("Input text", "Text processing is requesting an input value." + Environment.NewLine + "($prompt function)");
            if (prompt.ShowDialog() == DialogResult.OK)
            {
                customText = customText.Replace("$prompt", prompt.TextResult);
            }
            else
            {
                return string.Empty; // stop the text output if the calling function respects a string.Empty as an abort
            }
            prompt.Dispose();
            return customText;
        }

        private static void PadNumber(ref string customText, ref int padNumber)
        {
            if (customText.Contains("$n2"))
            {
                customText = customText.Replace("$n2", "");
                padNumber = 2;
            }
            if (customText.Contains("$n3"))
            {
                customText = customText.Replace("$n3", "");
                padNumber = 3;
            }
        }

        private void ReplaceText(ref string customText, ref string clip)
        {
            customText = customText.Replace("$rep", String.Empty);
            Clipboard.SetText(clip.Replace(mainForm.MemorySlot(1).Text, mainForm.MemorySlot(2).Text));
            clip = clip.Replace(mainForm.MemorySlot(1).Text, mainForm.MemorySlot(2).Text);
        }

        private string MemSlotText(string customText)
        {
            customText = customText.Replace("$m1", mainForm.MemorySlotText(1));
            customText = customText.Replace("$m2", mainForm.MemorySlotText(1));
            customText = customText.Replace("$m3", mainForm.MemorySlotText(1));
            return customText;
        }

        private static string ExcelQuotes(string customText)
        {
            customText = customText.Replace("$eq", "");
            customText = customText.Replace("\"\"", "£Q");
            customText = customText.Replace("\"", "");
            customText = customText.Replace("£Q", "\"");
            return customText;
        }

        private string ListSplit(string customText)
        {
            string[] values = customText.Split(Environment.NewLine, StringSplitOptions.None);

            if (mainForm.NumberSpinner < 1) mainForm.NumberSpinner = 1; // skip the first line with the $list

            int num = mainForm.NumberSpinner;
            if (num >= values.Length)
            {
                return String.Empty;
            }

            string currentline = values[num];

            if (values.Length > 0)
            {
                if (currentline.Contains("$list")) //skip this line
                {
                    //MessageBox.Show("Error using $list. Recursive lists is not allowed");
                    mainForm.NumberSpinner++;
                    return String.Empty;
                }
                customText = ProcessTextVariables(currentline, false);
            }
            else
            {
                customText = String.Empty;
            }

            mainForm.NumberSpinner++;
            return customText;
        }

        public string SeparatorList(string customText, int slot = 1)
        {
            char separator = ',';
            string command = "$v";
            if (customText.Contains("$vcm")) // semicolon separator
            {
                separator = ',';
                command = "$vcm";
            }
            else if (customText.Contains("$vsc")) // semicolon separator
            {
                separator = ';';
                command = "$vsc";
            }
            else if (customText.Contains("$vsp")) // semicolon separator
            {
                separator = ' ';
                command = "$vsp";
            }


            string[] values = mainForm.MemorySlot(slot).Text.Split(separator);
            if (values.Length > 0 && mainForm.NumberSpinner <= values.Length && mainForm.NumberSpinner >= 1)
            {
                customText = customText.Replace(command, values[(int)mainForm.NumberSpinner - 1]);
                //customText = values[(int)numericUpDown1.Value];
            }
            else
            {
                customText = customText.Replace(command, String.Empty);
            }
            mainForm.NumberSpinner++;
            return customText;
        }
    }
}
