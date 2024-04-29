using ClipboardTool.Classes;
using ClipboardTool.Properties;
using DebugTools;
using Hotkeys;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using TextBox = System.Windows.Forms.TextBox;

[assembly: AssemblyVersion("1.8.*")]

namespace ClipboardTool;
[SupportedOSPlatform("windows")]

public partial class MainForm : Form
{
    [LibraryImport("user32.dll")]
    private static partial void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
    [LibraryImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static partial bool SetForegroundWindow(IntPtr hWnd);

    public static readonly string ApplicationName = "ClipboardTool";
    readonly Settings settings = Settings.Default;
    private ProcessText _process;
    private MainMethods _mainMethods;
    TextLibrary? textTextLibrary;

    public Dictionary<string, Hotkey> HotkeyList = [];

    // For each hotkey below, add entries in Settings, hk???Key, hk???Ctrl, hk???Alt, hk???Shift, hk???Win
    public List<string> HotkeyNames =
    [
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
        "TextLibrary",
    ];

    private readonly Icon? iconUpper;
    private readonly Icon? iconLower;
    private readonly Icon? iconNormal;
    private bool oldCapslockState;
    private bool capLockStateSet = false;
    private bool alwaysOnTop = false;
    HelpForm helpForm = new();
    public CultureInfo startingCulture = CultureInfo.CurrentCulture;

    public MainForm()
    {
        InitializeComponent();
        timerStatus.Start();
        _process = new ProcessText(this);
        _mainMethods = new MainMethods(this);
        Main.UpgradeSettings();
        Main.UpdateCulture();
        iconUpper = notifyIconUpper?.Icon;
        iconLower = notifyIconLower?.Icon;
        iconNormal = systrayIcon?.Icon;
        helpForm.SetText(ProcessingCommands.GetListAsText());
        HotkeyList = HotkeyTools.LoadHotkeys(HotkeyList, HotkeyNames, this);
        if (settings.RegisterHotkeys) // optional
        {
            HotkeyTools.RegisterHotkeys(HotkeyList);
        }
        UpdateCapsLock(forceUpdate: true);
        Autorun.Autorun.UpdatePathIfEnabled(ApplicationName);
    }

    public ProcessText Process
    {
        get { return _process; }
        set { _process = value; }
    }

    public MainMethods Main
    {
        get { return _mainMethods; }
        set { _mainMethods = value; }
    }


    private void UpdateHotkeyLabels()
    {
        MainMethods.UpdateHotkeyLabel(HotkeyList["UpperCase"], labelUpper);
        MainMethods.UpdateHotkeyLabel(HotkeyList["LowerCase"], labelLower);
        MainMethods.UpdateHotkeyLabel(HotkeyList["PlainText"], labelPlain);
        MainMethods.UpdateHotkeyLabel(HotkeyList["CapsLock"], labelCaps);
        MainMethods.UpdateHotkeyLabel(HotkeyList["ProcessText"], labelProcess);
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
            ActionShowToolbar(sender, e);
        }

        UpdateHotkeyLabels();


        textCustom.Text = Main.LoadTextFromFile("process.txt");
        textBox1.Text = Main.LoadTextFromFile("mem1.txt");
        textBox2.Text = Main.LoadTextFromFile("mem2.txt");
        textBox3.Text = Main.LoadTextFromFile("mem3.txt");
    }



    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        HotkeyTools.ReleaseHotkeys(HotkeyList);
        if (Settings.Default.SaveMemorySlots)
        {
            Main.SaveMemSlotToFile(1, warnIfFailed: false);
            Main.SaveMemSlotToFile(2, warnIfFailed: false);
            Main.SaveMemSlotToFile(3, warnIfFailed: false);
        }
    }



    public static void ToggleCapsLock()
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
            //Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);                  // The key of the hotkey that was pressed.
            //KeyModifier modifier = (KeyModifier)((int)m.LParam & 0xFFFF);       // The modifier of the hotkey that was pressed.
            int id = m.WParam.ToInt32();                                        // The id of the hotkey that was pressed.
            Main.HandleHotkey(id);
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

    private void TimerStatus_Tick(object sender, EventArgs e)
    {
        UpdateCapsLock(forceUpdate: false);
    }

    private void CheckBoxCapsLock_Click(object sender, EventArgs e)
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

    private void ActionDelayedKeystrokes(object sender, EventArgs e)
    {
        if (ModifierKeys == Keys.None)
        {
            Main.DelayKeyStrokes();
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

    private void ShowToolTipHide(object sender, EventArgs e)
    {
        toolTip.SetToolTip(buttonHide, "Hide Window. Show again using the system tray icon");
    }

    private void ShowTooltipPin(object sender, EventArgs e)
    {
        toolTip.SetToolTip(buttonPin, "Pin program (Always on top)");
    }

    private void ShowTooltipSettings(object sender, EventArgs e)
    {
        toolTip.SetToolTip(buttonOptions, "Settings");
    }

    private void ShowTooltipHelp(object sender, EventArgs e)
    {
        toolTip.SetToolTip(buttonHelp, "Help: Processing variables");
    }

    private void ShowTooltipSaveTextToFile(object sender, EventArgs e)
    {
        toolTip.SetToolTip((Control)sender, "Save text. Text will load on start");
    }

    private void ShowToolTipMemSave(object sender, EventArgs e)
    {
        toolTip.SetToolTip((Control)sender, "Use clipboard text in this slot");
    }

    private void ShowToolTipMemLoad(object sender, EventArgs e)
    {
        toolTip.SetToolTip((Control)sender, "Update clipboard contents with this slot's text");
    }
    #endregion

    #region Button event actions -----------------------------------------
    private void ActionAlwaysOnTop(object sender, EventArgs e)
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

    private void ActionShowHelp(object sender, EventArgs e)
    {
        if (helpForm == null || helpForm.IsDisposed)
        {
            helpForm = new HelpForm();
        }

        helpForm.SetText(ProcessingCommands.GetListAsText());
        helpForm.Show();
    }

    private void ActionSaveCustomText(object sender, EventArgs e)
    {
        Main.SaveTextToFile("process.txt", textCustom.Text, warnIfFailed: true);
    }

    private void ActionCapsLock(object sender, EventArgs e)
    {
        ToggleCapsLock();
    }

    private void ActionShowWindow(object sender, EventArgs e)
    {
        Show();
        this.WindowState = FormWindowState.Normal;
        Show();
    }

    private void ActionExit(object sender, EventArgs e)
    {
        Application.Exit();
    }

    //public void actionCapsLock(object sender, MouseEventArgs e)
    //{
    //    ToggleCapsLock();
    //}

    public void ActionUpperCaseOnce(object sender, EventArgs e)
    {
        Main.UpperCaseOnce(forceClipboardUpdate: true);
    }

    public void ActionLowerCaseOnce(object sender, EventArgs e)
    {
        Main.LowerCaseOnce(forceClipboardUpdate: true);
    }

    public void ActionHideFromTaskbar(object sender, EventArgs e)
    {
        Hide();
    }

    public void ActionPlainTextOnce(object sender, EventArgs e)
    {
        Main.PlainTextOnce(forceClipboardUpdate: true);
    }

    private void ActionShowToolbar(object sender, EventArgs e)
    {
        Toolbar toolbar = new(this)
        {
            mainform = this
        };
        toolbar.Show();
        //toolbar.Parent = this;
    }

    public void ActionProcessText(object sender, EventArgs e)
    {
        Dbg.WriteWithCaller("Process text");
        Process.ProcessTextVariables(textCustom.Text, true);
    }

    private void ActionShowOptions(object sender, EventArgs e)
    {
        Options options = new(this);
        options.ShowDialog();
        options.Dispose();
    }

    private void ActionSave(object sender, EventArgs e)
    {
        var button = (System.Windows.Forms.Button)sender;
        string? tag = button.Tag?.ToString();
        if (tag != null)
        {
            int num = int.Parse(tag);
            Main.SetTextBoxFromClipboard(num);
        }
    }

    private void ActionLoad(object sender, EventArgs e)
    {
        var button = (System.Windows.Forms.Button)sender;
        string? tag = button.Tag?.ToString();
        if (tag != null)
        {
            int num = int.Parse(tag);
            Main.SetClipboardFromTextBox(num);
        }
    }

    private void ActionSaveToFile(object sender, EventArgs e)
    {
        var button = (System.Windows.Forms.Button)sender;
        string? tag = button.Tag?.ToString();
        if (tag != null)
        {
            int num = int.Parse(tag);
            Main.SaveMemSlotToFile(num, warnIfFailed: true);
        }
    }
    #endregion

    private void ButtonTextLibrary_Click(object sender, EventArgs e)
    {
        ShowTextLibrary();
    }

    public void ShowTextLibrary()
    {
        textTextLibrary ??= new TextLibrary(this);
        if (textTextLibrary.IsDisposed)
            textTextLibrary = new TextLibrary(this);

        textTextLibrary.Show();
        textTextLibrary.WindowState = FormWindowState.Normal;
        textTextLibrary.BringToFront();
        SetForegroundWindow(textTextLibrary.Handle);
    }
}