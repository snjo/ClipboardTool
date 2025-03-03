using System.Diagnostics;
using System.Runtime.Versioning;

namespace ClipboardTool;
[SupportedOSPlatform("windows")]
public partial class HelpForm : Form
{
    public HelpForm()
    {
        InitializeComponent();
    }

    private void Help_Load(object sender, EventArgs e)
    {

    }

    private void ActionClose(object sender, EventArgs e)
    {
        Hide();
    }

    public void SetText(string text)
    {
        richTextBox1.Text = "";
        if (OperatingSystem.IsWindows())
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
        richTextBox1.AppendText("Text processing commands\n\n");
        if (OperatingSystem.IsWindows())
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);

        richTextBox1.AppendText(text);

    }

    private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        string url = "https://github.com/snjo/ClipboardTool/blob/master/readme.md";
        Process.Start(new ProcessStartInfo() { FileName = url, UseShellExecute = true });
    }

    private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
    {
        if (e.LinkText == null) return;
        string url = e.LinkText;
        Process.Start(new ProcessStartInfo() { FileName = url, UseShellExecute = true });
    }
}
