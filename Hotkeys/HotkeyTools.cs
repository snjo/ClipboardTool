// add using for the active project's Properties here
// ex: using MyApp.Properties;
using ClipboardTool.Properties;

namespace Hotkeys
{
    public class HotkeyTools
    {

        public static Dictionary<string, Hotkey> LoadHotkeys(Dictionary<string, Hotkey> hotkeyList, Form parent)
        {
            foreach (KeyValuePair<string, Hotkey> kvp in hotkeyList)
            {
                hotkeyList[kvp.Key] = LoadHotkey(kvp.Key, parent);                
            }

            //MessageBox.Show("hotKeyList " + hotkeyList.Count);
            return hotkeyList;
        }

        public static Hotkey LoadHotkey(string hotkeyName, Form parent) //char settingHotkey
        {
            Hotkey hotkey = new Hotkey();
            
            hotkey.key = Settings.Default["hk" + hotkeyName + "Key"].ToString();
            hotkey.Ctrl = (bool)Settings.Default["hk" + hotkeyName + "Ctrl"];
            hotkey.Alt = (bool)Settings.Default["hk" + hotkeyName + "Alt"];
            hotkey.Shift = (bool)Settings.Default["hk" + hotkeyName + "Shift"];
            hotkey.Win = (bool)Settings.Default["hk" + hotkeyName + "Win"];
            hotkey.ghk = new GlobalHotkey(hotkey.Modifiers(), hotkey.key, parent);

            //MessageBox.Show("LoadHotkey: " + hotkeyName + " / " + hotkey.Win);
            return hotkey;
        }

        /// <summary>
        /// Registers a Global Hotkey.
        /// </summary>
        /// <param name="ghk">A GlobalHotkey</param>
        /// <param name="warning">Displays a MessageBox warning if the key fails to register</param>
        public static bool RegisterHotKey(GlobalHotkey ghk, bool warning=true)
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
                    if (warning && ghk.hotkey == null) MessageBox.Show("Could not register hotkey " + ghk.key + ", ghk.hotkey is null");
                    else if (warning) MessageBox.Show("Could not register hotkey " + ghk.key + "ghk.hotkey.Win is " + ghk.hotkey.Win);
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
                if (ghk.Value.key == string.Empty)
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
