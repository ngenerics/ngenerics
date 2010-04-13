/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Collections.Generic;
using NGenerics.Extensions;

namespace NGenerics.Patterns.Conversion
{
    /// <summary>
    /// Extensions on the IConverter interface.
    /// </summary>
    public static class ConverterExtensions
    {
        #region Extension Methods

        /// <summary>
        /// Converts all.
        /// </summary>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <typeparam name="TOutput">The type of the output.</typeparam>
        /// <param name="converter">The converter.</param>
        /// <param name="input">The input.</param>
        /// <returns>The converted representation of the input.</returns>
        public static IEnumerable<TOutput> ConvertAll<TInput, TOutput>(this IConverter<TInput, TOutput> converter, IEnumerable<TInput> input)
        {
            return ConvertInternal(input, converter.Convert);
        }

        /// <summary>
        /// Converts all.
        /// </summary>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <typeparam name="T2">The type of the 2.</typeparam>
        /// <param name="converter">The converter.</param>
        /// <param name="input">The input.</param>
        /// <returns>The converted representation of the input.</returns>
        public static IEnumerable<T2> ConvertAll<T1, T2>(this IBidirectionalConverter<T1, T2> converter, IEnumerable<T1> input)
        {
            return ConvertInternal(input, converter.Convert);
        }

        /// <summary>
        /// Converts the specified value.
        /// </summary>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <typeparam name="TOutput">The type of the output.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="converter">The converter.</param>
        /// <returns>The converted representation of the input.</returns>
        public static IEnumerable<TOutput> ConvertAll<TInput, TOutput>(this IEnumerable<TInput> value, IConverter<TInput, TOutput> converter)
        {
            return converter.ConvertAll(value);
        }


        /// <summary>
        /// Converts the specified items.
        /// </summary>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <typeparam name="TOutput">The type of the output.</typeparam>
        /// <param name="items">The items.</param>
        /// <param name="converter">The converter.</param>
        /// <returns>The converted representation of the input.</returns>
        public static IEnumerable<TOutput> Convert<TInput, TOutput>(this IEnumerable<TInput> items, IConverter<TInput, TOutput> converter)
        {
            return converter.ConvertAll(items);
        }

        /// <summary>
        /// Converts the specified items.
        /// </summary>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <typeparam name="TOutput">The type of the output.</typeparam>
        /// <param name="items">The items.</param>
        /// <param name="converter">The converter.</param>
        /// <returns>The converted representation of the input.</returns>
        public static IEnumerable<TOutput> Convert<TInput, TOutput>(this IEnumerable<TInput> items, IBidirectionalConverter<TInput, TOutput> converter)
        {
            return converter.ConvertAll(items);
        }

        /// <summary>
        /// Converts the specified value.
        /// </summary>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <typeparam name="TOutput">The type of the output.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="converter">The converter.</param>
        /// <returns>The converted representation of the input.</returns>
        public static TOutput Convert<TInput, TOutput>(this TInput value, IConverter<TInput, TOutput> converter)
        {
            return converter.Convert(value);
        }
       
        #endregion

        #region Internal Members

        /// <summary>
        /// Converts the internal.
        /// </summary>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <typeparam name="TOutput">The type of the output.</typeparam>
        /// <param name="input">The input.</param>
        /// <param name="converter">The converter.</param>
        /// <returns></returns>
        private static IEnumerable<TOutput> ConvertInternal<TInput, TOutput>(IEnumerable<TInput> input, Converter<TInput, TOutput> converter)
        {
            var list = new List<TOutput>();
            input.ForEach(x => list.Add(converter(x)));
            return list;
        }

        #endregion
    }
}