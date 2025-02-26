using System.Diagnostics;
using System.Runtime.Versioning;

namespace ClipboardTool.Forms
{

    [SupportedOSPlatform("windows")]

    public class PromptTextBoxConfig
    {
        public string InfoLabelText = "Input:";
        public string PrefilledText = "";
        public bool Multiline = false;
        public TextBox textbox = new();
        public Label label = new();
        public Color color = Color.White;

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

        private PromptTextBoxConfig()
        {
        }

        /// <summary>
        /// Creates a configuration with included Label and Textbox for a text entry field. Add the label and textbox controls to the Form.Controls. You should run UpdateControlPositions to set the correct placement.
        /// </summary>
        /// <param name="lines">Lines/height of the textbox. Enables Multiline if above 1</param>
        /// <param name="infoLabelText">The label above the textbox</param>
        /// <param name="prefilledText">Fill the textbox with a preset value</param>
        /// <param name="illegalcharaters">Used by other methods to prevent confirming a dialog with bad characters (bad file names)</param>
        public PromptTextBoxConfig(int lines, string infoLabelText, string? prefilledText, string[]? illegalcharaters = null)
        {

            Debug.WriteLine($"Create PromptTextBoxConfig, illegalcharacters null: {illegalcharaters == null}");

            Multiline = lines > 1;
            textbox.Multiline = Multiline;
            IllegalCharacters = illegalcharaters;
            if (lines < 1) lines = 1;

            textbox.Height = lines * textbox.Font.Height;
            Debug.WriteLine($"Lines: {lines}, Font{textbox.Font.Height}, Height:{textbox.Height}");


            label.Text = infoLabelText;
            textbox.Text = prefilledText;

            InfoLabelText = infoLabelText;
            if (prefilledText != null)
            {
                PrefilledText = prefilledText;
            }

            textbox.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
        }

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