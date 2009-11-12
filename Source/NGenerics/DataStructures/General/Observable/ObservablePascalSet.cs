/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

#if (!SILVERLIGHT)
using System;
#endif
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;

namespace NGenerics.DataStructures.General.Observable {

#if (!SILVERLIGHT)
    [Serializable]
#endif
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
    [SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    public partial class ObservablePascalSet : PascalSet
    {
        /// <summary>
        /// Adds the item to the set.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <param name="offset">The offset in which to add the item.</param>
        /// <remarks>
        /// 	<b>Notes to Inheritors: </b>
        /// Derived classes can override this method to change the behavior of the Add method.
        /// </remarks>
        protected override void AddItem(int item, int offset)
        {
            CheckReentrancy();
            base.AddItem(item, offset);
            OnPropertyChanged("Count", "LowerBound", "UpperBound", "Capacity", "IsFull","Item[]");
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item,-1));
        }


        /// <inheritdoc />
        protected override void ClearItems()
        {
            CheckReentrancy();
            base.ClearItems();
            OnPropertyChanged("Count", "LowerBound", "UpperBound", "Capacity", "IsFull", "Item[]");
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }


        /// <summary>
        /// Removes the item from the set.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        /// <param name="offset">The offset at which to remove the item.</param>
        /// <remarks>
        /// 	<b>Notes to Inheritors: </b>
        /// Derived classes can override this method to change the behavior of the Remove method.
        /// </remarks>
        protected override void RemoveItem(int item, int offset)
        {
            CheckReentrancy();
            base.RemoveItem(item, offset);
            OnPropertyChanged("Count", "LowerBound", "UpperBound", "Capacity", "IsFull", "Item[]");
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item,-1));
        }
    }
}