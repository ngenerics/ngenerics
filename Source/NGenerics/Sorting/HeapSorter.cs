/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System.Collections.Generic;
using NGenerics.DataStructures.General;

namespace NGenerics.Sorting
{
    /// <summary>
    /// An sorter for the Heap Sort algorithm.
	/// </summary>
    /// <typeparam name="T">The type of the elements to be sorted.</typeparam>
    /// <example>
    /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\Sorting\HeapSorterExamples.cs" region="Sort" lang="cs" title="The following example shows how to use the Sort method."/>
    /// <code source="..\..\Source\Examples\ExampleLibraryVB\Sorting\HeapSorterExamples.vb" region="Sort" lang="vbnet" title="The following example shows how to use the Sort method."/>
    /// </example>
	public sealed class HeapSorter<T> : ComparisonSorter<T>
	{
		#region Sorter<T> Members

		/// <inheritdoc />
        protected override void SortItems(IList<T> list, IComparer<T> comparer) 
		{
            // TODO : Make this a real Heap Sort and not use the provided Heap<T> data structure.
			var heap = new Heap<T>(HeapType.Minimum, list.Count, comparer);

			for (var i = 0; i < list.Count; i++)
			{
				heap.Add(list[i]);
			}

			for (var i = 0; i < list.Count; i++)
			{
				list[i] = heap.RemoveRoot();
			}
		}

		#endregion
	}
}
