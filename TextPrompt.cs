using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClipboardTool
{
    public partial class TextPrompt : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        public string TextResult = string.Empty;
        public TextPrompt()
        {
            InitializeComponent();
        }

        private void TextPrompt_Load(object sender, EventArgs e)
        {
            SetForegroundWindow(Handle);
            this.ActiveControl = textBox1;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            TextResult = textBox1.Text;
            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            TextResult = string.Empty;
            DialogResult = DialogResult.Cancel;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                TextResult = textBox1.Text;
                DialogResult = DialogResult.OK;
            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                TextResult = string.Empty;
                DialogResult = DialogResult.Cancel;
            }
        }


    }
}
