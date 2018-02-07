/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/


using System.Collections.Generic;

namespace NGenerics.Sorting
{
    /// <summary>
    /// A sorter implementing the Selection Sort algorithm.
	/// </summary>
    /// <typeparam name="T">The type of the elements to be sorted.</typeparam>
    /// <example>
    /// <code source="..\..\NGenerics.Examples\Sorting\SelectionSorterExamples.cs" region="Sort" lang="cs" title="The following example shows how to use the Sort method."/>
    /// </example>
	public sealed class SelectionSorter<T> : ComparisonSorter<T>
	{
		#region Sorter<T> Members

		/// <inheritdoc />
        protected override void SortItems(IList<T> list, IComparer<T> comparer)
		{
		    for (var i = 0; i < list.Count; i++)
			{
                var minIndex = i;

				// Find the smallest item in what's left of the array
				for (var j = i + 1; j < list.Count; j++)
				{
					if (comparer.Compare(list[j], list[minIndex]) < 0)
					{
						minIndex = j;
					}
				}

				// Swap the minimum and the current item at index i.
				Swap(list, i, minIndex);
			}
		}

		#endregion
	}
}
