using ClipboardTool.Properties;
using System.Diagnostics;

namespace ClipboardTool
{
    public partial class TextHistory : Form
    {
        private int checkboxColumnIndex = 0;
        private int titleColumnIndex = 1;
        private int textColumnIndex = 2;
        private int buttonColumnIndex = 3;
        MainForm mainForm;
        string colorTag = "//Color:";
        List<KeyValuePair<string, string[]>> historyEntries = new List<KeyValuePair<string, string[]>>();

        public TextHistory(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            LoadHistoryFiles();
            checkBoxMinimize.Checked = Settings.Default.HistoryMinimizeAfterCopy;
        }

        private string historyFolder
        {
            get
            {
                return Environment.ExpandEnvironmentVariables(Settings.Default.HistoryFolder);
                //return Path.Join(Environment.ExpandEnvironmentVariables(Settings.Default.MemorySlotFolder), "History");
            }
        }

        private bool CheckOrCreateHistoryFolder(bool createIfMissing)
        {
            if (!Directory.Exists(historyFolder) && createIfMissing)
            {
                try
                {
                    Directory.CreateDirectory(historyFolder);
                }
                catch
                {
                    Debug.WriteLine("Could not create folder for history text: " + historyFolder);
                }
            }
            return Directory.Exists(historyFolder);
        }

        private void PromptCreateHistoryFolder()
        {
            if (!CheckOrCreateHistoryFolder(false))
            {
                DialogResult createFolder = MessageBox.Show("Couldn't find History folder." + Environment.NewLine +
                    "Do you want to create " + historyFolder + "?" + Environment.NewLine +
                    "(You can set a different folder name in Options)"
                    , "Create History folder?"
                    , MessageBoxButtons.YesNo);

                if (createFolder == DialogResult.Yes)
                    CheckOrCreateHistoryFolder(true);
            }
        }

        private void LoadHistoryFiles()
        {
            PromptCreateHistoryFolder();
            if (CheckOrCreateHistoryFolder(false))
            {
                foreach (string file in Directory.GetFiles(historyFolder))
                {
                    if (File.Exists(file))
                    {
                        Debug.WriteLine("Loading file: " + file);
                        string[] entryText = File.ReadAllLines(file);
                        historyEntries.Add(new KeyValuePair<string, string[]>(file, entryText));
                    }
                    else
                    {
                        Debug.WriteLine("Couldn't load file: " + file);
                    }
                }
            }
            else
            {
                Debug.WriteLine("Could not locate or create folder for history text: " + historyFolder + Environment.NewLine + "Set the folder in Options");
            }
            gridHistory.Rows.Clear();
            int countRows = 0;
            foreach (KeyValuePair<string, string[]> entry in historyEntries)
            {
                Color c = Color.White;
                int tagCount = 0;
                if (entry.Value[0].Length > 0)
                {
                    if (entry.Value[0].Contains(colorTag))
                    {
                        c = ParseColor(entry.Value[0].Substring(colorTag.Length));

                        tagCount++;
                    }
                }
                string textWithoutTags = string.Empty;
                for (int i = tagCount; i < entry.Value.Length; i++)
                {
                    textWithoutTags += entry.Value[i];
                    if (i < entry.Value.Length - 1)
                        textWithoutTags += Environment.NewLine;
                }
                gridHistory.Rows.Add(true, Path.GetFileNameWithoutExtension(entry.Key), textWithoutTags);
                SetEntryColor(countRows, c);
                countRows++;
            }
        }

        private void SetEntryColor(int rowIndex, Color color)
        {
            DataGridViewRow row = gridHistory.Rows[rowIndex];
            if (row != null)
            {
                if (row.Cells[1] != null)
                {
                    row.Cells[titleColumnIndex].Style.BackColor = color;
                    row.Cells[textColumnIndex].Style.BackColor = MixColor(color, Color.White, 0.5f);
                }
            }
            //SaveEntry()
        }

        public static Color MixColor(Color color1, Color color2, float mix = 0.5f)
        {
            int R = (int)Lerp(color1.R, color2.R, mix);
            int G = (int)Lerp(color1.G, color2.G, mix);
            int B = (int)Lerp(color1.B, color2.B, mix);
            return Color.FromArgb(R, G, B);
        }

        public static float Lerp(float firstFloat, float secondFloat, float by)
        {
            return firstFloat * (1 - by) + secondFloat * by;
        }

        private Color ParseColor(string text)
        {
            string[] rgbText = text.Split(',');
            int[] rgbValues = new int[3] { 255, 255, 255 };
            rgbValues[0] = int.Parse(rgbText[0]);
            rgbValues[1] = int.Parse(rgbText[1]);
            rgbValues[2] = int.Parse(rgbText[2]);
            Color color = Color.FromArgb(rgbValues[0], rgbValues[1], rgbValues[2]);
            return color;
        }

        private bool SaveEntry(string? filename, string? text, Color? color)
        {
            if (filename == null || text == null) return false;
            if (filename.Length == 0) return false;
            string path = Path.Join(historyFolder, filename + ".txt");
            PromptCreateHistoryFolder();
            try
            {
                if (CheckOrCreateHistoryFolder(false))
                {
                    if (color != null)
                    {
                        int[] colorRGB = { color.Value.R, color.Value.G, color.Value.B };
                        string colorInfo = "//Color:" + colorRGB[0] + "," + colorRGB[1] + "," + colorRGB[2];

                        text = colorInfo + Environment.NewLine + text;
                    }


                    File.WriteAllText(path, text);
                    Debug.WriteLine("Saved entry to: " + path);
                    return true;
                }
                else
                {
                    Debug.WriteLine("Failed to save entry to: " + path);
                    return false;
                }
            }
            catch
            {
                Debug.WriteLine("Exception: Failed to save entry to: " + path);
                return false;
            }
        }

        private bool SaveEntry(int row)
        {
            bool result = false;
            if (gridHistory.Rows.Count > row)
            {
                if (gridHistory.Rows[row] == null) return false;
                if (gridHistory.Rows[row].Cells[titleColumnIndex] == null) return false;
                if (gridHistory.Rows[row].Cells[textColumnIndex] == null) return false;
                Debug.WriteLine("saving row" + row + ", title/text" + titleColumnIndex + "/" + textColumnIndex);

                string filename = gridHistory.Rows[row].Cells[titleColumnIndex].Value.ToString() + "";
                string text = gridHistory.Rows[row].Cells[textColumnIndex].Value.ToString() + "";
                Debug.WriteLine("   f: " + filename);
                Debug.WriteLine("   t: " + text);
                Color color = gridHistory.Rows[row].Cells[titleColumnIndex].Style.BackColor;
                result = SaveEntry(filename, text, color);
            }
            return result;
        }

        private void DeleteEntry(string? filename)
        {
            if (filename == null)
            {
                Debug.WriteLine("Can't Delete file, value is null");
                return;
            }
            try
            {
                if (Directory.Exists(historyFolder))
                {
                    string file = Path.Join(historyFolder, filename + ".txt");
                    if (File.Exists(file))
                    {
                        File.Delete(file);
                        Debug.WriteLine("Deleting file: " + file);
                    }
                    else
                    {
                        Debug.WriteLine("Can't Delete file (not found): " + file);
                    }
                }
                else
                {
                    Debug.WriteLine("Can't Delete file (not found): " + filename);
                }
            }
            catch
            {
                Debug.WriteLine("Exception: Can't Delete file : " + filename);
            }
        }

        private void buttonAddFromClipboard_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                string title = string.Empty;
                TextPrompt textPrompt = new TextPrompt("Set entry title", "Set title and click OK to pin entry." + Environment.NewLine + "Cancel adds entry but does not pin.", true, TextPrompt.IllegalFileCharacters);
                DialogResult = textPrompt.ShowDialog();
                if (DialogResult == DialogResult.OK)
                {
                    title = textPrompt.TextResult;
                    Color color = textPrompt.ColorPicked;
                    string clipboardtext = Clipboard.GetText();
                    bool saveSuccessful = false;
                    if (clipboardtext.Length > 0)
                    {
                        saveSuccessful = SaveEntry(textPrompt.TextResult, clipboardtext, color);
                    }
                    int row = gridHistory.Rows.Add(saveSuccessful, title, clipboardtext);
                    SetEntryColor(row, color);
                }
                else
                {
                    string clipboardtext = Clipboard.GetText();
                    gridHistory.Rows.Add(false, "", clipboardtext);
                }
            }
        }

        private void gridHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Load text to clipboard
            if (e.ColumnIndex == buttonColumnIndex)
            {
                string? cellText = "";
                if (gridHistory.Rows[e.RowIndex].Cells[textColumnIndex].Value != null)
                {
                    cellText = gridHistory.Rows[e.RowIndex].Cells[textColumnIndex].Value.ToString();
                }
                if (cellText != null)
                {
                    if (cellText.Length > 0)
                    {
                        string processedText = mainForm.process.ProcessTextVariables(cellText, false);
                        Clipboard.SetData(DataFormats.Text, processedText);
                        if (checkBoxMinimize.Checked)
                        {
                            this.WindowState = FormWindowState.Minimized;
                        }

                    }
                    else
                    {
                        Clipboard.Clear();
                    }
                }

            }

            // Pin or unpin (save file)
            if (e.ColumnIndex == checkboxColumnIndex)
            {
                if (gridHistory.Rows[e.RowIndex] == null)
                {
                    Debug.WriteLine("Row is null");
                    return;
                }

                DataGridViewCheckBoxCell checkboxCell = gridHistory.Rows[e.RowIndex].Cells[checkboxColumnIndex] as DataGridViewCheckBoxCell;
                if (checkboxCell == null)
                {
                    Debug.WriteLine("Checkbox cell is null");
                    return;
                }
                else
                {
                    bool oldCheckState = Convert.ToBoolean(checkboxCell.Value);
                    bool pinned = !oldCheckState;
                    if (pinned)
                    {
                        string title = string.Empty;
                        DataGridViewCellCollection cells = gridHistory.Rows[e.RowIndex].Cells;

                        if (cells[textColumnIndex].Value == null) return;

                        if (cells[titleColumnIndex].Value == null)
                        {
                            cells[titleColumnIndex].Value = string.Empty;
                        }

                        if (cells[titleColumnIndex].Value.ToString() == string.Empty)
                        {
                            TextPrompt textPrompt = new TextPrompt();
                            if (textPrompt.ShowDialog() == DialogResult.OK)
                            {
                                title = textPrompt.TextResult;
                                cells[titleColumnIndex].Value = title;
                            }
                            else
                            {
                                title = "entry " + e.RowIndex;
                                cells[titleColumnIndex].Value = title;
                            }
                        }
                        else
                        {
                            title = cells[titleColumnIndex].Value.ToString() + "";
                        }
                        string text = cells[textColumnIndex].Value.ToString() + "";
                        pinned = SaveEntry(title, text, cells[titleColumnIndex].Style.BackColor);
                    }
                    else
                    {
                        Debug.WriteLine("Unpinned. Trying to delete corresponding file");
                        DataGridViewCellCollection cells = gridHistory.Rows[e.RowIndex].Cells;
                        if (cells[titleColumnIndex].Value != null)
                            DeleteEntry(cells[titleColumnIndex].Value.ToString());
                    }
                    checkboxCell.Value = pinned;
                }

            }
        }

        private bool alwaysOnTop = false;
        private void actionAlwaysOnTop(object sender, EventArgs e)
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

        private void buttonColor_Click(object sender, EventArgs e)
        {
            ColorPicker();
        }

        private void ColorPicker()
        {
            if (gridHistory.SelectedCells.Count <= 0) return;

            DialogResult result = colorDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                Color newColor = colorDialog1.Color;
                int row = gridHistory.SelectedCells[0].RowIndex;
                SetEntryColor(row, newColor);
                SaveEntry(row);
            }
        }

        private void gridHistory_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SaveEntry(e.RowIndex);
        }
    }
}
