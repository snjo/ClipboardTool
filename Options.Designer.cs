namespace ClipboardTool
{
    partial class Options
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            optionStartHidden = new CheckBox();
            optionStartToolbar = new CheckBox();
            optionRegisterHotkeys = new CheckBox();
            optionResetCounter = new CheckBox();
            optionSaveMemorySlots = new CheckBox();
            textMemorySlotFolder = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textHotkeyUpper = new TextBox();
            checkUpperCtrl = new CheckBox();
            checkUpperAlt = new CheckBox();
            checkUpperShift = new CheckBox();
            checkUpperWin = new CheckBox();
            checkLowerWin = new CheckBox();
            checkLowerShift = new CheckBox();
            checkLowerAlt = new CheckBox();
            checkLowerCtrl = new CheckBox();
            textHotkeyLower = new TextBox();
            label4 = new Label();
            checkCapsWin = new CheckBox();
            checkCapsShift = new CheckBox();
            checkCapsAlt = new CheckBox();
            checkCapsCtrl = new CheckBox();
            textHotkeyCaps = new TextBox();
            label5 = new Label();
            checkPlainWin = new CheckBox();
            checkPlainShift = new CheckBox();
            checkPlainAlt = new CheckBox();
            checkPlainCtrl = new CheckBox();
            textHotkeyPlain = new TextBox();
            label6 = new Label();
            checkProcessWin = new CheckBox();
            checkProcessShift = new CheckBox();
            checkProcessAlt = new CheckBox();
            checkProcessCtrl = new CheckBox();
            textHotkeyProcess = new TextBox();
            label7 = new Label();
            buttonSave = new Button();
            buttonCancel = new Button();
            optionCut = new CheckBox();
            optionType = new CheckBox();
            optionPaste = new CheckBox();
            panel2 = new Panel();
            optionUpdateClipboard = new CheckBox();
            checkDateWin = new CheckBox();
            checkDateShift = new CheckBox();
            checkDateAlt = new CheckBox();
            checkDateCtrl = new CheckBox();
            textHotkeyDate = new TextBox();
            label8 = new Label();
            SuspendLayout();
            // 
            // optionStartHidden
            // 
            optionStartHidden.AutoSize = true;
            optionStartHidden.Location = new Point(12, 12);
            optionStartHidden.Name = "optionStartHidden";
            optionStartHidden.Size = new Size(92, 19);
            optionStartHidden.TabIndex = 0;
            optionStartHidden.Text = "Start Hidden";
            optionStartHidden.UseVisualStyleBackColor = true;
            // 
            // optionStartToolbar
            // 
            optionStartToolbar.AutoSize = true;
            optionStartToolbar.Location = new Point(12, 37);
            optionStartToolbar.Name = "optionStartToolbar";
            optionStartToolbar.Size = new Size(118, 19);
            optionStartToolbar.TabIndex = 1;
            optionStartToolbar.Text = "Start with Toolbar";
            optionStartToolbar.UseVisualStyleBackColor = true;
            // 
            // optionRegisterHotkeys
            // 
            optionRegisterHotkeys.AutoSize = true;
            optionRegisterHotkeys.Location = new Point(12, 168);
            optionRegisterHotkeys.Name = "optionRegisterHotkeys";
            optionRegisterHotkeys.Size = new Size(112, 19);
            optionRegisterHotkeys.TabIndex = 2;
            optionRegisterHotkeys.Text = "Register hotkeys";
            optionRegisterHotkeys.UseVisualStyleBackColor = true;
            // 
            // optionResetCounter
            // 
            optionResetCounter.AutoSize = true;
            optionResetCounter.Location = new Point(202, 12);
            optionResetCounter.Name = "optionResetCounter";
            optionResetCounter.Size = new Size(252, 19);
            optionResetCounter.TabIndex = 3;
            optionResetCounter.Text = "Reset number when updating memory slot";
            optionResetCounter.UseVisualStyleBackColor = true;
            // 
            // optionSaveMemorySlots
            // 
            optionSaveMemorySlots.AutoSize = true;
            optionSaveMemorySlots.Location = new Point(202, 37);
            optionSaveMemorySlots.Name = "optionSaveMemorySlots";
            optionSaveMemorySlots.Size = new Size(158, 19);
            optionSaveMemorySlots.TabIndex = 4;
            optionSaveMemorySlots.Text = "Save memory slots to file";
            optionSaveMemorySlots.UseVisualStyleBackColor = true;
            // 
            // textMemorySlotFolder
            // 
            textMemorySlotFolder.Location = new Point(202, 108);
            textMemorySlotFolder.Name = "textMemorySlotFolder";
            textMemorySlotFolder.Size = new Size(252, 23);
            textMemorySlotFolder.TabIndex = 5;
            // 
            // label1
            // 
            label1.Location = new Point(202, 63);
            label1.Name = "label1";
            label1.Size = new Size(252, 42);
            label1.TabIndex = 6;
            label1.Text = ".txt file folder. Use process.txt, mem1.txt mem2.txt, mem3.txt:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(12, 190);
            label2.Name = "label2";
            label2.Size = new Size(257, 15);
            label2.TabIndex = 7;
            label2.Text = "Restart the program to register new hotkeys";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 214);
            label3.Name = "label3";
            label3.Size = new Size(108, 15);
            label3.TabIndex = 8;
            label3.Text = "Hotkey Upper Case";
            // 
            // textHotkeyUpper
            // 
            textHotkeyUpper.Location = new Point(131, 209);
            textHotkeyUpper.Name = "textHotkeyUpper";
            textHotkeyUpper.Size = new Size(63, 23);
            textHotkeyUpper.TabIndex = 9;
            // 
            // checkUpperCtrl
            // 
            checkUpperCtrl.AutoSize = true;
            checkUpperCtrl.Location = new Point(202, 213);
            checkUpperCtrl.Name = "checkUpperCtrl";
            checkUpperCtrl.Size = new Size(45, 19);
            checkUpperCtrl.TabIndex = 10;
            checkUpperCtrl.Text = "Ctrl";
            checkUpperCtrl.UseVisualStyleBackColor = true;
            // 
            // checkUpperAlt
            // 
            checkUpperAlt.AutoSize = true;
            checkUpperAlt.Location = new Point(253, 213);
            checkUpperAlt.Name = "checkUpperAlt";
            checkUpperAlt.Size = new Size(41, 19);
            checkUpperAlt.TabIndex = 11;
            checkUpperAlt.Text = "Alt";
            checkUpperAlt.UseVisualStyleBackColor = true;
            // 
            // checkUpperShift
            // 
            checkUpperShift.AutoSize = true;
            checkUpperShift.Location = new Point(300, 213);
            checkUpperShift.Name = "checkUpperShift";
            checkUpperShift.Size = new Size(50, 19);
            checkUpperShift.TabIndex = 12;
            checkUpperShift.Text = "Shift";
            checkUpperShift.UseVisualStyleBackColor = true;
            // 
            // checkUpperWin
            // 
            checkUpperWin.AutoSize = true;
            checkUpperWin.Location = new Point(356, 213);
            checkUpperWin.Name = "checkUpperWin";
            checkUpperWin.Size = new Size(47, 19);
            checkUpperWin.TabIndex = 13;
            checkUpperWin.Text = "Win";
            checkUpperWin.UseVisualStyleBackColor = true;
            // 
            // checkLowerWin
            // 
            checkLowerWin.AutoSize = true;
            checkLowerWin.Location = new Point(356, 240);
            checkLowerWin.Name = "checkLowerWin";
            checkLowerWin.Size = new Size(47, 19);
            checkLowerWin.TabIndex = 19;
            checkLowerWin.Text = "Win";
            checkLowerWin.UseVisualStyleBackColor = true;
            // 
            // checkLowerShift
            // 
            checkLowerShift.AutoSize = true;
            checkLowerShift.Location = new Point(300, 240);
            checkLowerShift.Name = "checkLowerShift";
            checkLowerShift.Size = new Size(50, 19);
            checkLowerShift.TabIndex = 18;
            checkLowerShift.Text = "Shift";
            checkLowerShift.UseVisualStyleBackColor = true;
            // 
            // checkLowerAlt
            // 
            checkLowerAlt.AutoSize = true;
            checkLowerAlt.Location = new Point(253, 240);
            checkLowerAlt.Name = "checkLowerAlt";
            checkLowerAlt.Size = new Size(41, 19);
            checkLowerAlt.TabIndex = 17;
            checkLowerAlt.Text = "Alt";
            checkLowerAlt.UseVisualStyleBackColor = true;
            // 
            // checkLowerCtrl
            // 
            checkLowerCtrl.AutoSize = true;
            checkLowerCtrl.Location = new Point(202, 240);
            checkLowerCtrl.Name = "checkLowerCtrl";
            checkLowerCtrl.Size = new Size(45, 19);
            checkLowerCtrl.TabIndex = 16;
            checkLowerCtrl.Text = "Ctrl";
            checkLowerCtrl.UseVisualStyleBackColor = true;
            // 
            // textHotkeyLower
            // 
            textHotkeyLower.Location = new Point(131, 236);
            textHotkeyLower.Name = "textHotkeyLower";
            textHotkeyLower.Size = new Size(63, 23);
            textHotkeyLower.TabIndex = 15;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 241);
            label4.Name = "label4";
            label4.Size = new Size(108, 15);
            label4.TabIndex = 14;
            label4.Text = "Hotkey Lower Case";
            // 
            // checkCapsWin
            // 
            checkCapsWin.AutoSize = true;
            checkCapsWin.Location = new Point(356, 295);
            checkCapsWin.Name = "checkCapsWin";
            checkCapsWin.Size = new Size(47, 19);
            checkCapsWin.TabIndex = 31;
            checkCapsWin.Text = "Win";
            checkCapsWin.UseVisualStyleBackColor = true;
            // 
            // checkCapsShift
            // 
            checkCapsShift.AutoSize = true;
            checkCapsShift.Location = new Point(300, 295);
            checkCapsShift.Name = "checkCapsShift";
            checkCapsShift.Size = new Size(50, 19);
            checkCapsShift.TabIndex = 30;
            checkCapsShift.Text = "Shift";
            checkCapsShift.UseVisualStyleBackColor = true;
            // 
            // checkCapsAlt
            // 
            checkCapsAlt.AutoSize = true;
            checkCapsAlt.Location = new Point(253, 295);
            checkCapsAlt.Name = "checkCapsAlt";
            checkCapsAlt.Size = new Size(41, 19);
            checkCapsAlt.TabIndex = 29;
            checkCapsAlt.Text = "Alt";
            checkCapsAlt.UseVisualStyleBackColor = true;
            // 
            // checkCapsCtrl
            // 
            checkCapsCtrl.AutoSize = true;
            checkCapsCtrl.Location = new Point(202, 295);
            checkCapsCtrl.Name = "checkCapsCtrl";
            checkCapsCtrl.Size = new Size(45, 19);
            checkCapsCtrl.TabIndex = 28;
            checkCapsCtrl.Text = "Ctrl";
            checkCapsCtrl.UseVisualStyleBackColor = true;
            // 
            // textHotkeyCaps
            // 
            textHotkeyCaps.Location = new Point(131, 291);
            textHotkeyCaps.Name = "textHotkeyCaps";
            textHotkeyCaps.Size = new Size(63, 23);
            textHotkeyCaps.TabIndex = 27;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 296);
            label5.Name = "label5";
            label5.Size = new Size(102, 15);
            label5.TabIndex = 26;
            label5.Text = "Hotkey Caps Lock";
            // 
            // checkPlainWin
            // 
            checkPlainWin.AutoSize = true;
            checkPlainWin.Location = new Point(356, 268);
            checkPlainWin.Name = "checkPlainWin";
            checkPlainWin.Size = new Size(47, 19);
            checkPlainWin.TabIndex = 25;
            checkPlainWin.Text = "Win";
            checkPlainWin.UseVisualStyleBackColor = true;
            // 
            // checkPlainShift
            // 
            checkPlainShift.AutoSize = true;
            checkPlainShift.Location = new Point(300, 268);
            checkPlainShift.Name = "checkPlainShift";
            checkPlainShift.Size = new Size(50, 19);
            checkPlainShift.TabIndex = 24;
            checkPlainShift.Text = "Shift";
            checkPlainShift.UseVisualStyleBackColor = true;
            // 
            // checkPlainAlt
            // 
            checkPlainAlt.AutoSize = true;
            checkPlainAlt.Location = new Point(253, 268);
            checkPlainAlt.Name = "checkPlainAlt";
            checkPlainAlt.Size = new Size(41, 19);
            checkPlainAlt.TabIndex = 23;
            checkPlainAlt.Text = "Alt";
            checkPlainAlt.UseVisualStyleBackColor = true;
            // 
            // checkPlainCtrl
            // 
            checkPlainCtrl.AutoSize = true;
            checkPlainCtrl.Location = new Point(202, 268);
            checkPlainCtrl.Name = "checkPlainCtrl";
            checkPlainCtrl.Size = new Size(45, 19);
            checkPlainCtrl.TabIndex = 22;
            checkPlainCtrl.Text = "Ctrl";
            checkPlainCtrl.UseVisualStyleBackColor = true;
            // 
            // textHotkeyPlain
            // 
            textHotkeyPlain.Location = new Point(131, 264);
            textHotkeyPlain.Name = "textHotkeyPlain";
            textHotkeyPlain.Size = new Size(63, 23);
            textHotkeyPlain.TabIndex = 21;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 269);
            label6.Name = "label6";
            label6.Size = new Size(98, 15);
            label6.TabIndex = 20;
            label6.Text = "Hotkey Plain Text";
            // 
            // checkProcessWin
            // 
            checkProcessWin.AutoSize = true;
            checkProcessWin.Location = new Point(356, 324);
            checkProcessWin.Name = "checkProcessWin";
            checkProcessWin.Size = new Size(47, 19);
            checkProcessWin.TabIndex = 37;
            checkProcessWin.Text = "Win";
            checkProcessWin.UseVisualStyleBackColor = true;
            // 
            // checkProcessShift
            // 
            checkProcessShift.AutoSize = true;
            checkProcessShift.Location = new Point(300, 324);
            checkProcessShift.Name = "checkProcessShift";
            checkProcessShift.Size = new Size(50, 19);
            checkProcessShift.TabIndex = 36;
            checkProcessShift.Text = "Shift";
            checkProcessShift.UseVisualStyleBackColor = true;
            // 
            // checkProcessAlt
            // 
            checkProcessAlt.AutoSize = true;
            checkProcessAlt.Location = new Point(253, 324);
            checkProcessAlt.Name = "checkProcessAlt";
            checkProcessAlt.Size = new Size(41, 19);
            checkProcessAlt.TabIndex = 35;
            checkProcessAlt.Text = "Alt";
            checkProcessAlt.UseVisualStyleBackColor = true;
            // 
            // checkProcessCtrl
            // 
            checkProcessCtrl.AutoSize = true;
            checkProcessCtrl.Location = new Point(202, 324);
            checkProcessCtrl.Name = "checkProcessCtrl";
            checkProcessCtrl.Size = new Size(45, 19);
            checkProcessCtrl.TabIndex = 34;
            checkProcessCtrl.Text = "Ctrl";
            checkProcessCtrl.UseVisualStyleBackColor = true;
            // 
            // textHotkeyProcess
            // 
            textHotkeyProcess.Location = new Point(131, 320);
            textHotkeyProcess.Name = "textHotkeyProcess";
            textHotkeyProcess.Size = new Size(63, 23);
            textHotkeyProcess.TabIndex = 33;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 325);
            label7.Name = "label7";
            label7.Size = new Size(112, 15);
            label7.TabIndex = 32;
            label7.Text = "Hotkey Process Text";
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSave.Location = new Point(393, 388);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 38;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(312, 388);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 39;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // optionCut
            // 
            optionCut.AutoSize = true;
            optionCut.Location = new Point(12, 63);
            optionCut.Name = "optionCut";
            optionCut.Size = new Size(163, 19);
            optionCut.TabIndex = 40;
            optionCut.Text = "Ctrl+X when using hotkey";
            optionCut.UseVisualStyleBackColor = true;
            // 
            // optionType
            // 
            optionType.AutoSize = true;
            optionType.Location = new Point(12, 110);
            optionType.Name = "optionType";
            optionType.Size = new Size(181, 19);
            optionType.TabIndex = 41;
            optionType.Text = "Send keys when using hotkey";
            optionType.UseVisualStyleBackColor = true;
            // 
            // optionPaste
            // 
            optionPaste.AutoSize = true;
            optionPaste.Location = new Point(12, 88);
            optionPaste.Name = "optionPaste";
            optionPaste.Size = new Size(163, 19);
            optionPaste.TabIndex = 42;
            optionPaste.Text = "Ctrl+V when using hotkey";
            optionPaste.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Location = new Point(195, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(0, 125);
            panel2.TabIndex = 43;
            // 
            // optionUpdateClipboard
            // 
            optionUpdateClipboard.AutoSize = true;
            optionUpdateClipboard.Location = new Point(12, 135);
            optionUpdateClipboard.Name = "optionUpdateClipboard";
            optionUpdateClipboard.Size = new Size(237, 19);
            optionUpdateClipboard.TabIndex = 44;
            optionUpdateClipboard.Text = "Update clipboard when using Send Keys";
            optionUpdateClipboard.UseVisualStyleBackColor = true;
            // 
            // checkDateWin
            // 
            checkDateWin.AutoSize = true;
            checkDateWin.Location = new Point(356, 352);
            checkDateWin.Name = "checkDateWin";
            checkDateWin.Size = new Size(47, 19);
            checkDateWin.TabIndex = 50;
            checkDateWin.Text = "Win";
            checkDateWin.UseVisualStyleBackColor = true;
            // 
            // checkDateShift
            // 
            checkDateShift.AutoSize = true;
            checkDateShift.Location = new Point(300, 352);
            checkDateShift.Name = "checkDateShift";
            checkDateShift.Size = new Size(50, 19);
            checkDateShift.TabIndex = 49;
            checkDateShift.Text = "Shift";
            checkDateShift.UseVisualStyleBackColor = true;
            // 
            // checkDateAlt
            // 
            checkDateAlt.AutoSize = true;
            checkDateAlt.Location = new Point(253, 352);
            checkDateAlt.Name = "checkDateAlt";
            checkDateAlt.Size = new Size(41, 19);
            checkDateAlt.TabIndex = 48;
            checkDateAlt.Text = "Alt";
            checkDateAlt.UseVisualStyleBackColor = true;
            // 
            // checkDateCtrl
            // 
            checkDateCtrl.AutoSize = true;
            checkDateCtrl.Location = new Point(202, 352);
            checkDateCtrl.Name = "checkDateCtrl";
            checkDateCtrl.Size = new Size(45, 19);
            checkDateCtrl.TabIndex = 47;
            checkDateCtrl.Text = "Ctrl";
            checkDateCtrl.UseVisualStyleBackColor = true;
            // 
            // textHotkeyDate
            // 
            textHotkeyDate.Location = new Point(131, 348);
            textHotkeyDate.Name = "textHotkeyDate";
            textHotkeyDate.Size = new Size(63, 23);
            textHotkeyDate.TabIndex = 46;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 353);
            label8.Name = "label8";
            label8.Size = new Size(103, 15);
            label8.TabIndex = 45;
            label8.Text = "Hotkey Date/Time";
            // 
            // Options
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(478, 418);
            Controls.Add(checkDateWin);
            Controls.Add(checkDateShift);
            Controls.Add(checkDateAlt);
            Controls.Add(checkDateCtrl);
            Controls.Add(textHotkeyDate);
            Controls.Add(label8);
            Controls.Add(optionUpdateClipboard);
            Controls.Add(panel2);
            Controls.Add(optionPaste);
            Controls.Add(optionType);
            Controls.Add(optionCut);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(checkProcessWin);
            Controls.Add(checkProcessShift);
            Controls.Add(checkProcessAlt);
            Controls.Add(checkProcessCtrl);
            Controls.Add(textHotkeyProcess);
            Controls.Add(label7);
            Controls.Add(checkCapsWin);
            Controls.Add(checkCapsShift);
            Controls.Add(checkCapsAlt);
            Controls.Add(checkCapsCtrl);
            Controls.Add(textHotkeyCaps);
            Controls.Add(label5);
            Controls.Add(checkPlainWin);
            Controls.Add(checkPlainShift);
            Controls.Add(checkPlainAlt);
            Controls.Add(checkPlainCtrl);
            Controls.Add(textHotkeyPlain);
            Controls.Add(label6);
            Controls.Add(checkLowerWin);
            Controls.Add(checkLowerShift);
            Controls.Add(checkLowerAlt);
            Controls.Add(checkLowerCtrl);
            Controls.Add(textHotkeyLower);
            Controls.Add(label4);
            Controls.Add(checkUpperWin);
            Controls.Add(checkUpperShift);
            Controls.Add(checkUpperAlt);
            Controls.Add(checkUpperCtrl);
            Controls.Add(textHotkeyUpper);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textMemorySlotFolder);
            Controls.Add(optionSaveMemorySlots);
            Controls.Add(optionResetCounter);
            Controls.Add(optionRegisterHotkeys);
            Controls.Add(optionStartToolbar);
            Controls.Add(optionStartHidden);
            Name = "Options";
            Text = "Options";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox optionStartHidden;
        private CheckBox optionStartToolbar;
        private CheckBox optionRegisterHotkeys;
        private CheckBox optionResetCounter;
        private CheckBox optionSaveMemorySlots;
        private TextBox textMemorySlotFolder;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textHotkeyUpper;
        private CheckBox checkUpperCtrl;
        private CheckBox checkUpperAlt;
        private CheckBox checkUpperShift;
        private CheckBox checkUpperWin;
        private CheckBox checkLowerWin;
        private CheckBox checkLowerShift;
        private CheckBox checkLowerAlt;
        private CheckBox checkLowerCtrl;
        private TextBox textHotkeyLower;
        private Label label4;
        private CheckBox checkCapsWin;
        private CheckBox checkCapsShift;
        private CheckBox checkCapsAlt;
        private CheckBox checkCapsCtrl;
        private TextBox textHotkeyCaps;
        private Label label5;
        private CheckBox checkPlainWin;
        private CheckBox checkPlainShift;
        private CheckBox checkPlainAlt;
        private CheckBox checkPlainCtrl;
        private TextBox textHotkeyPlain;
        private Label label6;
        private CheckBox checkProcessWin;
        private CheckBox checkProcessShift;
        private CheckBox checkProcessAlt;
        private CheckBox checkProcessCtrl;
        private TextBox textHotkeyProcess;
        private Label label7;
        private Button buttonSave;
        private Button buttonCancel;
        private CheckBox optionCut;
        private CheckBox optionType;
        private CheckBox optionPaste;
        private Panel panel2;
        private CheckBox optionUpdateClipboard;
        private CheckBox checkDateWin;
        private CheckBox checkDateShift;
        private CheckBox checkDateAlt;
        private CheckBox checkDateCtrl;
        private TextBox textHotkeyDate;
        private Label label8;
    }
}