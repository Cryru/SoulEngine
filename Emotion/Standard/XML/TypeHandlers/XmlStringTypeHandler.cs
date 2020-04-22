﻿#region Using

using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

#endregion

namespace Emotion.Standard.XML.TypeHandlers
{
    public class XMLStringTypeHandler : XMLTypeHandler
    {
        public XMLStringTypeHandler(Type type) : base(type)
        {
        }

        public override bool Serialize(object obj, StringBuilder output, int indentation = 1, XMLRecursionChecker recursionChecker = null, string fieldName = null)
        {
            obj = SanitizeString((string) obj);
            return base.Serialize(obj, output, indentation, recursionChecker, fieldName);
        }

        public override object Deserialize(XMLReader input)
        {
            string readValue = input.GoToNextTag();
            return RestoreString(readValue);
        }

        private static readonly Regex StringSanitizeRegex = new Regex("<", RegexOptions.Compiled);
        private static readonly Regex StringRestoreRegex = new Regex("&lt;", RegexOptions.Compiled);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string SanitizeString(string str)
        {
            return StringSanitizeRegex.Replace(str, "&lt;");
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string RestoreString(string str)
        {
            return StringRestoreRegex.Replace(str, "<");
        }
    }
}