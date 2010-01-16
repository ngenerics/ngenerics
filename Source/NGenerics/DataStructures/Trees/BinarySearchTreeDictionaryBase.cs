/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using NGenerics.Comparers;
using NGenerics.Patterns.Visitor;

namespace NGenerics.DataStructures.Trees
{
    /// <summary>
    /// A base class for all binary trees that use an algorithm to speed access of nodes.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the tree.</typeparam>
    /// <typeparam name="TValue">The type of the values in the tree.</typeparam>
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
#if (!SILVERLIGHT)
    [Serializable]
#endif
    public abstract class BinarySearchTreeBase<TKey, TValue> : 
        BinarySearchTreeBase<KeyValuePair<TKey, TValue>>, 
        ISearchTreeDictionary<TKey, TValue>
    {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTreeBase&lt;TKey, TValue&gt;"/> class.
        /// </summary>
        protected BinarySearchTreeBase() : base(new KeyValuePairComparer<TKey, TValue>())
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTreeBase&lt;TKey, TValue&gt;"/> class.
        /// </summary>
        /// <param name="comparer">The comparer to use when comparing items.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        protected BinarySearchTreeBase(IComparer<TKey> comparer) : base(new KeyValuePairComparer<TKey, TValue>(comparer))
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTreeBase&lt;TKey, TValue&gt;"/> class.
        /// </summary>
        /// <param name="comparison">The comparison.</param>
        protected BinarySearchTreeBase(Comparison<TKey> comparison) : base(new KeyValuePairComparer<TKey, TValue>(comparison))
        {
            
        }

        #endregion
        
        #region Protected Members
        
        /// <summary>
        /// Finds the node containing the specified data key.
        /// </summary>
        /// <param name="key">The key to search for.</param>
		/// <returns>The node with the specified key if found.  If the key is not in the tree, this method returns null.</returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        protected virtual BinaryTree<KeyValuePair<TKey, TValue>> FindNode(TKey key)
        {
            return FindNode(new KeyValuePair<TKey,TValue>(key, default(TValue)));
        }
        
        #endregion

        #region Internal Members

       /// <summary>
        /// Manipulates the keys.
        /// </summary>
        /// <param name="manipulator">The manipulator.</param>
        internal void ManipulateKeys(Func<TKey, TKey> manipulator)
        {
            if (Tree != null)
            {
                var stack = new Stack<BinaryTree<KeyValuePair<TKey, TValue>>>();

                stack.Push(Tree);

                while (stack.Count > 0)
                {
                    var binaryTree = stack.Pop();

                    binaryTree.Data = new KeyValuePair<TKey, TValue>(manipulator(binaryTree.Data.Key), binaryTree.Data.Value);

                    if (binaryTree.Left != null)
                    {
                        stack.Push(binaryTree.Left);
                    }

                    if (binaryTree.Right != null)
                    {
                        stack.Push(binaryTree.Right);
                    }
                }
            }

        }

        #endregion
        
        #region IDictionary<TKey,TValue> Members

        /// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Trees\BinarySearchTreeBaseExamples.cs" region="Remove" lang="cs" title="The following example shows how to use the Remove method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Trees\BinarySearchTreeBaseExamples.vb" region="Remove" lang="vbnet" title="The following example shows how to use the Remove method."/>
        /// </example>
        public bool Remove(TKey key) {
            return Remove(new KeyValuePair<TKey,TValue>(key, default(TValue)));
        }

		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Trees\BinarySearchTreeBaseExamples.cs" region="Add" lang="cs" title="The following example shows how to use the Add method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Trees\BinarySearchTreeBaseExamples.vb" region="Add" lang="vbnet" title="The following example shows how to use the Add method."/>
        /// </example>
        public void Add(TKey key, TValue value)
        {
            Add(new KeyValuePair<TKey,TValue>(key, value));
        }
        

		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Trees\BinarySearchTreeBaseExamples.cs" region="ContainsKey" lang="cs" title="The following example shows how to use the ContainsKey method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Trees\BinarySearchTreeBaseExamples.vb" region="ContainsKey" lang="vbnet" title="The following example shows how to use the ContainsKey method."/>
        /// </example>
        public bool ContainsKey(TKey key)
        {
            return (FindNode(key) != null);
        }


        /// <summary>
        /// Gets an <see cref="T:System.Collections.Generic.ICollection`1"/> containing the keys of the <see cref="T:System.Collections.Generic.IDictionary`2"/>.
        /// </summary>
        /// <value></value>
        /// <example>
        /// 	<code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Trees\BinarySearchTreeBaseExamples.cs" region="Keys" lang="cs" title="The following example shows how to use the Keys property."/>
        /// 	<code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Trees\BinarySearchTreeBaseExamples.vb" region="Keys" lang="vbnet" title="The following example shows how to use the Keys property."/>
        /// </example>
        public ICollection<TKey> Keys
        {
            get
            {
                // Get the keys in sorted order
                var visitor = new KeyTrackingVisitor<TKey, TValue>();
                var inOrderVisitor = new InOrderVisitor<KeyValuePair<TKey, TValue>>(visitor);
                DepthFirstTraversal(inOrderVisitor);
                return new ReadOnlyCollection<TKey>(visitor.TrackingList);
            }
        }


		

		/// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Trees\BinarySearchTreeBaseExamples.cs" region="TryGetValue" lang="cs" title="The following example shows how to use the TryGetValue method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Trees\BinarySearchTreeBaseExamples.vb" region="TryGetValue" lang="vbnet" title="The following example shows how to use the TryGetValue method."/>
        /// </example>
        public bool TryGetValue(TKey key, out TValue value)
        {
            var node = FindNode(key);

            if (node == null)
            {
                value = default(TValue);
                return false;
            }
		    
            value = node.Data.Value;
		    return true;
        }

        /// <summary>
        /// Gets an <see cref="T:System.Collections.Generic.ICollection`1"/> containing the values in the <see cref="T:System.Collections.Generic.IDictionary`2"/>.
        /// </summary>
        /// <value></value>
        /// <example>
        /// 	<code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Trees\BinarySearchTreeBaseExamples.cs" region="Values" lang="cs" title="The following example shows how to use the Values property."/>
        /// 	<code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Trees\BinarySearchTreeBaseExamples.vb" region="Values" lang="vbnet" title="The following example shows how to use the Values property."/>
        /// </example>
        public ICollection<TValue> Values
        {
            get
            {
                var visitor = new ValueTrackingVisitor<TKey, TValue>();
                var inOrderVisitor = new InOrderVisitor<KeyValuePair<TKey, TValue>>(visitor);

                DepthFirstTraversal(inOrderVisitor);

                return new ReadOnlyCollection<TValue>(visitor.TrackingList);
            }
        }


        /// <summary>
        /// Gets or sets the value with the specified key.
        /// </summary>
        /// <value>The key of the item to set or get.</value>
        public TValue this[TKey key]
        {
            get
            {
                var node = FindNode(key);

                if (node == null)
                {
                    throw new KeyNotFoundException("key");
                }

                return node.Data.Value;
            }
            set
            {
                var node = FindNode(key);

                if (node == null)
                {
                    throw new KeyNotFoundException("key");
                }

                node.Data = new KeyValuePair<TKey,TValue>(key, value);
            }
        }

        #endregion

        #region ICollection<KeyValuePair<TKey,TValue>> Members
        
        /// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Trees\BinarySearchTreeBaseExamples.cs" region="Contains" lang="cs" title="The following example shows how to use the Contains method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Trees\BinarySearchTreeBaseExamples.vb" region="Contains" lang="vbnet" title="The following example shows how to use the Contains method."/>
        /// </example>
        public override bool Contains(KeyValuePair<TKey, TValue> item) {
            var node = FindNode(item);
            return node != null && item.Value.Equals(node.Data.Value);
        }

		


        #endregion
    }
}