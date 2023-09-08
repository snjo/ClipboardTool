// add using for the active project's Properties here
// ex: using MyApp.Properties;
using ClipboardTool.Properties;

namespace Hotkeys
{
    [Serializable]
    public class Hotkey
    {
        public string key = String.Empty;
        public bool Ctrl;
        public bool Alt;
        public bool Shift;
        public bool Win;
        public GlobalHotkey ghk;
        public bool hotkeysSet;
        //public bool registered; // TODO

        public Hotkey()
        {
            ghk = new GlobalHotkey();
        }

        public Hotkey(GlobalHotkey globalHK)
        {
            ghk = globalHK;
        }

        public int Modifiers() // bool Ctrl, bool Alt, bool Shift, bool Win)
        {
            int result = 0;
            if (Ctrl) result += (int)KeyModifier.Control;
            if (Alt) result += (int)KeyModifier.Alt;
            if (Shift) result += (int)KeyModifier.Shift;
            if (Win) result += (int)KeyModifier.WinKey;
            return result;

        }

        public string Text()
        {
            string result = "";
            if (key != "") // != 0   if key is char 
            {
                if (Ctrl) result += "Ctrl+";
                if (Alt) result += "Alt+";
                if (Shift) result += "Shift+";
                if (Win) result += "Win+";
                result += key;
            }
            else
            {
                result = "no hotkey";
            }
            return result;
        }

    }
}
