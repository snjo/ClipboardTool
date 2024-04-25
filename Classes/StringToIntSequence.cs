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
