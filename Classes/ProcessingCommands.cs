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
        public static readonly List<Command> Commands = [];
        public static readonly Command Date = new(name: "$date", description: "Outputs current date. Format/Culture can be set in Options", Commands);
        public static readonly Command Time = new(name: "$time", description: "Outputs current time", Commands);
        public static readonly Command ClipboardPlain = new(name: "$cp", description: "Clipboard (plain text)", Commands);
        public static readonly Command ClipboardUpper = new(name: "$cu", description: "Clipboard in upper case", Commands);
        public static readonly Command ClipboardLower = new(name: "$cl", description: "Clipboard in lower case", Commands);
        public static readonly Command Number = new(name: "$number", description: "Output the number from the upDown spinner ", Commands);
        public static readonly Command NumberIncrementPost = new(name: "$postinc", description: "Increments the number of the spinner AFTER processing is done", Commands);
        public static readonly Command NumberDecrementPost = new(name: "$postdec", description: "Decrements the number of the spinner AFTER processing is done", Commands);
        public static readonly Command NumberIncrementPre = new(name: "$preinc", description: "Increments the number of the spinner BEFORE processing is done", Commands);
        public static readonly Command NumberDecrementPre = new(name: "$predec", description: "Decrements the number of the spinner BEFORE processing is done", Commands);
        public static readonly Command PadNumber2 = new(name: "$n2", description: "Flag: pad number to 2 digits with zeroes (1 becomes 01)", Commands);
        public static readonly Command PadNumber3 = new(name: "$n3", description: "Flag: pad number to 3 digits with zeroes (1 becomes 001)", Commands);
        public static readonly Command MemSlot1 = new(name: "$m1", description: "Contents of memory slot 1", Commands);
        public static readonly Command MemSlot2 = new(name: "$m2", description: "Contents of memory slot 2", Commands);
        public static readonly Command MemSlot3 = new(name: "$m3", description: "Contents of memory slot 3", Commands);
        public static readonly Command ExcelQuotes = new(name: "$eq", description: "Flag: Convert \"\" to \", and removes single \"", Commands);
        public static readonly Command Replace = new(name: "$rep", description: "Replace text in clipboard. Use mem slot 1 & 2 as from/to strings", Commands);
        public static readonly Command ValueSplitComma = new(name: "$vcm", description: "Split value in slot 1 with COMMA, output value[number]", Commands);
        public static readonly Command ValueSplitSemicolon = new(name: "$vsc", description: "Split value in slot 1 with SEMICOLON, output value[number]", Commands);
        public static readonly Command ValueSplitSpace = new(name: "$vsp", description: "Split value in slot 1 with SPACE, output value[number]", Commands);
        public static readonly Command List = new(name: "$list", description: "Split lines in main textbox (skips line 1), output value[number]", Commands);
        public static readonly Command ListLines1 = new(name: "$lln1", description: "Split lines in mem1 for use in processing from other slot/text library", Commands);
        public static readonly Command ListLines2 = new(name: "$lln2", description: "Split lines in mem2 for use in processing from other slot/text library", Commands);
        public static readonly Command ListLines3 = new(name: "$lln3", description: "Split lines in mem3 for use in processing from other slot/text library", Commands);
        public static readonly Command Prompt = new(name: "$prompt", description: "Opens a popup box to insert a text value", Commands);
        public static readonly Command Math = new(name: "$Math", description: "Flag: Solves equations enclosed in [] brackets", Commands);
        public static readonly Command Round = new(name: "$Round", description: "Flag: Alters $Math to round off results. ", Commands);
        public static readonly Command RTF = new(name: "$RTF", description: "Output Rich Text (.rtf format)", Commands);
        public static readonly Command DigitToWord = new(name: "$DTW", description: "Translates digits in curly braces to numeral words. ex: $DTW{12} = twelve", Commands);
        public static readonly Command DigitToWordUpperCase = new(name: "$DTU", "Flag: DTW output is all upper case", Commands);
        public static readonly Command DigitToWordFirstCap = new(name: "$DTF", "Flag: DTW output starts with upper case", Commands);
        public static readonly Command ClipboardCharToInt = new(name: "$cci", description: "Convert text to character numbers for debugging", Commands);
        public static readonly Command None = new(name: "$X", description: "No processing, but separates a tag from the rest of the text", Commands);

        public static string GetListAsText(int padCommand = 10, string separator = "")
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
