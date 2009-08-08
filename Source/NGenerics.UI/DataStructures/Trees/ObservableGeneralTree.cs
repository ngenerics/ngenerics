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
using NGenerics.DataStructures.Trees;
using System.Diagnostics.CodeAnalysis;


namespace NGenerics.UI.DataStructures.Trees
{
    /// <summary>
    /// Represents a dynamic data <see cref="GeneralTree{T}"/> that provides notifications when items get added, removed, or when the whole list is refreshed.
    /// </summary>
    /// <typeparam name="T">The type of elements in the <see cref="ObservableGeneralTree{T}"/>.</typeparam>
#if (!SILVERLIGHT)
    [Serializable]
#endif
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
    [SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    public partial class ObservableGeneralTree<T> : GeneralTree<T>
    {

        /// <inheritdoc />
        protected override void InsertItem(int index, GeneralTree<T> item)
        {
            CheckReentrancy();
			base.InsertItem(index, item);
			OnPropertyChanged("Count", "IsEmpty", "Item[]");
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, index));

        }
        /// <inheritdoc />
        protected override void RemoveItem(int index, GeneralTree<T> item)
        {
            CheckReentrancy();
			base.RemoveItem(index, item);
			OnPropertyChanged("Count", "IsEmpty", "Item[]");
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item, index));
        }

        /// <inheritdoc />
        protected override bool RemoveItem(T item)
        {
            CheckReentrancy();
            var removed = base.RemoveItem(item);
            if (removed)
			{
				OnPropertyChanged("Count", "IsEmpty", "Item[]");
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item, -1));
            }
            return removed;
        }

        /// <inheritdoc />
        public override void Clear()
        {
            CheckReentrancy();
			base.Clear();
			OnPropertyChanged("Count", "IsEmpty", "Item[]");
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}