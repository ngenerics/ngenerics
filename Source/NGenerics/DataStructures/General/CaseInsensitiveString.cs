using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using NGenerics.Util;

namespace NGenerics.DataStructures.General
{
    [Serializable, ComVisible(true)]
    public sealed class CaseInsensitiveString : IComparable, ICloneable, IConvertible, IComparable<string>, IEnumerable<char>, IEquatable<string>, ISerializable, IXmlSerializable
    {
        public CaseInsensitiveString()
        {
            Value = string.Empty;
        }

        public CaseInsensitiveString(string value)
        {
            Guard.ArgumentNotNull(value, "value");
            Value = value;
        }

        protected CaseInsensitiveString(SerializationInfo info, StreamingContext context)
        {
            Guard.ArgumentNotNull(info, "info");
            Value = (string)info.GetValue("StringValue", typeof(string));
        }

        public object Clone()
        {
            return Value.Clone();
        }


        public int CompareTo(object obj)
        {
            return Value.CompareTo(obj);
        }

        public int CompareTo(string other)
        {
            return Value.CompareTo(other);
        }

        public bool Contains(string value)
        {
            return Value.ToUpperInvariant().Contains(value.ToUpperInvariant());
        }

        public void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count)
        {
            Value.CopyTo(sourceIndex, destination, destinationIndex, count);
        }

        public bool EndsWith(string value)
        {
            return Value.EndsWith(value, StringComparison.InvariantCultureIgnoreCase);
        }

        public bool EndsWith(string value, StringComparison comparisonType)
        {
            return Value.EndsWith(value, comparisonType);
        }

        public bool EndsWith(string value, bool ignoreCase, CultureInfo culture)
        {
            return Value.EndsWith(value, ignoreCase, culture);
        }

        public bool Equals(string other)
        {
            return (this == other);
        }

        public override bool Equals(object obj)
        {
            var strB = obj as string;
            if (strB == null)
            {
                return false;
            }

            return Equals(strB);
        }
        public override int GetHashCode()
        {
            return Value.ToUpper().GetHashCode();
        }

        private static bool EqualsHelper(CaseInsensitiveString left, CaseInsensitiveString right)
        {
            return left.Value.Equals(right.Value, StringComparison.InvariantCultureIgnoreCase);
        }

        public CaseInsensitiveString GetLastAfter(string after)
        {
            Guard.ArgumentNotNullOrEmptyString(after, "after");
            if (Contains(after))
            {
                var dotIndex = LastIndexOf(after);
                return Substring(dotIndex + 1, (Length - dotIndex) - 1);
            }
            return Value;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Guard.ArgumentNotNull(info, "info");
            info.AddValue("StringValue", Value);
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public TypeCode GetTypeCode()
        {
            return Value.GetTypeCode();
        }

        public int IndexOf(char value)
        {
            return Value.IndexOf(value.ToString(), StringComparison.InvariantCultureIgnoreCase);
        }

        public int IndexOf(string value)
        {
            return Value.IndexOf(value, StringComparison.InvariantCultureIgnoreCase);
        }

        public int IndexOf(char value, int startIndex)
        {
            return Value.IndexOf(value.ToString(), startIndex, StringComparison.InvariantCultureIgnoreCase);
        }

        public int IndexOf(string value, int startIndex)
        {
            return Value.IndexOf(value, startIndex, StringComparison.InvariantCultureIgnoreCase);
        }

        public int IndexOf(char value, int startIndex, int count)
        {
            return Value.IndexOf(value.ToString(), startIndex, count, StringComparison.InvariantCultureIgnoreCase);
        }

        public int IndexOf(string value, int startIndex, int count)
        {
            return Value.IndexOf(value, startIndex, count, StringComparison.InvariantCultureIgnoreCase);
        }

        public int IndexOfAny(char[] anyOf)
        {
            return Value.IndexOfAny(anyOf);
        }

        public int IndexOfAny(char[] anyOf, int startIndex)
        {
            return Value.IndexOfAny(anyOf, startIndex);
        }

        public int IndexOfAny(char[] anyOf, int startIndex, int count)
        {
            return Value.IndexOfAny(anyOf, startIndex, count);
        }

        public CaseInsensitiveString Insert(int startIndex, string value)
        {
            return Value.Insert(startIndex, value);
        }

        public bool IsNormalized()
        {
            return Value.IsNormalized();
        }

        public bool IsNormalized(NormalizationForm normalizationForm)
        {
            return Value.IsNormalized(normalizationForm);
        }

        public int LastIndexOf(char value)
        {
            return Value.LastIndexOf(value.ToString(), StringComparison.InvariantCultureIgnoreCase);
        }

        public int LastIndexOf(string value)
        {
            return Value.LastIndexOf(value, StringComparison.InvariantCultureIgnoreCase);
        }

        public int LastIndexOf(char value, int startIndex)
        {
            return Value.LastIndexOf(value.ToString(), startIndex, StringComparison.InvariantCultureIgnoreCase);
        }

        public int LastIndexOf(string value, int startIndex)
        {
            return Value.LastIndexOf(value, startIndex, StringComparison.InvariantCultureIgnoreCase);
        }

        public int LastIndexOf(string value, StringComparison comparisonType)
        {
            return Value.LastIndexOf(value, comparisonType);
        }

        public int LastIndexOf(char value, int startIndex, int count)
        {
            return Value.LastIndexOf(value.ToString(), startIndex, count, StringComparison.InvariantCultureIgnoreCase);
        }

        public int LastIndexOf(string value, int startIndex, int count)
        {
            return Value.LastIndexOf(value, startIndex, count, StringComparison.InvariantCultureIgnoreCase);
        }

        public int LastIndexOf(string value, int startIndex, StringComparison comparisonType)
        {
            return Value.LastIndexOf(value, startIndex, comparisonType);
        }

        public int LastIndexOf(string value, int startIndex, int count, StringComparison comparisonType)
        {
            return Value.LastIndexOf(value, startIndex, count, comparisonType);
        }

        public int LastIndexOfAny(char[] anyOf)
        {
            return Value.LastIndexOfAny(anyOf);
        }

        public int LastIndexOfAny(char[] anyOf, int startIndex)
        {
            return Value.LastIndexOfAny(anyOf, startIndex);
        }

        public int LastIndexOfAny(char[] anyOf, int startIndex, int count)
        {
            return Value.LastIndexOfAny(anyOf, startIndex, count);
        }

        public CaseInsensitiveString Normalize()
        {
            return Value.Normalize();
        }

        public CaseInsensitiveString Normalize(NormalizationForm normalizationForm)
        {
            return Value.Normalize(normalizationForm);
        }

        public static bool operator ==(CaseInsensitiveString left, CaseInsensitiveString right)
        {
            return (ReferenceEquals(left, right) || ((!ReferenceEquals(left, null) && !ReferenceEquals(right, null)) && EqualsHelper(left, right)));
        }

        public static implicit operator string(CaseInsensitiveString value)
        {
            if (value == null)
            {
                return null;
            }
            return value.Value;
        }

        public static implicit operator CaseInsensitiveString(string value)
        {
            if (value == null)
            {
                return null;
            }
            return new CaseInsensitiveString(value);
        }

        public static bool operator !=(CaseInsensitiveString left, CaseInsensitiveString right)
        {
            return !(left == right);
        }

        public CaseInsensitiveString PadLeft(int totalWidth)
        {
            return Value.PadLeft(totalWidth);
        }

        public CaseInsensitiveString PadLeft(int totalWidth, char paddingChar)
        {
            return Value.PadLeft(totalWidth, paddingChar);
        }

        public CaseInsensitiveString PadRight(int totalWidth)
        {
            return Value.PadRight(totalWidth);
        }

        public CaseInsensitiveString PadRight(int totalWidth, char paddingChar)
        {
            return Value.PadRight(totalWidth, paddingChar);
        }

        public void ReadXml(XmlReader reader)
        {
            Value = reader.ReadElementContentAsString();
        }

        public CaseInsensitiveString Remove(int startIndex)
        {
            return Value.Remove(startIndex);
        }

        public CaseInsensitiveString Remove(int startIndex, int count)
        {
            return Value.Remove(startIndex, count);
        }

        public CaseInsensitiveString RemoveEnd(string toRemove)
        {
            Guard.ArgumentNotNullOrEmptyString(toRemove, "toRemove");
            if (EndsWith(toRemove))
            {
                return Substring(0, Length - toRemove.Length);
            }
            return this;
        }

        public CaseInsensitiveString Replace(char oldChar, char newChar)
        {
            return Value.Replace(oldChar, newChar);
        }

        public CaseInsensitiveString Replace(string oldValue, string newValue)
        {
            return Value.Replace(oldValue, newValue);
        }

        public CaseInsensitiveString[] Split(params char[] separator)
        {
            return StringArrayTo(Value.Split(separator));
        }

        public CaseInsensitiveString[] Split(char[] separator, int count)
        {
            return StringArrayTo(Value.Split(separator, count));
        }

        [ComVisible(false)]
        public CaseInsensitiveString[] Split(char[] separator, StringSplitOptions options)
        {
            return StringArrayTo(Value.Split(separator, options));
        }

        [ComVisible(false)]
        public CaseInsensitiveString[] Split(string[] separator, StringSplitOptions options)
        {
            return StringArrayTo(Value.Split(separator, options));
        }

        [ComVisible(false)]
        public CaseInsensitiveString[] Split(char[] separator, int count, StringSplitOptions options)
        {
            return StringArrayTo(Value.Split(separator, count, options));
        }

        [ComVisible(false)]
        public CaseInsensitiveString[] Split(string[] separator, int count, StringSplitOptions options)
        {
            return StringArrayTo(Value.Split(separator, count, options));
        }

        public bool StartsWith(string value)
        {
            return Value.StartsWith(value, StringComparison.InvariantCultureIgnoreCase);
        }

        [ComVisible(false)]
        public bool StartsWith(string value, StringComparison comparisonType)
        {
            return Value.StartsWith(value, comparisonType);
        }

        public bool StartsWith(string value, bool ignoreCase, CultureInfo culture)
        {
            return Value.StartsWith(value, ignoreCase, culture);
        }

        private static CaseInsensitiveString[] StringArrayTo(string[] strings)
        {
            var caseInsensitiveStrings = new CaseInsensitiveString[strings.Length];
            for (var index = 0; index < strings.Length; index++)
            {
                caseInsensitiveStrings[index] = strings[index];
            }
            return caseInsensitiveStrings;
        }

        public CaseInsensitiveString Substring(int startIndex)
        {
            return Value.Substring(startIndex);
        }

        public CaseInsensitiveString Substring(int startIndex, int length)
        {
            return Value.Substring(startIndex, length);
        }

        IEnumerator<char> IEnumerable<char>.GetEnumerator()
        {
            return Value.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Value.GetEnumerator();
        }

        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToBoolean(provider);
        }

        byte IConvertible.ToByte(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToByte(provider);
        }

        char IConvertible.ToChar(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToChar(provider);
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToDateTime(provider);
        }

        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToDecimal(provider);
        }

        double IConvertible.ToDouble(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToDouble(provider);
        }

        short IConvertible.ToInt16(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToInt16(provider);
        }

        int IConvertible.ToInt32(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToInt32(provider);
        }

        long IConvertible.ToInt64(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToInt64(provider);
        }

        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToSByte(provider);
        }

        float IConvertible.ToSingle(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToSingle(provider);
        }

        object IConvertible.ToType(Type type, IFormatProvider provider)
        {
            return ((IConvertible)Value).ToType(type, provider);
        }

        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToUInt16(provider);
        }

        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToUInt32(provider);
        }

        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToUInt64(provider);
        }

        public char[] ToCharArray()
        {
            return Value.ToCharArray();
        }

        public char[] ToCharArray(int startIndex, int length)
        {
            return Value.ToCharArray(startIndex, length);
        }

        public string ToLower()
        {
            return Value.ToLower();
        }

        public string ToLower(CultureInfo culture)
        {
            return Value.ToLower(culture);
        }

        public string ToLowerInvariant()
        {
            return Value.ToLowerInvariant();
        }

        public override string ToString()
        {
            return Value;
        }

        public string ToString(IFormatProvider provider)
        {
            return Value.ToString(provider);
        }

        public string ToUpper()
        {
            return Value.ToUpper();
        }

        public string ToUpper(CultureInfo culture)
        {
            return Value.ToUpper(culture);
        }

        public string ToUpperInvariant()
        {
            return Value.ToUpperInvariant();
        }

        public CaseInsensitiveString Trim()
        {
            return Value.Trim();
        }

        public CaseInsensitiveString Trim(params char[] trimChars)
        {
            return Value.Trim(trimChars);
        }

        public CaseInsensitiveString TrimEnd(params char[] trimChars)
        {
            return Value.TrimEnd(trimChars);
        }

        public CaseInsensitiveString TrimStart(params char[] trimChars)
        {
            return Value.TrimStart(trimChars);
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteValue(Value);
        }

        // Properties
        public char this[int index]
        {
            get
            {
                return Value[index];
            }
        }

        public int Length
        {
            get
            {
                return Value.Length;
            }
        }

        public string Value { get; set; }
    }
}