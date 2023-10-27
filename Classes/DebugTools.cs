using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace DebugTools
{
    internal static class Dbg
    {
        public static string NameAndType(object o, string separator = ": ")
        {
            string objectType = o.GetType().Name;
            string objectValue = o.ToString() + "";
            return objectType + separator + objectValue;
        }

        [Conditional("DEBUG")]
        public static void DebugObjects(string title = "", string prefix = "   ", params object[] o)
        {
            if (title.Length > 0) Debug.WriteLine(title);
            foreach (object obj in o)
            {
                Debug.WriteLine(prefix + NameAndType(obj));
            }
        }

        [Conditional("DEBUG")]
        public static void DebugValues(string title = "", string prefixPadding = "   ", params object[] o)
        {
            string result = string.Empty;
            if (title.Length > 0) result += title;
            foreach (object obj in o)
            {
                result += Environment.NewLine + prefixPadding + obj.ToString();
            }
            Debug.WriteLine(result);
        }

        [Conditional("DEBUG")]
        public static void Writeline(params string[] texts)
        {
            string result = "";
            foreach (object t in texts)
            {
                result += t;
            }
            
            Debug.WriteLine(result);
        }

        [Conditional("DEBUG")]
        public static void WriteWithCaller(string text, [CallerMemberNameAttribute] string callerName = "", [CallerLineNumber] int sourceLineNumber = 0, [CallerFilePath] string callerFile = "")
        {
            string result = ">> " + callerName + ", line " + sourceLineNumber + " in " + callerFile + Environment.NewLine;
            result += ":  " + text;
            Debug.WriteLine(result);
        }

        [Conditional("DEBUG")]
        public static void WriteWithCaller(string[] texts, [CallerMemberNameAttribute] string callerName = "", [CallerLineNumber] int sourceLineNumber = 0, [CallerFilePath] string callerFile = "")
        {
            string result = ">> " + callerName + ", line " + sourceLineNumber + " in " + callerFile + sourceLineNumber + Environment.NewLine;
            foreach (object t in texts)
            {
                if (t != null)
                    result += ":  " + t;
                else
                    result += ":[null]";
            }
            Debug.WriteLine(result);
        }

        [Conditional("DEBUG")]
        public static void WriteLinesWithCaller(object[] texts, [CallerMemberNameAttribute] string callerName = "", [CallerLineNumber] int sourceLineNumber = 0, [CallerFilePath] string callerFile = "")
        {
            string result = ">> " + callerName + ", line " + sourceLineNumber + " in " + callerFile + sourceLineNumber + Environment.NewLine;
            foreach (object t in texts)
            {
                if (t != null)
                    result += ":  " + t + Environment.NewLine;
                else
                    result += ":[null]" + Environment.NewLine;
            }
            Debug.WriteLine(result);
        }

        public static object[] MakeArray(params object[] obj)
        {
            return obj;
        }
    }
}
