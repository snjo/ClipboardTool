// Add Application Settings like this, 5 values for each hotkey
RegisterHotkeys		bool 	User	True
hkMyHotkeyKey		string	User	PrintScreen
hkMyHotkeyCtrl		bool	User	false
hkMyHotkeyAlt		bool	User	false
hkMyHotkeyShift		bool	User	false
hkMyHotkeyWin		bool	User	false

// Add these methods to your main form, adjust HandleHotkey to taste
//------------------------------ Catch hotkey presses and do stuff with them

Settings settings = Settings.Default;

public Dictionary<string, Hotkey> hotkeyList = new Dictionary<string, Hotkey>
{
        {"MyHotkey", new Hotkey(new GlobalHotkey())},
};

public MainForm()
{
        InitializeComponent();

        hotkeyList = HotkeyTools.LoadHotkeys(hotkeyList,this);
        if (settings.RegisterHotkeys) // optional
        {
                HotkeyTools.RegisterHotkeys(hotkeyList);
        }
}

private void Form1_FormClosing(object sender, FormClosingEventArgs e)
{
        HotkeyTools.ReleaseHotkeys(hotkeyList);
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
                if (id == hotkeyList["MyHotkey"].ghk.id)
                {
                        //Do something
                }
        }
}



