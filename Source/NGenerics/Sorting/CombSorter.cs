/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/


/*
 * Adapted from wikipedia : http://en.wikipedia.org/wiki/Comb_sort
 */

using System.Collections.Generic;

namespace NGenerics.Sorting
{
	/// <summary>
	/// A comb sorter.  
	/// </summary>
    /// <typeparam name="T">The type of the elements to be sorted.</typeparam>
    /// <example>
    /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\Sorting\CombSorterExamples.cs" region="Sort" lang="cs" title="The following example shows how to use the Sort method."/>
    /// <code source="..\..\Source\Examples\ExampleLibraryVB\Sorting\CombSorterExamples.vb" region="Sort" lang="vbnet" title="The following example shows how to use the Sort method."/>
    /// </example>
	public sealed class CombSorter<T> : ComparisonSorter<T>
	{
		#region Sorter<T> Members

		/// <inheritdoc />
        protected override void SortItems(IList<T> list, IComparer<T> comparer) 
		{
			var gap = list.Count;
			
			while (!((gap == 1)))
			{
				if (gap > 1)
				{
					gap = (int)(gap / 1.3);

					if ((gap == 10) || (gap == 9))
					{
						gap = 11;
					}
				}

				var i = 0;

				while ((i + gap) != list.Count)
				{
                    if (comparer.Compare(list[i], list[i + gap]) > 0)
                    {
                        Swap(list, i, i + gap);
                    }
				    i++;
				}
			}
		}

		#endregion
	}
}
