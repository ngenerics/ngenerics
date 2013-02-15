/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
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

        #region Construction

        /// <param name="maximumUniverse">The maximum universe.(Obsolete)</param> 
        [Obsolete]
        public BucketSorter(int maximumUniverse)
        {

        }


        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\Sorting\BubbleSorterExamples.cs" region="Sort" lang="cs" title="The following example shows how to use the Sort method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\Sorting\BubbleSorterExamples.vb" region="Sort" lang="vbnet" title="The following example shows how to use the Sort method."/>
        /// </example>
        public BucketSorter()
        {

        }
        #endregion

        #region ISorter<int> Members

        /// <inheritdoc />
        public override void Sort(IList<int> list, SortOrder order)
        {
            #region Validation

            Guard.ArgumentNotNull(list, "list");

            #endregion

            if (list.Count <= 1)
                return;

			var max = list[0];
			var min = list[0];

            for (var i = 0; i < list.Count; i++)
            {
                if (list[i] > max) max = list[i];
                else if (list[i] < min) min = list[i];
            }

            var maximumIndex = max - min + 1;
            var counters = new int[maximumIndex];

            for (var i = 0; i < list.Count; i++)
            {
                counters[list[i] - min]++;
            }

            if (order == SortOrder.Ascending)
            {
                var position = 0;

                for (var i = 0; i < maximumIndex; i++)
                {
                    for (var j = 0; j < counters[i]; j++)
                    {
                        list[position] = i + min;
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
                        list[position] = i + min;
                        position--;
                    }
                }
            }
        }

        #endregion
    }
}
