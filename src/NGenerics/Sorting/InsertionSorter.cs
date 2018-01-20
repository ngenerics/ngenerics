/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/



using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System;

namespace NGenerics.Sorting
{
    /// <summary>
    /// A sorter that implements the Insertion sort algorithm.
    /// </summary>
    /// <typeparam name="T">The type of the elements to be sorted.</typeparam>
    /// <example>
    /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\Sorting\InsertionSorterExamples.cs" region="Sort" lang="cs" title="The following example shows how to use the Sort method."/>
    /// <code source="..\..\Source\Examples\ExampleLibraryVB\Sorting\InsertionSorterExamples.vb" region="Sort" lang="vbnet" title="The following example shows how to use the Sort method."/>
    /// </example>
    public sealed class InsertionSorter<T> : ComparisonSorter<T>
    {
        #region Sorter<T> Members

        /// <summary>
        /// Sorts the specified list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="comparer">The comparer to use in comparing items.</param>
        protected override void SortItems(IList<T> list, IComparer<T> comparer)
        {
            Sort(list, comparer, 0, list.Count - 1);
        }

        #endregion

        #region Private Members

        /// <summary>
        /// Inserts the specified item into the list in the correct position.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="sortedSequenceLength">Length of the sorted sequence.</param>
        /// <param name="val">The item to insert.</param>
        /// <param name="comparer">The comparer to use.</param>
        private static void Insert(IList<T> list, int sortedSequenceLength, T val, IComparer<T> comparer)
        {
            var i = sortedSequenceLength - 1;

            while ((i >= 0) && (comparer.Compare(list[i], val) > 0))
            {
                list[i + 1] = list[i];
                i--;
            }

            list[i + 1] = val;
        }

        /// <summary>
        /// Sorts the specified list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="comparer">The comparer.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentNullException"><paramref name="list"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        [SuppressMessage("Microsoft.Usage", "CA2233:OperationsShouldNotOverflow", MessageId = "end+1")]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        private void Sort(IList<T> list, IComparer<T> comparer, int start, int end)
        {
            if (end - start + 1 <= 1)
            {
                return;
            }

            var counter = start;

            while (counter < end + 1)
            {
                Insert(list, counter, list[counter], comparer);
                counter++;
            }
        }

        #endregion
    }
}