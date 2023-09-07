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
            HistoryEnabled = new CheckBox();
            NumberOfAutosaves = new NumericUpDown();
            labelAutosaveNumber = new Label();
            dataGridHistory = new DataGridView();
            ColumnPinned = new DataGridViewCheckBoxColumn();
            ColumnText = new DataGridViewTextBoxColumn();
            ColumnDelete = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)NumberOfAutosaves).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridHistory).BeginInit();
            SuspendLayout();
            // 
            // HistoryEnabled
            // 
            HistoryEnabled.AutoSize = true;
            HistoryEnabled.Location = new Point(4, 4);
            HistoryEnabled.Name = "HistoryEnabled";
            HistoryEnabled.Size = new Size(137, 19);
            HistoryEnabled.TabIndex = 0;
            HistoryEnabled.Text = "Use clipboard history";
            HistoryEnabled.UseVisualStyleBackColor = true;
            // 
            // NumberOfAutosaves
            // 
            NumberOfAutosaves.Location = new Point(168, 3);
            NumberOfAutosaves.Name = "NumberOfAutosaves";
            NumberOfAutosaves.Size = new Size(51, 23);
            NumberOfAutosaves.TabIndex = 1;
            NumberOfAutosaves.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // labelAutosaveNumber
            // 
            labelAutosaveNumber.AutoSize = true;
            labelAutosaveNumber.Location = new Point(225, 5);
            labelAutosaveNumber.Name = "labelAutosaveNumber";
            labelAutosaveNumber.Size = new Size(106, 15);
            labelAutosaveNumber.TabIndex = 2;
            labelAutosaveNumber.Text = "Entries to autosave";
            // 
            // dataGridHistory
            // 
            dataGridHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridHistory.Columns.AddRange(new DataGridViewColumn[] { ColumnPinned, ColumnText, ColumnDelete });
            dataGridHistory.Location = new Point(4, 32);
            dataGridHistory.Name = "dataGridHistory";
            dataGridHistory.RowHeadersVisible = false;
            dataGridHistory.RowTemplate.Height = 25;
            dataGridHistory.Size = new Size(519, 582);
            dataGridHistory.TabIndex = 3;
            // 
            // ColumnPinned
            // 
            ColumnPinned.HeaderText = "📌";
            ColumnPinned.Name = "ColumnPinned";
            ColumnPinned.Width = 30;
            // 
            // ColumnText
            // 
            ColumnText.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnText.HeaderText = "Text";
            ColumnText.Name = "ColumnText";
            // 
            // ColumnDelete
            // 
            ColumnDelete.HeaderText = "Delete";
            ColumnDelete.Name = "ColumnDelete";
            ColumnDelete.Text = "Delete";
            ColumnDelete.Width = 50;
            // 
            // ClipboardHistory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(526, 618);
            Controls.Add(dataGridHistory);
            Controls.Add(labelAutosaveNumber);
            Controls.Add(NumberOfAutosaves);
            Controls.Add(HistoryEnabled);
            Name = "ClipboardHistory";
            Text = "ClipboardHistory";
            ((System.ComponentModel.ISupportInitialize)NumberOfAutosaves).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridHistory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox HistoryEnabled;
        private NumericUpDown NumberOfAutosaves;
        private Label labelAutosaveNumber;
        private DataGridView dataGridHistory;
        private DataGridViewCheckBoxColumn ColumnPinned;
        private DataGridViewTextBoxColumn ColumnText;
        private DataGridViewButtonColumn ColumnDelete;
    }
}