using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace net.mkv25.writer
{
    public class NameUtils
    {
        public static string FormatClassName(string className)
        {
            if(String.IsNullOrEmpty(className))
                return className;

            var invalid = System.IO.Path.GetInvalidFileNameChars().Concat(new char[]{' '});

            string newName = new string( new CultureInfo(CultureInfo.CurrentCulture.LCID, false)
                .TextInfo.ToTitleCase(className.ToLower())
                .Select(s => invalid.Contains(s) ? '_' : s).ToArray());

            newName = newName.Replace("_", "");

            return newName;
        }

        public static string FormatVariableName(string variableName)
        {
            if (String.IsNullOrEmpty(variableName))
                return variableName;

            var invalid = System.IO.Path.GetInvalidFileNameChars().Concat(new char[] { ' ' });

            string newName = new String(variableName.Select(s => invalid.Contains(s) ? '_' : s).ToArray());

            newName = newName.Replace("_", "");

            return newName;
        }

        public static string FormatClassConstantName(string variableName)
        {
            if (String.IsNullOrEmpty(variableName))
                return variableName;

            var invalid = System.IO.Path.GetInvalidFileNameChars().Concat(new char[] { ' ' }).ToList();
            invalid.Add('!');
            invalid.Add('£');
            invalid.Add('$');
            invalid.Add('%');
            invalid.Add('^');
            invalid.Add('&');
            invalid.Add('(');
            invalid.Add(')');
            invalid.Add('{');
            invalid.Add('}');
            invalid.Add('[');
            invalid.Add(']');
            invalid.Add('\'');
            invalid.Add(';');
            invalid.Add('@');

            string newName = new string(new CultureInfo(CultureInfo.CurrentCulture.LCID, false)
                .TextInfo.ToUpper(variableName)
                .Select(s => invalid.Contains(s) ? '_' : s).ToArray());

            return newName;
        }
    }
}
