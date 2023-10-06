using ClipboardTool.Properties;
using System.Diagnostics;

namespace ClipboardTool
{
    public partial class ClipboardHistory : Form
    {
        private int checkboxColumnIndex = 0;
        private int titleColumnIndex = 1;
        private int textColumnIndex = 2;
        private int buttonColumnIndex = 3;
        MainForm mainForm;
        List<KeyValuePair<string, string>> historyEntries = new List<KeyValuePair<string, string>>();

        public ClipboardHistory(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            LoadHistoryFiles();
        }

        private string historyFolder
        {
            get
            {
                return Path.Join(Settings.Default.MemorySlotFolder, "History");
            }
        }

        private bool CheckOrCreateHistoryFolder()
        {
            if (!Directory.Exists(historyFolder))
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

        private void LoadHistoryFiles()
        {
            if (CheckOrCreateHistoryFolder())
            {
                foreach (string file in Directory.GetFiles(historyFolder))
                {
                    if (File.Exists(file))
                    {
                        Debug.WriteLine("Loading file: " + file);
                        historyEntries.Add(new KeyValuePair<string, string>(file, File.ReadAllText(file)));
                    }
                    else
                    {
                        Debug.WriteLine("Couldn't load file: " + file);
                    }
                }
            }
            else
            {
                MessageBox.Show("Could not locate or create folder for history text: " + historyFolder);
            }
            foreach (KeyValuePair<string, string> entry in historyEntries)
            {
                gridHistory.Rows.Add(true, Path.GetFileNameWithoutExtension(entry.Key), entry.Value);
            }
        }

        private bool SaveEntry(string? filename, string? text)
        {
            if (filename == null || text == null) return false;
            string path = Path.Join(historyFolder, filename + ".txt");
            try
            {
                if (CheckOrCreateHistoryFolder())
                {
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
                TextPrompt textPrompt = new TextPrompt();
                DialogResult = textPrompt.ShowDialog();
                if (DialogResult == DialogResult.OK)
                {
                    title = textPrompt.TextResult;
                    string clipboardtext = Clipboard.GetText();
                    if (clipboardtext.Length > 0)
                    {
                        SaveEntry(textPrompt.TextResult, clipboardtext);
                    }
                    gridHistory.Rows.Add(true, title, clipboardtext);
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
                        //Clipboard.SetText(cellText);
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
                        pinned = SaveEntry(title, text);
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
    }
}
