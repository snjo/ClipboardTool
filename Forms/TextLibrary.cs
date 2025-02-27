using ClipboardTool.Classes;
using ClipboardTool.Forms;
using ClipboardTool.Properties;
using DebugTools;
using System.Diagnostics;
using System.Runtime.Versioning;
using static System.Net.Mime.MediaTypeNames;

namespace ClipboardTool;
[SupportedOSPlatform("windows")]

public partial class TextLibrary : Form
{
    private readonly int checkboxColumnIndex = 0;
    private readonly int titleColumnIndex = 1;
    private readonly int textColumnIndex = 2;
    private readonly int buttonColumnIndex = 3;
    readonly MainForm mainForm;
    readonly string colorTag = "//Color:";
    readonly string colorFolder = "Colors";
    readonly string colorFileName = "colors.txt";
    readonly string entryFileExtension = ".txt";
    readonly List<KeyValuePair<string, string[]>> TextLibraryEntries = [];

    public TextLibrary(MainForm mainForm)
    {
        InitializeComponent();
        this.mainForm = mainForm;
        LoadTextLibraryFiles();
        checkBoxMinimize.Checked = Settings.Default.HistoryMinimizeAfterCopy;
    }

    private static string TextLibraryFolder
    {
        get
        {
            return Environment.ExpandEnvironmentVariables(Settings.Default.HistoryFolder);
        }
    }

    private static bool CheckOrCreateTextLibraryFolder(bool createIfMissing)
    {
        if (!Directory.Exists(TextLibraryFolder) && createIfMissing)
        {
            try
            {
                Directory.CreateDirectory(TextLibraryFolder);
            }
            catch
            {
                Dbg.WriteWithCaller("Could not create folder for TextLibrary text: " + TextLibraryFolder);
            }
        }
        return Directory.Exists(TextLibraryFolder);
    }

    private static void PromptCreateTextLibraryFolder()
    {
        if (!CheckOrCreateTextLibraryFolder(false))
        {
            DialogResult createFolder = MessageBox.Show("Couldn't find Text Library folder." + Environment.NewLine +
                "Do you want to create " + TextLibraryFolder + "?" + Environment.NewLine +
                "(You can set a different folder name in Options)"
                , "Create Text Library folder?"
                , MessageBoxButtons.YesNo);

            if (createFolder == DialogResult.Yes)
                CheckOrCreateTextLibraryFolder(true);
        }
    }

    private void LoadTextLibraryFiles()
    {
        PromptCreateTextLibraryFolder();
        if (CheckOrCreateTextLibraryFolder(false))
        {
            foreach (string file in Directory.GetFiles(TextLibraryFolder))
            {
                if (File.Exists(file))
                {
                    Dbg.WriteWithCaller("Loading file: " + file);
                    string[] entryText = File.ReadAllLines(file);
                    TextLibraryEntries.Add(new KeyValuePair<string, string[]>(file, entryText));
                }
                else
                {
                    Dbg.WriteWithCaller("Couldn't load file: " + file);
                }
            }
        }
        else
        {
            Dbg.WriteWithCaller("Could not locate or create folder for TextLibrary text: " + TextLibraryFolder + Environment.NewLine + "Set the folder in Options");
        }
        gridTextLibrary.Rows.Clear();
        int countRows = 0;
        foreach (KeyValuePair<string, string[]> entry in TextLibraryEntries)
        {
            Color c = Color.White;
            int tagCount = 0;
            if (entry.Value[0].Length > 0)
            {
                if (entry.Value[0].Contains(colorTag))
                {
                    c = ColorHelpers.ParseColor(entry.Value[0][colorTag.Length..]);

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
            gridTextLibrary.Rows.Add(true, Path.GetFileNameWithoutExtension(entry.Key), textWithoutTags);
            SetEntryColor(countRows, c);
            countRows++;
        }
    }

    private void SetEntryColor(int rowIndex, Color color)
    {
        DataGridViewRow row = gridTextLibrary.Rows[rowIndex];
        if (row != null)
        {
            if (row.Cells[1] != null)
            {
                row.Cells[titleColumnIndex].Style.BackColor = color;
                Color mixColor = ColorHelpers.MixColor(color, Color.White, 0.5f);
                row.Cells[textColumnIndex].Style.BackColor = mixColor;

                row.Cells[titleColumnIndex].Style.ForeColor = ColorHelpers.TextColorFromBackColor(color, 0.6f);
                row.Cells[textColumnIndex].Style.ForeColor = ColorHelpers.TextColorFromBackColor(mixColor, 0.6f);
            }
        }
    }

    private bool SaveEntry(string? filename, string? text, Color? color)
    {
        if (filename == null || text == null) return false;
        filename = filename.Trim();
        if (filename.Length == 0) return false;
        if (color == Color.Empty) color = Color.White;
        string path = Path.Join(TextLibraryFolder, filename + entryFileExtension);
        PromptCreateTextLibraryFolder();
        try
        {
            if (CheckOrCreateTextLibraryFolder(false))
            {
                if (color != null)
                {
                    int[] colorRGB = [color.Value.R, color.Value.G, color.Value.B];
                    string colorInfo = "//Color:" + colorRGB[0] + "," + colorRGB[1] + "," + colorRGB[2];

                    text = colorInfo + Environment.NewLine + text;
                }

                File.WriteAllText(path, text);
                Dbg.WriteWithCaller("Saved entry to: " + path);
                return true;
            }
            else
            {
                Dbg.WriteWithCaller("Failed to save entry to: " + path);
                return false;
            }
        }
        catch
        {
            Dbg.WriteWithCaller("Exception: Failed to save entry to: " + path);
            return false;
        }
    }

    private bool SaveEntry(int row)
    {
        bool result = false;
        if (gridTextLibrary.Rows.Count > row)
        {
            if (gridTextLibrary.Rows[row] == null) return false;
            if (gridTextLibrary.Rows[row].Cells[titleColumnIndex] == null) return false;
            if (gridTextLibrary.Rows[row].Cells[titleColumnIndex].Value == null) return false;
            if ((gridTextLibrary.Rows[row].Cells[titleColumnIndex].Value.ToString() + "").Length == 0) return false;
            if (gridTextLibrary.Rows[row].Cells[textColumnIndex] == null) return false;

            string filename = gridTextLibrary.Rows[row].Cells[titleColumnIndex].Value.ToString() + "";
            if (gridTextLibrary.Rows[row].Cells[textColumnIndex].Value == null)
                gridTextLibrary.Rows[row].Cells[textColumnIndex].Value = string.Empty;
            string text = gridTextLibrary.Rows[row].Cells[textColumnIndex].Value.ToString() + "";
            Dbg.WriteWithCaller("Saving: " + filename);
            Color color = GetRowColor(row);
            result = SaveEntry(filename, text, color);
            SetPinnedCheckboxValue(row, result);
        }
        return result;
    }

    private Color GetRowColor(int row)
    {
        return gridTextLibrary.Rows[row].Cells[titleColumnIndex].Style.BackColor;
    }

    private void DeleteEntry(string? filename)
    {
        if (filename == null)
        {
            Dbg.WriteWithCaller("Can't Delete file, value is null");
            return;
        }
        try
        {
            if (Directory.Exists(TextLibraryFolder))
            {
                string file = Path.Join(TextLibraryFolder, filename + entryFileExtension);
                if (File.Exists(file))
                {
                    File.Delete(file);
                    Dbg.WriteWithCaller("Deleting file: " + file);
                }
                else
                {
                    Dbg.WriteWithCaller("Can't Delete file (not found): " + file);
                }
            }
            else
            {
                Dbg.WriteWithCaller("Can't Delete file (not found): " + filename);
            }
        }
        catch
        {
            Dbg.WriteWithCaller("Exception: Can't Delete file : " + filename);
        }
    }

    private static TextPrompt UpdateTextEntryPrompt(string dialogHeading, string info, string titleText, string? contentsText, Color color)
    {
        List<PromptTextBoxConfig> promptConfig = [];
        promptConfig.Add(new PromptTextBoxConfig(1, "Title", titleText, TextPrompt.IllegalFileCharacters));
        PromptTextBoxConfig contentsCfg = new(10, "Contents", contentsText, null);
        contentsCfg.textbox.ScrollBars = ScrollBars.Vertical;
        
        promptConfig.Add(contentsCfg);

        TextPrompt textPrompt = new(promptConfig, dialogHeading, info, color)
        {
            ShowColorPicker = true,
        };

        textPrompt.textPromptConfigs.Last().textbox.Anchor |= AnchorStyles.Bottom;

        return textPrompt;
    }

    private void ButtonAddFromClipboard_Click(object sender, EventArgs e)
    {
        string clipboardtext = string.Empty;
        if (Clipboard.ContainsText())
        {
            clipboardtext = Clipboard.GetText();
        }

        string title;

        Debug.WriteLine($"Adding new from clipboard");

        //List<PromptTextBoxConfig> promptConfig = [];
        //promptConfig.Add(new PromptTextBoxConfig(1, "Title", "", TextPrompt.IllegalFileCharacters));
        //promptConfig.Add(new PromptTextBoxConfig(5, "Contents", clipboardtext, null));

        //TextPrompt textPrompt = new(promptConfig, "Add new from clipboard", "Set title and click OK to pin entry." + Environment.NewLine + "Cancel adds entry but does not pin.")
        //{
        //    ShowColorPicker = true,

        //};

        TextPrompt textPrompt = UpdateTextEntryPrompt("Add new from clipboard", 
            "Set title and click OK to save entry.", 
            "", clipboardtext, Color.White);

        DialogResult promptResult = textPrompt.ShowDialog();
        if (promptResult == DialogResult.OK)
        {
            title = textPrompt.TextResult.First();
            Color color = textPrompt.ColorPicked;

            bool saveSuccessful = false;
            if (clipboardtext.Length > 0)
            {
                saveSuccessful = SaveEntry(textPrompt.TextResult.First(), clipboardtext, color);
            }
            int row = gridTextLibrary.Rows.Add(saveSuccessful, title, clipboardtext);
            SetEntryColor(row, color);
        }
        //else
        //{
        //    gridTextLibrary.Rows.Add(false, "", clipboardtext);
        //}
    }


    private void RenameEntry(int rowIndex)
    {
        if (rowIndex > gridTextLibrary.Rows.Count - 1)
        {
            Dbg.WriteWithCaller("rowIndex error");
            return;
        }

        DataGridViewCell titleCell = gridTextLibrary.Rows[rowIndex].Cells[titleColumnIndex];
        if (titleCell == null)
        {
            Dbg.WriteWithCaller("Cell is null");
            return;
        }

        if (titleCell.Value == null)
        {
            Dbg.WriteWithCaller("Cell value null, setting empty string");
            titleCell.Value = string.Empty;
        }

        if (titleCell.Value != null)
        {
            string oldTitle = titleCell.Value.ToString() + "";
            DataGridViewCell contentCell = gridTextLibrary.Rows[rowIndex].Cells[textColumnIndex];
            string contents = contentCell.Value.ToString() + "";
            TextPrompt textPrompt = UpdateTextEntryPrompt("Edit Text", "Update title and contents", oldTitle, contents, GetRowColor(rowIndex));
            DialogResult promptResult = textPrompt.ShowDialog();
            if (promptResult != DialogResult.OK) return;

            string newTitle = textPrompt.TextResult[0].Trim();
            string newContent = textPrompt.TextResult[1];

            //update contents
            contentCell.Value = newContent;

            //update color
            SetEntryColor(rowIndex, textPrompt.ColorPicked);

            Dbg.WriteWithCaller("Renaming entry to: " + newTitle);

            //delete old file
            if (oldTitle.Length > 0)
            {
                string oldEntryPath = Path.Join(TextLibraryFolder, oldTitle + entryFileExtension);
                if (File.Exists(oldEntryPath))
                {
                    try
                    {
                        File.Delete(oldEntryPath);
                        Dbg.WriteWithCaller("Rename: Deleted old entry file " + oldEntryPath);
                    }
                    catch
                    {
                        Dbg.WriteWithCaller("Rename: Can't delete old entry file " + oldEntryPath);
                    }
                }
            }

            //save new file
            titleCell.Value = newTitle;

            SetPinnedCheckboxValue(rowIndex, (SaveEntry(rowIndex)));

        }
    }

    private void GridTextLibrary_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex == -1)
        {
            return;
        }
        // Load text to clipboard
        if (e.ColumnIndex == buttonColumnIndex)
        {
            ClickCopyButton(e);
        }

        // Pin or unpin (save file)
        if (e.ColumnIndex == checkboxColumnIndex)
        {
            ClickCheckbox(e);
        }
    }

    private void ClickCheckbox(DataGridViewCellEventArgs e)
    {
        if (gridTextLibrary.Rows[e.RowIndex] == null)
        {
            Dbg.WriteWithCaller("Row is null");
            return;
        }
        else
        {
            bool oldCheckState = GetPinnedCheckboxValue(e.RowIndex);
            bool pinned = !oldCheckState;
            if (pinned)
            {
                string title;
                DataGridViewCellCollection cells = gridTextLibrary.Rows[e.RowIndex].Cells;

                if (cells[textColumnIndex].Value == null) return;

                if (cells[titleColumnIndex].Value == null)
                {
                    cells[titleColumnIndex].Value = string.Empty;
                }

                if (cells[titleColumnIndex].Value.ToString() == string.Empty)
                {
                    string? contentText = cells[textColumnIndex].Value.ToString();

                    TextPrompt textPrompt = UpdateTextEntryPrompt("Save text", "Update title and contents. You must use a valid file name.", "", contentText, GetRowColor(e.RowIndex));
                    DialogResult promptResult = textPrompt.ShowDialog();

                    if (promptResult == DialogResult.OK)
                    {
                        title = textPrompt.TextResult[0];
                        cells[titleColumnIndex].Value = title;
                        cells[textColumnIndex].Value = textPrompt.TextResult[1];
                        //update color
                        SetEntryColor(e.RowIndex, textPrompt.ColorPicked);
                    }
                    else
                    {
                        return;
                        //title = "entry " + e.RowIndex;
                        //cells[titleColumnIndex].Value = title;
                    }
                }
                else
                {
                    title = cells[titleColumnIndex].Value.ToString() + "";
                }
                
                if (title.Trim() == "")
                {
                    title = "entry " + e.RowIndex;
                    cells[titleColumnIndex].Value = title;
                }

                string text = cells[textColumnIndex].Value.ToString() + "";
                pinned = SaveEntry(title, text, cells[titleColumnIndex].Style.BackColor);
                SetPinnedCheckboxValue(cells[textColumnIndex].RowIndex, pinned);
            }
            else
            {
                Dbg.WriteWithCaller("Unpinned. Trying to delete corresponding file");
                DataGridViewCellCollection cells = gridTextLibrary.Rows[e.RowIndex].Cells;
                if (cells[titleColumnIndex].Value != null)
                    DeleteEntry(cells[titleColumnIndex].Value.ToString());
                SetPinnedCheckboxValue(e.RowIndex, false);
            }
        }
    }

    private void ClickCopyButton(DataGridViewCellEventArgs e)
    {
        string? cellText = "";
        if (gridTextLibrary.Rows[e.RowIndex].Cells[textColumnIndex].Value != null)
        {
            cellText = gridTextLibrary.Rows[e.RowIndex].Cells[textColumnIndex].Value.ToString();
        }
        if (cellText != null)
        {
            if (cellText.Length > 0)
            {
                Dbg.WriteWithCaller("Process text");
                mainForm.Process.ProcessTextVariables(cellText, true);
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

    private bool GetPinnedCheckboxValue(int rowIndex)
    {
        DataGridViewCheckBoxCell? checkboxCell = gridTextLibrary.Rows[rowIndex].Cells[checkboxColumnIndex] as DataGridViewCheckBoxCell;
        checkboxCell ??= new DataGridViewCheckBoxCell();
        return Convert.ToBoolean(checkboxCell.Value);
    }

    private bool SetPinnedCheckboxValue(int rowIndex, bool newValue)
    {
        DataGridViewCheckBoxCell? checkboxCell = gridTextLibrary.Rows[rowIndex].Cells[checkboxColumnIndex] as DataGridViewCheckBoxCell;
        checkboxCell ??= new DataGridViewCheckBoxCell();
        checkboxCell.Value = newValue;
        return Convert.ToBoolean(checkboxCell.Value);
    }

    private bool alwaysOnTop = false;
    private void ActionAlwaysOnTop(object sender, EventArgs e)
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

    private void ButtonColor_Click(object sender, EventArgs e)
    {
        ColorPicker();
    }

    private void ColorPicker()
    {
        if (gridTextLibrary.SelectedCells.Count <= 0) return;

        colorDialog1.Dispose();
        colorDialog1 = new ColorDialog();
        int[]? colors = GetSavedColors();
        if (colors != null)
            colorDialog1.CustomColors = GetSavedColors();

        DialogResult result = colorDialog1.ShowDialog();

        if (result == DialogResult.OK)
        {
            Color newColor = colorDialog1.Color;
            int row = gridTextLibrary.SelectedCells[0].RowIndex;
            SetEntryColor(row, newColor);
            SaveEntry(row);

            if (ArraysAreIdentical(colorDialog1.CustomColors, colors))
            {
                Dbg.WriteWithCaller("Custom colors have not changed");
            }
            else
            {
                Dbg.WriteWithCaller("Custom colors have changed, saving to file");
                SaveColors();
            }
        }
    }

    private int[]? GetSavedColors()
    {
        List<int> colorList = [];
        string colorFilePath = Path.Join(TextLibraryFolder, colorFolder, colorFileName);

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
            Dbg.WriteWithCaller("Could not load color file: " + colorFilePath);
        }
        return [.. colorList];
    }

    private static bool ArraysAreIdentical(int[]? array1, int[]? array2)
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
        List<string> customColors = [];
        foreach (int c in colorDialog1.CustomColors)
        {
            customColors.Add(c.ToString());
        }

        if (CheckOrCreateTextLibraryFolder(false))
        {
            string colorFilePath = Path.Join(TextLibraryFolder, colorFolder, colorFileName);
            if (!Directory.Exists(colorFilePath))
            {
                Dbg.WriteWithCaller("Creating color subfolder");
                try
                {
                    Directory.CreateDirectory(Path.Join(TextLibraryFolder, colorFolder));
                }
                catch
                {
                    Dbg.WriteWithCaller("Could not create color directory");
                }
            }
            try
            {
                Dbg.WriteWithCaller("Saving color file");
                File.WriteAllLines(colorFilePath, customColors);
            }
            catch
            {
                Dbg.WriteWithCaller("Could not save color file");
            }
        }
    }

    private void GridTextLibrary_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        SaveEntry(e.RowIndex);
    }

    private void OpenTextLibraryFolder(object sender, LinkLabelLinkClickedEventArgs e)
    {
        if (CheckOrCreateTextLibraryFolder(false))
        {
            Process.Start(new ProcessStartInfo() { FileName = TextLibraryFolder, UseShellExecute = true });
        }
    }

    private void GridTextLibrary_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        Dbg.WriteWithCaller("Rename entry?");
        if (gridTextLibrary.SelectedCells.Count > 0)
        {
            DataGridViewCell cell = gridTextLibrary.SelectedCells[0];
            if (cell.ColumnIndex == titleColumnIndex)
            {
                Dbg.WriteWithCaller("Rename entry started");
                RenameEntry(cell.RowIndex);
            }
        }
    }


    private void CheckBoxMinimize_CheckedChanged(object sender, EventArgs e)
    {
        Settings.Default.HistoryMinimizeAfterCopy = checkBoxMinimize.Checked;
        Settings.Default.Save();
    }
}
