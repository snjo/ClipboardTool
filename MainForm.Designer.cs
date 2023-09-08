namespace ClipboardTool
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            buttonLower = new Button();
            button2 = new Button();
            button3 = new Button();
            labelLower = new Label();
            labelUpper = new Label();
            labelPlain = new Label();
            labelCaps = new Label();
            checkBoxCapsLock = new CheckBox();
            buttonOptions = new Button();
            buttonPin = new Button();
            buttonHide = new Button();
            buttonToolbar = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            numericUpDown1 = new NumericUpDown();
            labelProcess = new Label();
            buttonProcess = new Button();
            textCustom = new TextBox();
            label1 = new Label();
            textBox1 = new TextBox();
            buttonSave1 = new Button();
            buttonLoad1 = new Button();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            timerStatus = new System.Windows.Forms.Timer(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            hideToolStripMenuItem = new ToolStripMenuItem();
            showToolStripMenuItem = new ToolStripMenuItem();
            capsLockToolStripMenuItem = new ToolStripMenuItem();
            uPPERCaseClipboardToolStripMenuItem = new ToolStripMenuItem();
            lowerCaseClipboardToolStripMenuItem = new ToolStripMenuItem();
            plainTextClipboardToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            notifyIcon1 = new NotifyIcon(components);
            systrayIcon = new NotifyIcon(components);
            toolTip = new ToolTip(components);
            buttonHelp = new Button();
            buttonSaveCustom = new Button();
            timerKeystrokes = new System.Windows.Forms.Timer(components);
            splitContainer1 = new SplitContainer();
            button7 = new Button();
            splitContainer2 = new SplitContainer();
            button1 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button8 = new Button();
            button9 = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            SuspendLayout();
            // 
            // buttonLower
            // 
            buttonLower.Location = new Point(5, 41);
            buttonLower.Name = "buttonLower";
            buttonLower.Size = new Size(75, 23);
            buttonLower.TabIndex = 20;
            buttonLower.Text = "lower";
            buttonLower.UseVisualStyleBackColor = true;
            buttonLower.Click += actionLowerCaseOnce;
            // 
            // button2
            // 
            button2.Location = new Point(5, 66);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 21;
            button2.Text = "UPPER";
            button2.UseVisualStyleBackColor = true;
            button2.Click += actionUpperCaseOnce;
            // 
            // button3
            // 
            button3.Location = new Point(5, 91);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 22;
            button3.Text = "Plain";
            button3.UseVisualStyleBackColor = true;
            button3.Click += actionPlainTextOnce;
            // 
            // labelLower
            // 
            labelLower.AutoSize = true;
            labelLower.Location = new Point(90, 45);
            labelLower.Name = "labelLower";
            labelLower.Size = new Size(60, 15);
            labelLower.TabIndex = 3;
            labelLower.Text = "no hotkey";
            // 
            // labelUpper
            // 
            labelUpper.AutoSize = true;
            labelUpper.Location = new Point(90, 70);
            labelUpper.Name = "labelUpper";
            labelUpper.Size = new Size(60, 15);
            labelUpper.TabIndex = 4;
            labelUpper.Text = "no hotkey";
            // 
            // labelPlain
            // 
            labelPlain.AutoSize = true;
            labelPlain.Location = new Point(90, 95);
            labelPlain.Name = "labelPlain";
            labelPlain.Size = new Size(60, 15);
            labelPlain.TabIndex = 5;
            labelPlain.Text = "no hotkey";
            // 
            // labelCaps
            // 
            labelCaps.AutoSize = true;
            labelCaps.Location = new Point(90, 122);
            labelCaps.Name = "labelCaps";
            labelCaps.Size = new Size(60, 15);
            labelCaps.TabIndex = 6;
            labelCaps.Text = "no hotkey";
            // 
            // checkBoxCapsLock
            // 
            checkBoxCapsLock.AutoSize = true;
            checkBoxCapsLock.Location = new Point(8, 121);
            checkBoxCapsLock.Name = "checkBoxCapsLock";
            checkBoxCapsLock.Size = new Size(80, 19);
            checkBoxCapsLock.TabIndex = 23;
            checkBoxCapsLock.Text = "Caps Lock";
            checkBoxCapsLock.UseVisualStyleBackColor = true;
            checkBoxCapsLock.Click += actionCapsLock;
            // 
            // buttonOptions
            // 
            buttonOptions.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonOptions.Location = new Point(330, 5);
            buttonOptions.Name = "buttonOptions";
            buttonOptions.Size = new Size(23, 23);
            buttonOptions.TabIndex = 13;
            buttonOptions.Text = "⚙️";
            buttonOptions.UseVisualStyleBackColor = true;
            buttonOptions.Click += actionShowOptions;
            buttonOptions.MouseHover += showTooltipSettings;
            // 
            // buttonPin
            // 
            buttonPin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonPin.Location = new Point(306, 5);
            buttonPin.Name = "buttonPin";
            buttonPin.Size = new Size(23, 23);
            buttonPin.TabIndex = 12;
            buttonPin.Text = "📌";
            buttonPin.UseVisualStyleBackColor = true;
            buttonPin.Click += actionAlwaysOnTop;
            buttonPin.MouseHover += showTooltipPin;
            // 
            // buttonHide
            // 
            buttonHide.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonHide.Location = new Point(282, 5);
            buttonHide.Name = "buttonHide";
            buttonHide.Size = new Size(23, 23);
            buttonHide.TabIndex = 11;
            buttonHide.Text = "👻";
            buttonHide.UseVisualStyleBackColor = true;
            buttonHide.Click += actionHideFromTaskbar;
            buttonHide.MouseHover += showToolTipHide;
            // 
            // buttonToolbar
            // 
            buttonToolbar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonToolbar.Location = new Point(209, 5);
            buttonToolbar.Name = "buttonToolbar";
            buttonToolbar.Size = new Size(72, 23);
            buttonToolbar.TabIndex = 10;
            buttonToolbar.Text = "toolbar";
            buttonToolbar.UseVisualStyleBackColor = true;
            buttonToolbar.Click += actionShowToolbar;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(8, 34);
            panel1.Name = "panel1";
            panel1.Size = new Size(347, 1);
            panel1.TabIndex = 12;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Location = new Point(7, 146);
            panel2.Name = "panel2";
            panel2.Size = new Size(347, 1);
            panel2.TabIndex = 13;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericUpDown1.Location = new Point(286, 155);
            numericUpDown1.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(67, 23);
            numericUpDown1.TabIndex = 31;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // labelProcess
            // 
            labelProcess.AutoSize = true;
            labelProcess.Location = new Point(90, 159);
            labelProcess.Name = "labelProcess";
            labelProcess.Size = new Size(60, 15);
            labelProcess.TabIndex = 15;
            labelProcess.Text = "no hotkey";
            // 
            // buttonProcess
            // 
            buttonProcess.Location = new Point(9, 156);
            buttonProcess.Name = "buttonProcess";
            buttonProcess.Size = new Size(75, 23);
            buttonProcess.TabIndex = 30;
            buttonProcess.Text = "Process";
            buttonProcess.UseVisualStyleBackColor = true;
            buttonProcess.Click += actionProcessText;
            // 
            // textCustom
            // 
            textCustom.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textCustom.Location = new Point(8, 188);
            textCustom.Multiline = true;
            textCustom.Name = "textCustom";
            textCustom.ScrollBars = ScrollBars.Vertical;
            textCustom.Size = new Size(314, 92);
            textCustom.TabIndex = 32;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 291);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 18;
            label1.Text = "Memory slots";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(0, 3);
            textBox1.MinimumSize = new Size(0, 23);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(272, 38);
            textBox1.TabIndex = 40;
            // 
            // buttonSave1
            // 
            buttonSave1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonSave1.Location = new Point(302, 2);
            buttonSave1.Name = "buttonSave1";
            buttonSave1.Size = new Size(23, 23);
            buttonSave1.TabIndex = 42;
            buttonSave1.Tag = "1";
            buttonSave1.Text = "▽";
            buttonSave1.UseVisualStyleBackColor = true;
            buttonSave1.Click += actionSave;
            buttonSave1.MouseHover += showToolTipMemSave;
            // 
            // buttonLoad1
            // 
            buttonLoad1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonLoad1.Location = new Point(326, 2);
            buttonLoad1.Name = "buttonLoad1";
            buttonLoad1.Size = new Size(23, 23);
            buttonLoad1.TabIndex = 43;
            buttonLoad1.Tag = "1";
            buttonLoad1.Text = "△";
            buttonLoad1.UseVisualStyleBackColor = true;
            buttonLoad1.Click += actionLoad;
            buttonLoad1.MouseHover += showToolTipMemLoad;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox2.Location = new Point(0, 3);
            textBox2.MinimumSize = new Size(0, 23);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ScrollBars = ScrollBars.Vertical;
            textBox2.Size = new Size(272, 36);
            textBox2.TabIndex = 50;
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox3.Location = new Point(0, 3);
            textBox3.MinimumSize = new Size(0, 23);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.ScrollBars = ScrollBars.Vertical;
            textBox3.Size = new Size(272, 40);
            textBox3.TabIndex = 60;
            // 
            // timerStatus
            // 
            timerStatus.Enabled = true;
            timerStatus.Interval = 500;
            timerStatus.Tick += timerStatus_Tick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { hideToolStripMenuItem, showToolStripMenuItem, capsLockToolStripMenuItem, uPPERCaseClipboardToolStripMenuItem, lowerCaseClipboardToolStripMenuItem, plainTextClipboardToolStripMenuItem, exitToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(189, 158);
            // 
            // hideToolStripMenuItem
            // 
            hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            hideToolStripMenuItem.Size = new Size(188, 22);
            hideToolStripMenuItem.Text = "Hide";
            hideToolStripMenuItem.Click += actionHideFromTaskbar;
            // 
            // showToolStripMenuItem
            // 
            showToolStripMenuItem.Name = "showToolStripMenuItem";
            showToolStripMenuItem.Size = new Size(188, 22);
            showToolStripMenuItem.Text = "Show";
            showToolStripMenuItem.Click += actionShowWindow;
            // 
            // capsLockToolStripMenuItem
            // 
            capsLockToolStripMenuItem.Name = "capsLockToolStripMenuItem";
            capsLockToolStripMenuItem.Size = new Size(188, 22);
            capsLockToolStripMenuItem.Text = "Caps Lock";
            capsLockToolStripMenuItem.Click += actionCapsLock;
            // 
            // uPPERCaseClipboardToolStripMenuItem
            // 
            uPPERCaseClipboardToolStripMenuItem.Name = "uPPERCaseClipboardToolStripMenuItem";
            uPPERCaseClipboardToolStripMenuItem.Size = new Size(188, 22);
            uPPERCaseClipboardToolStripMenuItem.Text = "UPPER case clipboard";
            uPPERCaseClipboardToolStripMenuItem.Click += actionUpperCaseOnce;
            // 
            // lowerCaseClipboardToolStripMenuItem
            // 
            lowerCaseClipboardToolStripMenuItem.Name = "lowerCaseClipboardToolStripMenuItem";
            lowerCaseClipboardToolStripMenuItem.Size = new Size(188, 22);
            lowerCaseClipboardToolStripMenuItem.Text = "lower case clipboard";
            lowerCaseClipboardToolStripMenuItem.Click += actionLowerCaseOnce;
            // 
            // plainTextClipboardToolStripMenuItem
            // 
            plainTextClipboardToolStripMenuItem.Name = "plainTextClipboardToolStripMenuItem";
            plainTextClipboardToolStripMenuItem.Size = new Size(188, 22);
            plainTextClipboardToolStripMenuItem.Text = "Plain text clipboard";
            plainTextClipboardToolStripMenuItem.Click += actionPlainTextOnce;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(188, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += actionExit;
            // 
            // notifyIcon1
            // 
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "notifyIcon1";
            // 
            // systrayIcon
            // 
            systrayIcon.ContextMenuStrip = contextMenuStrip1;
            systrayIcon.Icon = (Icon)resources.GetObject("systrayIcon.Icon");
            systrayIcon.Text = "Clipboard Tool - Caps Lock is ?";
            systrayIcon.Visible = true;
            systrayIcon.DoubleClick += actionShowWindow;
            // 
            // toolTip
            // 
            toolTip.AutomaticDelay = 200;
            // 
            // buttonHelp
            // 
            buttonHelp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonHelp.Location = new Point(323, 188);
            buttonHelp.Name = "buttonHelp";
            buttonHelp.Size = new Size(30, 23);
            buttonHelp.TabIndex = 33;
            buttonHelp.Text = "?";
            buttonHelp.UseVisualStyleBackColor = true;
            buttonHelp.Click += actionShowHelp;
            buttonHelp.MouseHover += showTooltipHelp;
            // 
            // buttonSaveCustom
            // 
            buttonSaveCustom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonSaveCustom.Location = new Point(323, 217);
            buttonSaveCustom.Name = "buttonSaveCustom";
            buttonSaveCustom.Size = new Size(30, 23);
            buttonSaveCustom.TabIndex = 34;
            buttonSaveCustom.Text = "💾";
            buttonSaveCustom.UseVisualStyleBackColor = true;
            buttonSaveCustom.Click += actionSaveCustomText;
            buttonSaveCustom.MouseHover += showTooltipSaveTextToFile;
            // 
            // timerKeystrokes
            // 
            timerKeystrokes.Tick += actionDelayedKeystrokes;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(5, 309);
            splitContainer1.Margin = new Padding(0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(button7);
            splitContainer1.Panel1.Controls.Add(textBox1);
            splitContainer1.Panel1.Controls.Add(buttonSave1);
            splitContainer1.Panel1.Controls.Add(buttonLoad1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(350, 137);
            splitContainer1.SplitterDistance = 44;
            splitContainer1.TabIndex = 49;
            // 
            // button7
            // 
            button7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button7.Location = new Point(278, 2);
            button7.Name = "button7";
            button7.Size = new Size(23, 23);
            button7.TabIndex = 41;
            button7.Tag = "1";
            button7.Text = "💾";
            button7.UseVisualStyleBackColor = true;
            button7.Click += actionSaveToFile;
            button7.MouseHover += showTooltipSaveTextToFile;
            // 
            // splitContainer2
            // 
            splitContainer2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Margin = new Padding(0);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(button1);
            splitContainer2.Panel1.Controls.Add(button4);
            splitContainer2.Panel1.Controls.Add(button5);
            splitContainer2.Panel1.Controls.Add(textBox2);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(button6);
            splitContainer2.Panel2.Controls.Add(button8);
            splitContainer2.Panel2.Controls.Add(button9);
            splitContainer2.Panel2.Controls.Add(textBox3);
            splitContainer2.Size = new Size(348, 89);
            splitContainer2.SplitterDistance = 42;
            splitContainer2.TabIndex = 59;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(277, 3);
            button1.Name = "button1";
            button1.Size = new Size(23, 23);
            button1.TabIndex = 51;
            button1.Tag = "2";
            button1.Text = "💾";
            button1.UseVisualStyleBackColor = true;
            button1.Click += actionSaveToFile;
            button1.MouseHover += showTooltipSaveTextToFile;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button4.Location = new Point(301, 3);
            button4.Name = "button4";
            button4.Size = new Size(23, 23);
            button4.TabIndex = 52;
            button4.Tag = "2";
            button4.Text = "▽";
            button4.UseVisualStyleBackColor = true;
            button4.Click += actionSave;
            button4.MouseHover += showToolTipMemSave;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button5.Location = new Point(325, 3);
            button5.Name = "button5";
            button5.Size = new Size(23, 23);
            button5.TabIndex = 53;
            button5.Tag = "2";
            button5.Text = "△";
            button5.UseVisualStyleBackColor = true;
            button5.Click += actionLoad;
            button5.MouseHover += showToolTipMemLoad;
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button6.Location = new Point(277, 2);
            button6.Name = "button6";
            button6.Size = new Size(23, 23);
            button6.TabIndex = 61;
            button6.Tag = "3";
            button6.Text = "💾";
            button6.UseVisualStyleBackColor = true;
            button6.Click += actionSaveToFile;
            button6.MouseHover += showTooltipSaveTextToFile;
            // 
            // button8
            // 
            button8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button8.Location = new Point(301, 2);
            button8.Name = "button8";
            button8.Size = new Size(23, 23);
            button8.TabIndex = 62;
            button8.Tag = "3";
            button8.Text = "▽";
            button8.UseVisualStyleBackColor = true;
            button8.Click += actionSave;
            button8.MouseHover += showToolTipMemSave;
            // 
            // button9
            // 
            button9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button9.Location = new Point(325, 2);
            button9.Name = "button9";
            button9.Size = new Size(23, 23);
            button9.TabIndex = 63;
            button9.Tag = "3";
            button9.Text = "△";
            button9.UseVisualStyleBackColor = true;
            button9.Click += actionLoad;
            button9.MouseHover += showToolTipMemLoad;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 455);
            Controls.Add(splitContainer1);
            Controls.Add(buttonSaveCustom);
            Controls.Add(buttonHelp);
            Controls.Add(label1);
            Controls.Add(textCustom);
            Controls.Add(buttonProcess);
            Controls.Add(labelProcess);
            Controls.Add(numericUpDown1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(buttonToolbar);
            Controls.Add(buttonHide);
            Controls.Add(buttonPin);
            Controls.Add(buttonOptions);
            Controls.Add(checkBoxCapsLock);
            Controls.Add(labelCaps);
            Controls.Add(labelPlain);
            Controls.Add(labelUpper);
            Controls.Add(labelLower);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(buttonLower);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(180, 70);
            Name = "MainForm";
            Text = "Clipboard Tool";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonLower;
        private Button button2;
        private Button button3;
        private Label labelLower;
        private Label labelUpper;
        private Label labelPlain;
        private Label labelCaps;
        private CheckBox checkBoxCapsLock;
        private Button buttonOptions;
        private Button buttonPin;
        private Button buttonHide;
        private Button buttonToolbar;
        private Panel panel1;
        private Panel panel2;
        private NumericUpDown numericUpDown1;
        private Label labelProcess;
        private Button buttonProcess;
        private TextBox textCustom;
        private Label label1;
        private TextBox textBox1;
        private Button buttonSave1;
        private Button buttonLoad1;
        private TextBox textBox2;
        private TextBox textBox3;
        private System.Windows.Forms.Timer timerStatus;
        private ContextMenuStrip contextMenuStrip1;
        private NotifyIcon notifyIcon1;
        private NotifyIcon systrayIcon;
        private ToolTip toolTip;
        private ToolStripMenuItem hideToolStripMenuItem;
        private ToolStripMenuItem showToolStripMenuItem;
        private ToolStripMenuItem capsLockToolStripMenuItem;
        private ToolStripMenuItem uPPERCaseClipboardToolStripMenuItem;
        private ToolStripMenuItem lowerCaseClipboardToolStripMenuItem;
        private ToolStripMenuItem plainTextClipboardToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private Button buttonHelp;
        private Button buttonSaveCustom;
        private System.Windows.Forms.Timer timerKeystrokes;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private Button button7;
        private Button button1;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button8;
        private Button button9;
    }
}