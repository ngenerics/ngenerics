/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/



using System;using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;

namespace NGenerics.DataStructures.Trees.Observable
{

#if (!SILVERLIGHT && !WINDOWSPHONE)
	[Serializable]
#endif
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
    [SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    public partial class ObservableBinarySearchTree<TKey, TValue> : BinarySearchTree<TKey, TValue>
    {



        /// <inheritdoc />
        protected override void AddItem(KeyValuePair<TKey, TValue> item)
        {
            CheckReentrancy();
            base.AddItem(item);
            OnPropertyChanged("Count", "IsEmpty", "Item[]");
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, -1));
        }

        /// <inheritdoc />
        protected override bool RemoveItem(KeyValuePair<TKey, TValue> item)
        {
            CheckReentrancy();
            var value = base[item.Key];
            var removed = base.RemoveItem(item);
            if (removed)
            {
                OnPropertyChanged("Count", "IsEmpty", "Item[]");
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, value, -1));
            }
            return removed;
        }


        /// <inheritdoc />
        protected override void ClearItems()
        {
            CheckReentrancy();
            base.ClearItems();
            OnPropertyChanged("Count", "IsEmpty", "Item[]");
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

    }
}