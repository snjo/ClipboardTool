using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace ClipboardTool;
[SupportedOSPlatform("windows")]

public partial class TextPrompt : Form
{
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern bool SetForegroundWindow(IntPtr hWnd);
    public static readonly string[] IllegalFileCharacters = ["\\", "/", ":", "*", "?", "<", ">", "|"];

    public List<string> TextResult = [];
    List<TextBox> textBoxes = [];
    public Color ColorPicked = Color.White;
    readonly string[]? IllegalCharacters = null;

    public TextPrompt(int amount = 1, string title = "Input text", string info = "", bool showColorPicker = false, string[]? illegalCharacters = null)
    {
        InitializeComponent();
        Text = title;
        labelInfo.Text = info;

        buttonColorPicker.Visible = showColorPicker;

        IllegalCharacters = illegalCharacters;

        textBoxes.Clear();
        textBoxes.Add(textBox1);

        if (amount > 1)
        {
            for (int i = 1; i < amount; i++)
            {
                TextBox textBox = new TextBox();
                textBox.Left = textBox1.Left;
                textBox.Size = textBox1.Size;
                textBox.Top = textBox1.Top + (textBox.Height + 10) * i;
                textBox.KeyPress += TextBox_KeyPress;
                textBox.TabIndex = i;
                textBoxes.Add(textBox);
                Controls.Add(textBox);
            }
            buttonOK.Top = textBoxes.Last().Bottom + 10;
            buttonCancel.Top = buttonOK.Top;
            buttonColorPicker.Top = buttonOK.Top;
            this.Height = buttonOK.Bottom + 50;
        }
    }

    /// <summary>
    /// Shows a dialog with a text entry box.
    /// </summary>
    /// <returns>String if OK, null if cancelled</returns>
    public static string Prompt(string title = "Input text", string info = "", bool showColorPicker = false, string[]? illegalCharacters = null)
    {
        return PromptMultiple(1, title, info, showColorPicker, illegalCharacters).First();
    }

    public static List<string> PromptMultiple(int amount = 2, string title = "Input text", string info = "", bool showColorPicker = false, string[]? illegalCharacters = null)
    {
        TextPrompt textPrompt = new(amount, title, info, showColorPicker, illegalCharacters);
        DialogResult dialogResult = textPrompt.ShowDialog();
        if (dialogResult == DialogResult.OK)
        {
            Debug.WriteLine("Prompt result: " + textPrompt.TextResult);
            List<string> textResult = textPrompt.TextResult;
            textPrompt.Dispose();
            return textResult;
        }
        else
        {
            Debug.WriteLine("Prompt cancelled, returning null");
            textPrompt.Dispose();
            return new List<string>();
        }
    }

    private void AssembleResult()
    {
        TextResult.Clear();
        foreach (TextBox box in textBoxes)
        {
            TextResult.Add(box.Text);
        }
    }

    private void TextPrompt_Load(object sender, EventArgs e)
    {
        SetForegroundWindow(Handle);
        this.ActiveControl = textBox1;
    }

    private void ButtonOK_Click(object sender, EventArgs e)
    {
        AssembleResult();
        //TextResult = textBox1.Text;
        DialogResult = DialogResult.OK;
    }

    private void ButtonCancel_Click(object sender, EventArgs e)
    {
        //TextResult = string.Empty;
        DialogResult = DialogResult.Cancel;
    }

    private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter)
        {
            if (buttonOK.Enabled)
            {
                AssembleResult();
                //TextResult = textBox1.Text;
                DialogResult = DialogResult.OK;
            }
            e.Handled = true; // stops ding sound
        }
        if (e.KeyChar == (char)Keys.Escape)
        {
            //TextResult = string.Empty;
            DialogResult = DialogResult.Cancel;
            e.Handled = true;
        }
    }

    private void ButtonColor_Click(object sender, EventArgs e)
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

    private void TextBox1_TextChanged(object sender, EventArgs e)
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

    private static string ArrayToString(string[] textArray, string separator = " ")
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
