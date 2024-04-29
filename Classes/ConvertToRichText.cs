using ClipboardTool.Properties;
using DebugTools;
using System.Text;

namespace ClipboardTool.Classes;

internal class ConvertToRichText
{
    /// <summary>
    /// Parses tags into Rich Text, outputs both plain and rich text.
    /// </summary>
    /// <param name="plainText"></param>
    /// <returns>string PlainText, string RichText</returns>
    public static (string PlainText, string RichText) Convert(string plainText)
    {
        //https://www.biblioscape.com/rtf15_spec.htm
        Dbg.WriteWithCaller("Parsing Rich Text: ");

        RichTextBox rtfBox = new RichTextBox();
        StringBuilder builder = new StringBuilder();
        string plainTextResult = "";
        string richTextResult = "";
        string tagStart = "<";
        string tagEnd = ">";
        string escapeTag = "\\";
        string escapeTemp = "¤";

        plainText = plainText.Replace(escapeTag + tagStart, escapeTemp);
        plainText = plainText.Replace(Environment.NewLine, @"\par "); // add line breaks that RTF ignores back in
        string[] segments = plainText.Split(tagStart);
        if (segments.Length > 0)
        {
            foreach (string segment in segments)
            {
                string segmentUnEscaped = segment.Replace(escapeTemp, tagStart);
                segmentUnEscaped = segmentUnEscaped.Replace(escapeTag + tagEnd, escapeTemp);

                string[] tagAndText = segmentUnEscaped.Split(tagEnd, 2);
                string? tag = null;
                string? text = null;
                if (tagAndText.Length == 1)
                    text = tagAndText[0].Replace(escapeTemp, tagEnd);
                if (tagAndText.Length > 1)
                {
                    tag = tagAndText[0];
                    text = tagAndText[1].Replace(escapeTemp, tagEnd);
                }


                if (tag != null && text != null)
                {
                    switch (tag)
                    {
                        case "b": // bold
                            //rtfBox.SelectionFont = new Font(rtfBox.Font, FontStyle.Bold);
                            SetRTFTag(builder, text, @"\b ", @"\b0 ");
                            break;
                        case "i": // italic
                            //rtfBox.SelectionFont = new Font(rtfBox.Font, FontStyle.Bold);
                            SetRTFTag(builder, text, @"\i ", @"\i0 ");
                            break;
                        case "strike": // strikethrough
                            SetRTFTag(builder, text, @"\strike ", @"\strike0 ");
                            break;
                        case "ul": // underline
                            SetRTFTag(builder, text, @"\ul ", @"\ul0 ");
                            break;
                        case "ulw": // underlined words, but spaces are not
                            SetRTFTag(builder, text, @"\ulw ", @"\ulw0 ");
                            break;
                        case "plain": // plain (remove formatting)
                            SetRTFTag(builder, text, @"\plain ", @"");
                            break;
                        case "black":
                            SetRTFTag(builder, text, @"\cf1 ", @"");
                            break;
                        case "white":
                            SetRTFTag(builder, text, @"\cf2 ", @"");
                            break;
                        case "gray":
                            SetRTFTag(builder, text, @"\cf3 ", @"");
                            break;
                        case "red":
                            SetRTFTag(builder, text, @"\cf4 ", @"");
                            break;
                        case "green":
                            SetRTFTag(builder, text, @"\cf5 ", @"");
                            break;
                        case "blue":
                            SetRTFTag(builder, text, @"\cf6 ", @"");
                            break;
                        case "default":
                            SetRTFTag(builder, text, @"\f0 ", @"");
                            break;
                        case "serif":
                            SetRTFTag(builder, text, @"\f1 ", @"");
                            break;
                        case "sans":
                            SetRTFTag(builder, text, @"\f2 ", @"");
                            break;
                        case "mono":
                            SetRTFTag(builder, text, @"\f3 ", @"");
                            break;
                        case "script":
                            SetRTFTag(builder, text, @"\f4 ", @"");
                            break;
                        case "decor":
                            SetRTFTag(builder, text, @"\f5 ", @"");
                            break;
                        case "symbol":
                            SetRTFTag(builder, text, @"\f6 ", @"");
                            break;
                        default:
                            if (tagAndText[0].Length > 0) // unknown RTF code, pass it on
                            {
                                SetRTFTag(builder, text, @"\" + tagAndText[0] + " ", @"");
                            }
                            else builder.Append(text); // empy tag <>: regular text
                            break;
                    }
                }
                else
                {
                    if (segment.Length > 0)
                        builder.Append(text);
                }
                richTextResult = rtfHeader + FontTable() + ColorTable() + builder.ToString() + @"}";
                rtfBox.Rtf = richTextResult;
            }
        }
        plainTextResult = rtfBox.Text; // destroys unicode like smileys
        rtfBox.Dispose();
        //Dbg.WriteWithCaller("Original Text: " + plainText);
        //Debug.WriteLine("Plain text result: " + plainTextResult);
        //Debug.WriteLine("Rich text result: " + richTextResult);
        return (PlainText: plainTextResult, RichText: richTextResult);
    }

    private static void SetRTFTag(StringBuilder builder, string text, string start, string end)
    {
        if (text.Length > 0)
        {
            builder.Append(start);
            builder.Append(text);
            builder.Append(end);
        }
    }

    const string rtfHeader = @"{\rtf1\ansi ";
    const string colorBlack = @"\red0\green0\blue0;";
    const string colorWhite = @"\red255\green255\blue255;";
    const string colorGray = @"\red180\green180\blue180;";
    const string colorRed = @"\red255\green0\blue0;";
    const string colorGreen = @"\red0\green255\blue0;";
    const string colorBlue = @"\red0\green0\blue255;";
    //string fontTable = @"\deff0{\fonttbl{\f0\fnil Default Sans Serif;}{\f1\froman Times New Roman;}{\f2\fswiss Arial;}{\f3\fmodern Courier New;}{\f4\fscript Script MT Bold;}{\f5\fdecor Old English Text MT;}}";
    //string colorTableDefault = @"\red80\green120\blue200;\red255\green180\blue1800;";
    // fnil Default Sans Serif should work for Lotus Notes

    private static string ColorTable()
    {
        if (Settings.Default.RTFallowColorTable)
        {
            return @"{\colortbl;" + colorBlack + colorWhite + colorGray + colorRed + colorGreen + colorBlue + Settings.Default.RTFcolors + @"}";
        }
        else return string.Empty;
    }

    private static string FontTable()
    {
        if (Settings.Default.RTFallowFontTable)
        {
            return Settings.Default.RTFfonts;
        }
        else
        {
            return string.Empty;
        }
    }
}

