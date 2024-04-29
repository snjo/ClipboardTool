using System.Diagnostics;
using System.Text;

namespace ClipboardTool.Classes
{
    public class DigitsToWords
    {
        public static string ToWords(long number)
        {
            List<string> words = [];
            if (number > long.MaxValue)
            {
                return "a number too high to count";
            }
            if (number == 0)
            {
                return "zero";
            }
            if (number < 0)
            {
                number = Math.Abs(number);
                words.Add("minus");
            }

            long onesAndTens = number % 100;
            long hundreds = (number / 100) % 10;
            long thousands = (number / 1000) % 1000;
            long millions = (number / 1000000) % 1000;
            long billions = (number / 1000000000) % 1000;
            long trillions = (number / 1000000000000) % 1000;
            long quadrillions = (number / 1000000000000000) % 1000;
            long quintillions = (number / 1000000000000000000) % 1000;

            if (quintillions > 0)
            {
                words.Add(ToWords(quintillions));
                words.Add("quintillion");
            }
            if (quadrillions > 0)
            {
                words.Add(ToWords(quadrillions));
                words.Add("quadrillion");
            }
            if (trillions > 0)
            {
                words.Add(ToWords(trillions));
                words.Add("trillion");
            }
            if (billions > 0)
            {
                words.Add(ToWords(billions));
                words.Add("billion");
            }
            if (millions > 0)
            {
                words.Add(ToWords(millions));
                words.Add("million");
            }
            if (thousands > 0)
            {
                words.Add(ToWords(thousands));
                words.Add("thousand");
            }
            if (hundreds > 0)
            {
                words.Add(ToNumeralWordLow(hundreds));
                words.Add("hundred");
            }
            if (onesAndTens > 0)
            {
                if (number > 99) words.Add("and");
                words.Add(OnesAndTensToText(onesAndTens));
            }

            string result = string.Join(" ", words);
            Debug.WriteLine($"result {result}. length: {words.Count}");
            return result;
        }

        private static string OnesAndTensToText(long num)
        {
            if (num > 19)
            {
                return ToNumeralWordHigh(num);
            }
            else
            {
                return ToNumeralWordLow(num);
            }
        }

        private static string ToNumeralWordHigh(long number)
        {
            long tens = number / 10;
            string result = tens switch
            {
                2 => "twenty",
                3 => "thirty",
                4 => "fourty",
                5 => "fifty",
                6 => "sixty",
                7 => "seventy",
                8 => "eighty",
                9 => "ninety",
                _ => ""
            };
            if (number % 10 > 0)
            {
                return result + " " + ToNumeralWordLow(number % 10);
            }
            else
            {
                return result;
            }
        }

        private static string ToNumeralWordLow(long number)
        {
            return number switch
            {
                0 => "",
                1 => "one",
                2 => "two",
                3 => "three",
                4 => "four",
                5 => "five",
                6 => "six",
                7 => "seven",
                8 => "eight",
                9 => "nine",
                10 => "ten",
                11 => "eleven",
                12 => "twelve",
                13 => "thirteen",
                14 => "fourteen",
                15 => "fifteen",
                16 => "sixteen",
                17 => "seventeen",
                18 => "eighteen",
                19 => "nineteen",
                _ => ""
            };
        }

        public static string ToWords(string digits)
        {
            Debug.WriteLine($"Received number {digits}");
            digits = digits.Trim();
            digits = digits.Replace(" ", "");
            if (digits.Length >= long.MaxValue.ToString().Length)
            {
                return "a very large number";
            }
            string decimalsText = "";
            string decimalSplitWord = "";

            int lastDot = digits.LastIndexOf('.');
            int lastComma = digits.LastIndexOf(',');

            if (lastDot > -1 && lastComma > -1) // remove cosmetic . or , in numbers like 1.000.000,50
            {
                if (lastDot > lastComma)
                {
                    digits = digits.Replace(",", "");
                }
                else
                {
                    digits = digits.Replace(".", "");
                }
            }

            if (digits.Contains('.'))
            {
                string[] split = digits.Split('.', 2);
                decimalSplitWord = "point";
                digits = split[0];
                if (split.Length > 1) decimalsText = split[1];
            }
            else if (digits.Contains(','))
            {
                string[] split = digits.Split(',', 2);
                decimalSplitWord = "comma";
                digits = split[0];
                if (split.Length > 1) decimalsText = split[1];
            }
            if (digits.Length == 0) digits = "0";

            if (long.TryParse(digits, out long parsedInts) == false)
            {
                return "NaN";
            }
            //long parsedInts = long.Parse(digits);

            string result = ToWords(parsedInts);

            if (decimalsText.Length > 0)
            {
                //long decimals = long.Parse(decimalsText);
                if (long.TryParse(decimalsText, out long decimals) == false)
                {
                    return "NaN";
                }
                result += " " + decimalSplitWord + " " + ToWords(decimals);
            }

            return result;
        }

        public static string ProcessDigitsEnclosed(string text, bool UpperCase = false)
        {
            Debug.WriteLine($"Process digit text: '{text}'");
            string tag = ProcessingCommands.DigitToWord.Name;
            StringBuilder stringBuilder = new();

            string[] sections = text.Split(tag, StringSplitOptions.RemoveEmptyEntries);
            int firstSection = 1;
            if (text.StartsWith(tag))
            {
                firstSection = 0;
                Debug.WriteLine("starting with tag");
            }
            else
            {
                stringBuilder.Append(sections[0]);
                Debug.WriteLine("adding starting text");
            }

            for (int i = firstSection; i < sections.Length; i++)
            {
                int start = 0;
                int end = -1;
                Debug.WriteLine($"Digits start: {start}");
                if (start < sections[i].Length) // check that we're not at the end to avoid index error
                {
                    if (sections[i][start] == '{')
                    {
                        Debug.WriteLine("Found {");
                        end = sections[i].IndexOf('}', start + 1);
                        if (end < 0)
                        {
                            DebugTools.Dbg.WriteWithCaller("No end } for Digit to Word value");
                        }
                        else
                        {
                            int startDigit = start + 1;
                            string enclosedDigits = sections[i][startDigit..end];
                            Debug.WriteLine($"Found digits: {enclosedDigits}");
                            if (enclosedDigits.Length > 0)
                            {
                                stringBuilder.Append(ToWords(enclosedDigits));
                            }
                        }
                    }
                    else
                    {
                        Debug.WriteLine($"No {{, char at {start} was '{sections[i][start]}'");
                    }
                    if (end > -1)
                    {
                        stringBuilder.Append(sections[i][(end + 1)..]);
                    }
                    else
                    {
                        stringBuilder.Append(sections[i]);
                    }
                }
                else
                {
                    Debug.WriteLine($"Tag at end of text, aborting");
                }
            }

            //DebugTools.Dbg.WriteWithCaller("locations of tag: " + tagLocations.ToText());

            if (UpperCase)
            {
                return stringBuilder.ToString().ToUpper();
            }
            return stringBuilder.ToString();
        }
    }
}
