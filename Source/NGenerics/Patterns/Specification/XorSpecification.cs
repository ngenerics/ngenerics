/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
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
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\Patterns\Specification\XorSpecificationExamples.cs" region="IsSatisfiedBy" lang="cs" title="The following example shows how to use the IsSatisfiedBy method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\Patterns\Specification\XorSpecificationExamples.vb" region="IsSatisfiedBy" lang="vbnet" title="The following example shows how to use the IsSatisfiedBy method."/>
        /// </example>
        public override bool IsSatisfiedBy(T item)
        {
            return Left.IsSatisfiedBy(item) ^ Right.IsSatisfiedBy(item);
        }

        #endregion
    }
}
