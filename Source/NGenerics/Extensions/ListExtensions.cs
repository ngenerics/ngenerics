/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html. 
*/

using System;
using System.Collections.Generic;
#if (!WINDOWS_PHONE)
using System.Linq.Expressions;
#endif
using NGenerics.Sorting;
using NGenerics.Util;

namespace NGenerics.Extensions
{
    /// <summary>
    /// Extensions for the generic <see cref="List{T}"/> class.
    /// </summary>
    public static class ListExtensions
    {

   
        /// <inheritdoc cref="List{T}.GetRange"/>
        public static IList<T> GetRange<T>(this IList<T> enumerable,int index, int count)
        {
			Guard.ArgumentNotNull(enumerable, "enumerable");

			if (count < 0)
			{
				throw new IndexOutOfRangeException("count is below zero");
			}
			if (index < 0)
			{
				throw new IndexOutOfRangeException("index is below zero");
			}
			if ((enumerable.Count - index) < count)
			{
				throw new ArgumentException("Count is too small", "count");
			}

            var list = new List<T>(count);
            for (var i = index; i < index + count; i++)
            {
                list.Add(enumerable[i]);
            }
            return list;
        }

   

        /// <summary>
        /// Adds the range of items to the list.
        /// </summary>
        /// <typeparam name="T">The type of item.</typeparam>
        /// <param name="list">The list to add the items to.</param>
        /// <param name="collection">The collection of items to add.</param>
		public static void AddRange<T>(this IList<T> list, IEnumerable<T> collection)
        {
			Guard.ArgumentNotNull(list, "list");
            Guard.ArgumentNotNull(collection, "collection");

			collection.ForEach(list.Add);
        }

        /// <summary>
        /// Finds the index of the first item in the list that matches the specified predicate.
        /// </summary>
        /// <typeparam name="T">The type of item in the list.</typeparam>
        /// <param name="list">The list to search.</param>
        /// <param name="match">The matching predicate.</param>
        /// <returns>The index of the first item in the list that matches the specified predicate, -1 if none was found.</returns>
        public static int FindIndex<T>(this IList<T> list, Predicate<T> match)
		{
			Guard.ArgumentNotNull(list, "list");
			Guard.ArgumentNotNull(match, "match");

            return FindIndex(list, 0, match);

        }

        /// <summary>
        /// Finds the index of the first item in the list that matches the specified predicate.
        /// </summary>
        /// <typeparam name="T">The type of item in the list.</typeparam>
        /// <param name="list">The list to search.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="match">The matching predicate.</param>
        /// <returns>
        /// The index of the first item in the list that matches the specified predicate, -1 if none was found.
        /// </returns>
        public static int FindIndex<T>(this IList<T> list, int startIndex, Predicate<T> match)
		{
			Guard.ArgumentNotNull(list, "list");
			Guard.ArgumentNotNull(match, "match");

            return FindIndex(list, startIndex, list.Count - startIndex, match);
        }

        /// <summary>
        /// Finds the index of the first item in the list that matches the specified predicate.
        /// </summary>
        /// <typeparam name="T">The type of item in the list.</typeparam>
        /// <param name="list">The list to search.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="count">The number of items to inspect from the start index.</param>
        /// <param name="match">The matching predicate.</param>
        /// <returns>
        /// The index of the first item in the list that matches the specified predicate, -1 if none was found.
        /// </returns>
        public static int FindIndex<T>(this IList<T> list, int startIndex, int count, Predicate<T> match)
		{
			Guard.ArgumentNotNull(list, "list");
			Guard.ArgumentNotNull(match, "match");

            if (startIndex > list.Count)
            {
                throw new ArgumentOutOfRangeException("startIndex");
            }
            if ((count < 0) || (startIndex > (list.Count - count)))
            {
                throw new ArgumentOutOfRangeException("count");
            }

            var num = startIndex + count;
            for (var i = startIndex; i < num; i++)
            {
                if (match(list[i]))
                {
                    return i;
                }
            }
            return -1;
        }



        /// <summary>
        /// Finds the index of the last item in the list that matches the specified predicate.
        /// </summary>
        /// <typeparam name="T">The type of item in the list.</typeparam>
        /// <param name="list">The list to search.</param>
        /// <param name="match">The matching predicate.</param>
        /// <returns>
        /// The index of the last item in the list that matches the specified predicate if any was found, -1.
        /// </returns>
        public static int FindLastIndex<T>(this IList<T> list, Predicate<T> match)
		{
			Guard.ArgumentNotNull(list, "list");
			Guard.ArgumentNotNull(match, "match");

            return FindLastIndex(list, list.Count - 1, list.Count, match);
        }


        /// <summary>
        /// Finds the index of the last item in the list that matches the specified predicate.
        /// </summary>
        /// <typeparam name="T">The type of item in the list.</typeparam>
        /// <param name="list">The list to search.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="match">The matching predicate.</param>
        /// <returns>
        /// The index of the last item in the list that matches the specified predicate if any was found, -1.
        /// </returns>
        public static int FindLastIndex<T>(this IList<T> list, int startIndex, Predicate<T> match)
		{
			Guard.ArgumentNotNull(list, "list");
			Guard.ArgumentNotNull(match, "match");

            return FindLastIndex(list, startIndex, startIndex + 1, match);
        }


        /// <summary>
        /// Finds the index of the last item in the list that matches the specified predicate.
        /// </summary>
        /// <typeparam name="T">The type of item in the list.</typeparam>
        /// <param name="list">The list to search.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="count">The number of items to inspect from the start index.</param>
        /// <param name="match">The matching predicate.</param>
        /// <returns>
        /// The index of the last item in the list that matches the specified predicate if any was found, -1.
        /// </returns>
        public static int FindLastIndex<T>(this IList<T> list, int startIndex, int count, Predicate<T> match)
		{
			Guard.ArgumentNotNull(list, "list");
            Guard.ArgumentNotNull(match, "match");

            if (list.Count == 0)
            {
                if (startIndex != -1)
                {
                    throw new ArgumentOutOfRangeException("startIndex");
                }
            }
            else if (startIndex >= list.Count)
            {
                throw new ArgumentOutOfRangeException("startIndex");
            }
            if ((count < 0) || (((startIndex - count) + 1) < 0))
            {
                throw new ArgumentOutOfRangeException("count");
            }
            var num = startIndex - count;
            for (var i = startIndex; i > num; i--)
            {
                if (match(list[i]))
                {
                    return i;
                }
            }
            return -1;

        }


        /// <summary>
        /// Performs the specified action on each item in the list.
        /// </summary>
        /// <typeparam name="T">The type of item in the list.</typeparam>
        /// <param name="list">The list to enumerate over.</param>
        /// <param name="action">The action to execute.</param>
        public static void ForEach<T>(this IList<T> list, Action<T> action)
		{
			Guard.ArgumentNotNull(list, "list");
            Guard.ArgumentNotNull(action, "action");

            foreach (var item in list)
            {
                action(item);
            }
		}


        /// <inheritdoc cref="List{T}.InsertRange"/>
        public static void InsertRange<T>(this IList<T> list, int index, IEnumerable<T> collection)
		{
			Guard.ArgumentNotNull(list, "list");
            Guard.ArgumentNotNull(collection, "collection");

            if (index > list.Count)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            foreach (var t in collection)
            {
                list.Insert(index++, t);
            }
        }
 

 

        /// <inheritdoc cref="List{T}.RemoveAll"/>
        public static int RemoveAll<T>(this IList<T> list, Predicate<T> match)
		{
			Guard.ArgumentNotNull(list, "list");
            Guard.ArgumentNotNull(match, "match");

            var index = 0;
            var count = 0;
            while (index < list.Count)
            {
                var t = list[index];
                if (match(t))
                {
                    list.RemoveAt(index);
                    count++;
                }
                else
                {
                    index++;
                }
            }
            return count;
        }





        /// <summary>
        /// Sorts the specified list.
        /// </summary>
        /// <typeparam name="T">The type of item in the list.</typeparam>
        /// <param name="list">The list.</param>
        public static void Sort<T>(this IList<T> list)
		{
			Guard.ArgumentNotNull(list, "list");

            var sorter = new QuickSorter<T>();
            sorter.Sort(list);
        }

        /// <summary>
        /// Sorts the specified list.
        /// </summary>
        /// <typeparam name="T">The type of item in the list.</typeparam>
        /// <param name="list">The list.</param>
        /// <param name="sortOrder">The order in which to sort the list.</param>
        public static void Sort<T>(this IList<T> list, SortOrder sortOrder)
		{
			Guard.ArgumentNotNull(list, "list");

            var sorter = new QuickSorter<T>();
            sorter.Sort(list, sortOrder);
        }

        /// <summary>
        /// Sorts the specified list.
        /// </summary>
        /// <typeparam name="T">The type of item in the list.</typeparam>
        /// <param name="list">The list.</param>
        /// <param name="comparer">The comparer.</param>
        public static void Sort<T>(this IList<T> list, IComparer<T> comparer)
		{
			Guard.ArgumentNotNull(list, "list");
			Guard.ArgumentNotNull(comparer, "comparer");

            var sorter = new QuickSorter<T>();
            sorter.Sort(list, comparer);
        }

        /// <summary>
        /// Sorts the specified list.
        /// </summary>
        /// <typeparam name="T">The type of item in the list.</typeparam>
        /// <param name="list">The list.</param>
        /// <param name="comparison">The comparison.</param>
        public static void Sort<T>(this IList<T> list, Comparison<T> comparison)
		{
			Guard.ArgumentNotNull(list, "list");
			Guard.ArgumentNotNull(comparison, "comparison");

            var sorter = new QuickSorter<T>();
            sorter.Sort(list, comparison);
        }

        /// <summary>
        /// Sorts the specified list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <param name="comparison">The comparison.</param>
        /// <param name="sortOrder">The order in which to sort the list.</param>
        public static void Sort<T>(this IList<T> list, Comparison<T> comparison, SortOrder sortOrder)
        {
            Guard.ArgumentNotNull(list, "list");
            Guard.ArgumentNotNull(comparison, "comparison");

            var sorter = new QuickSorter<T>();
            sorter.Sort(list, comparison, sortOrder);
        }

#if (!WINDOWSPHONE)
        /// <summary>
        /// Sorts the specified list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="property">The target property to use to sort the list.</param>
        public static void Sort<T>(this IList<T> list, Expression<Func<T, IComparable>> property)
        {
            Sort(list, property, SortOrder.Ascending);
        }

        /// <summary>
        /// Sorts the specified list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="sortOrder">The order in which to sort the list.</param>
        /// <param name="property">The target property to use to sort the list.</param>
        public static void Sort<T>(this IList<T> list, Expression<Func<T, IComparable>> property, SortOrder sortOrder)
        {
            Guard.ArgumentNotNull(list, "list");
            Guard.ArgumentNotNull(property, "property");

            var sorter = new QuickSorter<T>();
            var comparison = new Comparison<T>((x, y) =>
                                               {
                                                   var compile = property.Compile();
                                                   return compile(x).CompareTo(compile(y));
                                               });
            sorter.Sort(list, comparison, sortOrder);
        }
#endif


        #if SILVERLIGHT

        /// <inheritdoc cref="List{T}.ConvertAll{TOutput}"/>
        public static List<TOutput> ConvertAll<T, TOutput>(this IList<T> enumerable, Converter<T, TOutput> converter) {
            Guard.ArgumentNotNull(converter, "converter");
            var list = new List<TOutput>(enumerable.Count);
            for (var i = 0; i < enumerable.Count; i++) {
                list.Add(converter(enumerable[i]));
            }
            return list;
        }

        #endif

    }
}