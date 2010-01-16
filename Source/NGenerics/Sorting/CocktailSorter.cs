/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


/*
 * Adapted from http://en.wikipedia.org/wiki/Cocktail_sort.
 */

using System.Collections.Generic;

namespace NGenerics.Sorting
{
    
	/// <summary>
	/// A Bi-Directional Bubble sorter.  
	/// </summary>
    /// <typeparam name="T">The type of the elements to be sorted.</typeparam>
    /// <example>
    /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\Sorting\CocktailSorterExamples.cs" region="Sort" lang="cs" title="The following example shows how to use the Sort method."/>
    /// <code source="..\..\Source\Examples\ExampleLibraryVB\Sorting\CocktailSorterExamples.vb" region="Sort" lang="vbnet" title="The following example shows how to use the Sort method."/>
    /// </example>
	public sealed class CocktailSorter<T> : ComparisonSorter<T>
	{
		#region Sorter<T> Members

		/// <inheritdoc />
		protected override void SortItems(IList<T> list, IComparer<T> comparer) 
        {
			var bottom = 0;
			var top = list.Count - 1;
			var swapped = true; 
			
			while(swapped) 
			{
				swapped = false; 
				
				for(var i = bottom; i < top; i++)
				{
					if (comparer.Compare(list[i], list[i + 1]) > 0) 
					{
						Swap(list, i, i + 1);
						swapped = true;
					}
				}

				top--;

				for(var j = top; j > bottom; j--)
				{
					if(comparer.Compare(list[j], list[j - 1]) < 0) 
					{
						Swap(list, j, j - 1);
						swapped = true;
					}
				}

				bottom++;
			}
		}

		#endregion
	}
}
