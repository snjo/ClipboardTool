using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            // get mem slot data first, so you can run other processing on it
            customText = customText.Replace("$m1", mainForm.MemorySlotText(1));
            customText = customText.Replace("$m2", mainForm.MemorySlotText(1));
            customText = customText.Replace("$m3", mainForm.MemorySlotText(1));

            // replace text in clipboard string. place first to allow for other processing on the result text. Uses mem slots 1 & 2
            if (customText.Contains("$rep"))
            {
                customText = customText.Replace("$rep", String.Empty);
                clip = clip.Replace(mainForm.MemorySlot(1).Text, mainForm.MemorySlot(2).Text);
                //customText += "|" + memorySlot(1).Text + "|" + memorySlot(2).Text + "|";
            }

            // date and time
            customText = customText.Replace("$d", DateTime.Now.ToShortDateString());
            customText = customText.Replace("$t", DateTime.Now.ToShortTimeString());

            // clipboard, case conversion
            customText = customText.Replace("$cp", clip);
            customText = customText.Replace("$cl", clip.ToLower());
            customText = customText.Replace("$cu", clip.ToUpper());

            // pad number with leading zeroes
            if (customText.Contains("$n"))
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
                customText = customText.Replace("$eq", "");
                customText = customText.Replace("\"\"", "£Q");
                customText = customText.Replace("\"", "");
                customText = customText.Replace("£Q", "\"");
            }

            // split text in mem slot 1, output lines by counter number
            if (customText.Contains("$v"))
            {
                customText = mainForm.SeparatorList(customText);
            }

            // split lines in main textbox, output lines by counter number
            if (customText.Contains("$list"))
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
            }

            //"$prompt Popup prompt to fill in a value\n" + // testing if the control can revert back to the active application
            if (customText.Contains("$prompt"))
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
            }

            // debug hotkey output
            if (customText.Contains("$Debug"))
            {

                var path = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath;
                string debug = path;
                //writeMessage(debug);
                customText = customText.Replace("$Debug", debug);
                //customText = debug;
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
    }
}
