/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NGenerics.Util;

namespace NGenerics.Extensions
{
    /// <summary>
    /// Extensions for the IEnumerable interface.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Performs the specified action on each element of the collection.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="enumerable"/>.</typeparam>
        /// <param name="enumerable">The collection to enumerate over.</param>
        /// <param name="action">The action to perform on each item..</param>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\Extensions\IEnumerableExtensionsExamples.cs" region="ForEach" lang="cs" title="The following example shows how to use the ForEach method."/>
        /// </example>
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            Guard.ArgumentNotNull(enumerable, "enumerable");
            Guard.ArgumentNotNull(action, "action");


            foreach (var item in enumerable)
            {
                action(item);
            }
        }

        /// <summary>
        /// Concatenates all the values into a string using ", " as in betweeen each value.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="enumerable"/>.</typeparam>
        /// <param name="enumerable">The <see cref="IEnumerable{T}"/> to concatenate.</param>
        /// <param name="func">A <see cref="Func{T,V}"/> to convert each <typeparamref name="T"/> to a string.</param>
        /// <returns>All values concatenated into a string using ", " as in betweeen each value.</returns>
        public static string ConcatToString<T>(this IEnumerable<T> enumerable, Func<T, string> func)
        {
            return ConcatToString(enumerable, func, ", ");
        }

        /// <summary>
        /// Concatenates all the values into a string using <paramref name="joinString"/> as in betweeen each value.
        /// </summary>
        /// <typeparam name="T">The type of the elements of <paramref name="enumerable"/>.</typeparam>
        /// <param name="enumerable">The <see cref="IEnumerable{T}"/> to concatenate.</param>
        /// <param name="func">A <see cref="Func{T,V}"/> to convert each <typeparamref name="T"/> to a string.</param>
        /// <param name="joinString">The <see cref="string"/> to use in between each value.</param>
        /// <returns>All values concatenated into a string using ", " as in betweeen each value.</returns>
        private static string ConcatToString<T>(this IEnumerable<T> enumerable, Func<T, string> func, string joinString)
        {
            var stringBuilder = new StringBuilder();
            var list = Enumerable.ToList(enumerable);
            for (var index = 0; index < list.Count; index++)
            {
                var item = list[index];
                stringBuilder.Append(func(item));
                if (index != list.Count - 1)
                {
                    stringBuilder.Append(joinString);
                }
            }
            return stringBuilder.ToString();
        }
    }
}
