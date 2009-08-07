/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/

#if (!SILVERLIGHT)
using System;
#endif
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using NGenerics.DataStructures.General;

namespace NGenerics.UI.DataStructures.General
{
    /// <summary>
    /// Represents a dynamic data <see cref="HashList{TKey,TValue}"/> that provides notifications when items get added, removed, or when the whole list is refreshed.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>

#if (!SILVERLIGHT)
    [Serializable]
#endif
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
    [SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    [SuppressMessage("Microsoft.Usage", "CA2240:ImplementISerializableCorrectly")]
	public partial class ObservableHashList<TKey, TValue> : HashList<TKey, TValue>
	{
		/// <inheritdoc />
		protected override void AddItem(TKey key, IList<TValue> value)
		{

			CheckReentrancy();
            base.AddItem(key, value);
            OnPropertyChanged("Count", "KeyCount", "ValueCount", "IsEmpty","Item[]");
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, new KeyValuePair<TKey, IList<TValue>>(key, value),-1));
		}

		/// <inheritdoc />
		public override void AddItem(KeyValuePair<TKey, TValue> item)
		{
			CheckReentrancy();
			base.AddItem(item);
			OnPropertyChanged("Count", "KeyCount", "ValueCount", "IsEmpty", "Item[]");
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item,-1));
		}	
		
		/// <inheritdoc />
		protected override bool RemoveItem(TKey key)
		{

			CheckReentrancy();
			IList<TValue> value;
			if (TryGetValue(key, out value))
			{
				base.RemoveItem(key);
				OnPropertyChanged("Count", "KeyCount", "ValueCount", "IsEmpty", "Item[]");
				OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, new KeyValuePair<TKey, IList<TValue>>(key, value),-1));
				return true;
			}
			return false;
		}

		/// <inheritdoc />
		protected override void ClearItems()
		{
			CheckReentrancy();
			base.ClearItems();
			OnPropertyChanged("Count", "KeyCount", "ValueCount", "IsEmpty", "Item[]");
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}

        /// <summary>
        /// Removes the first instance found of the value specified from the HashList.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        /// A value indicating whether or not an item matching the criteria was found and removed.
        /// </returns>
        protected override bool RemoveValueItem(TValue item)
        {
            CheckReentrancy();
            var removed = base.RemoveValueItem(item);
            if (removed)
			{
				OnPropertyChanged("Count", "KeyCount", "ValueCount", "IsEmpty", "Item[]");
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item,-1));
            }
            return removed;
        }

        /// <summary>
        /// Removes the item from this instance.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="item">The item to remove.</param>
        /// <returns>An indication of whether the item was found, and removed.</returns>
        protected override bool RemoveItem(TKey key, TValue item)
        {
            CheckReentrancy();
            var removed = base.RemoveItem(key, item);
            if (removed)
			{
				OnPropertyChanged("Count", "KeyCount", "ValueCount", "IsEmpty", "Item[]");
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item,-1));
            }
            return removed;
        }

        /// <summary>
        /// Removes all the specified values from the HashList.
        /// </summary>
        /// <param name="item">The item.</param>
		protected override void RemoveAllItems(TValue item)
        {
            CheckReentrancy();
			base.RemoveAllItems(item);
			OnPropertyChanged("Count", "KeyCount", "ValueCount", "IsEmpty", "Item[]");
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item,-1));
		}
	}
}