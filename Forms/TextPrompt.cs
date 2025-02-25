using System.Diagnostics;
using System.Runtime.CompilerServices;
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

    public int AmountOfTextPrompts = 1;
    public string TitleText;
    public string InfoText;
    public bool ShowColorPicker;
    public string[]? IllegalCharacters;
    public string[] PromptHeadings = {};
    public int DialogWidth = 350;
    //public Size TextboxSize = new Size(300, 23);
    //public bool TextboxMultiline = false;
    public List<PromptTextBoxConfig> textPromptConfigs = [];

    /// <summary>
    /// Creates TextPrompt and initializes the form
    /// </summary>
    /// <param name="amount">Number of text input fields</param>
    /// <param name="title">The form titlebar text</param>
    /// <param name="info">Text at the beginning of the form with instructions</param>
    /// <param name="showColorPicker">Enables the color picker button</param>
    /// <param name="illegalCharacters">If configured, disallows certain characters or phrases in the first field</param>
    //public TextPrompt(int amount = 1, string title = "Input text", string info = "", bool showColorPicker = false, string[]? illegalCharacters = null)
    //{
    //    Debug.WriteLine($"Adding TextPrompt with arguments");
    //    AmountOfTextPrompts = amount;
    //    TitleText = title;
    //    InfoText = info;
    //    ShowColorPicker = showColorPicker;
    //    IllegalCharacters = illegalCharacters;
    //    InitializePrompt();
    //}

    //public void InitializePrompt()
    //{
    //    InitializeComponent();
    //    Text = TitleText;
    //    labelInfo.Text = InfoText;

    //    buttonColorPicker.Visible = ShowColorPicker;
    //    Debug.WriteLine($"Show color picker: {ShowColorPicker}");

    //    textBoxes.Clear();

    //    if (AmountOfTextPrompts > 0)
    //    {
    //        int top = 20;
    //        for (int i = 0; i < AmountOfTextPrompts; i++)
    //        {
    //            string promptheading = "";
    //            if (i < PromptHeadings.Length) promptheading = PromptHeadings[i];
    //            PromptTextBoxConfig newTBC = new PromptTextBoxConfig(top, 10, this.Width - 20, 1, promptheading, string.Empty);
    //            this.Controls.Add(newTBC.label);
    //            this.Controls.Add(newTBC.textbox);
    //            newTBC.textbox.TextChanged += TextBox_TextChanged;
    //            textPromptConfigs.Add(newTBC);
    //            textBoxes.Add(newTBC.textbox);

    //            top = newTBC.GetBottom() + 5;
    //        }

    //        // ENTER confirms the text prompt only if it's single prompt, single line
    //        if (AmountOfTextPrompts == 1 && textPromptConfigs.First().Multiline == false)
    //        {
    //            textBoxes.First().KeyPress += TextBox_KeyPress;
    //        }

    //        buttonOK.Top = textBoxes.Last().Bottom + 10;
    //        buttonCancel.Top = buttonOK.Top;
    //        buttonColorPicker.Top = buttonOK.Top;
    //        this.Height = buttonOK.Bottom + 50;
    //    }
    //}

    /// <summary>
    /// Creates the TextPrompt object, using a list of configs
    /// </summary>
    /// <param name="configs">A list of 1-n text input fields</param>
    /// <param name="title">The form titlebar text</param>
    /// <param name="info">Text at the beginning of the form with instructions</param>
    public TextPrompt(List<PromptTextBoxConfig> configs, string title, string info)
    {
        Debug.WriteLine($"Adding TextPrompt with list of configs");
        InitializeComponent();
        TitleText = title;
        InfoText = info;
        labelInfo.Text = info;
        Text = title;
        AmountOfTextPrompts = configs.Count;
        textPromptConfigs = configs;

        foreach (PromptTextBoxConfig cfg in configs)
        {
            Controls.Add(cfg.label);
            Controls.Add(cfg.textbox);
            textBoxes.Add(cfg.textbox);
            cfg.textbox.TextChanged += TextBox_TextChanged;
        }

        //InitializePrompt();
        Debug.WriteLine($"show color picker: {ShowColorPicker}");
    }

    public void UpdateControls()
    {
        int controlsLeft = 5;
        int controlsWidth = this.Width - 25;
        int previousBottom = labelInfo.Bottom;
        foreach (PromptTextBoxConfig cfg in textPromptConfigs)
        {
            cfg.UpdateControlPositions(controlsLeft, previousBottom + 5, controlsWidth);
            //cfg.label.Left = controlsLeft;
            //cfg.label.Top = previousBottom + 5;
            //cfg.textbox.Left = controlsLeft;
            //cfg.textbox.Top = cfg.label.Bottom;
            previousBottom = cfg.GetBottom();
            Debug.WriteLine($"Form height {this.Height} to: {previousBottom + 30}");
            this.Height = previousBottom + 75;
            Debug.WriteLine($"Form height {this.Height}");
        }
        Debug.WriteLine($"Illegal characters: {IllegalCharacters != null}");
        if (ShowColorPicker)
        {
            buttonColorPicker.Visible = true;
        }
    }

   

    /// <summary>
    /// Shows a dialog with a text entry box.
    /// </summary>
    /// <returns>String if OK, null if cancelled</returns>
    public static string? Prompt(string title = "Input text", string info = "", bool showColorPicker = false, string[]? illegalCharacters = null)
    {
        Debug.WriteLine($"Spawning prompt");
        List<string> result = PromptMultiple(1, title, info, showColorPicker, illegalCharacters);
        if (result.Count < 1) return null;
        return result.First();
    }

    public static List<string> PromptMultiple(int amount = 2, string title = "Input text", string info = "", bool showColorPicker = false, string[]? illegalCharacters = null)
    {
        //TextPrompt textPrompt = new(amount, title, info, showColorPicker, illegalCharacters);
        List<PromptTextBoxConfig> promptconfigs = [];
        for (int i = 0; i < amount; i++)
        {
            promptconfigs.Add(new PromptTextBoxConfig(1, $"Input {i}:", "", illegalCharacters));
        }
        TextPrompt textPrompt = new(promptconfigs, title, "");
        foreach (PromptTextBoxConfig cfg in promptconfigs)
        {
            textPrompt.Controls.Add(cfg.label);
            textPrompt.Controls.Add(cfg.textbox);
        }
        textPrompt.UpdateControls();

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
        Debug.WriteLine($"Assemble prompt result from {textBoxes.Count} textboxes");
        TextResult.Clear();
        foreach (TextBox box in textBoxes)
        {
            Debug.WriteLine($"   Adding {box.Text}");
            TextResult.Add(box.Text);
        }
    }

    private void TextPrompt_Load(object sender, EventArgs e)
    {
        SetForegroundWindow(Handle);
        if (textBoxes.Count > 0)
        {
            this.ActiveControl = textBoxes.FirstOrDefault();
        }
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
        //if (e.KeyChar == (char)Keys.Escape)
        //{
        //    //TextResult = string.Empty;
        //    DialogResult = DialogResult.Cancel;
        //    e.Handled = true;
        //}
    }

    private void Form_KeyPress(object sender, KeyPressEventArgs e)
    {
        Debug.WriteLine($"Prompt form keypress");
        if (e.KeyChar == (char)Keys.Escape)
        {
            Debug.WriteLine($"Cancel prompt form");
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
            textBoxes.First().BackColor = ColorPicked;
        }
    }

    private void TextBox_TextChanged(object sender, EventArgs e)
    {
        Debug.WriteLine($"Textbox text changed");
        TextBox textbox = (TextBox)sender;
        if (textbox.Tag == null)
        {
            Debug.WriteLine($"   Textbox tag is null");
            return;
        }
        if ((textbox.Tag.GetType() == typeof(string[])) == false)
        {
            Debug.WriteLine($"   Textbox tag is not a string array");
            return;
        }
        string[]? illegalChars = (string[]?)textbox.Tag;
        if (illegalChars == null) return;
        if (illegalChars.Length == 0) return;
        if (textBoxes.Count < 1) return;
        string text = textbox.Text;
        bool illegalFound = false;
        foreach (string illegal in illegalChars)
        {
            if (text.Contains(illegal))
            {
                illegalFound = true;
            }
        }
        buttonOK.Enabled = !illegalFound;
        if (illegalFound)
        {
            Debug.WriteLine($"Found Illegal chars");
            toolTipIllegal.ShowAlways = true;
            toolTipIllegal.Show("You can't include these characters: " + ArrayToString(illegalChars), textbox);
        }
        else
        {
            Debug.WriteLine($"NO Illegal chars");
            toolTipIllegal.ShowAlways = true;
            toolTipIllegal.Hide(textbox);
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
