/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/



namespace NGenerics.Patterns.Visitor
{
    /// <summary>
    /// An Post order implementation of the <see cref="OrderedVisitor{T}"/> class.
    /// </summary>
    /// <typeparam name="T">The type of objects to be visited.</typeparam>
    public sealed class PostOrderVisitor<T> : OrderedVisitor<T>
    {
        #region Construction

        /// <param name="visitor">The visitor to use when visiting the object.</param>
        public PostOrderVisitor(IVisitor<T> visitor) : base(visitor) { }

        #endregion

        #region OrderedVisitor<T> Members

        /// <summary>
        /// Visits the object in order.
        /// </summary>
        /// <param name="obj">The obj.</param>
        public override void VisitInOrder(T obj)
        {
            // Do nothing.
        }

        /// <summary>
        /// Visits the object in pre order.
        /// </summary>
        /// <param name="obj">The obj.</param>
        public override void VisitPreOrder(T obj)
        {
            // Do nothing.
        }

        #endregion
    }
}