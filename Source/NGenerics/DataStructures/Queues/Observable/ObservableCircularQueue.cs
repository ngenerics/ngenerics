/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;

namespace NGenerics.DataStructures.Queues.Observable
{

#if (!SILVERLIGHT && !WINDOWSPHONE)
	[Serializable]
#endif
    [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix")]
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
    [SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    public partial class ObservableCircularQueue<T> : CircularQueue<T>
    {

        /// <summary>
        /// Enqueues the item.
        /// </summary>
        /// <param name="item">The item to enqueue.</param>
        /// <inheritdoc/>
        protected override void EnqueueItem(T item)
        {
            CheckReentrancy();
            base.EnqueueItem(item);
            OnPropertyChanged("Count", "IsEmpty");
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, -1));
        }

        /// <summary>
        /// Dequeues the item.
        /// </summary>
        /// <returns>The item at the front of the queue.</returns>
        /// <remarks>
        /// 	<b>Notes to Inheritors: </b>
        /// Derived classes can override this method to change the behavior of the Dequeue method.
        /// </remarks>
        protected override T DequeueItem()
        {
            CheckReentrancy();
            var item = base.DequeueItem();
            OnPropertyChanged("Count", "IsEmpty");
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item, -1));
            return item;
        }


        /// <inheritdoc />
        protected override void ClearItems()
        {
            CheckReentrancy();
            base.ClearItems();
            OnPropertyChanged("Count", "IsEmpty");
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        /// <summary>
        /// Removes the item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        /// An indication of whether the item was found, and removed.
        /// </returns>
        /// <remarks>
        /// 	<b>Notes to Inheritors: </b>
        /// Derived classes can override this method to change the behavior of the Remove method.
        /// </remarks>
        protected override bool RemoveItem(T item)
        {
            CheckReentrancy();
            var removed = base.RemoveItem(item);
            if (removed)
            {
                OnPropertyChanged("Count", "IsEmpty");
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item, -1));
            }
            return removed;
        }
    }
}