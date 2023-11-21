using ClipboardTool.Properties;
using DebugTools;
using Hotkeys;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace ClipboardTool.Classes;

public class CBT // CBT = clipboardtool, main code that's not directly UI events etc.
{
    MainForm mainForm;
    Settings settings = Settings.Default;
    ProcessText process;
    public CBT(MainForm parent)
    {
        mainForm = parent;
        settings = ClipboardTool.Properties.Settings.Default;
        process = mainForm.process;
    }

    public void updateHotkeyLabel(Hotkey hotkey, Label label)
    {
        if (hotkey != null)
        {
            if (hotkey.ghk != null)
            {
                if (hotkey.ghk.registered)
                {
                    label.Text = hotkey.Text();
                    return;
                }
            }

            if (hotkey.Key == "")
            {
                label.Text = "No hotkey" + hotkey.Key;
            }
            else
            {
                label.Text = "Hotkey error: " + hotkey.Text();
            }

        }
        else
        {
            label.Text = "Hotkey error";
        }
    }
    // SETTINGS

    public void UpgradeSettings()
    {
        if (settings.UpgradeSettings)
        {
            Dbg.WriteWithCaller("Upgrading settings");
            //MessageBox.Show("Upgrading settings");
            settings.Upgrade();
            settings.UpgradeSettings = false;
        }
        else
        {
            //MessageBox.Show("Not upgrading settings");
            Dbg.WriteWithCaller("Not upgrading settings");
        }
    }

    // CULTURE AND REGION
    public void UpdateCulture()
    {
        if (settings.Culture != "")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(settings.Culture);
            }
            catch
            {
                MessageBox.Show("Can't set Culture to '" + settings.Culture + "'" + Environment.NewLine + "The value has been set to default.");
                settings.Culture = "";
                settings.Save();
            }
        }
        else
        {
            Thread.CurrentThread.CurrentCulture = mainForm.startingCulture;
        }
        Dbg.DebugValues("Updated Culture: ", "  ",
            "Setting: " + settings.Culture,
            "Thread: " + Thread.CurrentThread.CurrentCulture,
            "Number Decimal: " + Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator,
            "Number Group: " + Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator,
            "Date Format Full: " + Thread.CurrentThread.CurrentCulture.DateTimeFormat.FullDateTimePattern,
            "Date Format Short: " + Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern);
    }

    // FILE INPUT AND OUTPUT

    public string loadTextFromFile(string filename)
    {
        string folder = settings.MemorySlotFolder;
        string fullpath = Environment.ExpandEnvironmentVariables(folder);
        if (fullpath.Length > 0)
        {
            if (Directory.Exists(fullpath))
            {
                if (fullpath.Substring(fullpath.Length - 1, 1) != "\\")
                    fullpath += "\\";
            }
        }
        if (File.Exists(fullpath + filename))
        {
            return File.ReadAllText(fullpath + filename);
        }
        return string.Empty;
    }

    public void saveTextToFile(string filename, string text, bool warnIfFailed)
    {
        string folder = settings.MemorySlotFolder;
        if (folder.Length > 0)
        {
            string folderExpanded = Environment.ExpandEnvironmentVariables(folder);
            if (Directory.Exists(folderExpanded))
            {
                string path = Path.Combine(folderExpanded, filename);
                bool writeOK = WriteToFile(path, text, warnIfFailed);
                Dbg.WriteWithCaller("Trying to save memory slot to: " + path + "\nSave: " + writeOK);
            }
            else
            {
                Dbg.WriteWithCaller("Save failed to folder: " + folderExpanded);
                if (warnIfFailed)
                    writeMessage("Couldn't save file " + filename + " to folder " + folder + Environment.NewLine +
                    "The folder does not exist." + Environment.NewLine +
                    "You can set the save location in Settings, '.txt file folder'");
            }
        }
        else
        {
            WriteToFile(filename, text, warnIfFailed);
        }
    }

    public bool WriteToFile(string filename, string text, bool warnIfFailed)
    {
        try
        {
            string fullpath = Environment.ExpandEnvironmentVariables(filename);
            File.WriteAllText(fullpath, text);
            return true;
        }
        catch
        {
            Debug.WriteLine("Save failed to file: " + filename);
            if (warnIfFailed)
                writeMessage("Couldn't save file " + filename + " to folder." + Environment.NewLine +
                "Ensure that the folder is not write protected." + Environment.NewLine +
                "You can set the save location in Settings, '.txt file folder'");
            return false;
        }
    }

    private void writeMessage(string text)
    {
        MessageBox.Show(text);
    }

    public void saveMemSlotToFile(int num, bool warnIfFailed)
    {
        saveTextToFile("mem" + num + ".txt", mainForm.MemorySlot(num).Text, warnIfFailed);
    }

    // HOTKEY HANDLING
    public bool hotkeyHeldDown = false;
    string delayedKeystrokes = "";

    private enum SendDateOption
    {
        NotStarted,
        JustDate,
        JustTime,
        DateAndTime,
        END
    }
    private SendDateOption sendDateChoice = SendDateOption.NotStarted;

    public void HandleHotkey(int id)
    {
        if (CheckHotkey("LowerCase", id))
        {
            if (!hotkeyHeldDown)
            {
                hotkeyHeldDown = true;
                sendCut();
                string t = LowerCaseOnce();
                SetClipBoard(t, null, settings.sendPaste, "Hotkey PlainText");
                sendPaste(t, "Hotkey LowerCase");
            }
        }

        if (CheckHotkey("UpperCase", id))
        {
            if (!hotkeyHeldDown)
            {
                hotkeyHeldDown = true;
                sendCut();
                string t = UpperCaseOnce();
                SetClipBoard(t, null, settings.sendPaste, "Hotkey PlainText");
                sendPaste(t, "Hotkey UpperCase");
            }
        }

        if (CheckHotkey("CapsLock", id))
        {
            mainForm.ToggleCapsLock();
        }

        if (CheckHotkey("PlainText", id))
        {
            if (!hotkeyHeldDown)
            {
                hotkeyHeldDown = true;
                sendCut();
                string t = PlainTextOnce();
                SetClipBoard(t, null, settings.sendPaste, "Hotkey PlainText");
                sendPaste(t, "Hotkey PlainText");
            }
        }

        if (CheckHotkey("ProcessText", id))
        {
            Debug.WriteLine("Process text pressed");
            if (!hotkeyHeldDown)
            {
                hotkeyHeldDown = true;
                sendCut();
                Dbg.WriteWithCaller("Process text");
                sendPaste(process.ProcessTextVariables(mainForm.MemorySlot(0).Text, settings.sendPaste).PlainText, "Hotkey Process");
            }
        }

        if (CheckHotkey("Date", id))
        {
            sendDate();
        }

        if (CheckHotkey("MemSlot1", id))
        {
            if (!hotkeyHeldDown)
            {
                hotkeyHeldDown = true;
                sendCut();
                Dbg.WriteWithCaller("Process text");
                sendPaste(process.ProcessTextVariables(mainForm.MemorySlot(1).Text, settings.sendPaste).PlainText);
            }
        }

        if (CheckHotkey("MemSlot2", id))
        {
            if (!hotkeyHeldDown)
            {
                hotkeyHeldDown = true;
                sendCut();
                Dbg.WriteWithCaller("Process text");
                sendPaste(process.ProcessTextVariables(mainForm.MemorySlot(2).Text, settings.sendPaste).PlainText);
            }
        }

        if (CheckHotkey("MemSlot3", id))
        {
            if (!hotkeyHeldDown)
            {
                hotkeyHeldDown = true;
                sendCut();
                Dbg.WriteWithCaller("Process text");
                sendPaste(process.ProcessTextVariables(mainForm.MemorySlot(3).Text, settings.sendPaste).PlainText);
            }
        }

        if (CheckHotkey("ResetNumber", id))
        {
            mainForm.NumberSpinner = 1;
        }

        if (CheckHotkey("History", id))
        {
            mainForm.ShowHistory();
        }
    }

    private bool CheckHotkey(string hotkeyName, int id)
    {
        if (mainForm.HotkeyList[hotkeyName] != null)
        {
            if (id == mainForm.HotkeyList[hotkeyName].ghk.id)
            {
                return true;
            }
        }
        return false;
    }

    private void sendCut()
    {
        if (settings.sendCut)
        {
            SendKeys.Send("^x");
        }
    }

    private void sendPaste(string output, string source = "unknown")
    {
        Debug.WriteLine("SendPaste start from " + source);
        //hotkeyHeldDown = true;
        if (output == string.Empty)
        {
            hotkeyHeldDown = false;
            return;
        }

        if (settings.sendPaste)
        {
            delayKeystrokes("^v");
        }
        else if (settings.sendType)
        {
            delayKeystrokes(output);
        }
    }

    private void delayKeystrokes(string keystrokes)
    {
        delayedKeystrokes = keystrokes;
        mainForm.StartTimerKeystrokes();
    }

    private void sendKeystrokes(string keystrokes)
    {
        switch (keystrokes)
        {
            case "^v":
                SendKeys.Send("^v");
                break;
            case "^x":
                SendKeys.Send("^x");
                break;
            case "^c":
                SendKeys.Send("^c");
                break;
            case "$SendDate":
                SendKeys.Send(SendDateText());
                sendDateChoice = SendDateOption.NotStarted;
                break;
            default:
                keystrokes = Regex.Replace(keystrokes, "[+^%~(){}]", "{$0}");
                SendKeys.Send(keystrokes);
                break;
        }

        // warning: ^'s will become &'s on non-US keyboards:
        // https://stackoverflow.com/questions/47635218/sending-a-caret-with-system-windows-forms-sendkeys-send-will-send-ampersand
        // use paste method instead of sendkeys if the text includes carets

        hotkeyHeldDown = false;
    }

    public string PlainTextOnce(bool forceClipboardUpdate = false)
    {
        string result = Clipboard.GetText(TextDataFormat.Text);
        SetClipBoard(result, null, forceClipboardUpdate, "PlainTextOnce");
        return result;
        //setClipBoard(clipBoardText);
    }

    public string UpperCaseOnce(bool forceClipboardUpdate = false)
    {
        if (Clipboard.ContainsText())
        {
            string result = Clipboard.GetText(TextDataFormat.Text).ToUpper();
            SetClipBoard(result, null, forceClipboardUpdate, "UpperCaseOnce");
            return result;
        }
        else return string.Empty;
    }

    public string LowerCaseOnce(bool forceClipboardUpdate = false)
    {
        if (Clipboard.ContainsText())
        {
            string result = Clipboard.GetText(TextDataFormat.Text).ToLower();
            SetClipBoard(result, null, forceClipboardUpdate, "LowerCaseOnce");
            return result;

        }
        else return string.Empty;
    }

    public void DelayKeyStrokes()
    {
        mainForm.StopTimerKeystrokes();
        if (delayedKeystrokes != null)
            sendKeystrokes(delayedKeystrokes);
    }

    private void sendDate()
    {
        if (sendDateChoice < SendDateOption.END - 1)
        {
            sendDateChoice = sendDateChoice + 1;
        }

        delayKeystrokes("$SendDate");
    }

    private string SendDateText()
    {
        string outDate = "init outDate (SendDate error)";
        switch (sendDateChoice)
        {
            case SendDateOption.NotStarted:
                outDate = "Use Date/Time hotkey (SendDate error)";
                break;
            case SendDateOption.JustDate:
                outDate = DateTime.Now.ToShortDateString();
                break;
            case SendDateOption.DateAndTime:
                outDate = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                break;
            case SendDateOption.JustTime:
                outDate = DateTime.Now.ToShortTimeString();
                break;
            default:
                outDate = "Pressed beyond the enum (SendDate error)";
                break;
        }

        return outDate;
    }


    // CLIPBOARD

    public void SetClipBoard(string plainText, string? richText = "", bool forceClipboardUpdate = false, string source = "unknown")//, TextDataFormat dataFormat = TextDataFormat.Text)
    {
        if ((!settings.updateClipboard && settings.sendType) && !forceClipboardUpdate)
        {
            return;
        }
        if (plainText.Length > 0)
        {
            if (richText == null)
            {
                DateTime clipStart = DateTime.Now;
                try
                {
                    //string testEmoji = char.ConvertFromUtf32(128076).ToString();
                    Clipboard.SetText(plainText, TextDataFormat.UnicodeText);
                }
                catch
                {
                    //if (OperatingSystem.IsWindows())
                    //    SystemSounds.Asterisk.Play();
                    Dbg.WriteWithCaller("Error updating clipboard");
                    //this was probably caused by another program accessing the clipboard at the same time, or sending requests too rapidly.
                    //should be fixed after fixing some spammy clipboard updates.
                }
                TimeSpan ts = DateTime.Now - clipStart;
            }
            else
            {
                DateTime clipStart = DateTime.Now;
                try
                {
                    // When pasting special unicode characters like smileys, the may be converted to ??
                    // plaintext loses the unicode because it's copied from textBox.Text, RTF for an unknown reason when using SetData(DataFormats.RTF
                    Clipboard.Clear();
                    DataObject data = new DataObject();
                    data.SetData(DataFormats.UnicodeText, plainText);
                    data.SetData(DataFormats.Rtf, richText);
                    Clipboard.SetDataObject(data);

                    //test
                    //Debug.WriteLine("Set to clip from RTF");
                    //Clipboard.SetText(plainText, TextDataFormat.UnicodeText);
                }
                catch
                {
                    //if (OperatingSystem.IsWindows())
                    //    SystemSounds.Asterisk.Play();
                    Dbg.WriteWithCaller("Error updating clipboard");
                }
                TimeSpan ts = DateTime.Now - clipStart;
            }
        }
        else
        {
            Clipboard.Clear();
        }
    }

    public void setTextBoxFromClipboard(int num)
    {
        TextBox textBox;
        textBox = mainForm.MemorySlot(num);
        if (Clipboard.ContainsText())
        {
            string newText = Clipboard.GetText();
            textBox.Text = newText;

            if (settings.SaveMemorySlots)
            {
                saveMemSlotToFile(num, warnIfFailed: true);
            }

            if (settings.ResetCounterWhenSet)
            {
                mainForm.NumberSpinner = 1;
            }

        }
    }

    public void setClipboardFromTextBox(int num)
    {
        TextBox textBox;
        textBox = mainForm.MemorySlot(num);
        if (textBox.Text != null)
        {
            if (textBox.Text.Length > 0)
            {
                //Dbg.WriteWithCaller("Process text");
                process.ProcessTextVariables(textBox.Text, true);
            }
            else
            {
                Clipboard.Clear();
            }
        }

    }
}
