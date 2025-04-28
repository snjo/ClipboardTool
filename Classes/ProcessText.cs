using DebugTools;
using System.Diagnostics;
using System.Runtime.Versioning;

namespace ClipboardTool.Classes;

[SupportedOSPlatform("windows")]

public class ProcessText(MainForm parent)
{
    readonly MainForm mainForm = parent;
    public ProcessingCommands commands = new();
    string clipboardText = "";

    /// <summary>
    /// Processes text with $-commands, outputs both plain and rich text.
    /// </summary>
    /// <param name="plainText"></param>
    /// <returns>string PlainText, string RichText</returns>
    public (string PlainText, string? RichText) ProcessTextVariables(string customText, int recursionDepth, bool forceClipboardUpdate = false) //(string, string)
    {
        Debug.WriteLine($"Recursion {recursionDepth}");
        if (recursionDepth > 3)
        {
            Debug.WriteLine($"Halting processing at recursion depth of 3");
            return ("", null);
        }
        //Debug.WriteLine("ProcessTextVariables start, clipboardupdate: " + forceClipboardUpdate);
        if (customText == null) return (PlainText: string.Empty, RichText: null);
        string plainText;// = string.Empty;
        string? richText;// = string.Empty;

        int padNumber = 1;
        //string clip = Clipboard.GetText(TextDataFormat.UnicodeText);
        if (recursionDepth < 1)
        {
            clipboardText = Clipboard.GetText();
        }

        int modifyNumberSpinnerValue = 0;

        // Update the number spinner before processing
        if (customText.Contains(ProcessingCommands.NumberIncrementPost.Name))
        {
            customText = customText.Replace(ProcessingCommands.NumberIncrementPost.Name, "");
            modifyNumberSpinnerValue += 1;
        }

        if (customText.Contains(ProcessingCommands.NumberDecrementPost.Name))
        {
            customText = customText.Replace(ProcessingCommands.NumberDecrementPost.Name, "");
            modifyNumberSpinnerValue -= 1;
        }

        // Update the number spinner after processing
        if (customText.Contains(ProcessingCommands.NumberIncrementPre.Name))
        {
            customText = customText.Replace(ProcessingCommands.NumberIncrementPre.Name, "");
            mainForm.NumberSpinner++;
        }

        if (customText.Contains(ProcessingCommands.NumberDecrementPre.Name))
        {
            customText = customText.Replace(ProcessingCommands.NumberDecrementPre.Name, "");
            mainForm.NumberSpinner--;
        }


        // replace text in clipboard string. place first to allow for other processing on the result text. Uses mem slots 1 & 2
        if (customText.Contains(ProcessingCommands.Replace.Name))
        {
            ReplaceText(ref customText, ref clipboardText);
        }

        // get mem slot data first, so you can run other processing on it
        customText = customText.Replace(ProcessingCommands.MemSlot1.Name, mainForm.MemorySlotText(1));
        customText = customText.Replace(ProcessingCommands.MemSlot2.Name, mainForm.MemorySlotText(2));
        customText = customText.Replace(ProcessingCommands.MemSlot3.Name, mainForm.MemorySlotText(3));

        // date and time
        customText = customText.Replace(ProcessingCommands.Date.Name, DateTime.Now.ToShortDateString());
        customText = customText.Replace(ProcessingCommands.Time.Name, DateTime.Now.ToShortTimeString());

        // clipboard, case conversion
        customText = customText.Replace(ProcessingCommands.ClipboardPlain.Name, clipboardText);
        customText = customText.Replace(ProcessingCommands.ClipboardUpper.Name, clipboardText.ToUpper());
        customText = customText.Replace(ProcessingCommands.ClipboardLower.Name, clipboardText.ToLower());

        // pad number with leading zeroes
        PadNumber.Convert(ref customText, ref padNumber);

        // output counter number
        customText = customText.Replace(ProcessingCommands.Number.Name, mainForm.NumberSpinner.ToString().PadLeft(padNumber, '0'));

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
            customText = ListSplit(customText, recursionDepth);
        }

        // split lines in slot 1-3 for use in processing text from other slot or text library. Processes line contents wit no clipboard output.
        if (customText.Contains(ProcessingCommands.ListLines1.Name))
        {
            customText = customText.Replace(ProcessingCommands.ListLines1.Name, ListLineFromSlot(1, recursionDepth));
        }
        if (customText.Contains(ProcessingCommands.ListLines2.Name))
        {
            customText = customText.Replace(ProcessingCommands.ListLines2.Name, ListLineFromSlot(2, recursionDepth));
        }
        if (customText.Contains(ProcessingCommands.ListLines3.Name))
        {
            customText = customText.Replace(ProcessingCommands.ListLines3.Name, ListLineFromSlot(3, recursionDepth));
        }

        //"$prompt Popup prompt to fill in a value\n" + // testing if the control can revert back to the active application
        if (customText.Contains(ProcessingCommands.Prompt.Name))
        {
            (bool confirm, string? promptText) = PromptForText.Process(customText);
            if (confirm && promptText != null)
            {
                customText = promptText;
            }
            else
            {
                return ("", null);
            }
        }

        // Convert characters in clipboard string to numbers for debugging text
        if (customText.Contains(ProcessingCommands.ClipboardCharToInt.Name))
        {
            customText = customText.Replace(ProcessingCommands.ClipboardCharToInt.Name, StringToIntSequence.Convert(clipboardText));
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

        bool DTWFirstCapFlag = false;
        if (customText.Contains(ProcessingCommands.DigitToWordFirstCap.Name))
        {
            DTWFirstCapFlag = true;
            customText = customText.Replace(ProcessingCommands.DigitToWordFirstCap.Name, "");
        }

        if (customText.Contains(ProcessingCommands.DigitToWord.Name))
        {
            customText = DigitsToWords.ProcessDigitsEnclosed(customText, DTWUpperCaseFlag, DTWFirstCapFlag);
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

        // update the number spinner after all text processing is done
        mainForm.NumberSpinner += modifyNumberSpinnerValue;

        //Debug.WriteLine("ProcessTextVariables send result");

        if (plainText.Length < 1)
        {
            return (string.Empty, string.Empty);
        }
        else
        {
            mainForm.Main.SetClipBoard(plainText, richText, forceClipboardUpdate);
            return (PlainText: plainText, RichText: richText);
        }
    }

    private void ReplaceText(ref string customText, ref string clip)
    {
        customText = customText.Replace(ProcessingCommands.Replace.Name, string.Empty);
        Clipboard.SetText(clip.Replace(mainForm.MemorySlot(1).Text, mainForm.MemorySlot(2).Text));
        clip = clip.Replace(mainForm.MemorySlot(1).Text, mainForm.MemorySlot(2).Text);
    }



    private string SeparatorList(string customText, int slot = 1)
    {
        char separator;
        string command;
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
            customText = customText.Replace(command, values[mainForm.NumberSpinner - 1]);
        }
        else
        {
            customText = customText.Replace(command, string.Empty);
        }
        mainForm.NumberSpinner++;
        return customText;
    }

    private string ListLineFromSlot(int slotNumber, int recursionDepth)
    {
        recursionDepth++;
        Debug.WriteLine($"ListLines slot:{slotNumber} rec:{recursionDepth}");
        string[] values = mainForm.MemorySlot(slotNumber).Text.Split(Environment.NewLine, StringSplitOptions.None);
        return GetSplitLines(recursionDepth, values);
    }

    private string ListSplit(string customText, int recursionDepth)
    {
        recursionDepth++;
        string[] values = customText.Split(Environment.NewLine, StringSplitOptions.None);
        Debug.WriteLine($"First entry of split lines{values[0]}");

        if (mainForm.NumberSpinner < 2)
        {
            Debug.WriteLine($"First line is just the $list command, incrementing to 2");
            mainForm.NumberSpinner = 2;
        }
        string result = GetSplitLines(recursionDepth, values);
        mainForm.NumberSpinner++;
        return result;
    }

    private string GetSplitLines(int recursionDepth, string[] values)
    {
        string result;
        if (mainForm.NumberSpinner < 1) mainForm.NumberSpinner = 1; // start at first position if 0. $list has its own check to ensure starting at 2

        int num = mainForm.NumberSpinner - 1;
        if (num >= values.Length)
        {
            return string.Empty;
        }

        string currentline = values[num];

        if (values.Length > 0)
        {
            if (currentline.Contains(ProcessingCommands.List.Name)) //skip this line
            {
                //mainForm.NumberSpinner++;
                return string.Empty;
            }
            Dbg.WriteWithCaller("Process text");
            result = ProcessTextVariables(currentline, recursionDepth, false).PlainText;
        }
        else
        {
            result = string.Empty;
        }

        return result;
    }
}
