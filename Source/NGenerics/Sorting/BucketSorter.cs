/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System.Collections.Generic;
using NGenerics.Util;

namespace NGenerics.Sorting
{
    /// <summary>
    /// A sorter that implements the Bucket Sort algorithm.
    /// </summary>
    /// <example>
    /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\Sorting\BucketSorterExamples.cs" region="Sort" lang="cs" title="The following example shows how to use the Sort method."/>
    /// <code source="..\..\Source\Examples\ExampleLibraryVB\Sorting\BucketSorterExamples.vb" region="Sort" lang="vbnet" title="The following example shows how to use the Sort method."/>
	/// <code source="..\..\Source\Examples\ExampleLibraryCSharp\Sorting\BucketSorterExamples.cs" region="SortWithSortOrder" lang="cs" title="The following example shows how to use the Sort method with a SortOrder."/>
	/// <code source="..\..\Source\Examples\ExampleLibraryVB\Sorting\BucketSorterExamples.vb" region="SortWithSortOrder" lang="vbnet" title="The following example shows how to use the Sort method with a SortOrder."/>
    /// </example>
	public sealed class BucketSorter : Sorter<int>
	{
		#region Globals

        private readonly int maximumUniverse;

		#endregion

		#region Construction

        /// <param name="maximumUniverse">The maximum universe.</param>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\Sorting\BubbleSorterExamples.cs" region="Sort" lang="cs" title="The following example shows how to use the Sort method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\Sorting\BubbleSorterExamples.vb" region="Sort" lang="vbnet" title="The following example shows how to use the Sort method."/>
        /// </example>
		public BucketSorter(int maximumUniverse)
		{
            this.maximumUniverse = maximumUniverse;
		}

		#endregion

        #region ISorter<int> Members

		/// <inheritdoc />
        public override void Sort(IList<int> list, SortOrder order)
        {
            #region Validation

            Guard.ArgumentNotNull(list, "list");

            #endregion

            var maximumIndex = maximumUniverse + 1;
            var counters = new int[maximumIndex];

            for (var i = 0; i < list.Count; i++)
            {
                counters[list[i]]++;
            }

            if (order == SortOrder.Ascending)
            {
                var position = 0;

                for (var i = 0; i < maximumIndex; i++)
                {
                    for (var j = 0; j < counters[i]; j++)
                    {
                        list[position] = i;
                        position++;
                    }
                }
            }
            else
            {
                var position = list.Count - 1;

                for (var i = 0; i < maximumIndex; i++)
                {
                    for (var j = 0; j < counters[i]; j++)
                    {
                        list[position] = i;
                        position--;
                    }
                }
            }
        }

        #endregion
    }
}
