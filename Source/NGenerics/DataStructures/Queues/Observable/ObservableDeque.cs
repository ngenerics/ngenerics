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

namespace NGenerics.DataStructures.Queues.Observable {

#if (!SILVERLIGHT)
    [Serializable]
#endif
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
    [SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    public partial class ObservableDeque<T> : Deque<T>
    {

        /// <inheritdoc />
        protected override T DequeueHeadItem()
        {
            CheckReentrancy();
            var item = base.DequeueHeadItem();
            OnPropertyChanged("Count", "IsEmpty","Head", "Tail");
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item, -1));
            return item;
        }


        /// <summary>
        /// Dequeues the tail item.
        /// </summary>
        /// <returns>The item that was dequeued.</returns>
        /// <remarks>
        /// 	<b>Notes to Inheritors: </b>
        /// Derived classes can override this method to change the behavior of the DequeueTail method.
        /// </remarks>
        protected override T DequeueTailItem()
        {
            CheckReentrancy();
            var item = base.DequeueHeadItem();
            OnPropertyChanged("Count", "IsEmpty", "Head", "Tail");
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item, -1));
            return item;
        }


        /// <inheritdoc />
        protected override void EnqueueTailItem(T item)
        {
            CheckReentrancy();
            base.EnqueueHeadItem(item);
            OnPropertyChanged("Count", "IsEmpty", "Head", "Tail");
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, -1));
        }


        /// <inheritdoc />
        protected override void EnqueueHeadItem(T item)
        {
            CheckReentrancy();
            base.EnqueueHeadItem(item);
            OnPropertyChanged("Count", "IsEmpty", "Head", "Tail");
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, -1));
        }


        /// <inheritdoc />
        protected override void ClearItems()
        {
            CheckReentrancy();
            base.ClearItems();
            OnPropertyChanged("Count", "IsEmpty", "Head", "Tail");
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

    }
}