// Autorun class uses static methods, no need to create an Autorun object in main, just ask it to enable, disable or update.
// in Main form:
//      public static readonly string ApplicationName = "ExampleApp";
//   in main method:
//     Autorun.Autorun.UpdatePathIfEnabled(ApplicationName);
//   update from options, for example check Options DialogResult, check if user enabled or diseabled Autorun:
//     if (options.AutorunEnabled)
//            {
//                Autorun.Autorun.Enable(ApplicationName);
//            }
//            else
//            {
//                Autorun.Autorun.Disable(ApplicationName);
//            }
//

using Microsoft.Win32;
using System.Runtime.Versioning;

namespace Autorun;
[SupportedOSPlatform("windows")]
public static class Autorun
{
    private const string autoStartKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";

    public static bool IsEnabled(string ApplicationName)
    {
        using RegistryKey? key = Registry.CurrentUser.OpenSubKey(autoStartKey, false);
        if (key != null)
        {
            return key.GetValue(ApplicationName, null) != null;
        }
        else
        {
            return false;
        }
    }

    public static void Enable(string ApplicationName)
    {
        using RegistryKey? key = Registry.CurrentUser.OpenSubKey(autoStartKey, true);
        key?.SetValue(ApplicationName, "\"" + Application.ExecutablePath + "\"");
    }

    public static void Disable(string ApplicationName)
    {
        using RegistryKey? key = Registry.CurrentUser.OpenSubKey(autoStartKey, true);
        key?.DeleteValue(ApplicationName, false);
    }

    public static bool UpdatePathIfEnabled(string ApplicationName)
    {
        bool enabled = IsEnabled(ApplicationName);
        if (enabled)
        {
            Enable(ApplicationName);
            return true;
        }
        else
        {
            return false;
        }
    }
}