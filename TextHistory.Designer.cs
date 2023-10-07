﻿namespace ClipboardTool
{
    partial class TextHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextHistory));
            gridHistory = new DataGridView();
            ColumnPinned = new DataGridViewCheckBoxColumn();
            ColumnTitle = new DataGridViewTextBoxColumn();
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnLoad = new DataGridViewButtonColumn();
            buttonAddFromClipboard = new Button();
            button1 = new Button();
            checkBoxMinimize = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)gridHistory).BeginInit();
            SuspendLayout();
            // 
            // gridHistory
            // 
            gridHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridHistory.Columns.AddRange(new DataGridViewColumn[] { ColumnPinned, ColumnTitle, ColumnText, ColumnLoad });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gridHistory.DefaultCellStyle = dataGridViewCellStyle1;
            gridHistory.Location = new Point(4, 32);
            gridHistory.MultiSelect = false;
            gridHistory.Name = "gridHistory";
            gridHistory.RowTemplate.Height = 50;
            gridHistory.Size = new Size(518, 582);
            gridHistory.TabIndex = 3;
            gridHistory.CellClick += gridHistory_CellClick;
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
            // ColumnLoad
            // 
            ColumnLoad.HeaderText = "Load";
            ColumnLoad.Name = "ColumnLoad";
            ColumnLoad.Text = ">";
            ColumnLoad.UseColumnTextForButtonValue = true;
            ColumnLoad.Width = 50;
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
            buttonAddFromClipboard.Click += buttonAddFromClipboard_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(443, 4);
            button1.Name = "button1";
            button1.Size = new Size(28, 23);
            button1.TabIndex = 5;
            button1.Text = "📌";
            button1.UseVisualStyleBackColor = true;
            button1.Click += actionAlwaysOnTop;
            // 
            // checkBoxMinimize
            // 
            checkBoxMinimize.AutoSize = true;
            checkBoxMinimize.Location = new Point(4, 7);
            checkBoxMinimize.Name = "checkBoxMinimize";
            checkBoxMinimize.Size = new Size(180, 19);
            checkBoxMinimize.TabIndex = 6;
            checkBoxMinimize.Text = "Minimize when clicking Load";
            checkBoxMinimize.UseVisualStyleBackColor = true;
            // 
            // TextHistory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(525, 618);
            Controls.Add(checkBoxMinimize);
            Controls.Add(button1);
            Controls.Add(buttonAddFromClipboard);
            Controls.Add(gridHistory);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "TextHistory";
            Text = "ClipboardHistory";
            ((System.ComponentModel.ISupportInitialize)gridHistory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView gridHistory;
        private Button buttonAddFromClipboard;
        private Button button1;
        private DataGridViewCheckBoxColumn ColumnPinned;
        private DataGridViewTextBoxColumn ColumnTitle;
        private DataGridViewTextBoxColumn ColumnText;
        private DataGridViewButtonColumn ColumnLoad;
        private CheckBox checkBoxMinimize;
    }
}