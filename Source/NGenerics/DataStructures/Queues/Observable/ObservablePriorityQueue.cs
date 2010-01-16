/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;

namespace NGenerics.DataStructures.Queues.Observable {

#if (!SILVERLIGHT)
    [Serializable]
#endif
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
    [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix")]
    [SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    public partial class ObservablePriorityQueue<TValue, TPriority> : PriorityQueue<TValue, TPriority> where TPriority : IComparable<TPriority>
    {
        /// <summary>
        /// Adds the item to the queue.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <param name="priority">The priority of the item.</param>
        /// <remarks>
        /// 	<b>Notes to Inheritors: </b>
        /// Derived classes can override this method to change the behavior of the Add(T,int) method.
        /// </remarks>
        protected override void AddItem(TValue item, TPriority priority)
        {
            CheckReentrancy();
            base.AddItem(item, priority);
            OnPropertyChanged("Count", "IsEmpty");
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, -1));
        }


        /// <inheritdoc />
        protected override bool RemoveItem(TValue item, out TPriority priority)
        {
            CheckReentrancy();
            var removed = base.RemoveItem(item, out priority);
            if (removed)
            {
                OnPropertyChanged("Count", "IsEmpty");
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item, -1));
            }
            return removed;
        }


        /// <inheritdoc />
        protected override bool RemoveItems(TPriority priority)
        {
            CheckReentrancy();
            var priorityGroup = GetPriorityGroup(priority);
            var removed = base.RemoveItems(priority);
            if (removed)
            {
                OnPropertyChanged("Count", "IsEmpty");
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, priorityGroup, -1));
            }
            return removed;
        }

        /// <summary>
        /// Dequeues the item at the front of the queue.
        /// </summary>
        /// <param name="priority"></param>
        /// <returns>The item at the front of the queue.</returns>
        /// <remarks>
        /// 	<b>Notes to Inheritors: </b>
        /// Derived classes can override this method to change the behavior of the Dequeue() or Dequeue(out int) methods.
        /// </remarks>
        protected override TValue DequeueItem(out TPriority priority)
        {
            CheckReentrancy();
            var item = base.DequeueItem(out priority);
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
        /// Adds the specified items to the priority queue with the specified priority.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <param name="priority">The priority.</param>
        protected override void AddPriorityGroupItem(IList<TValue> items, TPriority priority)
        {
            CheckReentrancy();
            base.AddPriorityGroupItem(items, priority);
            OnPropertyChanged("Count", "IsEmpty");
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, items, -1));
        }

    }
}