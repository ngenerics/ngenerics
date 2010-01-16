/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
namespace NGenerics.Patterns.Specification
{
    /// <summary>
    /// An abstract common base class for all specifications.
    /// </summary>
    /// <typeparam name="T">The type of item to apply the specification to.</typeparam>
    public abstract class AbstractSpecification<T> : ISpecification<T>
    {
        #region ISpecification<T> Members

        /// <summary>
        /// Determines whether the specification is satisfied by the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        /// 	<c>true</c> if the specification is satisfied by the specified item; otherwise, <c>false</c>.
        /// </returns>
        public abstract bool IsSatisfiedBy(T item);

        /// <summary>
        /// Performs the AND operation on this specification and the other.
        /// </summary>
        /// <param name="right">The right hand side of the operation.</param>
        /// <returns>The result of the AND operation.</returns>
        ISpecification<T> ISpecification<T>.And(ISpecification<T> right)
        {
            return And(right);
        }
        
        /// <summary>
        /// Performs the OR operation this specification and the other.
        /// </summary>
        /// <param name="right">The right hand side of the operation.</param>
        /// <returns>The result of the OR operation.</returns>
        ISpecification<T> ISpecification<T>.Or(ISpecification<T> right)
        {
            return Or(right);
        }

        /// <summary>
        /// Performs the XOR operation on the current specification.
        /// </summary>
        /// <param name="right">The right hand side of the operation..</param>
        /// <returns>The result of the XOR operation.</returns>
        ISpecification<T> ISpecification<T>.Xor(ISpecification<T> right)
        {
            return Xor(right);
        }

        /// <summary>
        /// Performs the NOT operation on the current specification.
        /// </summary>
        /// <returns>The result of the NOT operation.</returns>
        ISpecification<T> ISpecification<T>.Not()
        {
            return Not();
        }

        #endregion

        #region Operators

        /// <summary>
        /// Implements the operator &amp;.
        /// </summary>
        /// <param name="left">The left hand side specification.</param>
        /// <param name="right">The right hand side specification.</param>
        /// <returns>The result of the operator.</returns>
        public static AbstractSpecification<T> operator &(AbstractSpecification<T> left, ISpecification<T> right)
        {
            return AndInternal(left, right);
        }

        /// <summary>
        /// Implements the operator &amp;.
        /// </summary>
        /// <param name="left">The left hand side specification.</param>
        /// <param name="right">The right hand side predicate.</param>
        /// <returns>The result of the operator.</returns>
        public static AbstractSpecification<T> operator &(AbstractSpecification<T> left, Predicate<T> right)
        {
            return AndInternal(left, new PredicateSpecification<T>(right));
        }

        /// <summary>
        /// Implements the operator OR.
        /// </summary>
        /// <param name="left">The left hand side specification.</param>
        /// <param name="right">The right hand side specification.</param>
        /// <returns>The result of the operator.</returns>
        public static AbstractSpecification<T> operator |(AbstractSpecification<T> left, ISpecification<T> right)
        {
            return OrInternal(left, right);
        }

        /// <summary>
        /// Implements the operator OR.
        /// </summary>
        /// <param name="left">The left hand side specification.</param>
        /// <param name="right">The right hand side predicate.</param>
        /// <returns>The result of the operator.</returns>
        public static AbstractSpecification<T> operator |(AbstractSpecification<T> left, Predicate<T> right)
        {
            return OrInternal(left, new PredicateSpecification<T>(right));
        }
        
        /// <summary>
        /// Implements the operator NOT.
        /// </summary>
        /// <param name="operand">The operand.</param>
        /// <returns>The result of the operator.</returns>
        public static AbstractSpecification<T> operator !(AbstractSpecification<T> operand)
        {
            return NotInternal(operand);
        }
        
        /// <summary>
        /// Implements the operator XOR.
        /// </summary>
        /// <param name="left">The left hand side specification.</param>
        /// <param name="right">The right hand side specification.</param>
        /// <returns>The result of the operator.</returns>
        public static AbstractSpecification<T> operator ^(AbstractSpecification<T> left, ISpecification<T> right)
        {
            return XorInternal(left, right);
        }

        /// <summary>
        /// Implements the operator XOR.
        /// </summary>
        /// <param name="left">The left hand side specification.</param>
        /// <param name="right">The right hand side predicate.</param>
        /// <returns>The result of the operator.</returns>
        public static AbstractSpecification<T> operator ^(AbstractSpecification<T> left, Predicate<T> right)
        {
            return XorInternal(left, new PredicateSpecification<T>(right));
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Performs the AND operation on this specification and the other.
        /// </summary>
        /// <param name="right">The right hand side of the operation.</param>
        /// <returns>The result of the AND operation.</returns>
        public AbstractSpecification<T> And(ISpecification<T> right)
        {
            return AndInternal(this, right);
        }

        /// <summary>
        /// Performs the OR operation this specification and the other.
        /// </summary>
        /// <param name="right">The right hand side of the operation.</param>
        /// <returns>The result of the OR operation.</returns>
        public AbstractSpecification<T> Or(ISpecification<T> right)
        {
            return OrInternal(this, right);
        }

        /// <summary>
        /// Performs the XOR operation on the current specification.
        /// </summary>
        /// <param name="right">The right hand side of the operation..</param>
        /// <returns>The result of the XOR operation.</returns>
        public AbstractSpecification<T> Xor(ISpecification<T> right)
        {
            return XorInternal(this, right);
        }

        /// <summary>
        /// Performs the NOT operation on the current specification.
        /// </summary>
        /// <returns>The result of the NOT operation.</returns>
        public AbstractSpecification<T> Not()
        {
            return NotInternal(this);
        }

        /// <summary>
        /// Performs the AND operation on this specification and the other.
        /// </summary>
        /// <param name="right">The right hand side of the operation.</param>
        /// <returns>The result of the AND operation.</returns>
        public AbstractSpecification<T> And(Predicate<T> right)
        {
            return AndInternal(this, new PredicateSpecification<T>(right));
        }

        /// <summary>
        /// Performs the OR operation this specification and the other.
        /// </summary>
        /// <param name="right">The right hand side of the operation.</param>
        /// <returns>The result of the OR operation.</returns>
        public AbstractSpecification<T> Or(Predicate<T> right)
        {
            return OrInternal(this, new PredicateSpecification<T>(right));
        }

        /// <summary>
        /// Performs the XOR operation on the current specification.
        /// </summary>
        /// <param name="right">The right hand side of the operation..</param>
        /// <returns>The result of the XOR operation.</returns>
        public AbstractSpecification<T> Xor(Predicate<T> right)
        {
            return XorInternal(this, new PredicateSpecification<T>(right));
        }

        #endregion

        #region Private Members

        private static AbstractSpecification<T> OrInternal(ISpecification<T> left, ISpecification<T> right)
        {
            return new OrSpecification<T>(left, right);
        }

        private static AbstractSpecification<T> AndInternal(ISpecification<T> left, ISpecification<T> right)
        {
            return new AndSpecification<T>(left, right);
        }

        private static AbstractSpecification<T> XorInternal(ISpecification<T> left, ISpecification<T> right)
        {
            return new XorSpecification<T>(left, right);
        }
        
        private static AbstractSpecification<T> NotInternal(ISpecification<T> operand)
        {
            return new NotSpecification<T>(operand);
        }

        #endregion
    }
}
