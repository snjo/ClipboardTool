// add using for the active project's Properties here
// ex: using MyApp.Properties;
using ClipboardTool.Properties;
using System.Configuration;
using System.Diagnostics;

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
            Hotkey hotkey = new Hotkey();

            hotkey.Key = getSettingString("hk" + hotkeyName + "Key", "");
            hotkey.Ctrl = getSettingBool("hk" + hotkeyName + "Ctrl", false);
            hotkey.Alt  = getSettingBool("hk" + hotkeyName + "Alt", false);
            hotkey.Shift= getSettingBool("hk" + hotkeyName + "Shift", false);
            hotkey.Win  = getSettingBool("hk" + hotkeyName + "Win", false);
            hotkey.ghk = new GlobalHotkey(hotkey.Modifiers(), hotkey.Key, parent, hotkeyName);
            return hotkey;
        }

        private static string getSettingString(string key, string fallback)
        {
            if (DoesSettingExist(key))
            {
                return (string)Settings.Default[key];
            }
            else
            {
                Debug.WriteLine("Setting " + key + " does not exist");
                return fallback;
            }
        }

        private static bool getSettingBool(string key, bool fallback)
        {
            if (DoesSettingExist(key))
            {
                return (bool)Settings.Default[key];
            }
            else
            {
                Debug.WriteLine("Setting " + key + " does not exist");
                return fallback;
            }
        }

        private static bool DoesSettingExist(string settingName)
        {
            return Settings.Default.Properties.Cast<SettingsProperty>().Any(prop => prop.Name == settingName);
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
                //Debug.WriteLine("Registered hotkey named " + ghk.displayName + ", key: " + ghk.key + ", modifiers:" + ghk.modifier);
                return true;
            }
            else
            {
                if (ghk != null)
                {
                    if (warning) MessageBox.Show("Could not register hotkey named " + ghk.displayName + ", key " + ghk.key);
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
        /// <returns>An array with the name of any keys that failed to retister</returns>
        public static string[] RegisterHotkeys(Dictionary<string, Hotkey> hotkeyList, bool warning = false)
        {
            string warningText = "Could not register hotkeys:";
            List<string> warningKeys = new List<string>();
            foreach (KeyValuePair<string, Hotkey> hk in hotkeyList)
            {
                if (hk.Value.Key != string.Empty)
                {
                    if (!RegisterHotKey(hk.Value.ghk, false)) //register the key, add a warning to the list if it fails
                    {
                        warningKeys.Add(hk.Key);
                    }
                }
            }

            if (warningKeys.Count > 0)
            {
                foreach (string key in warningKeys)
                {
                    warningText += Environment.NewLine + key;
                }
                Debug.WriteLine(warningText);
                if (warning)
                    MessageBox.Show(warningText);
            }

            return warningKeys.ToArray();
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

        public static void UpdateHotkeys(Dictionary<string, Hotkey> hotkeyList, List<string> hotkeyNames, Form parent)
        {
            ReleaseHotkeys(hotkeyList);
            LoadHotkeys(hotkeyList, hotkeyNames, parent);
            RegisterHotkeys(hotkeyList, true);
        }
    }
}
