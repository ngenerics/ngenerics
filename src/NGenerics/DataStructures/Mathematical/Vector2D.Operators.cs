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
    public partial class Vector2D
    {
        #region Operator Overloads

        /// <summary>
        /// Overload of the operator /
        /// </summary>
        /// <param name="left">The left hand side.</param>
        /// <param name="right">The right hand side.</param>
        /// <returns>The result of the division.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="left"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.Operators.cs" region="OperatorDivideDouble" lang="cs" title="The following example shows how to use the divide operator."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.Operators.vb" region="OperatorDivideDouble" lang="vbnet" title="The following example shows how to use the divide operator."/>
        /// </example>
        public static Vector2D operator /(Vector2D left, double right)
        {
            Guard.ArgumentNotNull(left, "left");
            var clone = left.CloneInternal();
            MultiplyInternal(clone, 1/right);
            return clone;
        }


        /// <summary>
        /// Overload of the operator / 
        /// </summary>
        /// <param name="left">The left hand side.</param>
        /// <param name="right">The right hand side.</param>
        /// <returns>The result of the multiplication.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="left"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentNullException"><paramref name="right"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.Operators.cs" region="OperatorDivideVector" lang="cs" title="The following example shows how to use the divide operator."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.Operators.vb" region="OperatorDivideVector" lang="vbnet" title="The following example shows how to use the divide operator."/>
        /// </example>
        public static Vector2D operator /(Vector2D left, Vector2D right)
        {
            Guard.ArgumentNotNull(left, "left");
            Guard.ArgumentNotNull(right, "right");
            var vector2D = left.CloneInternal();
            DivideInternal(vector2D, right);
            return vector2D;
        }


        /// <summary>
        /// Overload of the operator * 
        /// </summary>
        /// <param name="left">The left hand side.</param>
        /// <param name="right">The right hand side.</param>
        /// <returns>The result of the multiplication.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="left"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentNullException"><paramref name="right"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.Operators.cs" region="OperatorMultiplyVector" lang="cs" title="The following example shows how to use the multiply operator."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.Operators.vb" region="OperatorMultiplyVector" lang="vbnet" title="The following example shows how to use the multiply operator."/>
        /// </example>
        public static Matrix operator *(Vector2D left, Vector2D right)
        {
            Guard.ArgumentNotNull(left, "left");
            Guard.ArgumentNotNull(right, "right");
            return MultiplyInternal(left, right);
        }


        /// <summary>
        /// Overload of the operator * 
        /// </summary>
        /// <param name="left">The left hand <see cref="Vector2D"/>.</param>
        /// <param name="right">The right hand side.</param>
        /// <returns>The result of the multiplication.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="left"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.Operators.cs" region="OperatorMultiplyDouble" lang="cs" title="The following example shows how to use the multiply operator."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.Operators.vb" region="OperatorMultiplyDouble" lang="vbnet" title="The following example shows how to use the multiply operator."/>
        /// </example>
        public static Vector2D operator *(Vector2D left, double right)
        {
            Guard.ArgumentNotNull(left, "left");
            var clone = left.CloneInternal();
            MultiplyInternal(clone, right);
            return clone;
        }


        /// <summary>
        /// Overload of the operator + 
        /// </summary>
        /// <param name="left">The left hand <see cref="Vector2D"/>.</param>
        /// <param name="right">The right hand <see cref="Vector2D"/>.</param>
        /// <returns>The result of the addition.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="left"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.Operators.cs" region="OperatorPlusDouble" lang="cs" title="The following example shows how to use the plus."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.Operators.vb" region="OperatorPlusDouble" lang="vbnet" title="The following example shows how to use the plus."/>
        /// </example>
        public static Vector2D operator +(Vector2D left, double right)
        {
            Guard.ArgumentNotNull(left, "left");
            var clone = left.CloneInternal();
            AddInternal(clone, right);
            return clone;
        }


        /// <summary>
        /// Overload of the operator + 
        /// </summary>
        /// <param name="left">The left hand <see cref="Vector2D"/>.</param>
        /// <param name="right">The right hand <see cref="Vector2D"/>.</param>
        /// <returns>The result of the addition.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="left"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentNullException"><paramref name="right"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.Operators.cs" region="OperatorPlusVector" lang="cs" title="The following example shows how to use the plus."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.Operators.vb" region="OperatorPlusVector" lang="vbnet" title="The following example shows how to use the plus."/>
        /// </example>
        [SuppressMessage("Microsoft.Design", "CA1013:OverloadOperatorEqualsOnOverloadingAddAndSubtract")]
        public static Vector2D operator +(Vector2D left, Vector2D right)
        {
            Guard.ArgumentNotNull(left, "left");
            Guard.ArgumentNotNull(right, "right");
            CheckDimensionsEqual(left, right);
            var clone = left.CloneInternal();
            AddInternal(clone, right);
            return clone;
        }


        /// <summary>
        /// Overload of the operator ++
        /// </summary>
        /// <param name="right">The right hand side.</param>
        /// <returns>The result of the addition.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="right"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.Operators.cs" region="OperatorIncrement" lang="cs" title="The following example shows how to use the increment."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.Operators.vb" region="OperatorIncrement" lang="vbnet" title="The following example shows how to use the increment."/>
        /// </example>
        public static Vector2D operator ++(Vector2D right)
        {
            Guard.ArgumentNotNull(right, "right");
            var clone = right.CloneInternal();
            AddInternal(clone, 1);
            return clone;
        }


        /// <summary>
        /// Overload of the operator - 
        /// </summary>
        /// <param name="left">The left hand <see cref="Vector2D"/>.</param>
        /// <param name="right">The right hand <see cref="Vector2D"/>.</param>
        /// <returns>The result of the subtraction.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="left"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentNullException"><paramref name="right"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>        
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.Operators.cs" region="OperatorSubtractVector" lang="cs" title="The following example shows how to use the minus."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.Operators.vb" region="OperatorSubtractVector" lang="vbnet" title="The following example shows how to use the minus."/>
        /// </example>
        [SuppressMessage("Microsoft.Design", "CA1013:OverloadOperatorEqualsOnOverloadingAddAndSubtract")]
        public static Vector2D operator -(Vector2D left, Vector2D right)
        {
            Guard.ArgumentNotNull(left, "left");
            Guard.ArgumentNotNull(right, "right");
            var clone = left.CloneInternal();
            SubtractInternal(clone, right);
            return clone;
        }


        /// <summary>
        /// Overload of the operator - 
        /// </summary>
        /// <param name="left">The left hand <see cref="Vector2D"/>.</param>
        /// <param name="right">The right hand <see cref="Vector2D"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="left"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <returns>The result of the subtraction.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.Operators.cs" region="OperatorSubtractDouble" lang="cs" title="The following example shows how to use the minus."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.Operators.vb" region="OperatorSubtractDouble" lang="vbnet" title="The following example shows how to use the minus."/>
        /// </example>
        public static Vector2D operator -(Vector2D left, double right)
        {
            Guard.ArgumentNotNull(left, "left");
            var clone = left.CloneInternal();
            AddInternal(clone, -right);
            return clone;
        }


        /// <summary>
        /// Overload of the operator - 
        /// </summary>
        /// <param name="right">The right hand <see cref="Vector2D"/>.</param>
        /// <returns>The result of the negation.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="right"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.Operators.cs" region="OperatorNegate" lang="cs" title="The following example shows how to use the negate."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.Operators.vb" region="OperatorNegate" lang="vbnet" title="The following example shows how to use the negate."/>
        /// </example>
        public static Vector2D operator -(Vector2D right)
        {
            Guard.ArgumentNotNull(right, "right");
            var clone = right.CloneInternal();
            clone.Negate();
            return clone;
        }


        /// <summary>
        /// Overload of the operator --
        /// </summary>
        /// <param name="right">The right hand side.</param>
        /// <returns>The result of the addition.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="right"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.Operators.cs" region="OperatorIncrement" lang="cs" title="The following example shows how to use the decrement."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.Operators.vb" region="OperatorIncrement" lang="vbnet" title="The following example shows how to use the decrement."/>
        /// </example>
        public static Vector2D operator --(Vector2D right)
        {
            Guard.ArgumentNotNull(right, "right");
            var clone = right.CloneInternal();
            AddInternal(clone, -1);
            return clone;
        }


        /// <summary>
        /// Copies the elements of the <see cref="Vector2D"/> to a new <see cref="Matrix"/>. 
        /// </summary>
        /// <param name="vector">The <see cref="Vector2D"/> to convert.</param>
        /// <returns>A <see cref="Matrix"/> array containing copies of the elements of the <see cref="Vector2D"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="vector"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.Operators.cs" region="OperatorToMatrix" lang="cs" title="The following example shows how to use the convert to matrix."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.Operators.vb" region="OperatorToMatrix" lang="vbnet" title="The following example shows how to use the convert to matrix."/>
        /// </example>
        public static implicit operator Matrix(Vector2D vector)
        {
            Guard.ArgumentNotNull(vector, "vector");
            return ToMatrixInternal(vector);
        }


        /// <summary>
        /// Copies the elements of the <see cref="ObjectMatrix{T}"/> to a new <see cref="Vector2D"/>. 
        /// </summary>
        /// <param name="matrix">The <see cref="ObjectMatrix{T}"/> to convert.</param>
        /// <returns>A <see cref="Vector2D"/> array containing copies of the elements of the <see cref="ObjectMatrix{T}"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="matrix"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="InvalidCastException"><paramref name="matrix"/> has more than 1 column.</exception>
        /// <exception cref="InvalidCastException"><paramref name="matrix"/> has more than 2 rows.</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.Operators.cs" region="OperatorFromMatrix" lang="cs" title="The following example shows how to use the convert from matrix."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.Operators.vb" region="OperatorFromMatrix" lang="vbnet" title="The following example shows how to use the convert from matrix."/>
        /// </example>
        public static explicit operator Vector2D(ObjectMatrix<double> matrix)
        {
            Guard.ArgumentNotNull(matrix, "matrix");
            return FromMatrixInternal(matrix);
        }


        /// <summary>
        /// Determines whether one specified <see cref="Vector2D"/> is greater than another specified <see cref="IVector{T}"/>. 
        /// </summary>
        /// <param name="left">The left hand side.</param>
        /// <param name="right">The right hand side.</param>
        /// <returns><see langword="true"/> if the <paramref name="left"/>s <see cref="IVector{T}.Magnitude"/> is greater than <paramref name="right"/>s <see cref="IVector{T}.Magnitude"/>; otherwise, <see langword="false"/>.</returns>
        ///  <exception cref="ArgumentNullException"><paramref name="left"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception> 
        ///  <exception cref="ArgumentNullException"><paramref name="right"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.Operators.cs" region="OperatorGreaterThan" lang="cs" title="The following example shows how to use the &gt; operator."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.Operators.vb" region="OperatorGreaterThan" lang="vbnet" title="The following example shows how to use the &gt; operator."/>
        /// </example>
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static bool operator >(Vector2D left, IVector<double> right)
        {
            Guard.ArgumentNotNull(left, "left");
            Guard.ArgumentNotNull(right, "right");
            return (left.Magnitude() > right.Magnitude());
        }


        /// <summary>
        /// Determines whether one specified <see cref="Vector2D"/> is less than another specified <see cref="IVector{T}"/>. 
        /// </summary>
        /// <param name="left">The left hand side.</param>
        /// <param name="right">The right hand side.</param>
        /// <returns><see langword="true"/> if the <paramref name="left"/>s <see cref="IVector{T}.Magnitude"/> is less than <paramref name="right"/>s <see cref="IVector{T}.Magnitude"/>; otherwise, <see langword="false"/>.</returns>
        ///  <exception cref="ArgumentNullException"><paramref name="left"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception> 
        ///  <exception cref="ArgumentNullException"><paramref name="right"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.Operators.cs" region="OperatorLessThan" lang="cs" title="The following example shows how to use the &lt; operator."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.Operators.vb" region="OperatorLessThan" lang="vbnet" title="The following example shows how to use the &lt; operator."/>
        /// </example>
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static bool operator <(Vector2D left, IVector<double> right)
        {
            Guard.ArgumentNotNull(left, "left");
            Guard.ArgumentNotNull(right, "right");
            return (left.Magnitude() < right.Magnitude());
        }


        /// <summary>
        /// Determines whether one specified <see cref="Vector2D"/> is greater than or equal to another specified <see cref="IVector{T}"/>. 
        /// </summary>
        /// <param name="left">The left hand side.</param>
        /// <param name="right">The right hand side.</param>
        /// <returns><see langword="true"/> if the <paramref name="left"/>s <see cref="IVector{T}.Magnitude"/> is greater than or equal to <paramref name="right"/>s <see cref="IVector{T}.Magnitude"/>; otherwise, <see langword="false"/>.</returns>
        ///  <exception cref="ArgumentNullException"><paramref name="left"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception> 
        ///  <exception cref="ArgumentNullException"><paramref name="right"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.Operators.cs" region="OperatorGreaterThanOrEqualTo" lang="cs" title="The following example shows how to use the &gt;= operator."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.Operators.vb" region="OperatorGreaterThanOrEqualTo" lang="vbnet" title="The following example shows how to use the &gt;= operator."/>
        /// </example>
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static bool operator >=(Vector2D left, Vector2D right)
        {
            Guard.ArgumentNotNull(left, "left");
            Guard.ArgumentNotNull(right, "right");
            return (left.Magnitude() >= right.Magnitude());
        }


        /// <summary>
        /// Determines whether one specified <see cref="Vector2D"/> is less than or equal to another specified <see cref="IVector{T}"/>. 
        /// </summary>
        /// <param name="left">The left hand side.</param>
        /// <param name="right">The right hand side.</param>
        /// <returns><see langword="true"/> if the <paramref name="left"/>s <see cref="IVector{T}.Magnitude"/> is less than or equal to <paramref name="right"/>s <see cref="IVector{T}.Magnitude"/>; otherwise, <see langword="false"/>.</returns>
        ///  <exception cref="ArgumentNullException"><paramref name="left"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception> 
        ///  <exception cref="ArgumentNullException"><paramref name="right"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\Vector2DExamples.Operators.cs" region="OperatorLessThanOrEqualTo" lang="cs" title="The following example shows how to use the &lt;= operator."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\Vector2DExamples.Operators.vb" region="OperatorLessThanOrEqualTo" lang="vbnet" title="The following example shows how to use the &lt;= operator."/>
        /// </example>
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static bool operator <=(Vector2D left, Vector2D right)
        {
            Guard.ArgumentNotNull(left, "left");
            Guard.ArgumentNotNull(right, "right");
            return (left.Magnitude() <= right.Magnitude());
        }

        #endregion
    }
}