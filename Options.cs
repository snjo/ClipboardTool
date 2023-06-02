using Hotkeys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
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

            /*
            fillInputs(UpperInputs, mainForm.hotkeys.UpperCase);
            fillInputs(LowerInputs, mainForm.hotkeys.LowerCase);
            fillInputs(PlainInputs, mainForm.hotkeys.PlainText);
            fillInputs(CapsInputs, mainForm.hotkeys.CapsLock);
            fillInputs(ProcessInputs, mainForm.hotkeys.ProcessText);
            fillInputs(DateInputs, mainForm.hotkeys.Date);
            */

            fillGrid();
        }

        private void fillGrid()
        {
            HotkeyGrid.Rows.Clear();
            HotkeyGrid.Rows.Add((int)HotkeyList.End);
            /*for (HotkeyList hk = 0; hk < HotkeyList.End; hk++)
            {
                HotkeyGrid.Rows[(int)hk].Cells[0].Value = hk.ToString();
                HotkeyGrid.Rows[(int)hk].Cells[1].Value = GetHotkey(hk).key;
                HotkeyGrid.Rows[(int)hk].Cells[2].Value = GetHotkey(hk).Ctrl;
                HotkeyGrid.Rows[(int)hk].Cells[3].Value = GetHotkey(hk).Alt;
                HotkeyGrid.Rows[(int)hk].Cells[4].Value = GetHotkey(hk).Shift;
                HotkeyGrid.Rows[(int)hk].Cells[5].Value = GetHotkey(hk).Win;
            }*/

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



        private void fillInputs(HotkeyControls input, Hotkey hotkey)
        {
            if (hotkey != null)
            {
                input.hotkey = hotkey;
                input.text.Text = hotkey.key.ToString();
                input.Ctrl.Checked = hotkey.Ctrl;
                input.Alt.Checked = hotkey.Alt;
                input.Shift.Checked = hotkey.Shift;
                input.Win.Checked = hotkey.Win;
            }
        }

        private void setupInputs()
        {
            UpperInputs.text = textHotkeyUpper;
            UpperInputs.Ctrl = checkUpperCtrl;
            UpperInputs.Alt = checkUpperAlt;
            UpperInputs.Shift = checkUpperShift;
            UpperInputs.Win = checkUpperWin;

            LowerInputs.text = textHotkeyLower;
            LowerInputs.Ctrl = checkLowerCtrl;
            LowerInputs.Alt = checkLowerAlt;
            LowerInputs.Shift = checkLowerShift;
            LowerInputs.Win = checkLowerWin;

            PlainInputs.text = textHotkeyPlain;
            PlainInputs.Ctrl = checkPlainCtrl;
            PlainInputs.Alt = checkPlainAlt;
            PlainInputs.Shift = checkPlainShift;
            PlainInputs.Win = checkPlainWin;

            CapsInputs.text = textHotkeyCaps;
            CapsInputs.Ctrl = checkCapsCtrl;
            CapsInputs.Alt = checkCapsAlt;
            CapsInputs.Shift = checkCapsShift;
            CapsInputs.Win = checkCapsWin;

            ProcessInputs.text = textHotkeyProcess;
            ProcessInputs.Ctrl = checkProcessCtrl;
            ProcessInputs.Alt = checkProcessAlt;
            ProcessInputs.Shift = checkProcessShift;
            ProcessInputs.Win = checkProcessWin;

            DateInputs.text = textHotkeyDate;
            DateInputs.Ctrl = checkDateCtrl;
            DateInputs.Alt = checkDateAlt;
            DateInputs.Shift = checkDateShift;
            DateInputs.Win = checkDateWin;

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

        private Hotkey readInputs(HotkeyControls input, Hotkey hotkey)
        {
            if (hotkey == null)
                hotkey = new Hotkeys.Hotkey();
            if (input.text.Text.Length > 0)
                hotkey.key = input.text.Text; //.ToCharArray()[0];
            else
                hotkey.key = new string("");//new char();
            hotkey.Ctrl = input.Ctrl.Checked;
            hotkey.Alt = input.Alt.Checked;
            hotkey.Shift = input.Shift.Checked;
            hotkey.Win = input.Win.Checked;
            return hotkey;
        }

        /*
        private bool DoesSettingExist(string settingName)
        {
            return Properties.Settings.Default.Properties.Cast<SettingsProperty>().Any(prop => prop.Name == settingName);
        }
        */

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



            /*
            mainForm.hotkeys.UpperCase = readInputs(UpperInputs, mainForm.hotkeys.UpperCase);
            mainForm.hotkeys.LowerCase = readInputs(LowerInputs, mainForm.hotkeys.LowerCase);
            mainForm.hotkeys.PlainText = readInputs(PlainInputs, mainForm.hotkeys.PlainText);
            mainForm.hotkeys.CapsLock = readInputs(CapsInputs, mainForm.hotkeys.CapsLock);
            mainForm.hotkeys.ProcessText = readInputs(ProcessInputs, mainForm.hotkeys.ProcessText);
            mainForm.hotkeys.Date = readInputs(DateInputs, mainForm.hotkeys.Date);
            */

            int i = 0;
            foreach (KeyValuePair<string, Hotkey> kvp in mainForm.HotkeyList)
            {

                Properties.Settings.Default["hk" + kvp.Key + "Key"] = HotkeyGrid.Rows[i].Cells[1].Value.ToString();
                Properties.Settings.Default["hk" + kvp.Key + "Ctrl"] = Convert.ToBoolean(HotkeyGrid.Rows[i].Cells[2].Value);
                Properties.Settings.Default["hk" + kvp.Key + "Alt"] = Convert.ToBoolean(HotkeyGrid.Rows[i].Cells[3].Value);
                Properties.Settings.Default["hk" + kvp.Key + "Shift"] = Convert.ToBoolean(HotkeyGrid.Rows[i].Cells[4].Value);
                Properties.Settings.Default["hk" + kvp.Key + "Win"] = Convert.ToBoolean(HotkeyGrid.Rows[i].Cells[5].Value);
                /*
                Properties.Settings.Default["hk" + kvp.Key + "Key"] = kvp.Value.key;
                Properties.Settings.Default["hk" + kvp.Key + "Ctrl"] = kvp.Value.Ctrl;
                Properties.Settings.Default["hk" + kvp.Key + "Alt"] = kvp.Value.Alt;
                Properties.Settings.Default["hk" + kvp.Key + "Shift"] = kvp.Value.Shift;
                Properties.Settings.Default["hk" + kvp.Key + "Win"] = kvp.Value.Win;
                */

                i++;
            }

            /*
            Properties.Settings.Default.hkUpperCaseKey = mainForm.hotkeys.UpperCase.key;
            Properties.Settings.Default.hkLowerCaseKey = mainForm.hotkeys.LowerCase.key;
            Properties.Settings.Default.hkPlainTextKey = mainForm.hotkeys.PlainText.key;
            Properties.Settings.Default.hkCapsLockKey = mainForm.hotkeys.CapsLock.key;
            Properties.Settings.Default.hkProcessTextKey = mainForm.hotkeys.ProcessText.key;

            Properties.Settings.Default.hkUpperCaseCtrl = mainForm.hotkeys.UpperCase.Ctrl;
            Properties.Settings.Default.hkUpperCaseAlt = mainForm.hotkeys.UpperCase.Alt;
            Properties.Settings.Default.hkUpperCaseShift = mainForm.hotkeys.UpperCase.Shift;
            Properties.Settings.Default.hkUpperCaseWin = mainForm.hotkeys.UpperCase.Win;

            Properties.Settings.Default.hkLowerCaseCtrl = mainForm.hotkeys.LowerCase.Ctrl;
            Properties.Settings.Default.hkLowerCaseAlt = mainForm.hotkeys.LowerCase.Alt;
            Properties.Settings.Default.hkLowerCaseShift = mainForm.hotkeys.LowerCase.Shift;
            Properties.Settings.Default.hkLowerCaseWin = mainForm.hotkeys.LowerCase.Win;

            Properties.Settings.Default.hkPlainTextCtrl = mainForm.hotkeys.PlainText.Ctrl;
            Properties.Settings.Default.hkPlainTextAlt = mainForm.hotkeys.PlainText.Alt;
            Properties.Settings.Default.hkPlainTextShift = mainForm.hotkeys.PlainText.Shift;
            Properties.Settings.Default.hkPlainTextWin = mainForm.hotkeys.PlainText.Win;

            Properties.Settings.Default.hkCapsLockCtrl = mainForm.hotkeys.CapsLock.Ctrl;
            Properties.Settings.Default.hkCapsLockAlt = mainForm.hotkeys.CapsLock.Alt;
            Properties.Settings.Default.hkCapsLockShift = mainForm.hotkeys.CapsLock.Shift;
            Properties.Settings.Default.hkCapsLockWin = mainForm.hotkeys.CapsLock.Win;

            Properties.Settings.Default.hkProcessTextCtrl = mainForm.hotkeys.ProcessText.Ctrl;
            Properties.Settings.Default.hkProcessTextAlt = mainForm.hotkeys.ProcessText.Alt;
            Properties.Settings.Default.hkProcessTextShift = mainForm.hotkeys.ProcessText.Shift;
            Properties.Settings.Default.hkProcessTextWin = mainForm.hotkeys.ProcessText.Win;

            Properties.Settings.Default.hkDateCtrl = mainForm.hotkeys.Date.Ctrl;
            Properties.Settings.Default.hkDateAlt = mainForm.hotkeys.Date.Alt;
            Properties.Settings.Default.hkDateShift = mainForm.hotkeys.Date.Shift;
            Properties.Settings.Default.hkDateWin = mainForm.hotkeys.Date.Win;
            */

            Properties.Settings.Default.Save();
        }
    }
}
