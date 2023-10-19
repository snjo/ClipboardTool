using System.Configuration;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

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
                Debug.WriteLine("RTF returned: " + plainText.Length + ", " + richText.Length);
                //dataFormat = TextDataFormat.Rtf;
                //return customText;
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

        public (string, string) ConvertToRichText(string plainText)
        {
            //https://www.biblioscape.com/rtf15_spec.htm
            RichTextBox rtfBox = new RichTextBox();
            StringBuilder builder = new StringBuilder();
            string plainTextResult = "";
            string richTextResult = "";
            string tagStart = "£<";
            string tagEnd = ">";
            plainText = plainText.Replace(Environment.NewLine, @"\par ");
            string[] segments = plainText.Split(tagStart);
            if (segments.Length > 0)
            {
                foreach (string segment in segments)
                {
                    Debug.WriteLine("segment: " + segment);
                    string[] tagAndText = segment.Split(tagEnd, 2);
                    if (tagAndText.Length > 1)
                    {
                        Debug.WriteLine("segment tag: " + tagAndText[0]);
                        Debug.WriteLine("segment text: " + tagAndText[1]);
                        switch (tagAndText[0])
                        {
                            case "b": // bold
                                //rtfBox.SelectionFont = new Font(rtfBox.Font, FontStyle.Bold);
                                SetRTFTag(builder, tagAndText[1], @"\b ", @"\b0 ");
                                break;
                            case "i": // italic
                                //rtfBox.SelectionFont = new Font(rtfBox.Font, FontStyle.Bold);
                                SetRTFTag(builder, tagAndText[1], @"\i ", @"\i0 ");
                                break;
                            case "strike": // strikethrough
                                SetRTFTag(builder, tagAndText[1], @"\strike ", @"\strike0 ");
                                break;
                            case "ul": // underline
                                SetRTFTag(builder, tagAndText[1], @"\ul ", @"\ul0 ");
                                break;
                            case "ulw": // underlined words, but spaces are not
                                SetRTFTag(builder, tagAndText[1], @"\ulw ", @"\ulw0 ");
                                break;
                            case "plain": // plain (remove formatting)
                                SetRTFTag(builder, tagAndText[1], @"\plain ", @"");
                                break;
                            case "fontsr":
                                if (OperatingSystem.IsWindows())
                                    rtfBox.Font = new Font(FontFamily.GenericSerif, 11f);
                                break;
                            case "fontss":
                                if (OperatingSystem.IsWindows())
                                    rtfBox.Font = new Font(FontFamily.GenericSansSerif, 11f);
                                break;
                            case "fontms":
                                if (OperatingSystem.IsWindows())
                                    rtfBox.Font = new Font(FontFamily.GenericMonospace, 11f);
                                break;
                            default: // error, or empy/unspecified tag: regular text
                                if (tagAndText[0].Length > 0) // unknown RTF code, pass it on
                                {
                                    Debug.WriteLine("Unknown RTF code, pass it on : " + tagAndText[0]);
                                    SetRTFTag(builder, tagAndText[1], @"\" + tagAndText[0] + " ", @"");
                                }
                                else builder.Append(tagAndText[1]);
                                break;
                        }
                    }
                    else
                    {
                        Debug.WriteLine("no tag end in segment");
                        if (segment.Length > 0)
                            builder.Append(segments[0]);
                    }

                    richTextResult = @"{\rtf1\ansi " + builder.ToString() + @" }";
                    rtfBox.Rtf = richTextResult;
                    //rtfBox.Rtf = @"{\rtf1\ansi " + builder.ToString() + @" }";

                }
            }
            else
            {
                Debug.WriteLine("no segments");
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
