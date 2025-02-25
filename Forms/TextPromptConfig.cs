using System.Diagnostics;
using System.Runtime.Versioning;

namespace ClipboardTool
{

    [SupportedOSPlatform("windows")]

    public class PromptTextBoxConfig
    {
        //public int TextboxWidth = 300;
        //public int TextboxHeight = 23;
        public string InfoLabelText = "Input:";
        public string PrefilledText = "";
        public bool Multiline = false;
        public TextBox textbox = new();
        public Label label = new();

        private string[]? _illegalChars = null;
        public string[]? IllegalCharacters
        {
            get
            {
                return _illegalChars;
            }
            set
            {
                Debug.WriteLine($"Textbox illegalcharacters set, null: {value == null}");
                textbox.Tag = value;
                _illegalChars = value;
            }
        }

        public PromptTextBoxConfig()
        {
        }

        public PromptTextBoxConfig(int lines, string infoLabelText, string? prefilledText, string[]? illegalcharaters = null)
        {
            //parent.Controls.Add(label);
            //parent.Controls.Add(textbox);
            Debug.WriteLine($"Create PromptTextBoxConfig, illegalcharacters null: {illegalcharaters == null}");

            Multiline = lines > 1;
            textbox.Multiline = Multiline;
            IllegalCharacters = illegalcharaters;
            if (lines < 1) lines = 1;

            textbox.Height = lines * textbox.Font.Height;
            Debug.WriteLine($"Lines: {lines}, Font{textbox.Font.Height}, Height:{textbox.Height}");

            //label.Width = textboxWidth;
            //textbox.Width = textboxWidth;

            //label.Left = left;
            //textbox.Left = left;

            //label.Top = top;
            //textbox.Top = top + label.Height + 1;

            label.Text = infoLabelText;
            textbox.Text = prefilledText;

            InfoLabelText = infoLabelText;
            if (prefilledText != null)
            {
                PrefilledText = prefilledText;
            }
        }

        //public PromptTextBoxConfig(int top, int left, int textboxWidth, int lines, string infoLabelText, string prefilledText, string[]? illegalcharaters = null)
        //{
        //    //parent.Controls.Add(label);
        //    //parent.Controls.Add(textbox);

        //    Multiline = lines > 1;
        //    textbox.Multiline = Multiline;
        //    IllegalCharacters = illegalcharaters;
        //    if (lines < 1) lines = 1;

        //    textbox.Height = lines * textbox.Font.Height;
        //    Debug.WriteLine($"Lines: {lines}, Font{textbox.Font.Height}, Height:{textbox.Height}");

        //    label.Width = textboxWidth;
        //    textbox.Width = textboxWidth;

        //    label.Left = left;
        //    textbox.Left = left;

        //    label.Top = top;
        //    textbox.Top = top + label.Height + 1;

        //    label.Text = infoLabelText;
        //    textbox.Text = prefilledText;

        //    InfoLabelText = infoLabelText;
        //    PrefilledText = prefilledText;
            
        //}

        public int GetBottom()
        {
            return textbox.Bottom;
        }

        public void UpdateControlPositions(int left, int top, int width)
        {
            label.Left = left;
            label.Width = width;
            label.Top = top;

            textbox.Left = left;
            textbox.Width = width;
            textbox.Top = label.Bottom;
        }
    }
}