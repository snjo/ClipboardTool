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
            buttonSave = new Button();
            buttonCancel = new Button();
            optionCut = new CheckBox();
            optionType = new CheckBox();
            optionPaste = new CheckBox();
            optionUpdateClipboard = new CheckBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            HotkeyGrid = new DataGridView();
            Function = new DataGridViewTextBoxColumn();
            Key = new DataGridViewTextBoxColumn();
            Ctrl = new DataGridViewCheckBoxColumn();
            Alt = new DataGridViewCheckBoxColumn();
            Shift = new DataGridViewCheckBoxColumn();
            Win = new DataGridViewCheckBoxColumn();
            linkLabel1 = new LinkLabel();
            linkLabel2 = new LinkLabel();
            label10 = new Label();
            buttonSelectSlotFolder = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            buttonSelectHistoryFolder = new Button();
            textBoxHistory = new TextBox();
            label3 = new Label();
            checkBoxHistoryMinimize = new CheckBox();
            labelVersion = new Label();
            checkBoxTrayCapslock = new CheckBox();
            textBoxRTFcolors = new TextBox();
            label4 = new Label();
            tabControl1 = new TabControl();
            tabPageGeneral = new TabPage();
            tabPageHotkeys = new TabPage();
            tabPageSources = new TabPage();
            tabPageCustom = new TabPage();
            label6 = new Label();
            checkBoxRTFfont = new CheckBox();
            checkBoxRTFcolor = new CheckBox();
            buttonRTFDefaultFonts = new Button();
            buttonRTFDefaultColors = new Button();
            label5 = new Label();
            textBoxRTFfonts = new TextBox();
            ((System.ComponentModel.ISupportInitialize)HotkeyGrid).BeginInit();
            tabControl1.SuspendLayout();
            tabPageGeneral.SuspendLayout();
            tabPageHotkeys.SuspendLayout();
            tabPageSources.SuspendLayout();
            tabPageCustom.SuspendLayout();
            SuspendLayout();
            // 
            // optionStartHidden
            // 
            optionStartHidden.AutoSize = true;
            optionStartHidden.Location = new Point(6, 6);
            optionStartHidden.Name = "optionStartHidden";
            optionStartHidden.Size = new Size(92, 19);
            optionStartHidden.TabIndex = 0;
            optionStartHidden.Text = "Start Hidden";
            optionStartHidden.UseVisualStyleBackColor = true;
            // 
            // optionStartToolbar
            // 
            optionStartToolbar.AutoSize = true;
            optionStartToolbar.Location = new Point(6, 29);
            optionStartToolbar.Name = "optionStartToolbar";
            optionStartToolbar.Size = new Size(118, 19);
            optionStartToolbar.TabIndex = 1;
            optionStartToolbar.Text = "Start with Toolbar";
            optionStartToolbar.UseVisualStyleBackColor = true;
            // 
            // optionRegisterHotkeys
            // 
            optionRegisterHotkeys.AutoSize = true;
            optionRegisterHotkeys.Location = new Point(6, 6);
            optionRegisterHotkeys.Name = "optionRegisterHotkeys";
            optionRegisterHotkeys.Size = new Size(112, 19);
            optionRegisterHotkeys.TabIndex = 2;
            optionRegisterHotkeys.Text = "Register hotkeys";
            optionRegisterHotkeys.UseVisualStyleBackColor = true;
            // 
            // optionResetCounter
            // 
            optionResetCounter.AutoSize = true;
            optionResetCounter.Location = new Point(6, 170);
            optionResetCounter.Name = "optionResetCounter";
            optionResetCounter.Size = new Size(252, 19);
            optionResetCounter.TabIndex = 3;
            optionResetCounter.Text = "Reset number when updating memory slot";
            optionResetCounter.UseVisualStyleBackColor = true;
            // 
            // optionSaveMemorySlots
            // 
            optionSaveMemorySlots.AutoSize = true;
            optionSaveMemorySlots.Location = new Point(0, 9);
            optionSaveMemorySlots.Name = "optionSaveMemorySlots";
            optionSaveMemorySlots.Size = new Size(158, 19);
            optionSaveMemorySlots.TabIndex = 4;
            optionSaveMemorySlots.Text = "Save memory slots to file";
            optionSaveMemorySlots.UseVisualStyleBackColor = true;
            // 
            // textMemorySlotFolder
            // 
            textMemorySlotFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textMemorySlotFolder.Location = new Point(3, 55);
            textMemorySlotFolder.Name = "textMemorySlotFolder";
            textMemorySlotFolder.Size = new Size(350, 23);
            textMemorySlotFolder.TabIndex = 5;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(3, 81);
            label1.Name = "label1";
            label1.Size = new Size(232, 30);
            label1.TabIndex = 6;
            label1.Text = "Use process.txt, mem1.txt mem2.txt, mem3.txt:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(134, 7);
            label2.Name = "label2";
            label2.Size = new Size(230, 15);
            label2.TabIndex = 7;
            label2.Text = "Restart the program to register hotkeys";
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSave.Location = new Point(508, 604);
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
            buttonCancel.Location = new Point(427, 604);
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
            optionCut.Location = new Point(6, 62);
            optionCut.Name = "optionCut";
            optionCut.Size = new Size(216, 19);
            optionCut.TabIndex = 40;
            optionCut.Text = "Cut text (Ctrl+X) when using hotkey";
            optionCut.UseVisualStyleBackColor = true;
            // 
            // optionType
            // 
            optionType.AutoSize = true;
            optionType.Location = new Point(6, 112);
            optionType.Name = "optionType";
            optionType.Size = new Size(250, 19);
            optionType.TabIndex = 41;
            optionType.Text = "Send text as keystrokes when using hotkey";
            optionType.UseVisualStyleBackColor = true;
            optionType.CheckedChanged += optionType_CheckedChanged;
            // 
            // optionPaste
            // 
            optionPaste.AutoSize = true;
            optionPaste.Location = new Point(6, 87);
            optionPaste.Name = "optionPaste";
            optionPaste.Size = new Size(314, 19);
            optionPaste.TabIndex = 42;
            optionPaste.Text = "Paste text (Ctrl+V) when using hotkey (recommended)";
            optionPaste.UseVisualStyleBackColor = true;
            optionPaste.CheckedChanged += optionPaste_CheckedChanged;
            // 
            // optionUpdateClipboard
            // 
            optionUpdateClipboard.AutoSize = true;
            optionUpdateClipboard.Location = new Point(6, 137);
            optionUpdateClipboard.Name = "optionUpdateClipboard";
            optionUpdateClipboard.Size = new Size(292, 19);
            optionUpdateClipboard.TabIndex = 44;
            optionUpdateClipboard.Text = "Update clipboard when sending keys as keystrokes";
            optionUpdateClipboard.UseVisualStyleBackColor = true;
            // 
            // HotkeyGrid
            // 
            HotkeyGrid.AllowUserToAddRows = false;
            HotkeyGrid.AllowUserToDeleteRows = false;
            HotkeyGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            HotkeyGrid.BackgroundColor = SystemColors.Window;
            HotkeyGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            HotkeyGrid.Columns.AddRange(new DataGridViewColumn[] { Function, Key, Ctrl, Alt, Shift, Win });
            HotkeyGrid.Location = new Point(6, 31);
            HotkeyGrid.Name = "HotkeyGrid";
            HotkeyGrid.RowHeadersVisible = false;
            HotkeyGrid.RowTemplate.Height = 25;
            HotkeyGrid.Size = new Size(418, 418);
            HotkeyGrid.TabIndex = 52;
            // 
            // Function
            // 
            Function.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Function.HeaderText = "Function";
            Function.Name = "Function";
            Function.ReadOnly = true;
            Function.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Key
            // 
            Key.HeaderText = "Key";
            Key.Name = "Key";
            Key.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Ctrl
            // 
            Ctrl.HeaderText = "Ctrl";
            Ctrl.Name = "Ctrl";
            Ctrl.Width = 50;
            // 
            // Alt
            // 
            Alt.HeaderText = "Alt";
            Alt.Name = "Alt";
            Alt.Width = 50;
            // 
            // Shift
            // 
            Shift.HeaderText = "Shift";
            Shift.Name = "Shift";
            Shift.Width = 50;
            // 
            // Win
            // 
            Win.HeaderText = "Win";
            Win.Name = "Win";
            Win.Width = 50;
            // 
            // linkLabel1
            // 
            linkLabel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(11, 608);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(49, 15);
            linkLabel1.TabIndex = 53;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Website";
            linkLabel1.LinkClicked += linkWebsite;
            // 
            // linkLabel2
            // 
            linkLabel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(66, 608);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(100, 15);
            linkLabel2.TabIndex = 54;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "user.config folder";
            linkLabel2.LinkClicked += LinkSettings;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(3, 37);
            label10.Name = "label10";
            label10.Size = new Size(100, 15);
            label10.TabIndex = 55;
            label10.Text = "Slot .txt file folder";
            // 
            // buttonSelectSlotFolder
            // 
            buttonSelectSlotFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonSelectSlotFolder.Location = new Point(359, 55);
            buttonSelectSlotFolder.Name = "buttonSelectSlotFolder";
            buttonSelectSlotFolder.Size = new Size(58, 23);
            buttonSelectSlotFolder.TabIndex = 56;
            buttonSelectSlotFolder.Text = "Select";
            buttonSelectSlotFolder.UseVisualStyleBackColor = true;
            buttonSelectSlotFolder.Click += buttonSelectFolder_Click;
            // 
            // folderBrowserDialog1
            // 
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyDocuments;
            // 
            // buttonSelectHistoryFolder
            // 
            buttonSelectHistoryFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonSelectHistoryFolder.Location = new Point(361, 139);
            buttonSelectHistoryFolder.Name = "buttonSelectHistoryFolder";
            buttonSelectHistoryFolder.Size = new Size(58, 23);
            buttonSelectHistoryFolder.TabIndex = 58;
            buttonSelectHistoryFolder.Text = "Select";
            buttonSelectHistoryFolder.UseVisualStyleBackColor = true;
            buttonSelectHistoryFolder.Click += buttonSelectHistoryFolder_Click;
            // 
            // textBoxHistory
            // 
            textBoxHistory.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxHistory.Location = new Point(3, 140);
            textBoxHistory.Name = "textBoxHistory";
            textBoxHistory.Size = new Size(352, 23);
            textBoxHistory.TabIndex = 57;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 122);
            label3.Name = "label3";
            label3.Size = new Size(79, 15);
            label3.TabIndex = 59;
            label3.Text = "History folder";
            // 
            // checkBoxHistoryMinimize
            // 
            checkBoxHistoryMinimize.AutoSize = true;
            checkBoxHistoryMinimize.Location = new Point(6, 195);
            checkBoxHistoryMinimize.Name = "checkBoxHistoryMinimize";
            checkBoxHistoryMinimize.Size = new Size(174, 19);
            checkBoxHistoryMinimize.TabIndex = 60;
            checkBoxHistoryMinimize.Text = "Minimize History after Copy";
            checkBoxHistoryMinimize.UseVisualStyleBackColor = true;
            // 
            // labelVersion
            // 
            labelVersion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelVersion.AutoSize = true;
            labelVersion.Location = new Point(172, 608);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new Size(45, 15);
            labelVersion.TabIndex = 61;
            labelVersion.Text = "version";
            // 
            // checkBoxTrayCapslock
            // 
            checkBoxTrayCapslock.AutoSize = true;
            checkBoxTrayCapslock.Location = new Point(6, 220);
            checkBoxTrayCapslock.Name = "checkBoxTrayCapslock";
            checkBoxTrayCapslock.Size = new Size(164, 19);
            checkBoxTrayCapslock.TabIndex = 62;
            checkBoxTrayCapslock.Text = "Tray icon Caps Lock status";
            checkBoxTrayCapslock.UseVisualStyleBackColor = true;
            // 
            // textBoxRTFcolors
            // 
            textBoxRTFcolors.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxRTFcolors.Location = new Point(3, 46);
            textBoxRTFcolors.Multiline = true;
            textBoxRTFcolors.Name = "textBoxRTFcolors";
            textBoxRTFcolors.Size = new Size(573, 69);
            textBoxRTFcolors.TabIndex = 63;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 28);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 64;
            label4.Text = "RTF colors";
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPageGeneral);
            tabControl1.Controls.Add(tabPageHotkeys);
            tabControl1.Controls.Add(tabPageSources);
            tabControl1.Controls.Add(tabPageCustom);
            tabControl1.Location = new Point(1, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(591, 603);
            tabControl1.TabIndex = 65;
            // 
            // tabPageGeneral
            // 
            tabPageGeneral.Controls.Add(optionStartHidden);
            tabPageGeneral.Controls.Add(optionStartToolbar);
            tabPageGeneral.Controls.Add(checkBoxTrayCapslock);
            tabPageGeneral.Controls.Add(optionCut);
            tabPageGeneral.Controls.Add(checkBoxHistoryMinimize);
            tabPageGeneral.Controls.Add(optionType);
            tabPageGeneral.Controls.Add(optionPaste);
            tabPageGeneral.Controls.Add(optionUpdateClipboard);
            tabPageGeneral.Controls.Add(optionResetCounter);
            tabPageGeneral.Location = new Point(4, 24);
            tabPageGeneral.Name = "tabPageGeneral";
            tabPageGeneral.Padding = new Padding(3);
            tabPageGeneral.Size = new Size(583, 575);
            tabPageGeneral.TabIndex = 0;
            tabPageGeneral.Text = "General";
            tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // tabPageHotkeys
            // 
            tabPageHotkeys.Controls.Add(optionRegisterHotkeys);
            tabPageHotkeys.Controls.Add(label2);
            tabPageHotkeys.Controls.Add(HotkeyGrid);
            tabPageHotkeys.Location = new Point(4, 24);
            tabPageHotkeys.Name = "tabPageHotkeys";
            tabPageHotkeys.Padding = new Padding(3);
            tabPageHotkeys.Size = new Size(583, 575);
            tabPageHotkeys.TabIndex = 1;
            tabPageHotkeys.Text = "Hotkeys";
            tabPageHotkeys.UseVisualStyleBackColor = true;
            // 
            // tabPageSources
            // 
            tabPageSources.Controls.Add(optionSaveMemorySlots);
            tabPageSources.Controls.Add(label10);
            tabPageSources.Controls.Add(textMemorySlotFolder);
            tabPageSources.Controls.Add(label1);
            tabPageSources.Controls.Add(buttonSelectSlotFolder);
            tabPageSources.Controls.Add(label3);
            tabPageSources.Controls.Add(textBoxHistory);
            tabPageSources.Controls.Add(buttonSelectHistoryFolder);
            tabPageSources.Location = new Point(4, 24);
            tabPageSources.Name = "tabPageSources";
            tabPageSources.Size = new Size(583, 575);
            tabPageSources.TabIndex = 3;
            tabPageSources.Text = "Text sources";
            tabPageSources.UseVisualStyleBackColor = true;
            // 
            // tabPageCustom
            // 
            tabPageCustom.Controls.Add(label6);
            tabPageCustom.Controls.Add(checkBoxRTFfont);
            tabPageCustom.Controls.Add(checkBoxRTFcolor);
            tabPageCustom.Controls.Add(buttonRTFDefaultFonts);
            tabPageCustom.Controls.Add(buttonRTFDefaultColors);
            tabPageCustom.Controls.Add(label5);
            tabPageCustom.Controls.Add(textBoxRTFfonts);
            tabPageCustom.Controls.Add(label4);
            tabPageCustom.Controls.Add(textBoxRTFcolors);
            tabPageCustom.Location = new Point(4, 24);
            tabPageCustom.Name = "tabPageCustom";
            tabPageCustom.Size = new Size(583, 575);
            tabPageCustom.TabIndex = 2;
            tabPageCustom.Text = "Custom values";
            tabPageCustom.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label6.Location = new Point(3, 263);
            label6.Name = "label6";
            label6.Size = new Size(569, 15);
            label6.TabIndex = 71;
            label6.Text = "When Color/Font tables are allowed, pasted text will not use the font or color that's already in the document";
            // 
            // checkBoxRTFfont
            // 
            checkBoxRTFfont.AutoSize = true;
            checkBoxRTFfont.Location = new Point(6, 125);
            checkBoxRTFfont.Name = "checkBoxRTFfont";
            checkBoxRTFfont.Size = new Size(175, 19);
            checkBoxRTFfont.TabIndex = 70;
            checkBoxRTFfont.Text = "Allow Font table in Rich Text";
            checkBoxRTFfont.UseVisualStyleBackColor = true;
            // 
            // checkBoxRTFcolor
            // 
            checkBoxRTFcolor.AutoSize = true;
            checkBoxRTFcolor.Location = new Point(7, 6);
            checkBoxRTFcolor.Name = "checkBoxRTFcolor";
            checkBoxRTFcolor.Size = new Size(180, 19);
            checkBoxRTFcolor.TabIndex = 69;
            checkBoxRTFcolor.Text = "Allow Color table in Rich Text";
            checkBoxRTFcolor.UseVisualStyleBackColor = true;
            // 
            // buttonRTFDefaultFonts
            // 
            buttonRTFDefaultFonts.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonRTFDefaultFonts.Location = new Point(503, 143);
            buttonRTFDefaultFonts.Name = "buttonRTFDefaultFonts";
            buttonRTFDefaultFonts.Size = new Size(75, 23);
            buttonRTFDefaultFonts.TabIndex = 68;
            buttonRTFDefaultFonts.Text = "Default";
            buttonRTFDefaultFonts.UseVisualStyleBackColor = true;
            buttonRTFDefaultFonts.Click += buttonRTFDefaultFonts_Click;
            // 
            // buttonRTFDefaultColors
            // 
            buttonRTFDefaultColors.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonRTFDefaultColors.Location = new Point(503, 24);
            buttonRTFDefaultColors.Name = "buttonRTFDefaultColors";
            buttonRTFDefaultColors.Size = new Size(75, 23);
            buttonRTFDefaultColors.TabIndex = 67;
            buttonRTFDefaultColors.Text = "Default";
            buttonRTFDefaultColors.UseVisualStyleBackColor = true;
            buttonRTFDefaultColors.Click += buttonRTFDefaultColors_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 147);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 66;
            label5.Text = "RTF fonts";
            // 
            // textBoxRTFfonts
            // 
            textBoxRTFfonts.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxRTFfonts.Location = new Point(3, 165);
            textBoxRTFfonts.Multiline = true;
            textBoxRTFfonts.Name = "textBoxRTFfonts";
            textBoxRTFfonts.Size = new Size(573, 85);
            textBoxRTFfonts.TabIndex = 65;
            // 
            // Options
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(593, 634);
            Controls.Add(tabControl1);
            Controls.Add(labelVersion);
            Controls.Add(linkLabel2);
            Controls.Add(linkLabel1);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            MinimumSize = new Size(450, 400);
            Name = "Options";
            Text = "Options";
            ((System.ComponentModel.ISupportInitialize)HotkeyGrid).EndInit();
            tabControl1.ResumeLayout(false);
            tabPageGeneral.ResumeLayout(false);
            tabPageGeneral.PerformLayout();
            tabPageHotkeys.ResumeLayout(false);
            tabPageHotkeys.PerformLayout();
            tabPageSources.ResumeLayout(false);
            tabPageSources.PerformLayout();
            tabPageCustom.ResumeLayout(false);
            tabPageCustom.PerformLayout();
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
        private Button buttonSave;
        private Button buttonCancel;
        private CheckBox optionCut;
        private CheckBox optionType;
        private CheckBox optionPaste;
        private CheckBox optionUpdateClipboard;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DataGridView HotkeyGrid;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
        private DataGridViewTextBoxColumn Function;
        private DataGridViewTextBoxColumn Key;
        private DataGridViewCheckBoxColumn Ctrl;
        private DataGridViewCheckBoxColumn Alt;
        private DataGridViewCheckBoxColumn Shift;
        private DataGridViewCheckBoxColumn Win;
        private Label label10;
        private Button buttonSelectSlotFolder;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button buttonSelectHistoryFolder;
        private TextBox textBoxHistory;
        private Label label3;
        private CheckBox checkBoxHistoryMinimize;
        private Label labelVersion;
        private CheckBox checkBoxTrayCapslock;
        private TextBox textBoxRTFcolors;
        private Label label4;
        private TabControl tabControl1;
        private TabPage tabPageGeneral;
        private TabPage tabPageHotkeys;
        private TabPage tabPageSources;
        private TabPage tabPageCustom;
        private Label label5;
        private TextBox textBoxRTFfonts;
        private Button buttonRTFDefaultFonts;
        private Button buttonRTFDefaultColors;
        private Label label6;
        private CheckBox checkBoxRTFfont;
        private CheckBox checkBoxRTFcolor;
    }
}