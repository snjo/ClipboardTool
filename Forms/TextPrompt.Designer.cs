namespace ClipboardTool
{
    partial class TextPrompt
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
            components = new System.ComponentModel.Container();
            textBox1 = new TextBox();
            buttonOK = new Button();
            buttonCancel = new Button();
            labelInfo = new Label();
            colorDialog1 = new ColorDialog();
            buttonColorPicker = new Button();
            toolTipIllegal = new ToolTip(components);
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(12, 33);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(309, 23);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += TextBox1_TextChanged;
            textBox1.KeyPress += TextBox_KeyPress;
            // 
            // buttonOK
            // 
            buttonOK.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonOK.Location = new Point(246, 71);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(75, 23);
            buttonOK.TabIndex = 102;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += ButtonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonCancel.Location = new Point(165, 71);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 101;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // labelInfo
            // 
            labelInfo.AutoSize = true;
            labelInfo.Location = new Point(12, 6);
            labelInfo.Name = "labelInfo";
            labelInfo.Size = new Size(38, 15);
            labelInfo.TabIndex = 3;
            labelInfo.Text = "label1";
            // 
            // buttonColorPicker
            // 
            buttonColorPicker.Location = new Point(12, 72);
            buttonColorPicker.Name = "buttonColorPicker";
            buttonColorPicker.Size = new Size(57, 23);
            buttonColorPicker.TabIndex = 100;
            buttonColorPicker.Text = "Color";
            buttonColorPicker.UseVisualStyleBackColor = true;
            buttonColorPicker.Click += ButtonColor_Click;
            // 
            // toolTipIllegal
            // 
            toolTipIllegal.ToolTipTitle = "Illegal Characters";
            // 
            // TextPrompt
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(333, 99);
            Controls.Add(buttonColorPicker);
            Controls.Add(labelInfo);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(textBox1);
            Name = "TextPrompt";
            Text = "Text Prompt";
            Load += TextPrompt_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button buttonOK;
        private Button buttonCancel;
        private Label labelInfo;
        private ColorDialog colorDialog1;
        private Button buttonColorPicker;
        private ToolTip toolTipIllegal;
    }
}