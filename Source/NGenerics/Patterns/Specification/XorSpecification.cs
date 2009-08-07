/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/

namespace NGenerics.Patterns.Specification
{
    /// <summary>
    /// Performs an AND operation between two specifications.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class XorSpecification<T> : CompositeSpecification<T>
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="XorSpecification&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="left">The left specification.</param>
        /// <param name="right">The right specification.</param>
        public XorSpecification(ISpecification<T> left, ISpecification<T> right) : base(left, right) { }

        #endregion

        #region AbstractSpecification<T> Members

        /// <summary>
        /// Determines whether the specification is satisfied by the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        /// 	<c>true</c> if the specification is satisfied by the specified item; otherwise, <c>false</c>.
        /// </returns>
        public override bool IsSatisfiedBy(T item)
        {
            return Left.IsSatisfiedBy(item) ^ Right.IsSatisfiedBy(item);
        }

        #endregion
    }
}
