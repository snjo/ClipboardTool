// See https://github.com/snjo/Hotkeys

// Add Application Settings like this, 5 values for each hotkey
RegisterHotkeys		bool 	User	True
hkMyHotkeyKey		string	User	PrintScreen
hkMyHotkeyCtrl		bool	User	false
hkMyHotkeyAlt		bool	User	false
hkMyHotkeyShift		bool	User	false
hkMyHotkeyWin		bool	User	false

// In HotkeyTools.cs, add a using statement to be able to reference Settings.Default, example:
// using MyApp.Properties;

// Add these methods to your main form, adjust HandleHotkey to taste
//------------------------------ Catch hotkey presses and do stuff with them

Settings settings = Settings.Default;

// For each hotkey below, add entries in Settings, hk???Key, hk???Ctrl, hk???Alt, hk???Shift, hk???Win
public List<string> HotkeyNames = new List<string>
{
        "MyHotkey1",
        "MyHotkey2",
};
public Dictionary<string, Hotkey> HotkeyList = new Dictionary<string, Hotkey>();

public MainForm()
{
        InitializeComponent();

        HotkeyList = HotkeyTools.LoadHotkeys(HotkeyList, HotkeyNames, this);
        if (settings.RegisterHotkeys) // optional
        {
                HotkeyTools.RegisterHotkeys(HotkeyList);
                // RegisterHotkeys returns a string[] with any failed hotkey registrations that can be used to output an error message
        }
}

private void Form1_FormClosing(object sender, FormClosingEventArgs e)
{
        HotkeyTools.ReleaseHotkeys(HotkeyList);
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

private void HandleHotkey(int id)
{

        if (hotkeyList["MyHotkey"] != null)
        {
                if (id == HotkeyList["MyHotkey"].ghk.id)
                {
                        //Do something
                }
        }
}

// If the user has changed hotkey settings (key binds) at runtime, re-register the hotkeys using:
// HotkeyTools.UpdateHotkeys(mainForm.HotkeyList, mainForm.HotkeyNames, mainForm);

