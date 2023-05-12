using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Configuration;

namespace Hotkeys
{
    class Hotkeys
    {
    }

    [Serializable]
    public class HotkeyList// : ApplicationSettingsBase
    {
        public Hotkey UpperCase = new();
        public Hotkey LowerCase = new();
        public Hotkey PlainText = new();
        public Hotkey CapsLock = new();
        public Hotkey ProcessText = new();
        public Hotkey Date = new();
    }

    [Serializable]
    public class Hotkey
    {
        //public char key;
        public string key = String.Empty;
        public bool Ctrl;
        public bool Alt;
        public bool Shift;
        public bool Win;
        public GlobalHotkey? ghk;
        //public bool registered; // TODO

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

    public sealed class HotkeySetting : ApplicationSettingsBase
    {
        [UserScopedSetting]
        [SettingsSerializeAs(SettingsSerializeAs.Xml)]
        [DefaultSettingValue("")]
        public List<Hotkey> Entries
        {
            get { return (List<Hotkey>)this[nameof(Entries)]; }
            set { this[nameof(Entries)] = value; }
        }
    }

    public class GlobalHotkey
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private int modifier;
        private int key;
        private IntPtr hWnd;
        public int id;
        public Hotkey? hotkey;
        public bool registered;
        private bool validKey;

        public Keys stringToKey(string keystring)
        {
            //MessageBox.Show("keystring "+keystring+", length " + keystring.Length);
            if (keystring.Length > 0)
            {
                if (keystring.Length == 1)
                {
                    char ch = keystring[0];
                    validKey = true;
                    return (Keys)ch;                    
                }
                else
                {
                    //MessageBox.Show("keystring " + keystring + ", length " + keystring.Length);
                    validKey = Enum.TryParse(keystring, out Keys key);
                    return (Keys)key;
                }
            }
            return new Keys();
        }

        public GlobalHotkey(int modifier, Keys key, Form form)
        {
            this.modifier = modifier;
            this.key = (int)key;
            this.hWnd = form.Handle;
            id = this.GetHashCode();
            validKey = true;
        }

        public GlobalHotkey(int modifier, string keystring, Form form)
        {
            this.modifier = modifier;
            Keys key = stringToKey(keystring);
            this.key = (int)key;
            this.hWnd = form.Handle;
            id = this.GetHashCode();
        }

        public GlobalHotkey(Keys modifiedkey, Form form)
        {
            this.key = (int)modifiedkey;
            this.hWnd = form.Handle;
            id = this.GetHashCode();
            validKey = true;
        }

        public override int GetHashCode()
        {
            return modifier ^ key ^ hWnd.ToInt32();
        }

        public bool Register()
        {
            if (validKey == false)
            {
                registered = false;
                return registered;
            }
            if (id != 0)
            {
                registered = RegisterHotKey(hWnd, id, modifier, key);
                return registered;
            }
            else
            {
                registered = false;
                return registered;
            }
        }

        public bool Unregister()
        {
            registered = false;
            return UnregisterHotKey(hWnd, id);
        }



    }



    public enum KeyModifier
    {
        None = 0,
        Alt = 1,
        Control = 2,
        Shift = 4,
        WinKey = 8
    }

    public static class Constants
    {
        //modifiers
        public const int NOMOD = 0x0000;
        public const int ALT = 0x0001;
        public const int CTRL = 0x0002;
        public const int SHIFT = 0x0004;
        public const int WIN = 0x0008;

        //windows message id for hotkey
        public const int WM_HOTKEY_MSG_ID = 0x0312; //0x0312;
    }
}
