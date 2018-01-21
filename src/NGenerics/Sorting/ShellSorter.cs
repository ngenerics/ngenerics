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
    /// A sorter that implements the Shell Sort algorithm.
	/// </summary>
    /// <typeparam name="T">The type of the elements to be sorted.</typeparam>
    /// <example>
    /// <code source="..\..\NGenerics.Examples\Sorting\ShellSorterExamples.cs" region="Sort" lang="cs" title="The following example shows how to use the Sort method."/>
    /// </example>
	public sealed class ShellSorter<T> : ComparisonSorter<T>
	{
		#region Sorter<T> Members

		/// <inheritdoc />
        protected override void SortItems(IList<T> list, IComparer<T> comparer)
		{
			var delta = list.Count;

			do
			{
				delta = 1 + (delta / 3);

				for (var i = 0; i < delta; i++)
				{
					var counter = delta + i;

					// Insertion sort the segments
					while (counter < list.Count)
					{
						var start = counter;
						var tmp = list[start];
					
						while (start != i)
						{
							if (comparer.Compare(list[start - delta], tmp) > 0)
							{
								list[start] = list[start - delta];
								start -= delta;
							}
							else
							{
								break;
							}
						}

						list[start] = tmp;
						counter += delta;
					}
				}
			}
			while (delta > 1);
		}

		#endregion
	}
}
