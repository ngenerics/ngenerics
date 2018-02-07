/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/


using System.Collections.Generic;
using NGenerics.Util;

namespace NGenerics.Sorting
{
    /// <summary>
    /// A sorter that implements the Bucket Sort algorithm.
    /// </summary>
    /// <example>
    /// <code source="..\..\NGenerics.Examples\Sorting\BucketSorterExamples.cs" region="Sort" lang="cs" title="The following example shows how to use the Sort method."/>
    /// <code source="..\..\NGenerics.Examples\Sorting\BucketSorterExamples.cs" region="SortWithSortOrder" lang="cs" title="The following example shows how to use the Sort method with a SortOrder."/>
    /// </example>
    public sealed class BucketSorter : Sorter<int>
    {
        #region ISorter<int> Members

        /// <inheritdoc />
        public override void Sort(IList<int> list, SortOrder order)
        {
            Guard.ArgumentNotNull(list, "list");

            if (list.Count <= 1)
                return;

			var max = list[0];
			var min = list[0];

            foreach (var item in list)
            {
                if (item > max) max = item;
                else if (item < min) min = item;
            }

            var maximumIndex = max - min + 1;
            var counters = new int[maximumIndex];

            foreach (var item in list)
            {
                counters[item - min]++;
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
