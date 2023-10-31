// add using for the active project's Properties here
// ex: using MyApp.Properties;
using ClipboardTool.Properties;

namespace Hotkeys
{
    public class HotkeyTools
    {

        public static Dictionary<string, Hotkey> LoadHotkeys(Dictionary<string, Hotkey> hotkeyList, List<string> hotkeyNames, Form parent)
        {
            foreach (string name in hotkeyNames)
            {
                if (hotkeyList.ContainsKey(name))
                    hotkeyList.Remove(name);
                hotkeyList.Add(name, LoadHotkey(name, parent));
            }
            return hotkeyList;
        }

        public static Hotkey LoadHotkey(string hotkeyName, Form parent) //char settingHotkey
        {
            string key = Settings.Default["hk" + hotkeyName + "Key"].ToString() + "";
            bool Ctrl = (bool)Settings.Default["hk" + hotkeyName + "Ctrl"];
            bool Alt = (bool)Settings.Default["hk" + hotkeyName + "Alt"];
            bool Shift = (bool)Settings.Default["hk" + hotkeyName + "Shift"];
            bool Win = (bool)Settings.Default["hk" + hotkeyName + "Win"];
            Hotkey hotkey = new Hotkey(key, Ctrl, Alt, Shift, Win, parent);
            return hotkey;
        }

        /// <summary>
        /// Registers a Global Hotkey.
        /// </summary>
        /// <param name="ghk">A GlobalHotkey</param>
        /// <param name="warning">Displays a MessageBox warning if the key fails to register</param>
        public static bool RegisterHotKey(GlobalHotkey ghk, bool warning = true)
        {
            if (ghk == null) return false;
            if (ghk.Register())
            {
                return true;
            }
            else
            {
                if (ghk != null)
                {
                    if (warning && ghk.Hotkey == null) MessageBox.Show("Could not register hotkey " + ghk.key + ", ghk.hotkey is null");
                    else if (warning) MessageBox.Show("Could not register hotkey " + ghk.key + "ghk.hotkey.Win is " + ghk.Hotkey.Win);
                }
                else
                {
                    if (warning) MessageBox.Show("Could not register unknown hotkey");
                }
                return false;
            }
        }

        /// <summary>
        /// Registers all keys in a Dictionary of hotkeys
        /// </summary>
        /// <param name="hotkeyList">A dictionary with hotkey names and Hotkey objects</param>
        /// <param name="warning">Displays a MessageBox warning if the key fails to register.</param>
        public static void RegisterHotkeys(Dictionary<string, Hotkey> hotkeyList, bool warning = true)
        {
            string warningKeys = "";
            foreach (KeyValuePair<string, Hotkey> ghk in hotkeyList)
            {
                if (ghk.Value.Key == string.Empty)
                {
                    //MessageBox.Show("Skipping hotkey");
                }
                else if (!RegisterHotKey(ghk.Value.ghk, false)) //register the key, add a warning to the list if it fails
                {
                    warningKeys += ghk.Key + "\n";
                }
            }
            if (warningKeys.Length > 0)
            {
                MessageBox.Show("Could not register hotkeys:\n" + warningKeys);
            }
        }

        public static void ReleaseHotkeys(Dictionary<string, Hotkey> hotkeyList)
        {
            foreach (KeyValuePair<string, Hotkey> ghk in hotkeyList)
            {
                ReleaseHotkey(ghk.Value.ghk);
            }
        }

        public static void ReleaseHotkey(GlobalHotkey ghk)
        {
            if (ghk != null)
            {
                ghk.Unregister();
            }
        }
    }
}
