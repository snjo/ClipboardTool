namespace Hotkeys
{
    [Serializable]
    public class Hotkey
    {
        public string Key = String.Empty;
        public bool Ctrl;
        public bool Alt;
        public bool Shift;
        public bool Win;
        public GlobalHotkey ghk;

        public Hotkey()
        {
            ghk = new GlobalHotkey();
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
            if (Key != "") // != 0   if key is char 
            {
                if (Ctrl) result += "Ctrl+";
                if (Alt) result += "Alt+";
                if (Shift) result += "Shift+";
                if (Win) result += "Win+";
                result += Key;
            }
            else
            {
                result = "no hotkey";
            }
            return result;
        }

    }
}
