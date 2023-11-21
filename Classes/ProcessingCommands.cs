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
        public List<Command> Commands;
        public Command Date;
        public Command Time;
        public Command ClipboardPlain;
        public Command ClipboardUpper;
        public Command ClipboardLower;
        public Command Number;
        public Command Increment;
        public Command Decrement;
        public Command PadNumber2;
        public Command PadNumber3;
        public Command MemSlot1;
        public Command MemSlot2;
        public Command MemSlot3;
        public Command ExcelQuotes;
        public Command Replace;
        public Command ValueSplitComma;
        public Command ValueSplitSemicolon;
        public Command ValueSplitSpace;
        public Command List;
        public Command Prompt;
        public Command Math;
        public Command Round;
        public Command RTF;
        public Command ClipboardCharToInt;
        public Command None;

        public ProcessingCommands()
        {
            Commands = new List<Command>();
            Date = new Command(name: "$d", description: "Outputs current date. Format/Culture can be set in Options", Commands);
            Time = new Command(name: "$t", description: "Outputs current time", Commands);
            ClipboardPlain = new Command(name: "$cp", description: "Clipboard (plain text)", Commands);
            ClipboardUpper = new Command(name: "$cu", description: "Clipboard in upper case", Commands);
            ClipboardLower = new Command(name: "$cl", description: "Clipboard in lower case", Commands);
            Number = new Command(name: "$i", description: "Output the number from the upDown spinner ", Commands);
            Increment = new Command(name: "$+", description: "Output the number from the upDown spinner, then increment it", Commands);
            Decrement = new Command(name: "$-", description: "Output the number from the upDown spinner, then decrement it", Commands);
            PadNumber2 = new Command(name: "$n2", description: "Flag: pad number to 2 digits with zeroes (1 becomes 01)", Commands);
            PadNumber3 = new Command(name: "$n3", description: "Flag: pad number to 3 digits with zeroes (1 becomes 001)", Commands);
            MemSlot1 = new Command(name: "$m1", description: "Contents of memory slot 1", Commands);
            MemSlot2 = new Command(name: "$m2", description: "Contents of memory slot 2", Commands);
            MemSlot3 = new Command(name: "$m3", description: "Contents of memory slot 3", Commands);
            ExcelQuotes = new Command(name: "$eq", description: "Flag: Convert \"\" to \", and removes single \"", Commands);
            Replace = new Command(name: "$rep", description: "Replace text in clipboard. Use mem slot 1 & 2 as from/to strings", Commands);
            ValueSplitComma = new Command(name: "$vcm", description: "Split value in slot 1 with COMMA, output value[number]", Commands);
            ValueSplitSemicolon = new Command(name: "$vsc", description: "Split value in slot 1 with SEMICOLON, output value[number]", Commands);
            ValueSplitSpace = new Command(name: "$vsp", description: "Split value in slot 1 with SPACE, output value[number]", Commands);
            List = new Command(name: "$list", description: "Split lines in main textbox(skips line 1), output value[number]", Commands);
            Prompt = new Command(name: "$prompt", description: "Opens a popup box to insert a text value", Commands);
            Math = new Command(name: "$Math", description: "Flag: Solves equations enclosed in [] brackets", Commands);
            Round = new Command(name: "$Round", description: "Flag: Alters $Math to round off results. ", Commands);
            RTF = new Command(name: "$RTF", description: "Output Rich Text (.rtf format)", Commands);
            ClipboardCharToInt = new Command(name: "$cci", description: "Convert text to character numbers for debugging", Commands);
            None = new Command(name: "$X", description: "No processing, but separates a tag from the rest of the text", Commands);
        }

        public string GetListAsText(int padCommand = 8, string separator = "")
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
