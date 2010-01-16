/*  
  Copyright 2007-2010 The NGenerics Team
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
    public partial class ObservableHeap<T> : Heap<T> 
    {
        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <remarks>
        /// 	<b>Notes to Inheritors: </b>
        /// Derived classes can override this method to change the behavior of the Add method.
        /// </remarks>
        protected override void AddItem(T item)
        {
            CheckReentrancy();
            base.AddItem(item);
            OnPropertyChanged("Count", "Root","IsEmpty");
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item,-1));
        }


        /// <summary>
        /// Removes the root item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <remarks>
        /// 	<b>Notes to Inheritors: </b>
        /// Derived classes can override this method to change the behavior of the RemoveRoot method.
        /// </remarks>
        protected override void RemoveRootItem(T item)
        {
            CheckReentrancy();
            base.RemoveRootItem(item);
            OnPropertyChanged("Count", "Root", "IsEmpty");
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item, -1));
        }


        /// <inheritdoc />
        protected override void ClearItems()
        {
            CheckReentrancy();
            base.ClearItems();
            OnPropertyChanged("Count", "Root", "IsEmpty");
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        
    }
}