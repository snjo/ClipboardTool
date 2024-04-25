﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClipboardTool.Classes;

internal class ExcelQuotes
{
    public static string Convert(string customText)
    {
        customText = customText.Replace(ProcessingCommands.ExcelQuotes.Name, "");
        customText = customText.Replace("\"\"", "£Q");
        customText = customText.Replace("\"", "");
        customText = customText.Replace("£Q", "\"");
        return customText;
    }
}
