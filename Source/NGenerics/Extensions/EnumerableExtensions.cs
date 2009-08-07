/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/

using System;
using System.Collections.Generic;
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
        /// <typeparam name="T"></typeparam>
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
    }
}
