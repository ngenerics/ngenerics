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
