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

namespace NGenerics.DataStructures.General.Observable
{
    /// <summary>
    /// An observable version of the <see cref="Heap{T}"/> data structure.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class ObservableHeap<T> : INotifyCollectionChanged, INotifyPropertyChanged
    {
        #region Globals


        /// <inheritdoc />
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        private readonly SimpleMonitor monitor;



        /// <inheritdoc />
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Construction


        /// <summary>
        /// Initializes a new instance of the <see cref="ObservableHeap&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="type">The type of Heap to create.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="type"/> is not either <see cref="HeapType.Maximum"/> or <see cref="HeapType.Minimum"/> .</exception>
        /// <example>
        /// 	<code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\HeapExamples.cs" region="Constructor" lang="cs" title="The following example shows how to use the default constructor."/>
        /// 	<code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\HeapExamples.vb" region="Constructor" lang="vbnet" title="The following example shows how to use the default constructor."/>
        /// </example>
        public ObservableHeap(HeapType type)
            : base(type)
        {
            monitor = new SimpleMonitor();
        }


        /// <inheritdoc />
        public ObservableHeap(HeapType type, int capacity)
            : base(type, capacity)
        {
            monitor = new SimpleMonitor();
        }


        /// <inheritdoc />
        public ObservableHeap(HeapType type, IComparer<T> comparer)
            : base(type, comparer)
        {
            monitor = new SimpleMonitor();
        }


        /// <inheritdoc />
        public ObservableHeap(HeapType type, int capacity, IComparer<T> comparer)
            : base(type, capacity, comparer)
        {

            monitor = new SimpleMonitor();
        }

        #endregion

        /// <summary>
        /// Raises the <see cref="CollectionChanged"/> event.
        /// </summary>
        /// <param name="e">A <see cref="NotifyCollectionChangedAction"/> that contains the event data.</param>
        [SuppressMessage("Microsoft.Security", "CA2109:ReviewVisibleEventHandlers")]
        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
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


        /// <inheritdoc cref="ObservableCollection{T}.BlockReentrancy"/>
        protected IDisposable BlockReentrancy()
        {
            monitor.Enter();
            return monitor;
        }


        /// <inheritdoc cref="ObservableCollection{T}.CheckReentrancy"/>
        protected void CheckReentrancy()
        {
            if ((monitor.Busy && (CollectionChanged != null)) && (CollectionChanged.GetInvocationList().Length > 0))
            {
                throw new InvalidOperationException("re-entrancy not allowed.");
            }
        }

    }
}