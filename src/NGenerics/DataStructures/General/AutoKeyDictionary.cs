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
using System.Runtime.InteropServices;
using NGenerics.Util;
#if (!SILVERLIGHT)
using System.Security;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.Serialization;
#endif

namespace NGenerics.DataStructures.General
{
    /// <summary>
    /// Provides the abstract base class for a dictionary that generated its own keys.
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the collection.</typeparam>
    /// <typeparam name="TItem">The type of items in the collection.</typeparam>
    [ComVisible(false)]
  #if (SILVERLIGHT || WINDOWSPHONE)
    public abstract class AutoKeyDictionary<TKey, TItem> : ICollection<TItem>
#else
    [Serializable]
    [DebuggerDisplay("Count = {Count}")]
    public class AutoKeyDictionary<TKey, TItem> : ICollection<TItem>, ISerializable, IDeserializationCallback
#endif
    {

        #region Globals

        private readonly Dictionary<TKey, TItem> dictionary;
      
        #endregion

        #region Constructors

        /// <inheritdoc />
        public AutoKeyDictionary(Func<TItem, TKey> getKeyForItem)
            : this(getKeyForItem, null, 0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AutoKeyDictionary&lt;TKey, TItem&gt;"/> class.
        /// </summary>
        /// <param name="getKeyForItem">The key retrieval function for the item.</param>
        /// <param name="comparer">The implementation of the <see cref="IEqualityComparer{T}"/> generic interface to use when comparing keys, or null to use the default equality comparer for the type of the key, obtained from <see cref="EqualityComparer{T}.Default"></see>.</param>
        public AutoKeyDictionary(Func<TItem, TKey> getKeyForItem, IEqualityComparer<TKey> comparer)
            : this(getKeyForItem, comparer, 0)
        {
        }

        
        /// <inheritdoc cref="Dictionary{TKey,TValue}(int)"/>
        public AutoKeyDictionary(Func<TItem, TKey> getKeyForItem, int capacity)
        {
            Guard.ArgumentNotNull(getKeyForItem, "getKeyForItem");
            GetKeyForItem = getKeyForItem;
            dictionary = new Dictionary<TKey, TItem>(capacity);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AutoKeyDictionary&lt;TKey, TItem&gt;"/> class.
        /// </summary>
        /// <param name="getKeyForItem">The key retrieval function for the item.</param>
        /// <param name="comparer">The implementation of the <see cref="IEqualityComparer{T}"/> generic interface to use when comparing keys, or null to use the default equality comparer for the type of the key, obtained from <see cref="EqualityComparer{T}.Default"/>.</param>
        /// <param name="capacity">The initial number of elements that the <see cref="AutoKeyDictionary{TKey,TItem}"/> can contain.</param>
        public AutoKeyDictionary(Func<TItem, TKey> getKeyForItem, IEqualityComparer<TKey> comparer, int capacity)
        {
            Guard.ArgumentNotNull(getKeyForItem, "getKeyForItem");
            GetKeyForItem = getKeyForItem;
            dictionary = new Dictionary<TKey, TItem>(capacity, comparer);
        }

#if (!SILVERLIGHT && !WINDOWSPHONE)
		/// <inheritdoc cref="Dictionary{TKey,TValue}(SerializationInfo, StreamingContext)"/>
        protected AutoKeyDictionary(SerializationInfo info, StreamingContext context)
        {
            var constructor = typeof(Dictionary<TKey, TItem>).GetConstructor(BindingFlags.NonPublic | BindingFlags.CreateInstance | BindingFlags.Instance, null, new[] { typeof(SerializationInfo), typeof(StreamingContext) }, null);
            dictionary = (Dictionary<TKey, TItem>)constructor.Invoke(BindingFlags.NonPublic, null, new object[] { info, context }, null);
        }
#endif
        #endregion

        #region Methods

        /// <summary>
        /// Attempts to add the specified item to the dictionary.
        /// </summary>
        /// <param name="item">The item to add to the dictionary.</param>
        /// <returns><c>True</c> if the item was added, <c>false</c> if another item with the same key was found in the dictionary.</returns>
        public virtual bool TryAdd(TItem item)
        {
            Guard.ArgumentNotNull(item, "item");

            var key = GetKeyForItem(item);
            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, item);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Attempts to remove the specified item from the dictionary.
        /// </summary>
        /// <param name="item">The item to remove from the dictionary.</param>
        /// <returns><c>True</c> if the item was found and removed, <c>false</c> if another item with the same key was found in the dictionary.</returns>
        public virtual bool TryRemove(TItem item)
        {
            Guard.ArgumentNotNull(item, "item");

            var key = GetKeyForItem(item);
            if (!dictionary.ContainsKey(key))
            {
                dictionary.Remove(key);
                return true;
            }
            return false;
        }

        #region ICollection<TItem> Members

		/// <inheritdoc />
        public virtual void Add(TItem item)
        {
            Guard.ArgumentNotNull(item, "item");
            dictionary.Add(GetKeyForItem(item), item);
        }


		/// <inheritdoc />
        public void Clear()
        {
            dictionary.Clear();
        }


		/// <inheritdoc />
        public virtual bool Contains(TItem item)
        {
            Guard.ArgumentNotNull(item, "item");
            var key = GetKeyForItem(item);
            return dictionary.ContainsKey(key);
        }


		/// <inheritdoc />
        public virtual void CopyTo(TItem[] array, int arrayIndex)
        {
            dictionary.Values.CopyTo(array, arrayIndex);
        }


		/// <inheritdoc />
        public virtual bool Remove(TItem item)
        {
            Guard.ArgumentNotNull(item, "item");
            var key = GetKeyForItem(item);
            return dictionary.Remove(key);
        }

        #endregion

        #region IEnumerable<TItem> Members
		/// <inheritdoc />
        public virtual IEnumerator<TItem> GetEnumerator()
        {
            return dictionary.Values.GetEnumerator();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return dictionary.Values.GetEnumerator();
        }

        #endregion

        /// <summary>
        /// When implemented in a derived class, extracts the key from the specified element.
        /// </summary>
        /// <returns>The key for the specified element.</returns>
        public virtual Func<TItem, TKey> GetKeyForItem { get; private set; }




        internal void InternalAdd(TItem item)
        {
            Guard.ArgumentNotNull(item, "item");
            dictionary.Add(GetKeyForItem(item), item);
        }


        /// <summary>
        /// Determines whether the <see cref="AutoKeyDictionary{TKey,TItem}"/> contains the specified key.
        /// </summary>
        /// <returns>true if the <see cref="AutoKeyDictionary{TKey,TItem}"/> contains an element with the specified key; otherwise, false.</returns>
        /// <param name="key">The key to locate in the <see cref="AutoKeyDictionary{TKey,TItem}"/>.</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="key"/> is null.</exception>
        public virtual bool ContainsKey(TKey key)
        {
            return dictionary.ContainsKey(key);
        }


        /// <summary>
        /// Removes the element with the specified key from the <see cref="AutoKeyDictionary{TKey,TItem}"/>. 
        /// </summary>
        /// <exception cref="InvalidOperationException">The <see cref="AutoKeyDictionary{TKey,TItem}"/> is read-only.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is null.</exception>
        /// <seealso cref="IsReadOnly"/> 
        public virtual bool RemoveKey(TKey key)
        {
            return dictionary.Remove(key);
        }


        /// <summary>
        /// Removes the element with the specified key from the <see cref="AutoKeyDictionary{TKey,TItem}"/>. 
        /// </summary>
        /// <exception cref="InvalidOperationException">The <see cref="AutoKeyDictionary{TKey,TItem}"/> is read-only.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is null.</exception>
        /// <seealso cref="IsReadOnly"/> 
        internal bool InternalRemove(TKey key)
        {
            return dictionary.Remove(key);
        }


        /// <summary>
        /// Removes the element from the <see cref="AutoKeyDictionary{TKey,TItem}"/>. 
        /// </summary>
        /// <exception cref="InvalidOperationException">The <see cref="AutoKeyDictionary{TKey,TItem}"/> is read-only. </exception>
        /// <exception cref="ArgumentNullException"><paramref name="item"/> is null.</exception>
        /// <seealso cref="IsReadOnly"/> 
        internal bool InternalRemove(TItem item)
        {
            Guard.ArgumentNotNull(item, "item");
            var key = GetKeyForItem(item);
            return dictionary.Remove(key);
        }




        /// <summary>
        /// Gets the item associated with the specified key. 
        /// </summary>
        /// <param name="key">The key of the item to get.</param>
        /// <param name="item">When this method returns, contains the item associated with the specified <paramref name="key"/>, if the key is found; otherwise, the default item for the type of the item parameter. This parameter is passed uninitialized.</param>
        /// <returns>true if the <see cref="AutoKeyDictionary{TKey,TItem}"/> contains an element with the specified <paramref name="key"/>; otherwise, false. </returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is a null reference </exception>
        public virtual bool TryGetValue(TKey key, out TItem item)
        {
            return dictionary.TryGetValue(key, out item);
        }


#if (!SILVERLIGHT && !WINDOWSPHONE)
		#region ISerializable, IDeserializationCallback


		#region IDeserializationCallback Members
		/// <inheritdoc />
        public virtual void OnDeserialization(object sender)
        {
            dictionary.OnDeserialization(sender);
        }

        #endregion
        

        #region ISerializable Members

		/// <inheritdoc />
		[SecurityCritical]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            dictionary.GetObjectData(info, context);
        }

        #endregion

        #endregion
#endif


        #endregion

        #region Properties

        /// <summary>Gets the <see cref="IEqualityComparer{T}"/> that is used to determine equality of keys for the dictionary. </summary>
        /// <returns>The <see cref="IEqualityComparer{T}"/> generic interface implementation that is used to determine equality of keys for the current <see cref="AutoKeyDictionary{TKey,TItem}"/> and to provide hash values for the keys.</returns>
        public virtual IEqualityComparer<TKey> Comparer
        {
            get
            {
                return dictionary.Comparer;
            }
        }


        /// <summary>Gets the value associated with the specified key.</summary>
        /// <returns>The value associated with the specified key. If the specified <paramref name="key"/> is not found, a get operation throws a <see cref="KeyNotFoundException"/>, and a set operation creates a new element with the specified key.</returns>
        /// <param name="key">The key of the value to get or set.</param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is null.</exception>
        /// <exception cref="KeyNotFoundException">An item with the <paramref name="key"/> does not exist in the collection.</exception>
        public virtual TItem this[TKey key]
        {
            get
            {
                return dictionary[key];
            }
        }


        /// <summary>
        /// Gets a collection containing the keys in the <see cref="AutoKeyDictionary{TKey,TItem}"/>. 
        /// </summary>
        /// <remarks>
        /// The order of the keys in the <see cref="Dictionary{TKey,TValue}.KeyCollection"/> is unspecified, but it is the same order as the associated values in the <see cref="Dictionary{TKey,TValue}.ValueCollection"/> returned by the Values property.
        /// The returned <see cref="Dictionary{TKey,TValue}.KeyCollection"/> is not a static copy; instead, the <see cref="Dictionary{TKey,TValue}.KeyCollection"/> refers back to the keys in the original <see cref="AutoKeyDictionary{TKey,TItem}"/>. Therefore, changes to the <see cref="AutoKeyDictionary{TKey,TItem}"/> continue to be reflected in the <see cref="Dictionary{TKey,TValue}.KeyCollection"/>.
        /// Getting the value of this property is an O(1) operation.
        /// </remarks>
        public virtual Dictionary<TKey, TItem>.KeyCollection Keys
        {
            get
            {
                return dictionary.Keys;
            }
        }

        /// <summary>
        /// Gets a collection containing the values in the <see cref="AutoKeyDictionary{TKey,TItem}"/>. 
        /// </summary>
        /// <remarks>
        /// The order of the values in the <see cref="Dictionary{TKey,TValue}.ValueCollection"/> is unspecified, but it is the same order as the associated keys in the <see cref="Dictionary{TKey,TValue}.KeyCollection"/> returned by the Keys property.
        /// The returned <see cref="Dictionary{TKey,TValue}.ValueCollection"/> is not a static copy; instead, the <see cref="Dictionary{TKey,TValue}.ValueCollection"/> refers back to the values in the original <see cref="AutoKeyDictionary{TKey,TItem}"/>. Therefore, changes to the <see cref="AutoKeyDictionary{TKey,TItem}"/> continue to be reflected in the <see cref="Dictionary{TKey,TValue}.ValueCollection"/>.
        /// Getting the value of this property is an O(1) operation.
        /// </remarks>
        public virtual Dictionary<TKey, TItem>.ValueCollection Values
        {
            get
            {
                return dictionary.Values;
            }
        }

		/// <inheritdoc />
        public virtual int Count
        {
            get
            {
                return dictionary.Count;
            }
        }

		/// <inheritdoc />
        public virtual bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        #endregion
    }
}