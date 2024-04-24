using System.Xml.Linq;

namespace ClipboardTool.Classes
{
    public class Command
    {
        public string Name;
        public string Description;
        public Command(string name, string description, List<Command> commandList)
        {
            Name = name;
            Description = description;
            commandList.Add(this);
        }
    }
    public class ProcessingCommands
    {
        public static readonly List<Command> Commands = new List<Command>();
        public static Command Date = new Command(name: "$d", description: "Outputs current date. Format/Culture can be set in Options", Commands);
        public static Command Time = new Command(name: "$t", description: "Outputs current time", Commands);
        public static Command ClipboardPlain = new Command(name: "$cp", description: "Clipboard (plain text)", Commands);
        public static Command ClipboardUpper = new Command(name: "$cu", description: "Clipboard in upper case", Commands);
        public static Command ClipboardLower = new Command(name: "$cl", description: "Clipboard in lower case", Commands);
        public static Command Number = new Command(name: "$i", description: "Output the number from the upDown spinner ", Commands);
        public static Command Increment = new Command(name: "$+", description: "Output the number from the upDown spinner, then increment it", Commands);
        public static Command Decrement = new Command(name: "$-", description: "Output the number from the upDown spinner, then decrement it", Commands);
        public static Command PadNumber2 = new Command(name: "$n2", description: "Flag: pad number to 2 digits with zeroes (1 becomes 01)", Commands);
        public static Command PadNumber3 = new Command(name: "$n3", description: "Flag: pad number to 3 digits with zeroes (1 becomes 001)", Commands);
        public static Command MemSlot1 = new Command(name: "$m1", description: "Contents of memory slot 1", Commands);
        public static Command MemSlot2 = new Command(name: "$m2", description: "Contents of memory slot 2", Commands);
        public static Command MemSlot3 = new Command(name: "$m3", description: "Contents of memory slot 3", Commands);
        public static Command ExcelQuotes = new Command(name: "$eq", description: "Flag: Convert \"\" to \", and removes single \"", Commands);
        public static Command Replace = new Command(name: "$rep", description: "Replace text in clipboard. Use mem slot 1 & 2 as from/to strings", Commands);
        public static Command ValueSplitComma = new Command(name: "$vcm", description: "Split value in slot 1 with COMMA, output value[number]", Commands);
        public static Command ValueSplitSemicolon = new Command(name: "$vsc", description: "Split value in slot 1 with SEMICOLON, output value[number]", Commands);
        public static Command ValueSplitSpace = new Command(name: "$vsp", description: "Split value in slot 1 with SPACE, output value[number]", Commands);
        public static Command List = new Command(name: "$list", description: "Split lines in main textbox(skips line 1), output value[number]", Commands);
        public static Command Prompt = new Command(name: "$prompt", description: "Opens a popup box to insert a text value", Commands);
        public static Command Math = new Command(name: "$Math", description: "Flag: Solves equations enclosed in [] brackets", Commands);
        public static Command Round = new Command(name: "$Round", description: "Flag: Alters $Math to round off results. ", Commands);
        public static Command RTF = new Command(name: "$RTF", description: "Output Rich Text (.rtf format)", Commands);
        public static Command DigitToWord = new Command(name: "$DTW", description: "Translates digits in curly braces to numeral words. ex: $DTW{12} = twelve", Commands);
        public static Command DigitToWordUpperCase = new Command(name: "$DTU", "Flag: output from DTW is all upper case", Commands);
        public static Command ClipboardCharToInt = new Command(name: "$cci", description: "Convert text to character numbers for debugging", Commands);
        public static Command None = new Command(name: "$X", description: "No processing, but separates a tag from the rest of the text", Commands);

        public static string GetListAsText(int padCommand = 8, string separator = "")
        {
            string result = string.Empty;
            foreach (Command cmd in Commands)
            {
                result += (cmd.Name + separator).PadRight(padCommand) + cmd.Description + Environment.NewLine;
            }
            return result;
        }
    }
}
