using Hotkeys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public Options(MainForm formParent)
        {
            InitializeComponent();
            mainForm = formParent;
            setupInputs();

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

            fillInputs(UpperInputs, mainForm.hotkeys.UpperCase);
            fillInputs(LowerInputs, mainForm.hotkeys.LowerCase);
            fillInputs(PlainInputs, mainForm.hotkeys.PlainText);
            fillInputs(CapsInputs, mainForm.hotkeys.CapsLock);
            fillInputs(ProcessInputs, mainForm.hotkeys.ProcessText);
            fillInputs(DateInputs, mainForm.hotkeys.Date);

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

            mainForm.hotkeys.UpperCase = readInputs(UpperInputs, mainForm.hotkeys.UpperCase);
            mainForm.hotkeys.LowerCase = readInputs(LowerInputs, mainForm.hotkeys.LowerCase);
            mainForm.hotkeys.PlainText = readInputs(PlainInputs, mainForm.hotkeys.PlainText);
            mainForm.hotkeys.CapsLock = readInputs(CapsInputs, mainForm.hotkeys.CapsLock);
            mainForm.hotkeys.ProcessText = readInputs(ProcessInputs, mainForm.hotkeys.ProcessText);
            mainForm.hotkeys.Date = readInputs(DateInputs, mainForm.hotkeys.Date);


            Properties.Settings.Default.hkUpperKey = mainForm.hotkeys.UpperCase.key;
            Properties.Settings.Default.hkLowerKey = mainForm.hotkeys.LowerCase.key;
            Properties.Settings.Default.hkPlainKey = mainForm.hotkeys.PlainText.key;
            Properties.Settings.Default.hkCapsLockKey = mainForm.hotkeys.CapsLock.key;
            Properties.Settings.Default.hkProcessTextKey = mainForm.hotkeys.ProcessText.key;

            Properties.Settings.Default.hkUpperCtrl = mainForm.hotkeys.UpperCase.Ctrl;
            Properties.Settings.Default.hkUpperAlt = mainForm.hotkeys.UpperCase.Alt;
            Properties.Settings.Default.hkUpperShift = mainForm.hotkeys.UpperCase.Shift;
            Properties.Settings.Default.hkUpperWin = mainForm.hotkeys.UpperCase.Win;

            Properties.Settings.Default.hkLowerCtrl = mainForm.hotkeys.LowerCase.Ctrl;
            Properties.Settings.Default.hkLowerAlt = mainForm.hotkeys.LowerCase.Alt;
            Properties.Settings.Default.hkLowerShift = mainForm.hotkeys.LowerCase.Shift;
            Properties.Settings.Default.hkLowerWin = mainForm.hotkeys.LowerCase.Win;

            Properties.Settings.Default.hkPlainCtrl = mainForm.hotkeys.PlainText.Ctrl;
            Properties.Settings.Default.hkPlainAlt = mainForm.hotkeys.PlainText.Alt;
            Properties.Settings.Default.hkPlainShift = mainForm.hotkeys.PlainText.Shift;
            Properties.Settings.Default.hkPlainWin = mainForm.hotkeys.PlainText.Win;

            Properties.Settings.Default.hkCapsCtrl = mainForm.hotkeys.CapsLock.Ctrl;
            Properties.Settings.Default.hkCapsAlt = mainForm.hotkeys.CapsLock.Alt;
            Properties.Settings.Default.hkCapsShift = mainForm.hotkeys.CapsLock.Shift;
            Properties.Settings.Default.hkCapsWin = mainForm.hotkeys.CapsLock.Win;

            Properties.Settings.Default.hkProcessCtrl = mainForm.hotkeys.ProcessText.Ctrl;
            Properties.Settings.Default.hkProcessAlt = mainForm.hotkeys.ProcessText.Alt;
            Properties.Settings.Default.hkProcessShift = mainForm.hotkeys.ProcessText.Shift;
            Properties.Settings.Default.hkProcessWin = mainForm.hotkeys.ProcessText.Win;

            Properties.Settings.Default.hkDateCtrl = mainForm.hotkeys.Date.Ctrl;
            Properties.Settings.Default.hkDateAlt = mainForm.hotkeys.Date.Alt;
            Properties.Settings.Default.hkDateShift = mainForm.hotkeys.Date.Shift;
            Properties.Settings.Default.hkDateWin = mainForm.hotkeys.Date.Win;

            Properties.Settings.Default.Save();
        }
    }
}
