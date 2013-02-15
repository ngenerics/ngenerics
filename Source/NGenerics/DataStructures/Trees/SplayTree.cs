/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/



using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace NGenerics.DataStructures.Trees
{
    /// <summary>
    /// An implementation of a Splay Tree data structure.
    /// </summary>
    /// <remarks>
    /// http://en.wikipedia.org/wiki/Splay_tree
    /// </remarks>
    /// <typeparam name="TKey">The type of the keys in the <see cref="SplayTree{TKey,TValue}"/>.</typeparam>
    /// <typeparam name="TValue">The type of the values in the <see cref="SplayTree{TKey,TValue}"/>.</typeparam>
	[SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
    [Serializable]
    public class SplayTree<TKey, TValue> : BinarySearchTreeBase<TKey, TValue>
    {
        #region Globals

        private static readonly KeyValuePair<TKey, TValue> nullPair = new KeyValuePair<TKey, TValue>();

        #endregion

        #region Construction

        /// <inheritdoc />
        public SplayTree()
        {
        }


        /// <inheritdoc />
        public SplayTree(IComparer<TKey> comparer)
            : base(comparer)
        {
        }

        /// <inheritdoc />
        public SplayTree(Comparison<TKey> comparison)
            : base(comparison)
        {
        }

        #endregion

        #region Public Members


        /// <inheritdoc/>
        /// <example>
        /// 	<code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Trees\BinarySearchTreeBaseExamples.cs" region="Maximum" lang="cs" title="The following example shows how to use the Maximum property."/>
        /// 	<code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Trees\BinarySearchTreeBaseExamples.vb" region="Maximum" lang="vbnet" title="The following example shows how to use the Maximum property."/>
        /// </example>
        public override KeyValuePair<TKey, TValue> Maximum
        {
            get
            {
                var max = base.Maximum;
                Splay(max);
                return max;
            }
        }


        /// <inheritdoc/>
        /// <example>
        /// 	<code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Trees\BinarySearchTreeBaseExamples.cs" region="Minimum" lang="cs" title="The following example shows how to use the Minimum property."/>
        /// 	<code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Trees\BinarySearchTreeBaseExamples.vb" region="Minimum" lang="vbnet" title="The following example shows how to use the Minimum property."/>
        /// </example>
        public override KeyValuePair<TKey, TValue> Minimum
        {
            get
            {
                var min = base.Minimum;
                Splay(min);
                return min;
            }
        }

        #endregion

        #region Private Members


        /// <summary>
        /// Finds the node containing the specified data key.
        /// </summary>
        /// <param name="key">The key to search for.</param>
        /// <returns>The node with the specified key if found.  If the key is not in the tree, this method returns null.</returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        protected override BinaryTree<KeyValuePair<TKey, TValue>> FindNode(TKey key)
        {
            var node = base.FindNode(key);

            if (node != null)
            {
                Splay(node.Data);
            }

            return node;
        }

        #endregion

        #region IDictionary<TKey,TValue> Members

        /// <summary>
        /// Adds an element with the provided key and value to the <see cref="IDictionary{TKey,TValue}"/>.
        /// </summary>
        /// <param name="item">The item.</param>
        protected override void AddItem(KeyValuePair<TKey, TValue> item)
        {
            if (Tree == null)
            {
                Tree = new BinaryTree<KeyValuePair<TKey, TValue>>(item);
            }
            else
            {
                Splay(item);

                var c = Comparer.Compare(item, Tree.Data);

                if (c == 0)
                {
                    throw new ArgumentException("Already in the tree.", "item");
                }

                var newTree = new BinaryTree<KeyValuePair<TKey, TValue>>(item);

                if (c < 0)
                {
                    newTree.Left = Tree.Left;
                    newTree.Right = Tree;
                    Tree.Left = null;
                }
                else
                {
                    newTree.Right = Tree.Right;
                    newTree.Left = Tree;
                    Tree.Right = null;
                }
                Tree = newTree;
            }
        }


        private void Splay(KeyValuePair<TKey, TValue> item)
        {
            var header = new BinaryTree<KeyValuePair<TKey, TValue>>(nullPair, null, null, false);
            var left = header;
            var right = header;
            var tempRoot = Tree;

            while (true)
            {
                BinaryTree<KeyValuePair<TKey, TValue>> rotateTree;
                if (Comparer.Compare(item, tempRoot.Data) < 0)
                {
                    if (tempRoot.Left == null)
                    {
                        break;
                    }

                    if (Comparer.Compare(item, tempRoot.Left.Data) < 0)
                    {
                        rotateTree = tempRoot.Left; /* rotate right */
                        tempRoot.Left = rotateTree.Right;
                        rotateTree.Right = tempRoot;
                        tempRoot = rotateTree;
                        if (tempRoot.Left == null)
                        {
                            break;
                        }
                    }
                    right.Left = tempRoot; /* link right */
                    right = tempRoot;
                    tempRoot = tempRoot.Left;
                }
                else if (Comparer.Compare(item, tempRoot.Data) > 0)
                {
                    if (tempRoot.Right == null)
                    {
                        break;
                    }
                    if (Comparer.Compare(item, tempRoot.Right.Data) > 0)
                    {
                        rotateTree = tempRoot.Right; /* rotate left */
                        tempRoot.Right = rotateTree.Left;
                        rotateTree.Left = tempRoot;
                        tempRoot = rotateTree;
                        if (tempRoot.Right == null)
                        {
                            break;
                        }
                    }
                    left.Right = tempRoot; /* link left */
                    left = tempRoot;
                    tempRoot = tempRoot.Right;
                }
                else
                {
                    break;
                }
            }
            left.Right = tempRoot.Left; /* assemble */
            right.Left = tempRoot.Right;
            tempRoot.Left = header.Right;
            tempRoot.Right = header.Left;
            Tree = tempRoot;
        }


        /// <summary>
        /// Removes the element with the specified key from the <see cref="IDictionary{TKey,TValue}"/>.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        /// <returns>
        /// 	<c>true</c> if the element is successfully removed; otherwise, <c>false</c>.  This method also returns false if key was not found in the original <see cref="IDictionary{TKey,TValue}"/>.
        /// </returns>
        protected override bool RemoveItem(KeyValuePair<TKey, TValue> item)
        {
            if (Tree == null)
            {
                return false;
            }

            Splay(item);

            if (Comparer.Compare(item, Tree.Data) == 0)
            {
                // Now delete the root
                if (Tree.Left == null)
                {
                    Tree = Tree.Right;
                }
                else
                {
                    var tempRight = Tree.Right;
                    Tree = Tree.Left;
                    Splay(item);
                    Tree.Right = tempRight;
                }
                return true;
            }

            return false;
        }

        #endregion
    }
}