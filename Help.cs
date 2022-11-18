using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClipboardTool
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
        }

        private void Help_Load(object sender, EventArgs e)
        {

        }

        private void actionClose(object sender, EventArgs e)
        {
            Hide();
        }

        public void setText(string text)
        {
            richTextBox1.Text = "";
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);

            richTextBox1.AppendText("Text processing commands\n\n");

            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);

            richTextBox1.AppendText(text);

        }
    }
}
