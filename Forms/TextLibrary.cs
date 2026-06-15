using ClipboardTool.Classes;
using ClipboardTool.Forms;
using ClipboardTool.Properties;
using DebugTools;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;

namespace ClipboardTool;

[SupportedOSPlatform("windows")]

public partial class TextLibrary : Form
{
    private readonly int checkboxColumnIndex = 0;
    private readonly int titleColumnIndex = 1;
    private readonly int textColumnIndex = 2;
    private readonly int buttonColumnIndex = 3;
    readonly MainForm mainForm;
    public static readonly string colorTag = "//Color:";
    public static readonly string colorFolder = "Colors";
    public static readonly string colorFileName = "colors.txt";
    readonly string entryFileExtension = ".txt";
    //readonly List<KeyValuePair<string, string[]>> TextLibraryEntries = [];
    readonly List<TextLibraryEntry> TextLibraryEntries = [];
    BindingList<TextLibraryEntry> bindingList = [];

    public TextLibrary(MainForm mainForm)
    {
        InitializeComponent();
        this.mainForm = mainForm;
        gridTextLibrary.AutoGenerateColumns = false;
        LoadTextLibraryFiles();
        checkBoxMinimize.Checked = Settings.Default.HistoryMinimizeAfterCopy;
        //gridTextLibrary.DataSource = bindingList;
        gridTextLibrary.ColumnCount = 4;
        gridTextLibrary.Columns[0].DataPropertyName = "PinnedEntry";
        gridTextLibrary.Columns[1].DataPropertyName = "Title";
        gridTextLibrary.Columns[2].DataPropertyName = "TextContentWithoutTags";

        RefreshGrid();
    }

    public static string TextLibraryFolder
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
                    //Dbg.WriteWithCaller("Loading file: " + file);
                    string[] entryText = File.ReadAllLines(file);
                    TextLibraryEntries.Add(new TextLibraryEntry(Path.GetFileNameWithoutExtension(file), entryText));
                    //Debug.WriteLine($"   TextLibrary entries: {TextLibraryEntries.Count}, latest {TextLibraryEntries.Last().EntryName}");
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

        int countRows = 0;
        foreach (TextLibraryEntry entry in TextLibraryEntries)
        {
            Color entryColor = Color.White;
            int tagCount = 0;
            if (entry.TextContentRaw[0].Length > 0)
            {
                if (entry.TextContentRaw[0].Contains(colorTag))
                {
                    entryColor = ColorHelpers.ParseColor(entry.TextContentRaw[0][colorTag.Length..]);
                    entry.BackgroundColor = entryColor;
                    tagCount++;
                }
            }
            string textWithoutTags = string.Empty;
            for (int i = tagCount; i < entry.TextContentRaw.Length; i++)
            {
                textWithoutTags += entry.TextContentRaw[i];
                if (i < entry.TextContentRaw.Length - 1)
                    textWithoutTags += Environment.NewLine;
            }
            //gridTextLibrary.Rows.Add(true, Path.GetFileNameWithoutExtension(entry.EntryName), textWithoutTags);
            //TextLibraryEntries.Add(new TextLibraryEntry(Path.GetFileNameWithoutExtension(entry.EntryName), textWithoutTags));
            entry.TextContentWithoutTags = textWithoutTags;
            //SetEntryColor(countRows, c);
            countRows++;
        }
    }

    private void UpdateEntryColor(int rowIndex)
    {
        DataGridViewRow row = gridTextLibrary.Rows[rowIndex];
        Color color;
        if (row.DataBoundItem is TextLibraryEntry entry)
        {
            //Debug.WriteLine($"Entry is TextLibraryEntry {entry.Title} with color {entry.BackgroundColor}");
            color = entry.BackgroundColor;
        }
        else
        {
            Debug.WriteLine($"Entry is incorrect type {row.DataBoundItem}");
            color = Color.Red;
        }

        if (row != null)
        {
            if (row.Cells[1] != null)
            {

                row.Cells[titleColumnIndex].Style.BackColor = color;
                Color mixColor = ColorHelpers.MixColor(color, Color.White, 0.5f);
                row.Cells[textColumnIndex].Style.BackColor = mixColor;

                row.Cells[titleColumnIndex].Style.ForeColor = ColorHelpers.TextColorFromBackColor(color, 0.6f);
                row.Cells[textColumnIndex].Style.ForeColor = ColorHelpers.TextColorFromBackColor(mixColor, 0.6f);

                //Debug.WriteLine($"Setting color on row {row.Index} to {color}: {row.Cells[titleColumnIndex].Style.BackColor}");
            }
        }
    }

    private bool SaveEntry(TextLibraryEntry entry)
    {
        return SaveEntry(entry.Title, entry.TextContentWithoutTags, entry.BackgroundColor);
    }

    private bool SaveEntry(string? title, string? text, Color? color)
    {
        if (title == null || text == null)
        {
            return false;
        }
        title = title.Trim();
        if (title.Length == 0) return false;
        if (color == Color.Empty) color = Color.White;
        string path = Path.Join(TextLibraryFolder, title + entryFileExtension);
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

    private void DeleteEntry(string? title)
    {
        if (title == null)
        {
            Dbg.WriteWithCaller("Can't Delete file, value is null");
            return;
        }
        try
        {
            if (Directory.Exists(TextLibraryFolder))
            {
                string file = Path.Join(TextLibraryFolder, title + entryFileExtension);
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
                Dbg.WriteWithCaller("Can't Delete file (not found): " + title);
            }
        }
        catch
        {
            Dbg.WriteWithCaller("Exception: Can't Delete file : " + title);
        }
    }

    private static TextPrompt UpdateTextEntryPrompt(string dialogHeading, string info, string titleText, string? contentsText, Color color)
    {
        Debug.WriteLine($"Found Color {color}");
        if (color == Color.Empty) color = Color.White;
        List<PromptTextBoxConfig> promptConfig = [];
        promptConfig.Add(new PromptTextBoxConfig(1, "Title", titleText, TextPrompt.IllegalFileCharacters));
        PromptTextBoxConfig contentsCfg = new(10, "Contents", contentsText, null);
        contentsCfg.textbox.ScrollBars = ScrollBars.Vertical;

        promptConfig.Add(contentsCfg);

        TextPrompt textPrompt = new(promptConfig, dialogHeading, info, color, enterConfirmsDialog: false)
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

        Debug.WriteLine($"Adding new from clipboard");

        TextPrompt textPrompt = UpdateTextEntryPrompt("Add new from clipboard",
            "Set title and click OK to save entry.",
            "", clipboardtext, Color.White);

        DialogResult promptResult = textPrompt.ShowDialog();
        if (promptResult == DialogResult.OK)
        {
            if (textPrompt.TextResult.Count < 2)
            {
                Dbg.WriteWithCaller($"textPrompt TextResult length too short {textPrompt.TextResult.Count}");
                return;
            }
            string title = textPrompt.TextResult[0];
            string content = textPrompt.TextResult[1];
            Color color = textPrompt.ColorPicked;

            TextLibraryEntry newEntry = new(title, [])
            {
                TextContentWithoutTags = content,
                BackgroundColor = color
            };
            SaveEntry(newEntry);
            TextLibraryEntries.Add(newEntry);
            RefreshGrid();
        }
    }


    private void RenameEntry(TextLibraryEntry entry)
    {
        string oldTitle = entry.Title;
        string oldContents = entry.TextContentWithoutTags;
        Color oldColor = entry.BackgroundColor;
        TextPrompt textPrompt = UpdateTextEntryPrompt("Edit Text", "Update title and contents", oldTitle, oldContents, oldColor);
        DialogResult promptResult = textPrompt.ShowDialog();
        if (promptResult != DialogResult.OK) return;

        string newTitle = textPrompt.TextResult[0].Trim();
        string newContent = textPrompt.TextResult[1];
        Color newColor = textPrompt.ColorPicked;
        entry.Title = newTitle;
        entry.TextContentWithoutTags = newContent;
        entry.BackgroundColor = newColor;

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
        entry.PinnedEntry = SaveEntry(entry);
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
        if (gridTextLibrary.Rows[e.RowIndex].DataBoundItem is TextLibraryEntry entry)
        {
            Debug.WriteLine($"Click checkbox on entry {e.RowIndex} {entry.Title}");
            bool newPinStatus = !entry.PinnedEntry;
            if (newPinStatus == true)
            {
                if (entry.Title == "")
                {
                    RenameEntry(entry);
                }
                entry.PinnedEntry = SaveEntry(entry);
            }
            else
            {
                entry.PinnedEntry = false;
                DeleteEntry(entry.Title);
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
                mainForm.Process.ProcessTextVariables(cellText, 0, true);
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
        PickSelectedEntryColor();
    }

    private void PickSelectedEntryColor()
    {
        if (gridTextLibrary.SelectedCells.Count <= 0) return;
        colorDialog1.Dispose();
        colorDialog1 = new ColorDialog();
        string colorFilePath = Path.Join(TextLibraryFolder, colorFolder, colorFileName);
        int[]? colors = GetSavedColors(colorFilePath);
        if (colors != null)
        {
            colorDialog1.CustomColors = GetSavedColors(colorFilePath);
        }

        DialogResult result = colorDialog1.ShowDialog();

        if (result == DialogResult.OK)
        {
            Color newColor = colorDialog1.Color;
            //int row = gridTextLibrary.SelectedCells[0].RowIndex;
            if (gridTextLibrary.SelectedCells[0].OwningRow.DataBoundItem is TextLibraryEntry entry)
            {
                entry.BackgroundColor = newColor;
                SaveEntry(entry);
                RefreshGrid();
            }

            if (ArraysAreIdentical(colorDialog1.CustomColors, colors))
            {
                Dbg.WriteWithCaller("Custom colors have not changed");
            }
            else
            {
                Dbg.WriteWithCaller("Custom colors have changed, saving to file");
                SaveColors(colorDialog1.CustomColors);
            }
        }
    }

    public static int[]? GetSavedColors(string colorFilePath)
    {
        List<int> colorList = [];

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

    public static bool ArraysAreIdentical(int[]? array1, int[]? array2)
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

    public static void SaveColors(int[] colors)
    {
        List<string> customColors = [];
        foreach (int c in colors)//colorDialog1.CustomColors)
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
        if (gridTextLibrary.Rows[e.RowIndex] == null)
        {
            Dbg.WriteWithCaller("Row is null");
            return;
        }
        if (gridTextLibrary.Rows[e.RowIndex].DataBoundItem is TextLibraryEntry entry)
        {
            SaveEntry(entry);
        }
        //SaveEntry(e.RowIndex);
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
                if (cell.OwningRow.DataBoundItem is TextLibraryEntry entry)
                {
                    RenameEntry(entry);
                    RefreshGrid();
                }
            }
        }
    }


    private void CheckBoxMinimize_CheckedChanged(object sender, EventArgs e)
    {
        Settings.Default.HistoryMinimizeAfterCopy = checkBoxMinimize.Checked;
        Settings.Default.Save();
    }

    private void RefreshGrid()
    {
        gridTextLibrary.DataSource = null;
        bindingList = FilteredEntries(textBoxSearch.Text);
        gridTextLibrary.DataSource = bindingList;
        RefreshColors();
    }

    private int RefreshColors()
    {
        int rowNumber = 0;
        foreach (DataGridViewRow row in gridTextLibrary.Rows)
        {
            UpdateEntryColor(rowNumber);
            rowNumber++;
        }

        return rowNumber;
    }

    public BindingList<TextLibraryEntry> FilteredEntries(string filter)
    {
        return ToBindingList((TextLibraryEntries.Where(x => x.Title.Contains(filter, StringComparison.InvariantCultureIgnoreCase) || x.TextContentWithoutTags.Contains(filter, StringComparison.InvariantCultureIgnoreCase))));
    }

    private void TextBoxSearch_TextChanged(object sender, EventArgs e)
    {
        RefreshGrid();
    }

    private void TextLibrary_Shown(object sender, EventArgs e)
    {
        // must run the color refresh after the form is fully loaded, otherwise the colors will not be used on the first refresh
        RefreshColors();
    }

    private void TextLibrary_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
        Debug.WriteLine($"Form Key down preview: {e.KeyCode}");
        if (e.KeyCode == Keys.F3)
        {
            textBoxSearch.Focus();
            //Debug.WriteLine($"Setting focus to search box");
        }
    }

    private void gridTextLibrary_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.F3)
        {
            e.Handled = true; // must prevent the grid from receiving F3, otherwise a sorting exception occurs.
            textBoxSearch.Focus();
        }
    }

    public static BindingList<T> ToBindingList<T>(IEnumerable<T> range)
    {
        return new BindingList<T>([.. range]);
    }

}
