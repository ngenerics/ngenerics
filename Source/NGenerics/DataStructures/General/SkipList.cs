/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using System.Collections.Generic;
using System.Collections;
using NGenerics.Util;
using System.Diagnostics.CodeAnalysis;
using NGenerics.Comparers;

namespace NGenerics.DataStructures.General
{
    /// <summary>
    /// A Skip List data structure
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
#if (!SILVERLIGHT)
    [Serializable]
#endif
    public class SkipList<TKey, TValue> : IDictionary<TKey, TValue>
    {
        #region Globals

        private readonly IComparer<TKey> comparerToUse;
        private readonly int maximumLevelToUse;
        private readonly double probabilityToUse;
        private readonly SkipListNode<TKey, TValue>[] headNodes;
        private readonly SkipListNode<TKey, TValue> tail = new SkipListNode<TKey, TValue>();

        internal const int defaultMaximumLevel = 16;
        internal const double defaultProbability = 0.5;

        // Initialise the random number generator with the current time.
        private readonly Random rand = new Random(Convert.ToInt32(DateTime.Now.Ticks % Int32.MaxValue));

        #endregion

        #region Construction

        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SkipListExamples.cs" region="Constructor" lang="cs" title="The following example shows how to use the default constructor."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SkipListExamples.vb" region="Constructor" lang="vbnet" title="The following example shows how to use the default constructor."/>
        /// </example>
        public SkipList() : this(defaultMaximumLevel, defaultProbability, Comparer<TKey>.Default) { }

        /// <param name="comparer">The comparer.</param>
		/// <exception cref="ArgumentNullException"><paramref name="comparer"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
		/// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SkipListExamples.cs" region="ConstructorComparer" lang="cs" title="The following example shows how to use the comparer constructor."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SkipListExamples.vb" region="ConstructorComparer" lang="vbnet" title="The following example shows how to use the comparer constructor."/>
        /// </example>
        public SkipList(IComparer<TKey> comparer) : this(defaultMaximumLevel, defaultProbability, comparer) { }


        /// <summary>
        /// Initializes a new instance of the <see cref="SkipList&lt;TKey, TValue&gt;"/> class.
        /// </summary>
        /// <param name="comparison">The comparison.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparison"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        public SkipList(Comparison<TKey> comparison) : this(defaultMaximumLevel, defaultProbability, new ComparisonComparer<TKey>(comparison)) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SkipList&lt;TKey, TValue&gt;"/> class.
        /// </summary>
        /// <param name="maximumLevel">The maximum level.</param>
        /// <param name="probability">The probability.</param>
        /// <param name="comparison">The comparison.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparison"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="maximumLevel"/> is less than 1.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="probability"/> is less than 0.1.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="probability"/> is greater than 0.9.</exception>
        public SkipList(int maximumLevel, double probability, Comparison<TKey> comparison) : this(maximumLevel, probability, new ComparisonComparer<TKey>(comparison)) { }

        /// <param name="maximumLevel">The maximum level.</param>
        /// <param name="probability">The probability.</param>
        /// <param name="comparer">The comparer.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="maximumLevel"/> is less than 1.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="probability"/> is less than 0.1.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="probability"/> is greater than 0.9.</exception>
        public SkipList(int maximumLevel, double probability, IComparer<TKey> comparer)
        {
            #region Validation

            if (maximumLevel < 1)
            {
                throw new ArgumentOutOfRangeException("maximumLevel", "The maximum level must be bigger than 0.");
            }

            Guard.ArgumentNotNull(comparer, "comparer");

            if ((probability > 0.9) || (probability < 0.1))
            {
                throw new ArgumentOutOfRangeException("probability", "The probability must be between 0.1 and 0.9");
            }

            #endregion

            comparerToUse = comparer;
            maximumLevelToUse = maximumLevel;
            probabilityToUse = probability;

            // Initialise the skip list to empty nodes, and link the heads and the tails
            headNodes = new SkipListNode<TKey, TValue>[maximumLevel];

            headNodes[0] = new SkipListNode<TKey, TValue> {Right = tail};

            for (var i = 1; i < maximumLevel; i++)
            {
                headNodes[i] = new SkipListNode<TKey, TValue> {Down = headNodes[i - 1], Right = tail};
                //headNodes[i - 1].Up = headNodes[i];
            }
        }

        #endregion

        #region ICollection<T> Members


		/// <inheritdoc />  
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SkipListExamples.cs" region="IsEmpty" lang="cs" title="The following example shows how to use the IsEmpty property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SkipListExamples.vb" region="IsEmpty" lang="vbnet" title="The following example shows how to use the IsEmpty property."/>
        /// </example>
        public bool IsEmpty
        {
            get
            {
                return Count == 0;
            }
        }

        #endregion

        #region ICollection<T> Members

        /// <inheritdoc />  
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SkipListExamples.cs" region="Count" lang="cs" title="The following example shows how to use the Count property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SkipListExamples.vb" region="Count" lang="vbnet" title="The following example shows how to use the Count property."/>
        /// </example>
        public int Count { get; private set; }


        /// <inheritdoc />  
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SkipListExamples.cs" region="IsReadOnly" lang="cs" title="The following example shows how to use the IsReadOnly property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SkipListExamples.vb" region="IsReadOnly" lang="vbnet" title="The following example shows how to use the IsReadOnly property."/>
        /// </example>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

		/// <inheritdoc />  
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SkipListExamples.cs" region="AddKeyValue" lang="cs" title="The following example shows how to use the AddKeyValue method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SkipListExamples.vb" region="AddKeyValue" lang="vbnet" title="The following example shows how to use the AddKeyValue method."/>
        /// </example>
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

		/// <inheritdoc />  
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SkipListExamples.cs" region="Clear" lang="cs" title="The following example shows how to use the Clear method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SkipListExamples.vb" region="Clear" lang="vbnet" title="The following example shows how to use the Clear method."/>
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
            // Set all the heads' references to the tail to eliminate the items in between
            for (var i = 0; i < maximumLevelToUse; i++)
            {
                headNodes[i].Right = tail;
            }

            Count = 0;
        }

		/// <inheritdoc />  	
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SkipListExamples.cs" region="ContainsKeyValue" lang="cs" title="The following example shows how to use the ContainsKeyValue method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SkipListExamples.vb" region="ContainsKeyValue" lang="vbnet" title="The following example shows how to use the ContainsKeyValue method."/>
        /// </example>
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            var node = Find(item.Key);

            return node != null && node.Value.Equals(item.Value);
        }

		/// <inheritdoc />  
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SkipListExamples.cs" region="CopyTo" lang="cs" title="The following example shows how to use the CopyTo method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SkipListExamples.vb" region="CopyTo" lang="vbnet" title="The following example shows how to use the CopyTo method."/>
        /// </example>
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            #region Validation

            Guard.ArgumentNotNull(array, "array");

            if ((array.Length - arrayIndex) < Count)
            {
                throw new ArgumentException(Constants.NotEnoughSpaceInTheTargetArray, "array");
            }

            #endregion

            foreach (var item in this)
            {
                array.SetValue(item, arrayIndex++);
            }
        }

		/// <inheritdoc />  
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return Remove(item.Key);
        }

        #endregion

        #region IDictionary<T> Members


        /// <summary>
        /// Gets an <see cref="T:System.Collections.Generic.ICollection`1"/> containing the keys of the <see cref="T:System.Collections.Generic.IDictionary`2"/>.
        /// </summary>
        /// <value></value>
        /// <example>
        /// 	<code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SkipListExamples.cs" region="Keys" lang="cs" title="The following example shows how to use the Keys property."/>
        /// 	<code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SkipListExamples.vb" region="Keys" lang="vbnet" title="The following example shows how to use the Keys property."/>
        /// </example>
        public ICollection<TKey> Keys
        {
            get
            {
                // Start at the bottom level and add all the keys to the return array.
                var startNode = headNodes[0];
                var keys = new TKey[Count];

                for (var i = 0; i < Count; i++)
                {
                    startNode = startNode.Right;
                    keys[i] = startNode.Key;
                }

                return keys;
            }
        }


        /// <summary>
        /// Gets an <see cref="T:System.Collections.Generic.ICollection`1"/> containing the values in the <see cref="T:System.Collections.Generic.IDictionary`2"/>.
        /// </summary>
        /// <value></value>
        /// <example>
        /// 	<code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SkipListExamples.cs" region="Values" lang="cs" title="The following example shows how to use the Values property."/>
        /// 	<code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SkipListExamples.vb" region="Values" lang="vbnet" title="The following example shows how to use the Values property."/>
        /// </example>
        public ICollection<TValue> Values
        {
            get
            {
                // Start at the bottom level and add all the values to the return array.
                var startNode = headNodes[0];
                var values = new TValue[Count];

                for (var i = 0; i < Count; i++)
                {
                    startNode = startNode.Right;
                    values[i] = startNode.Value;
                }

                return values;
            }
        }

        /// <summary>
        /// Gets or sets the value with the specified key.
        /// </summary>
        /// <value></value>
        /// <example>
        /// 	<code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SkipListExamples.cs" region="Item" lang="cs" title="The following example shows how to use the Item property."/>
        /// 	<code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SkipListExamples.vb" region="Item" lang="vbnet" title="The following example shows how to use the Item property."/>
        /// </example>
        public TValue this[TKey key]
        {
            get
            {
                var node = Find(key);

                if (node == null)
                {
                    throw new KeyNotFoundException("key");
                }
                
                return node.Value;
            }
            set
            {
                var node = Find(key);

                if (node == null)
                {
                    throw new KeyNotFoundException("key");
                }
                
                node.Value = value;
            }
        }

		/// <inheritdoc />  
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SkipListExamples.cs" region="Add" lang="cs" title="The following example shows how to use the Add method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SkipListExamples.vb" region="Add" lang="vbnet" title="The following example shows how to use the Add method."/>
        /// </example>
        public void Add(TKey key, TValue value)
        {
           AddItem(key,value);
		}
        
        /// <summary>
        /// Adds the item to the collection.
        /// </summary>
        /// <param name="key">The key of the item.</param>
        /// <param name="value">The value to add to the colleciton.</param>
        /// <remarks>
        /// 	<b>Notes to Inheritors: </b>
        /// Derived classes can override this method to change the behavior of the <see cref="Add(TKey,TValue)"/> method.
        /// </remarks>
        protected virtual void AddItem(TKey key, TValue value)
        {
            var rightNodes = FindRightMostNodes(key);

            // Check if the item already exists in the list.  If it does, throw an exception -
            // we will not allow duplicate items here.
            if ((rightNodes[0].Right != tail) && (comparerToUse.Compare(rightNodes[0].Right.Key, key) == 0))
            {
                throw new ArgumentException("The item is already in the list.", "key");
            }
		    
            var newLevel = PickRandomLevel();

		    if (newLevel > CurrentListLevel)
		    {
		        for (var i = CurrentListLevel + 1; i <= newLevel; i++)
		        {
		            rightNodes[i] = headNodes[i];
		        }

		        CurrentListLevel = newLevel;
		    }

		    var newNode = new SkipListNode<TKey, TValue>(key, value) {Right = rightNodes[0].Right}; 

		    // Insert the item in the first level
		    rightNodes[0].Right = newNode;

		    // And now insert the node in the rest of the levels, making sure
		    // to update the the links
		    for (var i = 1; i <= CurrentListLevel; i++)
		    {

		        var previousNode = newNode;
		        newNode = new SkipListNode<TKey, TValue>(key, value) {Right = rightNodes[i].Right};

		        rightNodes[i].Right = newNode;

		        newNode.Down = previousNode;
		    }
		    Count++;
        }

		/// <inheritdoc />  
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SkipListExamples.cs" region="ContainsKey" lang="cs" title="The following example shows how to use the ContainsKey method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SkipListExamples.vb" region="ContainsKey" lang="vbnet" title="The following example shows how to use the ContainsKey method."/>
        /// </example>
        public bool ContainsKey(TKey key)
        {
            return Find(key) != null;
        }

		/// <inheritdoc />  
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SkipListExamples.cs" region="Remove" lang="cs" title="The following example shows how to use the Remove method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SkipListExamples.vb" region="Remove" lang="vbnet" title="The following example shows how to use the Remove method."/>
        /// </example>
        public bool Remove(TKey key)
        {
		    return RemoveItem(key);
        }

        /// <summary>
        /// Removes the item from the collection.
        /// </summary>
        /// <param name="key">The key to remove.</param>
        /// <returns></returns>
        /// <remarks>
        /// 	<b>Notes to Inheritors: </b>
        /// Derived classes can override this method to change the behavior of the <see cref="Remove(TKey)"/> method.
        /// </remarks>
        protected virtual bool RemoveItem(TKey key)
        {
            var rightNodes = FindRightMostNodes(key);

            // See if we actually found the node
            if ((rightNodes[0].Right != tail) && (comparerToUse.Compare(rightNodes[0].Right.Key, key) == 0))
            {
                for (var i = 0; i <= CurrentListLevel; i++)
                {
                    // Since the node is consecutive levels, as soon as we don't find it on the next
                    // level, we can stop.
                    if ((rightNodes[i].Right != tail) && (comparerToUse.Compare(rightNodes[i].Right.Key, key) == 0))
                    {
                        rightNodes[i].Right = rightNodes[i].Right.Right;
                    }
                    else
                    {
                        break;
                    }
                }

                Count--;
                return true;
            }
		    
            return false;
        }

		/// <inheritdoc />  
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SkipListExamples.cs" region="TryGetValue" lang="cs" title="The following example shows how to use the TryGetValue method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SkipListExamples.vb" region="TryGetValue" lang="vbnet" title="The following example shows how to use the TryGetValue method."/>
        /// </example>
        public bool TryGetValue(TKey key, out TValue value)
        {
            var node = Find(key);

            if (node == null)
            {
                value = default(TValue);
                return false;
            }
		    
            value = node.Value;
		    return true;
        }

        #endregion

        #region IEnumerable<KeyValuePair<TKey, TValue>> Members


        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        /// <example>
        /// 	<code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SkipListExamples.cs" region="GetEnumerator" lang="cs" title="The following example shows how to use the GetEnumerator method."/>
        /// 	<code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SkipListExamples.vb" region="GetEnumerator" lang="vbnet" title="The following example shows how to use the GetEnumerator method."/>
        /// </example>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            // Start at the bottom level and add all the keys to the return array.
            var startNode = headNodes[0];

            while (startNode.Right != tail)
            {
                startNode = startNode.Right;
                yield return new KeyValuePair<TKey, TValue>(startNode.Key, startNode.Value);
            }
        }

        #endregion

        #region IEnumerable Members
		/// <inheritdoc />  
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Gets the comparer used to compare items in this instance.
        /// </summary>
        /// <value>The comparer.</value>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SkipListExamples.cs" region="Comparer" lang="cs" title="The following example shows how to use the Comparer property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SkipListExamples.vb" region="Comparer" lang="vbnet" title="The following example shows how to use the Comparer property."/>
        /// </example>
        public IComparer<TKey> Comparer
        {
            get
            {
                return comparerToUse;
            }
        }

        /// <summary>
        /// Gets the probability.
        /// </summary>
        /// <value>The probability.</value>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SkipListExamples.cs" region="Probability" lang="cs" title="The following example shows how to use the Probability property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SkipListExamples.vb" region="Probability" lang="vbnet" title="The following example shows how to use the Probability property."/>
        /// </example>
        public double Probability
        {
            get
            {
                return probabilityToUse;
            }
        }

        /// <summary>
        /// Gets the maximum level.
        /// </summary>
        /// <value>The maximum level.</value>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SkipListExamples.cs" region="MaximumListLevel" lang="cs" title="The following example shows how to use the MaximumListLevel property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SkipListExamples.vb" region="MaximumListLevel" lang="vbnet" title="The following example shows how to use the MaximumListLevel property."/>
        /// </example>
        public int MaximumListLevel
        {
            get
            {
                return maximumLevelToUse;
            }
        }

        /// <summary>
        /// Gets the current list level.
        /// </summary>
        /// <value>The current list level.</value>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\General\SkipListExamples.cs" region="CurrentListLevel" lang="cs" title="The following example shows how to use the CurrentListLevel property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\General\SkipListExamples.vb" region="CurrentListLevel" lang="vbnet" title="The following example shows how to use the CurrentListLevel property."/>
        /// </example>
        public int CurrentListLevel { get; private set; }

        #endregion

        #region Private Members

        private SkipListNode<TKey, TValue> Find(TKey key)
        {
            if (Count == 0)
            {
                return null;
            }
            
            // Start at the top list header node
            var currentNode = headNodes[CurrentListLevel];

            while (true)
            {
                while ((currentNode.Right != tail) && (comparerToUse.Compare(currentNode.Right.Key, key) < 0))
                {
                    currentNode = currentNode.Right;
                }

                // Check if there is a next level, and if there is move down.
                if (currentNode.Down == null)
                {
                    break;
                }
                
                currentNode = currentNode.Down;
            }

            // Do one final comparison to see if the key to the right equals this key.
            // If it doesn't match, it would be bigger than this key.
            if (comparerToUse.Compare(currentNode.Right.Key, key) == 0)
            {
                return currentNode.Right;
            }
            else
            {
                return null;
            }
        }

        private int PickRandomLevel()
        {
            var randomLevel = 0;

            while ((rand.NextDouble() < probabilityToUse) && (randomLevel <= CurrentListLevel + 1) && (randomLevel < maximumLevelToUse))
            {
                randomLevel++;
            }

            return randomLevel;
        }

        private SkipListNode<TKey, TValue>[] FindRightMostNodes(TKey key)
        {
            var rightNodes = new SkipListNode<TKey, TValue>[maximumLevelToUse];

            // Start at the top list header node
            var currentNode = headNodes[CurrentListLevel];

            for (var i = CurrentListLevel; i >= 0; i--)
            {
                while ((currentNode.Right != tail) && (comparerToUse.Compare(currentNode.Right.Key, key) < 0))
                {
                    currentNode = currentNode.Right;
                }

                // Store this node - the new node will be to the right of it.
                rightNodes[i] = currentNode;

                // Check if there is a next level, and if there is move down.
                if (i > 0)
                {
                    currentNode = currentNode.Down;
                }
            }
            return rightNodes;
        }

        #endregion
    }
}