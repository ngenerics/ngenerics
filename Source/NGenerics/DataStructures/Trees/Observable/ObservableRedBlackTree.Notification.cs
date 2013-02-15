/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using NGenerics.Util;

namespace NGenerics.DataStructures.Trees.Observable
{
    /// <summary>
    /// An observable version of the <see cref="RedBlackTree{TKey, TValue}"/>
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    public partial class ObservableRedBlackTree<TKey, TValue> : INotifyCollectionChanged, INotifyPropertyChanged
    {
        #region Globals

        /// <inheritdoc />
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        private readonly SimpleMonitor monitor;

        /// <inheritdoc />
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Construction

        /// <inheritdoc />
        public ObservableRedBlackTree()
        {
            monitor = new SimpleMonitor();
        }

        /// <inheritdoc />
        public ObservableRedBlackTree(IComparer<TKey> comparer)
            : base(comparer)
        {
            monitor = new SimpleMonitor();
        }

        #endregion

        /// <summary>
        /// Raises the <see cref="CollectionChanged"/> event.
        /// </summary>
        /// <param name="e">A <see cref="System.Collections.Specialized.NotifyCollectionChangedAction"/> that contains the event data.</param>
        [SuppressMessage("Microsoft.Security", "CA2109:ReviewVisibleEventHandlers")]
        protected virtual void OnCollectionChanged( NotifyCollectionChangedEventArgs e)
        {
            if (CollectionChanged != null)
            {
                using (BlockReentrancy())
                {
                    CollectionChanged(this, e);
                }
            }
        }
        /// <summary>
        /// Called when the specified properties change.
        /// </summary>
        /// <param name="propertyNames">The property names.</param>
        protected virtual void OnPropertyChanged(params string[] propertyNames)
        {
            for (var i = 0; i < propertyNames.Length; i++)
            {
                OnPropertyChanged(new PropertyChangedEventArgs(propertyNames[i]));
            }
        }

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="e">A <see cref="PropertyChangedEventArgs"/> that contains the event data.</param>
        [SuppressMessage("Microsoft.Security", "CA2109:ReviewVisibleEventHandlers")]
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }


        /// <inheritdoc cref="System.Collections.ObjectModel.ObservableCollection{T}.BlockReentrancy"/>
        protected IDisposable BlockReentrancy()
        {
            monitor.Enter();
            return monitor;
        }


        /// <inheritdoc cref="System.Collections.ObjectModel.ObservableCollection{T}.CheckReentrancy"/>
        protected void CheckReentrancy()
        {
            if ((monitor.Busy && (CollectionChanged != null)) && (CollectionChanged.GetInvocationList().Length > 0))
            {
                throw new InvalidOperationException("re-entrancy not allowed.");
            }
        }

    }
}