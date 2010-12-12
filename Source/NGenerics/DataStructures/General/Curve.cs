/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html. 
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using NGenerics.Comparers;

namespace NGenerics.DataStructures.General
{
    /// <summary>
    /// An implementation of a Dictionary like structure implemented with IList interface instead.
    /// Rather than KeyvaluePair this structure uses <see cref="Association{Key,Value} "/> for added flexibility.
    /// Another benefit that this structure can be XMLSerialized in contrast to Dictionary.
    /// Typical application would be for storing chart curve points, hence the name.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TValue">The type of the value.</typeparam>
    [Serializable]
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
    [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
    public class Curve<TKey, TValue> :
        IList<Association<TKey, TValue>>,
        IList
        where TKey : IComparable
    {
        #region Globals

        private readonly AssociationKeyComparer<TKey, TValue> comparerToUse;
        private readonly List<Association<TKey, TValue>> data;

        #endregion

        #region Construction

        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SortedListExamples.cs" region="Constructor" lang="cs" title="The following example shows how to use the default constructor."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SortedListExamples.vb" region="Constructor" lang="vbnet" title="The following example shows how to use the default constructor."/>
        /// </example>
        public Curve()
        {
            data = new List<Association<TKey, TValue>>();
            comparerToUse = AssociationKeyComparer<TKey, TValue>.DefaultComparer;
        }


        /// <param name="comparer">The comparer to use.</param>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SortedListExamples.cs" region="ConstructorComparer" lang="cs" title="The following example shows how to use the Comparer constructor."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SortedListExamples.vb" region="ConstructorComparer" lang="vbnet" title="The following example shows how to use the Comparer constructor."/>
        /// </example>
        public Curve(IComparer<TKey> comparer)
        {
            data = new List<Association<TKey, TValue>>();
            comparerToUse = new AssociationKeyComparer<TKey, TValue>(comparer);
        }

        /// <param name="capacity">The initial capacity of the sorted list.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="capacity"/> is less than 0.</exception>.
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SortedListExamples.cs" region="ConstructorCapacity" lang="cs" title="The following example shows how to use the constructor with an initial capacity."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SortedListExamples.vb" region="ConstructorCapacity" lang="vbnet" title="The following example shows how to use the constructor with an initial capacity."/>
        /// </example>
        public Curve(int capacity)
        {
            data = new List<Association<TKey, TValue>>(capacity);
            comparerToUse = AssociationKeyComparer<TKey, TValue>.DefaultComparer;
        }

        /// <param name="capacity">The initial capacity of the sorted list.</param>
        /// <param name="comparer">The comparer to use.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="capacity"/> is less than 0.</exception>.
        public Curve(int capacity, IComparer<TKey> comparer)
        {
            data = new List<Association<TKey, TValue>>(capacity);
            comparerToUse = new AssociationKeyComparer<TKey, TValue>(comparer);
        }


        /// <param name="collection">The collection to copy into the sorted list.</param>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SortedListExamples.cs" region="ConstructorCollection" lang="cs" title="The following example shows how to use the collections constructor."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SortedListExamples.vb" region="ConstructorCollection" lang="vbnet" title="The following example shows how to use the collections constructor."/>
        /// </example>
        public Curve(IEnumerable<Association<TKey, TValue>> collection)
            : this()
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        /// <param name="collection">The collection to copy into the sorted list.</param>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SortedListExamples.cs" region="ConstructorCollection" lang="cs" title="The following example shows how to use the collections constructor."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SortedListExamples.vb" region="ConstructorCollection" lang="vbnet" title="The following example shows how to use the collections constructor."/>
        /// </example>
        public Curve(IEnumerable<KeyValuePair<TKey, TValue>> collection)
            : this()
        {
            foreach (var item in collection)
            {
                Add(new Association<TKey, TValue>(item));
            }
        }

        #endregion

        /// <summary>
        /// Gets the comparer.
        /// </summary>
        /// <value>The comparer.</value>
        public IComparer<TKey> Comparer
        {
            get { return comparerToUse; }
        }

        /// <summary>
        /// Gets or sets the total number of elements the internal data structure can hold without resizing.
        /// </summary>
        public int Capacity
        {
            get { return data.Capacity; }
            set { data.Capacity = value; }
        }

        /// <inheritdoc />  
        public bool IsEmpty
        {
            get { return Count == 0; }
        }

        /// <summary>
        /// Get the value indexed by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public TValue GetValue(TKey key)
        {
            var index = IndexOf(key);

            if (index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            return data[index].Value;
        }


        /// <summary>
        /// Gets or sets the <see cref="NGenerics.DataStructures.General.Association&lt;TKey,TValue&gt;"/> with the specified key.
        /// </summary>
        /// <value></value>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Association<TKey, TValue> this[TKey key]
        {
            get
            {
                var index = IndexOf(key);

                // Item was found
                if (index < 0)
                {
                    throw new ArgumentOutOfRangeException();

                }
                return this[index];
            }
            set
            {
                var a = this[key];
                if (a.Key.Equals(value.Key))
                    a.Value = value.Value;
                else
                    throw new ArgumentException();
            }
        }

        /// <summary>
        /// Gets the keys.
        /// </summary>
        /// <value>The keys.</value>
        public TKey[] Keys
        {
            get
            {
                var values = new TKey[Count];
                for (var i = 0; i < Count; i++)
                {
                    values[i] = data[i].Key;
                }
                return values;
            }
        }

        /// <summary>
        /// Gets the values.
        /// </summary>
        /// <value>The values.</value>
        public TValue[] Values
        {
            get
            {
                var values = new TValue[Count];
                for (var i = 0; i < Count; i++)
                {
                    values[i] = data[i].Value;
                }
                return values;
            }
        }

        #region IList Members

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.IList"/>.
        /// </summary>
        /// <param name="value">The <see cref="T:System.Object"/> to remove from the <see cref="T:System.Collections.IList"/>.</param>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"/> is read-only.-or- The <see cref="T:System.Collections.IList"/> has a fixed size. </exception>
        void IList.Remove(object value)
        {
            var association = value as Association<TKey, TValue>;
            if (association != null)
            {
                Remove(association);
            }
            else
            {
                if (value is KeyValuePair<TKey, TValue>)
                {
                    var val = (KeyValuePair<TKey, TValue>) value;
                    var i = IndexOf(val.Key);
                    if (i < 0)
                    {
                        return;
                    }
                    if (this[i].Value.Equals(val.Value))
                    {
                        RemoveAt(i);
                    }
                }
                else if (value is TKey)
                {
                    Remove((TKey) value);
                }
                else
                {
                    throw new ArgumentException();
                }
            }

        }

        /// <summary>
        /// Gets or sets the <see cref="System.Object"/> at the specified index.
        /// </summary>
        /// <value></value>
        object IList.this[int index]
        {
            get { return this[index]; }
            set { throw new NotSupportedException(); }
        }


        void ICollection.CopyTo(Array array, int arrayIndex)
        {
            data.ToArray().CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Gets an object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection"/>.
        /// </summary>
        /// <value></value>
        /// <returns>An object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection"/>.</returns>
        public object SyncRoot
        {
            get { return data; }
        }

        /// <summary>
        /// Gets a value indicating whether access to the <see cref="T:System.Collections.ICollection"/> is synchronized (thread safe).
        /// </summary>
        /// <value></value>
        /// <returns>true if access to the <see cref="T:System.Collections.ICollection"/> is synchronized (thread safe); otherwise, false.</returns>
        public bool IsSynchronized
        {
            get { return false; }
        }

        /// <summary>
        /// Adds an item to the <see cref="T:System.Collections.IList"/>.
        /// </summary>
        /// <param name="value">The <see cref="T:System.Object"/> to add to the <see cref="T:System.Collections.IList"/>.</param>
        /// <returns>
        /// The position into which the new element was inserted.
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"/> is read-only.-or- The <see cref="T:System.Collections.IList"/> has a fixed size. </exception>
        int IList.Add(object value)
        {
            return AddSetItem((Association<TKey, TValue>)value);
        }

        /// <summary>
        /// Determines whether the <see cref="T:System.Collections.IList"/> contains a specific value.
        /// </summary>
        /// <param name="value">The <see cref="T:System.Object"/> to locate in the <see cref="T:System.Collections.IList"/>.</param>
        /// <returns>
        /// true if the <see cref="T:System.Object"/> is found in the <see cref="T:System.Collections.IList"/>; otherwise, false.
        /// </returns>
        bool IList.Contains(object value)
        {
            return Contains((Association<TKey, TValue>)value);
        }

        /// <summary>
        /// Determines the index of a specific item in the <see cref="T:System.Collections.IList"/>.
        /// </summary>
        /// <param name="value">The <see cref="T:System.Object"/> to locate in the <see cref="T:System.Collections.IList"/>.</param>
        /// <returns>
        /// The index of <paramref name="value"/> if found in the list; otherwise, -1.
        /// </returns>
        int IList.IndexOf(object value)
        {
            return IndexOf((Association<TKey, TValue>)value);
        }

        /// <summary>
        /// Inserts an item to the <see cref="T:System.Collections.IList"/> at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which <paramref name="value"/> should be inserted.</param>
        /// <param name="value">The <see cref="T:System.Object"/> to insert into the <see cref="T:System.Collections.IList"/>.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// 	<paramref name="index"/> is not a valid index in the <see cref="T:System.Collections.IList"/>. </exception>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.IList"/> is read-only.-or- The <see cref="T:System.Collections.IList"/> has a fixed size. </exception>
        /// <exception cref="T:System.NullReferenceException">
        /// 	<paramref name="value"/> is null reference in the <see cref="T:System.Collections.IList"/>.</exception>
        void IList.Insert(int index, object value)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.IList"/> has a fixed size.
        /// </summary>
        /// <value></value>
        /// <returns>true if the <see cref="T:System.Collections.IList"/> has a fixed size; otherwise, false.</returns>
        public bool IsFixedSize
        {
            get { return false; }
        }

        #endregion

        #region Operator Overloads

        /// <summary>
        /// Gets the item at the specified position.
        /// </summary>
        /// <returns>The element at the specified index.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/> is less than 0.-or-<paramref name="index"/> is equal to or greater than <see cref="Count"/>.</exception>
        public Association<TKey, TValue> this[int index]
        {
            get { return data[index]; }
            set { data[index] = value; }
        }

        #endregion

        #region IList<Association<TKey,TValue>> Members

        /// <inheritdoc />  
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SortedListExamples.cs" region="RemoveAt" lang="cs" title="The following example shows how to use the RemoveAt method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SortedListExamples.vb" region="RemoveAt" lang="vbnet" title="The following example shows how to use the RemoveAt method."/>
        /// </example>
        public void RemoveAt(int index)
        {
            data.RemoveAt(index);
        }

        /// <inheritdoc />  
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SortedListExamples.cs" region="CopyTo" lang="cs" title="The following example shows how to use the CopyTo method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SortedListExamples.vb" region="CopyTo" lang="vbnet" title="The following example shows how to use the CopyTo method."/>
        /// </example>
        public void CopyTo(Association<TKey, TValue>[] array, int arrayIndex)
        {
            (this as ICollection).CopyTo(array, arrayIndex);
        }


        /// <inheritdoc />  
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SortedListExamples.cs" region="Add" lang="cs" title="The following example shows how to use the Add method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SortedListExamples.vb" region="Add" lang="vbnet" title="The following example shows how to use the Add method."/>
        /// </example>
        public void Add(Association<TKey, TValue> item)
        {
            AddSetItem(item);
        }

        private int AddSetItem(Association<TKey, TValue> item)
        {
            if (data.Count == 0)
            {
                data.Add(item);
                return 0;
            }

            var index = data.BinarySearch(item, comparerToUse);

            // Item was not found
            if (index < 0)
            {
                index = ~index;
                data.Insert(index, item);
            }
            else data[index] = item;


            return index;

        }

        /// <inheritdoc />  
        public bool Remove(Association<TKey, TValue> item)
        {
            return data.Remove(item);
        }

        /// <inheritdoc />  
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SortedListExamples.cs" region="Contains" lang="cs" title="The following example shows how to use the Contains method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SortedListExamples.vb" region="Contains" lang="vbnet" title="The following example shows how to use the Contains method."/>
        /// </example>
        public bool Contains(Association<TKey, TValue> item)
        {
            return data.Contains(item);
        }

        /// <summary>
        /// Check if the collection contains (key,value) pair
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(TKey key, TValue value)
        {
            return data.Contains(new Association<TKey,TValue>(key, value));
        }

        /// <inheritdoc />  
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SortedListExamples.cs" region="Count" lang="cs" title="The following example shows how to use the Count method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SortedListExamples.vb" region="Count" lang="vbnet" title="The following example shows how to use the Count method."/>
        /// </example>
        public int Count
        {
            get { return data.Count; }
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
        public IEnumerator<Association<TKey, TValue>> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        /// <inheritdoc />  
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SortedListExamples.cs" region="Clear" lang="cs" title="The following example shows how to use the Clear method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SortedListExamples.vb" region="Clear" lang="vbnet" title="The following example shows how to use the Clear method."/>
        /// </example>
        public void Clear()
        {
            data.Clear();
        }

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
            get { return false; }
        }

        /// <inheritdoc />  
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <inheritdoc />  
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SortedListExamples.cs" region="IndexOf" lang="cs" title="The following example shows how to use the IndexOf method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SortedListExamples.vb" region="IndexOf" lang="vbnet" title="The following example shows how to use the IndexOf method."/>
        /// </example>
        public int IndexOf(Association<TKey, TValue> item)
        {
            return data.BinarySearch(item, comparerToUse);
        }

        /// <inheritdoc />  
        /// <exception cref="NotSupportedException">Always.</exception>
        [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void IList<Association<TKey, TValue>>.Insert(int index, Association<TKey, TValue> item)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />  
        /// <exception cref="NotSupportedException">When set is called.</exception>
        [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        Association<TKey, TValue> IList<Association<TKey, TValue>>.this[int index]
        {
            get { return data[index]; }
            set { throw new NotSupportedException(); }
        }

        #endregion

        /// <summary>
        /// Gets the key for item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The key for the specified association.</returns>
        protected TKey GetKeyForItem(Association<TKey, TValue> item)
        {
            return item.Key;
        }


        /// <summary>
        /// Determines whether the collection contains the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        /// 	<c>true</c> if the collection contains the key; otherwise, <c>false</c>.
        /// </returns>
        public bool ContainsKey(TKey key)
        {
            return IndexOf(key) >= 0;
        }


        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Add(TKey key, TValue value)
        {
            Add(new Association<TKey, TValue>(key, value));
        }

        /// <summary>
        /// Removes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public bool Remove(TKey key)
        {
            var index = IndexOf(key);

            // Item was found
            if (index < 0)
            {
                return false;
            }

            RemoveAt(index);
            return true;

        }

        /// <summary>
        /// Tries to the get the value tied to the specified key.
        /// </summary>
        /// <param name="key">The key to look for.</param>
        /// <param name="value">The value.</param>
        /// <returns>An indication of whether the item was found.</returns>
        public bool TryGetValue(TKey key, out TValue value)
        {
            var index = IndexOf(key);

            // Item was found
            var res = (index >= 0);
            if (res)
            {
                value = this[index].Value;
            }
            else
            {
                value = default(TValue);
            }
            return res;
        }

        /// <summary>
        /// Gets the default association for the key.
        /// </summary>
        /// <param name="key">The key to get the default association for.</param>
        /// <returns>An association with a default value and the given key.</returns>
        protected Association<TKey, TValue> GetDefaultAssociationForKey(TKey key)
        {
            return new Association<TKey, TValue>(key, default(TValue));
        }

        /// <summary>
        /// Gets the index of the specified key.
        /// </summary>
        /// <param name="key">The key to look for.</param>
        /// <returns>The index of the specified key.</returns>
        protected int IndexOf(TKey key)
        {
            return IndexOf(GetDefaultAssociationForKey(key));
        }
    }
}