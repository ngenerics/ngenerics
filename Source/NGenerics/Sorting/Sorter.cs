/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/

using System.Collections.Generic;

namespace NGenerics.Sorting
{
    /// <summary>
    /// The base class for all sorters.
    /// </summary>
    /// <typeparam name="T">The type of element to be sorted.</typeparam>
    public abstract class Sorter<T> : ISorter<T>
    {
        #region ISorter<T> Members
		/// <inheritdoc />
        public void Sort(IList<T> list)
        {
            Sort(list, SortOrder.Ascending);
        }
		/// <inheritdoc />
        public abstract void Sort(IList<T> list, SortOrder order);

        #endregion
    }
}
