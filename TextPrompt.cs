using System.Runtime.InteropServices;

namespace ClipboardTool
{
    public partial class TextPrompt : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        public string TextResult = string.Empty;
        public Color ColorPicked = Color.White;

        public TextPrompt(string title = "Input text", string info = "", bool showColorPicker = false)
        {
            InitializeComponent();
            Text = title;
            labelInfo.Text = info;
            if (!showColorPicker)
            {
                buttonColorPicker.Enabled = false;
                buttonColorPicker.Visible = false;
            }
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

        private void buttonColor_Click(object sender, EventArgs e)
        {
            ColorPicker();
        }

        private void ColorPicker()
        {
            DialogResult result = colorDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                ColorPicked = colorDialog1.Color;
                textBox1.BackColor = ColorPicked;
            }
        }
    }
}
