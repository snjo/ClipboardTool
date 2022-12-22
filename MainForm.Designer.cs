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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonLower = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.labelLower = new System.Windows.Forms.Label();
            this.labelUpper = new System.Windows.Forms.Label();
            this.labelPlain = new System.Windows.Forms.Label();
            this.labelCaps = new System.Windows.Forms.Label();
            this.checkBoxCapsLock = new System.Windows.Forms.CheckBox();
            this.buttonOptions = new System.Windows.Forms.Button();
            this.buttonPin = new System.Windows.Forms.Button();
            this.buttonHide = new System.Windows.Forms.Button();
            this.buttonToolbar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.labelProcess = new System.Windows.Forms.Label();
            this.buttonProcess = new System.Windows.Forms.Button();
            this.textCustom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonSave1 = new System.Windows.Forms.Button();
            this.buttonLoad1 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.timerStatus = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.capsLockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uPPERCaseClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lowerCaseClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plainTextClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.systrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonHelp = new System.Windows.Forms.Button();
            this.buttonSaveCustom = new System.Windows.Forms.Button();
            this.timerKeystrokes = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLower
            // 
            this.buttonLower.Location = new System.Drawing.Point(5, 41);
            this.buttonLower.Name = "buttonLower";
            this.buttonLower.Size = new System.Drawing.Size(75, 23);
            this.buttonLower.TabIndex = 0;
            this.buttonLower.Text = "lower";
            this.buttonLower.UseVisualStyleBackColor = true;
            this.buttonLower.Click += new System.EventHandler(this.actionLowerCaseOnce);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(5, 66);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "UPPER";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.actionUpperCaseOnce);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(5, 91);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Plain";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.actionPlainTextOnce);
            // 
            // labelLower
            // 
            this.labelLower.AutoSize = true;
            this.labelLower.Location = new System.Drawing.Point(90, 45);
            this.labelLower.Name = "labelLower";
            this.labelLower.Size = new System.Drawing.Size(60, 15);
            this.labelLower.TabIndex = 3;
            this.labelLower.Text = "no hotkey";
            // 
            // labelUpper
            // 
            this.labelUpper.AutoSize = true;
            this.labelUpper.Location = new System.Drawing.Point(90, 70);
            this.labelUpper.Name = "labelUpper";
            this.labelUpper.Size = new System.Drawing.Size(60, 15);
            this.labelUpper.TabIndex = 4;
            this.labelUpper.Text = "no hotkey";
            // 
            // labelPlain
            // 
            this.labelPlain.AutoSize = true;
            this.labelPlain.Location = new System.Drawing.Point(90, 95);
            this.labelPlain.Name = "labelPlain";
            this.labelPlain.Size = new System.Drawing.Size(60, 15);
            this.labelPlain.TabIndex = 5;
            this.labelPlain.Text = "no hotkey";
            // 
            // labelCaps
            // 
            this.labelCaps.AutoSize = true;
            this.labelCaps.Location = new System.Drawing.Point(90, 122);
            this.labelCaps.Name = "labelCaps";
            this.labelCaps.Size = new System.Drawing.Size(60, 15);
            this.labelCaps.TabIndex = 6;
            this.labelCaps.Text = "no hotkey";
            // 
            // checkBoxCapsLock
            // 
            this.checkBoxCapsLock.AutoSize = true;
            this.checkBoxCapsLock.Location = new System.Drawing.Point(8, 121);
            this.checkBoxCapsLock.Name = "checkBoxCapsLock";
            this.checkBoxCapsLock.Size = new System.Drawing.Size(80, 19);
            this.checkBoxCapsLock.TabIndex = 7;
            this.checkBoxCapsLock.Text = "Caps Lock";
            this.checkBoxCapsLock.UseVisualStyleBackColor = true;
            this.checkBoxCapsLock.Click += new System.EventHandler(this.checkBoxCapsLock_Click);
            // 
            // buttonOptions
            // 
            this.buttonOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOptions.Location = new System.Drawing.Point(221, 5);
            this.buttonOptions.Name = "buttonOptions";
            this.buttonOptions.Size = new System.Drawing.Size(23, 23);
            this.buttonOptions.TabIndex = 8;
            this.buttonOptions.Text = "⚙️";
            this.buttonOptions.UseVisualStyleBackColor = true;
            this.buttonOptions.Click += new System.EventHandler(this.actionShowOptions);
            this.buttonOptions.MouseHover += new System.EventHandler(this.showTooltipSettings);
            // 
            // buttonPin
            // 
            this.buttonPin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPin.Location = new System.Drawing.Point(197, 5);
            this.buttonPin.Name = "buttonPin";
            this.buttonPin.Size = new System.Drawing.Size(23, 23);
            this.buttonPin.TabIndex = 9;
            this.buttonPin.Text = "📌";
            this.buttonPin.UseVisualStyleBackColor = true;
            this.buttonPin.Click += new System.EventHandler(this.actionAlwaysOnTop);
            this.buttonPin.MouseHover += new System.EventHandler(this.showTooltipPin);
            // 
            // buttonHide
            // 
            this.buttonHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHide.Location = new System.Drawing.Point(173, 5);
            this.buttonHide.Name = "buttonHide";
            this.buttonHide.Size = new System.Drawing.Size(23, 23);
            this.buttonHide.TabIndex = 10;
            this.buttonHide.Text = "👻";
            this.buttonHide.UseVisualStyleBackColor = true;
            this.buttonHide.Click += new System.EventHandler(this.actionHideFromTaskbar);
            this.buttonHide.MouseHover += new System.EventHandler(this.showToolTipHide);
            // 
            // buttonToolbar
            // 
            this.buttonToolbar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonToolbar.Location = new System.Drawing.Point(100, 5);
            this.buttonToolbar.Name = "buttonToolbar";
            this.buttonToolbar.Size = new System.Drawing.Size(72, 23);
            this.buttonToolbar.TabIndex = 11;
            this.buttonToolbar.Text = "toolbar";
            this.buttonToolbar.UseVisualStyleBackColor = true;
            this.buttonToolbar.Click += new System.EventHandler(this.actionShowToolbar);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(8, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 1);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(7, 146);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(238, 1);
            this.panel2.TabIndex = 13;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown1.Location = new System.Drawing.Point(177, 155);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(67, 23);
            this.numericUpDown1.TabIndex = 14;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelProcess
            // 
            this.labelProcess.AutoSize = true;
            this.labelProcess.Location = new System.Drawing.Point(90, 159);
            this.labelProcess.Name = "labelProcess";
            this.labelProcess.Size = new System.Drawing.Size(60, 15);
            this.labelProcess.TabIndex = 15;
            this.labelProcess.Text = "no hotkey";
            // 
            // buttonProcess
            // 
            this.buttonProcess.Location = new System.Drawing.Point(9, 156);
            this.buttonProcess.Name = "buttonProcess";
            this.buttonProcess.Size = new System.Drawing.Size(75, 23);
            this.buttonProcess.TabIndex = 16;
            this.buttonProcess.Text = "Process";
            this.buttonProcess.UseVisualStyleBackColor = true;
            this.buttonProcess.Click += new System.EventHandler(this.actionProcessText);
            // 
            // textCustom
            // 
            this.textCustom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textCustom.Location = new System.Drawing.Point(8, 188);
            this.textCustom.Multiline = true;
            this.textCustom.Name = "textCustom";
            this.textCustom.Size = new System.Drawing.Size(205, 92);
            this.textCustom.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 291);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 18;
            this.label1.Text = "Memory slots";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(8, 312);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(169, 23);
            this.textBox1.TabIndex = 19;
            // 
            // buttonSave1
            // 
            this.buttonSave1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave1.Location = new System.Drawing.Point(183, 312);
            this.buttonSave1.Name = "buttonSave1";
            this.buttonSave1.Size = new System.Drawing.Size(30, 23);
            this.buttonSave1.TabIndex = 20;
            this.buttonSave1.Text = "S";
            this.buttonSave1.UseVisualStyleBackColor = true;
            this.buttonSave1.Click += new System.EventHandler(this.actionSave1);
            // 
            // buttonLoad1
            // 
            this.buttonLoad1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoad1.Location = new System.Drawing.Point(214, 312);
            this.buttonLoad1.Name = "buttonLoad1";
            this.buttonLoad1.Size = new System.Drawing.Size(30, 23);
            this.buttonLoad1.TabIndex = 21;
            this.buttonLoad1.Text = "L";
            this.buttonLoad1.UseVisualStyleBackColor = true;
            this.buttonLoad1.Click += new System.EventHandler(this.actionLoad1);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(215, 341);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "L";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.actionLoad2);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(184, 341);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(30, 23);
            this.button4.TabIndex = 23;
            this.button4.Text = "S";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.actionSave2);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(9, 341);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(169, 23);
            this.textBox2.TabIndex = 22;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Location = new System.Drawing.Point(215, 370);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(30, 23);
            this.button5.TabIndex = 27;
            this.button5.Text = "L";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.actionLoad3);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.Location = new System.Drawing.Point(184, 370);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(30, 23);
            this.button6.TabIndex = 26;
            this.button6.Text = "S";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.actionSave3);
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(9, 370);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(169, 23);
            this.textBox3.TabIndex = 25;
            // 
            // timerStatus
            // 
            this.timerStatus.Enabled = true;
            this.timerStatus.Interval = 500;
            this.timerStatus.Tick += new System.EventHandler(this.timerStatus_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideToolStripMenuItem,
            this.showToolStripMenuItem,
            this.capsLockToolStripMenuItem,
            this.uPPERCaseClipboardToolStripMenuItem,
            this.lowerCaseClipboardToolStripMenuItem,
            this.plainTextClipboardToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(189, 158);
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.hideToolStripMenuItem.Text = "Hide";
            this.hideToolStripMenuItem.Click += new System.EventHandler(this.actionHideFromTaskbar);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.actionShowWindow);
            // 
            // capsLockToolStripMenuItem
            // 
            this.capsLockToolStripMenuItem.Name = "capsLockToolStripMenuItem";
            this.capsLockToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.capsLockToolStripMenuItem.Text = "Caps Lock";
            this.capsLockToolStripMenuItem.Click += new System.EventHandler(this.actionCapsLock);
            // 
            // uPPERCaseClipboardToolStripMenuItem
            // 
            this.uPPERCaseClipboardToolStripMenuItem.Name = "uPPERCaseClipboardToolStripMenuItem";
            this.uPPERCaseClipboardToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.uPPERCaseClipboardToolStripMenuItem.Text = "UPPER case clipboard";
            this.uPPERCaseClipboardToolStripMenuItem.Click += new System.EventHandler(this.actionUpperCaseOnce);
            // 
            // lowerCaseClipboardToolStripMenuItem
            // 
            this.lowerCaseClipboardToolStripMenuItem.Name = "lowerCaseClipboardToolStripMenuItem";
            this.lowerCaseClipboardToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.lowerCaseClipboardToolStripMenuItem.Text = "lower case clipboard";
            this.lowerCaseClipboardToolStripMenuItem.Click += new System.EventHandler(this.actionLowerCaseOnce);
            // 
            // plainTextClipboardToolStripMenuItem
            // 
            this.plainTextClipboardToolStripMenuItem.Name = "plainTextClipboardToolStripMenuItem";
            this.plainTextClipboardToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.plainTextClipboardToolStripMenuItem.Text = "Plain text clipboard";
            this.plainTextClipboardToolStripMenuItem.Click += new System.EventHandler(this.actionPlainTextOnce);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.actionExit);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            // 
            // systrayIcon
            // 
            this.systrayIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.systrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("systrayIcon.Icon")));
            this.systrayIcon.Text = "Clipboard Tool - Caps Lock is ?";
            this.systrayIcon.Visible = true;
            this.systrayIcon.Click += new System.EventHandler(this.actionCapsLock);
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 200;
            // 
            // buttonHelp
            // 
            this.buttonHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHelp.Location = new System.Drawing.Point(214, 188);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(30, 23);
            this.buttonHelp.TabIndex = 28;
            this.buttonHelp.Text = "?";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.actionShowHelp);
            this.buttonHelp.MouseHover += new System.EventHandler(this.showTooltipHelp);
            // 
            // buttonSaveCustom
            // 
            this.buttonSaveCustom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveCustom.Location = new System.Drawing.Point(214, 217);
            this.buttonSaveCustom.Name = "buttonSaveCustom";
            this.buttonSaveCustom.Size = new System.Drawing.Size(30, 23);
            this.buttonSaveCustom.TabIndex = 29;
            this.buttonSaveCustom.Text = "💾";
            this.buttonSaveCustom.UseVisualStyleBackColor = true;
            this.buttonSaveCustom.Click += new System.EventHandler(this.actionSaveCustomText);
            this.buttonSaveCustom.MouseHover += new System.EventHandler(this.showTooltipSaveCustom);
            // 
            // timerKeystrokes
            // 
            this.timerKeystrokes.Tick += new System.EventHandler(this.actionDelayedKeystrokes);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 404);
            this.Controls.Add(this.buttonSaveCustom);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.buttonLoad1);
            this.Controls.Add(this.buttonSave1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textCustom);
            this.Controls.Add(this.buttonProcess);
            this.Controls.Add(this.labelProcess);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonToolbar);
            this.Controls.Add(this.buttonHide);
            this.Controls.Add(this.buttonPin);
            this.Controls.Add(this.buttonOptions);
            this.Controls.Add(this.checkBoxCapsLock);
            this.Controls.Add(this.labelCaps);
            this.Controls.Add(this.labelPlain);
            this.Controls.Add(this.labelUpper);
            this.Controls.Add(this.labelLower);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonLower);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Clipboard Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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