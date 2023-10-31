using ClipboardTool.Properties;
using Hotkeys;
using System.Configuration;
using System.Diagnostics;

namespace ClipboardTool
{
    public partial class Options : Form
    {
        public MainForm mainForm;
        Properties.Settings settings = Properties.Settings.Default;
        string RTFcolorsDefault = @"\red80\green120\blue200;\red255\green180\blue1800;";
        string RTFfontsDefault = @"\deff0{\fonttbl{\f0\fnil Default Sans Serif;}{\f1\froman Times New Roman;}{\f2\fswiss Arial;}{\f3\fmodern Courier New;}{\f4\fscript Script MT Bold;}{\f5\fdecor Old English Text MT;}}\f0 ";

        public Options(MainForm formParent)
        {
            InitializeComponent();
            mainForm = formParent;

            optionStartHidden.Checked = settings.StartHidden;
            optionStartToolbar.Checked = settings.StartToolbar;
            optionRegisterHotkeys.Checked = settings.RegisterHotkeys;
            optionSaveMemorySlots.Checked = settings.SaveMemorySlots;
            textMemorySlotFolder.Text = settings.MemorySlotFolder;
            textBoxHistory.Text = settings.HistoryFolder;
            optionResetCounter.Checked = settings.ResetCounterWhenSet;
            optionCut.Checked = settings.sendCut;
            optionType.Checked = settings.sendType;
            optionPaste.Checked = settings.sendPaste;
            optionUpdateClipboard.Checked = settings.updateClipboard;
            checkBoxHistoryMinimize.Checked = settings.HistoryMinimizeAfterCopy;
            checkBoxTrayCapslock.Checked = settings.TrayIconCapslockStatus;
            textBoxRTFcolors.Text = settings.RTFcolors;
            textBoxRTFfonts.Text = settings.RTFfonts;
            checkBoxRTFcolor.Checked = settings.RTFallowColorTable;
            checkBoxRTFfont.Checked = settings.RTFallowFontTable;

            fillGrid();

            labelVersion.Text = Application.ProductVersion;
        }

        private void fillGrid()
        {
            HotkeyGrid.Rows.Clear();
            HotkeyGrid.Rows.Add(mainForm.HotkeyList.Count);

            int i = 0;
            foreach (KeyValuePair<string, Hotkey> kvp in mainForm.HotkeyList)
            {
                string keyName = kvp.Key;
                Hotkey hotkey = kvp.Value;
                HotkeyGrid.Rows[i].Cells[0].Value = keyName;
                HotkeyGrid.Rows[i].Cells[1].Value = hotkey.Key;
                HotkeyGrid.Rows[i].Cells[2].Value = hotkey.Ctrl;
                HotkeyGrid.Rows[i].Cells[3].Value = hotkey.Alt;
                HotkeyGrid.Rows[i].Cells[4].Value = hotkey.Shift;
                HotkeyGrid.Rows[i].Cells[5].Value = hotkey.Win;
                i++;
            }
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveSettings();
            Close();
        }

        private Hotkey GetHotkeyFromGrid(Hotkey hotkey, DataGridViewCellCollection settingRow)
        {
            string settingKey = string.Empty;
            DataGridViewCell cell = settingRow[1];
            if (cell != null)
            {
                if (cell.Value != null)
                    settingKey = (string)cell.Value;
                if (settingKey == null) settingKey = string.Empty;
            }

            if (settingKey.Length > 0)
                hotkey.Key = settingKey;
            else
                hotkey.Key = new string("");

            hotkey.Ctrl = Convert.ToBoolean(settingRow[2].Value);
            hotkey.Alt = Convert.ToBoolean(settingRow[3].Value);
            hotkey.Shift = Convert.ToBoolean(settingRow[4].Value);
            hotkey.Win = Convert.ToBoolean(settingRow[5].Value);

            return hotkey;
        }

        private void saveSettings()
        {
            settings.StartHidden = optionStartHidden.Checked;
            settings.StartToolbar = optionStartToolbar.Checked;
            settings.RegisterHotkeys = optionRegisterHotkeys.Checked;
            settings.SaveMemorySlots = optionSaveMemorySlots.Checked;
            settings.MemorySlotFolder = textMemorySlotFolder.Text;
            settings.HistoryFolder = textBoxHistory.Text;
            settings.ResetCounterWhenSet = optionResetCounter.Checked;
            settings.sendCut = optionCut.Checked;
            settings.sendType = optionType.Checked;
            settings.sendPaste = optionPaste.Checked;
            settings.updateClipboard = optionUpdateClipboard.Checked;
            settings.HistoryMinimizeAfterCopy = checkBoxHistoryMinimize.Checked;
            settings.TrayIconCapslockStatus = checkBoxTrayCapslock.Checked;
            settings.RTFcolors = textBoxRTFcolors.Text;
            settings.RTFfonts = textBoxRTFfonts.Text;
            settings.RTFallowColorTable = checkBoxRTFcolor.Checked;
            settings.RTFallowFontTable = checkBoxRTFfont.Checked;


            int i = 0;
            foreach (KeyValuePair<string, Hotkey> kvp in mainForm.HotkeyList)
            {
                string keyName = kvp.Key;
                if (HotkeyGrid.Rows[i].Cells[1].Value == null)
                {
                    HotkeyGrid.Rows[i].Cells[1].Value = "";
                }

                SaveSetting("hk" + keyName + "Key", HotkeyGrid.Rows[i].Cells[1].Value.ToString()+"");
                SaveSetting("hk" + keyName + "Ctrl", Convert.ToBoolean(HotkeyGrid.Rows[i].Cells[2].Value));
                SaveSetting("hk" + keyName + "Alt", Convert.ToBoolean(HotkeyGrid.Rows[i].Cells[3].Value));
                SaveSetting("hk" + keyName + "Shift", Convert.ToBoolean(HotkeyGrid.Rows[i].Cells[4].Value));
                SaveSetting("hk" + keyName + "Win", Convert.ToBoolean(HotkeyGrid.Rows[i].Cells[5].Value));

                mainForm.HotkeyList[keyName] = GetHotkeyFromGrid(mainForm.HotkeyList[keyName], HotkeyGrid.Rows[i].Cells);

                i++;
            }

            settings.Save();
            mainForm.UpdateCapsLock(true); // updates the tray icon to a/A or normal icon

            reloadHotkeys();
        }

        private static bool DoesSettingExist(string settingName)
        {
            return Settings.Default.Properties.Cast<SettingsProperty>().Any(prop => prop.Name == settingName);
        }

        private void SaveSetting(string settingName, object value)
        {
            if (DoesSettingExist(settingName))
            {
                Settings.Default[settingName] = value;
            }
            else
            {
                Debug.WriteLine("Warning. Tried to save setting that is not defined: " + settingName);
            }
        }

        private void reloadHotkeys()
        {
            HotkeyTools.UpdateHotkeys(mainForm.HotkeyList, mainForm.HotkeyNames, mainForm);
            Debug.WriteLine("Released and re-registered hotkeys");
        }

        private void linkWebsite(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://github.com/snjo/ClipboardTool";
            Process.Start(new ProcessStartInfo() { FileName = url, UseShellExecute = true });
        }

        private void LinkSettings(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string file = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath;
            string? folder = Path.GetDirectoryName(file);
            if (folder == null) return;
            if (Directory.Exists(folder))
            {
                Process.Start(new ProcessStartInfo() { FileName = folder, UseShellExecute = true });
            }
            else
            {
                MessageBox.Show("No settings folder exists yet. Save the settings and try again." + Environment.NewLine +
                    "(A new settings file/folder is created if the application has changed or moved)");
            }

        }

        private void buttonSelectFolder_Click(object sender, EventArgs e)
        {
            DialogResult dialog = folderBrowserDialog1.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                textMemorySlotFolder.Text = folderBrowserDialog1.SelectedPath;
            }

        }

        private void buttonSelectHistoryFolder_Click(object sender, EventArgs e)
        {
            DialogResult dialog = folderBrowserDialog1.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                textBoxHistory.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void buttonRTFDefaultColors_Click(object sender, EventArgs e)
        {
            textBoxRTFcolors.Text = RTFcolorsDefault;
        }

        private void buttonRTFDefaultFonts_Click(object sender, EventArgs e)
        {
            textBoxRTFfonts.Text = RTFfontsDefault;
        }

        private void optionPaste_CheckedChanged(object sender, EventArgs e)
        {
            if (optionPaste.Checked)
            {
                optionType.Checked = false;
            }
        }

        private void optionType_CheckedChanged(object sender, EventArgs e)
        {
            if (optionType.Checked)
            {
                optionPaste.Checked = false;
            }
        }
    }
}
