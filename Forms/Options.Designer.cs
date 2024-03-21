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
            checkBoxMathWarning = new CheckBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            tabPageHotkeys = new TabPage();
            tabPageSources = new TabPage();
            tabPageCustom = new TabPage();
            button1 = new Button();
            label13 = new Label();
            label12 = new Label();
            textBoxCulture = new TextBox();
            label11 = new Label();
            label2 = new Label();
            label6 = new Label();
            checkBoxRTFfont = new CheckBox();
            checkBoxRTFcolor = new CheckBox();
            buttonRTFDefaultFonts = new Button();
            buttonRTFDefaultColors = new Button();
            label5 = new Label();
            textBoxRTFfonts = new TextBox();
            optionAutoStart = new CheckBox();
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
            optionStartHidden.Location = new Point(26, 57);
            optionStartHidden.Name = "optionStartHidden";
            optionStartHidden.Size = new Size(92, 19);
            optionStartHidden.TabIndex = 0;
            optionStartHidden.Text = "Start Hidden";
            optionStartHidden.UseVisualStyleBackColor = true;
            // 
            // optionStartToolbar
            // 
            optionStartToolbar.AutoSize = true;
            optionStartToolbar.Location = new Point(26, 80);
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
            optionResetCounter.Location = new Point(21, 280);
            optionResetCounter.Name = "optionResetCounter";
            optionResetCounter.Size = new Size(252, 19);
            optionResetCounter.TabIndex = 3;
            optionResetCounter.Text = "Reset number when updating memory slot";
            optionResetCounter.UseVisualStyleBackColor = true;
            // 
            // optionSaveMemorySlots
            // 
            optionSaveMemorySlots.AutoSize = true;
            optionSaveMemorySlots.Location = new Point(7, 7);
            optionSaveMemorySlots.Name = "optionSaveMemorySlots";
            optionSaveMemorySlots.Size = new Size(233, 19);
            optionSaveMemorySlots.TabIndex = 4;
            optionSaveMemorySlots.Text = "Save memory slots to file automatically";
            optionSaveMemorySlots.UseVisualStyleBackColor = true;
            // 
            // textMemorySlotFolder
            // 
            textMemorySlotFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textMemorySlotFolder.Location = new Point(3, 55);
            textMemorySlotFolder.Name = "textMemorySlotFolder";
            textMemorySlotFolder.Size = new Size(366, 23);
            textMemorySlotFolder.TabIndex = 5;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            label1.Location = new Point(3, 81);
            label1.Name = "label1";
            label1.Size = new Size(232, 30);
            label1.TabIndex = 6;
            label1.Text = "Use process.txt, mem1.txt mem2.txt, mem3.txt:";
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSave.Location = new Point(365, 484);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 38;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(284, 484);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 39;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // optionCut
            // 
            optionCut.AutoSize = true;
            optionCut.Location = new Point(22, 155);
            optionCut.Name = "optionCut";
            optionCut.Size = new Size(216, 19);
            optionCut.TabIndex = 40;
            optionCut.Text = "Cut text (Ctrl+X) when using hotkey";
            optionCut.UseVisualStyleBackColor = true;
            // 
            // optionType
            // 
            optionType.AutoSize = true;
            optionType.Location = new Point(22, 205);
            optionType.Name = "optionType";
            optionType.Size = new Size(250, 19);
            optionType.TabIndex = 41;
            optionType.Text = "Send text as keystrokes when using hotkey";
            optionType.UseVisualStyleBackColor = true;
            optionType.CheckedChanged += OptionType_CheckedChanged;
            // 
            // optionPaste
            // 
            optionPaste.AutoSize = true;
            optionPaste.Location = new Point(22, 180);
            optionPaste.Name = "optionPaste";
            optionPaste.Size = new Size(314, 19);
            optionPaste.TabIndex = 42;
            optionPaste.Text = "Paste text (Ctrl+V) when using hotkey (recommended)";
            optionPaste.UseVisualStyleBackColor = true;
            optionPaste.CheckedChanged += OptionPaste_CheckedChanged;
            // 
            // optionUpdateClipboard
            // 
            optionUpdateClipboard.AutoSize = true;
            optionUpdateClipboard.Location = new Point(22, 230);
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
            HotkeyGrid.Size = new Size(427, 418);
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
            linkLabel1.Location = new Point(11, 488);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(49, 15);
            linkLabel1.TabIndex = 53;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Website";
            linkLabel1.LinkClicked += LinkWebsite;
            // 
            // linkLabel2
            // 
            linkLabel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(66, 488);
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
            buttonSelectSlotFolder.Location = new Point(375, 54);
            buttonSelectSlotFolder.Name = "buttonSelectSlotFolder";
            buttonSelectSlotFolder.Size = new Size(58, 23);
            buttonSelectSlotFolder.TabIndex = 56;
            buttonSelectSlotFolder.Text = "Select";
            buttonSelectSlotFolder.UseVisualStyleBackColor = true;
            buttonSelectSlotFolder.Click += ButtonSelectFolder_Click;
            // 
            // folderBrowserDialog1
            // 
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyDocuments;
            // 
            // buttonSelectHistoryFolder
            // 
            buttonSelectHistoryFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonSelectHistoryFolder.Location = new Point(375, 139);
            buttonSelectHistoryFolder.Name = "buttonSelectHistoryFolder";
            buttonSelectHistoryFolder.Size = new Size(58, 23);
            buttonSelectHistoryFolder.TabIndex = 58;
            buttonSelectHistoryFolder.Text = "Select";
            buttonSelectHistoryFolder.UseVisualStyleBackColor = true;
            buttonSelectHistoryFolder.Click += ButtonSelectHistoryFolder_Click;
            // 
            // textBoxHistory
            // 
            textBoxHistory.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxHistory.Location = new Point(3, 140);
            textBoxHistory.Name = "textBoxHistory";
            textBoxHistory.Size = new Size(366, 23);
            textBoxHistory.TabIndex = 57;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 122);
            label3.Name = "label3";
            label3.Size = new Size(101, 15);
            label3.TabIndex = 59;
            label3.Text = "Text Library folder";
            // 
            // checkBoxHistoryMinimize
            // 
            checkBoxHistoryMinimize.AutoSize = true;
            checkBoxHistoryMinimize.Location = new Point(21, 305);
            checkBoxHistoryMinimize.Name = "checkBoxHistoryMinimize";
            checkBoxHistoryMinimize.Size = new Size(193, 19);
            checkBoxHistoryMinimize.TabIndex = 60;
            checkBoxHistoryMinimize.Text = "Minimize TextLibrary after Copy";
            checkBoxHistoryMinimize.UseVisualStyleBackColor = true;
            // 
            // labelVersion
            // 
            labelVersion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelVersion.AutoSize = true;
            labelVersion.Location = new Point(172, 488);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new Size(45, 15);
            labelVersion.TabIndex = 61;
            labelVersion.Text = "version";
            // 
            // checkBoxTrayCapslock
            // 
            checkBoxTrayCapslock.AutoSize = true;
            checkBoxTrayCapslock.Location = new Point(26, 105);
            checkBoxTrayCapslock.Name = "checkBoxTrayCapslock";
            checkBoxTrayCapslock.Size = new Size(164, 19);
            checkBoxTrayCapslock.TabIndex = 62;
            checkBoxTrayCapslock.Text = "Tray icon Caps Lock status";
            checkBoxTrayCapslock.UseVisualStyleBackColor = true;
            // 
            // textBoxRTFcolors
            // 
            textBoxRTFcolors.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxRTFcolors.Location = new Point(16, 64);
            textBoxRTFcolors.Multiline = true;
            textBoxRTFcolors.Name = "textBoxRTFcolors";
            textBoxRTFcolors.Size = new Size(417, 69);
            textBoxRTFcolors.TabIndex = 63;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 46);
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
            tabControl1.Location = new Point(1, 5);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(448, 480);
            tabControl1.TabIndex = 65;
            // 
            // tabPageGeneral
            // 
            tabPageGeneral.Controls.Add(optionAutoStart);
            tabPageGeneral.Controls.Add(checkBoxMathWarning);
            tabPageGeneral.Controls.Add(label9);
            tabPageGeneral.Controls.Add(label8);
            tabPageGeneral.Controls.Add(label7);
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
            tabPageGeneral.Size = new Size(440, 452);
            tabPageGeneral.TabIndex = 0;
            tabPageGeneral.Text = "General";
            tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // checkBoxMathWarning
            // 
            checkBoxMathWarning.AutoSize = true;
            checkBoxMathWarning.Location = new Point(21, 330);
            checkBoxMathWarning.Name = "checkBoxMathWarning";
            checkBoxMathWarning.Size = new Size(222, 19);
            checkBoxMathWarning.TabIndex = 66;
            checkBoxMathWarning.Text = "$Math equation error popup warning";
            checkBoxMathWarning.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label9.Location = new Point(0, 257);
            label9.Name = "label9";
            label9.Size = new Size(60, 15);
            label9.TabIndex = 65;
            label9.Text = "Functions";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.Location = new Point(3, 132);
            label8.Name = "label8";
            label8.Size = new Size(90, 15);
            label8.TabIndex = 64;
            label8.Text = "Copy and paste";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.Location = new Point(3, 11);
            label7.Name = "label7";
            label7.Size = new Size(88, 15);
            label7.TabIndex = 63;
            label7.Text = "Startup and UI";
            // 
            // tabPageHotkeys
            // 
            tabPageHotkeys.Controls.Add(optionRegisterHotkeys);
            tabPageHotkeys.Controls.Add(HotkeyGrid);
            tabPageHotkeys.Location = new Point(4, 24);
            tabPageHotkeys.Name = "tabPageHotkeys";
            tabPageHotkeys.Padding = new Padding(3);
            tabPageHotkeys.Size = new Size(440, 452);
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
            tabPageSources.Size = new Size(440, 452);
            tabPageSources.TabIndex = 3;
            tabPageSources.Text = "Text sources";
            tabPageSources.UseVisualStyleBackColor = true;
            // 
            // tabPageCustom
            // 
            tabPageCustom.Controls.Add(button1);
            tabPageCustom.Controls.Add(label13);
            tabPageCustom.Controls.Add(label12);
            tabPageCustom.Controls.Add(textBoxCulture);
            tabPageCustom.Controls.Add(label11);
            tabPageCustom.Controls.Add(label2);
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
            tabPageCustom.Size = new Size(440, 452);
            tabPageCustom.TabIndex = 2;
            tabPageCustom.Text = "Custom values";
            tabPageCustom.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(172, 360);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 77;
            button1.Text = "Check";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            label13.Location = new Point(21, 386);
            label13.Name = "label13";
            label13.Size = new Size(301, 15);
            label13.TabIndex = 76;
            label13.Text = "Ex: nb-NO, en-US, en-GB, or blank to use system default";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(21, 342);
            label12.Name = "label12";
            label12.Size = new Size(79, 15);
            label12.TabIndex = 75;
            label12.Text = "Culture name";
            // 
            // textBoxCulture
            // 
            textBoxCulture.Location = new Point(21, 360);
            textBoxCulture.Name = "textBoxCulture";
            textBoxCulture.Size = new Size(145, 23);
            textBoxCulture.TabIndex = 74;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label11.Location = new Point(3, 323);
            label11.Name = "label11";
            label11.Size = new Size(48, 15);
            label11.TabIndex = 73;
            label11.Text = "Culture";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(3, 6);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 72;
            label2.Text = "Rich Text";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            label6.Location = new Point(16, 281);
            label6.Name = "label6";
            label6.Size = new Size(419, 51);
            label6.TabIndex = 71;
            label6.Text = "When Color/Font tables are allowed, pasted text will not use the font or color that's already in the document";
            // 
            // checkBoxRTFfont
            // 
            checkBoxRTFfont.AutoSize = true;
            checkBoxRTFfont.Location = new Point(16, 143);
            checkBoxRTFfont.Name = "checkBoxRTFfont";
            checkBoxRTFfont.Size = new Size(175, 19);
            checkBoxRTFfont.TabIndex = 70;
            checkBoxRTFfont.Text = "Allow Font table in Rich Text";
            checkBoxRTFfont.UseVisualStyleBackColor = true;
            // 
            // checkBoxRTFcolor
            // 
            checkBoxRTFcolor.AutoSize = true;
            checkBoxRTFcolor.Location = new Point(16, 24);
            checkBoxRTFcolor.Name = "checkBoxRTFcolor";
            checkBoxRTFcolor.Size = new Size(180, 19);
            checkBoxRTFcolor.TabIndex = 69;
            checkBoxRTFcolor.Text = "Allow Color table in Rich Text";
            checkBoxRTFcolor.UseVisualStyleBackColor = true;
            // 
            // buttonRTFDefaultFonts
            // 
            buttonRTFDefaultFonts.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonRTFDefaultFonts.Location = new Point(360, 143);
            buttonRTFDefaultFonts.Name = "buttonRTFDefaultFonts";
            buttonRTFDefaultFonts.Size = new Size(75, 23);
            buttonRTFDefaultFonts.TabIndex = 68;
            buttonRTFDefaultFonts.Text = "Default";
            buttonRTFDefaultFonts.UseVisualStyleBackColor = true;
            buttonRTFDefaultFonts.Click += ButtonRTFDefaultFonts_Click;
            // 
            // buttonRTFDefaultColors
            // 
            buttonRTFDefaultColors.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonRTFDefaultColors.Location = new Point(360, 24);
            buttonRTFDefaultColors.Name = "buttonRTFDefaultColors";
            buttonRTFDefaultColors.Size = new Size(75, 23);
            buttonRTFDefaultColors.TabIndex = 67;
            buttonRTFDefaultColors.Text = "Default";
            buttonRTFDefaultColors.UseVisualStyleBackColor = true;
            buttonRTFDefaultColors.Click += ButtonRTFDefaultColors_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 165);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 66;
            label5.Text = "RTF fonts";
            // 
            // textBoxRTFfonts
            // 
            textBoxRTFfonts.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxRTFfonts.Location = new Point(16, 183);
            textBoxRTFfonts.Multiline = true;
            textBoxRTFfonts.Name = "textBoxRTFfonts";
            textBoxRTFfonts.Size = new Size(417, 85);
            textBoxRTFfonts.TabIndex = 65;
            // 
            // optionAutoStart
            // 
            optionAutoStart.AutoSize = true;
            optionAutoStart.Location = new Point(26, 32);
            optionAutoStart.Name = "optionAutoStart";
            optionAutoStart.Size = new Size(253, 19);
            optionAutoStart.TabIndex = 67;
            optionAutoStart.Text = "Automatically start when starting Windows";
            optionAutoStart.UseVisualStyleBackColor = true;
            // 
            // Options
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 514);
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
        private Label label9;
        private Label label8;
        private Label label7;
        private CheckBox checkBoxMathWarning;
        private Label label12;
        private TextBox textBoxCulture;
        private Label label11;
        private Label label2;
        private Label label13;
        private Button button1;
        private CheckBox optionAutoStart;
    }
}