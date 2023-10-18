using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace ClipboardTool
{
    public partial class TextPrompt : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        public static string[] IllegalFileCharacters = { "\\", "/", ":", "*", "?", "<", ">", "|" };

        public string TextResult = string.Empty;
        public Color ColorPicked = Color.White;
        string[]? IllegalCharacters = null;

        public TextPrompt(string title = "Input text", string info = "", bool showColorPicker = false, string[]? illegalCharacters = null)
        {
            InitializeComponent();
            Text = title;
            labelInfo.Text = info;

            buttonColorPicker.Visible = showColorPicker;

            IllegalCharacters = illegalCharacters;
        }

        /// <summary>
        /// Shows a dialog with a text entry box.
        /// </summary>
        /// <returns>String if OK, null if cancelled</returns>
        public static string? Prompt(string title = "Input text", string info = "", bool showColorPicker = false, string[]? illegalCharacters = null)
        {
            TextPrompt textPrompt = new TextPrompt(title, info, showColorPicker, illegalCharacters);
            DialogResult dialogResult = textPrompt.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                Debug.WriteLine("Prompt result: " + textPrompt.TextResult);
                string textResult = textPrompt.TextResult;
                textPrompt.Dispose();
                return textResult;
            }
            else
            {
                Debug.WriteLine("Prompt cancelled, returning null");
                textPrompt.Dispose();
                return null;
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
                if (buttonOK.Enabled)
                {
                    TextResult = textBox1.Text;
                    DialogResult = DialogResult.OK;
                }
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (IllegalCharacters == null) return;
            string text = textBox1.Text;
            bool illegalFound = false;
            foreach (string illegal in IllegalCharacters)
            {
                if (text.Contains(illegal))
                {
                    illegalFound = true;
                }
            }
            buttonOK.Enabled = !illegalFound;
            if (illegalFound)
            {
                toolTipIllegal.ShowAlways = true;
                toolTipIllegal.Show("You can't include these characters: " + ArrayToString(IllegalCharacters), textBox1);
            }
            else
            {
                toolTipIllegal.ShowAlways = true;
                toolTipIllegal.Hide(textBox1);
            }
        }

        private string ArrayToString(string[] textArray, string separator = " ")
        {
            string result = string.Empty;
            for (int i = 0; i < textArray.Length; i++)
            {
                result += textArray[i];
                if (i < textArray.Length - 1) result += separator;
            }
            return result;
        }
    }
}
