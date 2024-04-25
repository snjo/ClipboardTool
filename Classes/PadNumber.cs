namespace ClipboardTool.Classes;

internal class PadNumber
{
    public static void Convert(ref string customText, ref int padNumber)
    {
        if (customText.Contains(ProcessingCommands.PadNumber2.Name))
        {
            customText = customText.Replace(ProcessingCommands.PadNumber2.Name, "");
            padNumber = 2;
        }
        if (customText.Contains(ProcessingCommands.PadNumber3.Name))
        {
            customText = customText.Replace(ProcessingCommands.PadNumber3.Name, "");
            padNumber = 3;
        }
    }
}
