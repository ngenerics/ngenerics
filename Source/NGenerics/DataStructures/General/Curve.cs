using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using NGenerics.Comparers;
using NGenerics.Misc;
using NGenerics.Util;

namespace NGenerics.DataStructures.General
{
    /// <summary>
    /// An implementation of a Dictionary like structure implemented with IList interface instead.
    /// Rather than KeyvaluePair this structure uses Association<Key,Value> for added flexibility.
    /// Another benefit that this structure can be XMLSerialized in contrast to Dictionary.
    /// 
    /// Typical application would be for storing chart curve points, hence the name.
    /// </summary>
    /// <typeparam name="T">The type of elements in the sorted list.</typeparam>
#if (!SILVERLIGHT)
    [Serializable]
#endif
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
    [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
    public class Curve<TKey, TValue> :
        IList<Association<TKey, TValue>>,
        ICollection<Association<TKey, TValue>>,
        IList
        where TKey : IComparable
        //where TKey : struct
    {
        #region Globals

        private readonly IAssociationKeyComparer<TKey, TValue> comparerToUse;
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

        /// <inheritdoc />  
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SortedListExamples.cs" region="IsEmpty" lang="cs" title="The following example shows how to use the IsEmpty property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SortedListExamples.vb" region="IsEmpty" lang="vbnet" title="The following example shows how to use the IsEmpty property."/>
        /// </example>
        public bool IsEmpty
        {
            get { return Count == 0; }
        }

        public TValue GetValue(TKey key)
        {
            var index = IndexOf(key);

            if (index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            return data[index].Value;
        }


        ///<summary>
        ///</summary>
        ///<param name="key"></param>
        ///<exception cref="ArgumentOutOfRangeException"></exception>
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
                AddSetItem(value);
            }
        }

        ///<summary>
        ///</summary>
        public TKey[] Keys
        {
            get
            {
                var values = new TKey[Count];
                for (int i = 0; i < Count; i++)
                {
                    values[i] = data[i].Key;
                }
                return values;
            }
        }

        ///<summary>
        ///</summary>
        public TValue[] Values
        {
            get
            {
                var values=new  TValue[Count];
                for (int i = 0; i < Count; i++)
                {
                    values[i] = data[i].Value;
                }
                return values;
            }
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //public List<Association<TKey, TValue>> Data
        //{
        //    get { return data; }
        //}

        #region IList Members

        void IList.Remove(object value)
        {
                Remove((Association<TKey, TValue>) value);
        }

        object IList.this[int index]
        {
            get { return this[index]; }
            set { throw new NotSupportedException(); }
        }


        void ICollection.CopyTo(Array array, int arrayIndex)
        {
            data.ToArray().CopyTo(array,arrayIndex);
        }

        public object SyncRoot
        {
            get { return data; }
        }

        public bool IsSynchronized
        {
            get { return false;  }
        }

        int IList.Add(object value)
        {
                return AddSetItem((Association<TKey, TValue>)value);
        }

        bool IList.Contains(object value)
        {
                return Contains((Association<TKey, TValue>)value);
        }

        int IList.IndexOf(object value)
        {
                return IndexOf((Association<TKey, TValue>)value);
        }

        void IList.Insert(int index, object value)
        {
            throw new NotSupportedException();
        }

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
                {   index=~index;
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
            return data.IndexOf(item);
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

        protected TKey GetKeyForItem(Association<TKey, TValue> item)
        {
            return item.Key;
        }


        ///<summary>
        ///</summary>
        ///<param name="key"></param>
        ///<returns></returns>
        public bool ContainsKey(TKey key)
        {
            return IndexOf(key) >= 0;
        }


        ///<summary>
        ///</summary>
        ///<param name="key"></param>
        ///<param name="value"></param>
        public void Add(TKey key, TValue value)
        {
            Add(new Association<TKey, TValue>(key, value));
        }

        ///<summary>
        ///</summary>
        ///<param name="key"></param>
        ///<returns></returns>
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

        ///<summary>
        ///</summary>
        ///<param name="key"></param>
        ///<param name="value"></param>
        ///<returns></returns>
        public bool TryGetValue(TKey key, out TValue value)
        {
            var index = IndexOf(key);

            // Item was found
            bool res = (index >= 0);
            value = (res ? this[index].Value : default(TValue));
            return res;
        }

        protected Association<TKey, TValue> GetDefaultAssociationForKey(TKey key)
        {
            return new Association<TKey, TValue>(key, default(TValue));
        }

        protected int IndexOf(TKey key)
        {
            return data.BinarySearch(GetDefaultAssociationForKey(key), comparerToUse);
        }
    }
}