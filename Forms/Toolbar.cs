using ClipboardTool.Properties;
using System.ComponentModel;
using System.Runtime.Versioning;

namespace ClipboardTool;
[SupportedOSPlatform("windows")]

public partial class Toolbar : Form
{
    public MainForm mainform;
    private bool borderLess = false;
    private bool alwaysOnTop = true;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Toolbar(MainForm parent)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        InitializeComponent();
        mainform = parent;
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        string tooltipText = "...";
        if (button1 != null) toolTip1.SetToolTip(button1, tooltipText);
        if (button2 != null) toolTip1.SetToolTip(button2, tooltipText);
        if (button3 != null) toolTip1.SetToolTip(button3, tooltipText);
        Icon = Resources.cbtIcon; // did it this way to avoid null warning when set via Designer
    }

    private void ActionToolbarClose(object sender, EventArgs e)
    {
        mainform.Show();
        this.Close();
    }

    public void ShowForm()
    {
        Show();
    }

    private void ActionBorderToggle(object? sender, EventArgs e)
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

    private void ActionAlwaysOnTop(object? sender, EventArgs e)
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

    private void ActionLower(object? sender, EventArgs e)
    {
        if (sender != null) mainform.ActionLowerCaseOnce(sender, e);
    }

    private void ActionUpper(object? sender, EventArgs e)
    {
        if (sender != null) mainform.ActionUpperCaseOnce(sender, e);
    }

    private void ActionPlain(object? sender, EventArgs e)
    {
        if (sender != null) mainform.ActionPlainTextOnce(sender, e);
    }

    private void ActionProcess(object? sender, EventArgs e)
    {
        if (sender != null) mainform.ActionProcessText(sender, e);
    }

    private void Saveload1(object? sender, MouseEventArgs e)
    {
        SaveLoad(1, e);
    }

    private void Saveload2(object? sender, MouseEventArgs e)
    {
        SaveLoad(2, e);
    }
    private void Saveload3(object? sender, MouseEventArgs e)
    {
        SaveLoad(3, e);
    }

    private void SaveLoad(int num, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            mainform.Main.SetClipboardFromTextBox(num);
        }
        if (e.Button == MouseButtons.Right)
        {
            mainform.Main.SetTextBoxFromClipboard(num);
        }
    }

    private void UpdateTooltip(Button button, int num)
    {
        toolTip1.SetToolTip(button, "Left Click to load to clipboard\nRight Click to save clipboard to this slot\n\n" + mainform.MemorySlotText(num));
    }

    private void UpdateTooltip1(object? sender, EventArgs e)
    {
        UpdateTooltip(button1, 1);
    }

    private void UpdateTooltip2(object? sender, EventArgs e)
    {
        UpdateTooltip(button2, 2);
    }

    private void UpdateTooltip3(object? sender, EventArgs e)
    {
        UpdateTooltip(button3, 3);
    }

    private void UpdateTooltipLower(object? sender, EventArgs e)
    {
        toolTip1.SetToolTip(buttonLower, "Converts clipboard text to lower case");
    }

    private void UpdateTooltipUpper(object? sender, EventArgs e)
    {
        toolTip1.SetToolTip(buttonUpper, "Converts clipboard text to upper case");
    }

    private void UpdateTooltipPlain(object? sender, EventArgs e)
    {
        toolTip1.SetToolTip(buttonPlain, "Converts clipboard text to plain text");
    }

    private void UpdateTooltipProcess(object? sender, EventArgs e)
    {
        toolTip1.SetToolTip(buttonProcess, "Updates clipboard using values from the main window Process text box");
    }

    private void UpdateTooltipHistory(object? sender, EventArgs e)
    {
        toolTip1.SetToolTip(buttonHistory, "Show the History panel");
    }

    private Button buttonPin;
    private Button buttonhide;
    private Button button1;
    private Button button2;
    private Button button3;
    private Button buttonProcess;
    private Button buttonPlain;
    private Button buttonUpper;
    private Button buttonLower;
    //private object resources;

    private void InitializeComponent()
    {
        components = new Container();
        buttonPin = new Button();
        buttonhide = new Button();
        button1 = new Button();
        button2 = new Button();
        button3 = new Button();
        buttonProcess = new Button();
        buttonPlain = new Button();
        buttonUpper = new Button();
        buttonLower = new Button();
        toolTip1 = new ToolTip(components);
        buttonHistory = new Button();
        SuspendLayout();
        // 
        // buttonPin
        // 
        buttonPin.Location = new Point(211, 1);
        buttonPin.Name = "buttonPin";
        buttonPin.Size = new Size(23, 23);
        buttonPin.TabIndex = 10;
        buttonPin.Text = "📌";
        buttonPin.UseVisualStyleBackColor = true;
        buttonPin.Click += ActionAlwaysOnTop;
        // 
        // buttonhide
        // 
        buttonhide.Location = new Point(189, 1);
        buttonhide.Name = "buttonhide";
        buttonhide.Size = new Size(23, 23);
        buttonhide.TabIndex = 11;
        buttonhide.Text = "—";
        buttonhide.UseVisualStyleBackColor = true;
        buttonhide.Click += ActionBorderToggle;
        // 
        // button1
        // 
        button1.Location = new Point(93, 1);
        button1.Name = "button1";
        button1.Size = new Size(23, 23);
        button1.TabIndex = 12;
        button1.Text = "1";
        button1.UseVisualStyleBackColor = true;
        button1.MouseHover += UpdateTooltip1;
        button1.MouseUp += Saveload1;
        // 
        // button2
        // 
        button2.Location = new Point(115, 1);
        button2.Name = "button2";
        button2.Size = new Size(23, 23);
        button2.TabIndex = 13;
        button2.Text = "2";
        button2.UseVisualStyleBackColor = true;
        button2.MouseHover += UpdateTooltip2;
        button2.MouseUp += Saveload2;
        // 
        // button3
        // 
        button3.Location = new Point(137, 1);
        button3.Name = "button3";
        button3.Size = new Size(23, 23);
        button3.TabIndex = 14;
        button3.Text = "3";
        button3.UseVisualStyleBackColor = true;
        button3.MouseHover += UpdateTooltip3;
        button3.MouseUp += Saveload3;
        // 
        // buttonProcess
        // 
        buttonProcess.Location = new Point(71, 1);
        buttonProcess.Name = "buttonProcess";
        buttonProcess.Size = new Size(23, 23);
        buttonProcess.TabIndex = 15;
        buttonProcess.Text = "$";
        buttonProcess.UseVisualStyleBackColor = true;
        buttonProcess.Click += ActionProcess;
        buttonProcess.MouseHover += UpdateTooltipProcess;
        // 
        // buttonPlain
        // 
        buttonPlain.Location = new Point(45, 1);
        buttonPlain.Name = "buttonPlain";
        buttonPlain.Size = new Size(23, 23);
        buttonPlain.TabIndex = 16;
        buttonPlain.Text = "t";
        buttonPlain.UseVisualStyleBackColor = true;
        buttonPlain.Click += ActionPlain;
        buttonPlain.MouseHover += UpdateTooltipPlain;
        // 
        // buttonUpper
        // 
        buttonUpper.Location = new Point(23, 1);
        buttonUpper.Name = "buttonUpper";
        buttonUpper.Size = new Size(23, 23);
        buttonUpper.TabIndex = 17;
        buttonUpper.Text = "A";
        buttonUpper.UseVisualStyleBackColor = true;
        buttonUpper.Click += ActionUpper;
        buttonUpper.MouseHover += UpdateTooltipUpper;
        // 
        // buttonLower
        // 
        buttonLower.Location = new Point(1, 1);
        buttonLower.Name = "buttonLower";
        buttonLower.Size = new Size(23, 23);
        buttonLower.TabIndex = 18;
        buttonLower.Text = "a";
        buttonLower.UseVisualStyleBackColor = true;
        buttonLower.Click += ActionLower;
        buttonLower.MouseHover += UpdateTooltipLower;
        // 
        // buttonHistory
        // 
        buttonHistory.Location = new Point(163, 1);
        buttonHistory.Name = "buttonHistory";
        buttonHistory.Size = new Size(23, 23);
        buttonHistory.TabIndex = 19;
        buttonHistory.Text = "H";
        buttonHistory.UseVisualStyleBackColor = true;
        buttonHistory.Click += ButtonHistory_Click;
        buttonHistory.MouseHover += UpdateTooltipHistory;
        // 
        // Toolbar
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(235, 25);
        Controls.Add(buttonHistory);
        Controls.Add(buttonLower);
        Controls.Add(buttonUpper);
        Controls.Add(buttonPlain);
        Controls.Add(buttonProcess);
        Controls.Add(button3);
        Controls.Add(button2);
        Controls.Add(button1);
        Controls.Add(buttonhide);
        Controls.Add(buttonPin);
        Name = "Toolbar";
        Text = "Toolbar";
        TopMost = true;
        ResumeLayout(false);
    }

    private void ButtonHistory_Click(object? sender, EventArgs e)
    {
        mainform.ShowTextLibrary();
    }
}
