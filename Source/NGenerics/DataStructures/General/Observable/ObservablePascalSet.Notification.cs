/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using NGenerics.Util;

namespace NGenerics.DataStructures.General.Observable
{
    /// <summary>
    /// An observable version of the <see cref="PascalSet"/>.
    /// </summary>
    public partial class ObservablePascalSet : INotifyCollectionChanged, INotifyPropertyChanged
    {
        #region Globals

        /// <inheritdoc />
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        private readonly SimpleMonitor monitor;



        /// <inheritdoc />
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Public Constructors


        /// <inheritdoc />
        public ObservablePascalSet(int upperBound)
            : base(upperBound)
        {
            monitor = new SimpleMonitor();
        }

	
        /// <inheritdoc />
        public ObservablePascalSet(int upperBound, int[] initialValues)
            : base(upperBound)
        {
            monitor = new SimpleMonitor();
            for (var i = 0; i < initialValues.Length; i++)
            {
                Add(initialValues[i]);
            }
        }


        /// <inheritdoc />
        public ObservablePascalSet(int lowerBound, int upperBound, int[] initialValues)
            : base(lowerBound, upperBound)
        {
            monitor = new SimpleMonitor(); 
            for (var i = 0; i < initialValues.Length; i++)
            {
                Add(initialValues[i]);
            }
        }


        /// <inheritdoc />
        public ObservablePascalSet(int lowerBound, int upperBound)
            : base(lowerBound, upperBound)
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