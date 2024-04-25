using ClipboardTool.Properties;
using DebugTools;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace ClipboardTool.Classes;

internal class SolveEquation
{
    [SupportedOSPlatform("windows")]
    public static string Solve(string mixedText, bool round)
    {
        Debug.WriteLine($"Solve equation: '{mixedText}', round: {round}");
        string result = "";
        string tagStart = "[";
        string tagEnd = "]";
        string escapeTag = "\\";
        string escapeTemp = "¤";

        mixedText = mixedText.Replace(escapeTag + tagStart, escapeTemp);
        string[] segments = mixedText.Split(tagStart);
        if (segments.Length > 0)
        {
            foreach (string segment in segments)
            {
                string segmentUnEscaped = segment.Replace(escapeTemp, tagStart);
                segmentUnEscaped = segmentUnEscaped.Replace(escapeTag + tagEnd, escapeTemp);
                string[] equationAndText = segmentUnEscaped.Split(tagEnd, 2);
                string? equation = null;
                string? text = null;

                if (equationAndText.Length == 1)
                    text = equationAndText[0].Replace(escapeTemp, tagEnd);
                if (equationAndText.Length > 1)
                {
                    equation = equationAndText[0];
                    equation = equation.Replace(",", "."); // error if using , as decimal separator
                    equation = equation.Replace(" ", ""); // error if using spaces
                    text = equationAndText[1].Replace(escapeTemp, tagEnd);
                }

                string answer = "";

                if (equation != null)
                {
                    Dbg.WriteWithCaller("Equation: " + equation);
                    DataTable dt = new DataTable();
                    try
                    {
                        var comp = dt.Compute(equation, "");
                        if (round)
                        {
                            double num = Convert.ToDouble(comp);
                            Debug.WriteLine("num: " + num);
                            answer = Math.Round(num).ToString();
                        }
                        else
                        {
                            answer = comp.ToString() + "";
                        }
                        Dbg.WriteWithCaller("Equation result: " + answer);
                    }
                    catch
                    {
                        if (Settings.Default.MathWarning)
                            MessageBox.Show("Can't solve equation:" + Environment.NewLine + equation, ProcessingCommands.Math.Name + " error");
                        Dbg.Writeline("Can't compute equation: " + equation);
                    }
                }
                result += answer + text;
            }
        }
        return result;
    }
}
