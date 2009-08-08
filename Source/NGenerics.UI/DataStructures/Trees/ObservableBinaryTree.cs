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
    /// Represents a dynamic data <see cref="BinaryTree{T}"/> that provides notifications when items get added, removed, or when the whole list is refreshed.
    /// </summary>
    /// <typeparam name="T">The type of elements in the <see cref="ObservableBinaryTree{T}"/>.</typeparam>
#if (!SILVERLIGHT)
    [Serializable]
#endif
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
    [SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
	public partial class ObservableBinaryTree<T> : BinaryTree<T>
	{
		/// <inheritdoc />
		public override void RemoveLeft()
		{
			CheckReentrancy();
			var left = Left;
			base.RemoveLeft();
			OnPropertyChanged("Count", "IsEmpty", "Item[]");
			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, left, -1));
		}
		/// <inheritdoc />
		public override void RemoveRight()
		{
			CheckReentrancy();
			var right = Right;
			base.RemoveLeft();
			OnPropertyChanged("Count", "IsEmpty", "Item[]");
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, right, -1));
		}
		/// <inheritdoc />
		protected override void AddItem(BinaryTree<T> subtree)
		{
			CheckReentrancy();
			base.AddItem(subtree);

			OnPropertyChanged("Count", "IsEmpty", "Item[]");
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, subtree, -1));
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