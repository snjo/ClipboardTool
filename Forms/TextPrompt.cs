using ClipboardTool.Classes;
using ClipboardTool.Forms;
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
    private readonly List<TextBox> textBoxes = [];
    public Color ColorPicked = Color.White;

    public int AmountOfTextPrompts = 1;
    public string TitleText;
    public string InfoText;
    public bool ShowColorPicker;
    public string[] PromptHeadings = [];
    public bool EnterConfirmsDialog = true;
    public int DialogWidth = 350;
    public List<PromptTextBoxConfig> textPromptConfigs = [];


    /// <summary>
    /// Creates the TextPrompt object, using a list of configs
    /// </summary>
    /// <param name="configs">A list of 1-n text input fields</param>
    /// <param name="title">The form titlebar text</param>
    /// <param name="info">Text at the beginning of the form with instructions</param>
    public TextPrompt(List<PromptTextBoxConfig> configs, string title, string info, Color color, bool enterConfirmsDialog)
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
            if (cfg.Multiline)
            {
                // if Enter confirms, multiline entry can't happen, therefore disabling it regardless of the argument.
                enterConfirmsDialog = false;
            }
        }

        buttonColorPicker.BackColor = color;
        ColorPicked = color;
        buttonColorPicker.ForeColor = ColorHelpers.TextColorFromBackColor(color);

        UpdateControls();
        Debug.WriteLine($"show color picker: {ShowColorPicker}");
        EnterConfirmsDialog = enterConfirmsDialog;
    }

    public void UpdateControls()
    {
        int controlsLeft = 5;
        int controlsWidth = this.Width - 25;
        int previousBottom = labelInfo.Bottom;
        if (labelInfo.Text == "")
        {
            previousBottom = labelInfo.Top;
            labelInfo.Visible = false;
        }
        else
        {
            labelInfo.Visible = true;
        }

        foreach (PromptTextBoxConfig cfg in textPromptConfigs)
        {
            cfg.UpdateControlPositions(controlsLeft, previousBottom + 5, controlsWidth);
            previousBottom = cfg.GetBottom();
            Debug.WriteLine($"Form height {this.Height} to: {previousBottom + 30}");
            this.Height = previousBottom + 75;
            Debug.WriteLine($"Form height {this.Height}");
        }

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
        List<string>? result = PromptMultiple(1, title, info, showColorPicker, illegalCharacters);
        if (result == null) return null;
        if (result.Count < 1) return null;
        return result.First();
    }

    public static List<string>? PromptMultiple(int amount = 2, string title = "Input text", string info = "", bool showColorPicker = false, string[]? illegalCharacters = null, bool enterConfirmsDialog = true)
    {
        List<PromptTextBoxConfig> promptconfigs = [];
        for (int i = 0; i < amount; i++)
        {
            promptconfigs.Add(new PromptTextBoxConfig(1, $"Input {i}:", "", illegalCharacters));
        }
        TextPrompt textPrompt = new(promptconfigs, title, info, Color.White, enterConfirmsDialog)
        {
            ShowColorPicker = showColorPicker
        };

        DialogResult promptResult = textPrompt.ShowDialog();
        if (promptResult == DialogResult.OK)
        {
            Debug.WriteLine("Prompt result: " + textPrompt.TextResult.Count);
            List<string> textResult = textPrompt.TextResult;
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
        DialogResult = DialogResult.OK;
    }

    private void ButtonCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
    }

    private void Form_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            bool forceConfirm = false;
            if (e.Modifiers == Keys.Control)
            {
                forceConfirm = true;
            }
            HandleEnterKeyPress(e, forceConfirm);
        }

        if (e.KeyCode == Keys.Escape)
        {
            Debug.WriteLine($"Escape pressed, cancel prompt form");
            DialogResult = DialogResult.Cancel;
            e.Handled = true;
        }
    }

    private void HandleEnterKeyPress(KeyEventArgs e, bool forceConfirm)
    {
        // forceConfirm is true if user pressed Control+Enter
        if ((forceConfirm || EnterConfirmsDialog) && buttonOK.Enabled)
        {
            Debug.WriteLine($"Enter pressed, confirming dialog");
            AssembleResult();
            DialogResult = DialogResult.OK;
        }

        if (EnterConfirmsDialog)
        {
            e.Handled = true; // stops ding sound when pressing enter in a single line text box. Allow dings if EnterConfirmsDialog is false.
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
            //textBoxes.First().BackColor = ColorPicked;
            buttonColorPicker.BackColor = ColorPicked;
            buttonColorPicker.ForeColor = ColorHelpers.TextColorFromBackColor(ColorPicked);
        }
    }

    private void TextBox_TextChanged(object? sender, EventArgs e)
    {
        if (sender == null) return;
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
