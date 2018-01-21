/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/


using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using NGenerics.Util;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Serialization;
using System.Security;
namespace NGenerics.DataStructures.General
{
    /// <summary>
    /// Represents case insensitive text as a series of Unicode characters.
    /// </summary>
    /// <remarks>
    /// All operations are performed in case insensitive manner using <see cref="StringComparison.InvariantCultureIgnoreCase"/>.
    /// </remarks>
    [ComVisible(true)]
    [Serializable]
    public sealed class CaseInsensitiveString : IComparable, IConvertible, IComparable<string>, IEquatable<string>, IEquatable<CaseInsensitiveString>, IXmlSerializable, IEnumerable<char>, ICloneable, ISerializable
    {

        /// <summary>
        /// Default constructor
        /// </summary>
        public CaseInsensitiveString()
        {
            Value = string.Empty;
        }

        /// <summary>
        /// Constrcuts CaseInsensitiveString based on <paramref name="value"/>
        /// </summary>
        /// <param name="value"></param>
        public CaseInsensitiveString(string value)
        {
            Guard.ArgumentNotNull(value, "value");
            Value = value;
        }

        private CaseInsensitiveString(SerializationInfo info, StreamingContext context)
        {
            Guard.ArgumentNotNull(info, "info");
            Value = (string)info.GetValue("StringValue", typeof(string));
        }

        /// <summary>
        /// Gets or sets the underlying case sensitive string.
        /// </summary>
        public string Value { get; set; }


        /// <summary>
        /// Gets the character at a specified character position in the current <see cref="String"/> object.
        /// </summary>
        /// <returns>
        /// A Unicode character.
        /// </returns>
        /// <param name="index">A character position in the current <see cref="String"/> object.</param>
        /// <exception cref="IndexOutOfRangeException"><paramref name="index"/> is greater than or equal to the length of this object or less than zero.</exception>
        public char this[int index] => Value[index];

        /// <summary>
        /// Gets the number of characters in the current <see cref="String"/> object.
        /// </summary>
        /// <returns>
        /// The number of characters in this instance.
        /// </returns>
        public int Length => Value.Length;

        /// <summary>
        /// Returns substring after <paramref name="after"/>
        /// </summary>
        /// <param name="after"></param>
        /// <returns></returns>
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




        /// <summary>
        /// Write the string to Xml
        /// </summary>
        /// <param name="writer"></param>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteValue(Value);
        }

        /// <summary>
        /// Reads the string from xml
        /// </summary>
        /// <param name="reader"></param>
        public void ReadXml(XmlReader reader)
        {
            Value = reader.ReadElementContentAsString();
        }

        /// <summary>
        /// Retrieves an object that can iterate through the individual characters in this string.
        /// </summary>
        /// <returns>
        /// A <see cref="CharEnumerator"/> object.
        /// </returns>
        public CharEnumerator GetEnumerator()
        {
            return Value.GetEnumerator();
        }

        private static bool EqualsHelper(CaseInsensitiveString left, CaseInsensitiveString right)
        {
            return left.Value.Equals(right.Value, StringComparison.InvariantCultureIgnoreCase);
        }

        [SecurityCritical]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Guard.ArgumentNotNull(info, "info");
            info.AddValue("StringValue", Value);
        }


        /// <summary>
        /// returms xmlSchema
        /// </summary>
        /// <returns></returns>
        public XmlSchema GetSchema()
        {
            return null;
        }


        #region ICloneable Members
        /// <summary>
        /// Returns a reference to this instance of <see cref="String"/>.
        /// </summary>
        /// <returns>
        /// This instance of String.
        /// </returns>
        public object Clone()
        {
            return Value.Clone();
        }

        #endregion

        #region IComparable Members

        /// <summary>
        /// Compares this instance with a specified <see cref="Object"/> and indicates whether this instance precedes, follows, or appears in the same position in the sort order as the specified <see cref="Object"/>.
        ///  </summary>
        /// <returns>
        /// A 32-bit signed integer that indicates whether this instance precedes, follows, or appears in the same position in the sort order as the <paramref name="value"/> parameter.
        /// Value
        /// Condition
        /// Less than zero
        /// This instance precedes <paramref name="value"/>.
        /// Zero
        /// This instance has the same position in the sort order as <paramref name="value"/>.
        /// Greater than zero
        /// This instance follows <paramref name="value"/>.
        /// -or-
        /// <paramref name="value"/> is null.
        /// </returns>
        /// <param name="value">An <see cref="Object"/> that evaluates to a String.</param>
        /// <exception cref="ArgumentException"><paramref name="value"/> is not a <see cref="String"/>.</exception>
        public int CompareTo(object value)
        {
            return Value.CompareTo(value);
        }

        #endregion

        #region IComparable<string> Members

        /// <summary>
        /// Compares this instance with a specified <see cref="String"/> object and indicates whether this instance precedes, follows, or appears in the same position in the sort order as the specified <see cref="String"/>.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that indicates whether this instance precedes, follows, or appears in the same position in the sort order as the <paramref name="strB"/> parameter.
        /// Value
        /// Condition
        /// Less than zero
        /// This instance precedes <paramref name="strB"/>.
        /// Zero
        /// This instance has the same position in the sort order as <paramref name="strB"/>.
        /// Greater than zero
        /// This instance follows <paramref name="strB"/>.
        /// -or-
        /// <paramref name="strB"/> is null.
        /// 
        /// </returns>
        /// <param name="strB">A <see cref="String"/>.</param>
        public int CompareTo(string strB)
        {
            return String.Compare(Value, strB, StringComparison.Ordinal);
        }

        #endregion

        #region IConvertible Members

        /// <summary>
        /// Returns this instance of <see cref="String"/>; no actual conversion is performed.
        /// </summary>
        /// <returns>
        /// This <see cref="String"/>.
        /// </returns>
        /// <param name="provider">(Reserved) An <see cref="IFormatProvider"/> that supplies culture-specific formatting information.</param>
        public string ToString(IFormatProvider provider)
        {
            return Value.ToString(provider);
        }

        /// <summary>
        /// Returns the <see cref="TypeCode"/> for class <see cref="String"/>.
        /// </summary>
        /// <returns>
        /// The enumerated constant, <see cref="TypeCode.String"/>.
        /// </returns>
        public TypeCode GetTypeCode()
        {
            return Value.GetTypeCode();
        }

        /// <summary>
        /// For a description of this member, see <see cref="IConvertible.ToBoolean(System.IFormatProvider)"/>.
        /// </summary>
        /// <returns>
        /// true if the value of the current <see cref="String"/> object is <see cref="Boolean.TrueString"/>, or false if the value of the current <see cref="String"/> object is <see cref="F:System.Boolean.FalseString"/>.
        /// </returns>
        /// <param name="provider">This parameter is ignored.</param>
        /// <exception cref="FormatException">The value of the current <see cref="String"/> object is not <see cref="Boolean.TrueString"/> or <see cref="F:System.Boolean.FalseString"/>.</exception>
        bool IConvertible.ToBoolean(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToBoolean(provider);
        }

        /// <summary>
        /// For a description of this member, see <see cref="IConvertible.ToChar(IFormatProvider)"/>.
        /// </summary>
        /// <returns>
        /// The character at index 0 in the current <see cref="String"/> object.
        /// </returns>
        /// <param name="provider">An <see cref="IFormatProvider"/> object that provides culture-specific formatting information.</param>
        char IConvertible.ToChar(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToChar(provider);
        }


        /// <summary>
        /// For a description of this member, see <see cref="IConvertible.ToSByte(IFormatProvider)"/>.
        /// </summary>
        /// <returns>
        /// The converted value of the current <see cref="String"/> object.
        /// </returns>
        /// <param name="provider">An <see cref="IFormatProvider"/> object that provides culture-specific formatting information.</param>
        /// <exception cref="FormatException">The value of the current <see cref="String"/> object cannot be parsed.</exception>
        /// <exception cref="OverflowException">The value of the current <see cref="String"/> object is a number greater than <see cref="F:System.SByte.MaxValue"/> or less than <see cref="F:System.SByte.MinValue"/>.</exception>
        sbyte IConvertible.ToSByte(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToSByte(provider);
        }

        /// <summary>
        /// For a description of this member, see <see cref="IConvertible.ToByte(IFormatProvider)"/>.
        /// </summary>
        /// <returns>
        /// The converted value of the current <see cref="String"/> object.
        /// </returns>
        /// <param name="provider">An <see cref="IFormatProvider"/> object that provides culture-specific formatting information.</param>
        /// <exception cref="FormatException">The value of the current <see cref="String"/> object cannot be parsed.</exception>
        /// <exception cref="OverflowException">The value of the current <see cref="String"/> object is a number greater than <see cref="F:System.Byte.MaxValue"/> or less than <see cref="F:System.Byte.MinValue"/>.</exception>
        byte IConvertible.ToByte(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToByte(provider);
        }

        /// <summary>
        /// For a description of this member, see <see cref="IConvertible.ToInt16(IFormatProvider)"/>.
        /// </summary>
        /// <returns>
        /// The converted value of the current <see cref="String"/> object.
        /// </returns>
        /// <param name="provider">An <see cref="IFormatProvider"/> object that provides culture-specific formatting information.</param>
        /// <exception cref="FormatException">The value of the current <see cref="String"/> object cannot be parsed.</exception>
        /// <exception cref="OverflowException">The value of the current <see cref="String"/> object is a number greater than <see cref="F:System.Int16.MaxValue"/> or less than <see cref="F:System.Int16.MinValue"/>.</exception>
        short IConvertible.ToInt16(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToInt16(provider);
        }

        /// <summary>
        /// For a description of this member, see <see cref="IConvertible.ToUInt16(IFormatProvider)"/>.
        /// </summary>
        /// <returns>
        /// The converted value of the current <see cref="String"/> object.
        /// </returns>
        /// <param name="provider">An <see cref="IFormatProvider"/> object that provides culture-specific formatting information.</param>
        /// <exception cref="FormatException">The value of the current <see cref="String"/> object cannot be parsed.</exception>
        /// <exception cref="OverflowException">The value of the current <see cref="String"/> object is a number greater than <see cref="UInt16.MaxValue"/> or less than <see cref="UInt16.MinValue"/>.</exception>
        ushort IConvertible.ToUInt16(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToUInt16(provider);
        }

        /// <summary>
        /// For a description of this member, see <see cref="IConvertible.ToInt32(IFormatProvider)"/>.
        /// </summary>
        /// <returns>
        /// The converted value of the current <see cref="String"/> object.
        /// </returns>
        /// <param name="provider">An <see cref="IFormatProvider"/> object that provides culture-specific formatting information.</param>
        int IConvertible.ToInt32(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToInt32(provider);
        }

        /// <summary>
        /// For a description of this member, see <see cref="IConvertible.ToUInt32(IFormatProvider)"/>.
        /// </summary>
        /// <returns>
        /// The converted value of the current <see cref="String"/> object.
        /// </returns>
        /// <param name="provider">An <see cref="IFormatProvider"/> object.</param>
        /// <exception cref="FormatException">The value of the current <see cref="String"/> object cannot be parsed.</exception>
        /// <exception cref="OverflowException">The value of the current <see cref="String"/> object is a number greater <see cref="UInt32.MaxValue"/> or less than <see cref="UInt32.MinValue"/></exception>
        uint IConvertible.ToUInt32(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToUInt32(provider);
        }


        /// <summary>
        /// For a description of this member, see <see cref="IConvertible.ToInt64(IFormatProvider)"/>.
        /// </summary>
        /// <returns>
        /// The converted value of the current <see cref="String"/> object.
        /// </returns>
        /// <param name="provider">An <see cref="IFormatProvider"/> object that provides culture-specific formatting information.</param>
        long IConvertible.ToInt64(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToInt64(provider);
        }


        /// <summary>
        /// For a description of this member, see <see cref="IConvertible.ToUInt64(IFormatProvider)"/>.
        /// </summary>
        /// <returns>
        /// The converted value of the current <see cref="String"/> object.
        /// </returns>
        /// <param name="provider">An <see cref="IFormatProvider"/> object.</param>
        ulong IConvertible.ToUInt64(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToUInt64(provider);
        }

        /// <summary>
        /// For a description of this member, see <see cref="IConvertible.ToSingle(IFormatProvider)"/>.
        /// </summary>
        /// <returns>
        /// The converted value of the current <see cref="String"/> object.
        /// </returns>
        /// <param name="provider">An <see cref="IFormatProvider"/> object that provides culture-specific formatting information.</param>
        float IConvertible.ToSingle(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToSingle(provider);
        }

        /// <summary>
        /// For a description of this member, see <see cref="IConvertible.ToDouble(IFormatProvider)"/>.
        /// </summary>
        /// <returns>
        /// The converted value of the current <see cref="String"/> object.
        /// </returns>
        /// <param name="provider">An <see cref="IFormatProvider"/> object that provides culture-specific formatting information.</param>
        /// <exception cref="FormatException">The value of the current <see cref="String"/> object cannot be parsed.</exception>
        /// <exception cref="OverflowException">The value of the current <see cref="String"/> object is a number less than <see cref="Double.MinValue"/> or greater than <see cref="Double.MaxValue"/>.</exception>
        double IConvertible.ToDouble(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToDouble(provider);
        }

        /// <summary>
        /// For a description of this member, see <see cref="IConvertible.ToDecimal(IFormatProvider)"/>.
        /// </summary>
        /// <returns>
        /// The converted value of the current <see cref="String"/> object.
        /// </returns>
        /// <param name="provider">An <see cref="IFormatProvider"/> object that provides culture-specific formatting information.</param>
        /// <exception cref="FormatException">The value of the current <see cref="String"/> object cannot be parsed.</exception>
        /// <exception cref="OverflowException">The value of the current <see cref="String"/> object is a number less than <see cref="F:System.Decimal.MinValue"/> or than <see cref="F:System.Decimal.MaxValue"/> greater.</exception>
        decimal IConvertible.ToDecimal(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToDecimal(provider);
        }


        /// <summary>
        /// For a description of this member, see <see cref="IConvertible.ToDateTime(IFormatProvider)"/>.
        /// </summary>
        /// <returns>
        /// The converted value of the current <see cref="String"/> object.
        /// </returns>
        /// <param name="provider">An <see cref="IFormatProvider"/> object that provides culture-specific formatting information.</param>
        DateTime IConvertible.ToDateTime(IFormatProvider provider)
        {
            return ((IConvertible)Value).ToDateTime(provider);
        }



        /// <summary>
        /// For a description of this member, see <see cref="IConvertible.ToType(Type,IFormatProvider)"/>.
        /// </summary>
        /// <returns>
        /// The converted value of the current <see cref="String"/> object.
        /// </returns>
        /// <param name="type">The type of the returned object.</param>
        /// <param name="provider">An <see cref="IFormatProvider"/> object that provides culture-specific formatting information.</param>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> is null.</exception>
        /// <exception cref="InvalidCastException">The value of the current <see cref="String"/> object cannot be converted to the type specified by the <paramref name="type"/> parameter.</exception>
        object IConvertible.ToType(Type type, IFormatProvider provider)
        {
            return ((IConvertible)Value).ToType(type, provider);
        }

        #endregion

        #region IEnumerable<char> Members

        IEnumerator<char> IEnumerable<char>.GetEnumerator()
        {
            return ((IEnumerable<char>)Value).GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the current <see cref="String"/> object.
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerator"/> object that can be used to iterate through the current <see cref="String"/> object.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Value).GetEnumerator();
        }

        #endregion

        #region IEquatable<string> Members

        /// <summary>
        /// Determines whether this instance and another specified <see cref="String"/> object have the same value.
        /// </summary>
        /// <returns>
        /// true if the value of the <paramref name="value"/> parameter is the same as this instance; otherwise, false.
        /// </returns>
        /// <param name="value">A <see cref="String"/>.</param>
        /// <exception cref="NullReferenceException">This instance is null.</exception>
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        public bool Equals(string value)
        {
            return (this == value);
        }

        #endregion
        #region IEquatable<CaseInsensitiveString> Members

        /// <summary>
        /// Determines whether this instance and another specified <see cref="CaseInsensitiveString"/> object have the same value.
        /// </summary>
        /// <returns>
        /// true if the value of the <paramref name="value"/> parameter is the same as this instance; otherwise, false.
        /// </returns>
        /// <param name="value">A <see cref="CaseInsensitiveString"/>.</param>
        /// <exception cref="NullReferenceException">This instance is null.</exception>
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        public bool Equals(CaseInsensitiveString value)
        {
            return (this == value);
        }

        #endregion

        /// <summary>
        /// Determines whether two specified <see cref="String"/> objects have the same value.
        /// </summary>
        /// <returns>
        /// true if the value of <paramref name="a"/> is the same as the value of <paramref name="b"/>; otherwise, false.
        /// </returns>
        /// <param name="a">A <see cref="String"/> or null.</param>
        /// <param name="b">A <see cref="String"/> or null.</param>
        public static bool operator ==(CaseInsensitiveString a, CaseInsensitiveString b)
        {
            return (ReferenceEquals(a, b) || ((!ReferenceEquals(a, null) && !ReferenceEquals(b, null)) && EqualsHelper(a, b)));
        }


        /// <summary>
        /// Determines whether two specified <see cref="String"/> objects have different values.
        /// </summary>
        /// <returns>
        /// true if the value of <paramref name="a"/> is different from the value of <paramref name="b"/>; otherwise, false.
        /// </returns>
        /// <param name="a">A String or null.</param>
        /// <param name="b">A String or null.</param>
        public static bool operator !=(CaseInsensitiveString a, CaseInsensitiveString b)
        {
            return !(a == b);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator string(CaseInsensitiveString value)
        {
            if (value == null)
            {
                return null;
            }
            return value.Value;
        }


        /// <summary>
        /// Creates a new instance of <see cref="CaseInsensitiveString" /> based  on <paramref name="value"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator CaseInsensitiveString(string value)
        {
            if (value == null)
            {
                return null;
            }
            return new CaseInsensitiveString(value);
        }


        /// <summary>
        /// Determines whether this instance of <see cref="String"/> and a specified object, which must also be a <see cref="String"/> object, have the same value.
        /// </summary>
        /// <returns>
        /// true if <paramref name="obj"/> is a <see cref="String"/> and its value is the same as this instance; otherwise, false.
        /// </returns>
        /// <param name="obj">An <see cref="Object"/>.</param>
        /// <exception cref="NullReferenceException">This instance is null.</exception>
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        public override bool Equals(object obj)
        {
            if (!(obj is string strB))
            {
                return false;
            }

            return Equals(strB);
        }

        /// <summary>
        /// Copies the characters in this instance to a Unicode character array.
        /// </summary>
        /// <returns>
        /// A Unicode character array whose elements are the individual characters of this instance. If this instance is an empty string, the returned array is empty and has a zero length.
        /// </returns>
        public char[] ToCharArray()
        {
            return Value.ToCharArray();
        }


        /// <summary>
        /// Copies the characters in a specified substring in this instance to a Unicode character array.
        /// </summary>
        /// <returns>
        /// A Unicode character array whose elements are the <paramref name="length"/> number of characters in this instance starting from character position <paramref name="startIndex"/>.
        /// </returns>
        /// <param name="startIndex">The starting position of a substring in this instance.</param>
        /// <param name="length">The length of the substring in this instance.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="startIndex"/> or <paramref name="length"/> is less than zero.
        /// -or-
        /// <paramref name="startIndex"/> plus <paramref name="length"/> is greater than the length of this instance.
        /// </exception>
        public char[] ToCharArray(int startIndex, int length)
        {
            return Value.ToCharArray(startIndex, length);
        }

        /// <summary>
        /// Returns the hash code for this string.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        public override int GetHashCode()
        {
            return Value.ToUpper().GetHashCode();
        }


        /// <summary>
        /// Returns a string array that contains the substrings in this instance that are delimited by elements of a specified Unicode character array.
        /// </summary>
        /// <returns>
        /// An array whose elements contain the substrings in this instance that are delimited by one or more characters in <paramref name="separator"/>. For more information, see the Remarks section.
        /// </returns>
        /// <param name="separator">An array of Unicode characters that delimit the substrings in this instance, an empty array that contains no delimiters, or null.</param>
        public CaseInsensitiveString[] Split(params char[] separator)
        {
            return StringArrayTo(Value.Split(separator));
        }

        /// <summary>
        /// Returns a string array that contains the substrings in this instance that are delimited by elements of a specified Unicode character array. A parameter specifies the maximum number of substrings to return.
        /// </summary>
        /// <returns>
        /// An array whose elements contain the substrings in this instance that are delimited by one or more characters in <paramref name="separator"/>. For more information, see the Remarks section.
        /// </returns>
        /// <param name="separator">An array of Unicode characters that delimit the substrings in this instance, an empty array that contains no delimiters, or null.</param>
        /// <param name="count">The maximum number of substrings to return.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="count"/> is negative.</exception>
        public CaseInsensitiveString[] Split(char[] separator, int count)
        {
            return StringArrayTo(Value.Split(separator, count));
        }

        /// <summary>
        /// Returns a string array that contains the substrings in this string that are delimited by elements of a specified Unicode character array. A parameter specifies whether to return empty array elements.
        /// </summary>
        /// <returns>
        /// An array whose elements contain the substrings in this string that are delimited by one or more characters in <paramref name="separator"/>. For more information, see the Remarks section.
        /// </returns>
        /// <param name="separator">An array of Unicode characters that delimit the substrings in this string, an empty array that contains no delimiters, or null.</param>
        /// <param name="options">Specify <see cref="F:System.StringSplitOptions.RemoveEmptyEntries"/> to omit empty array elements from the array returned, or <see cref="F:System.StringSplitOptions.None"/> to include empty array elements in the array returned.</param>
        /// <exception cref="ArgumentException"><paramref name="options"/> is not one of the <see cref="StringSplitOptions"/> values.</exception>
        [ComVisible(false)]
        public CaseInsensitiveString[] Split(char[] separator, StringSplitOptions options)
        {
            return StringArrayTo(Value.Split(separator, options));
        }

        /// <summary>
        /// Returns a string array that contains the substrings in this string that are delimited by elements of a specified Unicode character array. Parameters specify the maximum number of substrings to return and whether to return empty array elements.
        /// </summary>
        /// <returns>
        /// An array whose elements contain the substrings in this string that are delimited by one or more characters in <paramref name="separator"/>. For more information, see the Remarks section.
        /// </returns>
        /// <param name="separator">An array of Unicode characters that delimit the substrings in this string, an empty array that contains no delimiters, or null.</param>
        /// <param name="count">The maximum number of substrings to return.</param>
        /// <param name="options">Specify <see cref="StringSplitOptions.RemoveEmptyEntries"/> to omit empty array elements from the array returned, or <see cref="F:System.StringSplitOptions.None"/> to include empty array elements in the array returned.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="count"/> is negative.</exception>
        /// <exception cref="ArgumentException"><paramref name="options"/> is not one of the <see cref="StringSplitOptions"/> values.</exception>
        [ComVisible(false)]
        public CaseInsensitiveString[] Split(char[] separator, int count, StringSplitOptions options)
        {
            return StringArrayTo(Value.Split(separator, count, options));
        }

        /// <summary>
        /// Returns a string array that contains the substrings in this string that are delimited by elements of a specified string array. A parameter specifies whether to return empty array elements.
        /// </summary>
        /// <returns>
        /// An array whose elements contain the substrings in this string that are delimited by one or more strings in <paramref name="separator"/>. For more information, see the Remarks section.
        /// </returns>
        /// <param name="separator">An array of strings that delimit the substrings in this string, an empty array that contains no delimiters, or null.</param>
        /// <param name="options">Specify <see cref="StringSplitOptions.RemoveEmptyEntries"/> to omit empty array elements from the array returned, or <see cref="F:System.StringSplitOptions.None"/> to include empty array elements in the array returned.</param>
        /// <exception cref="ArgumentException"><paramref name="options"/> is not one of the <see cref="StringSplitOptions"/> values.</exception>
        [ComVisible(false)]
        public CaseInsensitiveString[] Split(string[] separator, StringSplitOptions options)
        {
            return StringArrayTo(Value.Split(separator, options));
        }

        /// <summary>
        /// Returns a string array that contains the substrings in this string that are delimited by elements of a specified string array. Parameters specify the maximum number of substrings to return and whether to return empty array elements.
        /// </summary>
        /// <returns>
        /// An array whose elements contain the substrings in this string that are delimited by one or more strings in <paramref name="separator"/>. For more information, see the Remarks section.
        /// </returns>
        /// <param name="separator">An array of strings that delimit the substrings in this string, an empty array that contains no delimiters, or null.</param>
        /// <param name="count">The maximum number of substrings to return.</param>
        /// <param name="options">Specify <see cref="StringSplitOptions.RemoveEmptyEntries"/> to omit empty array elements from the array returned, or <see cref="F:System.StringSplitOptions.None"/> to include empty array elements in the array returned.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="count"/> is negative.</exception>
        /// <exception cref="ArgumentException"><paramref name="options"/> is not one of the <see cref="StringSplitOptions"/> values.</exception>
        [ComVisible(false)]
        public CaseInsensitiveString[] Split(string[] separator, int count, StringSplitOptions options)
        {
            return StringArrayTo(Value.Split(separator, count, options));
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

        /// <summary>
        /// Retrieves a substring from this instance. The substring starts at a specified character position.
        /// </summary>
        /// <returns>
        /// A <see cref="String"/> object equivalent to the substring that begins at <paramref name="startIndex"/> in this instance, or <see cref="F:System.String.Empty"/> if <paramref name="startIndex"/> is equal to the length of this instance.
        /// </returns>
        /// <param name="startIndex">The zero-based starting character position of a substring in this instance.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="startIndex"/> is less than zero or greater than the length of this instance.</exception>
        public CaseInsensitiveString Substring(int startIndex)
        {
            return Value.Substring(startIndex);
        }

        /// <summary>
        /// Retrieves a substring from this instance. The substring starts at a specified character position and has a specified length.
        /// </summary>
        /// <returns>
        /// A <see cref="String"/> equivalent to the substring of length <paramref name="length"/> that begins at <paramref name="startIndex"/> in this instance, or <see cref="F:System.String.Empty"/> if <paramref name="startIndex"/> is equal to the length of this instance and <paramref name="length"/> is zero.
        /// </returns>
        /// <param name="startIndex">The zero-based starting character position of a substring in this instance.</param>
        /// <param name="length">The number of characters in the substring.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="startIndex"/> plus <paramref name="length"/> indicates a position not within this instance.
        ///  -or-
        /// <paramref name="startIndex"/> or <paramref name="length"/> is less than zero.
        /// </exception>
        public CaseInsensitiveString Substring(int startIndex, int length)
        {
            return Value.Substring(startIndex, length);
        }


        /// <summary>
        /// Removes all leading and trailing occurrences of a set of characters specified in an array from the current <see cref="String"/> object.
        /// </summary>
        /// <returns>
        /// The string that remains after all occurrences of the characters in the <paramref name="trimChars"/> parameter are removed from the start and end of the current <see cref="String"/> object. If <paramref name="trimChars"/> is null, white-space characters are removed instead.
        /// </returns>
        /// <param name="trimChars">An array of Unicode characters to remove or null.</param>
        public CaseInsensitiveString Trim(params char[] trimChars)
        {
            return Value.Trim(trimChars);
        }

        /// <summary>
        /// Removes all leading occurrences of a set of characters specified in an array from the current <see cref="String"/> object.
        /// </summary>
        /// <returns>
        /// The string that remains after all occurrences of characters in the <paramref name="trimChars"/> parameter are removed from the start of the current <see cref="String"/> object. If <paramref name="trimChars"/> is null, white-space characters are removed instead.
        /// </returns>
        /// <param name="trimChars">An array of Unicode characters to remove or null.</param>
        public CaseInsensitiveString TrimStart(params char[] trimChars)
        {
            return Value.TrimStart(trimChars);
        }

        /// <summary>
        /// Removes all trailing occurrences of a set of characters specified in an array from the current <see cref="String"/> object.
        /// </summary>
        /// <returns>
        /// The string that remains after all occurrences of the characters in the <paramref name="trimChars"/> parameter are removed from the end of the current <see cref="String"/> object. If <paramref name="trimChars"/> is null, white-space characters are removed instead.
        /// </returns>
        /// <param name="trimChars">An array of Unicode characters to remove or null.</param>
        public CaseInsensitiveString TrimEnd(params char[] trimChars)
        {
            return Value.TrimEnd(trimChars);
        }


        /// <summary>
        /// Indicates whether this string is in Unicode normalization form C.
        /// </summary>
        /// <returns>
        /// true if this string is in normalization form C; otherwise, false.
        /// </returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/></PermissionSet>
        public bool IsNormalized()
        {
            return Value.IsNormalized();
        }

        /// <summary>
        /// Indicates whether this string is in the specified Unicode normalization form.
        /// </summary>
        /// <returns>
        /// true if this string is in the normalization form specified by the <paramref name="normalizationForm"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="normalizationForm">A Unicode normalization form.</param>
        /// <PermissionSet><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/></PermissionSet>
        public bool IsNormalized(NormalizationForm normalizationForm)
        {
            return Value.IsNormalized(normalizationForm);
        }

        /// <summary>
        /// Returns a new string whose textual value is the same as this string, but whose binary representation is in Unicode normalization form C.
        /// </summary>
        /// <returns>
        /// A new, normalized string whose textual value is the same as this string, but whose binary representation is in normalization form C.
        /// </returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/></PermissionSet>
        public CaseInsensitiveString Normalize()
        {
            return Value.Normalize();
        }

        /// <summary>
        /// Returns a new string whose textual value is the same as this string, but whose binary representation is in the specified Unicode normalization form.
        /// </summary>
        /// <returns>
        /// A new string whose textual value is the same as this string, but whose binary representation is in the normalization form specified by the <paramref name="normalizationForm"/> parameter.
        /// </returns>
        /// <param name="normalizationForm">A Unicode normalization form.</param>
        /// <PermissionSet><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/></PermissionSet>
        public CaseInsensitiveString Normalize(NormalizationForm normalizationForm)
        {
            return Value.Normalize(normalizationForm);
        }

        /// <summary>
        /// Returns a value indicating whether the specified <see cref="String"/> object occurs within this string.
        /// </summary>
        /// <returns>
        /// true if the <paramref name="value"/> parameter occurs within this string, or if <paramref name="value"/> is the empty string (""); otherwise, false.
        /// </returns>
        /// <param name="value">The <see cref="String"/> object to seek.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        public bool Contains(string value)
        {
            return Value.ToUpper(CultureInfo.InvariantCulture).Contains(value.ToUpper(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Determines whether the end of this instance matches the specified string.
        /// </summary>
        /// <returns>
        /// true if <paramref name="value"/> matches the end of this instance; otherwise, false.
        /// </returns>
        /// <param name="value">A <see cref="String"/> to compare to.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        public bool EndsWith(string value)
        {
            return Value.EndsWith(value, StringComparison.InvariantCultureIgnoreCase);
        }


        /// <summary>
        /// Determines whether the end of this string matches the specified string when compared using the specified comparison option.
        /// </summary>
        /// <returns>
        /// true if the <paramref name="value"/> parameter matches the end of this string; otherwise, false.
        /// </returns>
        /// <param name="value">A <see cref="String"/> object to compare to.</param>
        /// <param name="comparisonType">One of the <see cref="StringComparison"/> values that determines how this string and <paramref name="value"/> are compared.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="comparisonType"/> is not a <see cref="StringComparison"/> value.</exception>
        [ComVisible(false)]
        public bool EndsWith(string value, StringComparison comparisonType)
        {
            return Value.EndsWith(value, comparisonType);
        }

        /// <summary>
        /// Determines whether the end of this string matches the specified string when compared using the specified culture.
        /// </summary>
        /// <returns>
        /// true if the <paramref name="value"/> parameter matches the end of this string; otherwise, false.
        /// </returns>
        /// <param name="value">A <see cref="String"/> object to compare to.</param>
        /// <param name="ignoreCase">true to ignore case when comparing this instance and <paramref name="value"/>; otherwise, false.</param>
        /// <param name="culture">Cultural information that determines how this instance and <paramref name="value"/> are compared. If <paramref name="culture"/> is null, the current culture is used.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        public bool EndsWith(string value, bool ignoreCase, CultureInfo culture)
        {
            return Value.EndsWith(value, ignoreCase, culture);
        }

        /// <summary>
        /// Reports the index of the first occurrence of the specified Unicode character in this string.
        /// </summary>
        /// <returns>
        /// The zero-based index position of <paramref name="value"/> if that character is found, or -1 if it is not.
        /// </returns>
        /// <param name="value">A Unicode character to seek.</param>
        public int IndexOf(char value)
        {
            return Value.IndexOf(value.ToString(), StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Reports the index of the first occurrence of the specified Unicode character in this string. The search starts at a specified character position.
        /// </summary>
        /// <returns>
        /// The zero-based index position of <paramref name="value"/> if that character is found, or -1 if it is not.
        /// </returns>
        /// <param name="value">A Unicode character to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="startIndex"/> is less than zero or specifies a position beyond the end of this instance.</exception>
        public int IndexOf(char value, int startIndex)
        {
            return Value.IndexOf(value.ToString(), startIndex, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Reports the index of the first occurrence of the specified character in this instance. The search starts at a specified character position and examines a specified number of character positions.
        /// </summary>
        /// <returns>
        /// The zero-based index position of <paramref name="value"/> if that character is found, or -1 if it is not.
        /// </returns>
        /// <param name="value">A Unicode character to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="count"/> or <paramref name="startIndex"/> is negative.
        /// -or-
        /// <paramref name="count"/> + <paramref name="startIndex"/> specifies a position beyond the end of this instance.
        /// </exception>

        public int IndexOf(char value, int startIndex, int count)
        {
            return Value.IndexOf(value.ToString(), startIndex, count, StringComparison.InvariantCultureIgnoreCase);
        }


        /// <summary>
        /// Reports the index of the first occurrence in this instance of any character in a specified array of Unicode characters.
        /// </summary>
        /// <returns>
        /// The zero-based index position of the first occurrence in this instance where any character in <paramref name="anyOf"/> was found; otherwise, -1 if no character in <paramref name="anyOf"/> was found.
        /// </returns>
        /// <param name="anyOf">A Unicode character array containing one or more characters to seek.</param>
        /// <exception cref="ArgumentNullException"><paramref name="anyOf"/> is null.</exception>
        public int IndexOfAny(char[] anyOf)
        {
            return Value.IndexOfAny(anyOf);
        }

        /// <summary>
        /// Reports the index of the first occurrence in this instance of any character in a specified array of Unicode characters. The search starts at a specified character position.
        /// </summary>
        /// <returns>
        /// The zero-based index position of the first occurrence in this instance where any character in <paramref name="anyOf"/> was found; otherwise, -1 if no character in <paramref name="anyOf"/> was found.
        /// </returns>
        /// <param name="anyOf">A Unicode character array containing one or more characters to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="anyOf"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="startIndex"/> is negative.
        /// -or-
        /// <paramref name="startIndex"/> is greater than the number of characters in this instance.</exception>

        public int IndexOfAny(char[] anyOf, int startIndex)
        {
            return Value.IndexOfAny(anyOf, startIndex);
        }

        /// <summary>
        /// Reports the index of the first occurrence in this instance of any character in a specified array of Unicode characters. The search starts at a specified character position and examines a specified number of character positions.
        /// </summary>
        /// <returns>
        /// The zero-based index position of the first occurrence in this instance where any character in <paramref name="anyOf"/> was found; otherwise, -1 if no character in <paramref name="anyOf"/> was found.
        /// </returns>
        /// <param name="anyOf">A Unicode character array containing one or more characters to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <exception cref="ArgumentNullException"><paramref name="anyOf"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="count"/> or <paramref name="startIndex"/> is negative.
        /// -or-
        /// <paramref name="count"/> + <paramref name="startIndex"/> is greater than the number of characters in this instance.
        /// </exception>
        public int IndexOfAny(char[] anyOf, int startIndex, int count)
        {
            return Value.IndexOfAny(anyOf, startIndex, count);
        }

        /// <summary>
        /// Reports the index of the first occurrence of the specified <see cref="String"/> in this instance.
        /// </summary>
        /// <returns>
        /// The zero-based index position of <paramref name="value"/> if that string is found, or -1 if it is not. If <paramref name="value"/> is <see cref="F:System.String.Empty"/>, the return value is 0.
        /// </returns>
        /// <param name="value">The <see cref="String"/> to seek.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        public int IndexOf(string value)
        {
            return Value.IndexOf(value, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Reports the index of the first occurrence of the specified <see cref="String"/> in this instance. The search starts at a specified character position.
        /// </summary>
        /// <returns>
        /// The zero-based index position of <paramref name="value"/> if that string is found, or -1 if it is not. If <paramref name="value"/> is <see cref="F:System.String.Empty"/>, the return value is <paramref name="startIndex"/>.
        /// 
        /// </returns>
        /// <param name="value">The <see cref="String"/> to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="startIndex"/> is negative.
        /// -or-
        /// <paramref name="startIndex"/> specifies a position not within this instance.</exception>
        public int IndexOf(string value, int startIndex)
        {
            return Value.IndexOf(value, startIndex, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Reports the index of the first occurrence of the specified <see cref="String"/> in this instance. The search starts at a specified character position and examines a specified number of character positions.
        /// </summary>
        /// <returns>
        /// The zero-based index position of <paramref name="value"/> if that string is found, or -1 if it is not. If <paramref name="value"/> is <see cref="F:System.String.Empty"/>, the return value is <paramref name="startIndex"/>.
        /// </returns>
        /// <param name="value">The <see cref="String"/> to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="count"/> or <paramref name="startIndex"/> is negative.
        /// -or-
        /// <paramref name="count"/> plus <paramref name="startIndex"/> specify a position not within this instance.
        /// </exception>
        public int IndexOf(string value, int startIndex, int count)
        {
            return Value.IndexOf(value, startIndex, count, StringComparison.InvariantCultureIgnoreCase);
        }


        /// <summary>
        /// Reports the index position of the last occurrence of a specified Unicode character within this instance.
        /// </summary>
        /// <returns>
        /// The index position of <paramref name="value"/> if that character is found, or -1 if it is not.
        /// </returns>
        /// <param name="value">A Unicode character to seek.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        public int LastIndexOf(char value)
        {
            return Value.LastIndexOf(value.ToString(), StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Reports the index position of the last occurrence of a specified Unicode character within this instance. The search starts at a specified character position.
        /// </summary>
        /// <returns>
        /// The index position of <paramref name="value"/> if that character is found, or -1 if it is not.
        /// </returns>
        /// <param name="value">A Unicode character to seek.</param>
        /// <param name="startIndex">The starting position of a substring within this instance.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="startIndex"/> is less than zero or greater than the length of this instance.</exception>
        public int LastIndexOf(char value, int startIndex)
        {
            return Value.LastIndexOf(value.ToString(), startIndex, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Reports the index position of the last occurrence of the specified Unicode character in a substring within this instance. The search starts at a specified character position and examines a specified number of character positions.
        /// </summary>
        /// <returns>
        /// The index position of <paramref name="value"/> if that character is found, or -1 if it is not.
        /// </returns>
        /// <param name="value">A Unicode character to seek.</param>
        /// <param name="startIndex">The starting position of a substring within this instance.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="startIndex"/> is less than zero, or greater than or equal to the length of this instance.
        /// -or-
        /// <paramref name="startIndex"/> + 1 - <paramref name="count"/> is less than zero.
        /// </exception>
        public int LastIndexOf(char value, int startIndex, int count)
        {
            return Value.LastIndexOf(value.ToString(), startIndex, count, StringComparison.InvariantCultureIgnoreCase);
        }


        /// <summary>
        /// Reports the index position of the last occurrence in this instance of one or more characters specified in a Unicode array.
        /// </summary>
        /// <returns>
        /// The index position of the last occurrence in this instance where any character in <paramref name="anyOf"/> was found; otherwise, -1 if no character in <paramref name="anyOf"/> was found.
        /// </returns>
        /// <param name="anyOf">A Unicode character array containing one or more characters to seek.</param>
        /// <exception cref="ArgumentNullException"><paramref name="anyOf"/> is null.</exception>
        public int LastIndexOfAny(char[] anyOf)
        {
            return Value.LastIndexOfAny(anyOf);
        }

        /// <summary>
        /// Reports the index position of the last occurrence in this instance of one or more characters specified in a Unicode array. The search starts at a specified character position.
        /// </summary>
        /// <returns>
        /// The index position of the last occurrence in this instance where any character in <paramref name="anyOf"/> was found; otherwise, -1 if no character in <paramref name="anyOf"/> was found.
        /// </returns>
        /// <param name="anyOf">A Unicode character array containing one or more characters to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <exception cref="ArgumentNullException"><paramref name="anyOf"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="startIndex"/> specifies a position not within this instance.</exception>
        public int LastIndexOfAny(char[] anyOf, int startIndex)
        {
            return Value.LastIndexOfAny(anyOf, startIndex);
        }

        /// <summary>
        /// Reports the index position of the last occurrence in this instance of one or more characters specified in a Unicode array. The search starts at a specified character position and examines a specified number of character positions.
        /// </summary>
        /// <returns>
        /// The index position of the last occurrence in this instance where any character in <paramref name="anyOf"/> was found; otherwise, -1 if no character in <paramref name="anyOf"/> was found.
        /// </returns>
        /// <param name="anyOf">A Unicode character array containing one or more characters to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <exception cref="ArgumentNullException"><paramref name="anyOf"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="count"/> or <paramref name="startIndex"/> is negative.
        /// -or-
        /// <paramref name="startIndex"/> minus <paramref name="count"/> specify a position that is not within this instance.
        /// </exception>
        public int LastIndexOfAny(char[] anyOf, int startIndex, int count)
        {
            return Value.LastIndexOfAny(anyOf, startIndex, count);
        }

        /// <summary>
        /// Reports the index position of the last occurrence of a specified <see cref="String"/> within this instance.
        /// </summary>
        /// <returns>
        /// The index position of <paramref name="value"/> if that string is found, or -1 if it is not. If <paramref name="value"/> is <see cref="F:System.String.Empty"/>, the return value is the last index position in this instance.
        /// </returns>
        /// <param name="value">A <see cref="String"/> to seek.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        public int LastIndexOf(string value)
        {
            return Value.LastIndexOf(value, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Reports the index position of the last occurrence of a specified <see cref="String"/> within this instance. The search starts at a specified character position.
        /// </summary>
        /// <returns>
        /// The index position of <paramref name="value"/> if that string is found, or -1 if it is not. If <paramref name="value"/> is <see cref="F:System.String.Empty"/>, the return value is <paramref name="startIndex"/>.
        /// </returns>
        /// <param name="value">The <see cref="String"/> to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="startIndex"/> is less than zero or specifies a position not within this instance.</exception>
        public int LastIndexOf(string value, int startIndex)
        {
            return Value.LastIndexOf(value, startIndex, StringComparison.InvariantCultureIgnoreCase);
        }


        /// <summary>
        /// Reports the index position of the last occurrence of a specified <see cref="String"/> within this instance. The search starts at a specified character position and examines a specified number of character positions.
        /// </summary>
        /// <returns>
        /// The index position of <paramref name="value"/> if that string is found, or -1 if it is not. If <paramref name="value"/> is <see cref="F:System.String.Empty"/>, the return value is <paramref name="startIndex"/>.
        /// </returns>
        /// <param name="value">The <see cref="String"/> to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="count"/> or <paramref name="startIndex"/> is negative.
        /// -or-
        /// <paramref name="startIndex"/> is greater than the length of this instance.
        /// -or-
        /// <paramref name="startIndex"/> + 1 - <paramref name="count"/> specifies a position that is not within this instance.
        /// </exception>
        public int LastIndexOf(string value, int startIndex, int count)
        {
            return Value.LastIndexOf(value, startIndex, count, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Reports the index of the last occurrence of a specified string within the current <see cref="String"/> object. A parameter specifies the type of search to use for the specified string.
        /// </summary>
        /// <returns>
        /// The index position of the <paramref name="value"/> parameter if that string is found, or -1 if it is not. If <paramref name="value"/> is <see cref="F:System.String.Empty"/>, the return value is the last index position in this instance.
        /// </returns>
        /// <param name="value">The <see cref="String"/> object to seek.</param>
        /// <param name="comparisonType">One of the <see cref="StringComparison"/> values.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="comparisonType"/> is not a valid <see cref="StringComparison"/> value.</exception>
        public int LastIndexOf(string value, StringComparison comparisonType)
        {
            return Value.LastIndexOf(value, comparisonType);
        }

        /// <summary>
        /// Reports the index of the last occurrence of a specified string within the current <see cref="String"/> object. Parameters specify the starting search position in the current string, and type of search to use for the specified string.
        /// </summary>
        /// <returns>
        /// The index position of the <paramref name="value"/> parameter if that string is found, or -1 if it is not. If <paramref name="value"/> is <see cref="F:System.String.Empty"/>, the return value is <paramref name="startIndex"/>.
        /// </returns>
        /// <param name="value">The <see cref="String"/> object to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="comparisonType">One of the <see cref="StringComparison"/> values.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="startIndex"/> is less than zero or specifies a position that is not within this instance.</exception>
        /// <exception cref="ArgumentException"><paramref name="comparisonType"/> is not a valid <see cref="StringComparison"/> value.</exception>
        public int LastIndexOf(string value, int startIndex, StringComparison comparisonType)
        {
            return Value.LastIndexOf(value, startIndex, comparisonType);
        }

        /// <summary>
        /// Reports the index position of the last occurrence of a specified <see cref="String"/> object within this instance. Parameters specify the starting search position in the current string, the number of characters in the current string to search, and the type of search to use for the specified string.
        /// </summary>
        /// <returns>
        /// The index position of the <paramref name="value"/> parameter if that string is found, or -1 if it is not. If <paramref name="value"/> is <see cref="F:System.String.Empty"/>, the return value is <paramref name="startIndex"/>.
        /// </returns>
        /// <param name="value">The <see cref="String"/> object to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <param name="comparisonType">One of the <see cref="StringComparison"/> values.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="count"/> or <paramref name="startIndex"/> is negative.
        /// -or-
        /// <paramref name="startIndex"/> is greater than the length of this instance.
        /// -or-
        /// <paramref name="startIndex"/> + 1 - <paramref name="count"/> specifies a position that is not within this instance.
        /// </exception>
        /// <exception cref="ArgumentException"><paramref name="comparisonType"/> is not a valid <see cref="StringComparison"/> value.</exception>

        public int LastIndexOf(string value, int startIndex, int count, StringComparison comparisonType)
        {
            return Value.LastIndexOf(value, startIndex, count, comparisonType);
        }

        /// <summary>
        /// Right-aligns the characters in this instance, padding with spaces on the left for a specified total length.
        /// </summary>
        /// <returns>
        /// A new <see cref="String"/> that is equivalent to this instance, but right-aligned and padded on the left with as many spaces as needed to create a length of <paramref name="totalWidth"/>. Or, if <paramref name="totalWidth"/> is less than the length of this instance, a new <see cref="String"/> object that is identical to this instance.
        /// </returns>
        /// <param name="totalWidth">The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="totalWidth"/> is less than zero.</exception>
        public CaseInsensitiveString PadLeft(int totalWidth)
        {
            return Value.PadLeft(totalWidth);
        }

        /// <summary>
        /// Right-aligns the characters in this instance, padding on the left with a specified Unicode character for a specified total length.
        /// </summary>
        /// <returns>
        /// A new <see cref="String"/> that is equivalent to this instance, but right-aligned and padded on the left with as many <paramref name="paddingChar"/> characters as needed to create a length of <paramref name="totalWidth"/>. Or, if <paramref name="totalWidth"/> is less than the length of this instance, a new <see cref="String"/> that is identical to this instance.
        /// </returns>
        /// <param name="totalWidth">The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters.</param>
        /// <param name="paddingChar">A Unicode padding character.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="totalWidth"/> is less than zero.</exception>
        public CaseInsensitiveString PadLeft(int totalWidth, char paddingChar)
        {
            return Value.PadLeft(totalWidth, paddingChar);
        }

        /// <summary>
        /// Left-aligns the characters in this string, padding with spaces on the right, for a specified total length.
        /// </summary>
        /// <returns>
        /// A new <see cref="String"/> that is equivalent to this instance, but left-aligned and padded on the right with as many spaces as needed to create a length of <paramref name="totalWidth"/>. Or, if <paramref name="totalWidth"/> is less than the length of this instance, a new <see cref="String"/> that is identical to this instance.
        /// </returns>
        /// <param name="totalWidth">The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="totalWidth"/> is less than zero.</exception>
        public CaseInsensitiveString PadRight(int totalWidth)
        {
            return Value.PadRight(totalWidth);
        }


        /// <summary>
        /// Left-aligns the characters in this string, padding on the right with a specified Unicode character, for a specified total length.
        /// </summary>
        /// <returns>
        /// A new <see cref="String"/> that is equivalent to this instance, but left-aligned and padded on the right with as many <paramref name="paddingChar"/> characters as needed to create a length of <paramref name="totalWidth"/>. Or, if <paramref name="totalWidth"/> is less than the length of this instance, a new <see cref="String"/> that is identical to this instance.
        /// </returns>
        /// <param name="totalWidth">The number of characters in the resulting string, equal to the number of original characters plus any additional padding characters.</param>
        /// <param name="paddingChar">A Unicode padding character.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="totalWidth"/> is less than zero.</exception>
        public CaseInsensitiveString PadRight(int totalWidth, char paddingChar)
        {
            return Value.PadRight(totalWidth, paddingChar);
        }


        /// <summary>
        /// Determines whether the beginning of this instance matches the specified string.
        /// </summary>
        /// <returns>
        /// true if <paramref name="value"/> matches the beginning of this string; otherwise, false.
        /// </returns>
        /// <param name="value">The <see cref="String"/> to compare.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        public bool StartsWith(string value)
        {
            return Value.StartsWith(value, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Determines whether the beginning of this string matches the specified string when compared using the specified comparison option.
        /// </summary>
        /// <returns>
        /// true if the <paramref name="value"/> parameter matches the beginning of this string; otherwise, false.
        /// </returns>
        /// <param name="value">A <see cref="String"/> object to compare to.</param>
        /// <param name="comparisonType">One of the <see cref="StringComparison"/> values that determines how this string and <paramref name="value"/> are compared.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="comparisonType"/> is not a <see cref="StringComparison"/> value.</exception>
        [ComVisible(false)]
        public bool StartsWith(string value, StringComparison comparisonType)
        {
            return Value.StartsWith(value, comparisonType);
        }

        /// <summary>
        /// Determines whether the beginning of this string matches the specified string when compared using the specified culture.
        /// </summary>
        /// <returns>
        /// true if the <paramref name="value"/> parameter matches the beginning of this string; otherwise, false.
        /// </returns>
        /// <param name="value">The <see cref="String"/> object to compare.</param>
        /// <param name="ignoreCase">true to ignore case when comparing this string and <paramref name="value"/>; otherwise, false.</param>
        /// <param name="culture">Cultural information that determines how this string and <paramref name="value"/> are compared. If <paramref name="culture"/> is null, the current culture is used.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        public bool StartsWith(string value, bool ignoreCase, CultureInfo culture)
        {
            return Value.StartsWith(value, ignoreCase, culture);
        }

        /// <summary>
        /// Returns a copy of this <see cref="String"/> converted to lowercase, using the casing rules of the current culture.
        /// </summary>
        /// <returns>
        /// A <see cref="String"/> in lowercase.
        /// </returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/></PermissionSet>
        public string ToLower()
        {
            return Value.ToLower();
        }

        /// <summary>
        /// Returns a copy of this <see cref="String"/> converted to lowercase, using the casing rules of the specified culture.
        /// </summary>
        /// <returns>
        /// A <see cref="String"/> in lowercase.
        /// </returns>
        /// <param name="culture">A <see cref="CultureInfo"/> object that supplies culture-specific casing rules.</param>
        /// <exception cref="ArgumentNullException"><paramref name="culture"/> is null.</exception>
        /// <PermissionSet><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/></PermissionSet>
        public string ToLower(CultureInfo culture)
        {
            return Value.ToLower(culture);
        }

        /// <summary>
        /// Returns a copy of this <see cref="String"/> object converted to lowercase using the casing rules of the invariant culture.
        /// </summary>
        /// <returns>
        /// A <see cref="String"/> object in lowercase.
        /// </returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/></PermissionSet>
        public string ToLowerInvariant()
        {
            return Value.ToLowerInvariant();
        }

        /// <summary>
        /// Returns a copy of this <see cref="String"/> object converted to uppercase using the casing rules of the invariant culture.
        /// </summary>
        /// <returns>
        /// A <see cref="String"/> object in uppercase.
        /// </returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/></PermissionSet>
        public string ToUpperInvariant()
        {
            return Value.ToUpperInvariant();
        }

        /// <summary>
        /// Returns a copy of this <see cref="String"/> converted to uppercase, using the casing rules of the current culture.
        /// </summary>
        /// <returns>
        /// A <see cref="String"/> in uppercase.
        /// </returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/></PermissionSet>
        public string ToUpper()
        {
            return Value.ToUpper();
        }

        /// <summary>
        /// Returns a copy of this <see cref="String"/> converted to uppercase, using the casing rules of the specified culture.
        /// </summary>
        /// <returns>
        /// A <see cref="String"/> in uppercase.
        /// </returns>
        /// <param name="culture">A <see cref="CultureInfo"/> object that supplies culture-specific casing rules.</param>
        /// <exception cref="ArgumentNullException"><paramref name="culture"/> is null.</exception>
        /// <PermissionSet><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/></PermissionSet>
        public string ToUpper(CultureInfo culture)
        {
            return Value.ToUpper(culture);
        }


        /// <summary>
        /// Returns this instance of <see cref="String"/>; no actual conversion is performed.
        /// </summary>
        /// <returns>
        /// This <see cref="String"/>.
        /// </returns>
        public override string ToString()
        {
            return Value;
        }

        /// <summary>
        /// Removes all leading and trailing white-space characters from the current <see cref="String"/> object.
        /// </summary>
        /// <returns>
        /// The string that remains after all white-space characters are removed from the start and end of the current <see cref="String"/> object.
        /// </returns>
        public CaseInsensitiveString Trim()
        {
            return Value.Trim();
        }

        /// <summary>
        /// Inserts a specified instance of <see cref="String"/> at a specified index position in this instance.
        /// </summary>
        /// <returns>
        /// A new <see cref="String"/> equivalent to this instance but with <paramref name="value"/> inserted at position <paramref name="startIndex"/>.
        /// </returns>
        /// <param name="startIndex">The index position of the insertion.</param>
        /// <param name="value">The <see cref="String"/> to insert.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="startIndex"/> is negative or greater than the length of this instance.</exception>
        public CaseInsensitiveString Insert(int startIndex, string value)
        {
            return Value.Insert(startIndex, value);
        }

        /// <summary>
        /// Replaces all occurrences of a specified Unicode character in this instance with another specified Unicode character.
        /// </summary>
        /// <returns>
        /// A <see cref="String"/> equivalent to this instance but with all instances of <paramref name="oldChar"/> replaced with <paramref name="newChar"/>.
        /// </returns>
        /// <param name="oldChar">A Unicode character to be replaced.</param>
        /// <param name="newChar">A Unicode character to replace all occurrences of <paramref name="oldChar"/>.</param>
        public CaseInsensitiveString Replace(char oldChar, char newChar)
        {
            //TODO: not the fastest way
            return Replace(oldChar.ToString(), newChar.ToString());
        }

        /// <summary>
        /// Replaces all occurrences of a specified <see cref="String"/> in this instance, with another specified <see cref="String"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="String"/> equivalent to this instance but with all instances of <paramref name="pattern"/> replaced with <paramref name="replacement"/>.
        /// </returns>
        /// <param name="pattern">A <see cref="String"/> to be replaced.</param>
        /// <param name="replacement">A <see cref="String"/> to replace all occurrences of <paramref name="pattern"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="pattern"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="pattern"/> is the empty string ("").</exception>
        public CaseInsensitiveString Replace(string pattern, string replacement)
        {

            if (String.IsNullOrEmpty(pattern))
            {
                return this;
            }


            var posCurrent = 0;
            var lenPattern = pattern.Length;
            var idxNext = Value.IndexOf(pattern, StringComparison.InvariantCultureIgnoreCase);
            var result = new StringBuilder();

            while (idxNext >= 0)
            {
                result.Append(Value, posCurrent, idxNext - posCurrent);
                result.Append(replacement);

                posCurrent = idxNext + lenPattern;

                idxNext = Value.IndexOf(pattern, posCurrent, StringComparison.InvariantCultureIgnoreCase);
            }

            result.Append(Value, posCurrent, Value.Length - posCurrent);

            return result.ToString();
        }

        /// <summary>
        /// Deletes a specified number of characters from this instance beginning at a specified position.
        /// </summary>
        /// <returns>
        /// A new <see cref="String"/> that is equivalent to this instance less <paramref name="count"/> number of characters.
        /// </returns>
        /// <param name="startIndex">The zero-based position to begin deleting characters.</param>
        /// <param name="count">The number of characters to delete.</param>
        /// <exception cref="ArgumentOutOfRangeException">Either <paramref name="startIndex"/> or <paramref name="count"/> is less than zero.
        /// -or-
        /// <paramref name="startIndex"/> plus <paramref name="count"/> specify a position outside this instance.
        /// </exception>
        public CaseInsensitiveString Remove(int startIndex, int count)
        {
            return Value.Remove(startIndex, count);
        }

        /// <summary>
        /// Deletes all the characters from this string beginning at a specified position and continuing through the last position.
        /// </summary>
        /// <returns>
        /// A new <see cref="String"/> object that is equivalent to this string less the removed characters.
        /// </returns>
        /// <param name="startIndex">The zero-based position to begin deleting characters.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="startIndex"/> is less than zero.
        /// -or-
        /// <paramref name="startIndex"/> specifies a position that is not within this string.
        /// </exception>
        public CaseInsensitiveString Remove(int startIndex)
        {
            return Value.Remove(startIndex);
        }

        /// <summary>
        /// Remove <paramref name="toRemove"/> string if it is the of this string.
        /// </summary>
        /// <param name="toRemove"></param>
        /// <returns></returns>
        public CaseInsensitiveString RemoveEnd(string toRemove)
        {
            Guard.ArgumentNotNullOrEmptyString(toRemove, "toRemove");
            if (EndsWith(toRemove))
            {
                return Substring(0, Length - toRemove.Length);
            }
            return this;
        }


    }
}