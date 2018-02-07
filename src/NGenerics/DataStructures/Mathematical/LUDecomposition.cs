/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/


using System;
using System.Diagnostics.CodeAnalysis;
using NGenerics.Util;

namespace NGenerics.DataStructures.Mathematical
{
   /// <summary>
   ///   LU decomposition (Gaussian elimination) of a rectangular Matrix.
   /// </summary>
   /// <remarks>
   ///   For an m-by-n Matrix <c>A</c> with m >= n, the LU decomposition is an m-by-n
   ///   unit lower triangular Matrix <c>L</c>, an n-by-n upper triangular Matrix <c>U</c>,
   ///   and a permutation vector <c>piv</c> of length m so that <c>A(piv)=L*U</c>.
   ///   If m &lt; n, then <c>L</c> is m-by-m and <c>U</c> is m-by-n.
   /// </remarks>
   /// <remarks>
   /// Adapted from the JAMA package : http://math.nist.gov/javanumerics/jama/
   /// </remarks>
   public class LUDecomposition : IDecomposition
   {

      #region Globals

      // Storage of the LU decomposition
      private Matrix _lu;

      private int _pivotSign;
      private int[] _pivots;

      #endregion

      #region Construction


      /// <param name="matrix">The matrix.</param>
      public LUDecomposition(Matrix matrix)
      {
         Guard.ArgumentNotNull(matrix, "matrix");
          matrix.ValidateIsSquare();
         Decompose(matrix);
      }

      #endregion

      #region Public Members

      /// <summary>
      /// Gets a value indicating whether the matrix is non singular.
      /// </summary>
      /// <value><c>true</c> if non singular; otherwise, <c>false</c>.</value>
      [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "NonSingular")]
      public bool NonSingular
      {
         get
         {
            for (var j = 0; j < _lu.Columns; j++)
            {
               if (_lu.GetValue(j, j) == 0)
               {
                  return false;
               }
            }

            return true;
         }
      }


      /// <summary>
      /// Calculates the determinant.
      /// </summary>
      /// <returns>The determinant.</returns>
      public double Determinant()
      {
         double determinant = _pivotSign;

         for (var j = 0; j < _lu.Columns; j++)
         {
            determinant *= _lu.GetValue(j, j);
         }

         return determinant;
      }

      /// <summary>
      ///  Description
      /// returns rank of matrix
      /// </summary>
      public int Rank()
      {
         var rank = 0;

         for (var j = 0; j < _lu.Columns; j++)
         {
            if (_lu.GetValue(j, j)!=0.0) rank++ ;
         }
         return rank;
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Solves the equation for the specified matrices.
      /// </summary>
      /// <param name="B">The result (B).</param>
      private Matrix SolveInternal(Matrix B)
      {
         // Copy right hand side with pivoting
         var nx = B.Columns;

         var subMatrix = B.GetSubMatrix(_pivots, 0, nx - 1);

         // Solve L*Y = B(piv,:)
         for (var k = 0; k < _lu.Columns; k++)
         {
            for (var i = k + 1; i < _lu.Columns; i++)
            {
               for (var j = 0; j < nx; j++)
               {
                  subMatrix.SetValue(i, j, subMatrix.GetValue(i, j) - (subMatrix.GetValue(k, j) * _lu.GetValue(i, k)));
               }
            }
         }
         // Solve U*X = Y
         for (var k = _lu.Columns - 1; k >= 0; k--)
         {
            for (var j = 0; j < nx; j++)
            {
               subMatrix.SetValue(k, j, subMatrix.GetValue(k, j) / _lu.GetValue(k, k));
            }
            for (var i = 0; i < k; i++)
            {
               for (var j = 0; j < nx; j++)
               {
                  subMatrix.SetValue(i, j, subMatrix.GetValue(i, j) - (subMatrix.GetValue(k, j) * _lu.GetValue(i, k)));
               }
            }
         }

         return subMatrix;
      }

      /// <summary>
      /// Decomposes the specified matrix using a LU decomposition.
      /// </summary>
      /// <param name="matrix">The matrix to decompose.</param>
      public void Decompose(Matrix matrix)
      {
         _lu = matrix.Clone();

         _pivots = new int[_lu.Rows];

         for (var i = 0; i < _lu.Rows; i++)
         {
            _pivots[i] = i;
         }

         _pivotSign = 1;

         var column = new double[_lu.Rows];

         for (var j = 0; j < _lu.Columns; j++)
         {
            for (var i = 0; i < _lu.Rows; i++)
            {
               column[i] = _lu.GetValue(i, j);
            }

            // Apply previous transformations.
            for (var i = 0; i < _lu.Rows; i++)
            {
               // Most of the time is spent in the following dot product.
               var kmax = Math.Min(i, j);
               var s = 0.0;

               for (var k = 0; k < kmax; k++)
               {
                  s += _lu.GetValue(i, k) * column[k];
               }

               _lu.SetValue(i, j, column[i] - s);
               column[i] -= s;
            }

            // Find pivot and exchange if necessary.
            var p = j;

            for (var i = j + 1; i < _lu.Rows; i++)
            {
               if (Math.Abs(column[i]) > Math.Abs(column[p]))
               {
                  p = i;
               }
            }

            if (p != j)
            {
               for (var k = 0; k < _lu.Columns; k++)
               {
                  var t = _lu[p, k];
                  _lu.SetValue(p, k, _lu[j, k]);
                  _lu.SetValue(j, k, t);
               }

               Swapper.Swap(_pivots, p, j);

               _pivotSign = -_pivotSign;
            }

            // Compute multipliers.
            if ((j < _lu.Rows) && (_lu.GetValue(j, j) != 0.0))
            {
               for (var i = j + 1; i < _lu.Rows; i++)
               {
                  _lu.SetValue(i, j, _lu.GetValue(i, j) / _lu.GetValue(j, j));
               }
            }
         }
      }

      /// <summary>
      /// Gets the lower triangular factor (L).
      /// </summary>
      private Matrix GetLowerTriangularFactor()
      {
         var matrix = new Matrix(_lu.Rows, _lu.Columns);

         for (var i = 0; i < _lu.Rows; i++)
         {
            for (var j = 0; j < _lu.Columns; j++)
            {
               if (i > j)
               {
                  matrix.SetValue(i, j, _lu.GetValue(i, j));
               }
               else if (i == j)
               {
                  matrix.SetValue(i, j, 1.0);
               }
               else
               {
                  matrix.SetValue(i, j, 0.0);
               }
            }
         }

         return matrix;
      }

      /// <summary>
      /// Gets the upper triangular factor (U).
      /// </summary>
      private Matrix GetUpperTriangularFactor()
      {
         var matrix = new Matrix(_lu.Rows, _lu.Columns);

         for (var i = 0; i < _lu.Rows; i++)
         {
            for (var j = 0; j < _lu.Columns; j++)
            {
               if (i <= j)
               {
                  matrix.SetValue(i, j, _lu.GetValue(i, j));
               }
               else
               {
                  matrix.SetValue(i, j, 0.0);
               }
            }
         }

         return matrix;
      }

      #endregion

      #region IDecomposition Members

      /// <summary>
      /// Gets the lower triangular factor L, with A=LU.
      /// </summary>
      /// <value>The lower triangular factor.</value>
      public Matrix LeftFactorMatrix
      {
         get {  return GetLowerTriangularFactor(); }
      }

      /// <summary>
      /// Gets the upper triangular factor U, with A=LU.
      /// </summary>
      /// <value>The upper triangular factor.</value>
      public Matrix RightFactorMatrix
      {
         get { return GetUpperTriangularFactor(); }
      }

      /// <summary>
      /// Solve A*X = B
      /// </summary>
      /// <param name="right">A Matrix with as many rows as A and any number of columns.</param>
      /// <returns>The Matrix X, so that A * X = B.</returns>
      /// <exception cref="ArgumentException">Matrix row dimensions must agree.
      /// </exception>
      /// <exception cref="ArgumentException">Matrix is singular.</exception>
      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "0#b")]
      public Matrix Solve(Matrix right)
      {
          Guard.ArgumentNotNull(right, "right");

          Matrix.ValidateEqualRows(right, _lu);

          if (!NonSingular)
          {
              throw new ArgumentException("This operation is only valid on non-singular matrices.");
          }

          return SolveInternal(right);
      }

      #endregion
   }
}