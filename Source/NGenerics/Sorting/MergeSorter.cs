/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/


/*
 * Adapted from CSSorters : http://web6.codeproject.com/cs/algorithms/cssorters.asp
 */

using System.Collections.Generic;

namespace NGenerics.Sorting
{
	/// <summary>
	/// A merge sorter.
	/// </summary>
    /// <typeparam name="T">The type of the elements to be sorted.</typeparam>
    /// <example>
    /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\Sorting\MergeSorterExamples.cs" region="Sort" lang="cs" title="The following example shows how to use the Sort method."/>
    /// <code source="..\..\Source\Examples\ExampleLibraryVB\Sorting\MergeSorterExamples.vb" region="Sort" lang="vbnet" title="The following example shows how to use the Sort method."/>
    /// </example>
	public sealed class MergeSorter<T> : ComparisonSorter<T>
	{
		#region Sorter<T> Members

		/// <inheritdoc />
        protected override void SortItems(IList<T> list, IComparer<T> comparer) 
		{
			MergeSort(0, list.Count - 1, list, comparer); 
		}
		
		#endregion

		#region Private Members

        /// <summary>
        /// Performs a merge sort.
        /// </summary>
        /// <param name="leftBoundary">The left boundary.</param>
        /// <param name="rightBoundary">The right boundary.</param>
        /// <param name="list">The list.</param>
        /// <param name="comparer">The comparer.</param>
		private static void MergeSort(int leftBoundary, int rightBoundary, IList<T> list, IComparer<T> comparer)
		{
			if (leftBoundary < rightBoundary)
			{
				var middle = (leftBoundary + rightBoundary) / 2;

				MergeSort(leftBoundary, middle, list, comparer);
				MergeSort(middle + 1, rightBoundary, list, comparer);

				while ((middle + 1 <= rightBoundary) && (leftBoundary <= middle))
				{
					if (comparer.Compare(list[leftBoundary], list[middle + 1]) < 0)
					{
						leftBoundary++;
					}
					else
					{
						var currentItem = list[middle + 1];

						for (var i = middle; i >= leftBoundary; i--)
						{
							list[i + 1] = list[i];
						}

						list[leftBoundary] = currentItem;
						leftBoundary++;
						middle++;
					}
				}
			}

		}

		#endregion
	}
}
