/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
#if (!SILVERLIGHT && !WINDOWSPHONE)
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;


namespace NGenerics.Extensions
{
    /// <summary>
    /// Extensions methods on the <see cref="System.Object"/> class.
    /// </summary>
    public static class ObjectExtensions
    {

        /// <summary>
        /// Converts the specified value into the type specified by the generic parameter if possible.
        /// </summary>
        /// <typeparam name="T">The type to convert the object into.</typeparam>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        /// <exception cref="NotSupportedException">When no compatible type converter is found for the operation.</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\Extensions\ObjectExtensionsExamples.cs" region="ConvertTo" lang="cs" title="The following example shows how to use the ConvertTo method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\Extensions\ObjectExtensionsExamples.vb" region="ConvertTo" lang="vbnet" title="The following example shows how to use the ConvertTo method."/>
        /// </example>
        public static T ConvertTo<T>(this object value)
        {
            return (T) TypeDescriptor
                        .GetConverter(typeof(T))
                        .ConvertFrom(value);
        }
        
        /// <summary>
        /// Serializes any Serializable Object to XMLString
        /// </summary>
        /// <remarks>Uses <see cref="XmlSerializer"/>.</remarks>
        /// <typeparam name="T">The type of object to serialize.</typeparam>
        /// <param name="obj">The object to serialize.</param>
        /// <returns>A serialized representation of the object.</returns>
        public static string Serialize<T>(this T obj)
        {
            var serializer = new XmlSerializer(typeof(T));
            
            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, obj);
                return writer.ToString();
            }
        }

        /// <summary>
        /// Deserializes object from String
        /// </summary>
        /// <remarks>Uses <see cref="XmlSerializer"/>.</remarks>
        /// <typeparam name="T">The type of object to deserialize.</typeparam>
        /// <param name="xml">The XML to deserialize the object from.</param>
        /// <returns>ready populated object</returns>
        public static T Deserialize<T>(string xml)
        {
            using (var reader = (new StringReader(xml)))
            {
                var serializer = new XmlSerializer(typeof (T));
                return (T) serializer.Deserialize(reader);
            }
        }


        /// <summary>
        /// Performs a deep copy the specified serializable object.
        /// </summary>
        /// <typeparam name="T">The type of object to perform a deep copy on.</typeparam>
        /// <param name="obj">The object to perform a deep copy on.</param>
        /// <returns>A copy of the specified object.</returns>
        /// <remarks>This method relies on serialization (<see cref="BinaryFormatter"/>) for a generic deep copy routine - if performance is needed, rather implement <see cref="ICloneable"/>.</remarks>
        public static T DeepCopy<T>(this T obj) 
        {
            var formatter = new BinaryFormatter();

            using (var memStream = new MemoryStream())
            {
                formatter.Serialize(memStream, obj);
                memStream.Position = 0;
                return (T)formatter.Deserialize(memStream);
            }
        }

        /// <summary>
        /// Wraps an object in an <see cref="List{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of object to wrap.</typeparam>
        /// <param name="obj">The object to wrap.</param>
        /// <returns>A new <see cref="List{T}"/> containing the object.</returns>
        [Obsolete("Made obsolete to stop conflicting with Enumerable.ToList. Use ObjectExtensions.ToIList instead.", true)]
        public static List<T> ToList<T>(this T obj)
        {
            return new List<T>{obj};
        }
        /// <summary>
        /// Wraps an object in an <see cref="List{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of object to wrap.</typeparam>
        /// <param name="obj">The object to wrap.</param>
        /// <returns>A new <see cref="List{T}"/> containing the object.</returns>
        public static List<T> ToIList<T>(this T obj)
        {
            return new List<T>{obj};
        }
    }
}
#endif