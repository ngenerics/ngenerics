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
using System.Diagnostics.CodeAnalysis;
using NGenerics.Patterns.Visitor;
using NGenerics.Sorting;
using NGenerics.Util;


namespace NGenerics.DataStructures.Trees
{
    /// <summary>
    /// A general tree data structure that can hold any amount of nodes.
    /// </summary>
    /// <typeparam name="T">The type of elements in the <see cref="GeneralTree{T}"/>.</typeparam>
    [Serializable]
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
    public class GeneralTree<T> : ICollection<T>, ITree<T>, ISortable<GeneralTree<T>>
    {
        #region Globals

        private T nodeData;
        private GeneralTree<T> parent;
        private readonly List<GeneralTree<T>> childNodes = new List<GeneralTree<T>>();

        #endregion

        #region Construction


        /// <param name="data">The data held in this tree.</param>
        public GeneralTree(T data)
        {
            #region Validation

            Guard.ArgumentNotNull(data, "data");

            #endregion

            nodeData = data;
        }

        #endregion

        #region ICollection<T>  Members

        /// <inheritdoc />
        public bool Contains(T item)
        {
            foreach (var thisItem in this)
            {
                if (item.Equals(thisItem))
                {
                    return true;
                }
            }

            return false;
        }

        /// <inheritdoc />
        public void CopyTo(T[] array, int arrayIndex)
        {

            Guard.ArgumentNotNull(array, "array");

            foreach (var item in this)
            {
                if (arrayIndex >= array.Length)
                {
                    throw new ArgumentException(Constants.NotEnoughSpaceInTheTargetArray, "array");
                }

                array[arrayIndex++] = item;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            var stack = new Stack<GeneralTree<T>>();

            stack.Push(this);

            while (stack.Count > 0)
            {
                var tree = stack.Pop();

                if (tree != null)
                {
                    yield return tree.Data;

                    for (var i = 0; i < tree.Degree; i++)
                    {
                        stack.Push(tree.GetChild(i));
                    }
                }
            }
        }


        /// <inheritdoc />
        public int Count
        {
            get
            {
                return childNodes.Count;
            }
        }

        /// <inheritdoc />
        public virtual void Clear()
        {
            childNodes.Clear();
        }

        /// <inheritdoc />
        public bool IsEmpty
        {
            get
            {
                return (Count == 0);
            }
        }

        /// <inheritdoc />
        void ICollection<T>.Add(T item)
        {
            var child = new GeneralTree<T>(item);
            InsertItem(Count, child);
        }

        /// <inheritdoc />
        public GeneralTree<T> Add(T item)
        {
            var child = new GeneralTree<T>(item);
            InsertItem(Count, child);
            return child;
        }

        /// <summary>
        /// Inserts the item.
        /// </summary>
        /// <param name="index">The index to insert the item into.</param>
        /// <param name="item">The item to insert.</param>
        /// <remarks>
        /// 	<b>Notes to Inheritors: </b>
        /// Derived classes can override this method to change the behavior of the <see cref="Add(T)"/> method.
        /// </remarks>
        protected virtual void InsertItem(int index, GeneralTree<T> item)
        {
            if (item.parent != null)
            {
                item.parent.Remove(item);
            }

            if (!childNodes.Contains(item))
            {
                childNodes.Add(item);
                item.parent = this;
            }
        }

        /// <inheritdoc />
        public bool Remove(T item)
        {
            return RemoveItem(item);
        }

        /// <summary>
        /// Removes the item form the tree.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        /// <returns>An indication of whether the item was found, and removed.</returns>
        /// <remarks>
        /// 	<b>Notes to Inheritors: </b>
        /// Derived classes can override this method to change the behavior of the <see cref="Remove(T)"/> method.
        /// </remarks>
        protected virtual bool RemoveItem(T item)
        {
            for (var i = 0; i < childNodes.Count; i++)
            {
                var tree = childNodes[i];
                if (tree.Data.Equals(item))
                {
                    tree.parent = null;
                    childNodes.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        /// <inheritdoc />
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }


        #endregion

        #region ITree<T> Members

        /// <inheritdoc />
        void ITree<T>.Add(ITree<T> child)
        {
            Add((GeneralTree<T>)child);
        }

        /// <inheritdoc />
        ITree<T> ITree<T>.GetChild(int index)
        {
            return GetChild(index);
        }

        /// <inheritdoc />
        bool ITree<T>.Remove(ITree<T> child)
        {
            return Remove((GeneralTree<T>)child);
        }

        /// <inheritdoc />
        ITree<T> ITree<T>.FindNode(Predicate<T> condition)
        {
            return FindNode(condition);
        }
        /// <inheritdoc />
        ITree<T> ITree<T>.Parent
        {
            get
            {
                return parent;
            }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Retrieves the Ancestors of this node, in the same order
        /// as the path from the current node to the root.
        /// </summary>
        /// <value>The ancestors.</value>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public IList<GeneralTree<T>> Ancestors
        {
            get
            {
                return GetPath(x => x);
            }
        }

        /// <summary>
        /// Gets the child nodes of this node.
        /// </summary>
        /// <value>The child nodes.</value>
        /// <remarks>The ChildNodes list returned is read-only.</remarks>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public IList<GeneralTree<T>> ChildNodes
        {
            get
            {
                return new ReadOnlyCollection<GeneralTree<T>>(childNodes);
            }
        }

        /// <summary>
        /// Gets the parent of this node.
        /// </summary>
        /// <value>The parent of this node.</value>
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public GeneralTree<T> Parent
        {
            get
            {
                return parent;
            }
            set
            {
                Guard.ArgumentNotNull(value, "value");
                value.Add(this);
            }
        }

        /// <inheritdoc />
        public int Degree
        {
            get
            {
                return childNodes.Count;
            }
        }

        /// <summary>
        /// Finds the node with the specified condition.  If a node is not found matching
        /// the specified condition, null is returned.
        /// </summary>
        /// <param name="condition">The condition to test.</param>
        /// <returns>The first node that matches the condition supplied.  If a node is not found, null is returned.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="condition"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        public GeneralTree<T> FindNode(Predicate<T> condition)
        {
            Guard.ArgumentNotNull(condition, "condition");

            if (condition(Data))
            {
                return this;
            }

            for (var i = 0; i < Degree; i++)
            {
                var ret = childNodes[i].FindNode(condition);

                if (ret != null)
                {
                    return ret;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the child at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The child at the specified index.</returns>
        public GeneralTree<T> GetChild(int index)
        {
            return childNodes[index];
        }

        /// <summary>
        /// Gets the path.
        /// </summary>
        /// <returns>The path found to this node.</returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public IList<GeneralTree<T>> GetPath()
        {
            return GetPath(x => x);
        }

        /// <summary>
        /// Gets the path to the specified node.
        /// </summary>
        /// <typeparam name="TOutput">The type of the output.</typeparam>
        /// <param name="converter">The converter.</param>
        /// <returns>A list (of converted) General Trees that form the path to this node from the root.</returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public IList<TOutput> GetPath<TOutput>(Converter<GeneralTree<T>, TOutput> converter)
        {
            if (converter == null)
            {
                throw new ArgumentNullException("converter");
            }

            return GetPath(converter, false);
        }


        /// <inheritdoc />
        public int Height
        {
            get
            {
                if (Degree == 0)
                {
                    return 0;
                }

                return 1 + FindMaximumChildHeight();
            }
        }


        /// <summary>
        /// Performs a depth first traversal on this tree with the specified visitor.
        /// </summary>
        /// <param name="orderedVisitor">The ordered visitor.</param>
        /// <exception cref="ArgumentNullException"><paramref name="orderedVisitor"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        public void DepthFirstTraversal(OrderedVisitor<T> orderedVisitor)
        {
            Guard.ArgumentNotNull(orderedVisitor, "orderedVisitor");

            if (orderedVisitor.HasCompleted)
            {
                return;
            }

            orderedVisitor.VisitPreOrder(Data);

            for (var i = 0; i < Degree; i++)
            {
                if (GetChild(i) != null)
                {
                    GetChild(i).DepthFirstTraversal(orderedVisitor);
                }
            }

            orderedVisitor.VisitPostOrder(Data);
        }

        /// <summary>
        /// Performs a breadth first traversal on this tree with the specified visitor.
        /// </summary>
        /// <param name="visitor">The visitor.</param>
        public void BreadthFirstTraversal(IVisitor<T> visitor)
        {
            var queue = new Queue<GeneralTree<T>>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var generalTree = queue.Dequeue();
                visitor.Visit(generalTree.Data);

                for (var i = 0; i < generalTree.Degree; i++)
                {
                    var child = generalTree.GetChild(i);

                    if (child != null)
                    {
                        queue.Enqueue(child);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the data held in this node.
        /// </summary>
        /// <value>The data.</value>
        public T Data
        {
            get
            {
                return nodeData;
            }
            set
            {
                #region Validation

                Guard.ArgumentNotNull(value, "value");

                #endregion

                nodeData = value;
            }
        }

        /// <inheritdoc />
        public virtual bool IsLeafNode
        {
            get
            {
                return Degree == 0;
            }
        }

        /// <summary>
        /// Adds the child tree to this node.
        /// </summary>
        /// <param name="child">The child tree to add.</param>
        public void Add(GeneralTree<T> child)
        {
            InsertItem(Count, child);
        }

        /// <summary>
        /// Removes the specified child node from the tree.
        /// </summary>
        /// <param name="child">The child tree to remove.</param>
        /// <returns>A value indicating whether the child was found (and removed) from this tree.</returns>
        public bool Remove(GeneralTree<T> child)
        {
            var indexOf = childNodes.IndexOf(child);

            if (indexOf > -1)
            {
                RemoveItem(indexOf, child);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Removes the child at the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        public void RemoveAt(int index)
        {
            RemoveItem(index, childNodes[index]);
        }

        /// <summary>
        /// Removes the item from the tree.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="item">The item to remove.</param>
        /// <remarks>
        /// 	<b>Notes to Inheritors: </b>
        /// Derived classes can override this method to change the behavior of the <see cref="RemoveAt"/> method.
        /// </remarks>
        protected virtual void RemoveItem(int index, GeneralTree<T> item)
        {
            item.parent = null;
            childNodes.RemoveAt(index);
        }

        /// <summary>
        /// Sorts all descendants using the specified sorter.
        /// </summary>
        /// <param name="sorter">The sorter to use in the sorting process.</param>
        /// <param name="comparison">The comparison.</param>
        /// <exception cref="ArgumentNullException"><paramref name="sorter"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentNullException"><paramref name="comparison"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public void SortAllDescendants(IComparisonSorter<GeneralTree<T>> sorter, Comparison<GeneralTree<T>> comparison)
        {
            #region Validation

            Guard.ArgumentNotNull(sorter, "sorter");
            Guard.ArgumentNotNull(comparison, "comparison");

            #endregion

            childNodes.Sort(sorter, comparison);

            for (var i = 0; i < childNodes.Count; i++)
            {
                childNodes[i].SortAllDescendants(sorter, comparison);
            }
        }

        /// <summary>
        /// Sorts all descendants using the specified sorter.
        /// </summary>
        /// <param name="sorter">The sorter to use in the sorting process.</param>
        /// <param name="comparer">The comparer.</param>
        /// <exception cref="ArgumentNullException"><paramref name="sorter"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public void SortAllDescendants(IComparisonSorter<GeneralTree<T>> sorter, IComparer<GeneralTree<T>> comparer)
        {
            #region Validation

            Guard.ArgumentNotNull(sorter, "sorter");
            Guard.ArgumentNotNull(comparer, "comparer");

            #endregion

            childNodes.Sort(sorter, comparer);

            for (var i = 0; i < childNodes.Count; i++)
            {
                childNodes[i].SortAllDescendants(sorter, comparer);
            }
        }

        /// <summary>
        /// Sorts all descendants using the specified sorter.
        /// </summary>
        /// <param name="sorter">The sorter to use in the sorting process.</param>
        /// <param name="order">The order in which to sort.</param>
        /// <exception cref="ArgumentNullException"><paramref name="sorter"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public void SortAllDescendants(ISorter<GeneralTree<T>> sorter, SortOrder order)
        {
            #region Validation

            Guard.ArgumentNotNull(sorter, "sorter");

            #endregion

            childNodes.Sort(sorter, order);

            for (var i = 0; i < childNodes.Count; i++)
            {
                childNodes[i].SortAllDescendants(sorter, order);
            }
        }

        #endregion

        #region Protected Members

        /// <summary>
        /// Gets the path to the specified node.
        /// </summary>
        /// <typeparam name="TOutput">The type of the output.</typeparam>
        /// <param name="converter">The converter.</param>
        /// <param name="includeThis">if set to <c>true</c> include this node in the path.</param>
        /// <returns>A list (of converted) General Trees that form the path to this node from the root.</returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        protected IList<TOutput> GetPath<TOutput>(Converter<GeneralTree<T>, TOutput> converter, bool includeThis)
        {
            var path = new List<TOutput>();

            if (includeThis)
            {
                path.Add(converter(this));
            }

            for (var node = Parent; node != null; node = node.Parent)
            {
                path.Add(converter(node));
            }

            path.Reverse();

            return path;
        }

        #endregion

        #region Private Members

        /// <summary>
        /// Finds the maximum height between the child nodes.
        /// </summary>
        /// <returns>The maximum height of all paths between this node and all leaf nodes.</returns>
        private int FindMaximumChildHeight()
        {
            var maximum = 0;

            for (var i = 0; i < Degree; i++)
            {
                var childHeight = GetChild(i).Height;

                if (childHeight > maximum)
                {
                    maximum = childHeight;
                }
            }

            return maximum;
        }

        #endregion

        #region Operator Overloads


        /// <summary>
        /// Gets the <see cref="NGenerics.DataStructures.Trees.GeneralTree{T}"/> at the specified index.
        /// </summary>
        public GeneralTree<T> this[int index]
        {
            get
            {
                return GetChild(index);
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

        #region ISortable<GeneralTree<T>> Members

        /// <inheritdoc />
        /// <exception cref="NotSupportedException">Always.</exception>
        void ISortable<GeneralTree<T>>.Sort(ISorter<GeneralTree<T>> sorter)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public void Sort(IComparisonSorter<GeneralTree<T>> sorter, Comparison<GeneralTree<T>> comparison)
        {
            #region Validation

            Guard.ArgumentNotNull(sorter, "sorter");
            Guard.ArgumentNotNull(comparison, "comparison");

            #endregion

            childNodes.Sort(sorter, comparison);
        }

        /// <inheritdoc />
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public void Sort(IComparisonSorter<GeneralTree<T>> sorter, IComparer<GeneralTree<T>> comparer)
        {
            #region Validation

            Guard.ArgumentNotNull(sorter, "sorter");
            Guard.ArgumentNotNull(comparer, "comparer");

            #endregion

            childNodes.Sort(sorter, comparer);
        }

        /// <inheritdoc />
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public void Sort(ISorter<GeneralTree<T>> sorter, SortOrder order)
        {
            #region Validation

            Guard.ArgumentNotNull(sorter, "sorter");

            #endregion

            childNodes.Sort(sorter, order);
        }

        #endregion

        #region Object Members

        /// <inheritdoc />
        public override string ToString()
        {
            return Data.ToString();
        }

        #endregion
    }
}