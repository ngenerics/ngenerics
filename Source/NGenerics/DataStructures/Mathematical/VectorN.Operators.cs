/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
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
    public partial class VectorN
    {

        /// <summary>
        /// Copies the elements of the <see cref="VectorBase{T}"/> to a new <see cref="Matrix"/>. 
        /// </summary>
        /// <param name="vector">The <see cref="VectorBase{T}"/> to convert.</param>
        /// <returns>A <see cref="Matrix"/> array containing copies of the elements of the <see cref="VectorBase{T}"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="vector"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\VectorNExamples.Operators.cs" region="OperatorToMatrix" lang="cs" title="The following example shows how to use the convert to matrix operator."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\VectorNExamples.Operators.vb" region="OperatorToMatrix" lang="vbnet" title="The following example shows how to use the convert to matrix operator."/>
        /// </example>
        public static implicit operator Matrix(VectorN vector)
        {
            Guard.ArgumentNotNull(vector, "vector");
            return ToMatrixInternal(vector);
        }


        /// <summary>
        /// Copies the elements of the <see cref="ObjectMatrix{T}"/> to a new <see cref="VectorBase{T}"/>. 
        /// </summary>
        /// <param name="matrix">The <see cref="ObjectMatrix{T}"/> to convert.</param>
        /// <returns>A <see cref="VectorBase{T}"/> array containing copies of the elements of the <see cref="ObjectMatrix{T}"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="matrix"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="InvalidCastException"><paramref name="matrix"/> has more than 1 column.</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\VectorNExamples.Operators.cs" region="OperatorFromMatrix" lang="cs" title="The following example shows how to use the convert from matrix operator."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\VectorNExamples.Operators.vb" region="OperatorFromMatrix" lang="vbnet" title="The following example shows how to use the convert from matrix operator."/>
        /// </example>
        public static explicit operator VectorN(ObjectMatrix<double> matrix)
        {
            Guard.ArgumentNotNull(matrix, "matrix");
            return FromMatrixInternal(matrix);
        }


        /// <summary>
        /// Determines whether one specified <see cref="VectorBase{T}"/> is greater than another specified <see cref="VectorBase{T}"/>. 
        /// </summary>
        /// <param name="left">The left hand side.</param>
        /// <param name="right">The right hand side.</param>
        /// <returns><see langword="true"/> if the <paramref name="left"/>s <see cref="IVector{T}.Magnitude"/> is greater than <paramref name="right"/>s <see cref="IVector{T}.Magnitude"/>; otherwise, <see langword="false"/>.</returns>
        ///  <exception cref="ArgumentNullException"><paramref name="left"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception> 
        ///  <exception cref="ArgumentNullException"><paramref name="right"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\VectorNExamples.Operators.cs" region="OperatorGreaterThan" lang="cs" title="The following example shows how to use the &gt; operator."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\VectorNExamples.Operators.vb" region="OperatorGreaterThan" lang="vbnet" title="The following example shows how to use the &gt; operator."/>
        /// </example>
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static bool operator >(VectorN left, IVector<double> right)
        {
            Guard.ArgumentNotNull(left, "left");
            Guard.ArgumentNotNull(right, "right");
            return (left.Magnitude() > right.Magnitude());
        }


        /// <summary>
        /// Determines whether one specified <see cref="VectorN"/> is less than another specified <see cref="IVector{T}"/>. 
        /// </summary>
        /// <param name="left">The left hand side.</param>
        /// <param name="right">The right hand side.</param>
        /// <returns><see langword="true"/> if the <paramref name="left"/>s <see cref="IVector{T}.Magnitude"/> is less than <paramref name="right"/>s <see cref="IVector{T}.Magnitude"/>; otherwise, <see langword="false"/>.</returns>
        ///  <exception cref="ArgumentNullException"><paramref name="left"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception> 
        ///  <exception cref="ArgumentNullException"><paramref name="right"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\VectorNExamples.Operators.cs" region="OperatorLessThan" lang="cs" title="The following example shows how to use the &lt; operator."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\VectorNExamples.Operators.vb" region="OperatorLessThan" lang="vbnet" title="The following example shows how to use the &lt; operator."/>
        /// </example>
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static bool operator <(VectorN left, IVector<double> right)
        {
            Guard.ArgumentNotNull(left, "left");
            Guard.ArgumentNotNull(right, "right");
            return (left.Magnitude() < right.Magnitude());
        }


        /// <summary>
        /// Determines whether one specified <see cref="VectorN"/> is greater than or equal to another specified <see cref="IVector{T}"/>. 
        /// </summary>
        /// <param name="left">The left hand side.</param>
        /// <param name="right">The right hand side.</param>
        /// <returns><see langword="true"/> if the <paramref name="left"/>s <see cref="IVector{T}.Magnitude"/> is greater than or equal to <paramref name="right"/>s <see cref="IVector{T}.Magnitude"/>; otherwise, <see langword="false"/>.</returns>
        ///  <exception cref="ArgumentNullException"><paramref name="left"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception> 
        ///  <exception cref="ArgumentNullException"><paramref name="right"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\VectorNExamples.Operators.cs" region="OperatorGreaterThanOrEqualTo" lang="cs" title="The following example shows how to use the &gt;= operator."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\VectorNExamples.Operators.vb" region="OperatorGreaterThanOrEqualTo" lang="vbnet" title="The following example shows how to use the &gt;= operator."/>
        /// </example>
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static bool operator >=(VectorN left, IVector<double> right)
        {
            Guard.ArgumentNotNull(left, "left");
            Guard.ArgumentNotNull(right, "right");
            return (left.Magnitude() >= right.Magnitude());
        }


        /// <summary>
        /// Determines whether one specified <see cref="VectorN"/> is less than or equal to another specified <see cref="IVector{T}"/>. 
        /// </summary>
        /// <param name="left">The left hand side.</param>
        /// <param name="right">The right hand side.</param>
        /// <returns><see langword="true"/> if the <paramref name="left"/>s <see cref="IVector{T}.Magnitude"/> is less than or equal to <paramref name="right"/>s <see cref="IVector{T}.Magnitude"/>; otherwise, <see langword="false"/>.</returns>
        ///  <exception cref="ArgumentNullException"><paramref name="left"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception> 
        ///  <exception cref="ArgumentNullException"><paramref name="right"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\VectorNExamples.Operators.cs" region="OperatorLessThanOrEqualTo" lang="cs" title="The following example shows how to use the &lt;= operator."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\VectorNExamples.Operators.vb" region="OperatorLessThanOrEqualTo" lang="vbnet" title="The following example shows how to use the &lt;= operator."/>
        /// </example>
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static bool operator <=(VectorN left, IVector<double> right)
        {
            Guard.ArgumentNotNull(left, "left");
            Guard.ArgumentNotNull(right, "right");
            return (left.Magnitude() <= right.Magnitude());
        }

    }
}