/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/

using System;
using NGenerics.DataStructures.General;

namespace NGenerics.DataStructures.Mathematical
{
    /// <summary>
    /// An interface for a Mathematical matrix as in Linear Algebra.
    /// </summary>
    public interface IMathematicalMatrix : IMatrix<double>
    {
        /// <summary>
        /// Gets a value indicating whether this matrix instance is symmetric.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this matrix instance is symmetric; otherwise, <c>false</c>.
        /// </value>
        bool IsSymmetric { get; }

        /// <summary>
        /// Inverts this matrix.
        /// </summary>
        /// <returns>The inverted representation of this instance.</returns>
        IMathematicalMatrix Inverse();

        /// <summary>
        /// Calculates the determinant of the matrix.
        /// </summary>
        /// <returns>The determinant of the matrix.</returns>
        double Determinant();

        /// <summary>
        /// Verifies whether the matrix is singular or not.
        /// </summary>
        /// <value>A boolean value indicating whether the matrix is singular or not.</value>
        bool IsSingular { get;}

        /// <summary>
        /// Negates (multiply all entries with -1) this matrix.
        /// </summary>
        /// <returns>The negated representation of the matrix.</returns>
        IMathematicalMatrix Negate();

        /// <summary>
        /// Subtracts the matrices according to the linear algebra operator -.
        /// </summary>
        /// <param name="matrix">The result of the subtraction.</param>
		/// <returns>The result of the minus operation.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="matrix"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        IMathematicalMatrix Subtract(IMathematicalMatrix matrix);

        /// <summary>
        /// Adds to matrices according to the linear algebra operator +.
        /// </summary>
        /// <param name="matrix">The result of the addition.</param>
		/// <returns>The result of the plus operation.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="matrix"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        IMathematicalMatrix Add(IMathematicalMatrix matrix);

        /// <summary>
        /// Times the matrices according to the linear algebra operator *.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
		/// <returns>The result of the times operation.</returns>
		/// <exception cref="ArgumentException"><see cref="IMatrix{T}.Rows"/> is greater than <see cref="IMatrix{T}.Rows"/> <paramref name="matrix"/>.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="matrix"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        IMathematicalMatrix Multiply(IMathematicalMatrix matrix);
                
        /// <summary>
        /// Times the matrices according to the linear algebra operator *.
        /// </summary>
        /// <param name="number">The number to multiply this matrix with.</param>
        /// <returns>The result of the times operation.</returns>
        IMathematicalMatrix Multiply(double number);

        /// <summary>
        /// Multiplies the row with the specified number.
        /// </summary>
        /// <param name="row">The index of the row to multiply.</param>
		/// <param name="number">The number to multiply each entry in the row with.</param>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="row"/> is negative or larger than the number of rows in the matrix.</exception>
        void MultiplyRow(int row, double number);

        /// <summary>
        /// Multiplies the column with the specified number.
        /// </summary>
        /// <param name="column">The index of the column to multiply.</param>
		/// <param name="number">The number to multiply each entry in the column with.</param>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="column"/> is negative or larger than the number of columns in the matrix.</exception>
        void MultiplyColumn(int column, double number);

        /// <summary>
        /// Transposes the matrix.
        /// </summary>
        /// <returns>The transposed representation of this matrix.</returns>
        /// <value>The transposed matrix.</value>
        IMathematicalMatrix Transpose();

        /// <summary>
        /// Calculate the minor of the entry specified.
        /// </summary>
        /// <param name="row">The row index.</param>
        /// <param name="column">The column index.</param>
        /// <returns>The minor of the entry specified.</returns>
        IMathematicalMatrix Minor(int row, int column);

        /// <summary>
        /// Calculates the adjoint (the transpose of the matrix formed by the cofactors of the elements of determinants) of the matrix.
        /// </summary>
        /// <returns>The adjoint of the matrix.</returns>
        IMathematicalMatrix Adjoint();

        /// <summary>
        /// Concatenates two matrices in horizontal manner.
        /// </summary>
        /// <param name="rightMatrix">The right hand matrix to concatenate to the left hand matrix.</param>
		/// <returns>The result of the concatenate operation.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="rightMatrix"/> is null.</exception>
		/// <exception cref="ArgumentException"><paramref name="rightMatrix"/> does not have the same amount of rows as this matrix.</exception>
        IMathematicalMatrix Concatenate(IMathematicalMatrix rightMatrix);
    }
}
