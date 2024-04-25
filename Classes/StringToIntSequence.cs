using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClipboardTool.Classes;

internal class StringToIntSequence
{
    public static string Convert(string clip)
    {
        string result = string.Empty;
        foreach (char c in clip)
        {
            result += (int)c + " ";
        }
        return result;
    }
}
