/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using NGenerics.Comparers;
using NGenerics.Util;

namespace NGenerics.Sorting
{
    /// <summary>
    /// The base class used for all comparison based Sorters in the library.
    /// </summary>
    /// <typeparam name="T">The type of the elements to be sorted.</typeparam>
    /// <example>
    /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\Sorting\SorterExamples.cs" region="SortList" lang="cs" title="The following example shows how to use the Sort method."/>
    /// <code source="..\..\Source\Examples\ExampleLibraryVB\Sorting\SorterExamples.vb" region="SortList" lang="vbnet" title="The following example shows how to use the Sort method."/>
    /// </example>
    public abstract class ComparisonSorter<T> : Sorter<T>, IComparisonSorter<T>
    {
        #region ISorter<T> Members

		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\Sorting\SorterExamples.cs" region="SortListComparer" lang="cs" title="The following example shows how to use the Sort method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\Sorting\SorterExamples.vb" region="SortListComparer" lang="vbnet" title="The following example shows how to use the Sort method."/>
        /// </example>
        public void Sort(IList<T> list, IComparer<T> comparer)
        {
            #region Validation

            Guard.ArgumentNotNull(list, "list");
            Guard.ArgumentNotNull(comparer, "comparer");

            #endregion

            if (list.Count <= 1)
            {
                return;
            }

            SortItems(list, comparer);
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\Sorting\SorterExamples.cs" region="SortListDelegate" lang="cs" title="The following example shows how to use the Sort method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\Sorting\SorterExamples.vb" region="SortListDelegate" lang="vbnet" title="The following example shows how to use the Sort method."/>
        /// </example>
        public void Sort(IList<T> list, Comparison<T> comparison)
        {
            #region Validation

            Guard.ArgumentNotNull(list, "list");
            Guard.ArgumentNotNull(comparison, "comparison");

            #endregion

            Sort(list, new ComparisonComparer<T>(comparison));
        }

        /// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\Sorting\SorterExamples.cs" region="SortListDelegate" lang="cs" title="The following example shows how to use the Sort method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\Sorting\SorterExamples.vb" region="SortListDelegate" lang="vbnet" title="The following example shows how to use the Sort method."/>
        /// </example>
        public void Sort(IList<T> list, Comparison<T> comparison, SortOrder sortOrder)
        {
            #region Validation

            Guard.ArgumentNotNull(list, "list");
            Guard.ArgumentNotNull(comparison, "comparison");

            #endregion

            Sort(list, new ReverseComparisonComparer<T>(comparison));
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\Sorting\SorterExamples.cs" region="SortListOrder" lang="cs" title="The following example shows how to use the Sort method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\Sorting\SorterExamples.vb" region="SortListOrder" lang="vbnet" title="The following example shows how to use the Sort method."/>
        /// </example>
        public override void Sort(IList<T> list, SortOrder order)
        {
            #region Validation

            Guard.ArgumentNotNull(list, "list");


            if ((order != SortOrder.Ascending) && (order != SortOrder.Descending))
            {
                throw new ArgumentOutOfRangeException("order");
            }

            #endregion

            if (order == SortOrder.Ascending)
            {
                Sort(list, Comparer<T>.Default);
            }
            else if (order == SortOrder.Descending)
            {
                Sort(list, new ReverseComparer<T>(Comparer<T>.Default));
            }
        }

        #endregion

        #region Protected Members

        /// <summary>
        /// Sorts the specified list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="comparer">The comparer to use in comparing items.</param>
        protected abstract void SortItems(IList<T> list, IComparer<T> comparer);

        /// <summary>
        /// Swaps items in the specified list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="pos1">The position of the first item.</param>
        /// <param name="pos2">The position of the last item.</param>
        [SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        protected static void Swap(IList<T> list, int pos1, int pos2)
        {
            Swapper.Swap(list, pos1, pos2);
        }

        #endregion
    }
}