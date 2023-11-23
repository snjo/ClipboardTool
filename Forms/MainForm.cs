using ClipboardTool.Classes;
using ClipboardTool.Properties;
using DebugTools;
using Hotkeys;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using TextBox = System.Windows.Forms.TextBox;

[assembly: AssemblyVersion("1.7.*")]

namespace ClipboardTool;

public partial class MainForm : Form
{
    [DllImport("user32.dll")]
    static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    static extern bool SetForegroundWindow(IntPtr hWnd);

    Settings settings = Settings.Default;
    private ProcessText _process;
    private MainMethods _mainMethods;
    TextHistory? textHistory;

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
    HelpForm helpForm = new HelpForm();
    public CultureInfo startingCulture = CultureInfo.CurrentCulture;

    public MainForm()
    {
        InitializeComponent();
        timerStatus.Start();
        _process = new ProcessText(this);
        _mainMethods = new MainMethods(this);
        main.UpgradeSettings();
        main.UpdateCulture();
        iconUpper = notifyIconUpper.Icon;
        iconLower = notifyIconLower.Icon;
        iconNormal = systrayIcon.Icon;
        helpForm.setText(process.commands.GetListAsText());
        HotkeyList = HotkeyTools.LoadHotkeys(HotkeyList, HotkeyNames, this);
        if (settings.RegisterHotkeys) // optional
        {
            HotkeyTools.RegisterHotkeys(HotkeyList);
        }
        UpdateCapsLock(forceUpdate: true);
    }

    public ProcessText process
    {
        get { return _process; }
        set { _process = value; }
    }

    public MainMethods main
    {
        get { return _mainMethods; }
        set { _mainMethods = value; }
    }


    private void updateHotkeyLabels()
    {
        main.updateHotkeyLabel(HotkeyList["UpperCase"], labelUpper);
        main.updateHotkeyLabel(HotkeyList["LowerCase"], labelLower);
        main.updateHotkeyLabel(HotkeyList["PlainText"], labelPlain);
        main.updateHotkeyLabel(HotkeyList["CapsLock"], labelCaps);
        main.updateHotkeyLabel(HotkeyList["ProcessText"], labelProcess);
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


        textCustom.Text = main.loadTextFromFile("process.txt");
        textBox1.Text = main.loadTextFromFile("mem1.txt");
        textBox2.Text = main.loadTextFromFile("mem2.txt");
        textBox3.Text = main.loadTextFromFile("mem3.txt");
    }



    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        HotkeyTools.ReleaseHotkeys(HotkeyList);
        if (Settings.Default.SaveMemorySlots)
        {
            main.saveMemSlotToFile(1, warnIfFailed: false);
            main.saveMemSlotToFile(2, warnIfFailed: false);
            main.saveMemSlotToFile(3, warnIfFailed: false);
        }
    }



    public void ToggleCapsLock()
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

    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);
        if (m.Msg == Hotkeys.Constants.WM_HOTKEY_MSG_ID)
        {
            Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);                  // The key of the hotkey that was pressed.
            KeyModifier modifier = (KeyModifier)((int)m.LParam & 0xFFFF);       // The modifier of the hotkey that was pressed.
            int id = m.WParam.ToInt32();                                        // The id of the hotkey that was pressed.
            main.HandleHotkey(id);
        }
    }

    public void UpdateCapsLock(bool forceUpdate)
    {
        bool capsLockStatus = Control.IsKeyLocked(System.Windows.Forms.Keys.CapsLock);
        if (forceUpdate || !capLockStateSet || capsLockStatus != oldCapslockState)
        {
            checkBoxCapsLock.Checked = capsLockStatus;
            oldCapslockState = capsLockStatus;
            capLockStateSet = true;

            string CapsLockStatusText = "off";
            if (capsLockStatus)
            {
                CapsLockStatusText = "on";
                UpdateCapsLockIcon(capsLockOn: true);
            }
            else
            {
                UpdateCapsLockIcon(capsLockOn: false);
            }
            systrayIcon.Text = "Clipboard Tool - Caps Lock is " + CapsLockStatusText;
        }
    }

    private void UpdateCapsLockIcon(bool capsLockOn)
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
        UpdateCapsLock(forceUpdate: false);
    }

    private void checkBoxCapsLock_Click(object sender, EventArgs e)
    {
        ToggleCapsLock();
    }



    public TextBox MemorySlot(int num)
    {
        if (num == 0)
            return textCustom;
        if (num == 1)
            return textBox1;
        if (num == 2)
            return textBox2;
        if (num == 3)
            return textBox3;
        return textBox1;
    }

    public void StartTimerKeystrokes()
    {
        timerKeystrokes.Start();
    }
    public void StopTimerKeystrokes()
    {
        timerKeystrokes.Stop();
    }


    public string MemorySlotText(int num)
    {
        return MemorySlot(num).Text;
    }

    private void actionDelayedKeystrokes(object sender, EventArgs e)
    {
        if (ModifierKeys == Keys.None)
        {
            main.DelayKeyStrokes();
        }
        //hotkeyHeldDown = false;
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
            if (newValue <= numericUpDown1.Maximum && newValue >= numericUpDown1.Minimum)
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

        helpForm.setText(process.commands.GetListAsText());
        helpForm.Show();
    }

    private void actionSaveCustomText(object sender, EventArgs e)
    {
        main.saveTextToFile("process.txt", textCustom.Text, warnIfFailed: true);
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

    //public void actionCapsLock(object sender, MouseEventArgs e)
    //{
    //    ToggleCapsLock();
    //}

    public void actionUpperCaseOnce(object sender, EventArgs e)
    {
        main.UpperCaseOnce(forceClipboardUpdate: true);
    }

    public void actionLowerCaseOnce(object sender, EventArgs e)
    {
        main.LowerCaseOnce(forceClipboardUpdate: true);
    }

    public void actionHideFromTaskbar(object sender, EventArgs e)
    {
        Hide();
    }

    public void actionPlainTextOnce(object sender, EventArgs e)
    {
        main.PlainTextOnce(forceClipboardUpdate: true);
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
        Dbg.WriteWithCaller("Process text");
        process.ProcessTextVariables(textCustom.Text, true);
    }

    private void actionShowOptions(object sender, EventArgs e)
    {
        Options options = new Options(this);
        options.ShowDialog();
        options.Dispose();
    }

    private void actionSave(object sender, EventArgs e)
    {
        var button = (System.Windows.Forms.Button)sender;
        string? tag = button.Tag.ToString();
        if (tag != null)
        {
            int num = int.Parse(tag);
            main.setTextBoxFromClipboard(num);
        }
    }

    private void actionLoad(object sender, EventArgs e)
    {
        var button = (System.Windows.Forms.Button)sender;
        string? tag = button.Tag.ToString();
        if (tag != null)
        {
            int num = int.Parse(tag);
            main.setClipboardFromTextBox(num);
        }
    }

    private void actionSaveToFile(object sender, EventArgs e)
    {
        var button = (System.Windows.Forms.Button)sender;
        string? tag = button.Tag.ToString();
        if (tag != null)
        {
            int num = int.Parse(tag);
            main.saveMemSlotToFile(num, warnIfFailed: true);
        }
    }
    #endregion

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