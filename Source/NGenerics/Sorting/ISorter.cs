/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System.Collections.Generic;

namespace NGenerics.Sorting
{
    /// <summary>
    /// An interface for a Sorter.
	/// </summary>
    /// <typeparam name="T">The type of the elements to be sorted.</typeparam>
	public interface ISorter<T>
	{
        /// <summary>
        /// Sorts the specified list.
        /// </summary>
        /// <param name="list">The list to sort.</param>
		void Sort(IList<T> list);

        /// <summary>
        /// Sorts the specified list.
        /// </summary>
        /// <param name="list">The list to sort.</param>
        /// <param name="order">The order in which to sort the list.</param>
        void Sort(IList<T> list, SortOrder order);
	}
}
