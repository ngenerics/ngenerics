/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System.Collections.Generic;

namespace NGenerics.Sorting
{
    /// <summary>
    /// A Quick Sort sorter.
    /// </summary>
    /// <typeparam name="T">The type of the elements to be sorted.</typeparam>
    /// <example>
    /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\Sorting\QuickSorterExamples.cs" region="Sort" lang="cs" title="The following example shows how to use the Sort method."/>
    /// <code source="..\..\Source\Examples\ExampleLibraryVB\Sorting\QuickSorterExamples.vb" region="Sort" lang="vbnet" title="The following example shows how to use the Sort method."/>
    /// </example>
    public sealed class QuickSorter<T> : ComparisonSorter<T>
    {
        #region Sorter<T> Members
		/// <inheritdoc />
        protected override void SortItems(IList<T> list, IComparer<T> comparer)
        {
            QuickSort(list, comparer, 0, list.Count - 1);
        }

        #endregion

        #region Private Members

        /// <summary>
        /// Quicks the sort.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="comparer">The comparer.</param>
        /// <param name="leftBoundary">The left boundary.</param>
        /// <param name="rightBoundary">The right boundary.</param>
        private static void QuickSort(IList<T> list, IComparer<T> comparer, int leftBoundary, int rightBoundary)
        {
            // Check for overlapping boundaries
            if (leftBoundary < rightBoundary)
            {
                var pivotIndex = GetPivot(list, comparer, leftBoundary, rightBoundary);
                QuickSort(list, comparer, leftBoundary, pivotIndex - 1);
                QuickSort(list, comparer, pivotIndex + 1, rightBoundary);
            }
        }

        /// <summary>
        /// Gets the pivot.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="comparer">The comparer.</param>
        /// <param name="leftBoundary">The left boundary.</param>
        /// <param name="rightBoundary">The right boundary.</param>
        private static int GetPivot(IList<T> list, IComparer<T> comparer, int leftBoundary, int rightBoundary)
        {
            var middle = (leftBoundary + rightBoundary) / 2;

            if (comparer.Compare(list[leftBoundary], list[rightBoundary]) < 0)
            {
                Swap(list, leftBoundary, rightBoundary);
            }

            if (comparer.Compare(list[middle], list[rightBoundary]) < 0)
            {
                Swap(list, middle, rightBoundary);
            }

            if (comparer.Compare(list[leftBoundary], list[middle]) > 0)
            {
                Swap(list, leftBoundary, middle);
            }

            var pivotIndex = leftBoundary;
            var pivot = list[pivotIndex];

            for (var i = leftBoundary + 1; i <= rightBoundary; i++)
            {
                if (comparer.Compare(list[i], pivot) < 0)
                {
                    pivotIndex++;
                    Swap(list, pivotIndex, i);
                }
            }

            Swap(list, leftBoundary, pivotIndex);

            return pivotIndex;
        }

        #endregion
    }
}