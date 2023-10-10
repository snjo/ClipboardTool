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
            ((System.ComponentModel.ISupportInitialize)HotkeyGrid).BeginInit();
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
            optionResetCounter.Location = new Point(261, 12);
            optionResetCounter.Name = "optionResetCounter";
            optionResetCounter.Size = new Size(252, 19);
            optionResetCounter.TabIndex = 3;
            optionResetCounter.Text = "Reset number when updating memory slot";
            optionResetCounter.UseVisualStyleBackColor = true;
            // 
            // optionSaveMemorySlots
            // 
            optionSaveMemorySlots.AutoSize = true;
            optionSaveMemorySlots.Location = new Point(261, 37);
            optionSaveMemorySlots.Name = "optionSaveMemorySlots";
            optionSaveMemorySlots.Size = new Size(158, 19);
            optionSaveMemorySlots.TabIndex = 4;
            optionSaveMemorySlots.Text = "Save memory slots to file";
            optionSaveMemorySlots.UseVisualStyleBackColor = true;
            // 
            // textMemorySlotFolder
            // 
            textMemorySlotFolder.Location = new Point(261, 87);
            textMemorySlotFolder.Name = "textMemorySlotFolder";
            textMemorySlotFolder.Size = new Size(181, 23);
            textMemorySlotFolder.TabIndex = 5;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(261, 113);
            label1.Name = "label1";
            label1.Size = new Size(232, 30);
            label1.TabIndex = 6;
            label1.Text = "Use process.txt, mem1.txt mem2.txt, mem3.txt:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(12, 190);
            label2.Name = "label2";
            label2.Size = new Size(230, 15);
            label2.TabIndex = 7;
            label2.Text = "Restart the program to register hotkeys";
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSave.Location = new Point(433, 524);
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
            buttonCancel.Location = new Point(352, 524);
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
            // HotkeyGrid
            // 
            HotkeyGrid.AllowUserToAddRows = false;
            HotkeyGrid.AllowUserToDeleteRows = false;
            HotkeyGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            HotkeyGrid.BackgroundColor = SystemColors.Window;
            HotkeyGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            HotkeyGrid.Columns.AddRange(new DataGridViewColumn[] { Function, Key, Ctrl, Alt, Shift, Win });
            HotkeyGrid.Location = new Point(12, 241);
            HotkeyGrid.Name = "HotkeyGrid";
            HotkeyGrid.RowHeadersVisible = false;
            HotkeyGrid.RowTemplate.Height = 25;
            HotkeyGrid.Size = new Size(494, 277);
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
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(11, 528);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(49, 15);
            linkLabel1.TabIndex = 53;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Website";
            linkLabel1.LinkClicked += linkWebsite;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(66, 528);
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
            label10.Location = new Point(261, 69);
            label10.Name = "label10";
            label10.Size = new Size(100, 15);
            label10.TabIndex = 55;
            label10.Text = "Slot .txt file folder";
            // 
            // buttonSelectSlotFolder
            // 
            buttonSelectSlotFolder.Location = new Point(448, 87);
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
            buttonSelectHistoryFolder.Location = new Point(448, 172);
            buttonSelectHistoryFolder.Name = "buttonSelectHistoryFolder";
            buttonSelectHistoryFolder.Size = new Size(58, 23);
            buttonSelectHistoryFolder.TabIndex = 58;
            buttonSelectHistoryFolder.Text = "Select";
            buttonSelectHistoryFolder.UseVisualStyleBackColor = true;
            buttonSelectHistoryFolder.Click += buttonSelectHistoryFolder_Click;
            // 
            // textBoxHistory
            // 
            textBoxHistory.Location = new Point(261, 172);
            textBoxHistory.Name = "textBoxHistory";
            textBoxHistory.Size = new Size(181, 23);
            textBoxHistory.TabIndex = 57;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(261, 154);
            label3.Name = "label3";
            label3.Size = new Size(79, 15);
            label3.TabIndex = 59;
            label3.Text = "History folder";
            // 
            // checkBoxHistoryMinimize
            // 
            checkBoxHistoryMinimize.AutoSize = true;
            checkBoxHistoryMinimize.Location = new Point(261, 201);
            checkBoxHistoryMinimize.Name = "checkBoxHistoryMinimize";
            checkBoxHistoryMinimize.Size = new Size(174, 19);
            checkBoxHistoryMinimize.TabIndex = 60;
            checkBoxHistoryMinimize.Text = "Minimize History after Copy";
            checkBoxHistoryMinimize.UseVisualStyleBackColor = true;
            // 
            // Options
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(518, 554);
            Controls.Add(checkBoxHistoryMinimize);
            Controls.Add(label3);
            Controls.Add(buttonSelectHistoryFolder);
            Controls.Add(textBoxHistory);
            Controls.Add(buttonSelectSlotFolder);
            Controls.Add(label10);
            Controls.Add(linkLabel2);
            Controls.Add(linkLabel1);
            Controls.Add(HotkeyGrid);
            Controls.Add(optionUpdateClipboard);
            Controls.Add(optionPaste);
            Controls.Add(optionType);
            Controls.Add(optionCut);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
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
            ((System.ComponentModel.ISupportInitialize)HotkeyGrid).EndInit();
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
    }
}