/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/



#if (!SILVERLIGHT)
using System;
#endif
using System.Diagnostics.CodeAnalysis;

namespace NGenerics.DataStructures.Trees {
    /// <summary>
    /// A container class, used for the RedBlackTree.
    /// </summary>
    /// <typeparam name="T">The type of element.</typeparam>
#if (!SILVERLIGHT)
    [Serializable]
#endif
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
    internal class RedBlackTreeNode<T> : BinaryTree<T> {
        
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="RedBlackTreeNode&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="data">The data contained in this node.</param>
        internal RedBlackTreeNode(T data)
            : base(data) {
            Color = NodeColor.Red;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the color of the current node.
        /// </summary>
        /// <value>The color of the node.</value>
        internal NodeColor Color { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="NGenerics.DataStructures.Trees.BinaryTree&lt;T&gt;"/> with the specified direction.
        /// </summary>
        /// <value></value>
        internal RedBlackTreeNode<T> this[bool direction] {
            get {
                return direction ? Right : Left;
            }
            set {
                if (direction) {
                    Right = value;
                } else {
                    Left = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the left subtree.
        /// </summary>
        /// <value>The left subtree.</value>
        internal new RedBlackTreeNode<T> Left {
            get {
                return (RedBlackTreeNode<T>)base.Left;
            }
            set {
                base.Left = value;
            }
        }

        /// <summary>
        /// Gets or sets the right subtree.
        /// </summary>
        /// <value>The right subtree.</value>
        internal new RedBlackTreeNode<T> Right {
            get {
                return (RedBlackTreeNode<T>)base.Right;
            }
            set {
                base.Right = value;
            }
        }
        

        #endregion
    }
}
