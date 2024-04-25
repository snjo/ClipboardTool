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
        PadNumber.Convert(ref customText, ref padNumber);

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
            customText = ExcelQuotes.Convert(customText);
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
            customText = PromptForText.Process(customText);
        }

        // Convert characters in clipboard string to numbers for debugging text
        if (customText.Contains(ProcessingCommands.ClipboardCharToInt.Name))
        {
            customText = customText.Replace(ProcessingCommands.ClipboardCharToInt.Name, StringToIntSequence.Convert(clip));
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
            customText = SolveEquation.Solve(customText, round);
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
            (plainText, richText) = ConvertToRichText.Convert(customText);
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

    private void ReplaceText(ref string customText, ref string clip)
    {
        customText = customText.Replace(ProcessingCommands.Replace.Name, String.Empty);
        Clipboard.SetText(clip.Replace(mainForm.MemorySlot(1).Text, mainForm.MemorySlot(2).Text));
        clip = clip.Replace(mainForm.MemorySlot(1).Text, mainForm.MemorySlot(2).Text);
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
