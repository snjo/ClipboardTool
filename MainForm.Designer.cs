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
            button1 = new Button();
            button4 = new Button();
            textBox2 = new TextBox();
            button5 = new Button();
            button6 = new Button();
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
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // buttonLower
            // 
            buttonLower.Location = new Point(5, 41);
            buttonLower.Name = "buttonLower";
            buttonLower.Size = new Size(75, 23);
            buttonLower.TabIndex = 0;
            buttonLower.Text = "lower";
            buttonLower.UseVisualStyleBackColor = true;
            buttonLower.Click += actionLowerCaseOnce;
            // 
            // button2
            // 
            button2.Location = new Point(5, 66);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 1;
            button2.Text = "UPPER";
            button2.UseVisualStyleBackColor = true;
            button2.Click += actionUpperCaseOnce;
            // 
            // button3
            // 
            button3.Location = new Point(5, 91);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 2;
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
            checkBoxCapsLock.TabIndex = 7;
            checkBoxCapsLock.Text = "Caps Lock";
            checkBoxCapsLock.UseVisualStyleBackColor = true;
            checkBoxCapsLock.Click += checkBoxCapsLock_Click;
            // 
            // buttonOptions
            // 
            buttonOptions.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonOptions.Location = new Point(221, 5);
            buttonOptions.Name = "buttonOptions";
            buttonOptions.Size = new Size(23, 23);
            buttonOptions.TabIndex = 8;
            buttonOptions.Text = "⚙️";
            buttonOptions.UseVisualStyleBackColor = true;
            buttonOptions.Click += actionShowOptions;
            buttonOptions.MouseHover += showTooltipSettings;
            // 
            // buttonPin
            // 
            buttonPin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonPin.Location = new Point(197, 5);
            buttonPin.Name = "buttonPin";
            buttonPin.Size = new Size(23, 23);
            buttonPin.TabIndex = 9;
            buttonPin.Text = "📌";
            buttonPin.UseVisualStyleBackColor = true;
            buttonPin.Click += actionAlwaysOnTop;
            buttonPin.MouseHover += showTooltipPin;
            // 
            // buttonHide
            // 
            buttonHide.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonHide.Location = new Point(173, 5);
            buttonHide.Name = "buttonHide";
            buttonHide.Size = new Size(23, 23);
            buttonHide.TabIndex = 10;
            buttonHide.Text = "👻";
            buttonHide.UseVisualStyleBackColor = true;
            buttonHide.Click += actionHideFromTaskbar;
            buttonHide.MouseHover += showToolTipHide;
            // 
            // buttonToolbar
            // 
            buttonToolbar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonToolbar.Location = new Point(100, 5);
            buttonToolbar.Name = "buttonToolbar";
            buttonToolbar.Size = new Size(72, 23);
            buttonToolbar.TabIndex = 11;
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
            panel1.Size = new Size(238, 1);
            panel1.TabIndex = 12;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Location = new Point(7, 146);
            panel2.Name = "panel2";
            panel2.Size = new Size(238, 1);
            panel2.TabIndex = 13;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericUpDown1.Location = new Point(177, 155);
            numericUpDown1.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(67, 23);
            numericUpDown1.TabIndex = 14;
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
            buttonProcess.TabIndex = 16;
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
            textCustom.Size = new Size(205, 92);
            textCustom.TabIndex = 17;
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
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(8, 312);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(169, 23);
            textBox1.TabIndex = 19;
            // 
            // buttonSave1
            // 
            buttonSave1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonSave1.Location = new Point(183, 312);
            buttonSave1.Name = "buttonSave1";
            buttonSave1.Size = new Size(30, 23);
            buttonSave1.TabIndex = 20;
            buttonSave1.Text = "S";
            buttonSave1.UseVisualStyleBackColor = true;
            buttonSave1.Click += actionSave1;
            buttonSave1.MouseHover += showToolTipMemSave;
            // 
            // buttonLoad1
            // 
            buttonLoad1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonLoad1.Location = new Point(214, 312);
            buttonLoad1.Name = "buttonLoad1";
            buttonLoad1.Size = new Size(30, 23);
            buttonLoad1.TabIndex = 21;
            buttonLoad1.Text = "L";
            buttonLoad1.UseVisualStyleBackColor = true;
            buttonLoad1.Click += actionLoad1;
            buttonLoad1.MouseHover += showToolTipMemLoad;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(215, 341);
            button1.Name = "button1";
            button1.Size = new Size(30, 23);
            button1.TabIndex = 24;
            button1.Text = "L";
            button1.UseVisualStyleBackColor = true;
            button1.Click += actionLoad2;
            button1.MouseHover += showToolTipMemLoad;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button4.Location = new Point(184, 341);
            button4.Name = "button4";
            button4.Size = new Size(30, 23);
            button4.TabIndex = 23;
            button4.Text = "S";
            button4.UseVisualStyleBackColor = true;
            button4.Click += actionSave2;
            button4.MouseHover += showToolTipMemSave;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox2.Location = new Point(9, 341);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ScrollBars = ScrollBars.Vertical;
            textBox2.Size = new Size(169, 23);
            textBox2.TabIndex = 22;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button5.Location = new Point(215, 370);
            button5.Name = "button5";
            button5.Size = new Size(30, 23);
            button5.TabIndex = 27;
            button5.Text = "L";
            button5.UseVisualStyleBackColor = true;
            button5.Click += actionLoad3;
            button5.MouseHover += showToolTipMemLoad;
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button6.Location = new Point(184, 370);
            button6.Name = "button6";
            button6.Size = new Size(30, 23);
            button6.TabIndex = 26;
            button6.Text = "S";
            button6.UseVisualStyleBackColor = true;
            button6.Click += actionSave3;
            button6.MouseHover += showToolTipMemSave;
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox3.Location = new Point(9, 370);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.ScrollBars = ScrollBars.Vertical;
            textBox3.Size = new Size(169, 23);
            textBox3.TabIndex = 25;
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
            systrayIcon.Click += actionCapsLock;
            // 
            // toolTip
            // 
            toolTip.AutomaticDelay = 200;
            // 
            // buttonHelp
            // 
            buttonHelp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonHelp.Location = new Point(214, 188);
            buttonHelp.Name = "buttonHelp";
            buttonHelp.Size = new Size(30, 23);
            buttonHelp.TabIndex = 28;
            buttonHelp.Text = "?";
            buttonHelp.UseVisualStyleBackColor = true;
            buttonHelp.Click += actionShowHelp;
            buttonHelp.MouseHover += showTooltipHelp;
            // 
            // buttonSaveCustom
            // 
            buttonSaveCustom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonSaveCustom.Location = new Point(214, 217);
            buttonSaveCustom.Name = "buttonSaveCustom";
            buttonSaveCustom.Size = new Size(30, 23);
            buttonSaveCustom.TabIndex = 29;
            buttonSaveCustom.Text = "💾";
            buttonSaveCustom.UseVisualStyleBackColor = true;
            buttonSaveCustom.Click += actionSaveCustomText;
            buttonSaveCustom.MouseHover += showTooltipSaveCustom;
            // 
            // timerKeystrokes
            // 
            timerKeystrokes.Tick += actionDelayedKeystrokes;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(251, 404);
            Controls.Add(buttonSaveCustom);
            Controls.Add(buttonHelp);
            Controls.Add(button5);
            Controls.Add(button6);
            Controls.Add(textBox3);
            Controls.Add(button1);
            Controls.Add(button4);
            Controls.Add(textBox2);
            Controls.Add(buttonLoad1);
            Controls.Add(buttonSave1);
            Controls.Add(textBox1);
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
            Name = "MainForm";
            Text = "Clipboard Tool";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
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
        private Button button1;
        private Button button4;
        private TextBox textBox2;
        private Button button5;
        private Button button6;
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
    }
}