/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using System.Collections.Generic;


namespace NGenerics.Sorting
{
    /// <summary>
    /// An interface implemented that can be implemented by sortable collections.
	/// </summary>
	/// <typeparam name="T">The type of the elements to be sorted.</typeparam>
	public interface ISortable<T>
	{
        /// <summary>
        /// Sorts using the specified sorter.
        /// </summary>
		/// <param name="sorter">The sorter to use in the sorting process.</param>
		/// <exception cref="ArgumentNullException"><paramref name="sorter"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
		void Sort(ISorter<T> sorter);

        /// <summary>
        /// Sorts using the specified sorter.
        /// </summary>
        /// <param name="sorter">The sorter to use in the sorting process.</param>
		/// <param name="order">The order in which to sort.</param>
		/// <exception cref="ArgumentNullException"><paramref name="sorter"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        void Sort(ISorter<T> sorter, SortOrder order);

        /// <summary>
        /// Sorts using the specified sorter.
        /// </summary>
        /// <param name="sorter">The sorter to use in the sorting process.</param>
		/// <param name="comparison">The comparison.</param>
		/// <exception cref="ArgumentNullException"><paramref name="sorter"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
		/// <exception cref="ArgumentNullException"><paramref name="comparison"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        void Sort(IComparisonSorter<T> sorter, Comparison<T> comparison);

        /// <summary>
        /// Sorts using the specified sorter.
        /// </summary>
        /// <param name="sorter">The sorter to use in the sorting process.</param>
		/// <param name="comparer">The comparer.</param>
		/// <exception cref="ArgumentNullException"><paramref name="sorter"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
		/// <exception cref="ArgumentNullException"><paramref name="comparer"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        void Sort(IComparisonSorter<T> sorter, IComparer<T> comparer);
	}
}
