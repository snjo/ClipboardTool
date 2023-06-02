using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net.Security;
using System.Resources;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClipboardTool.Properties;
using Hotkeys;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace ClipboardTool
{
    public partial class MainForm : Form
    {

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        Settings settings = Properties.Settings.Default;
        string clipBoardText = String.Empty;

        public Dictionary<string, Hotkey> HotkeyList = new Dictionary<string, Hotkey>
        {
            //{"UpperCase", new GlobalHotkey(new Hotkey())},
            {"UpperCase", new Hotkey(new GlobalHotkey())},
            {"LowerCase", new Hotkey(new GlobalHotkey())},
            {"PlainText", new Hotkey(new GlobalHotkey())},
            {"CapsLock", new Hotkey(new GlobalHotkey())},
            {"ProcessText", new Hotkey(new GlobalHotkey())},
            {"Date", new Hotkey(new GlobalHotkey())},
            {"MemSlot1", new Hotkey(new GlobalHotkey())},
            {"MemSlot2", new Hotkey(new GlobalHotkey())},
            {"MemSlot3", new Hotkey(new GlobalHotkey())},
        };
        /*private GlobalHotkey? ghkUpperCase; //nullable (?) to avoid warning in MainForm method
        private GlobalHotkey? ghkLowerCase;
        private GlobalHotkey? ghkCapsLock;
        private GlobalHotkey? ghkPlainText;
        private GlobalHotkey? ghkProcessText;
        private GlobalHotkey? ghkDate;
        private GlobalHotkey? ghkMemSlot1;
        private GlobalHotkey? ghkMemSlot2;
        private GlobalHotkey? ghkMemSlot3;*/

        private Icon iconUpper;
        private Icon iconLower;
        private bool oldCapslockState;
        private bool capLockStateSet = false;
        private bool alwaysOnTop = false;
        public Form Current;
        public HotkeyList hotkeys = new HotkeyList();
        private bool hotkeysSet = false;
        HelpForm helpForm = new HelpForm();
        string delayedKeystrokes = "";
            

        string tooltipText =
            "$d date\n" +
            "$t time\n" +
            "$cp clipboard contents\n" +
            "$cl / $cu clipboard in lower/upper case\n" +
            "$i number\n" +
            "$+ number, then increment it\n" +
            "$- number, then decrement it\n" +
            "$n2, $n3 use 1-3 digits in number (01, 001)\n" +
            "$m1-$m3 contents of the memory slots\n" +
            "$eq Convert \"\" to \", and removes single \"\n" +
            "$rep Replace text in clipboard. Use mem slot 1 & 2 as from/to strings.\n" +
            "$vcm Split value in slot 1 with comma, output value[number]\n" +
            "$vsc Split value in slot 1 with semicolon, output value[number]\n" +
            "$vsp Split value in slot 1 with space, output value[number]\n" +
            "$list Split lines in main textbox (skips line 1), output value[number]\n" +
            "\n" +
            "Tap the date hotkey 1-3 times while holding the modifier keys:\n" +
            "1: Just the date\n" +
            "2: Date and Time\n" +
            "3: Just the Time\n";

        public MainForm()
        {
            InitializeComponent();
            Current = this;
            timerStatus.Start();

            iconUpper = notifyIcon1.Icon;
            iconLower = systrayIcon.Icon;
            helpForm.setText(tooltipText);
        }

        public void LoadHotkeys()
        {
            Settings newSettings = new();                        
            
            foreach (KeyValuePair<string, Hotkey> kvp in HotkeyList )
            {
                HotkeyList[kvp.Key] = LoadHotkey(kvp.Key);
            }            
        }

        private Hotkey LoadHotkey(string hotkeyName) //char settingHotkey
        {
            //Settings.Default["hk" + hotkeyName + "Key"]
            Hotkey hotkey = new Hotkey();
            hotkey.key = Settings.Default["hk" + hotkeyName + "Key"].ToString();
            hotkey.Ctrl = (bool)Settings.Default["hk" + hotkeyName + "Ctrl"];
            hotkey.Alt = (bool)Settings.Default["hk" + hotkeyName + "Alt"];
            hotkey.Shift = (bool)Settings.Default["hk" + hotkeyName + "Shift"];
            hotkey.Win = (bool)Settings.Default["hk" + hotkeyName + "Win"];
            hotkey.ghk = new Hotkeys.GlobalHotkey(hotkey.Modifiers(), hotkey.key, this);
            return hotkey;
        }

        private Hotkey LoadHotkey(string settingHotkey, bool Ctrl, bool Alt, bool Shift, bool Win) //char settingHotkey
        {            
            Hotkey hotkey = new Hotkey();
            hotkey.key = settingHotkey;
            hotkey.Ctrl = Ctrl;
            hotkey.Alt = Alt;
            hotkey.Shift = Shift;
            hotkey.Win = Win;
            hotkey.ghk = new Hotkeys.GlobalHotkey(hotkey.Modifiers(), hotkey.key, this);            
            return hotkey;
        }

        private GlobalHotkey LoadHotkey(out Hotkey hotkey, string settingHotkey, bool Ctrl, bool Alt, bool Shift, bool Win) //char settingHotkey
        {
            GlobalHotkey? result = null;
            hotkey = new Hotkey();
            hotkey.key = settingHotkey;
            hotkey.Ctrl = Ctrl;
            hotkey.Alt = Alt;
            hotkey.Shift = Shift;
            hotkey.Win = Win;
            if (hotkey != null)
            {
                if (hotkey.key != "") //!=0
                {
                    result = new Hotkeys.GlobalHotkey(hotkey.Modifiers(), hotkey.key, this);
                    hotkey.ghk = result;
                }
                else
                {
                    //throw new Exception("hotkey is 0");
                }
            }
            else
            {
                //throw new Exception("hotkey is null");
            }
            return result;
        }

        private void updateHotkeyLabels()
        {
            updateHotkeyLabel(HotkeyList["UpperCase"], labelUpper);            
            updateHotkeyLabel(HotkeyList["LowerCase"], labelLower);
            updateHotkeyLabel(HotkeyList["PlainText"], labelPlain);
            updateHotkeyLabel(HotkeyList["CapsLock"], labelCaps);
            updateHotkeyLabel(HotkeyList["ProcessText"], labelProcess);
        }

        private void updateHotkeyLabel(Hotkey hotkey, Label label)
        {
            if (hotkey != null)
            {
                if (hotkey.ghk != null)
                {
                    if (hotkey.ghk.registered)
                    {
                        label.Text = hotkey.Text();
                        return;
                    }
                }

                if (hotkey.key == "")
                {
                    label.Text = "No hotkey" + hotkey.key;
                }
                else
                {
                    label.Text = "Invalid hotkey: " + hotkey.key;
                }

            }
            else
            {
                label.Text = "Hotkey error";
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadHotkeys();
            RegisterHotKeys();

            if (settings.StartHidden)
            {
                WindowState = FormWindowState.Minimized;
                Hide();
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }

            if (settings.StartToolbar)
            {
                actionShowToolbar(sender, e);
            }

            updateHotkeyLabels();


            textCustom.Text = loadTextFromFile("process.txt");
            textBox1.Text = loadTextFromFile("mem1.txt");
            textBox2.Text = loadTextFromFile("mem2.txt");
            textBox3.Text = loadTextFromFile("mem3.txt");
        }

        private string loadTextFromFile(string filename)
        {
            string folder = settings.MemorySlotFolder;
            if (folder.Length > 0)
            {
                if (folder.Substring(folder.Length - 1, 1) != "\\")
                    folder += "\\";
            }
            if (File.Exists(folder + filename))
            {
                return File.ReadAllText(folder + filename);
            }
            return "";
        }

        public void saveTextToFile(string filename, string text)
        {
            string folder = settings.MemorySlotFolder;
            if (folder.Length > 0)
            {
                if (Directory.Exists(folder))
                {
                    if (folder.Substring(folder.Length - 1, 1) != "\\")
                        folder += "\\";
                    File.WriteAllText(folder + filename, text);
                }
            }
            else
            {
                File.WriteAllText(filename, text);
            }
        }

        public void RegisterHotKeys()
        {
            if (!settings.RegisterHotkeys) return;

            hotkeysSet = true;

            string errorMessages = "";
            //trying to register hotkey

            foreach (KeyValuePair<string, Hotkey> ghk in HotkeyList)
            {
                RegisterHotKey(ghk.Value.ghk);
            }

            if (errorMessages.Length > 0)
            {
                writeMessage(errorMessages);
            }
        }

        private void RegisterHotKey(GlobalHotkey ghk)
        {
            if (ghk != null)
            {
                if (!ghk.Register())
                {
                    //writeMessage("register hotkey failed");
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ReleaseHotkeys();
        }

        public void ReleaseHotkeys()
        {
            if (!hotkeysSet) return;

            foreach (KeyValuePair<string, Hotkey> ghk in HotkeyList)
            {
                ReleaseHotkey(ghk.Value.ghk);
            }
        }

        private void ReleaseHotkey(GlobalHotkey ghk)
        {
            if (ghk != null)
            {
                ghk.Unregister();
            }
        }


        private void HandleHotkey(int id)
        {

            if (HotkeyList["LowerCase"] != null)
            {
                if (id == HotkeyList["LowerCase"].ghk.id)
                {
                    sendCut();

                    sendPaste(LowerCaseOnce());
                }
            }
            
            //if (ghkUpperCase != null)
            if (HotkeyList["UpperCase"] != null)
            {
                //if (id == ghkUpperCase.id)
                if (id == HotkeyList["UpperCase"].ghk.id)
                {
                    sendCut();

                    sendPaste(UpperCaseOnce());
                }
            }

            if (HotkeyList["CapsLock"] != null)
            {
                if (id == HotkeyList["CapsLock"].ghk.id)
                {
                    ToggleCapsLock();
                }
            }

            if (HotkeyList["PlainText"] != null)
            {
                if (id == HotkeyList["PlainText"].ghk.id)
                {
                    sendCut();

                    sendPaste(PlainTextOnce());
                }
            }

            if (HotkeyList["ProcessText"] != null)
            {
                if (id == HotkeyList["ProcessText"].ghk.id)
                {
                    sendCut();

                    sendPaste(ProcessTextVariables(textCustom.Text));
                }
            }

            if (HotkeyList["Date"] != null)
            {
                if (id == HotkeyList["Date"].ghk.id)
                {
                    sendDate();
                }
            }
            
            if (HotkeyList["MemSlot1"] != null)
            {
                if (id == HotkeyList["MemSlot1"].ghk.id)
                {
                    SetClipBoard(textBox1.Text, settings.sendPaste); //only update if ctrl+v is in use
                    sendPaste(textBox1.Text);
                }
            }
            if (HotkeyList["MemSlot2"] != null)
            {
                if (id == HotkeyList["MemSlot2"].ghk.id)
                {
                    SetClipBoard(textBox2.Text, settings.sendPaste);
                    sendPaste(textBox2.Text);
                }
            }
            if (HotkeyList["MemSlot3"] != null)
            {
                if (id == HotkeyList["MemSlot3"].ghk.id)
                {
                    SetClipBoard(textBox3.Text, settings.sendPaste);
                    sendPaste(textBox3.Text);
                }
            }
        }

        private enum SendDateOption
        {
            NotStarted,
            JustDate,
            DateAndTime,
            JustTime,
            END
        }
        private SendDateOption sendDateChoice = SendDateOption.NotStarted;

        private void sendDate()
        {
            if (sendDateChoice < SendDateOption.END - 1)
            {
                sendDateChoice = sendDateChoice + 1;
            }

            delayKeystrokes("$SendDate");
        }

        private string SendDateText()
        {
            string outDate = "init outDate (SendDate error)";
            switch (sendDateChoice)
            {
                case SendDateOption.NotStarted:
                    outDate = "Use Date/Time hotkey (SendDate error)";
                    break;
                case SendDateOption.JustDate:
                    outDate = DateTime.Now.ToShortDateString();
                    break;
                case SendDateOption.DateAndTime:
                    outDate = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                    break;
                case SendDateOption.JustTime:
                    outDate = DateTime.Now.ToShortTimeString();
                    break;
                default:
                    outDate = "Pressed beyond the enum (SendDate error)";
                    break;
            }

            return outDate;
        }

        private void sendCut()
        {
            if (settings.sendCut)
            {
                SendKeys.SendWait("^x");
            }
        }

        private void sendPaste(string output)
        {
            if (settings.sendPaste)
            {
                delayKeystrokes("^v");
            }
            else if (settings.sendType)
            {
                delayKeystrokes(output);
            }
        }

        private void delayKeystrokes(string keystrokes)
        {
            delayedKeystrokes = keystrokes;
            timerKeystrokes.Start();
        }

        private void sendKeystrokes(string keystrokes)
        {
            switch (keystrokes)
            {
                case "^v":
                    SendKeys.SendWait("^v");
                    break;
                case "^x":
                    SendKeys.SendWait("^x");
                    break;
                case "^c":
                    SendKeys.SendWait("^c");
                    break;
                case "$SendDate":
                    SendKeys.SendWait(SendDateText());
                    sendDateChoice = SendDateOption.NotStarted;
                    break;
                default:
                    keystrokes = Regex.Replace(keystrokes, "[+^%~(){}]", "{$0}");
                    //keystrokes = Regex.Replace(keystrokes, "[+%~(){}]", "{$0}");
                    //keystrokes = keystrokes.Replace("^", "%(94)");  //alt ascii code doesn't work :(
                    SendKeys.SendWait(keystrokes);
                    break;
            }

            // warning: ^'s will become &'s on non-US keyboards:
            // https://stackoverflow.com/questions/47635218/sending-a-caret-with-system-windows-forms-sendkeys-send-will-send-ampersand
            // use paste method instead of sendkeys if the text includes carets
        }

        private void actionDelayedKeystrokes(object sender, EventArgs e)
        {
            if (ModifierKeys == Keys.None)
            {
                timerKeystrokes.Stop();
                if (delayedKeystrokes != null)
                    sendKeystrokes(delayedKeystrokes);
            }
        }

        private string PlainTextOnce(bool forceClipboardUpdate = false)
        {
            string result = Clipboard.GetText(TextDataFormat.Text);
            SetClipBoard(result, forceClipboardUpdate);
            return result;
            //setClipBoard(clipBoardText);
        }

        private string UpperCaseOnce(bool forceClipboardUpdate = false)
        {
            if (Clipboard.ContainsText())
            {
                string result = Clipboard.GetText(TextDataFormat.Text).ToUpper();
                SetClipBoard(result, forceClipboardUpdate);
                return result;
            }
            else return string.Empty;
        }

        private string LowerCaseOnce(bool forceClipboardUpdate = false)
        {
            if (Clipboard.ContainsText())
            {
                string result = Clipboard.GetText(TextDataFormat.Text).ToLower();
                SetClipBoard(result, forceClipboardUpdate);
                return result;

            }
            else return string.Empty;
        }

        private void SetClipBoard(string clipBoardText, bool forceClipboardUpdate = false)
        {
            if (!settings.updateClipboard && settings.sendType && !forceClipboardUpdate) return;
            if (clipBoardText.Length > 0)
            {
                Clipboard.SetText(clipBoardText);
            }
            else
            {
                Clipboard.Clear();
            }
        }

        private static void ToggleCapsLock()
        {
            const int KEYEVENTF_EXTENDEDKEY = 0x1;
            const int KEYEVENTF_KEYUP = 0x2;
            if (Control.IsKeyLocked(System.Windows.Forms.Keys.CapsLock))
            {
                keybd_event((byte)Keys.CapsLock, 0, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
                keybd_event((byte)Keys.CapsLock, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr)0);
            }
            else //redundant at the moment
            {
                keybd_event((byte)Keys.CapsLock, 0, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
                keybd_event((byte)Keys.CapsLock, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr)0);
            }
        }

        private void writeMessage(string text)
        {
            MessageBox.Show(text);
            //label1.Text = text;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == Hotkeys.Constants.WM_HOTKEY_MSG_ID)
            {
                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);                  // The key of the hotkey that was pressed.
                KeyModifier modifier = (KeyModifier)((int)m.LParam & 0xFFFF);       // The modifier of the hotkey that was pressed.
                int id = m.WParam.ToInt32();                                        // The id of the hotkey that was pressed.
                //MessageBox.Show("Hotkey " + id + " has been pressed!");
                HandleHotkey(id);
            }
        }

        private void UpdateCapsLock()
        {
            bool capsLockStatus = Control.IsKeyLocked(System.Windows.Forms.Keys.CapsLock);
            if (!capLockStateSet || capsLockStatus != oldCapslockState)
            {
                checkBoxCapsLock.Checked = capsLockStatus;
                oldCapslockState = capsLockStatus;
                capLockStateSet = true;

                string CapsLockStatusText = "off";
                if (capsLockStatus)
                {
                    CapsLockStatusText = "on";
                    systrayIcon.Icon = iconUpper;
                }
                else
                {
                    systrayIcon.Icon = iconLower;
                }
                systrayIcon.Text = "Case Converter - Caps Lock is " + CapsLockStatusText;
            }
        }

        private void timerStatus_Tick(object sender, EventArgs e)
        {
            UpdateCapsLock();
        }

        private void checkBoxCapsLock_Click(object sender, EventArgs e)
        {
            ToggleCapsLock();
        }



        private string ProcessTextVariables(string customText, bool forceClipboardUpdate = false)
        {
            if (customText == null) return String.Empty;

            int padNumber = 1;
            string clip = Clipboard.GetText();

            // get mem slot data first, so you can run other processing on it
            customText = customText.Replace("$m1", textBox1.Text);
            customText = customText.Replace("$m2", textBox2.Text);
            customText = customText.Replace("$m3", textBox3.Text);

            // replace text in clipboard string. place first to allow for other processing on the result text. Uses mem slots 1 & 2
            if (customText.Contains("$rep"))
            {
                customText = customText.Replace("$rep", String.Empty);
                clip = clip.Replace(memorySlot(1).Text, memorySlot(2).Text);
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
            customText = customText.Replace("$i", numericUpDown1.Value.ToString().PadLeft(padNumber, '0'));

            // output counter number, then increment it
            if (customText.Contains("$+"))
            {
                customText = customText.Replace("$+", numericUpDown1.Value.ToString().PadLeft(padNumber, '0'));
                if (numericUpDown1.Value < numericUpDown1.Maximum)
                    numericUpDown1.Value++;
            }

            // output counter number, then decrement it
            if (customText.Contains("$-"))
            {
                customText = customText.Replace("$-", numericUpDown1.Value.ToString().PadLeft(padNumber, '0'));
                if (numericUpDown1.Value > numericUpDown1.Minimum)
                    numericUpDown1.Value--;
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
                customText = SeparatorList(customText);
            }

            // split lines in main textbox, output lines by counter number
            if (customText.Contains("$list"))
            {
                string[] values = customText.Split(Environment.NewLine, StringSplitOptions.None);

                if (numericUpDown1.Value < 1) numericUpDown1.Value = 1; // skip the first line with the $list

                int num = (int)numericUpDown1.Value;
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
                        numericUpDown1.Value++;
                        return String.Empty;
                    }
                    customText = ProcessTextVariables(currentline, false);
                }
                else
                {
                    customText = String.Empty;
                }

                if (numericUpDown1.Value < numericUpDown1.Maximum)
                    numericUpDown1.Value++;
            }

            // debug hotkey output
            if (customText.Contains("$debug"))
            {
                //string debug = HotkeyList["UpperCase"].hotkey.key;
                //customText.Replace("$debug", debug);
            }

                if (customText.Length < 1)
            {
                return "";
            }
            else
            {
                SetClipBoard(customText, forceClipboardUpdate);
                return customText;
            }
        }

        private string SeparatorList(string customText, int slot = 1)
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


            string[] values = memorySlot(slot).Text.Split(separator);
            if (values.Length > 0 && numericUpDown1.Value <= values.Length && numericUpDown1.Value >= 1)
            {
                customText = customText.Replace(command, values[(int)numericUpDown1.Value - 1]);
                //customText = values[(int)numericUpDown1.Value];
            }
            else
            {
                customText = customText.Replace(command, String.Empty);
            }
            if (numericUpDown1.Value < numericUpDown1.Maximum)
                numericUpDown1.Value++;
            return customText;
        }

        private TextBox memorySlot(int num)
        {
            if (num == 1)
                return textBox1;
            if (num == 2)
                return textBox2;
            if (num == 3)
                return textBox3;
            return textBox1;
        }

        public void setTextBoxFromClipboard(int num)
        {
            TextBox textBox;
            textBox = SetTextBoxTarget(num);
            if (Clipboard.ContainsText())
            {
                string newText = Clipboard.GetText();
                textBox.Text = newText;

                if (Properties.Settings.Default.SaveMemorySlots)
                {
                    saveMemSlotToFile(num);
                }

                if (Properties.Settings.Default.ResetCounterWhenSet)
                {
                    numericUpDown1.Value = 1;
                }

            }
        }

        private void saveMemSlotToFile(int num)
        {
            saveTextToFile(".\\mem" + num + ".txt", SetTextBoxTarget(num).Text);
        }

        public void setClipboardFromTextBox(int num)//(TextBox textBox)
        {
            TextBox textBox;
            textBox = SetTextBoxTarget(num);
            if (textBox.Text != null)
            {
                if (textBox.Text.Length > 0)
                {
                    Clipboard.SetText(textBox.Text);
                }
                else
                {
                    Clipboard.Clear();
                }
            }

        }

        private TextBox SetTextBoxTarget(int num)
        {
            TextBox textBox;
            switch (num)
            {
                case 1:
                    {
                        textBox = textBox1;
                        break;
                    }
                case 2:
                    {
                        textBox = textBox2;
                        break;
                    }
                case 3:
                    {
                        textBox = textBox3;
                        break;
                    }
                default:
                    {
                        textBox = textBox1;
                        break;
                    }
            }

            return textBox;
        }

        public string getMemorySlot(int num)
        {
            TextBox textBox;
            textBox = SetTextBoxTarget(num);
            return textBox.Text;
        }

        private void actionAlwaysOnTop(object sender, EventArgs e)
        {
            alwaysOnTop = !alwaysOnTop;
            if (alwaysOnTop)
            {
                TopMost = true;
            }
            else
            {
                TopMost = false;
            }
        }

        private void actionShowHelp(object sender, EventArgs e)
        {
            if (helpForm == null || helpForm.IsDisposed)
            {
                helpForm = new HelpForm();
            }

            helpForm.setText(tooltipText);
            helpForm.Show();
        }

        private void actionSaveCustomText(object sender, EventArgs e)
        {
            saveTextToFile("process.txt", textCustom.Text);
        }

        private void showToolTipHide(object sender, EventArgs e)
        {
            toolTip.SetToolTip(buttonHide, "Hide Window");
        }

        private void showTooltipPin(object sender, EventArgs e)
        {
            toolTip.SetToolTip(buttonPin, "Pin program (Always on top)");
        }

        private void showTooltipSettings(object sender, EventArgs e)
        {
            toolTip.SetToolTip(buttonOptions, "Settings");
        }

        private void showTooltipHelp(object sender, EventArgs e)
        {
            toolTip.SetToolTip(buttonHelp, "Help: Processing variables");
        }

        private void showTooltipSaveCustom(object sender, EventArgs e)
        {
            toolTip.SetToolTip(buttonSaveCustom, "Save text. Text will load on start");
        }

        private void showToolTipMemSave(object sender, EventArgs e)
        {
            toolTip.SetToolTip((Control)sender, "Use clipboard text in this slot");
        }

        private void showToolTipMemLoad(object sender, EventArgs e)
        {
            toolTip.SetToolTip((Control)sender, "Update clipboard contents with this slot's text");
        }

        private void actionCapsLock(object sender, EventArgs e)
        {
            ToggleCapsLock();
        }

        private void actionShowWindow(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            Show();
        }

        private void actionExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void actionCapsLock(object sender, MouseEventArgs e)
        {
            ToggleCapsLock();
        }

        public void actionUpperCaseOnce(object sender, EventArgs e)
        {
            UpperCaseOnce(true);
        }

        public void actionLowerCaseOnce(object sender, EventArgs e)
        {
            LowerCaseOnce(true);
        }

        public void actionHideFromTaskbar(object sender, EventArgs e)
        {
            Hide();
        }

        public void actionPlainTextOnce(object sender, EventArgs e)
        {
            PlainTextOnce(true);
        }

        private void actionShowToolbar(object sender, EventArgs e)
        {
            Toolbar toolbar = new Toolbar();

            toolbar.mainform = this;
            toolbar.Show();
            //toolbar.Parent = this;
        }

        public void actionProcessText(object sender, EventArgs e)
        {
            ProcessTextVariables(textCustom.Text, true);
        }

        private void actionShowOptions(object sender, EventArgs e)
        {
            Options options = new Options(this);
            options.ShowDialog();
        }

        public void actionSave(object sender = null, EventArgs e = null)
        {
            var button = (System.Windows.Forms.Button)sender;
            int num = int.Parse(button.Tag.ToString());
            setTextBoxFromClipboard(num);
        }

        public void actionLoad(object sender = null, EventArgs e = null)
        {
            var button = (System.Windows.Forms.Button)sender;
            int num = int.Parse(button.Tag.ToString());
            setClipboardFromTextBox(num);
        }

        private void actionSaveToFile(object sender, EventArgs e)
        {
            var button = (System.Windows.Forms.Button)sender;
            int num = int.Parse(button.Tag.ToString());
            saveMemSlotToFile(num);
        }
    }
}