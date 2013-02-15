/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System.Collections.Generic;

namespace NGenerics.Sorting
{
    /// <summary>
    /// A Bubble Sorter.
	/// </summary>
    /// <typeparam name="T">The type of the elements to be sorted.</typeparam>
    /// <example>
    /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\Sorting\BubbleSorterExamples.cs" region="Sort" lang="cs" title="The following example shows how to use the Sort method."/>
    /// <code source="..\..\Source\Examples\ExampleLibraryVB\Sorting\BubbleSorterExamples.vb" region="Sort" lang="vbnet" title="The following example shows how to use the Sort method."/>
    /// </example>
	public sealed class BubbleSorter<T> : ComparisonSorter<T>
	{
		#region Sorter<T> Members

		/// <inheritdoc />
        protected override void SortItems(IList<T> list, IComparer<T> comparer)
		{
			for (var i = list.Count - 1; i >= 0; i--)
			{
				for (var j = 0; j < i; j++)
				{
					if (comparer.Compare(list[j], list[j + 1]) > 0)
					{
						Swap(list, j, j + 1);
					}
				}
			}
		}

		#endregion
	}
}
