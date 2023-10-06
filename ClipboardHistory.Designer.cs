namespace ClipboardTool
{
    partial class ClipboardHistory
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
            HistoryEnabled = new CheckBox();
            NumberOfAutosaves = new NumericUpDown();
            labelAutosaveNumber = new Label();
            gridHistory = new DataGridView();
            buttonAddFromClipboard = new Button();
            button1 = new Button();
            ColumnPinned = new DataGridViewCheckBoxColumn();
            ColumnTitle = new DataGridViewTextBoxColumn();
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnLoad = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)NumberOfAutosaves).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridHistory).BeginInit();
            SuspendLayout();
            // 
            // HistoryEnabled
            // 
            HistoryEnabled.AutoSize = true;
            HistoryEnabled.Enabled = false;
            HistoryEnabled.Location = new Point(4, 4);
            HistoryEnabled.Name = "HistoryEnabled";
            HistoryEnabled.Size = new Size(137, 19);
            HistoryEnabled.TabIndex = 0;
            HistoryEnabled.Text = "Use clipboard history";
            HistoryEnabled.UseVisualStyleBackColor = true;
            // 
            // NumberOfAutosaves
            // 
            NumberOfAutosaves.Enabled = false;
            NumberOfAutosaves.Location = new Point(168, 3);
            NumberOfAutosaves.Name = "NumberOfAutosaves";
            NumberOfAutosaves.Size = new Size(51, 23);
            NumberOfAutosaves.TabIndex = 1;
            NumberOfAutosaves.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // labelAutosaveNumber
            // 
            labelAutosaveNumber.AutoSize = true;
            labelAutosaveNumber.Enabled = false;
            labelAutosaveNumber.Location = new Point(225, 5);
            labelAutosaveNumber.Name = "labelAutosaveNumber";
            labelAutosaveNumber.Size = new Size(106, 15);
            labelAutosaveNumber.TabIndex = 2;
            labelAutosaveNumber.Text = "Entries to autosave";
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
            gridHistory.Size = new Size(519, 582);
            gridHistory.TabIndex = 3;
            gridHistory.CellClick += gridHistory_CellClick;
            // 
            // buttonAddFromClipboard
            // 
            buttonAddFromClipboard.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonAddFromClipboard.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            buttonAddFromClipboard.Location = new Point(478, 4);
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
            button1.Location = new Point(444, 4);
            button1.Name = "button1";
            button1.Size = new Size(28, 23);
            button1.TabIndex = 5;
            button1.Text = "📌";
            button1.UseVisualStyleBackColor = true;
            button1.Click += actionAlwaysOnTop;
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
            // ClipboardHistory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(526, 618);
            Controls.Add(button1);
            Controls.Add(buttonAddFromClipboard);
            Controls.Add(gridHistory);
            Controls.Add(labelAutosaveNumber);
            Controls.Add(NumberOfAutosaves);
            Controls.Add(HistoryEnabled);
            Name = "ClipboardHistory";
            Text = "ClipboardHistory";
            ((System.ComponentModel.ISupportInitialize)NumberOfAutosaves).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridHistory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox HistoryEnabled;
        private NumericUpDown NumberOfAutosaves;
        private Label labelAutosaveNumber;
        private DataGridView gridHistory;
        private Button buttonAddFromClipboard;
        private Button button1;
        private DataGridViewCheckBoxColumn ColumnPinned;
        private DataGridViewTextBoxColumn ColumnTitle;
        private DataGridViewTextBoxColumn ColumnText;
        private DataGridViewButtonColumn ColumnLoad;
    }
}