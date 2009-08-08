/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;

namespace NGenerics.DataStructures.Queues
{
	/// <summary>
	/// An interface for a deque
	/// </summary>
	/// <typeparam name="T">The type of the elements in the deque.</typeparam>
	public interface IDeque<T>
	{
		/// <summary>
		/// Dequeues the head.
		/// </summary>
		/// <returns>The head of the deque.</returns>
		/// <exception cref="InvalidOperationException">The <see cref="IDeque{T}"/> is empty.</exception>
		T DequeueHead();

		/// <summary>
		/// Dequeues the tail.
		/// </summary>
		/// <returns>The tail of the deque.</returns>
		/// <exception cref="InvalidOperationException">The <see cref="IDeque{T}"/> is empty.</exception>
		T DequeueTail();

		/// <summary>
		/// Enqueues the head.
		/// </summary>
		/// <param name="item">The item.</param>
		void EnqueueHead(T item);

		/// <summary>
		/// Enqueues the tail.
		/// </summary>
		/// <param name="item">The item.</param>
		void EnqueueTail(T item);

		/// <summary>
		/// Gets the head.
		/// </summary>
		/// <value>The head.</value>
		/// <exception cref="InvalidOperationException">The <see cref="IDeque{T}"/> is empty.</exception>
		T Head { get; }

		/// <summary>
		/// Gets the tail.
		/// </summary>
		/// <value>The tail.</value>
		/// <exception cref="InvalidOperationException">The <see cref="IDeque{T}"/> is empty.</exception>
		T Tail { get; }
	}
}
