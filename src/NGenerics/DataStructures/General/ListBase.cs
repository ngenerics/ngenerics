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
using System.Collections.ObjectModel;
using System.Diagnostics;
using NGenerics.Util;
using System.Diagnostics.CodeAnalysis;

namespace NGenerics.DataStructures.General
{
    /// <summary>
    /// Represents a strongly typed list of objects that can be accessed by index. Provides methods to search, sort, and manipulate lists.
    /// </summary>
    [Serializable]
    [DebuggerDisplay("Count = {Count}")]
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
    [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
    public class ListBase<T> : IList<T>, IList
    {
        internal readonly List<T> innerList;


        /// <inheritdoc cref="List{T}()"/>
        public ListBase()
        {
            innerList = new List<T>();
        }


        /// <inheritdoc cref="List{T}(IEnumerable{T})"/>
        public ListBase(IEnumerable<T> collection)
        {
            innerList = new List<T>(collection);
        }


        /// <inheritdoc cref="List{T}(int)"/>
        public ListBase(int capacity)
        {
            innerList = new List<T>(capacity);
        }

        /// <inheritdoc />
        public void Add(T item)
        {
            InsertItem(Count, item);
        }

        /// <summary>
        /// Inserts an element into the <see cref="ListBase{T}"/> at the specified index.
        /// </summary>
        /// <param name="index">The object to insert. The value can be null for reference types.</param>
        /// <param name="item">The zero-based index at which value should be inserted.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/> is less than zero.-or-<paramref name="index"/> is equal to or greater than <see cref="Count"/>.</exception>
        /// <remarks>
        /// <b>Notes to Inheritors: </b>
        ///  Derived classes can override this method to change the behavior of the <see cref="Add"/> method.
        /// </remarks>
        protected virtual void InsertItem(int index, T item)
        {
            innerList.Insert(index, item);
        }


        /// <summary>
        /// Adds the elements of the specified collection to the end of the <see cref="ListBase{T}"></see>.
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the <see cref="ListBase{T}"></see>. The collection itself cannot be null, but it can contain elements that are null, if type T is a reference type.</param>
        /// <exception cref="ArgumentNullException">collection is null.</exception>
        public void AddRange(IEnumerable<T> collection)
        {
            AddRangeItems(collection);
        }
        /// <summary>
        /// Adds a range of items to the list.
        /// </summary>
        /// <param name="collection">The collection of items to add.</param>
        /// <remarks>
        /// 	<b>Notes to Inheritors: </b>
        /// Derived classes can override this method to change the behavior of the <see cref="AddRange"/> method.
        /// </remarks>
        virtual protected void AddRangeItems(IEnumerable<T> collection)
        {
            innerList.AddRange(collection);
        }

        /// <summary>
        /// Returns a read-only <see cref="IList{T}"></see> wrapper for the current collection.
        /// </summary>
        /// <returns>A <see cref="ReadOnlyCollection{T}"></see> that acts as a read-only wrapper around the current <see cref="ListBase{T}"></see>.</returns>
        public ReadOnlyCollection<T> AsReadOnly()
        {
            return new ReadOnlyCollection<T>(this);
        }

        /// <summary>
        /// Searches the entire sorted <see cref="ListBase{T}"></see> for an element using the default comparer and returns the zero-based index of the element.</summary>
        /// <returns>The zero-based index of value in the sorted <see cref="ListBase{T}"></see>, if value is found; otherwise, a negative number that is the bitwise complement of the index of the next element that is larger than value or, if there is no larger element, the bitwise complement of <see cref="ListBase{T}.Count"></see>.</returns>
        /// <param name="item">The object to locate. The value can be null for reference types.</param>
        /// <exception cref="InvalidOperationException">The default comparer <see cref="Comparer{T}.Default"></see> cannot find an implementation of the <see cref="IComparable{T}"></see> generic interface or the <see cref="IComparable"></see> interface for type T.</exception>
        public int BinarySearch(T item)
        {
            return innerList.BinarySearch(item);
        }

        /// <summary>
        /// Searches the entire sorted <see cref="ListBase{T}"></see> for an element using the specified comparer and returns the zero-based index of the element.</summary>
        /// <returns>The zero-based index of value in the sorted <see cref="ListBase{T}"></see>, if value is found; otherwise, a negative number that is the bitwise complement of the index of the next element that is larger than value or, if there is no larger element, the bitwise complement of <see cref="ListBase{T}.Count"></see>.</returns>
        /// <param name="item">The object to locate. The value can be null for reference types.</param>
        /// <param name="comparer">The <see cref="IComparer{T}"></see> implementation to use when comparing elements.-or-null to use the default comparer <see cref="Comparer{T}.Default"></see>.</param>
        /// <exception cref="InvalidOperationException">comparer is null, and the default comparer <see cref="Comparer{T}.Default"></see> cannot find an implementation of the <see cref="IComparable{T}"></see> generic interface or the <see cref="IComparable"></see> interface for type T.</exception>
        public int BinarySearch(T item, IComparer<T> comparer)
        {
            return innerList.BinarySearch(item, comparer);
        }

        /// <summary>
        /// Searches a range of elements in the sorted <see cref="ListBase{T}"></see> for an element using the specified comparer and returns the zero-based index of the element.
        /// </summary>
        /// <returns>The zero-based index of value in the sorted <see cref="ListBase{T}"></see>, if value is found; otherwise, a negative number that is the bitwise complement of the index of the next element that is larger than value or, if there is no larger element, the bitwise complement of <see cref="ListBase{T}.Count"></see>.</returns>
        /// <param name="count">The length of the range to search.</param>
        /// <param name="item">The object to locate. The value can be null for reference types.</param>
        /// <param name="index">The zero-based starting index of the range to search.</param>
        /// <param name="comparer">The <see cref="IComparer{T}"></see> implementation to use when comparing elements, or null to use the default comparer <see cref="Comparer{T}.Default"></see>.</param>
        /// <exception cref="ArgumentOutOfRangeException">index is less than 0.-or-count is less than 0. </exception>
        /// <exception cref="InvalidOperationException">comparer is null, and the default comparer <see cref="Comparer{T}.Default"></see> cannot find an implementation of the <see cref="IComparable{T}"></see> generic interface or the <see cref="IComparable"></see> interface for type T.</exception>
        /// <exception cref="ArgumentException">index and count do not denote a valid range in the <see cref="ListBase{T}"></see>.</exception>
        public int BinarySearch(int index, int count, T item, IComparer<T> comparer)
        {
            return innerList.BinarySearch(index, count, item, comparer);
        }

        /// <inheritdoc />
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
            innerList.Clear();
        }



        /// <inheritdoc />
        public bool Contains(T item)
        {
            return innerList.Contains(item);
        }

        /// <inheritdoc cref="List{T}.ConvertAll{TOutput}"/>
        public IList<TOutput> ConvertAll<TOutput>(Converter<T, TOutput> converter)
        {
            return innerList.ConvertAll(converter);
        }

        /// <inheritdoc cref="List{T}.CopyTo(T[])"/>
        public void CopyTo(T[] array)
        {
            innerList.CopyTo(array);
        }

        /// <inheritdoc />
        public void CopyTo(T[] array, int arrayIndex)
        {
            innerList.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Copies all items in the list to the specified array.
        /// </summary>
        /// <param name="index">The index to start from in the list.</param>
        /// <param name="array">The array to copy from.</param>
        /// <param name="arrayIndex">Index of the array.</param>
        /// <param name="count">The number of items to copy.</param>
        public void CopyTo(int index, T[] array, int arrayIndex, int count)
        {
            innerList.CopyTo(index, array, arrayIndex, count);
        }



        /// <inheritdoc cref="List{T}.ForEach"/>
        public void ForEach(Action<T> action)
        {
            innerList.ForEach(action);
        }


        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }


        /// <inheritdoc cref="List{T}.GetRange"/>
        public IList<T> GetRange(int index, int count)
        {
            return innerList.GetRange(index, count);
        }

        /// <inheritdoc />
        public int IndexOf(T item)
        {
            return innerList.IndexOf(item);
        }


        /// <inheritdoc cref="List{T}.IndexOf(T,int)"/>
        public int IndexOf(T item, int index)
        {
            return innerList.IndexOf(item, index);
        }


        /// <inheritdoc cref="List{T}.IndexOf(T,int,int)"/>
        public int IndexOf(T item, int index, int count)
        {
            return innerList.IndexOf(item, index, count);
        }

        /// <inheritdoc />
        public void Insert(int index, T item)
        {
            InsertItem(index, item);
        }


        /// <inheritdoc cref="List{T}.InsertRange"/>
        public void InsertRange(int index, IEnumerable<T> collection)
        {
            InsertRangeItems(index, collection);
        }

        /// <summary>
        /// Inserts items in the specified range, from the specified index.
        /// </summary>
        /// <param name="index">The index to start copying to.</param>
        /// <param name="collection">The collection to copy from.</param>
        /// <remarks>
        /// 	<b>Notes to Inheritors: </b>
        /// Derived classes can override this method to change the behavior of the <see cref="InsertRange"/> method.
        /// </remarks>
        protected virtual void InsertRangeItems(int index, IEnumerable<T> collection)
        {
            innerList.InsertRange(index, collection);
        }


        /// <inheritdoc cref="List{T}.LastIndexOf(T)"/>
        public int LastIndexOf(T item)
        {
            return innerList.LastIndexOf(item);
        }


        /// <inheritdoc cref="List{T}.LastIndexOf(T,int)"/>
        public int LastIndexOf(T item, int index)
        {
            return innerList.LastIndexOf(item, index);
        }


        /// <inheritdoc cref="List{T}.LastIndexOf(T,int,int)"/>
        public int LastIndexOf(T item, int index, int count)
        {
            return innerList.LastIndexOf(item, index, count);
        }

        /// <inheritdoc />
        public bool Remove(T item)
        {
            var index = innerList.IndexOf(item);
            if (index < 0)
            {
                return false;
            }
            RemoveItem(index, item);
            return true;

        }



        /// <summary>
        /// Removes the element at the specified index of the <see cref="ICollection{T}"/>.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        /// <param name="item">The object to remove from the <see cref="ICollection{T}"/>.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/> is less than zero.-or-<paramref name="index"/> is equal to or greater than <see cref="Count"/>.</exception>
        /// <remarks>
        /// <b>Notes to Inheritors: </b>
        ///  Derived classes can override this method to change the behavior of the <see cref="Remove"/> method.
        /// </remarks>
        protected virtual void RemoveItem(int index, T item)
        {
            innerList.RemoveAt(index);
        }

        /// <inheritdoc cref="List{T}.RemoveAll"/>
        public int RemoveAll(Predicate<T> match)
        {
            Guard.ArgumentNotNull(match, "match");
            var countRemoved = 0;

            var index = 0;
            while (index < Count)
            {
                var item = this[index];
                if (match(item))
                {
                    RemoveItem(index, item);
                    countRemoved++;
                }
                else
                {
                    index++;
                }
            }

            return (countRemoved);

        }

        /// <inheritdoc />
        public void RemoveAt(int index)
        {
            var item = innerList[index];
            RemoveItem(index, item);
        }


        /// <inheritdoc cref="List{T}.RemoveRange"/>
        public void RemoveRange(int index, int count)
        {

            RemoveRangeItems(index, count);
        }

        /// <summary>
        /// Removes the items in the specified range.
        /// </summary>
        /// <param name="index">The index to start from.</param>
        /// <param name="count">The number of items to remove.</param>
        /// <remarks>
        /// 	<b>Notes to Inheritors: </b>
        /// Derived classes can override this method to change the behavior of the <see cref="RemoveRange"/> method.
        /// </remarks>
        protected virtual void RemoveRangeItems(int index, int count)
        {
            innerList.RemoveRange(index, count);
        }


        /// <inheritdoc cref="List{T}.Reverse()"/>
        public void Reverse()
        {
            innerList.Reverse();
        }


        /// <inheritdoc cref="List{T}.Reverse(int,int)"/>
        public void Reverse(int index, int count)
        {
            innerList.Reverse(index, count);
        }

        /// <summary>
        /// Replaces the element at the specified index.
        /// </summary>
        /// <param name="index">The new value for the element at the specified index. The value can be null for reference types.</param>
        /// <param name="item">The zero-based index of the element to replace.</param>
        /// <exception cref="ArgumentOutOfRangeException">index is less than 0.-or-count is less than 0. </exception>
        /// <remarks>
        /// <b>Notes to Inheritors: </b>
        ///  Derived classes can override this method to change the behavior of the <see cref="SetItem"/> method.
        /// </remarks>
        protected virtual void SetItem(int index, T item)
        {
            innerList[index] = item;
        }


        /// <inheritdoc cref="List{T}.Sort()"/>
        public void Sort()
        {
            innerList.Sort();
        }



        /// <inheritdoc cref="List{T}.Sort(IComparer{T})"/>
        public void Sort(IComparer<T> comparer)
        {
            innerList.Sort(comparer);
        }




        /// <inheritdoc cref="List{T}.Sort(Comparison{T})"/>
        public void Sort(Comparison<T> comparison)
        {
            innerList.Sort(comparison);
        }




        /// <inheritdoc cref="List{T}.Sort(int,int,IComparer{T})"/>
        public void Sort(int index, int count, IComparer<T> comparer)
        {
            innerList.Sort(index, count, comparer);
        }



        /// <inheritdoc />
        void ICollection.CopyTo(Array array, int index)
        {
            ((ICollection)innerList).CopyTo(array, index);
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        /// <inheritdoc />
        int IList.Add(object value)
        {
            VerifyValueType(value);
            Add((T)value);
            return (Count - 1);

        }

        /// <inheritdoc />
        bool IList.Contains(object value)
        {
            return ((IList)innerList).Contains(value);
        }

        /// <inheritdoc />
        int IList.IndexOf(object value)
        {
            if (IsCompatibleObject(value))
            {
                return IndexOf((T)value);
            }
            return -1;

        }

        /// <inheritdoc />
        void IList.Insert(int index, object value)
        {
            VerifyValueType(value);
            InsertItem(index, (T)value);
        }

        /// <inheritdoc />
        void IList.Remove(object value)
        {
            if (IsCompatibleObject(value))
            {
                Remove((T)value);
            }
        }


        /// <inheritdoc cref="List{T}.ToArray"/>
        public T[] ToArray()
        {
            return innerList.ToArray();
        }


        /// <inheritdoc cref="List{T}.TrimExcess"/>
        public void TrimExcess()
        {
            innerList.TrimExcess();
        }





        /// <inheritdoc cref="List{T}.Capacity"/>
        public int Capacity
        {
            get
            {
                return innerList.Capacity;
            }
            set
            {
                innerList.Capacity = value;
            }
        }

        /// <inheritdoc />
        public int Count
        {
            get
            {
                return innerList.Count;
            }
        }

        /// <inheritdoc />
        public T this[int index]
        {
            get
            {
                return innerList[index];
            }
            set
            {
                SetItem(index, value);
            }
        }

        /// <inheritdoc />
        public bool IsSynchronized
        {
            get
            {
                return ((IList)innerList).IsSynchronized;
            }
        }
        /// <inheritdoc />
        public object SyncRoot
        {
            get
            {
                return ((IList)innerList).SyncRoot;
            }
        }

        /// <inheritdoc />
        public bool IsFixedSize
        {
            get
            {
                return ((IList)innerList).IsFixedSize;
            }
        }
        /// <inheritdoc />
        public bool IsReadOnly
        {
            get
            {
                return ((IList)innerList).IsReadOnly;
            }
        }
        /// <inheritdoc />
        object IList.this[int index]
        {
            get
            {
                return innerList[index];
            }
            set
            {
                VerifyValueType(value);
                SetItem(index, (T)value);

            }
        }

        private static void VerifyValueType(object value)
        {
            if (!IsCompatibleObject(value))
            {
                throw new ArgumentException("InvalidType");
            }
        }
        private static bool IsCompatibleObject(object value)
        {
            return (value is T) || ((value == null) && !typeof(T).IsValueType);
        }

    }

}