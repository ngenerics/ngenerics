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
using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security;
using NGenerics.Util;

namespace NGenerics.DataStructures.General
{
    /// <summary>
    /// A custom hashtable extending the standard Generic Dictionary.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The <see cref="DictionaryBase{TKey,TValue}"/> class can be used by derive your 
    /// own dictionary type the <see cref="DictionaryBase{TKey,TValue}"/> class.
    /// </para>
    /// <para>
    /// The <see cref="DictionaryBase{TKey,TValue}"/> class provides protected 
    /// methods that can be used to customize its behavior when adding and removing 
    /// items, clearing the dictionary, or setting the value of an existing item.
    /// </para>
    /// <para>
    /// <see cref="DictionaryBase{TKey,TValue}"/> accepts a null reference 
    /// (Nothing in Visual Basic) as a valid value for reference types.
    /// </para>
    /// <para>
    /// Notes to Implementers: This base class is provided to make it easier for implementers 
    /// to create a custom dictionaries. Implementers are encouraged to extend this base class 
    /// instead of creating their own. 
    /// </para>
    /// </remarks>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
	/// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    [Serializable]
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
	public abstract class DictionaryBase<TKey, TValue> : IDictionary<TKey, TValue>, IDictionary, ISerializable, IDeserializationCallback
    {
        #region Globals

        private readonly Dictionary<TKey, TValue> _dictionary;

        #endregion 

        #region Construction


        /// <inheritdoc cref="Dictionary{TKey,TValue}()"/>
        protected DictionaryBase()
        {
            _dictionary = new Dictionary<TKey, TValue>();
        }


        /// <inheritdoc cref="Dictionary{TKey,TValue}(IDictionary{TKey,TValue})"/>
        protected DictionaryBase(IDictionary<TKey, TValue> dictionary)
        {
            _dictionary = new Dictionary<TKey, TValue>(dictionary);
        }


        /// <inheritdoc cref="Dictionary{TKey,TValue}(IEqualityComparer{TKey})"/>
        protected DictionaryBase(IEqualityComparer<TKey> comparer)
        {
            _dictionary = new Dictionary<TKey, TValue>(comparer);
        }



        /// <inheritdoc cref="Dictionary{TKey,TValue}(int)"/>
        protected DictionaryBase(int capacity)
        {
            _dictionary = new Dictionary<TKey, TValue>(capacity);
        }



        /// <inheritdoc cref="Dictionary{TKey,TValue}(IDictionary{TKey,TValue}, IEqualityComparer{TKey})"/>
        protected DictionaryBase(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
        {
            _dictionary = new Dictionary<TKey, TValue>(dictionary, comparer);
        }



        /// <inheritdoc cref="Dictionary{TKey,TValue}(int, IEqualityComparer{TKey})"/>
        protected DictionaryBase(int capacity, IEqualityComparer<TKey> comparer)
        {
            _dictionary = new Dictionary<TKey, TValue>(capacity, comparer);
        }


		/// <inheritdoc cref="Dictionary{TKey,TValue}(SerializationInfo, StreamingContext)"/>
        protected DictionaryBase(SerializationInfo info, StreamingContext context)
        {
            var constructor = typeof(Dictionary<TKey, TValue>).GetConstructor(BindingFlags.NonPublic | BindingFlags.CreateInstance | BindingFlags.Instance, null, new[] { typeof(SerializationInfo), typeof(StreamingContext) }, null);
            _dictionary = (Dictionary<TKey, TValue>)constructor.Invoke(BindingFlags.NonPublic, null, new object[] { info, context }, null);
        }

        #endregion

        #region Methods


        /// <inheritdoc cref="Dictionary{TKey,TValue}.GetEnumerator()"/>
        public Dictionary<TKey, TValue>.Enumerator GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }



        /// <inheritdoc cref="Dictionary{TKey,TValue}.Add"/>
		/// <remarks>
		/// <b>Notes to Inheritors: </b>
		///  Derived classes can override this method to change the behavior of the <see cref="Add"/> method.
		/// </remarks>
		protected virtual void AddItem(TKey key, TValue value)
        {
			_dictionary.Add(key, value);
        }

        /// <summary>
        /// Sets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key to set the value for.</param>
        /// <param name="value">The value to assign to the entry.</param>
        /// <remarks>
        /// 	<b>Notes to Inheritors: </b>
        /// Derived classes can override this method to change the behavior of the <see cref="SetItem"/> method.
        /// </remarks>
		protected virtual void SetItem(TKey key, TValue value)
        {
            _dictionary[key] = value;
        }

        /// <summary>
        /// Removes the value with the specified key from the <see cref="DictionaryBase{TKey,TValue}"/>.
        /// </summary>
        /// <param name="key">The key to remove.</param>
        /// <returns>
        /// 	<c>true</c> if the element is successfully found and removed; otherwise, <c>false</c>. This method returns false if key is not found in the <see cref="DictionaryBase{TKey,TValue}"/>.
        /// </returns>
        /// <remarks>
        /// 	<b>Notes to Inheritors: </b>
        /// Derived classes can override this method to change the behavior of the <see cref="Remove"/> method.
        /// </remarks>
		protected virtual bool RemoveItem(TKey key)
        {
			return _dictionary.Remove(key);
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
            _dictionary.Clear();
        }


        /// <summary>
        /// Verifies the key.
        /// </summary>
        /// <param name="key">The key.</param>
        private static void VerifyKey(object key)
        {
            Guard.ArgumentNotNull(key, "key");
            if (!(key is TKey))
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Keys is of type {0}.", typeof(TKey)), "key");
            }
        }

        /// <summary>
        /// Verifies the type of the value.
        /// </summary>
        /// <param name="value">The value.</param>
        private static void VerifyValueType(object value)
        {
            if (!(value is TValue))
            {
                if (value != null || typeof (TValue).IsValueType)
                {
                    throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Value is of type {0}.", typeof (TValue)), "value");
                }
            }
        }


        #endregion

        #region Properties


        /// <inheritdoc cref="Dictionary{TKey,TValue}.Comparer"/>
        public IEqualityComparer<TKey> Comparer => _dictionary.Comparer;

        #endregion

        #region IDictionary<TKey,TValue> Members

		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\DictionaryBaseExamples.cs" region="ContainsKey" lang="cs" title="The following example shows how to use the ContainsKey method."/>
        /// </example>
        public bool ContainsKey(TKey key)
        {
            return _dictionary.ContainsKey(key);
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\DictionaryBaseExamples.cs" region="Add" lang="cs" title="The following example shows how to use the Add method."/>
        /// </example>
        public void Add(TKey key, TValue value)
        {
            AddItem(key, value);
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\DictionaryBaseExamples.cs" region="Remove" lang="cs" title="The following example shows how to use the Remove method."/>
        /// </example>
        public bool Remove(TKey key)
        {
				return RemoveItem(key);
        }


		/// <inheritdoc />
		/// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\DictionaryBaseExamples.cs" region="TryGetValue" lang="cs" title="The following example shows how to use the TryGetValue method."/>
        /// </example>
        public bool TryGetValue(TKey key, out TValue value)
        {
            return _dictionary.TryGetValue(key, out value);
        }


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\DictionaryBaseExamples.cs" region="Item" lang="cs" title="The following example shows how to use the Item property."/>
        /// </example>
        public TValue this[TKey key]
        {
            get => _dictionary[key];
		    set => SetItem(key, value);
		}


		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\DictionaryBaseExamples.cs" region="Keys" lang="cs" title="The following example shows how to use the Keys property."/>
        /// </example>
        public ICollection<TKey> Keys => _dictionary.Keys;


        /// <inheritdoc />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\DictionaryBaseExamples.cs" region="Values" lang="cs" title="The following example shows how to use the Values property."/>
        /// </example>
        public ICollection<TValue> Values => _dictionary.Values;

        #endregion

        #region ICollection<KeyValuePair<TKey,TValue>> Members

		/// <inheritdoc />
        void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
        {
            AddItem(item.Key, item.Value);
        }


        /// <inheritdoc cref="ICollection{T}" />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\DictionaryBaseExamples.cs" region="Clear" lang="cs" title="The following example shows how to use the Clear method."/>
        /// </example>
        public void Clear()
        {
            ClearItems();
        }


		/// <inheritdoc />
        [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item)
        {
            return ((ICollection<KeyValuePair<TKey, TValue>>)_dictionary).Contains(item);
        }


		/// <inheritdoc />
        [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            ((ICollection<KeyValuePair<TKey, TValue>>)_dictionary).CopyTo(array, arrayIndex);
        }


		/// <inheritdoc />
        [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
		{
		    if (TryGetValue(item.Key, out var value) &&
		        EqualityComparer<TValue>.Default.Equals(value, item.Value))
		    {
		        RemoveItem(item.Key);
		        return true;
		    }

		    return false;
		}


        /// <inheritdoc cref="ICollection{T}" />
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\General\DictionaryBaseExamples.cs" region="Count" lang="cs" title="The following example shows how to use the Count property."/>
        /// </example>
        public int Count => _dictionary.Count;

        #endregion

        #region IEnumerable<KeyValuePair<TKey,TValue>> Members

		/// <inheritdoc />
        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

		/// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<TKey, TValue>>)this).GetEnumerator();
        }

        #endregion

        #region IDictionary Members

		/// <inheritdoc />
        void IDictionary.Add(object key, object value)
        {
            VerifyKey(key);
            VerifyValueType(value);
            AddItem((TKey)key, (TValue)value);
        }


		/// <inheritdoc />
        [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        bool IDictionary.Contains(object key)
        {
            return ((IDictionary)_dictionary).Contains(key);
        }


		/// <inheritdoc />
        IDictionaryEnumerator IDictionary.GetEnumerator()
        {
            return ((IDictionary)_dictionary).GetEnumerator();
        }



		/// <inheritdoc />
        [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void IDictionary.Remove(object key)
        {
            VerifyKey(key);
            Remove((TKey)key);
        }


		/// <inheritdoc />
        object IDictionary.this[object key]
        {
            get => ((IDictionary)_dictionary)[key];
		    set
            {
                VerifyKey(key);
                VerifyValueType(value);
                SetItem((TKey)key, (TValue)value);
            }
        }


		/// <inheritdoc />
        [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        ICollection IDictionary.Keys => ((IDictionary)_dictionary).Keys;

        /// <inheritdoc />
        [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        ICollection IDictionary.Values => ((IDictionary)_dictionary).Values;


        /// <inheritdoc />
        [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        public bool IsFixedSize => false;


        /// <inheritdoc cref="ICollection{T}" />
        [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
       public bool IsReadOnly => ((IDictionary)_dictionary).IsReadOnly;

        #endregion

        #region ICollection Members
		/// <inheritdoc />
        [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void ICollection.CopyTo(Array array, int index)
        {
            ((ICollection)_dictionary).CopyTo(array, index);
        }


		/// <inheritdoc />
        [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        object ICollection.SyncRoot => ((ICollection)_dictionary).SyncRoot;


        /// <inheritdoc />
        [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        bool ICollection.IsSynchronized => ((ICollection)_dictionary).IsSynchronized;

        #endregion

		#region ISerializable Members

		/// <inheritdoc />
		[SecurityCritical]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            _dictionary.GetObjectData(info, context);
        }

        #endregion

        #region IDeserializationCallback Members

        /// <inheritdoc />
        public virtual void OnDeserialization(object sender)
        {
            _dictionary.OnDeserialization(sender);
        }

        #endregion
    }
}