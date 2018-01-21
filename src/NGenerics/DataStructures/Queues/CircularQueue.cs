/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/



using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using NGenerics.Util;

namespace NGenerics.DataStructures.Queues
{
    /// <summary>
    /// An implementation of a Circular Queue.
	/// </summary>
	/// <typeparam name="T">The type of the elements in the <see cref="CircularQueue{T}"/>.</typeparam>
    [Serializable]
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
    [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix")]
    [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
    public class CircularQueue<T> : ICollection<T>, IQueue<T>
    {
        #region Globals

        const string queueIsEmpty = "The Queue is empty.";
        private readonly LinkedList<T> data = new LinkedList<T>();
        private readonly int capacity;

        #endregion

        #region Construction

        /// <param name="capacity">The initial capacity of the list.</param>
        /// <exception cref="ArgumentException"><paramref name="capacity"/> is less than 1.</exception>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Queues\CircularQueueExamples.cs" region="Constructor" lang="cs" title="The following example shows how to use the default constructor."/>
        /// </example>
        public CircularQueue(int capacity)
        {
            #region Validation

            if (capacity < 1)
            {
                throw new ArgumentException("Capacity can not be less than 1.", "capacity");
            }

            this.capacity = capacity;

            #endregion
        }

        #endregion
        
        #region IQueue<T> Members

		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Queues\CircularQueueExamples.cs" region="Enqueue" lang="cs" title="The following example shows how to use the Enqueue method."/>
        /// </example>
        public void Enqueue(T item)
        {
			EnqueueItem(item);
        }


        /// <summary>
        /// Enqueues the item.
        /// </summary>
        /// <param name="item">The item to enqueue.</param>
        /// <remarks>
        /// 	<b>Notes to Inheritors: </b>
        /// Derived classes can override this method to change the behavior of the <see cref="Enqueue"/> method.
        /// </remarks>
		protected virtual void  EnqueueItem(T item)
		{
            if (data.Count == capacity)
            {
                data.RemoveFirst();
            }

            data.AddLast(item);
		}

        /// <summary>
        /// Dequeues the item at the front of the queue.
        /// </summary>
        /// <returns>The item at the front of the queue.</returns>
        /// <example>
        /// 	<code source="..\..\NGenerics.Examples\DataStructures\Queues\CircularQueueExamples.cs" region="Dequeue" lang="cs" title="The following example shows how to use the Dequeue method."/>
        /// </example>
        public T Dequeue()
		{
		    if (IsEmpty)
		    {
		        throw new InvalidOperationException(queueIsEmpty);
		    }

            return DequeueItem();
		}

        /// <summary>
        /// Dequeues the item.
        /// </summary>
        /// <returns>The item at the front of the queue.</returns>
        /// <remarks>
        /// 	<b>Notes to Inheritors: </b>
        /// Derived classes can override this method to change the behavior of the <see cref="Dequeue"/> method.
        /// </remarks>
		protected virtual T DequeueItem()
		{

			var value = data.First.Value;
			data.RemoveFirst();
			return value;
		}

        /// <summary>
        /// Peeks at the item in the front of the queue, without removing it.
        /// </summary>
        /// <returns>The item at the front of the queue.</returns>
        /// <example>
        /// 	<code source="..\..\NGenerics.Examples\DataStructures\Queues\CircularQueueExamples.cs" region="Peek" lang="cs" title="The following example shows how to use the Peek method."/>
        /// </example>
        public T Peek()
		{
		    if (IsEmpty)
            {
                throw new InvalidOperationException(queueIsEmpty);
            }
		    
            return data.First.Value;
		}

        #endregion

        #region ICollection<T> Members

	
		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Queues\CircularQueueExamples.cs" region="IsEmpty" lang="cs" title="The following example shows how to use the IsEmpty property."/>
        /// </example>
        public bool IsEmpty
        {
            get
            {
                return data.Count == 0;
            }
        }

		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Queues\CircularQueueExamples.cs" region="IsFull" lang="cs" title="The following example shows how to use the IsFull property."/>
        /// </example>
        public bool IsFull
        {
            get
            {
                return data.Count == capacity;
            }
        }

        #endregion

        #region ICollection<T> Members

		/// <inheritdoc />
        [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void ICollection<T>.Add(T item)
        {
            Enqueue(item);
        }

		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Queues\CircularQueueExamples.cs" region="Clear" lang="cs" title="The following example shows how to use the Clear property."/>
        /// </example>
        public void Clear()
        {
           ClearItems();
        }

		/// <summary>
		/// Clears all the objects in this instance.
		/// </summary>
		/// <remarks>
		/// <b>Notes to Inheritors: </b>
		///  Derived classes can override this method to change the behavior of the <see cref="Clear"/> method.
		/// </remarks>
        protected virtual void ClearItems()
        {
            data.Clear();
        }

		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Queues\CircularQueueExamples.cs" region="Contains" lang="cs" title="The following example shows how to use the Contains method."/>
        /// </example>
        public bool Contains(T item)
        {
            return !IsEmpty && data.Contains(item);
        }

		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Queues\CircularQueueExamples.cs" region="CopyTo" lang="cs" title="The following example shows how to use the CopyTo method."/>
        /// </example>
        public void CopyTo(T[] array, int arrayIndex)
        {
            Guard.ArgumentNotNull(array, "array");

            if (IsEmpty)
            {
                return;
            }
		    
            data.CopyTo(array, arrayIndex);
        }

		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Queues\CircularQueueExamples.cs" region="Count" lang="cs" title="The following example shows how to use the Count property."/>
        /// </example>
        public int Count
        {
            get
            {
                return data.Count;
            }
        }

		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Queues\CircularQueueExamples.cs" region="IsReadOnly" lang="cs" title="The following example shows how to use the IsReadOnly property."/>
        /// </example>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Queues\CircularQueueExamples.cs" region="Remove" lang="cs" title="The following example shows how to use the Remove method."/>
        /// </example>
        public bool Remove(T item)
        {
            return RemoveItem(item);
        }

        /// <summary>
        /// Removes the item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>An indication of whether the item was found, and removed.</returns>
        /// <remarks>
        /// 	<b>Notes to Inheritors: </b>
        /// Derived classes can override this method to change the behavior of the <see cref="Remove"/> method.
        /// </remarks>
        protected virtual bool RemoveItem(T item)
        {
            return data.Remove(item);
        }

        #endregion

        #region IEnumerable<T> Members

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        /// <example>
        /// 	<code source="..\..\NGenerics.Examples\DataStructures\Queues\CircularQueueExamples.cs" region="GetEnumerator" lang="cs" title="The following example shows how to use the GetEnumerator method."/>
        /// </example>
        public IEnumerator<T> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

		/// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion


        #region Public Members

        /// <summary>
        /// Gets the capacity.
        /// </summary>
        /// <value>The capacity.</value>
        /// <example>
        /// 	<code source="..\..\NGenerics.Examples\DataStructures\Queues\CircularQueueExamples.cs" region="Capacity" lang="cs" title="The following example shows how to use the Capacity property."/>
        /// </example>
        public int Capacity
        {
            get
            {
                return capacity;
            }
        }

        #endregion
    }
}
