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

namespace NGenerics.DataStructures.Queues
{
	/// <summary>
	/// A data structure much like a queue, except that you can enqueue and dequeue to both the head and the tail.
	/// </summary>
	/// <typeparam name="T">The type of the elements in the <see cref="Deque{T}"/>.</typeparam>
    [Serializable]
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
    [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
	public class Deque<T> : ICollection<T>, IDeque<T>
	{
		#region Globals

		private const string DequeIsEmpty = "The deque is empty.";
		private readonly LinkedList<T> _list;

		#endregion


		#region Construction

        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Queues\DequeExamples.cs" region="Constructor" lang="cs" title="The following example shows how to use the default constructor."/>
        /// </example>
		public Deque()
		{
			_list = new LinkedList<T>();
		}

        /// <param name="collection">A collection implementing the <see cref="IEnumerable{T}"/> interface.</param>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Queues\DequeExamples.cs" region="ConstructorCollection" lang="cs" title="The following example shows how to use the collection constructor."/>
        /// </example>
		public Deque(IEnumerable<T> collection)
		{
			_list = new LinkedList<T>(collection);
		}

		#endregion


		#region Public Members

		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Queues\DequeExamples.cs" region="EnqueueHead" lang="cs" title="The following example shows how to use the EnqueueHead method."/>
        /// </example>
		public void EnqueueHead(T item)
		{
			EnqueueHeadItem(item);
		}
		/// <summary>
		/// Enqueues the head.
		/// </summary>
		/// <param name="item">The item.</param>
		/// <remarks>
		/// <b>Notes to Inheritors: </b>
		///  Derived classes can override this method to change the behavior of the <see cref="EnqueueHead"/> method.
		/// </remarks>
		protected virtual void EnqueueHeadItem(T item)
		{
			_list.AddFirst(item);
		}

		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Queues\DequeExamples.cs" region="DequeueHead" lang="cs" title="The following example shows how to use the DequeueHead method."/>
        /// </example>
		public T DequeueHead()
        {
            #region Validation
                        
            if (_list.Count == 0)
            {
                throw new InvalidOperationException(DequeIsEmpty);
            }

		    #endregion

			return DequeueHeadItem();		
		}

		/// <summary>
		/// Dequeues the head.
		/// </summary>
		/// <remarks>
		/// <b>Notes to Inheritors: </b>
		/// Derived classes can override this method to change the behavior of the <see cref="DequeueHead"/> method.
		/// </remarks>
		/// <returns>The head of the deque.</returns>
		protected virtual T DequeueHeadItem()
        {

            var ret = _list.First.Value;
			_list.RemoveFirst();
			return ret;			
		}

		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Queues\DequeExamples.cs" region="EnqueueTail" lang="cs" title="The following example shows how to use the EnqueueTail method."/>
        /// </example>
		public void EnqueueTail(T item)
		{
			EnqueueTailItem(item);
		}	
		
		/// <summary>
		/// Enqueues the tail.
		/// </summary>
		/// <param name="item">The obj.</param>
		/// <remarks>
		/// <b>Notes to Inheritors: </b>
		///  Derived classes can override this method to change the behavior of the <see cref="EnqueueTail"/> method.
		/// </remarks>
		protected virtual void EnqueueTailItem(T item)
		{
			_list.AddLast(item);
		}

		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Queues\DequeExamples.cs" region="DequeueTail" lang="cs" title="The following example shows how to use the DequeueTail method."/>
        /// </example>
		public T DequeueTail()
        {
            #region Validation
            
            if (_list.Count == 0)
		    {
                throw new InvalidOperationException(DequeIsEmpty);
            }
                        
            #endregion

			return DequeueTailItem();			
		}

        /// <summary>
        /// Dequeues the tail item.
        /// </summary>
        /// <returns>The item that was dequeued.</returns>
        /// <remarks>
        /// 	<b>Notes to Inheritors: </b>
        /// Derived classes can override this method to change the behavior of the <see cref="DequeueTail"/> method.
        /// </remarks>
		protected virtual T DequeueTailItem()
        {

            var ret = _list.Last.Value;
			_list.RemoveLast();
			return ret;			
		}

		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Queues\DequeExamples.cs" region="Head" lang="cs" title="The following example shows how to use the Head property."/>
        /// </example>
		public T Head
		{
			get
            {
                #region Validation
                
                if (_list.Count == 0)
                {
                    throw new InvalidOperationException(DequeIsEmpty);
                }
                                
                #endregion
				
				return _list.First.Value;				
			}
		}

		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Queues\DequeExamples.cs" region="Tail" lang="cs" title="The following example shows how to use the Tail property."/>
        /// </example>
		public T Tail
		{
			get
            {
                #region Validation
                                
                if (_list.Count == 0)
			    {
                    throw new InvalidOperationException(DequeIsEmpty);
                }
                                
                #endregion

                return _list.Last.Value;				
			}
		}

		#endregion


		#region ICollection<T> Members

		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Queues\DequeExamples.cs" region="Contains" lang="cs" title="The following example shows how to use the Contains method."/>
        /// </example>
		public bool Contains(T item)
		{
			return _list.Contains(item);
		}

		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Queues\DequeExamples.cs" region="CopyTo" lang="cs" title="The following example shows how to use the CopyTo method."/>
        /// </example>
		public void CopyTo(T[] array, int arrayIndex)
		{
			_list.CopyTo(array, arrayIndex);
		}

		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Queues\DequeExamples.cs" region="Count" lang="cs" title="The following example shows how to use the Count property."/>
        /// </example>
		public int Count
		{
			get
			{
				return _list.Count;
			}
		}

		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Queues\DequeExamples.cs" region="Clear" lang="cs" title="The following example shows how to use the Clear method."/>
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
			_list.Clear();
		}

		/// <inheritdoc />
		/// <exception cref="NotSupportedException">Always.</exception>
        [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
		void ICollection<T>.Add(T item)
		{
			throw new NotSupportedException();
		}

		/// <inheritdoc />
        /// <exception cref="NotSupportedException">Always.</exception>
        [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
		bool ICollection<T>.Remove(T item)
		{
			throw new NotSupportedException();
		}

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        /// <example>
        /// 	<code source="..\..\NGenerics.Examples\DataStructures\Queues\DequeExamples.cs" region="GetEnumerator" lang="cs" title="The following example shows how to use the GetEnumerator method."/>
        /// </example>
		public IEnumerator<T> GetEnumerator()
		{
			return _list.GetEnumerator();
		}
        
		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Queues\DequeExamples.cs" region="IsEmpty" lang="cs" title="The following example shows how to use the IsEmpty property."/>
        /// </example>
		public bool IsEmpty => Count == 0;

		#endregion
     
   			
		#region ICollection<T> Members

		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Queues\DequeExamples.cs" region="IsReadOnly" lang="cs" title="The following example shows how to use the IsReadOnly property."/>
        /// </example>
        public bool IsReadOnly => false;

		#endregion


		#region IEnumerable Members

		/// <inheritdoc />
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		#endregion
	}
}
