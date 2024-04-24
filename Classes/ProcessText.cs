using ClipboardTool.Classes;
using ClipboardTool.Properties;
using DebugTools;
using System.Data;
using System.Diagnostics;
using System.Runtime.Versioning;
using System.Text;

namespace ClipboardTool;

[SupportedOSPlatform("windows")]

public class ProcessText
{
    readonly MainForm mainForm;
    public ProcessingCommands commands = new ProcessingCommands();
    public ProcessText(MainForm parent)
    {
        mainForm = parent;
    }

    /// <summary>
    /// Processes text with $-commands, outputs both plain and rich text.
    /// </summary>
    /// <param name="plainText"></param>
    /// <returns>string PlainText, string RichText</returns>
    public (string PlainText, string? RichText) ProcessTextVariables(string customText, bool forceClipboardUpdate = false) //(string, string)
    {
        //Debug.WriteLine("ProcessTextVariables start, clipboardupdate: " + forceClipboardUpdate);
        if (customText == null) return (PlainText: string.Empty, RichText: null);
        string plainText = String.Empty;
        string? richText = String.Empty;

        int padNumber = 1;
        //string clip = Clipboard.GetText(TextDataFormat.UnicodeText);
        string clip = Clipboard.GetText();

        // replace text in clipboard string. place first to allow for other processing on the result text. Uses mem slots 1 & 2
        if (customText.Contains(ProcessingCommands.Replace.Name))
        {
            ReplaceText(ref customText, ref clip);
        }

        // get mem slot data first, so you can run other processing on it
        customText = customText.Replace(ProcessingCommands.MemSlot1.Name, mainForm.MemorySlotText(1));
        customText = customText.Replace(ProcessingCommands.MemSlot2.Name, mainForm.MemorySlotText(2));
        customText = customText.Replace(ProcessingCommands.MemSlot3.Name, mainForm.MemorySlotText(3));

        // date and time
        customText = customText.Replace(ProcessingCommands.Date.Name, DateTime.Now.ToShortDateString());
        customText = customText.Replace(ProcessingCommands.Time.Name, DateTime.Now.ToShortTimeString());

        // clipboard, case conversion
        customText = customText.Replace(ProcessingCommands.ClipboardPlain.Name, clip);
        customText = customText.Replace(ProcessingCommands.ClipboardUpper.Name, clip.ToUpper());
        customText = customText.Replace(ProcessingCommands.ClipboardLower.Name, clip.ToLower());

        // pad number with leading zeroes
        PadNumber(ref customText, ref padNumber);

        // output counter number
        customText = customText.Replace(ProcessingCommands.Number.Name, mainForm.NumberSpinner.ToString().PadLeft(padNumber, '0'));

        // output counter number, then increment it
        if (customText.Contains(ProcessingCommands.Increment.Name))
        {
            customText = customText.Replace(ProcessingCommands.Increment.Name, mainForm.NumberSpinner.ToString().PadLeft(padNumber, '0'));
            mainForm.NumberSpinner++;
        }

        // output counter number, then decrement it
        if (customText.Contains(ProcessingCommands.Decrement.Name))
        {
            customText = customText.Replace(ProcessingCommands.Decrement.Name, mainForm.NumberSpinner.ToString().PadLeft(padNumber, '0'));
            mainForm.NumberSpinner--;
        }

        // Excel double quote fix
        if (customText.Contains(ProcessingCommands.ExcelQuotes.Name))
        {
            customText = ExcelQuotes(customText);
        }

        // split text in mem slot 1, output lines by counter number
        customText = SeparatorList(customText);


        // split lines in main textbox, output lines by counter number
        if (customText.Contains(ProcessingCommands.List.Name))
        {
            customText = ListSplit(customText);
        }

        //"$prompt Popup prompt to fill in a value\n" + // testing if the control can revert back to the active application
        if (customText.Contains(ProcessingCommands.Prompt.Name))
        {
            customText = PromptForText(customText);
        }

        // Convert characters in clipboard string to numbers for debugging text
        if (customText.Contains(ProcessingCommands.ClipboardCharToInt.Name))
        {
            customText = customText.Replace(ProcessingCommands.ClipboardCharToInt.Name, StringToIntSequence(clip));
        }

        // Math
        if (customText.Contains(ProcessingCommands.Math.Name))
        {
            bool round = false;
            customText = customText.Replace(ProcessingCommands.Math.Name, "");
            if (customText.Contains(ProcessingCommands.Round.Name))
            {
                customText = customText.Replace(ProcessingCommands.Round.Name, "");
                round = true;
            }
            customText = SolveEquation(customText, round);
        }


        // Replace digits with numeral words
        bool DTWUpperCaseFlag = false;
        if (customText.Contains(ProcessingCommands.DigitToWordUpperCase.Name))
        {
            DTWUpperCaseFlag = true;
            customText = customText.Replace(ProcessingCommands.DigitToWordUpperCase.Name, "");
        }

        if (customText.Contains(ProcessingCommands.DigitToWord.Name))
        {
            customText = DigitsToWords.ProcessDigitsEnclosed(customText, DTWUpperCaseFlag);
            customText = customText.Replace(ProcessingCommands.DigitToWord.Name, "");
        }

        // Remove None-Command, used for separating the end of a tag from text, or splitting up what could be construed as a tag. For edge cases.
        customText = customText.Replace(ProcessingCommands.None.Name, "");

        // Decide if output should be plain text or rich text.
        // Don't add any more processing to customText after this, it will be ignored.
        if (customText.Contains(ProcessingCommands.RTF.Name))
        {
            customText = customText.Replace(ProcessingCommands.RTF.Name, "");
            (plainText, richText) = ConvertToRichText(customText);
        }
        else
        {
            plainText = customText;
            richText = null;
        }

        //Debug.WriteLine("ProcessTextVariables send result");

        if (plainText.Length < 1)
        {
            return (string.Empty, string.Empty);
        }
        else
        {
            mainForm.Main.SetClipBoard(plainText, richText, forceClipboardUpdate, "Process Text");
            return (PlainText: plainText, RichText: richText);
        }
    }

    private static string StringToIntSequence(string clip)
    {
        string result = string.Empty;
        foreach (char c in clip)
        {
            result += (int)c + " ";
        }
        return result;
    }

    readonly string rtfHeader = @"{\rtf1\ansi ";
    readonly string colorBlack = @"\red0\green0\blue0;";
    readonly string colorWhite = @"\red255\green255\blue255;";
    readonly string colorGray = @"\red180\green180\blue180;";
    readonly string colorRed = @"\red255\green0\blue0;";
    readonly string colorGreen = @"\red0\green255\blue0;";
    readonly string colorBlue = @"\red0\green0\blue255;";
    //string fontTable = @"\deff0{\fonttbl{\f0\fnil Default Sans Serif;}{\f1\froman Times New Roman;}{\f2\fswiss Arial;}{\f3\fmodern Courier New;}{\f4\fscript Script MT Bold;}{\f5\fdecor Old English Text MT;}}";
    //string colorTableDefault = @"\red80\green120\blue200;\red255\green180\blue1800;";
    // fnil Default Sans Serif should work for Lotus Notes

    private string ColorTable()
    {
        if (Settings.Default.RTFallowColorTable)
        {
            return @"{\colortbl;" + colorBlack + colorWhite + colorGray + colorRed + colorGreen + colorBlue + Settings.Default.RTFcolors + @"}";
        }
        else return string.Empty;
    }

    private static string FontTable()
    {
        if (Settings.Default.RTFallowFontTable)
        {
            return Settings.Default.RTFfonts;
        }
        else
        {
            return string.Empty;
        }
    }

    private static string SolveEquation(string mixedText, bool round)
    {
        Debug.WriteLine($"Solve equation: '{mixedText}', round: {round}");
        string result = "";
        string tagStart = "[";
        string tagEnd = "]";
        string escapeTag = "\\";
        string escapeTemp = "¤";

        mixedText = mixedText.Replace(escapeTag + tagStart, escapeTemp);
        string[] segments = mixedText.Split(tagStart);
        if (segments.Length > 0)
        {
            foreach (string segment in segments)
            {
                string segmentUnEscaped = segment.Replace(escapeTemp, tagStart);
                segmentUnEscaped = segmentUnEscaped.Replace(escapeTag + tagEnd, escapeTemp);
                string[] equationAndText = segmentUnEscaped.Split(tagEnd, 2);
                string? equation = null;
                string? text = null;

                if (equationAndText.Length == 1)
                    text = equationAndText[0].Replace(escapeTemp, tagEnd);
                if (equationAndText.Length > 1)
                {
                    equation = equationAndText[0];
                    equation = equation.Replace(",", "."); // error if using , as decimal separator
                    equation = equation.Replace(" ", ""); // error if using spaces
                    text = equationAndText[1].Replace(escapeTemp, tagEnd);
                }

                string answer = "";

                if (equation != null)
                {
                    Dbg.WriteWithCaller("Equation: " + equation);
                    DataTable dt = new DataTable();
                    try
                    {
                        var comp = dt.Compute(equation, "");
                        if (round)
                        {
                            double num = Convert.ToDouble(comp);
                            Debug.WriteLine("num: " + num);
                            answer = Math.Round(num).ToString();
                        }
                        else
                        {
                            answer = comp.ToString() + "";
                        }
                        Dbg.WriteWithCaller("Equation result: " + answer);
                    }
                    catch
                    {
                        if (Settings.Default.MathWarning)
                            MessageBox.Show("Can't solve equation:" + Environment.NewLine + equation, ProcessingCommands.Math.Name + " error");
                        Dbg.Writeline("Can't compute equation: " + equation);
                    }
                }
                result += answer + text;
            }
        }
        return result;
    }

    /// <summary>
    /// Parses tags into Rich Text, outputs both plain and rich text.
    /// </summary>
    /// <param name="plainText"></param>
    /// <returns>string PlainText, string RichText</returns>
    private (string PlainText, string RichText) ConvertToRichText(string plainText)
    {
        //https://www.biblioscape.com/rtf15_spec.htm
        Dbg.WriteWithCaller("Parsing Rich Text: ");

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
                segmentUnEscaped = segmentUnEscaped.Replace(escapeTag + tagEnd, escapeTemp);

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


                if (tag != null && text != null)
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
                        case "default":
                            SetRTFTag(builder, text, @"\f0 ", @"");
                            break;
                        case "serif":
                            SetRTFTag(builder, text, @"\f1 ", @"");
                            break;
                        case "sans":
                            SetRTFTag(builder, text, @"\f2 ", @"");
                            break;
                        case "mono":
                            SetRTFTag(builder, text, @"\f3 ", @"");
                            break;
                        case "script":
                            SetRTFTag(builder, text, @"\f4 ", @"");
                            break;
                        case "decor":
                            SetRTFTag(builder, text, @"\f5 ", @"");
                            break;
                        case "symbol":
                            SetRTFTag(builder, text, @"\f6 ", @"");
                            break;
                        default:
                            if (tagAndText[0].Length > 0) // unknown RTF code, pass it on
                            {
                                SetRTFTag(builder, text, @"\" + tagAndText[0] + " ", @"");
                            }
                            else builder.Append(text); // empy tag <>: regular text
                            break;
                    }
                }
                else
                {
                    if (segment.Length > 0)
                        builder.Append(text);
                }
                richTextResult = rtfHeader + FontTable() + ColorTable() + builder.ToString() + @"}";
                rtfBox.Rtf = richTextResult;
            }
        }

        plainTextResult = rtfBox.Text; // destroys unicode like smileys
        rtfBox.Dispose();
        //Dbg.WriteWithCaller("Original Text: " + plainText);
        //Debug.WriteLine("Plain text result: " + plainTextResult);
        //Debug.WriteLine("Rich text result: " + richTextResult);
        return (PlainText: plainTextResult, RichText: richTextResult);
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

    private static string PromptForText(string customText)
    {
        TextPrompt prompt = new TextPrompt("Input text", "Text processing is requesting an input value." + Environment.NewLine + "(" + ProcessingCommands.Prompt.Name + " function)");
        if (prompt.ShowDialog() == DialogResult.OK)
        {
            customText = customText.Replace(ProcessingCommands.Prompt.Name, prompt.TextResult);
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
        if (customText.Contains(ProcessingCommands.PadNumber2.Name))
        {
            customText = customText.Replace(ProcessingCommands.PadNumber2.Name, "");
            padNumber = 2;
        }
        if (customText.Contains(ProcessingCommands.PadNumber3.Name))
        {
            customText = customText.Replace(ProcessingCommands.PadNumber3.Name, "");
            padNumber = 3;
        }
    }

    private void ReplaceText(ref string customText, ref string clip)
    {
        customText = customText.Replace(ProcessingCommands.Replace.Name, String.Empty);
        Clipboard.SetText(clip.Replace(mainForm.MemorySlot(1).Text, mainForm.MemorySlot(2).Text));
        clip = clip.Replace(mainForm.MemorySlot(1).Text, mainForm.MemorySlot(2).Text);
    }

    private static string ExcelQuotes(string customText)
    {
        customText = customText.Replace(ProcessingCommands.ExcelQuotes.Name, "");
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
            if (currentline.Contains(ProcessingCommands.List.Name)) //skip this line
            {
                mainForm.NumberSpinner++;
                return String.Empty;
            }
            Dbg.WriteWithCaller("Process text");
            customText = ProcessTextVariables(currentline, false).PlainText;
        }
        else
        {
            customText = String.Empty;
        }

        mainForm.NumberSpinner++;
        return customText;
    }

    private string SeparatorList(string customText, int slot = 1)
    {
        char separator = ',';
        string command = string.Empty;
        if (customText.Contains(ProcessingCommands.ValueSplitComma.Name)) // comma separator
        {
            separator = ',';
            command = ProcessingCommands.ValueSplitComma.Name;
        }
        else if (customText.Contains(ProcessingCommands.ValueSplitSemicolon.Name)) // semicolon separator
        {
            separator = ';';
            command = ProcessingCommands.ValueSplitSemicolon.Name;
        }
        else if (customText.Contains(ProcessingCommands.ValueSplitSpace.Name)) // space separator
        {
            separator = ' ';
            command = ProcessingCommands.ValueSplitSpace.Name;
        }
        else return customText;

        string[] values = mainForm.MemorySlot(slot).Text.Split(separator);
        if (values.Length > 0 && mainForm.NumberSpinner <= values.Length && mainForm.NumberSpinner >= 1)
        {
            customText = customText.Replace(command, values[(int)mainForm.NumberSpinner - 1]);
        }
        else
        {
            customText = customText.Replace(command, String.Empty);
        }
        mainForm.NumberSpinner++;
        return customText;
    }
}
