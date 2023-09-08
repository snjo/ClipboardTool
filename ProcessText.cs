using System.Configuration;

namespace ClipboardTool
{
    internal class ProcessText
    {
        MainForm mainForm;
        public ProcessText(MainForm parent)
        {
            mainForm = parent;
        }

        public string ProcessTextVariables(string customText, bool forceClipboardUpdate = false)
        {
            if (customText == null) return String.Empty;

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

            if (customText.Length < 1)
            {
                return "";
            }
            else
            {
                mainForm.SetClipBoard(customText, forceClipboardUpdate);
                return customText;
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
            TextPrompt prompt = new TextPrompt();
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
