using Hotkeys;
using System.Configuration;
using System.Diagnostics;

namespace ClipboardTool
{
    public partial class Options : Form
    {
        public MainForm mainForm;

        public Options(MainForm formParent)
        {
            InitializeComponent();
            mainForm = formParent;

            optionStartHidden.Checked = Properties.Settings.Default.StartHidden;
            optionStartToolbar.Checked = Properties.Settings.Default.StartToolbar;
            optionRegisterHotkeys.Checked = Properties.Settings.Default.RegisterHotkeys;
            optionSaveMemorySlots.Checked = Properties.Settings.Default.SaveMemorySlots;
            textMemorySlotFolder.Text = Properties.Settings.Default.MemorySlotFolder;
            textBoxHistory.Text = Properties.Settings.Default.HistoryFolder;
            optionResetCounter.Checked = Properties.Settings.Default.ResetCounterWhenSet;
            optionCut.Checked = Properties.Settings.Default.sendCut;
            optionType.Checked = Properties.Settings.Default.sendType;
            optionPaste.Checked = Properties.Settings.Default.sendPaste;
            optionUpdateClipboard.Checked = Properties.Settings.Default.updateClipboard;
            checkBoxHistoryMinimize.Checked = Properties.Settings.Default.HistoryMinimizeAfterCopy;

            fillGrid();
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
            Properties.Settings.Default.StartHidden = optionStartHidden.Checked;
            Properties.Settings.Default.StartToolbar = optionStartToolbar.Checked;
            Properties.Settings.Default.RegisterHotkeys = optionRegisterHotkeys.Checked;
            Properties.Settings.Default.SaveMemorySlots = optionSaveMemorySlots.Checked;
            Properties.Settings.Default.MemorySlotFolder = textMemorySlotFolder.Text;
            Properties.Settings.Default.HistoryFolder = textBoxHistory.Text;
            Properties.Settings.Default.ResetCounterWhenSet = optionResetCounter.Checked;
            Properties.Settings.Default.sendCut = optionCut.Checked;
            Properties.Settings.Default.sendType = optionType.Checked;
            Properties.Settings.Default.sendPaste = optionPaste.Checked;
            Properties.Settings.Default.updateClipboard = optionUpdateClipboard.Checked;
            Properties.Settings.Default.HistoryMinimizeAfterCopy = checkBoxHistoryMinimize.Checked;


            int i = 0;
            foreach (KeyValuePair<string, Hotkey> kvp in mainForm.HotkeyList)
            {
                string keyName = kvp.Key;
                if (HotkeyGrid.Rows[i].Cells[1].Value == null)
                {
                    HotkeyGrid.Rows[i].Cells[1].Value = "";
                }
                Properties.Settings.Default["hk" + keyName + "Key"] = HotkeyGrid.Rows[i].Cells[1].Value.ToString();

                Properties.Settings.Default["hk" + keyName + "Ctrl"] = Convert.ToBoolean(HotkeyGrid.Rows[i].Cells[2].Value);
                Properties.Settings.Default["hk" + keyName + "Alt"] = Convert.ToBoolean(HotkeyGrid.Rows[i].Cells[3].Value);
                Properties.Settings.Default["hk" + keyName + "Shift"] = Convert.ToBoolean(HotkeyGrid.Rows[i].Cells[4].Value);
                Properties.Settings.Default["hk" + keyName + "Win"] = Convert.ToBoolean(HotkeyGrid.Rows[i].Cells[5].Value);

                mainForm.HotkeyList[keyName] = GetHotkeyFromGrid(mainForm.HotkeyList[keyName], HotkeyGrid.Rows[i].Cells);

                i++;
            }

            Properties.Settings.Default.Save();
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
    }
}
