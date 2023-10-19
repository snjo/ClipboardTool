using ClipboardTool.Properties;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

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
        string colorFileName = @"Colors\colors.txt";
        string entryFileExtension = ".txt";
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
                    Color mixColor = MixColor(color, Color.White, 0.5f);
                    row.Cells[textColumnIndex].Style.BackColor = mixColor;

                    row.Cells[titleColumnIndex].Style.ForeColor = TextColorFromBackColor(color, 0.6f);
                    row.Cells[textColumnIndex].Style.ForeColor = TextColorFromBackColor(mixColor, 0.6f);
                }
            }
        }

        private Color TextColorFromBackColor(Color backColor, float threshold)
        {
            Color result = Color.Black;
            if (ColorValue(backColor) < threshold)
                result = Color.White;
            return result;
        }

        private float ColorValue(Color color)
        {
            // returns a value of 0-1f based on the total brightness of the input color
            //https://stackoverflow.com/questions/596216/formula-to-determine-perceived-brightness-of-rgb-color
            //https://en.wikipedia.org/wiki/Relative_luminance
            //perceived value (0.2126 * R + 0.7152 * G + 0.0722 * B)
            float pR = 0.2126f;
            float pG = 0.7152f;
            float pB = 0.0722f;
            float result = ((color.R * pR) + (color.G * pG) + (color.B * pB)) / 256f;
            return result;
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
            string path = Path.Join(historyFolder, filename + entryFileExtension);
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
                if (gridHistory.Rows[row].Cells[titleColumnIndex].Value == null) return false;
                if ((gridHistory.Rows[row].Cells[titleColumnIndex].Value.ToString() + "").Length == 0) return false;
                if (gridHistory.Rows[row].Cells[textColumnIndex] == null) return false;
                Debug.WriteLine("saving row" + row + ", title/text" + titleColumnIndex + "/" + textColumnIndex);

                string filename = gridHistory.Rows[row].Cells[titleColumnIndex].Value.ToString() + "";
                if (gridHistory.Rows[row].Cells[textColumnIndex].Value == null)
                        gridHistory.Rows[row].Cells[textColumnIndex].Value = string.Empty;
                string text = gridHistory.Rows[row].Cells[textColumnIndex].Value.ToString() + "";
                Debug.WriteLine("   f: " + filename);
                Debug.WriteLine("   t: " + text);
                Color color = gridHistory.Rows[row].Cells[titleColumnIndex].Style.BackColor;
                if (color == Color.Empty) color = Color.White;
                result = SaveEntry(filename, text, color);
                SetPinnedCheckboxValue(row, result);
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
                    string file = Path.Join(historyFolder, filename + entryFileExtension);
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
            //Debug.WriteLine("Clicked on row " + e.RowIndex);
            if (e.RowIndex == -1)
            {
                return;
            }
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
                        //string processedText = mainForm.process.ProcessTextVariables(cellText, false);
                        //Clipboard.SetData(DataFormats.Text, processedText);
                        mainForm.process.ProcessTextVariables(cellText, true);
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

                /*DataGridViewCheckBoxCell? checkboxCell = gridHistory.Rows[e.RowIndex].Cells[checkboxColumnIndex] as DataGridViewCheckBoxCell;
                if (checkboxCell == null)
                {
                    Debug.WriteLine("Checkbox cell is null");
                    return;
                }*/
                else
                {
                    //bool oldCheckState = Convert.ToBoolean(checkboxCell.Value);
                    bool oldCheckState = GetPinnedCheckboxValue(e.RowIndex);
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
                        SetPinnedCheckboxValue(e.RowIndex, false);
                    }
                    //checkboxCell.Value = pinned;
                    //SetPinnedCheckboxValue(e.RowIndex, pinned);
                }

            }
        }

        private bool GetPinnedCheckboxValue(int rowIndex)
        {
            DataGridViewCheckBoxCell? checkboxCell = gridHistory.Rows[rowIndex].Cells[checkboxColumnIndex] as DataGridViewCheckBoxCell;
            if (checkboxCell == null) checkboxCell = new DataGridViewCheckBoxCell();
            return Convert.ToBoolean(checkboxCell.Value);
        }

        private bool SetPinnedCheckboxValue(int rowIndex, bool newValue)
        {
            DataGridViewCheckBoxCell? checkboxCell = gridHistory.Rows[rowIndex].Cells[checkboxColumnIndex] as DataGridViewCheckBoxCell;
            if (checkboxCell == null) checkboxCell = new DataGridViewCheckBoxCell();
            checkboxCell.Value = newValue;
            return Convert.ToBoolean(checkboxCell.Value);
        }

        private bool TogglePinnedCheckboxValue(int rowIndex)
        {
            DataGridViewCheckBoxCell? checkboxCell = gridHistory.Rows[rowIndex].Cells[checkboxColumnIndex] as DataGridViewCheckBoxCell;
            if (checkboxCell == null) checkboxCell = new DataGridViewCheckBoxCell();
            if (checkboxCell.Value == null) checkboxCell.Value = false;
            checkboxCell.Value = !Convert.ToBoolean(checkboxCell.Value);
            return Convert.ToBoolean(checkboxCell.Value);
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



            colorDialog1.Dispose();
            colorDialog1 = new ColorDialog();
            //colorDialog1.CustomColors = new int[] { unchecked((Int32)0xAAFFFF), unchecked((Int32)0xBBFF00) };
            int[]? colors = GetSavedColors();
            if (colors != null)
                colorDialog1.CustomColors = GetSavedColors();

            DialogResult result = colorDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                Color newColor = colorDialog1.Color;
                int row = gridHistory.SelectedCells[0].RowIndex;
                SetEntryColor(row, newColor);
                SaveEntry(row);

                if (ArraysAreIdentical(colorDialog1.CustomColors, colors))
                {
                    Debug.WriteLine("Custom colors have not changed");
                }
                else
                {
                    Debug.WriteLine("Custom colors have changed, saving to file");
                    SaveColors();
                }
            }
        }

        private int[]? GetSavedColors()
        {
            List<int> colorList = new List<int>();
            string colorFilePath = Path.Join(historyFolder, colorFileName);
            if (File.Exists(colorFilePath))
            {
                string[] lines = File.ReadAllLines(colorFilePath);
                foreach (string line in lines)
                {
                    if (colorList.Count < 16)
                        colorList.Add(int.Parse(line));
                }
            }
            else
            {
                Debug.WriteLine("Could not load color file: " + colorFilePath);
            }
            return colorList.ToArray();
        }

        private bool ArraysAreIdentical(int[]? array1, int[]? array2)
        {
            if (array1 == null && array2 == null) return true;
            if (array1 == null || array2 == null) return false;
            if (array1.Length != array2.Length) return false;
            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i]) return false;
            }
            return true;
        }

        private void SaveColors()
        {
            List<string> customColors = new List<string>();
            foreach (int c in colorDialog1.CustomColors)
            {
                customColors.Add(c.ToString());
            }

            if (CheckOrCreateHistoryFolder(false))
            {
                string colorFilePath = Path.Join(historyFolder, colorFileName);
                File.WriteAllLines(colorFilePath, customColors);
            }
        }

        private void gridHistory_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SaveEntry(e.RowIndex);
        }

        private void OpenHistoryFolder(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CheckOrCreateHistoryFolder(false))
            {
                Process.Start(new ProcessStartInfo() { FileName = historyFolder, UseShellExecute = true });
            }
        }

        private void gridHistory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("Rename entry?");
            if (gridHistory.SelectedCells.Count > 0)
            {
                DataGridViewCell cell = gridHistory.SelectedCells[0];
                if (cell.ColumnIndex == titleColumnIndex)
                {
                    Debug.WriteLine("Rename entry started");
                    renameEntry(cell.RowIndex);
                }
            }
        }

        private void renameEntry(int rowIndex)
        {
            if (rowIndex > gridHistory.Rows.Count - 1)
            {
                Debug.WriteLine("rowIndex error");
                return;
            }
            DataGridViewRow gridRow = gridHistory.Rows[rowIndex];
            DataGridViewCell cell = gridHistory.Rows[rowIndex].Cells[titleColumnIndex];
            if (cell == null)
            {
                Debug.WriteLine("Cell is null");
                return;
            }

            if (cell.Value == null)
            {
                Debug.WriteLine("Cell value null, setting empty string");
                cell.Value = string.Empty;
            }

            if (cell.Value != null)
            {
                string oldTitle = cell.Value.ToString()+"";
                string? newTitle = TextPrompt.Prompt();
                if (newTitle != null)
                {
                    Debug.WriteLine("Renaming entry to: " + newTitle);
                    //delete old file
                    if (oldTitle.Length > 0)
                    {
                        string oldEntryPath = Path.Join(historyFolder, oldTitle + entryFileExtension);
                        if (File.Exists(oldEntryPath))
                        {
                            try
                            {
                                File.Delete(oldEntryPath);
                                Debug.WriteLine("Rename: Deleted old entry file " + oldEntryPath);
                            }
                            catch
                            {
                                Debug.WriteLine("Rename: Can't delete old entry file " + oldEntryPath);
                            }
                        }
                    }
                    //save new file
                    cell.Value = newTitle;
                    
                    SetPinnedCheckboxValue(rowIndex, (SaveEntry(rowIndex)));
                }
                else
                {
                    Debug.WriteLine("Rename cancelled");
                }
            }
            //string oldTitle = 
        }
    }
}
