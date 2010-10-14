/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace NGenerics.DataStructures.Trees
{
    /// <summary>
    /// An implementation of a Binary Search Tree data structure.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the tree.</typeparam>
    /// <typeparam name="TValue">The type of the values in the tree.</typeparam>
	[SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
#if (!SILVERLIGHT && !WINDOWSPHONE)
    [Serializable]
#endif
    public class BinarySearchTree<TKey, TValue> : BinarySearchTreeBase<TKey, TValue>
    {
        #region Construction

        /// <inheritdoc />
        public BinarySearchTree()
        {
        }


        /// <inheritdoc />
        public BinarySearchTree(IComparer<TKey> comparer)
            : base(comparer)
        {
        }

        /// <inheritdoc />
        public BinarySearchTree(Comparison<TKey> comparison)
            : base(comparison)
        {
        }

        #endregion

        #region Public Members

        #endregion

        #region Private Members

        /// <summary>
        /// Finds the node containing the specified data item.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="parent">The parent node of the item found.</param>
        /// <returns>The node in the tree with the specified key if found, otherwise null.</returns>
        private BinaryTree<KeyValuePair<TKey, TValue>> FindNode(TKey key, out BinaryTree<KeyValuePair<TKey, TValue>> parent)
        {
            var currentNode = Tree;
            parent = null;
            var searchItem = new KeyValuePair<TKey, TValue>(key, default(TValue));

            while (currentNode != null)
            {
                var nodeResult = Comparer.Compare(searchItem, currentNode.Data);

                if (nodeResult == 0)
                {
                    return currentNode;
                }
                
                if (nodeResult < 0)
                {
                    parent = currentNode;
                    currentNode = currentNode.Left;
                }
                else
                {
                    parent = currentNode;
                    currentNode = currentNode.Right;
                }
            }

            return null;
        }


        /// <summary>
        /// Finds the maximum node.
        /// </summary>
        /// <param name="startNode">The start node.</param>
        /// <param name="parent">The parent of the node found.</param>
        /// <returns>The maximum node underneath the node specified.  If the node specified is a leaf node, it is returned.</returns>
        private static BinaryTree<KeyValuePair<TKey, TValue>> FindMaximumNode(BinaryTree<KeyValuePair<TKey, TValue>> startNode, out BinaryTree<KeyValuePair<TKey, TValue>> parent)
        {
            #region Asserts

            Debug.Assert(startNode != null);

            #endregion
            
            var searchNode = startNode;
            parent = null;

            while (searchNode.Right != null)
            {
                parent = searchNode;
                searchNode = searchNode.Right;
            }

            return searchNode;
        }

        #endregion

        #region IDictionary<TKey,TValue> Members

		/// <inheritdoc />
        protected override void AddItem(KeyValuePair<TKey, TValue> item)
        {
            if (Tree == null)
            {
                Tree = new BinaryTree<KeyValuePair<TKey, TValue>>(item);
            }
            else
            {
                var currentNode = Tree;

                // Find the place to insert the item.
                //	- If the item is found, throw an exception - no duplicate items allowed.
                //  - If a leaf is reached, insert the item in the correct place.
                //  - Else, traverse the tree further
                while (true)
                {
                    var nodeResult = Comparer.Compare(item, currentNode.Data);

                    if (nodeResult == 0)
                    {
                        throw new ArgumentException(alreadyContainedInTheTree, "item");
                    }

                    if (nodeResult < 0)
                    {
                        if (currentNode.Left == null)
                        {
                            currentNode.Left = new BinaryTree<KeyValuePair<TKey, TValue>>(item);
                            break;
                        }
                        
                        currentNode = currentNode.Left;
                    }
                    else
                    {
                        if (currentNode.Right == null)
                        {
                            currentNode.Right = new BinaryTree<KeyValuePair<TKey, TValue>>(item);
                            break;
                        }
                        
                        currentNode = currentNode.Right;
                    }
                }
            }
        }
        
		/// <inheritdoc />
        protected override bool RemoveItem(KeyValuePair<TKey, TValue> item)
        {
            BinaryTree<KeyValuePair<TKey, TValue>> parentNode;
            var currentNode = FindNode(item.Key, out parentNode);

            // The node wasn't found in the tree.
            if (currentNode == null)
            {
                return false;
            }
		    
            if (currentNode.Degree == 2)
		    {
		        // Find the element with the largest key in the left sub-tree					
                BinaryTree<KeyValuePair<TKey, TValue>> searchParent;
		        var searchNode = FindMaximumNode(currentNode.Left, out searchParent);

		        parentNode = searchParent ?? currentNode;

		        currentNode.Data = searchNode.Data;
		        currentNode = searchNode;
		    }

		    var leftOverChild = currentNode.Left ?? currentNode.Right;

		    if (currentNode == Tree)
		    {
		        Tree = leftOverChild;
		    }
		    else
		    {
		        if (currentNode == parentNode.Left)
		        {
		            parentNode.Left = leftOverChild;
		        }
		        else
		        {
		            parentNode.Right = leftOverChild;
		        }
		    }

		    return true;
        }

        #endregion
    }
}