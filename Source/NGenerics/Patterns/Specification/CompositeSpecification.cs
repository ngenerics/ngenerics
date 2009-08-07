/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/

using NGenerics.Util;

namespace NGenerics.Patterns.Specification
{
    /// <summary>
    /// Provides a composite specification container.
    /// </summary>
    /// <typeparam name="T">The type of item to apply this specification to.</typeparam>
    public abstract class CompositeSpecification<T> : AbstractSpecification<T>
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="CompositeSpecification&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="left">The left specification.</param>
        /// <param name="right">The right specification.</param>
        protected CompositeSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            #region Validation

            Guard.ArgumentNotNull(left, "left");
            Guard.ArgumentNotNull(right, "right");

            #endregion

            Left = left;
            Right = right;
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Gets or sets the left specification.
        /// </summary>
        /// <value>The left specification.</value>
        public ISpecification<T> Left { get; set; }

        /// <summary>
        /// Gets or sets the right specification.
        /// </summary>
        /// <value>The right specification</value>
        public ISpecification<T> Right { get; set; }

        #endregion
    }
}
