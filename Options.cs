using Hotkeys;
using System.Configuration;
using System.Diagnostics;

namespace ClipboardTool
{
    public partial class Options : Form
    {
        public MainForm mainForm;

        public enum HotkeyList // can be used for row numbers in data grid
        {
            UpperCase,
            LowerCase,
            PlainText,
            CapsLock,
            ProcessText,
            Date,
            MemSlot1, MemSlot2, MemSlot3,
            ResetNumber,
            End
        }

        public Options(MainForm formParent)
        {
            InitializeComponent();
            mainForm = formParent;
            //setupInputs();

            optionStartHidden.Checked = Properties.Settings.Default.StartHidden;
            optionStartToolbar.Checked = Properties.Settings.Default.StartToolbar;
            optionRegisterHotkeys.Checked = Properties.Settings.Default.RegisterHotkeys;
            optionSaveMemorySlots.Checked = Properties.Settings.Default.SaveMemorySlots;
            textMemorySlotFolder.Text = Properties.Settings.Default.MemorySlotFolder;
            optionResetCounter.Checked = Properties.Settings.Default.ResetCounterWhenSet;
            optionCut.Checked = Properties.Settings.Default.sendCut;
            optionType.Checked = Properties.Settings.Default.sendType;
            optionPaste.Checked = Properties.Settings.Default.sendPaste;
            optionUpdateClipboard.Checked = Properties.Settings.Default.updateClipboard;


            fillGrid();
        }

        private void fillGrid()
        {
            HotkeyGrid.Rows.Clear();
            HotkeyGrid.Rows.Add((int)HotkeyList.End);

            int i = 0;
            foreach (KeyValuePair<string, Hotkey> kvp in mainForm.HotkeyList)
            {
                HotkeyGrid.Rows[i].Cells[0].Value = kvp.Key;
                HotkeyGrid.Rows[i].Cells[1].Value = kvp.Value.key;
                HotkeyGrid.Rows[i].Cells[2].Value = kvp.Value.Ctrl;
                HotkeyGrid.Rows[i].Cells[3].Value = kvp.Value.Alt;
                HotkeyGrid.Rows[i].Cells[4].Value = kvp.Value.Shift;
                HotkeyGrid.Rows[i].Cells[5].Value = kvp.Value.Win;
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

        private Hotkey sendHotkeyToMain(Hotkey hotkey, DataGridViewCellCollection settingRow)
        {
            if (hotkey == null)
                hotkey = new Hotkeys.Hotkey();

            string settingKey = string.Empty;
            DataGridViewCell cell = settingRow[1];
            if (cell != null)
            {
                if (cell.Value != null)
                    settingKey = (string)cell.Value;
                if (settingKey == null) settingKey = string.Empty;
            }

            if (settingKey.Length > 0)
                hotkey.key = settingKey; //.ToCharArray()[0];
            else
                hotkey.key = new string("");//new char();

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
            Properties.Settings.Default.ResetCounterWhenSet = optionResetCounter.Checked;
            Properties.Settings.Default.sendCut = optionCut.Checked;
            Properties.Settings.Default.sendType = optionType.Checked;
            Properties.Settings.Default.sendPaste = optionPaste.Checked;
            Properties.Settings.Default.updateClipboard = optionUpdateClipboard.Checked;


            int i = 0;
            foreach (KeyValuePair<string, Hotkey> kvp in mainForm.HotkeyList)
            {
                if (HotkeyGrid.Rows[i].Cells[1].Value == null)
                {
                    HotkeyGrid.Rows[i].Cells[1].Value = "";
                }
                Properties.Settings.Default["hk" + kvp.Key + "Key"] = HotkeyGrid.Rows[i].Cells[1].Value.ToString();

                Properties.Settings.Default["hk" + kvp.Key + "Ctrl"] = Convert.ToBoolean(HotkeyGrid.Rows[i].Cells[2].Value);
                Properties.Settings.Default["hk" + kvp.Key + "Alt"] = Convert.ToBoolean(HotkeyGrid.Rows[i].Cells[3].Value);
                Properties.Settings.Default["hk" + kvp.Key + "Shift"] = Convert.ToBoolean(HotkeyGrid.Rows[i].Cells[4].Value);
                Properties.Settings.Default["hk" + kvp.Key + "Win"] = Convert.ToBoolean(HotkeyGrid.Rows[i].Cells[5].Value);

                mainForm.HotkeyList[kvp.Key] = sendHotkeyToMain(mainForm.HotkeyList[kvp.Key], HotkeyGrid.Rows[i].Cells);

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
    }
}
