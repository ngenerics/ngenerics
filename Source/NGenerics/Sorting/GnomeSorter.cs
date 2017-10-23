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
    /// A sorter implementing the Gnome sort algorithm.
	/// </summary>
    /// <typeparam name="T">The type of the elements to be sorted.</typeparam>
    /// <example>
    /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\Sorting\GnomeSorterExamples.cs" region="Sort" lang="cs" title="The following example shows how to use the Sort method."/>
    /// <code source="..\..\Source\Examples\ExampleLibraryVB\Sorting\GnomeSorterExamples.vb" region="Sort" lang="vbnet" title="The following example shows how to use the Sort method."/>
    /// </example>
	public sealed class GnomeSorter<T> : ComparisonSorter<T>
	{
		#region Sorter<T> Members

		/// <inheritdoc />
        protected override void SortItems(IList<T> list, IComparer<T> comparer) 
		{
			var i = 1;

			while (i < list.Count)
			{
				if (comparer.Compare(list[i - 1], list[i]) <= 0)
				{
					i++;
				}
				else
				{
					Swap(list, i - 1, i);

					if (i > 1)
					{
						i--;
					}					
				}
			}
		}

		#endregion
	}
}
