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
using NGenerics.DataStructures.Trees;

namespace NGenerics.UI.DataStructures.Trees
{
    /// <summary>
    /// Represents a dynamic data <see cref="RedBlackTree{TKey,TValue}"/> that provides notifications when items get added, removed, or when the whole list is refreshed.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the <see cref="ObservableRedBlackTree{TKey,TValue}"/>.</typeparam>
    /// <typeparam name="TValue">The type of the values in the <see cref="ObservableRedBlackTree{TKey,TValue}"/>.</typeparam>
#if (!SILVERLIGHT)
    [Serializable]
#endif
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
    [SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
	public partial class ObservableRedBlackTree<TKey, TValue> : RedBlackTree<TKey, TValue>
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
			TValue value;
			var removeItem = false;
			if (TryGetValue(item.Key, out value))
			{
				removeItem = base.RemoveItem(item);
				OnPropertyChanged("Count", "IsEmpty", "Item[]");
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item, -1));
			}
			return removeItem;
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
