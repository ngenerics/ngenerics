/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/



using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using NGenerics.DataStructures.General;
using NGenerics.Extensions;
using NGenerics.Util;

namespace NGenerics.DataStructures.Mathematical
{
    /// <summary>
    /// A Matrix data structure corresponding to the mathematical matrix used in linear algebra.	
    /// </summary>
    /// <remarks>
    /// Some of the members have been adapted from the JAMA package : http://math.nist.gov/javanumerics/jama/, which is in the public domain.
	/// </remarks>
    [Serializable]
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
    [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
	public class Matrix : ObjectMatrix<double>, IMathematicalMatrix, IEquatable<IMathematicalMatrix>, ICollection<double>
#if (!SILVERLIGHT && !WINDOWSPHONE)
        , ICloneable
#endif
    {

        const string incompatibleMatrices = "Incompatible matrices.  For this operation the matrices should be of the same size.";
        const string incompatibleMatricesTimes = "Incompatible matrices for this operation.  The rows of the input matrix must be equal to the columns of this matrix.";

        #region Construction

        /// <inheritdoc/>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\MatrixExamples.cs" region="Constructor" lang="cs" title="The following example shows how to use the default constructor."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\MatrixExamples.vb" region="Constructor" lang="vbnet" title="The following example shows how to use the default constructor."/>
        /// </example> 
        public Matrix(int rows, int columns)
            : base(rows, columns)
        {
            // Do nothing - initialisation is handled by ObjectMatrix
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix"/> class.
        /// </summary>
        /// <param name="rows">The number of rows.</param>
        /// <param name="columns">The number of columns.</param>
        /// <param name="data">The data to initialise the matrix with.</param>
        public Matrix(int rows, int columns, double[] data)
            : base(rows, columns, data)
        {
            // Do nothing - initialisation is handled by ObjectMatrix
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix"/> class.
        /// </summary>
        /// <param name="rows">The number of rows.</param>
        /// <param name="columns">The number of columns.</param>
        /// <param name="data">The data to initialise the matrix with.</param>
        [CLSCompliant(false)]
        public Matrix(int rows, int columns, double[,] data)
            : base(rows, columns, data)
        {
            // Do nothing - initialisation is handled by ObjectMatrix
        }

        #endregion

        #region IMatrix Members
        /// <inheritdoc />
        IMatrix<double> IMatrix<double>.GetSubMatrix(int rowStart, int columnStart, int rowCount, int columnCount)
        {
            return GetSubMatrix(rowStart, columnStart, rowCount, columnCount);
        }

        #endregion

        #region IMathematicalMatrix Members

        /// <inheritdoc />
        IMathematicalMatrix IMathematicalMatrix.Multiply(IMathematicalMatrix matrix)
        {
            #region Validation

            Guard.ArgumentNotNull(matrix, "matrix");

            // Check the dimensions to make sure the operation is a valid one.
            if (noOfColumns != matrix.Rows)
            {
                throw new ArgumentException(incompatibleMatricesTimes, "matrix");
            }

            #endregion

            var ret = new Matrix(noOfRows, matrix.Columns);

            for (var i = 0; i < noOfRows; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {
                    double sum = 0;

                    for (var k = 0; k < noOfColumns; k++)
                    {
                        sum += (GetValue(i, k) * matrix[k, j]);
                    }

                    ret.SetValue(i, j, sum);
                }
            }

            return ret;
        }

        /// <inheritdoc />
        IMathematicalMatrix IMathematicalMatrix.Multiply(double number)
        {
            return Multiply(number);
        }

        /// <inheritdoc />
        IMathematicalMatrix IMathematicalMatrix.Add(IMathematicalMatrix matrix)
        {
            return AddInternal(this, matrix);
        }


        /// <inheritdoc />
        IMathematicalMatrix IMathematicalMatrix.Negate()
        {
            return Negate();
        }

        /// <inheritdoc />
        IMathematicalMatrix IMathematicalMatrix.Inverse()
        {
            return Inverse();
        }

        /// <inheritdoc />
        IMathematicalMatrix IMathematicalMatrix.Minor(int row, int column)
        {
            return Minor(row, column);
        }

        /// <inheritdoc />
        IMathematicalMatrix IMathematicalMatrix.Adjoint()
        {
            return Adjoint();
        }

        /// <inheritdoc />
        IMathematicalMatrix IMathematicalMatrix.Concatenate(IMathematicalMatrix rightMatrix)
        {
            return ConcatenateInternal(this, rightMatrix);
        }

        /// <inheritdoc />
        IMathematicalMatrix IMathematicalMatrix.Subtract(IMathematicalMatrix matrix)
        {
            #region Validation

            Guard.ArgumentNotNull(matrix, "matrix");

            if ((noOfRows != matrix.Rows) || (noOfColumns != matrix.Columns))
            {
                throw new ArgumentException(incompatibleMatrices, "matrix");
            }

            #endregion

            var ret = new Matrix(noOfRows, noOfColumns);

            for (var i = 0; i < noOfRows; i++)
            {
                for (var j = 0; j < noOfColumns; j++)
                {
                    ret.SetValue(i, j, GetValue(i, j) - matrix[i, j]);
                }
            }

            return ret;
        }

        /// <inheritdoc />
        IMathematicalMatrix IMathematicalMatrix.Transpose()
        {
            return Transpose();
        }

        #endregion

        #region Public Members




        /// <summary>
        /// Calculate the minor of the entry specified.
        /// </summary>
        /// <param name="row">The row index.</param>
        /// <param name="column">The column index.</param>
        /// <returns>The matrix without the row and column specified.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\MatrixExamples.cs" region="Minor" lang="cs" title="The following example shows how to use the Minor method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\MatrixExamples.vb" region="Minor" lang="vbnet" title="The following example shows how to use the Minor method."/>
        /// </example>
        public Matrix Minor(int row, int column)
        {
            #region Validation

            if ((row > Rows - 1) || (row < 0))
            {
                throw new ArgumentOutOfRangeException("row");
            }

            if ((column > Columns - 1) || (column < 0))
            {
                throw new ArgumentOutOfRangeException("column");
            }

            #endregion

            var minor = new Matrix(Rows - 1, Columns - 1);

            var m = 0;

            for (var i = 0; i < Rows; i++)
            {
                // Skip the row specified
                if (i == row)
                {
                    continue;
                }

                var n = 0;

                for (var j = 0; j < Columns; j++)
                {
                    // Skip the column specified
                    if (j == column)
                    {
                        continue;
                    }

                    minor.SetValue(m, n, GetValue(i, j));

                    n++;
                }

                m++;
            }
            return minor;
        }

        /// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\MatrixExamples.cs" region="Determinant" lang="cs" title="The following example shows how to use the Determinant method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\MatrixExamples.vb" region="Determinant" lang="vbnet" title="The following example shows how to use the Determinant method."/>
        /// </example>
        public double Determinant()
        {
            return new LUDecomposition(this).Determinant();
        }


        /// <summary>
        /// Calculates the rank of the matrix.
        /// </summary>
        /// <returns>the rank of the matrix.</returns>
        public double Rank()
        {
            return new LUDecomposition(this).Rank();
        }

        /// <summary>
        /// Solves the equation
        /// A*x = B;
        /// Where A is a square matrix of arbitrary size n and x and b are vectors of size n.
        /// Returns the inverse of square non-singular matrix A.
        /// </summary>
        /// <param name="leftMatrix"> leftMatrix is a square matrix of arbitrary size n and x and.</param>
        /// <param name="rightMatrix"> rightMatrix is a vector of size n</param>
        /// <returns>The inverse of square non-singular matrix <paramref name="leftMatrix"/> as a vector of size n</returns>
        public static Matrix LinearSolve(Matrix leftMatrix, Matrix rightMatrix)
        {
            #region Validation

            Guard.ArgumentNotNull(leftMatrix, "leftMatrix");

            #endregion

            return leftMatrix.Inverse() * rightMatrix;
        }

        /// <summary>
        /// Calculates the adjoint (the transpose of the matrix formed by the cofactors of the elements of determinants) of the matrix.
        /// </summary>
        /// <returns>The Adjoint of the current matrix.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\MatrixExamples.cs" region="Adjoint" lang="cs" title="The following example shows how to use the Adjoint method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\MatrixExamples.vb" region="Adjoint" lang="vbnet" title="The following example shows how to use the Adjoint method."/>
        /// </example>
        public Matrix Adjoint()
        {
            ValidateIsSquare();

            var tmp = new Matrix(Rows, Columns);

            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Columns; j++)
                {
                    tmp.SetValue(
                        i,
                        j,
                        Math.Pow(-1, i + j) * (Minor(i, j)).Determinant()
                    );
                }
            }

            return tmp.Transpose();
        }

     

        /// <summary>
        /// Times the matrices according to the linear algebra operator *.
        /// </summary>
        /// <param name="matrix">The matrix to multiply this matrix with.</param>
        /// <returns>The result of the times operation.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="matrix"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentException">The <see cref="ObjectMatrix{T}.Columns"/> of the current instance do not equal the <see cref="ObjectMatrix{T}.Columns"/> of <paramref name="matrix"/>.</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\MatrixExamples.cs" region="MultiplyMatrixMatrix" lang="cs" title="The following example shows how to use the Multiply method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\MatrixExamples.vb" region="MultiplyMatrixMatrix" lang="vbnet" title="The following example shows how to use the Multiply method."/>
        /// </example>
        public Matrix Multiply(Matrix matrix)
        {
            #region Validation

            Guard.ArgumentNotNull(matrix, "matrix");

            // Check the dimensions to make sure the operation is a valid one.
            if (noOfColumns != matrix.noOfRows)
            {
                throw new ArgumentException(incompatibleMatricesTimes, "matrix");
            }

            #endregion

            var ret = new Matrix(noOfRows, matrix.noOfColumns);

            for (var i = 0; i < noOfRows; i++)
            {
                for (var j = 0; j < matrix.noOfColumns; j++)
                {
                    double sum = 0;

                    for (var k = 0; k < noOfColumns; k++)
                    {
                        sum += (GetValue(i, k) * matrix.GetValue(k, j));
                    }

                    ret.SetValue(i, j, sum);
                }
            }

            return ret;
        }

        /// <summary>
        /// Times the matrices according to the linear algebra operator *.
        /// </summary>
        /// <param name="number">The number to multiply this matrix with.</param>
        /// <returns>The result of the times operation.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\MatrixExamples.cs" region="MultiplyMatrixDouble" lang="cs" title="The following example shows how to use the Multiply method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\MatrixExamples.vb" region="MultiplyMatrixDouble" lang="vbnet" title="The following example shows how to use the Multiply method."/>
        /// </example>
        public Matrix Multiply(double number)
        {
            var ret = new Matrix(noOfRows, noOfColumns);

            for (var i = 0; i < noOfRows; i++)
            {
                for (var j = 0; j < noOfColumns; j++)
                {
                    ret.SetValue(i, j, GetValue(i, j) * number);
                }
            }

            return ret;
        }

        /// <summary>
        /// Adds to matrices according to the linear algebra operator +.
        /// </summary>
        /// <param name="matrix">The matrix to add to this matrix.</param>
        /// <returns>The result of the plus operation.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="matrix"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentException">The <see cref="ObjectMatrix{T}.Columns"/> of the current instance do not equal the <see cref="ObjectMatrix{T}.Columns"/> of <paramref name="matrix"/>.</exception>
        /// <exception cref="ArgumentException">The <see cref="ObjectMatrix{T}.Rows"/> of the current instance do not equal the <see cref="ObjectMatrix{T}.Rows"/> of <paramref name="matrix"/>.</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\MatrixExamples.cs" region="Add" lang="cs" title="The following example shows how to use the Add method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\MatrixExamples.vb" region="Add" lang="vbnet" title="The following example shows how to use the Add method."/>
        /// </example>
        public Matrix Add(Matrix matrix)
        {
            return AddInternal(this, matrix);
        }

        /// <summary>
        /// Negate (multiply all entries with -1) this instance.
        /// </summary>
        /// <returns>An negated representation of the current matrix.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\MatrixExamples.cs" region="Negate" lang="cs" title="The following example shows how to use the Negate method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\MatrixExamples.vb" region="Negate" lang="vbnet" title="The following example shows how to use the Negate method."/>
        /// </example>
        public Matrix Negate()
        {
            return this * -1;
        }

        /// <summary>
        /// Subtracts the matrices according to the linear algebra operator -.
        /// </summary>
        /// <param name="matrix">The matrix to subtract from this matrix.</param>
        /// <returns>The result of the subtraction.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="matrix"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentException">The <see cref="ObjectMatrix{T}.Columns"/> of the current instance do not equal the <see cref="ObjectMatrix{T}.Columns"/> of <paramref name="matrix"/>.</exception>
        /// <exception cref="ArgumentException">The <see cref="ObjectMatrix{T}.Rows"/> of the current instance do not equal the <see cref="ObjectMatrix{T}.Rows"/> of <paramref name="matrix"/>.</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\MatrixExamples.cs" region="Subtract" lang="cs" title="The following example shows how to use the Subtract method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\MatrixExamples.vb" region="Subtract" lang="vbnet" title="The following example shows how to use the Subtract method."/>
        /// </example>
        public Matrix Subtract(Matrix matrix)
        {
            #region Validation

            Guard.ArgumentNotNull(matrix, "matrix");

            if ((noOfRows != matrix.noOfRows) || (noOfColumns != matrix.noOfColumns))
            {
                throw new ArgumentException(incompatibleMatrices, "matrix");
            }

            #endregion

            var ret = new Matrix(noOfRows, noOfColumns);

            for (var i = 0; i < noOfRows; i++)
            {
                for (var j = 0; j < noOfColumns; j++)
                {
                    ret.SetValue(i, j, GetValue(i, j) - matrix.GetValue(i, j));
                }
            }

            return ret;
        }

        /// <summary>
        /// Transposes the matrix.
        /// </summary>
        /// <returns>The transposed matrix.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\MatrixExamples.cs" region="Transpose" lang="cs" title="The following example shows how to use the Transpose method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\MatrixExamples.vb" region="Transpose" lang="vbnet" title="The following example shows how to use the Transpose method."/>
        /// </example>
        public Matrix Transpose()
        {
            var ret = new Matrix(noOfColumns, noOfRows);

            for (var i = 0; i < noOfRows; i++)
            {
                for (var j = 0; j < noOfColumns; j++)
                {
                    ret.SetValue(j, i, GetValue(i, j));
                }
            }

            return ret;
        }

        /// <summary>
        /// Checks if matrix positive definite .
        /// </summary>
        /// <returns>true if matrix is  positive definite.</returns>
        public bool IsPositiveDefinite
        {
            get
            {
                if (noOfRows == noOfColumns)
                {
                    for (var i = 0; i < noOfRows; i++)
                    {
                        for (var j = 0; j < i; j++)
                        {
                            if (GetValue(i, j) != GetValue(j, i))
                            {
                                return false;
                            }
                        }
                    }

                    return true;
                }

                return false;
            }
        }


        /// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\MatrixExamples.cs" region="IsSymmetric" lang="cs" title="The following example shows how to use the IsSymmetric property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\MatrixExamples.vb" region="IsSymmetric" lang="vbnet" title="The following example shows how to use the IsSymmetric property."/>
        /// </example>
        public bool IsSymmetric
        {
            get
            {
                if (noOfRows == noOfColumns)
                {
                    for (var i = 0; i < noOfRows; i++)
                    {
                        for (var j = 0; j < i; j++)
                        {
                            if (GetValue(i, j) != GetValue(j, i))
                            {
                                return false;
                            }
                        }
                    }

                    return true;
                }

                return false;
            }
        }

        /// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\MatrixExamples.cs" region="IsSingular" lang="cs" title="The following example shows how to use the IsSingular property."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\MatrixExamples.vb" region="IsSingular" lang="vbnet" title="The following example shows how to use the IsSingular property."/>
        /// </example>
        public bool IsSingular
        {
            get
            {
                return Determinant() == 0;
            }
        }

        /// <summary>
        /// Verifies whether the matrix is diagonal or not.
        /// </summary>
        /// <value>
        /// 	A boolean value indicating whether the matrix is diagonal or not.
        /// </value>
        public bool IsDiagonal
        {
            get
            {
                if (noOfRows == noOfColumns)
                {
                    for (var i = 0; i < noOfRows; i++)
                    {
                        for (var j = 0; j < i; j++)
                        {
                            if ((GetValue(i, j) != 0) || (GetValue(j, i) != 0))
                            {
                                return false;
                            }
                        }
                    }

                    return true;
                }

                return false;
            }
        }




        /// <summary>
        /// Verifies whether the matrix is Triangular or not.
        /// </summary>
        /// <value>
        /// A TriangularMatrixTypes enum value indicating whether the matrix is UpperTriangular, LowerTriangular, Diagonal or not.
        /// </value>      
        public TriangularMatrixType IsTriangular
        {
            get
            {
                if (noOfRows == noOfColumns)
                {
                    var upper = true;
                    var lower = true;

                    for (var i = 0; i < noOfRows; i++)
                    {
                        for (var j = 0; j < i; j++)
                        {
                            if ((GetValue(i, j) != 0))
                            {
                                upper = false;
                            }
                            if ((GetValue(j, i) != 0))
                            {
                                lower = false;
                            }
                        }
                    }

                    if (upper)
                    {
                        return lower ? TriangularMatrixType.Diagonal : TriangularMatrixType.Upper;
                    }

                    return lower ? TriangularMatrixType.Lower : TriangularMatrixType.None;
                }

                return TriangularMatrixType.None;
            }
        }



        /// <summary>
        /// Inverts this instance.
        /// </summary>
        /// <returns>An inverted representation of the current matrix.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\MatrixExamples.cs" region="Inverse" lang="cs" title="The following example shows how to use the Inverse method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\MatrixExamples.vb" region="Inverse" lang="vbnet" title="The following example shows how to use the Inverse method."/>
        /// </example>
        public Matrix Inverse()
        {
            return Solve(IdentityMatrix(noOfRows, noOfRows));
        }

        /// <summary>
        /// Constructs a diagonal matrix of the specified size with the specified value.
        /// </summary>
        /// <param name="rows">The number of rows.</param>
        /// <param name="columns">The number of columns.</param>
        /// <param name="value">The value of diagonal elements.</param>
        /// <returns>An diagonal matrix of the specified size.</returns>
        public static Matrix Diagonal(int rows, int columns, double value)
        {
            var matrix = new Matrix(rows, columns);
            var N = Math.Min(rows, columns);

            for (var i = 0; i < N; i++)
            {
                matrix.SetValue(i, i, value);
            }
            return matrix;
        }

        /// <summary>
        /// Constructs an identity matrix of the specified size.
        /// </summary>
        /// <param name="rows">The number of rows.</param>
        /// <param name="columns">The number of columns.</param>
        /// <returns>An identity matrix of the specified size.</returns>
        public static Matrix IdentityMatrix(int rows, int columns)
        {
            return Diagonal(rows, columns, 1);
        }


        /// <summary>
        /// Calculates the LHS solution vector if the matrix is square or the least squares solution otherwise.
        /// </summary>
        /// <param name="rightHandSide">The right hand side.</param>
        /// <returns>Returns the LHS solution vector if the matrix is square or the least squares solution otherwise.</returns>
        public Matrix Solve(Matrix rightHandSide)
        {
            IDecomposition decomposition;
            if (IsSquare)
            {
                // if (IsSymmetric)
                //     decomposition = new CholeskyDecomposition(this);
                //  else
                decomposition = new LUDecomposition(this);
            }
            else
            {
                decomposition = new QRDecomposition(this);
            }
            return decomposition.Solve(rightHandSide);
        }


        /// <summary>
        /// Calculates the trace of the current matrix.
        /// </summary>
        /// <value>The sum of the diagonal elements of the matrix.</value>
        public double Trace
        {
            get
            {
                double trace = 0;

                var direction = Math.Min(noOfRows, noOfColumns);

                for (var i = 0; i < direction; i++)
                {
                    trace += GetValue(i, i);
                }

                return trace;
            }
        }


        /// <summary>
        /// Calculates the One Norm for the matrix.
        /// </summary>
        /// <value>The maximum column sum.</value>
        public double OneNorm
        {
            get
            {
                double f = 0;

                for (var j = 0; j < noOfColumns; j++)
                {
                    double s = 0;

                    for (var i = 0; i < noOfRows; i++)
                    {
                        s += Math.Abs(GetValue(i, j));
                    }

                    if (f < s)
                    {
                        f = s;
                    }
                }

                return f;
            }
        }


        /// <summary>
        /// Calculates infinity norm for the matrix.
        /// </summary>
        /// <value>The maximum row sum.</value>
        public double InfinityNorm
        {
            get
            {
                double f = 0;

                for (var i = 0; i < noOfRows; i++)
                {
                    double s = 0;

                    for (var j = 0; j < noOfColumns; j++)
                    {
                        s += Math.Abs(GetValue(i, j));
                    }

                    if (f < s)
                    {
                        f = s;
                    }
                }

                return f;
            }
        }


        /// <summary>
        /// Calculates the Frobenius Norm for the matrix.
        /// </summary>
        /// <value>The square root of sum of squares of all elements.</value>
        public double FrobeniusNorm
        {
            get
            {
                double f = 0;

                for (var i = 0; i < noOfRows; i++)
                {
                    for (var j = 0; j < noOfColumns; j++)
                    {
                        f = Algorithms.MathAlgorithms.Hypotenuse(f, GetValue(i, j));
                    }
                }

                return f;
            }
        }


        /// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\MatrixExamples.cs" region="MultiplyRow" lang="cs" title="The following example shows how to use the MultiplyRow method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\MatrixExamples.vb" region="MultiplyRow" lang="vbnet" title="The following example shows how to use the MultiplyRow method."/>
        /// </example>
        public void MultiplyRow(int row, double number)
        {
            #region Validation

            if ((row > Rows - 1) || (row < 0))
            {
                throw new ArgumentOutOfRangeException("row");
            }

            #endregion

            for (var i = 0; i < Columns; i++)
            {
                SetValue(row, i, GetValue(row, i) * number);
            }
        }


        /// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\MatrixExamples.cs" region="MultiplyColumn" lang="cs" title="The following example shows how to use the MultiplyColumn method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\MatrixExamples.vb" region="MultiplyColumn" lang="vbnet" title="The following example shows how to use the MultiplyColumn method."/>
        /// </example>
        public void MultiplyColumn(int column, double number)
        {
            #region Validation

            if ((column > Columns - 1) || (column < 0))
            {
                throw new ArgumentOutOfRangeException("column");
            }

            #endregion

            for (var i = 0; i < Rows; i++)
            {
                SetValue(i, column, GetValue(i, column) * number);
            }
        }


        /// <summary>
        /// Concatenates two matrices in horizontal manner.
        /// </summary>
        /// <param name="rightMatrix">The right hand matrix to concatenate to the left hand matrix.</param>
        /// <returns>The result of the concatenate operation.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="rightMatrix"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="rightMatrix"/> does not have the same amount of rows as this matrix.</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\MatrixExamples.cs" region="Concatenate" lang="cs" title="The following example shows how to use the Concatenate method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\MatrixExamples.vb" region="Concatenate" lang="vbnet" title="The following example shows how to use the Concatenate method."/>
        /// </example>
        public Matrix Concatenate(Matrix rightMatrix)
        {
            return ConcatenateInternal(this, rightMatrix);
        }


        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\MatrixExamples.cs" region="Clone" lang="cs" title="The following example shows how to use the Clone method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\MatrixExamples.vb" region="Clone" lang="vbnet" title="The following example shows how to use the Clone method."/>
        /// </example>
        public Matrix Clone()
        {
            return new Matrix(noOfRows, noOfColumns, (double[]) data.Clone());
        }

        /// <summary>
        /// Changes signs of all elements of specified column
        /// </summary>
        /// <param name="columnIndex">The index of the column to change the sign of.</param>
        public void ChangeSignColumn(int columnIndex)
        {
            #region Validation

            if ((columnIndex < 0) || (columnIndex > noOfColumns - 1))
            {
                throw new ArgumentOutOfRangeException("columnIndex");
            }

            #endregion

            for (var i = 0; i < noOfRows; i++)
            {
                SetValue(i, columnIndex, -GetValue(i, columnIndex));
            }
        }

        /// <summary>
        /// Changes signs of all elements of specified row
        /// </summary>
        /// <param name="rowIndex">The index of the row to change the sign of.</param>
        public void ChangeSignRow(int rowIndex)
        {
            #region Validation

            if ((rowIndex < 0) || (rowIndex > noOfRows - 1))
            {
                throw new ArgumentOutOfRangeException("rowIndex");
            }

            #endregion

            for (var i = 0; i < noOfColumns; i++)
            {
                SetValue(rowIndex, i, -GetValue(rowIndex, i));
            }
        }

        #endregion

        #region Internal Members

        internal static void ValidateEqualRows(IMatrix<double> leftMatrix, IMatrix<double> rightMatrix) {
            if (leftMatrix.Rows != rightMatrix.Rows) {
                throw new ArgumentException("The current operation is only valid for matrices with equal number of rows.");
            }
        }

        internal void ValidateIsSymmetric() {
            if (!IsSymmetric) {
                throw new ArgumentException("The operation is only valid on a symmetric matrix.");
            }
        }

        /// <summary>
        /// Gets the sub matrix specified with the row indices, the start
        /// column, and the end column.
        /// </summary>
        /// <param name="rows">The row indices.</param>
        /// <param name="columnStart">The column start.</param>
        /// <param name="columnEnd">The column end.</param>
        internal Matrix GetSubMatrix(int[] rows, int columnStart, int columnEnd)
        {
            var tmp = new Matrix(rows.Length, columnEnd - columnStart + 1);

            for (var i = 0; i < rows.Length; i++)
            {
                for (var j = columnStart; j <= columnEnd; j++)
                {
                    tmp.SetValue(i, j - columnStart, GetValue(rows[i], j));
                }
            }

            return tmp;
        }

        #endregion

        #region Private Members

        /// <summary>
        /// Internal addition function.
        /// </summary>
        /// <param name="leftMatrix">The left matrix.</param>
        /// <param name="rightMatrix">The right matrix.</param>
        /// <returns>The result of the addition operation.</returns>
        private static Matrix AddInternal(IMatrix<double> leftMatrix, IMatrix<double> rightMatrix)
        {
            #region Validation

            Guard.ArgumentNotNull(leftMatrix, "leftMatrix");
            Guard.ArgumentNotNull(rightMatrix, "rightMatrix");

            if ((leftMatrix.Rows != rightMatrix.Rows) || (leftMatrix.Columns != rightMatrix.Columns))
            {
                throw new ArgumentException(incompatibleMatrices, "rightMatrix");
            }

            #endregion

            var ret = new Matrix(leftMatrix.Rows, leftMatrix.Columns);

            for (var i = 0; i < leftMatrix.Rows; i++)
            {
                for (var j = 0; j < leftMatrix.Columns; j++)
                {
                    ret.SetValue(i, j, leftMatrix[i, j] + rightMatrix[i, j]);
                }
            }

            return ret;
        }


        /// <summary>
        /// Internal method for concatenation.
        /// </summary>
        /// <param name="leftMatrix">The left hand side matrix.</param>
        /// <param name="rightMatrix">The right hand side matrix.</param>
        /// <returns>The result of the concatenation operation.</returns>
        private static Matrix ConcatenateInternal(IMatrix<double> leftMatrix, IMatrix<double> rightMatrix)
        {
            #region Validation

            Debug.Assert(leftMatrix != null);


            Guard.ArgumentNotNull(rightMatrix, "rightMatrix");

            ValidateEqualRows(leftMatrix, rightMatrix);

            #endregion

            var newMatrix = new Matrix(
                leftMatrix.Rows,
                leftMatrix.Columns + rightMatrix.Columns
            );

            // Copy the left hand matrix into the new matrix
            for (var i = 0; i < leftMatrix.Rows; i++)
            {
                for (var j = 0; j < leftMatrix.Columns; j++)
                {
                    newMatrix.SetValue(i, j, leftMatrix[i, j]);
                }
            }

            // Copy right hand matrix into the new matrix
            for (var i = 0; i < rightMatrix.Rows; i++)
            {
                for (var j = 0; j < rightMatrix.Columns; j++)
                {
                    newMatrix.SetValue(i, j + leftMatrix.Columns, rightMatrix[i, j]);
                }
            }

            return newMatrix;
        }

        #endregion

        #region Operator Overloads

        /// <summary>
        /// Overload of the operator + as in linear algebra.
        /// </summary>
        /// <param name="left">The left hand matrix.</param>
        /// <param name="right">The right hand matrix.</param>
        /// <returns>The result of the addition.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="left"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentNullException"><paramref name="right"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\MatrixExamples.cs" region="OperatorPlus" lang="cs" title="The following example shows how to use the plus operator."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\MatrixExamples.vb" region="OperatorPlus" lang="vbnet" title="The following example shows how to use the plus operator."/>
        /// </example>
        [SuppressMessage("Microsoft.Design", "CA1013:OverloadOperatorEqualsOnOverloadingAddAndSubtract")]
        public static Matrix operator +(Matrix left, Matrix right)
        {
            Guard.ArgumentNotNull(left, "left");
            return left.Add(right);
        }


        /// <summary>
        /// Overload of the operator - as in linear algebra.
        /// </summary>
        /// <param name="left">The left hand matrix.</param>
        /// <param name="right">The right hand matrix.</param>
        /// <returns>The result of the subtraction.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="left"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentNullException"><paramref name="right"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\MatrixExamples.cs" region="OperatorMinus" lang="cs" title="The following example shows how to use the minus operator."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\MatrixExamples.vb" region="OperatorMinus" lang="vbnet" title="The following example shows how to use the minus operator."/>
        /// </example>
        [SuppressMessage("Microsoft.Design", "CA1013:OverloadOperatorEqualsOnOverloadingAddAndSubtract")]
        public static Matrix operator -(Matrix left, Matrix right)
        {
            Guard.ArgumentNotNull(left, "left");
            return left.Subtract(right);
        }


        /// <summary>
        /// Overload of the operator * as in linear algebra.
        /// </summary>
        /// <param name="left">The left hand matrix.</param>
        /// <param name="right">The right hand matrix.</param>
        /// <returns>The result of the multiplication.</returns>     
        /// <exception cref="ArgumentNullException"><paramref name="left"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <exception cref="ArgumentNullException"><paramref name="right"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>   
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\MatrixExamples.cs" region="OperatorMultiplyMatrixMatrix" lang="cs" title="The following example shows how to use the multiply operator."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\MatrixExamples.vb" region="OperatorMultiplyMatrixMatrix" lang="vbnet" title="The following example shows how to use the multiply operator."/>
        /// </example>
        public static Matrix operator *(Matrix left, Matrix right)
        {
            #region Validation

            Guard.ArgumentNotNull(left, "m1");
            Guard.ArgumentNotNull(left, "m2");

            #endregion

            return left.Multiply(right);
        }


        /// <summary>
        /// Overload of the operator * as in linear algebra.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="matrix">The right hand matrix.</param>
        /// <returns>The result of the multiplication.</returns> 
        /// <exception cref="ArgumentNullException"><paramref name="matrix"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\MatrixExamples.cs" region="OperatorMultiplyMatrixDouble" lang="cs" title="The following example shows how to use the multiply operator."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\MatrixExamples.vb" region="OperatorMultiplyMatrixDouble" lang="vbnet" title="The following example shows how to use the multiply operator."/>
        /// </example>
        public static Matrix operator *(double number, Matrix matrix)
        {
            Guard.ArgumentNotNull(matrix, "matrix");
            return matrix.Multiply(number);
        }


        /// <summary>
        /// Overload of the operator * as in linear algebra.
        /// </summary>
        /// <param name="matrix">The number to be multiplied with.</param>
        /// <param name="number">The number.</param>
        /// <returns>The result of the multiplication.</returns>  
        /// <exception cref="ArgumentNullException"><paramref name="matrix"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\MatrixExamples.cs" region="OperatorMultiplyMatrixDouble" lang="cs" title="The following example shows how to use the multiply operator."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\MatrixExamples.vb" region="OperatorMultiplyMatrixDouble" lang="vbnet" title="The following example shows how to use the multiply operator."/>
        /// </example>
        public static Matrix operator *(Matrix matrix, double number)
        {
            Guard.ArgumentNotNull(matrix, "matrix");

            return matrix.Multiply(number);
        }

        #endregion

        #region ICollection<double> Members

        /// <inheritdoc />
        /// <exception cref="NotSupportedException">Always.</exception>
        [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void ICollection<double>.Add(double item)
        {
            throw new NotSupportedException();
        }


        /// <inheritdoc />
        /// <exception cref="NotSupportedException">Always.</exception>
        [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        bool ICollection<double>.Remove(double item)
        {
            throw new NotSupportedException();
        }


        #endregion

        #region ObjectMatrix Overloads

        /// <summary>
        /// Gets the sub matrix.
        /// </summary>
        /// <param name="rowStart">The row start.</param>
        /// <param name="columnStart">The column start.</param>
        /// <param name="rowCount">The row count.</param>
        /// <param name="columnCount">The column count.</param>
        /// <returns>The sub matrix of the current matrix.</returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\MatrixExamples.cs" region="GetSubMatrix" lang="cs" title="The following example shows how to use the GetSubMatrix method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\MatrixExamples.vb" region="GetSubMatrix" lang="vbnet" title="The following example shows how to use the GetSubMatrix method."/>
        /// </example>           
        public new Matrix GetSubMatrix(int rowStart, int columnStart, int rowCount, int columnCount)
        {
            var objectMatrix = base.GetSubMatrix(rowStart, columnStart, rowCount, columnCount);
            var ret = new Matrix(rowCount, columnCount, objectMatrix.Data);
            return ret;
        }

        #endregion

#if (!SILVERLIGHT && !WINDOWSPHONE)
		#region IClonable Members

		/// <inheritdoc />
        object ICloneable.Clone()
        {
            return Clone();
        }

        #endregion
#endif

        #region IEquatable<IMathematicalMatrix> Members

        /// <inheritdoc />
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\MatrixExamples.cs" region="Equals" lang="cs" title="The following example shows how to use the Equals method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\MatrixExamples.vb" region="Equals" lang="vbnet" title="The following example shows how to use the Equals method."/>
        /// </example>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public bool Equals(IMathematicalMatrix other)
        {
            if (other == null)
            {
                return false;
            }

            if (other.Rows != Rows)
            {
                return false;
            }

            if (other.Columns != Columns)
            {
                return false;
            }

            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Columns; j++)
                {
                    if (GetValue(i, j) != other[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }


        /// <summary>
        /// Compares elements with precision factor to solve machine double rounding problem.
        /// </summary>
        /// <param name="other">The other matrix to compare.</param>
        /// <param name="precision">The precision with which to compare.</param>
        /// <returns></returns>
        /// <example>
        /// 	<code source="..\..\Source\Examples\ExampleLibraryCSharp\DataStructures\Mathematical\MatrixExamples.cs" region="Equals" lang="cs" title="The following example shows how to use the Equals method."/>
        /// 	<code source="..\..\Source\Examples\ExampleLibraryVB\DataStructures\Mathematical\MatrixExamples.vb" region="Equals" lang="vbnet" title="The following example shows how to use the Equals method."/>
        /// </example>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters")]
        public bool Equals(IMathematicalMatrix other, double precision)
        {
            if (other == null)
            {
                return false;
            }

            if (other.Rows != Rows)
            {
                return false;
            }

            if (other.Columns != Columns)
            {
                return false;
            }

            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Columns; j++)
                {
                    if (!GetValue(i, j).IsSimilarTo(other[i, j], precision))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        #endregion
    }
}