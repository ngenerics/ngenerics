/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using NGenerics.Util;

namespace NGenerics.Patterns.Specification
{
    /// <summary>
    /// A simple specification that operates on a predicate.
    /// </summary>
    /// <typeparam name="T">The type of predicate to accept.</typeparam>
    public class PredicateSpecification<T> : AbstractSpecification<T>
    {
        #region Globals

        private readonly Predicate<T> predicate;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="PredicateSpecification&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="predicate">The predicate to use as a specification.</param>
        public PredicateSpecification(Predicate<T> predicate)
        {
            #region Validation

            Guard.ArgumentNotNull(predicate, "predicate");

            #endregion

            this.predicate = predicate;
        }

        #endregion

        #region AbstractSpecification<T> Memberes

        /// <summary>
        /// Determines whether the specification is satisfied by the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        /// 	<c>true</c> if the specification is satisfied by the specified item; otherwise, <c>false</c>.
        /// </returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\Patterns\Specification\PredicateSpecificationExamples.cs" region="IsSatisfiedBy" lang="cs" title="The following example shows how to use the IsSatisfiedBy method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\Patterns\Specification\PredicateSpecificationExamples.vb" region="IsSatisfiedBy" lang="vbnet" title="The following example shows how to use the IsSatisfiedBy method."/>
        /// </example>
        public override bool IsSatisfiedBy(T item)
        {
            return predicate(item);
        }

        #endregion
        
        #region Public Members

        /// <summary>
        /// Gets the predicate.
        /// </summary>
        /// <value>The predicate.</value>
        public Predicate<T> Predicate
        {
            get
            {
                return predicate;
            }
        }

        #endregion
    }
}
