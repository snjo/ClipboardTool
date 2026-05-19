using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClipboardTool.Classes
{
    public class TextLibraryEntry
    {
        public string FilePath { get; set; } = "";
        public string EntryName { get; set; } = "";
        public string[] TextContentRaw { get; set; } = [];
        public string TextContentWithoutTags { get; set; } = "";
        public Color BackgroundColor { get; set; } = Color.White;
        public bool PinnedEntry { get; set; } = false;
        public TextLibraryEntry(string name, string[] textContentRaw)
        {
            EntryName = name;
            if (EntryName.Length > 0) PinnedEntry = true;
            TextContentRaw = textContentRaw;
            BackgroundColor = Color.White;
        }

        public TextLibraryEntry(string name, string[] textContentRaw, Color color)
        {
            EntryName = name;
            if (EntryName.Length > 0) PinnedEntry = true;
            TextContentRaw = textContentRaw;
            BackgroundColor = color;
        }

        public TextLibraryEntry(string name, string textContent)
        {
            EntryName = name;
            if (EntryName.Length > 0) PinnedEntry = true;
            TextContentWithoutTags = textContent;
            BackgroundColor = Color.White;
        }
    }
}
