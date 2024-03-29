﻿namespace ClipboardTool
{
    partial class TextLibrary
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextLibrary));
            gridTextLibrary = new DataGridView();
            ColumnPinned = new DataGridViewCheckBoxColumn();
            ColumnTitle = new DataGridViewTextBoxColumn();
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnCopy = new DataGridViewButtonColumn();
            buttonAddFromClipboard = new Button();
            button1 = new Button();
            checkBoxMinimize = new CheckBox();
            colorDialog1 = new ColorDialog();
            buttonColor = new Button();
            linkLabelHistoryFolder = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)gridTextLibrary).BeginInit();
            SuspendLayout();
            // 
            // gridHistory
            // 
            gridTextLibrary.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridTextLibrary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridTextLibrary.Columns.AddRange(new DataGridViewColumn[] { ColumnPinned, ColumnTitle, ColumnText, ColumnCopy });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gridTextLibrary.DefaultCellStyle = dataGridViewCellStyle1;
            gridTextLibrary.Location = new Point(4, 32);
            gridTextLibrary.MultiSelect = false;
            gridTextLibrary.Name = "gridHistory";
            gridTextLibrary.RowHeadersVisible = false;
            gridTextLibrary.RowHeadersWidth = 20;
            gridTextLibrary.RowTemplate.Height = 50;
            gridTextLibrary.Size = new Size(518, 487);
            gridTextLibrary.TabIndex = 3;
            gridTextLibrary.CellClick += GridTextLibrary_CellClick;
            gridTextLibrary.CellEndEdit += GridTextLibrary_CellEndEdit;
            gridTextLibrary.MouseDoubleClick += GridTextLibrary_MouseDoubleClick;
            // 
            // ColumnPinned
            // 
            ColumnPinned.HeaderText = "📌";
            ColumnPinned.Name = "ColumnPinned";
            ColumnPinned.ReadOnly = true;
            ColumnPinned.Width = 30;
            // 
            // ColumnTitle
            // 
            ColumnTitle.HeaderText = "Title";
            ColumnTitle.Name = "ColumnTitle";
            ColumnTitle.ReadOnly = true;
            // 
            // ColumnText
            // 
            ColumnText.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnText.HeaderText = "Text";
            ColumnText.Name = "ColumnText";
            // 
            // ColumnCopy
            // 
            ColumnCopy.HeaderText = "Copy";
            ColumnCopy.Name = "ColumnCopy";
            ColumnCopy.Text = ">";
            ColumnCopy.UseColumnTextForButtonValue = true;
            ColumnCopy.Width = 50;
            // 
            // buttonAddFromClipboard
            // 
            buttonAddFromClipboard.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonAddFromClipboard.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            buttonAddFromClipboard.Location = new Point(477, 4);
            buttonAddFromClipboard.Name = "buttonAddFromClipboard";
            buttonAddFromClipboard.Size = new Size(45, 23);
            buttonAddFromClipboard.TabIndex = 4;
            buttonAddFromClipboard.Text = "Add";
            buttonAddFromClipboard.UseVisualStyleBackColor = true;
            buttonAddFromClipboard.Click += ButtonAddFromClipboard_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(362, 3);
            button1.Name = "button1";
            button1.Size = new Size(28, 23);
            button1.TabIndex = 5;
            button1.Text = "📌";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ActionAlwaysOnTop;
            // 
            // checkBoxMinimize
            // 
            checkBoxMinimize.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            checkBoxMinimize.AutoSize = true;
            checkBoxMinimize.Location = new Point(340, 523);
            checkBoxMinimize.Name = "checkBoxMinimize";
            checkBoxMinimize.Size = new Size(182, 19);
            checkBoxMinimize.TabIndex = 6;
            checkBoxMinimize.Text = "Minimize when clicking Copy";
            checkBoxMinimize.UseVisualStyleBackColor = true;
            checkBoxMinimize.CheckedChanged += CheckBoxMinimize_CheckedChanged;
            // 
            // buttonColor
            // 
            buttonColor.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonColor.Location = new Point(396, 3);
            buttonColor.Name = "buttonColor";
            buttonColor.Size = new Size(75, 23);
            buttonColor.TabIndex = 7;
            buttonColor.Text = "Color";
            buttonColor.UseVisualStyleBackColor = true;
            buttonColor.Click += ButtonColor_Click;
            // 
            // linkLabelHistoryFolder
            // 
            linkLabelHistoryFolder.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            linkLabelHistoryFolder.AutoSize = true;
            linkLabelHistoryFolder.Location = new Point(4, 524);
            linkLabelHistoryFolder.Name = "linkLabelHistoryFolder";
            linkLabelHistoryFolder.Size = new Size(103, 15);
            linkLabelHistoryFolder.TabIndex = 8;
            linkLabelHistoryFolder.TabStop = true;
            linkLabelHistoryFolder.Text = "Text Library Folder";
            linkLabelHistoryFolder.LinkClicked += OpenTextLibraryFolder;
            // 
            // TextLibrary
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(525, 545);
            Controls.Add(linkLabelHistoryFolder);
            Controls.Add(buttonColor);
            Controls.Add(checkBoxMinimize);
            Controls.Add(button1);
            Controls.Add(buttonAddFromClipboard);
            Controls.Add(gridTextLibrary);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "TextLibrary";
            Text = "Text Library";
            ((System.ComponentModel.ISupportInitialize)gridTextLibrary).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView gridTextLibrary;
        private Button buttonAddFromClipboard;
        private Button button1;
        private CheckBox checkBoxMinimize;
        private ColorDialog colorDialog1;
        private Button buttonColor;
        private DataGridViewCheckBoxColumn ColumnPinned;
        private DataGridViewTextBoxColumn ColumnTitle;
        private DataGridViewTextBoxColumn ColumnText;
        private DataGridViewButtonColumn ColumnCopy;
        private LinkLabel linkLabelHistoryFolder;
    }
}