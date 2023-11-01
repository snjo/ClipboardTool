using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Hotkeys
{
    public class GlobalHotkey
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public int modifier;
        public int key;
        private IntPtr hWnd;
        public int id;
        public bool registered;
        private bool validKey;
        public string displayName = "Unnamed";

        public Keys stringToKey(string keystring)
        {
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
                    validKey = Enum.TryParse(keystring, out Keys key);
                    return (Keys)key;
                }
            }
            return new Keys();
        }

        public GlobalHotkey(int modifier, string keystring, Form form, string name = "Unnamed")
        {
            this.modifier = modifier;
            Keys key = stringToKey(keystring);  // assigns validKey
            this.key = (int)key;
            this.hWnd = form.Handle;
            displayName = name;
            id = this.GetHashCode();
        }

        public GlobalHotkey()
        {
            validKey = false;
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
                Debug.WriteLine("Validkey false: " + key + " / " + modifier);
                return registered;
            }
            if (id != 0)
            {
                registered = RegisterHotKey(hWnd, id, modifier, key);
                //Debug.WriteLine("Registered hotkey:" + registered.ToString() + " / " + key + " / " + modifier);
                return registered;
            }
            else
            {
                registered = false;
                Debug.WriteLine("Unknown register hotkey error: " + key + " / " + modifier);
                return registered;
            }
        }

        public bool Unregister()
        {
            //Debug.WriteLine("Releasing hotkey: " + key + " / " + modifier);
            registered = false;
            return UnregisterHotKey(hWnd, id);
        }
    }
}
