/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
#if (!SILVERLIGHT)
using System.Runtime.Serialization;
#endif
using NGenerics.Util;

namespace NGenerics.DataStructures.General
{
	/// <summary>
	/// A Dictionary that accepts multiple values for a unique key.
	/// </summary>
	/// <typeparam name="TKey">The type of the keys in the HashList.</typeparam>
    /// <typeparam name="TValue">The type of the values in the HashList.</typeparam>
#if (!SILVERLIGHT)
    [Serializable]
#endif
	[SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
    public class HashList<TKey, TValue> : DictionaryBase<TKey, IList<TValue>>
	{
		#region Construction

        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\HashListExamples.cs" region="Constructor" lang="cs" title="The following example shows how to use the default constructor."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\HashListExamples.vb" region="Constructor" lang="vbnet" title="The following example shows how to use the default constructor."/>
        /// </example>     
		public HashList()
		{
		}


		/// <param name="dictionary">The dictionary.</param>
		/// <exception cref="ArgumentException"><paramref name="dictionary"/> contains one or more duplicate keys. </exception>
		/// <exception cref="ArgumentNullException"><paramref name="dictionary"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
		[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
		public HashList(IDictionary<TKey, IList<TValue>> dictionary) : base(dictionary)
		{
		}


        /// <param name="comparer">The comparer.</param>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\HashListExamples.cs" region="ConstructorComparer" lang="cs" title="The following example shows how to use the comparer constructor."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\HashListExamples.vb" region="ConstructorComparer" lang="vbnet" title="The following example shows how to use the comparer constructor."/>
        /// </example> 
		public HashList(IEqualityComparer<TKey> comparer) : base(comparer)
		{
		}


		/// <param name="capacity">The capacity.</param>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="capacity"/> is less than 0.</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\HashListExamples.cs" region="ConstructorCapacity" lang="cs" title="The following example shows how to use the capacity constructor."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\HashListExamples.vb" region="ConstructorCapacity" lang="vbnet" title="The following example shows how to use the capacity constructor."/>
        /// </example> 
		public HashList(int capacity) : base(capacity)
		{
		}


		/// <param name="capacity">The capacity.</param>
		/// <param name="comparer">The comparer.</param>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="capacity"/> is less than 0.</exception>
		public HashList(int capacity, IEqualityComparer<TKey> comparer) : base(capacity, comparer)
		{
        }


#if (!SILVERLIGHT)
        /// <param name="info">A <see cref="SerializationInfo"/> object containing the information required to serialize the <see cref="Dictionary{TKey,TValue}"/>.</param>
		/// <param name="context">A <see cref="StreamingContext"/> structure containing the source and destination of the serialized stream associated with the <see cref="Dictionary{TKey,TValue}"/>.</param>
		protected HashList(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

#endif
        #endregion

        #region Public Members

        /// <summary>
		/// Gets the count of values in this HashList.
		/// </summary>
		/// <value>The count of values.</value>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\HashListExamples.cs" region="ValueCount" lang="cs" title="The following example shows how to use the ValueCount property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\HashListExamples.vb" region="ValueCount" lang="vbnet" title="The following example shows how to use the ValueCount property."/>
        /// </example>
		public int ValueCount
		{
			get
			{
				var count = 0;

				foreach (var item in this)
				{
					if (item.Value != null)
					{
						count += item.Value.Count;
					}
				}

				return count;
			}
		}

		/// <summary>
		/// Gets the count of values in this HashList.
		/// </summary>
        /// <value>The count of values.</value>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\HashListExamples.cs" region="KeyCount" lang="cs" title="The following example shows how to use the KeyCount property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\HashListExamples.vb" region="KeyCount" lang="vbnet" title="The following example shows how to use the KeyCount property."/>
        /// </example>
		public int KeyCount
		{
			get
			{
				return Count;
			}
		}


		/// <summary>
		/// Gets an enumerator for enumerating though values.
		/// </summary>
        /// <returns>A enumerator for enumerating through values in the <see cref="HashList{TKey,TValue}"/>.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\HashListExamples.cs" region="GetValueEnumerator" lang="cs" title="The following example shows how to use the GetValueEnumerator method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\HashListExamples.vb" region="GetValueEnumerator" lang="vbnet" title="The following example shows how to use the GetValueEnumerator method."/>
        /// </example>
		[SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
		public IEnumerator<TValue> GetValueEnumerator()
		{
			// Note : Can not use using {} for the enumerator here.
			// It appears that a reference is kept to the enumerator and the enumeration only happens
			// after the enumerator has been disposed - some interesting behaviour follows.  To do : Investigate IL.
			// Note : Important to specify full type name for enumerator (Dictionary<TKey, IList<TValue>>.Enumerator)
			// for mono support.  Do not remove.

			foreach (var keyValuePair in this)
			{
				var value = keyValuePair.Value;
				if (value != null)
				{
					for (var i = 0; i < value.Count; i++)
					{
						yield return value[i];
					}
				}
			}
		}


		/// <summary>
		/// Adds the specified key.
		/// </summary>
		/// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\HashListExamples.cs" region="Add" lang="cs" title="The following example shows how to use the Add method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\HashListExamples.vb" region="Add" lang="vbnet" title="The following example shows how to use the Add method."/>
        /// </example>
		public void Add(TKey key, TValue value)
		{
			AddItem(new KeyValuePair<TKey, TValue>(key, value));
		}

        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="item">The item.</param>
		public virtual void AddItem(KeyValuePair<TKey, TValue>  item)
		{
			IList<TValue> list;

			if (!TryGetValue(item.Key, out list))
			{
				list = new List<TValue>();
				this[item.Key] = list;
			}

			list.Add(item.Value);
		}

		/// <summary>
		/// Adds the specified key.
		/// </summary>
		/// <param name="key">The key.</param>
        /// <param name="values">The values.</param>   
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\HashListExamples.cs" region="AddParams" lang="cs" title="The following example shows how to use the Add method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\HashListExamples.vb" region="AddParams" lang="vbnet" title="The following example shows how to use the Add method."/>
        /// </example>     
        public void Add(TKey key, params TValue[] values)
		{

            Add(key, new List<TValue>(values));
		}


		/// <inheritdoc />
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
		protected override void AddItem(TKey key, IList<TValue>  value)
        {
			
            Guard.ArgumentNotNull(value, "value");
            //no need to check key for null ContainsKey will do that.
			IList<TValue> list;

			if (!TryGetValue(key, out list))
			{
				list = new List<TValue>();
				this[key] = list;
			}

			((List<TValue>) list).AddRange(value);
		}


		/// <summary>
		/// Removes the first occurrence of the value found.
		/// </summary>
		/// <param name="item">The item.</param>
		/// <returns>A indication of whether the item has been found (and removed) in the Hash IList.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\HashListExamples.cs" region="RemoveValue" lang="cs" title="The following example shows how to use the RemoveValue method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\HashListExamples.vb" region="RemoveValue" lang="vbnet" title="The following example shows how to use the RemoveValue method."/>
        /// </example>     
		public bool RemoveValue(TValue item)
		{
			return RemoveValueItem(item);
		}

        /// <summary>
        /// Removes the first instance found of the value specified from the HashList.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>A value indicating whether or not an item matching the criteria was found and removed.</returns>
        /// <remarks>
        /// 	<b>Notes to Inheritors: </b>
        /// Derived classes can override this method to change the behavior of the <see cref="RemoveValue"/> method.
        /// </remarks>
	    protected virtual bool RemoveValueItem(TValue item)
	    {
	        IList<TKey> keys = new List<TKey>(Keys);

	        for (var i = 0; i < keys.Count; i++)
	        {
	            var values = this[keys[i]];

	            if (values.Remove(item))
	            {
	                return true;
	            }
	        }
	        return false;
	    }


	    /// <summary>
		/// Removes all the occurrences of the item in the HashList
		/// </summary>
        /// <param name="item">The item.</param>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\HashListExamples.cs" region="RemoveAll" lang="cs" title="The following example shows how to use the RemoveAll method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\HashListExamples.vb" region="RemoveAll" lang="vbnet" title="The following example shows how to use the RemoveAll method."/>
        /// </example>     
		public void RemoveAll(TValue item)
		{
			RemoveAllItems(item);
		}

        /// <summary>
        /// Removes all the specified values from the HashList.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <remarks>
        /// 	<b>Notes to Inheritors: </b>
        /// Derived classes can override this method to change the behavior of the <see cref="RemoveAll"/> method.
        /// </remarks>
		protected virtual void RemoveAllItems(TValue item)
		{
			IList<TKey> keys = new List<TKey>(Keys);

			for (var i = 0; i < keys.Count; i++)
			{
				var values = this[keys[i]];

				if (values != null)
				{
					for (var j = 0; j < values.Count; j++)
					{
						if (values[j].Equals(item))
						{
							values.RemoveAt(j);
							j--;
						}
					}
				}
			}
		}


		/// <summary>
		/// Removes all the occurrences of the item in the HashList
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="item">The item.</param>
        /// <returns>An indication of whether the key and value pair has been found (and removed).</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\HashListExamples.cs" region="RemoveKeyValue" lang="cs" title="The following example shows how to use the RemoveAll method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\HashListExamples.vb" region="RemoveKeyValue" lang="vbnet" title="The following example shows how to use the RemoveAll method."/>
        /// </example>     
		public bool Remove(TKey key, TValue item)
		{
		    return RemoveItem(key, item);
		}

        /// <summary>
        /// Removes the item from this instance.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="item">The item to remove.</param>
        /// <returns></returns>
        /// <remarks>
        /// 	<b>Notes to Inheritors: </b>
        /// Derived classes can override this method to change the behavior of the <see cref="Remove"/> method.
        /// </remarks>
        protected virtual bool RemoveItem(TKey key, TValue item)
        {
            IList<TValue> values;
            return TryGetValue(key, out values) && values.Remove(item);
        }

	    #endregion
	}
}