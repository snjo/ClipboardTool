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
            //string tooltipText = "...";
            //toolTip1.SetToolTip(buttonMemory1, tooltipText);
            //toolTip1.SetToolTip(buttonMemory2, tooltipText);
            //toolTip1.SetToolTip(buttonMemory3, tooltipText);

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

        private void updateTooltip(int num)
        {
            //toolTip1.SetToolTip(button1, "Left Click to load to clipboard\nRight Click to save clipboard to this slot\n\n" + mainform.getMemorySlot(num));
        }

        private void updateTooltip1(object sender, EventArgs e)
        {
            updateTooltip(1);
        }

        private void updateTooltip2(object sender, EventArgs e)
        {
            updateTooltip(2);
        }

        private void updateTooltip3(object sender, EventArgs e)
        {
            updateTooltip(3);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Toolbar));
            this.buttonPin = new System.Windows.Forms.Button();
            this.buttonhide = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonProcess = new System.Windows.Forms.Button();
            this.buttonPlain = new System.Windows.Forms.Button();
            this.buttonUpper = new System.Windows.Forms.Button();
            this.buttonLower = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonPin
            // 
            this.buttonPin.Location = new System.Drawing.Point(185, 1);
            this.buttonPin.Name = "buttonPin";
            this.buttonPin.Size = new System.Drawing.Size(23, 23);
            this.buttonPin.TabIndex = 10;
            this.buttonPin.Text = "📌";
            this.buttonPin.UseVisualStyleBackColor = true;
            this.buttonPin.Click += new System.EventHandler(this.actionAlwaysOnTop);
            // 
            // buttonhide
            // 
            this.buttonhide.Location = new System.Drawing.Point(163, 1);
            this.buttonhide.Name = "buttonhide";
            this.buttonhide.Size = new System.Drawing.Size(23, 23);
            this.buttonhide.TabIndex = 11;
            this.buttonhide.Text = "—";
            this.buttonhide.UseVisualStyleBackColor = true;
            this.buttonhide.Click += new System.EventHandler(this.actionBorderToggle);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(93, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.saveload1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(115, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(23, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.saveload2);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(137, 1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(23, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.saveload3);
            // 
            // buttonProcess
            // 
            this.buttonProcess.Location = new System.Drawing.Point(71, 1);
            this.buttonProcess.Name = "buttonProcess";
            this.buttonProcess.Size = new System.Drawing.Size(23, 23);
            this.buttonProcess.TabIndex = 15;
            this.buttonProcess.Text = "$";
            this.buttonProcess.UseVisualStyleBackColor = true;
            this.buttonProcess.Click += new System.EventHandler(this.actionProcess);
            // 
            // buttonPlain
            // 
            this.buttonPlain.Location = new System.Drawing.Point(45, 1);
            this.buttonPlain.Name = "buttonPlain";
            this.buttonPlain.Size = new System.Drawing.Size(23, 23);
            this.buttonPlain.TabIndex = 16;
            this.buttonPlain.Text = "t";
            this.buttonPlain.UseVisualStyleBackColor = true;
            this.buttonPlain.Click += new System.EventHandler(this.actionPlain);
            // 
            // buttonUpper
            // 
            this.buttonUpper.Location = new System.Drawing.Point(23, 1);
            this.buttonUpper.Name = "buttonUpper";
            this.buttonUpper.Size = new System.Drawing.Size(23, 23);
            this.buttonUpper.TabIndex = 17;
            this.buttonUpper.Text = "A";
            this.buttonUpper.UseVisualStyleBackColor = true;
            this.buttonUpper.Click += new System.EventHandler(this.actionUpper);
            // 
            // buttonLower
            // 
            this.buttonLower.Location = new System.Drawing.Point(1, 1);
            this.buttonLower.Name = "buttonLower";
            this.buttonLower.Size = new System.Drawing.Size(23, 23);
            this.buttonLower.TabIndex = 18;
            this.buttonLower.Text = "a";
            this.buttonLower.UseVisualStyleBackColor = true;
            this.buttonLower.Click += new System.EventHandler(this.actionLower);
            // 
            // Toolbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 25);
            this.Controls.Add(this.buttonLower);
            this.Controls.Add(this.buttonUpper);
            this.Controls.Add(this.buttonPlain);
            this.Controls.Add(this.buttonProcess);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonhide);
            this.Controls.Add(this.buttonPin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Toolbar";
            this.Text = "Toolbar";
            this.ResumeLayout(false);

        }
    }


}
