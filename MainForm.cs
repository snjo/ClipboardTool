using ClipboardTool.Properties;
using Hotkeys;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using TextBox = System.Windows.Forms.TextBox;

[assembly: AssemblyVersion("1.3.*")]

namespace ClipboardTool
{
    public partial class MainForm : Form
    {
        //#pragma warning disable CS8602 // Dereference of a possibly null reference.
        //#pragma warning disable CS8604 // Possible null reference argument.
        //#pragma warning disable CS8601 // Possible null reference assignment.


        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        Settings settings = Settings.Default;
        string clipBoardText = String.Empty;
        public ProcessText process;


        public Dictionary<string, Hotkey> HotkeyList = new Dictionary<string, Hotkey>();

        // For each hotkey below, add entries in Settings, hk???Key, hk???Ctrl, hk???Alt, hk???Shift, hk???Win
        public List<string> HotkeyNames = new List<string>
        {
            "UpperCase",
            "LowerCase",
            "PlainText",
            "CapsLock",
            "ProcessText",
            "Date",
            "MemSlot1",
            "MemSlot2",
            "MemSlot3",
            "ResetNumber",
            "History",
        };

        private Icon iconUpper;
        private Icon iconLower;
        private Icon iconNormal;
        private bool oldCapslockState;
        private bool capLockStateSet = false;
        private bool alwaysOnTop = false;
        public Form Current;
        HelpForm helpForm = new HelpForm();
        string delayedKeystrokes = "";



        string tooltipText =
            "$d      Date\n" +
            "$t      Time\n" +
            "$cp     Clipboard contents\n" +
            "$cl/$cu Clipboard in lower/upper case\n" +
            "$i      Number\n" +
            "$+      Number, then increment it\n" +
            "$-      Number, then decrement it\n" +
            "$n2/$n3 Use 1-3 digits in number (01, 001)\n" +
            "$m1-$m3 Contents of the memory slots\n" +
            "$eq     Convert \"\" to \", and removes single \"\n" +
            "$rep    Replace text in clipboard. Use mem slot 1 & 2 as from/to strings.\n" +
            "$vcm    Split value in slot 1 with comma, output value[number]\n" +
            "$vsc    Split value in slot 1 with semicolon, output value[number]\n" +
            "$vsp    Split value in slot 1 with space, output value[number]\n" +
            "$list   Split lines in main textbox (skips line 1), output value[number]\n" +
            "$prompt Opens a popup box to insert a text value\n" +
            "\n" +
            "Tap the date hotkey 1-3 times while holding the modifier keys:\n" +
            "1: Just the date\n" +
            "2: Date and Time\n" +
            "3: Just the Time\n";

        public MainForm()
        {
            InitializeComponent();
            UpgradeSettings();
            Current = this;
            timerStatus.Start();
            process = new ProcessText(this);
            iconUpper = notifyIconUpper.Icon;
            iconLower = notifyIconLower.Icon;
            iconNormal = systrayIcon.Icon;
            helpForm.setText(tooltipText);

            HotkeyList = HotkeyTools.LoadHotkeys(HotkeyList, HotkeyNames, this);
            if (settings.RegisterHotkeys) // optional
            {
                HotkeyTools.RegisterHotkeys(HotkeyList);
            }
            UpdateCapsLock(true);
        }

        private void UpgradeSettings()
        {
            if (Settings.Default.UpgradeSettings)
            {
                Debug.WriteLine("Upgrading settings");
                //MessageBox.Show("Upgrading settings");
                Settings.Default.Upgrade();
                Settings.Default.UpgradeSettings = false;
            }
            else
            {
                //MessageBox.Show("Not upgrading settings");
                Debug.WriteLine("Not upgrading settings");
            }
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

                if (hotkey.Key == "")
                {
                    label.Text = "No hotkey" + hotkey.Key;
                }
                else
                {
                    label.Text = "Invalid hotkey: " + hotkey.Key;
                }

            }
            else
            {
                label.Text = "Hotkey error";
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
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
            string fullpath = Environment.ExpandEnvironmentVariables(folder);
            if (fullpath.Length > 0)
            {
                if (Directory.Exists(fullpath))
                {
                    if (fullpath.Substring(fullpath.Length - 1, 1) != "\\")
                        fullpath += "\\";
                }
            }
            if (File.Exists(fullpath + filename))
            {
                return File.ReadAllText(fullpath + filename);
            }
            return string.Empty;
        }

        public void saveTextToFile(string filename, string text)
        {
            string folder = settings.MemorySlotFolder;
            if (folder.Length > 0)
            {
                string fullpath = Environment.ExpandEnvironmentVariables(folder);
                if (Directory.Exists(fullpath))
                {
                    if (folder.Substring(folder.Length - 1, 1) != "\\")
                        folder += "\\";
                    WriteToFile(folder + filename, text);
                }
                else
                {
                    writeMessage("Couldn't save file " + filename + " to folder " + folder + Environment.NewLine +
                    "The folder does not exist." + Environment.NewLine +
                    "You can set the save location in Settings, '.txt file folder'");
                }
            }
            else
            {
                WriteToFile(filename, text);
            }
        }

        private void WriteToFile(string filename, string text)
        {
            try
            {
                string fullpath = Environment.ExpandEnvironmentVariables(filename);
                File.WriteAllText(fullpath, text);
            }
            catch
            {
                writeMessage("Couldn't save file " + filename + " to folder." + Environment.NewLine +
                    "Ensure that the folder is not write protected." + Environment.NewLine +
                    "You can set the save location in Settings, '.txt file folder'");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            HotkeyTools.ReleaseHotkeys(HotkeyList);
        }

        private void HandleHotkey(int id)
        {
            if (CheckHotkey("LowerCase", id))
            {
                sendCut();
                sendPaste(LowerCaseOnce());
            }

            if (CheckHotkey("UpperCase", id))
            {
                sendCut();
                sendPaste(UpperCaseOnce());
            }

            if (CheckHotkey("CapsLock", id))
            {
                ToggleCapsLock();
            }

            if (CheckHotkey("PlainText", id))
            {
                sendCut();
                sendPaste(PlainTextOnce());
            }

            if (CheckHotkey("ProcessText", id))
            {
                sendCut();
                sendPaste(process.ProcessTextVariables(textCustom.Text));
            }

            if (CheckHotkey("Date", id))
            {
                sendDate();
            }

            if (CheckHotkey("MemSlot1", id))
            {
                sendCut();
                sendPaste(process.ProcessTextVariables(textBox1.Text));
            }

            if (CheckHotkey("MemSlot2", id))
            {
                sendCut();
                sendPaste(process.ProcessTextVariables(textBox2.Text));
            }

            if (CheckHotkey("MemSlot3", id))
            {
                sendCut();
                sendPaste(process.ProcessTextVariables(textBox3.Text));
            }

            if (CheckHotkey("ResetNumber", id))
            {
                numericUpDown1.Value = 1;
            }

            if (CheckHotkey("History", id))
            {
                ShowHistory();
            }
        }

        private bool CheckHotkey(string hotkeyName, int id)
        {
            if (HotkeyList[hotkeyName] != null)
            {
                if (id == HotkeyList[hotkeyName].ghk.id)
                {
                    return true;
                }
            }
            return false;
        }

        private enum SendDateOption
        {
            NotStarted,
            JustDate,
            JustTime,
            DateAndTime,
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
                SendKeys.Send("^x");
            }
        }

        private void sendPaste(string output)
        {
            if (output == string.Empty) return;

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
                    SendKeys.Send("^v");
                    break;
                case "^x":
                    SendKeys.Send("^x");
                    break;
                case "^c":
                    SendKeys.Send("^c");
                    break;
                case "$SendDate":
                    SendKeys.Send(SendDateText());
                    sendDateChoice = SendDateOption.NotStarted;
                    break;
                default:
                    keystrokes = Regex.Replace(keystrokes, "[+^%~(){}]", "{$0}");
                    SendKeys.Send(keystrokes);
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

        public void SetClipBoard(string clipBoardText, bool forceClipboardUpdate = false)
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

        public void UpdateCapsLock(bool force)
        {
            bool capsLockStatus = Control.IsKeyLocked(System.Windows.Forms.Keys.CapsLock);
            if (force || !capLockStateSet || capsLockStatus != oldCapslockState)
            {
                checkBoxCapsLock.Checked = capsLockStatus;
                oldCapslockState = capsLockStatus;
                capLockStateSet = true;

                string CapsLockStatusText = "off";
                if (capsLockStatus)
                {
                    CapsLockStatusText = "on";
                    UpdateCapsLockIcon(true);
                }
                else
                {
                    UpdateCapsLockIcon(false);
                }
                systrayIcon.Text = "Clipboard Tool - Caps Lock is " + CapsLockStatusText;
            }
        }

        public void UpdateCapsLockIcon(bool capsLockOn)
        {
            if (settings.TrayIconCapslockStatus)
            {
                if (capsLockOn)
                    systrayIcon.Icon = iconUpper;
                else
                    systrayIcon.Icon = iconLower;
            }
            else
            {
                systrayIcon.Icon = iconNormal;
            }
        }

        private void timerStatus_Tick(object sender, EventArgs e)
        {
            UpdateCapsLock(false);
        }

        private void checkBoxCapsLock_Click(object sender, EventArgs e)
        {
            ToggleCapsLock();
        }

        public void setTextBoxFromClipboard(int num)
        {
            TextBox textBox;
            textBox = MemorySlot(num);
            if (Clipboard.ContainsText())
            {
                string newText = Clipboard.GetText();
                textBox.Text = newText;

                if (Settings.Default.SaveMemorySlots)
                {
                    saveMemSlotToFile(num);
                }

                if (Settings.Default.ResetCounterWhenSet)
                {
                    numericUpDown1.Value = 1;
                }

            }
        }

        private void saveMemSlotToFile(int num)
        {
            saveTextToFile("mem" + num + ".txt", MemorySlot(num).Text);
        }

        public void setClipboardFromTextBox(int num)//(TextBox textBox)
        {
            //(ProcessTextVariables(textBox1.Text));
            TextBox textBox;
            textBox = MemorySlot(num);
            if (textBox.Text != null)
            {
                if (textBox.Text.Length > 0)
                {
                    string newClipText = process.ProcessTextVariables(textBox.Text);
                    if (newClipText.Length > 0)
                        Clipboard.SetText(newClipText);
                }
                else
                {
                    Clipboard.Clear();
                }
            }

        }

        public TextBox MemorySlot(int num)
        {
            if (num == 1)
                return textBox1;
            if (num == 2)
                return textBox2;
            if (num == 3)
                return textBox3;
            return textBox1;
        }

        public string MemorySlotText(int num)
        {
            return MemorySlot(num).Text;
        }

        public int NumberSpinner
        {
            get
            {
                return (int)numericUpDown1.Value;
            }
            set
            {
                decimal newValue = numericUpDown1.Value + value;
                if (newValue <= numericUpDown1.Maximum &&
                    newValue >= numericUpDown1.Minimum)
                {
                    numericUpDown1.Value = value;
                }
            }
        }

        #region Tooltips -----------------------------------------------------

        private void showToolTipHide(object sender, EventArgs e)
        {
            toolTip.SetToolTip(buttonHide, "Hide Window. Show again using the system tray icon");
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

        private void showTooltipSaveTextToFile(object sender, EventArgs e)
        {
            toolTip.SetToolTip((Control)sender, "Save text. Text will load on start");
        }

        private void showToolTipMemSave(object sender, EventArgs e)
        {
            toolTip.SetToolTip((Control)sender, "Use clipboard text in this slot");
        }

        private void showToolTipMemLoad(object sender, EventArgs e)
        {
            toolTip.SetToolTip((Control)sender, "Update clipboard contents with this slot's text");
        }
        #endregion

        #region Button event actions -----------------------------------------
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
            Toolbar toolbar = new Toolbar(this);

            toolbar.mainform = this;
            toolbar.Show();
            //toolbar.Parent = this;
        }

        public void actionProcessText(object sender, EventArgs e)
        {
            process.ProcessTextVariables(textCustom.Text, true);
        }

        private void actionShowOptions(object sender, EventArgs e)
        {
            Options options = new Options(this);
            options.ShowDialog();
        }

        public void actionSave(object sender, EventArgs e)
        {
            var button = (System.Windows.Forms.Button)sender;
            string? tag = button.Tag.ToString();
            if (tag != null)
            {
                int num = int.Parse(tag);
                setTextBoxFromClipboard(num);
            }
        }

        public void actionLoad(object sender, EventArgs e)
        {
            var button = (System.Windows.Forms.Button)sender;
            string? tag = button.Tag.ToString();
            if (tag != null)
            {
                int num = int.Parse(tag);
                setClipboardFromTextBox(num);
            }
        }

        private void actionSaveToFile(object sender, EventArgs e)
        {
            var button = (System.Windows.Forms.Button)sender;
            string? tag = button.Tag.ToString();
            if (tag != null)
            {
                int num = int.Parse(tag);
                saveMemSlotToFile(num);
            }
        }
        #endregion

        TextHistory textHistory;
        private void buttonHistory_Click(object sender, EventArgs e)
        {
            ShowHistory();
        }

        public void ShowHistory()
        {
            if (textHistory == null)
                textHistory = new TextHistory(this);
            if (textHistory.IsDisposed)
                textHistory = new TextHistory(this);

            textHistory.Show();
            textHistory.WindowState = FormWindowState.Normal;
            textHistory.BringToFront();
            SetForegroundWindow(textHistory.Handle);
        }
    }
}