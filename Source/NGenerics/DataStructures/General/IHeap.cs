/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/


using System;

namespace NGenerics.DataStructures.General
{
	/// <summary>
	/// An interface for the <see cref="Heap{T}"/> data structure.
	/// </summary>
	/// <typeparam name="T">The type of elements in the heap.</typeparam>
	public interface IHeap<T>
	{
		/// <summary>
		/// Adds the specified item.
		/// </summary>
		/// <param name="item">The item.</param>
		void Add(T item);

		/// <summary>
		/// Removes the root and returns it.
		/// </summary>
		/// <returns>The root of the <see cref="Heap{T}"/>.</returns>
		/// <exception cref="InvalidOperationException">The <see cref="Graph{T}"/> is empty.</exception>
		T RemoveRoot();

		/// <summary>
		/// Gets the root.
		/// </summary>
		/// <value>The root.</value>
		/// <exception cref="InvalidOperationException">The <see cref="Heap{T}"/> is empty.</exception>
		T Root { get; }
	}
}
