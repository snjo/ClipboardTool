using ClipboardTool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace ClipboardTool
{
    public partial class Toolbar : Form
    {
        public MainForm mainform;
        private bool borderLess = false;
        private bool alwaysOnTop = true;

        public Toolbar()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            string tooltipText = "...";
            toolTip1.SetToolTip(button1, tooltipText);
            toolTip1.SetToolTip(button2, tooltipText);
            toolTip1.SetToolTip(button3, tooltipText);

        }

        private void actionToolbarClose(object sender, EventArgs e)
        {
            mainform.Show();
            this.Close();
        }

        public void ShowForm()
        {
            Show();
        }

        private void actionBorderToggle(object sender, EventArgs e)
        {
            borderLess = !borderLess;
            if (borderLess)
            {
                FormBorderStyle = FormBorderStyle.None;
            }
            else
            {
                FormBorderStyle = FormBorderStyle.FixedToolWindow;
            }
        }

        private void actionAlwaysOnTop(object sender, EventArgs e)
        {
            alwaysOnTop = !alwaysOnTop;
            if (alwaysOnTop)
            {
                TopMost = true;
            }
            else
            {
                TopMost = false;
            }
        }

        private void actionLower(object sender, EventArgs e)
        {
            mainform.actionLowerCaseOnce(sender, e);
        }

        private void actionUpper(object sender, EventArgs e)
        {
            mainform.actionUpperCaseOnce(sender, e);
        }

        private void actionPlain(object sender, EventArgs e)
        {
            mainform.actionPlainTextOnce(sender, e);
        }

        private void actionProcess(object sender, EventArgs e)
        {
            mainform.actionProcessText(sender, e);
        }

        private void saveload1(object sender, MouseEventArgs e)
        {
            saveLoad(1, e);
        }

        private void saveload2(object sender, MouseEventArgs e)
        {
            saveLoad(2, e);
        }
        private void saveload3(object sender, MouseEventArgs e)
        {
            saveLoad(3, e);
        }

        private void saveLoad(int num, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mainform.setClipboardFromTextBox(num);
            }
            if (e.Button == MouseButtons.Right)
            {
                mainform.setTextBoxFromClipboard(num);
            }
        }

        private void updateTooltip(System.Windows.Forms.Button button, int num)
        {
            toolTip1.SetToolTip(button, "Left Click to load to clipboard\nRight Click to save clipboard to this slot\n\n" + mainform.MemorySlotText(num));
        }

        private void updateTooltip1(object sender, EventArgs e)
        {
            updateTooltip(button1, 1);
        }

        private void updateTooltip2(object sender, EventArgs e)
        {
            updateTooltip(button2, 2);
        }

        private void updateTooltip3(object sender, EventArgs e)
        {
            updateTooltip(button3, 3);
        }

        private void updateTooltipLower(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(buttonLower, "Converts clipboard text to lower case");
        }

        private void updateTooltipUpper(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(buttonUpper, "Converts clipboard text to upper case");
        }

        private void updateTooltipPlain(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(buttonPlain, "Converts clipboard text to plain text");
        }

        private void updateTooltipProcess(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(buttonProcess, "Updates clipboard using values from the main window Process text box");
        }

        private System.Windows.Forms.Button buttonPin;
        private System.Windows.Forms.Button buttonhide;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonProcess;
        private System.Windows.Forms.Button buttonPlain;
        private System.Windows.Forms.Button buttonUpper;
        private System.Windows.Forms.Button buttonLower;

        private void InitializeComponent()
        {
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Toolbar));
            buttonPin = new System.Windows.Forms.Button();
            buttonhide = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            buttonProcess = new System.Windows.Forms.Button();
            buttonPlain = new System.Windows.Forms.Button();
            buttonUpper = new System.Windows.Forms.Button();
            buttonLower = new System.Windows.Forms.Button();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            SuspendLayout();
            // 
            // buttonPin
            // 
            buttonPin.Location = new Point(185, 1);
            buttonPin.Name = "buttonPin";
            buttonPin.Size = new Size(23, 23);
            buttonPin.TabIndex = 10;
            buttonPin.Text = "📌";
            buttonPin.UseVisualStyleBackColor = true;
            buttonPin.Click += actionAlwaysOnTop;
            // 
            // buttonhide
            // 
            buttonhide.Location = new Point(163, 1);
            buttonhide.Name = "buttonhide";
            buttonhide.Size = new Size(23, 23);
            buttonhide.TabIndex = 11;
            buttonhide.Text = "—";
            buttonhide.UseVisualStyleBackColor = true;
            buttonhide.Click += actionBorderToggle;
            // 
            // button1
            // 
            button1.Location = new Point(93, 1);
            button1.Name = "button1";
            button1.Size = new Size(23, 23);
            button1.TabIndex = 12;
            button1.Text = "1";
            button1.UseVisualStyleBackColor = true;
            button1.MouseHover += updateTooltip1;
            button1.MouseUp += saveload1;
            // 
            // button2
            // 
            button2.Location = new Point(115, 1);
            button2.Name = "button2";
            button2.Size = new Size(23, 23);
            button2.TabIndex = 13;
            button2.Text = "2";
            button2.UseVisualStyleBackColor = true;
            button2.MouseHover += updateTooltip2;
            button2.MouseUp += saveload2;
            // 
            // button3
            // 
            button3.Location = new Point(137, 1);
            button3.Name = "button3";
            button3.Size = new Size(23, 23);
            button3.TabIndex = 14;
            button3.Text = "3";
            button3.UseVisualStyleBackColor = true;
            button3.MouseHover += updateTooltip3;
            button3.MouseUp += saveload3;
            // 
            // buttonProcess
            // 
            buttonProcess.Location = new Point(71, 1);
            buttonProcess.Name = "buttonProcess";
            buttonProcess.Size = new Size(23, 23);
            buttonProcess.TabIndex = 15;
            buttonProcess.Text = "$";
            buttonProcess.UseVisualStyleBackColor = true;
            buttonProcess.Click += actionProcess;
            buttonProcess.MouseHover += updateTooltipProcess;
            // 
            // buttonPlain
            // 
            buttonPlain.Location = new Point(45, 1);
            buttonPlain.Name = "buttonPlain";
            buttonPlain.Size = new Size(23, 23);
            buttonPlain.TabIndex = 16;
            buttonPlain.Text = "t";
            buttonPlain.UseVisualStyleBackColor = true;
            buttonPlain.Click += actionPlain;
            buttonPlain.MouseHover += updateTooltipPlain;
            // 
            // buttonUpper
            // 
            buttonUpper.Location = new Point(23, 1);
            buttonUpper.Name = "buttonUpper";
            buttonUpper.Size = new Size(23, 23);
            buttonUpper.TabIndex = 17;
            buttonUpper.Text = "A";
            buttonUpper.UseVisualStyleBackColor = true;
            buttonUpper.Click += actionUpper;
            buttonUpper.MouseHover += updateTooltipUpper;
            // 
            // buttonLower
            // 
            buttonLower.Location = new Point(1, 1);
            buttonLower.Name = "buttonLower";
            buttonLower.Size = new Size(23, 23);
            buttonLower.TabIndex = 18;
            buttonLower.Text = "a";
            buttonLower.UseVisualStyleBackColor = true;
            buttonLower.Click += actionLower;
            buttonLower.MouseHover += updateTooltipLower;
            // 
            // Toolbar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(209, 25);
            Controls.Add(buttonLower);
            Controls.Add(buttonUpper);
            Controls.Add(buttonPlain);
            Controls.Add(buttonProcess);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(buttonhide);
            Controls.Add(buttonPin);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Toolbar";
            Text = "Toolbar";
            TopMost = true;
            ResumeLayout(false);
        }

    }


}
