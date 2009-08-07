/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/


using System;
using System.Collections.Generic;
using NGenerics.Util;

namespace NGenerics.Sorting
{    
    /// <summary>
    /// A sorter implementing Radix Sort.
    /// Adapted from Wikipedia : see http://en.wikipedia.org/wiki/Radix_sort.
    /// </summary>    
    /// <example>
    /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\Sorting\RadixSorterExamples.cs" region="Sort" lang="cs" title="The following example shows how to use the Sort method."/>
    /// <code source="..\..\Source\Examples\ExampleLibraryVB\Sorting\RadixSorterExamples.vb" region="Sort" lang="vbnet" title="The following example shows how to use the Sort method."/>
    /// </example>
    public sealed class RadixSorter : Sorter<int>
    {     
        #region Globals

        private const int intSize = 32;     // sizeof(int) * 8
        private const int r = 8;            
        private const int radix = 1 << r;
        private const int mask = 255;       // radix - 1
        private static readonly int passesNeeded = (int)Math.Ceiling(intSize / (double)r);

        #endregion

        #region Sorter Members

		/// <inheritdoc />
        public override void Sort(IList<int> list, SortOrder order)
        {
            #region Validation

            Guard.ArgumentNotNull(list, "list");

            #endregion

            var auxiliary = new int[list.Count];
            var currentShift = 0;

            var prefixes = new int[radix];

            // the algorithm: 
            for (var pass = 0; pass < passesNeeded; pass++)
            {
                var counts = new int[radix];              

                // Count the elements in the current group
                for (var i = 0; i < list.Count; i++)
                {
                    ++counts[(list[i] >> currentShift) & mask];
                }
                                
                // Calculate the prefixes
                prefixes[0] = 0;

                for (var i = 1; i < radix; i++)
                {
                    prefixes[i] = prefixes[i - 1] + counts[i - 1];
                }

                // Copy the items into the auxiliary array in sorted order
                for (var i = 0; i < list.Count; i++)
                {
                    auxiliary[prefixes[(list[i] >> currentShift) & mask]++] = list[i];
                }

                // Copy the sorted items over to the original array                
                for (var i = 0; i < auxiliary.Length; i++)
                {
                    list[i] = auxiliary[i];
                }                

                // Increment the shift to look at the next digit
                currentShift += r;
            }
                        
            if (order == SortOrder.Descending)
            {
                var tempList = new List<int>(list.Count);
                tempList.AddRange(list);

                var counter = 0;

                // Reverse copy the sorted items over to the original list
                for (var i = list.Count - 1; i >= 0; i--)
                {                    
                    list[i] = tempList[counter];
                    counter++;
                }
            }
        }

        #endregion
    } 
}
