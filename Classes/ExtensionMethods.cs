namespace ClipboardTool.Classes
{
    public static class ExtensionMethods
    {
        public static List<int> IndexOfAll(this string sourceText, string findText)
        {
            int currentIndex = 0;
            List<int> tagLocations = [];
            while (currentIndex < sourceText.Length)
            {
                int loc = sourceText.IndexOf(findText, currentIndex);
                if (loc > -1)
                {
                    tagLocations.Add(loc);
                    currentIndex = loc + 1;
                }
                else
                {
                    break;
                }
            }
            return tagLocations;
        }

        public static string ToText(this List<int> list, string separator = ", ")
        {
            return string.Join(separator, list.ToArray());
        }

        public static string ToText(this int[] list, string separator = ", ")
        {
            return string.Join(separator, list);
        }
    }
}
