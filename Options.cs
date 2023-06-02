﻿using Hotkeys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClipboardTool
{



    public partial class Options : Form
    {
        public MainForm mainForm;
        private HotkeyControls UpperInputs = new HotkeyControls();
        private HotkeyControls LowerInputs = new HotkeyControls();
        private HotkeyControls PlainInputs = new HotkeyControls();
        private HotkeyControls CapsInputs = new HotkeyControls();
        private HotkeyControls ProcessInputs = new HotkeyControls();
        private HotkeyControls DateInputs = new HotkeyControls();

        public enum HotkeyList // can be used for row numbers in data grid
        {
            UpperCase,
            LowerCase,
            PlainText,
            CapsLock,
            ProcessText,
            Date,
            MemSlot1, MemSlot2, MemSlot3,
            End
        }
        private Hotkey GetHotkey(HotkeyList hk)
        {
            if (hk == HotkeyList.UpperCase) return mainForm.hotkeys.UpperCase;
            if (hk == HotkeyList.LowerCase) return mainForm.hotkeys.LowerCase;
            if (hk == HotkeyList.PlainText) return mainForm.hotkeys.PlainText;
            if (hk == HotkeyList.CapsLock) return mainForm.hotkeys.CapsLock;
            if (hk == HotkeyList.ProcessText) return mainForm.hotkeys.ProcessText;
            if (hk == HotkeyList.Date) return mainForm.hotkeys.Date;
            if (hk == HotkeyList.MemSlot1) return mainForm.hotkeys.MemSlot1;
            if (hk == HotkeyList.MemSlot2) return mainForm.hotkeys.MemSlot2;
            if (hk == HotkeyList.MemSlot3) return mainForm.hotkeys.MemSlot3;

            throw new ArgumentOutOfRangeException("Add new hotkeys to GetHotkey function: " + nameof(hk));
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
            //mainForm.ReleaseHotkeys();
            //mainForm.RegisterHotKeys();
            Close();
        }

        private Hotkey sendHotkeyToMain(Hotkey hotkey, DataGridViewCellCollection settingRow)
        {
            if (hotkey == null)
                hotkey = new Hotkeys.Hotkey();
            string settingKey = settingRow[1].Value.ToString();
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
            string folder = Path.GetDirectoryName(file);            
            Process.Start(new ProcessStartInfo() { FileName = folder, UseShellExecute = true });            
        }
    }
}
