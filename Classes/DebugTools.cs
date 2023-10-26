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

        public static void DebugObjects(string title = "", string prefix = "   ", params object[] o)
        {
            if (title.Length > 0) Debug.WriteLine(title);
            foreach (object obj in o)
            {
                Debug.WriteLine(prefix + NameAndType(obj));
            }
        }

        public static string DebugValues(string title = "", string prefixPadding = "   ", params object[] o)
        {
            string result = string.Empty;
            if (title.Length > 0) result += title;
            foreach (object obj in o)
            {
                result += Environment.NewLine + prefixPadding + obj.ToString();
            }
            Debug.WriteLine(result);
            return result;
        }

        //public static void DebugValues(params object[] o)
        //{
        //    foreach (object obj in o)
        //    {
        //        Debug.WriteLine(obj.ToString());
        //    }
        //}

        public static void Writeline(params string[] texts)
        {
            string result = "";
            foreach (object t in texts)
            {
                result += t;
            }
            
            Debug.WriteLine("Debug: " + result);
        }

        public static void WriteWithCaller(string text, [CallerMemberNameAttribute] string callerName = "", [CallerLineNumber] int sourceLineNumber = 0, [CallerFilePath] string callerFile = "")
        {
            string result = ">> " + callerName + ", line " + sourceLineNumber + " in " + callerFile + Environment.NewLine;
            result += ":  " + text;
            Debug.WriteLine(result);
        }

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
