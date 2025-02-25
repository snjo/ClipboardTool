using System.Diagnostics;
using System.Runtime.Versioning;
using System.Text;



namespace ClipboardTool.Classes;

[SupportedOSPlatform("windows")]

public static class PromptForText
{
    public static string Process(string text)
    {
        List<int> foundTags = text.IndexOfAll(ProcessingCommands.Prompt.Name);
        Debug.WriteLine($"foundTags {foundTags.Count}");

        List<string> promptResults = TextPrompt.PromptMultiple(foundTags.Count);

        if (promptResults.Count == 0)
        {
            return text.Replace(ProcessingCommands.Prompt.Name, "");
        }

        StringBuilder sb = new();

        int lastTagLoc = text.Length;
        for (int i = foundTags.Count - 1; i >= 0; i--)
        {
            Debug.WriteLine($"tag {i} at {foundTags[i]}");
            sb.Insert(0, (text[(foundTags[i] + ProcessingCommands.Prompt.Name.Length)..lastTagLoc]));
            sb.Insert(0, promptResults[i]);
            lastTagLoc = foundTags[i];
        }
        sb.Insert(0, text[0..lastTagLoc]);
        return sb.ToString();
    }
}
