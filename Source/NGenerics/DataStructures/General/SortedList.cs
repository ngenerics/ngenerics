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

namespace NGenerics.DataStructures.General
{
	/// <summary>
	/// An implementation of a SortedList data structure, which keeps any objects
	/// added to it sorted.
	/// </summary>
	/// <typeparam name="T">The type of elements in the sorted list.</typeparam>
#if (!SILVERLIGHT && !WINDOWSPHONE)
	[Serializable]
#endif
	[SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
	[SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
	public class SortedList<T> : IList<T>, IList
	{
		#region Globals

		private readonly List<T> data;
		private readonly IComparer<T> comparerToUse;

		#endregion

		#region Construction


		/// <example>
		/// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SortedListExamples.cs" region="Constructor" lang="cs" title="The following example shows how to use the default constructor."/>
		/// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SortedListExamples.vb" region="Constructor" lang="vbnet" title="The following example shows how to use the default constructor."/>
		/// </example>
		public SortedList()
		{
			data = new List<T>();
			comparerToUse = Comparer<T>.Default;
		}


		/// <param name="comparer">The comparer to use.</param>
		/// <example>
		/// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SortedListExamples.cs" region="ConstructorComparer" lang="cs" title="The following example shows how to use the Comparer constructor."/>
		/// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SortedListExamples.vb" region="ConstructorComparer" lang="vbnet" title="The following example shows how to use the Comparer constructor."/>
		/// </example>
		public SortedList(IComparer<T> comparer)
		{
			data = new List<T>();
			comparerToUse = comparer;
		}

		/// <param name="capacity">The initial capacity of the sorted list.</param>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="capacity"/> is less than 0.</exception>.
		/// <example>
		/// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SortedListExamples.cs" region="ConstructorCapacity" lang="cs" title="The following example shows how to use the constructor with an initial capacity."/>
		/// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SortedListExamples.vb" region="ConstructorCapacity" lang="vbnet" title="The following example shows how to use the constructor with an initial capacity."/>
		/// </example>
		public SortedList(int capacity)
		{
			data = new List<T>(capacity);
			comparerToUse = Comparer<T>.Default;
		}

		/// <param name="capacity">The initial capacity of the sorted list.</param>
		/// <param name="comparer">The comparer to use.</param>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="capacity"/> is less than 0.</exception>.
		public SortedList(int capacity, IComparer<T> comparer)
		{
			data = new List<T>(capacity);
			comparerToUse = comparer;
		}


		/// <param name="collection">The collection to copy into the sorted list.</param>
		/// <example>
		/// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SortedListExamples.cs" region="ConstructorCollection" lang="cs" title="The following example shows how to use the collections constructor."/>
		/// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SortedListExamples.vb" region="ConstructorCollection" lang="vbnet" title="The following example shows how to use the collections constructor."/>
		/// </example>
		public SortedList(IEnumerable<T> collection)
		{
			data = new List<T>();
			comparerToUse = Comparer<T>.Default;

			foreach (var item in collection)
			{
				Add(item);
			}

		}

		#endregion

		#region Public Members

		void IList.Remove(object value)
		{
			Remove((T)value);
		}

		/// <inheritdoc />  
		/// <example>
		/// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SortedListExamples.cs" region="RemoveAt" lang="cs" title="The following example shows how to use the RemoveAt method."/>
		/// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SortedListExamples.vb" region="RemoveAt" lang="vbnet" title="The following example shows how to use the RemoveAt method."/>
		/// </example>
		public virtual void RemoveAt(int index)
		{
			data.RemoveAt(index);
		}

		object IList.this[int index]
		{
			get { return this[index]; }
			set { throw new NotSupportedException(); }
		}

		/// <summary>
		/// Gets the comparer.
		/// </summary>
		/// <value>The comparer.</value>
		public IComparer<T> Comparer
		{
			get
			{
				return comparerToUse;
			}
		}

		#endregion

		#region ICollection<T> Members


		/// <inheritdoc />  
		/// <example>
		/// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SortedListExamples.cs" region="IsEmpty" lang="cs" title="The following example shows how to use the IsEmpty property."/>
		/// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SortedListExamples.vb" region="IsEmpty" lang="vbnet" title="The following example shows how to use the IsEmpty property."/>
		/// </example>
		public bool IsEmpty
		{
			get
			{
				return Count == 0;
			}
		}


		/// <inheritdoc />  
		/// <example>
		/// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SortedListExamples.cs" region="CopyTo" lang="cs" title="The following example shows how to use the CopyTo method."/>
		/// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SortedListExamples.vb" region="CopyTo" lang="vbnet" title="The following example shows how to use the CopyTo method."/>
		/// </example>
		public void CopyTo(T[] array, int arrayIndex)
		{
			#region Validation


			Guard.ArgumentNotNull(array, "array");

			if ((array.Length - arrayIndex) < Count)
			{
				throw new ArgumentException(Constants.NotEnoughSpaceInTheTargetArray, "array");
			}

			#endregion

			for (var i = 0; i < data.Count; i++)
			{
				array.SetValue(data[i], arrayIndex++);
			}
		}


		/// <inheritdoc />  
		/// <example>
		/// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SortedListExamples.cs" region="Add" lang="cs" title="The following example shows how to use the Add method."/>
		/// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SortedListExamples.vb" region="Add" lang="vbnet" title="The following example shows how to use the Add method."/>
		/// </example>
		public void Add(T item)
		{
			AddItem(item);
		}

		/// <summary>
		/// Protected virual method for adding items which can be overriden in subclasses
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		protected virtual int AddItem(T item)
		{
			if (data.Count == 0)
			{
				data.Add(item);
				return 0;
			}


			var index = data.BinarySearch(item, comparerToUse);

			// Item was found
			if (index < 0)
				index = ~index;

			data.Insert(index, item);
			return index;

		}

		/// <inheritdoc />  
		public virtual bool Remove(T item)
		{
			return data.Remove(item);
		}

		/// <inheritdoc />  
		/// <example>
		/// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SortedListExamples.cs" region="Contains" lang="cs" title="The following example shows how to use the Contains method."/>
		/// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SortedListExamples.vb" region="Contains" lang="vbnet" title="The following example shows how to use the Contains method."/>
		/// </example>
		public bool Contains(T item)
		{
			return data.Contains(item);
		}

		void ICollection.CopyTo(Array array, int index)
		{
			CopyTo((T[])array, index);
		}

		/// <inheritdoc />  
		/// <example>
		/// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SortedListExamples.cs" region="Count" lang="cs" title="The following example shows how to use the Count method."/>
		/// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SortedListExamples.vb" region="Count" lang="vbnet" title="The following example shows how to use the Count method."/>
		/// </example>
		public int Count
		{
			get
			{
				return data.Count;
			}
		}

		object ICollection.SyncRoot
		{
			get { return data; }
		}

		bool ICollection.IsSynchronized
		{
			get { return false; }
		}

		/// <summary>
		/// Returns an enumerator that iterates through the collection.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
		/// </returns>
		/// <example>
		/// 	<code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SortedListExamples.cs" region="GetEnumerator" lang="cs" title="The following example shows how to use the GetEnumerator method."/>
		/// 	<code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SortedListExamples.vb" region="GetEnumerator" lang="vbnet" title="The following example shows how to use the GetEnumerator method."/>
		/// </example>
		public IEnumerator<T> GetEnumerator()
		{
			return data.GetEnumerator();
		}

		/// <summary>
		/// Adds the elements of the specified collection to the end of the <see cref="SortedList{T}"/>.
		/// </summary>
		/// <param name="collection">The collection whose elements should be added to the end of the <see cref="SortedList{T}"/>. The collection itself cannot be null, but it can contain elements that are null, if type T is a reference type.</param>
		/// <exception cref="ArgumentNullException"><paramref name="collection"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
		public void AddRange(IEnumerable<T> collection)
		{
			Guard.ArgumentNotNull(collection, "collection");
			foreach (var item in collection)
			{
				AddItem(item);
			}
		}
		int IList.Add(object value)
		{
			return AddItem((T)value);
		}

		bool IList.Contains(object value)
		{
			return Contains((T)value);
		}

		/// <inheritdoc />  
		/// <example>
		/// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SortedListExamples.cs" region="Clear" lang="cs" title="The following example shows how to use the Clear method."/>
		/// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SortedListExamples.vb" region="Clear" lang="vbnet" title="The following example shows how to use the Clear method."/>
		/// </example>
		public virtual void Clear()
		{
			data.Clear();
		}

		int IList.IndexOf(object value)
		{
			return IndexOf((T)value);
		}

		void IList.Insert(int index, object value)
		{
			throw new NotSupportedException();
		}

		#endregion

		#region Operator Overloads

		/// <summary>
		/// Gets the item at the specified position.
		/// </summary>
		/// <returns>The element at the specified index.</returns>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/> is less than 0.-or-<paramref name="index"/> is equal to or greater than <see cref="Count"/>.</exception>
		public T this[int index]
		{
			get
			{
				return data[index];
			}
		}

		#endregion

		#region ICollection<T> Members

		/// <inheritdoc />  
		/// <remarks>Always returns <c>false</c>.</remarks>
		/// <value>
		/// 	<c>false</c>.
		/// </value>
		/// <example>
		/// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SortedListExamples.cs" region="IsReadOnly" lang="cs" title="The following example shows how to use the IsReadOnly property."/>
		/// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SortedListExamples.vb" region="IsReadOnly" lang="vbnet" title="The following example shows how to use the IsReadOnly property."/>
		/// </example>
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		bool IList.IsFixedSize
		{
			get { return false; }
		}

		#endregion

		#region IEnumerable Members

		/// <inheritdoc />  
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		#endregion

		#region IList<T> Members
		/// <inheritdoc />  
		/// <example>
		/// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SortedListExamples.cs" region="IndexOf" lang="cs" title="The following example shows how to use the IndexOf method."/>
		/// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SortedListExamples.vb" region="IndexOf" lang="vbnet" title="The following example shows how to use the IndexOf method."/>
		/// </example>
		public int IndexOf(T item)
		{
			return data.IndexOf(item);
		}

		/// <inheritdoc />  
		/// <exception cref="NotSupportedException">Always.</exception>
		[SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
		void IList<T>.Insert(int index, T item)
		{
			throw new NotSupportedException();
		}

		/// <inheritdoc />  
		/// <exception cref="NotSupportedException">When set is called.</exception>
		[SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
		T IList<T>.this[int index]
		{
			get
			{
				return this[index];
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		#endregion
	}
}
