/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/



using System;
using System.Diagnostics.CodeAnalysis;
using NGenerics.DataStructures.General;
using NGenerics.Util;

namespace NGenerics.DataStructures.Mathematical
{


    /// <summary>
    /// A Vector data structure.
    /// </summary>
    public abstract partial class VectorBase<T>
    {
        #region Operator Overloads
        
        /// <summary>
        /// Equals operator.
        /// </summary>
        /// <param name="left">The left hand side.</param>
        /// <param name="right">The right hand side.</param>
        /// <returns><c>true</c> is <paramref name="left"/> is equal to <paramref name="right"/>; otherwise <c>false</c>.</returns>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Mathematical\VectorBaseExamples.cs" region="OperatorEquals" lang="cs" title="The following example shows how to use the equals operator overload."/>
        /// </example>
        [SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static bool operator ==(VectorBase<T> left, IVector<T> right)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            // If one is null, but not both, return <c>false</c>.
            if (((object)left == null) || (right == null))
            {
                return false;
            }

            // Return true if the fields match:
            return left.EqualsInternal(right);
        }
        
        /// <summary>
        /// Not Equals operator.
        /// </summary>
        /// <param name="left">The left hand side.</param>
        /// <param name="right">The right hand side.</param>
        /// <returns><c>true</c> is <paramref name="left"/> is not equal to <paramref name="right"/>; otherwise <c>false</c>.</returns>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Mathematical\VectorBaseExamples.cs" region="OperatorNotEquals" lang="cs" title="The following example shows how to use the not equals operator overload."/>
        /// </example>
        [SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static bool operator !=(VectorBase<T> left, IVector<T> right)
        {
            return !(left == right);
        }


        /// <summary>
        /// Overload of the operator /
        /// </summary>
        /// <param name="left">The left hand side.</param>
        /// <param name="right">The right hand side.</param>
        /// <returns>The result of the division.</returns>
        /// <exception cref="ArgumentException">The <see cref="IVector{T}.DimensionCount"/> of <paramref name="left"/> does not equal the <see cref="IVector{T}.DimensionCount"/> of <paramref name="right"/>.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="left"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentNullException"><paramref name="right"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Mathematical\VectorBaseExamples.cs" region="OperatorDivideVector" lang="cs" title="The following example shows how to use the divide operator overload."/>
        /// </example>
        [SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static VectorBase<T> operator /(VectorBase<T> left, IVector<T> right)
        {
            Guard.ArgumentNotNull(left, "left");
            Guard.ArgumentNotNull(right, "right");
            CheckDimensionsEqual(left, right);
            var clone = (VectorBase<T>)left.DeepClone();
            clone.Divide(right);
            return clone;
        }


        /// <summary>
        /// Overload of the operator /
        /// </summary>
        /// <param name="left">The left hand side.</param>
        /// <param name="right">The right hand side.</param>
        /// <returns>The result of the division.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="left"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Mathematical\VectorBaseExamples.cs" region="OperatorDivideDouble" lang="cs" title="The following example shows how to use the divide operator overload."/>
        /// </example>
        [SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static VectorBase<T> operator /(VectorBase<T> left, T right)
        {
            Guard.ArgumentNotNull(left, "left");
            var clone = (VectorBase<T>)left.DeepClone();
            clone.Divide(right);
            return clone;
        }


        /// <summary>
        /// Overload of the operator * 
        /// </summary>
        /// <param name="left">The left hand side.</param>
        /// <param name="right">The right hand side.</param>
        /// <returns>The result of the multiplication.</returns>
        /// <exception cref="ArgumentException">The <see cref="IVector{T}.DimensionCount"/> of the current instance does not equal the <see cref="IVector{T}.DimensionCount"/> of <paramref name="right"/>.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="left"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentNullException"><paramref name="right"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Mathematical\VectorBaseExamples.cs" region="OperatorMultiplyVector" lang="cs" title="The following example shows how to use the multiply operator overload."/>
        /// </example>
        [SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static IMatrix<T> operator *(VectorBase<T> left, IVector<T> right)
        {
            Guard.ArgumentNotNull(left, "left");
            Guard.ArgumentNotNull(right, "right");
            CheckDimensionsEqual(left, right);

            var matrix = left.Multiply(right);
            return matrix;
        }


        /// <summary>
        /// Overload of the operator * 
        /// </summary>
        /// <param name="left">The left hand side.</param>
        /// <param name="right">The right hand side.</param>
        /// <returns>The result of the multiplication.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="left"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Mathematical\VectorBaseExamples.cs" region="OperatorMultiplyDouble" lang="cs" title="The following example shows how to use the multiply operator overload."/>
        /// </example>
        [SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static VectorBase<T> operator *(VectorBase<T> left, T right)
        {
            Guard.ArgumentNotNull(left, "left");
            var clone = (VectorBase<T>)left.DeepClone();
            clone.Multiply(right);
            return clone;
        }


        /// <summary>
        /// Overload of the operator + 
        /// </summary>
        /// <param name="left">The left hand side.</param>
        /// <param name="right">The right hand side.</param>
        /// <returns>The result of the addition.</returns>
        /// <exception cref="ArgumentException">The <see cref="IVector{T}.DimensionCount"/> of the current instance does not equal the <see cref="IVector{T}.DimensionCount"/> of <paramref name="right"/>.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="left"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentNullException"><paramref name="right"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Mathematical\VectorBaseExamples.cs" region="OperatorPlus" lang="cs" title="The following example shows how to use the plus operator."/>
        /// </example>
        [SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static VectorBase<T> operator +(VectorBase<T> left, IVector<T> right)
        {
            Guard.ArgumentNotNull(left, "left");
            Guard.ArgumentNotNull(right, "right");
            CheckDimensionsEqual(left, right);
            var clone = (VectorBase<T>)left.DeepClone();
            clone.Add(right);
            return clone;
        }


        /// <summary>
        /// Overload of the operator ++
        /// </summary>
        /// <param name="right">The right hand side.</param>
        /// <returns>The result of the addition.</returns>
        /// <exception cref="ArgumentException">The <see cref="IVector{T}.DimensionCount"/> of the current instance does not equal the <see cref="IVector{T}.DimensionCount"/> of <paramref name="right"/>.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="right"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Mathematical\VectorBaseExamples.cs" region="OperatorIncrement" lang="cs" title="The following example shows how to use the increment operator."/>
        /// </example>
        [SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static VectorBase<T> operator ++(VectorBase<T> right)
        {
            Guard.ArgumentNotNull(right, "right");
            var clone = (VectorBase<T>)right.DeepClone();
            clone.Increment();
            return clone;
        }

        /// <summary>
        /// Overload of the operator + 
        /// </summary>
        /// <param name="left">The left hand side.</param>
        /// <param name="right">The right hand side.</param>
        /// <returns>The result of the addition.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="left"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Mathematical\VectorBaseExamples.cs" region="OperatorPlusDouble" lang="cs" title="The following example shows how to use the plus operator."/>
        /// </example>
        [SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static VectorBase<T> operator +(VectorBase<T> left, T right)
        {
            Guard.ArgumentNotNull(left, "left");
            var clone = (VectorBase<T>)left.DeepClone();
            clone.Add(right);
            return clone;
        }


        /// <summary>
        /// Overload of the operator - 
        /// </summary>
        /// <param name="left">The left hand side.</param>
        /// <param name="right">The right hand side.</param>
        /// <returns>The result of the subtraction.</returns>
        /// <exception cref="ArgumentException">The <see cref="IVector{T}.DimensionCount"/> of the current instance does not equal the <see cref="IVector{T}.DimensionCount"/> of <paramref name="right"/>.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="left"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentNullException"><paramref name="right"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Mathematical\VectorBaseExamples.cs" region="OperatorSubtractVector" lang="cs" title="The following example shows how to use the minus operator."/>
        /// </example>
        [SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static VectorBase<T> operator -(VectorBase<T> left, IVector<T> right)
        {
            Guard.ArgumentNotNull(left, "left");
            Guard.ArgumentNotNull(right, "right");
            CheckDimensionsEqual(left, right);
            var clone = (VectorBase<T>)left.DeepClone();
            clone.Subtract(right);
            return clone;
        }


        /// <summary>
        /// Overload of the operator - 
        /// </summary>
        /// <param name="left">The left hand side.</param>
        /// <param name="right">The right hand side.</param>
        /// <returns>The result of the subtraction.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="left"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Mathematical\VectorBaseExamples.cs" region="OperatorSubtractDouble" lang="cs" title="The following example shows how to use the minus operator."/>
        /// </example>
        [SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static VectorBase<T> operator -(VectorBase<T> left, T right)
        {
            Guard.ArgumentNotNull(left, "left");
            var clone = (VectorBase<T>)left.DeepClone();
            clone.Subtract(right);
            return clone;
        }


        /// <summary>
        /// Overload of the operator - 
        /// </summary>
        /// <param name="right">The right hand side.</param>
        /// <returns>The result of the negation.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="right"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Mathematical\VectorBaseExamples.cs" region="OperatorNegate" lang="cs" title="The following example shows how to use the negate operator."/>
        /// </example>
        [SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static VectorBase<T> operator -(VectorBase<T> right)
        {
            Guard.ArgumentNotNull(right, "right");
            var clone = (VectorBase<T>)right.DeepClone();
            clone.Negate();
            return clone;
        }


        /// <summary>
        /// Overload of the operator --
        /// </summary>
        /// <param name="right">The right hand side.</param>
        /// <returns>The result of the addition.</returns>
        /// <exception cref="ArgumentException">The <see cref="IVector{T}.DimensionCount"/> of the current instance does not equal the <see cref="IVector{T}.DimensionCount"/> of <paramref name="right"/>.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="right"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\NGenerics.Examples\DataStructures\Mathematical\VectorBaseExamples.cs" region="OperatorIncrement" lang="cs" title="The following example shows how to use the decrement operator."/>
        /// </example>
        [SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static VectorBase<T> operator --(VectorBase<T> right)
        {
            Guard.ArgumentNotNull(right, "right");
            var clone = (VectorBase<T>)right.DeepClone();
            clone.Decrement();
            return clone;
        }

        #endregion
    }
}