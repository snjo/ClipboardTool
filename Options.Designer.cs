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
            this.optionStartHidden = new System.Windows.Forms.CheckBox();
            this.optionStartToolbar = new System.Windows.Forms.CheckBox();
            this.optionRegisterHotkeys = new System.Windows.Forms.CheckBox();
            this.optionResetCounter = new System.Windows.Forms.CheckBox();
            this.optionSaveMemorySlots = new System.Windows.Forms.CheckBox();
            this.textMemorySlotFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.optionCut = new System.Windows.Forms.CheckBox();
            this.optionType = new System.Windows.Forms.CheckBox();
            this.optionPaste = new System.Windows.Forms.CheckBox();
            this.optionUpdateClipboard = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.HotkeyGrid = new System.Windows.Forms.DataGridView();
            this.Function = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ctrl = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Alt = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Shift = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Win = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.HotkeyGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // optionStartHidden
            // 
            this.optionStartHidden.AutoSize = true;
            this.optionStartHidden.Location = new System.Drawing.Point(12, 12);
            this.optionStartHidden.Name = "optionStartHidden";
            this.optionStartHidden.Size = new System.Drawing.Size(92, 19);
            this.optionStartHidden.TabIndex = 0;
            this.optionStartHidden.Text = "Start Hidden";
            this.optionStartHidden.UseVisualStyleBackColor = true;
            // 
            // optionStartToolbar
            // 
            this.optionStartToolbar.AutoSize = true;
            this.optionStartToolbar.Location = new System.Drawing.Point(12, 37);
            this.optionStartToolbar.Name = "optionStartToolbar";
            this.optionStartToolbar.Size = new System.Drawing.Size(118, 19);
            this.optionStartToolbar.TabIndex = 1;
            this.optionStartToolbar.Text = "Start with Toolbar";
            this.optionStartToolbar.UseVisualStyleBackColor = true;
            // 
            // optionRegisterHotkeys
            // 
            this.optionRegisterHotkeys.AutoSize = true;
            this.optionRegisterHotkeys.Location = new System.Drawing.Point(12, 168);
            this.optionRegisterHotkeys.Name = "optionRegisterHotkeys";
            this.optionRegisterHotkeys.Size = new System.Drawing.Size(112, 19);
            this.optionRegisterHotkeys.TabIndex = 2;
            this.optionRegisterHotkeys.Text = "Register hotkeys";
            this.optionRegisterHotkeys.UseVisualStyleBackColor = true;
            // 
            // optionResetCounter
            // 
            this.optionResetCounter.AutoSize = true;
            this.optionResetCounter.Location = new System.Drawing.Point(261, 12);
            this.optionResetCounter.Name = "optionResetCounter";
            this.optionResetCounter.Size = new System.Drawing.Size(252, 19);
            this.optionResetCounter.TabIndex = 3;
            this.optionResetCounter.Text = "Reset number when updating memory slot";
            this.optionResetCounter.UseVisualStyleBackColor = true;
            // 
            // optionSaveMemorySlots
            // 
            this.optionSaveMemorySlots.AutoSize = true;
            this.optionSaveMemorySlots.Location = new System.Drawing.Point(261, 37);
            this.optionSaveMemorySlots.Name = "optionSaveMemorySlots";
            this.optionSaveMemorySlots.Size = new System.Drawing.Size(158, 19);
            this.optionSaveMemorySlots.TabIndex = 4;
            this.optionSaveMemorySlots.Text = "Save memory slots to file";
            this.optionSaveMemorySlots.UseVisualStyleBackColor = true;
            // 
            // textMemorySlotFolder
            // 
            this.textMemorySlotFolder.Location = new System.Drawing.Point(261, 104);
            this.textMemorySlotFolder.Name = "textMemorySlotFolder";
            this.textMemorySlotFolder.Size = new System.Drawing.Size(229, 23);
            this.textMemorySlotFolder.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(261, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 30);
            this.label1.TabIndex = 6;
            this.label1.Text = ".txt file folder. Use process.txt, mem1.txt mem2.txt, mem3.txt:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(257, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Restart the program to register new hotkeys";
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(433, 524);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 38;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(352, 524);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 39;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // optionCut
            // 
            this.optionCut.AutoSize = true;
            this.optionCut.Location = new System.Drawing.Point(12, 63);
            this.optionCut.Name = "optionCut";
            this.optionCut.Size = new System.Drawing.Size(163, 19);
            this.optionCut.TabIndex = 40;
            this.optionCut.Text = "Ctrl+X when using hotkey";
            this.optionCut.UseVisualStyleBackColor = true;
            // 
            // optionType
            // 
            this.optionType.AutoSize = true;
            this.optionType.Location = new System.Drawing.Point(12, 110);
            this.optionType.Name = "optionType";
            this.optionType.Size = new System.Drawing.Size(181, 19);
            this.optionType.TabIndex = 41;
            this.optionType.Text = "Send keys when using hotkey";
            this.optionType.UseVisualStyleBackColor = true;
            // 
            // optionPaste
            // 
            this.optionPaste.AutoSize = true;
            this.optionPaste.Location = new System.Drawing.Point(12, 88);
            this.optionPaste.Name = "optionPaste";
            this.optionPaste.Size = new System.Drawing.Size(163, 19);
            this.optionPaste.TabIndex = 42;
            this.optionPaste.Text = "Ctrl+V when using hotkey";
            this.optionPaste.UseVisualStyleBackColor = true;
            // 
            // optionUpdateClipboard
            // 
            this.optionUpdateClipboard.AutoSize = true;
            this.optionUpdateClipboard.Location = new System.Drawing.Point(12, 135);
            this.optionUpdateClipboard.Name = "optionUpdateClipboard";
            this.optionUpdateClipboard.Size = new System.Drawing.Size(237, 19);
            this.optionUpdateClipboard.TabIndex = 44;
            this.optionUpdateClipboard.Text = "Update clipboard when using Send Keys";
            this.optionUpdateClipboard.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(25, 205);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(279, 15);
            this.label9.TabIndex = 51;
            this.label9.Text = "Tap 1-3 times for Date/Time while holding Modifiers";
            // 
            // HotkeyGrid
            // 
            this.HotkeyGrid.AllowUserToAddRows = false;
            this.HotkeyGrid.AllowUserToDeleteRows = false;
            this.HotkeyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HotkeyGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.HotkeyGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HotkeyGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Function,
            this.Key,
            this.Ctrl,
            this.Alt,
            this.Shift,
            this.Win});
            this.HotkeyGrid.Location = new System.Drawing.Point(12, 223);
            this.HotkeyGrid.Name = "HotkeyGrid";
            this.HotkeyGrid.RowHeadersVisible = false;
            this.HotkeyGrid.RowTemplate.Height = 25;
            this.HotkeyGrid.Size = new System.Drawing.Size(494, 295);
            this.HotkeyGrid.TabIndex = 52;
            // 
            // Function
            // 
            this.Function.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Function.HeaderText = "Function";
            this.Function.Name = "Function";
            this.Function.ReadOnly = true;
            this.Function.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Key
            // 
            this.Key.HeaderText = "Key";
            this.Key.Name = "Key";
            this.Key.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Ctrl
            // 
            this.Ctrl.HeaderText = "Ctrl";
            this.Ctrl.Name = "Ctrl";
            this.Ctrl.Width = 50;
            // 
            // Alt
            // 
            this.Alt.HeaderText = "Alt";
            this.Alt.Name = "Alt";
            this.Alt.Width = 50;
            // 
            // Shift
            // 
            this.Shift.HeaderText = "Shift";
            this.Shift.Name = "Shift";
            this.Shift.Width = 50;
            // 
            // Win
            // 
            this.Win.HeaderText = "Win";
            this.Win.Name = "Win";
            this.Win.Width = 50;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(11, 528);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(49, 15);
            this.linkLabel1.TabIndex = 53;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Website";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkWebsite);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(66, 528);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(100, 15);
            this.linkLabel2.TabIndex = 54;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "user.config folder";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkSettings);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 554);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.HotkeyGrid);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.optionUpdateClipboard);
            this.Controls.Add(this.optionPaste);
            this.Controls.Add(this.optionType);
            this.Controls.Add(this.optionCut);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textMemorySlotFolder);
            this.Controls.Add(this.optionSaveMemorySlots);
            this.Controls.Add(this.optionResetCounter);
            this.Controls.Add(this.optionRegisterHotkeys);
            this.Controls.Add(this.optionStartToolbar);
            this.Controls.Add(this.optionStartHidden);
            this.Name = "Options";
            this.Text = "Options";
            ((System.ComponentModel.ISupportInitialize)(this.HotkeyGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private CheckBox optionUpdateClipboard;
        private CheckBox checkDateWin;
        private CheckBox checkDateShift;
        private CheckBox checkDateAlt;
        private CheckBox checkDateCtrl;
        private TextBox textHotkeyDate;
        private Label label8;
        private Label label9;
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
    }
}