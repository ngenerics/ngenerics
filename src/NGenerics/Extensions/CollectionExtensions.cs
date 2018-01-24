/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System.Collections.Generic;

namespace NGenerics.Extensions
{

    /// <summary>
    /// Extensions for ICollection implementations.
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Tests whether the collection is empty.
        /// </summary>
        /// <typeparam name="T">The type of item in the collection.</typeparam>
        /// <param name="collection">The collection to perform this action on.</param>
        /// <returns></returns>
        public static bool IsEmpty<T>(this ICollection<T> collection)
        {
            return collection.Count == 0;
        }
    }
}
