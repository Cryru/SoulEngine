﻿#region Using

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Emotion.Common;
using Emotion.Standard.Logging;

#endregion

namespace Emotion.Standard.XML.TypeHandlers
{
    public class XMLArrayTypeHandler : XMLTypeHandler
    {
        public override bool CanBeInherited { get => false; }
        protected XMLFieldHandler _elementTypeHandler;
        protected Type _elementType;

        public XMLArrayTypeHandler(Type type, Type elementType) : base(type)
        {
            _elementTypeHandler = XMLHelpers.ResolveFieldHandler(elementType, null);
            _elementType = elementType;
            RecursiveType = _elementTypeHandler.TypeHandler.IsRecursiveWith(Type);
        }

        public override bool IsRecursiveWith(Type type)
        {
            return base.IsRecursiveWith(type) || _elementTypeHandler.TypeHandler.IsRecursiveWith(type);
        }

        public override void Serialize(object obj, StringBuilder output, int indentation, XMLRecursionChecker recursionChecker)
        {
            var arr = (IEnumerable) obj;
            output.Append("\n");
            foreach (object item in arr)
            {
                // Force serialize objects in arrays, to keep length.
                if (!_elementTypeHandler.TypeHandler.ShouldSerialize(item))
                {
                    _elementTypeHandler.GetDerivedTypeHandler(item, out string derivedType);
                    output.AppendJoin(XMLFormat.IndentChar, new string[indentation + 1]);
                    output.Append(derivedType != null ? $"<{_elementTypeHandler.Name} type=\"{derivedType}\">" : $"<{_elementTypeHandler.Name}></{_elementTypeHandler.Name}>\n");
                }
                else
                {
                    _elementTypeHandler.Serialize(item, output, indentation, recursionChecker);
                }
            }
            output.AppendJoin(XMLFormat.IndentChar, new string[indentation]);
        }

        public override object Deserialize(XMLReader input)
        {
            var backingList = new List<object>();

            int depth = input.Depth;
            input.GoToNextTag();
            input.ReadTag(out string typeAttribute);
            while (input.Depth >= depth && !input.Finished)
            {
                XMLTypeHandler handler = _elementTypeHandler.TypeHandler;
                if (typeAttribute != null)
                {
                    Type derivedType = XMLHelpers.GetTypeByName(typeAttribute);
                    if (derivedType == null)
                    {
                        Engine.Log.Warning($"Couldn't find derived type of name {typeAttribute} in array.", MessageSource.XML);
                        return null;
                    }

                    handler = XMLHelpers.GetTypeHandler(derivedType);
                }

                object newObj = handler.Deserialize(input);
                backingList.Add(newObj);
                input.GoToNextTag();
                input.ReadTag(out typeAttribute);
            }

            var arr = Array.CreateInstance(_elementType, backingList.Count);
            for (var i = 0; i < backingList.Count; i++)
            {
                arr.SetValue(backingList[i], i);
            }

            return arr;
        }
    }
}