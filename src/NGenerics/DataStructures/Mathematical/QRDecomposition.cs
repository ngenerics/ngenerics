/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/


/*  
 Adapted from the JAMA package : http://math.nist.gov/javanumerics/jama/
*/

using System;
using System.Diagnostics.CodeAnalysis;
using NGenerics.Algorithms;
using NGenerics.Util;

namespace NGenerics.DataStructures.Mathematical
{
   /// <summary>
   /// QR Decomposition.
   /// </summary>
   /// <remarks>
   /// For an qr.Rows-by-qr.Columns matrix A with qr.Rows >= qr.Columns, the QR decomposition is an qr.Rows-by-qr.Columns
   /// orthogonal matrix Q and an qr.Columns-by-qr.Columns upper triangular matrix R so that
   /// A = Q*R.
   /// </remarks>
   /// <remarks>
   /// The QR decomposition always exists, even if the matrix does not have
   /// full rank, so the constructor will never fail.  The primary use of the
   /// QR decomposition is in the least squares solution of non-square systems
   /// of simultaneous linear equations.  This will fail if isFullRank()
   /// returns <c>false</c>.
   /// </remarks>
   /// <remarks>
   /// Adapted from the JAMA package : http://math.nist.gov/javanumerics/jama/
	/// </remarks>
    [Serializable]
   public class QRDecomposition : IDecomposition
   {

      #region Globals

      // Array for internal storage of decomposition.
      private Matrix _qr;

      // Array for internal storage of diagonal of R.
      private double[] _diagonal;

      #endregion

      #region Construction

      /// <param name="matrix">A rectangular matrix.</param>
      public QRDecomposition(Matrix matrix)
      {
         Guard.ArgumentNotNull(matrix, "matrix");
         Decompose(matrix);
      }

      #endregion

      #region Public Members

      /// <summary>
      /// Gets a value indicating whether the matrix is full rank.
      /// </summary>
      /// <value><c>true</c> if R, and hence A, has full rank, else <c>false</c>..</value>
      public bool IsFullRank
      {
         get
         {
            for (var j = 0; j < _qr.Columns; j++)
            {
               if (_diagonal[j] == 0)
               {
                  return false;
               }
            }
            return true;
         }

      }

      /// <summary>
      /// Gets the Householder vectors.
      /// </summary>
      /// <value>Lower trapezoidal matrix whose columns define the reflections.</value>
      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "H")]
      public Matrix H
      {
         get
         {
            var matrix = new Matrix(_qr.Rows, _qr.Columns);

            for (var i = 0; i < _qr.Rows; i++)
            {
               for (var j = 0; j < _qr.Columns; j++)
               {
                  if (i >= j)
                  {
                     matrix.SetValue(i, j, _qr.GetValue(i, j));
                  }
                  else
                  {
                     matrix.SetValue(i, j, 0.0);
                  }
               }
            }
            return matrix;
         }

      }

      /// <summary>
      /// Gets the the upper triangular factor.
      /// </summary>
      /// <returns>The upper triangular factor.</returns>
      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "R")]
      public Matrix UpperTriangularMatrix 
      {
          get
          {
              var matrix = new Matrix(_qr.Columns, _qr.Columns);

              for (var i = 0; i < _qr.Columns; i++)
              {
                  for (var j = 0; j < _qr.Columns; j++)
                  {
                      if (i < j)
                      {
                          matrix.SetValue(i, j, _qr.GetValue(i, j));
                      }
                      else if (i == j)
                      {
                          matrix.SetValue(i, j, _diagonal[i]);
                      }
                      else
                      {
                          matrix.SetValue(i, j, 0.0);
                      }
                  }
              }
              return matrix;
          }
      }

      /// <summary>
      /// Generate and return the (economy-sized) orthogonal factor.
      /// </summary>
      /// <returns>The (economy-sized) orthogonal factor.</returns>
      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Q")]
      public Matrix OrthogonalFactor 
      {
          get
          {
              var matrix = new Matrix(_qr.Rows, _qr.Columns);

              for (var k = _qr.Columns - 1; k >= 0; k--)
              {
                  for (var i = 0; i < _qr.Rows; i++)
                  {
                      matrix.SetValue(i, k, 0.0);
                  }

                  matrix.SetValue(k, k, 1.0);

                  for (var j = k; j < _qr.Columns; j++)
                  {
                      if (_qr.GetValue(k, k) != 0)
                      {
                          var s = 0.0;
                          for (var i = k; i < _qr.Rows; i++)
                          {
                              s += _qr.GetValue(i, k)*matrix.GetValue(i, j);
                          }
                          s = (-s)/_qr.GetValue(k, k);
                          for (var i = k; i < _qr.Rows; i++)
                          {
                              matrix.SetValue(i, j, matrix.GetValue(i, j) + (s*_qr.GetValue(i, k)));
                          }
                      }
                  }
              }
              return matrix;
          }
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Decomposes the specified matrix, using a QR decomposition.
      /// </summary>
      /// <param name="matrix">The matrix to decompose.</param>
      public void Decompose(Matrix matrix)
      {
         _qr = matrix.Clone();
         _diagonal = new double[_qr.Columns];

         // Main loop.
         for (var k = 0; k < _qr.Columns; k++)
         {
            // Compute 2-norm of k-th column without under/overflow.
            double nrm = 0;

            for (var i = k; i < _qr.Rows; i++)
            {
               nrm = MathAlgorithms.Hypotenuse(nrm, _qr[i, k]);
            }

            if (nrm != 0.0)
            {

               // Form k-th Householder vector.
               if (_qr.GetValue(k, k) < 0)
               {
                  nrm = -nrm;
               }
               for (var i = k; i < _qr.Rows; i++)
               {
                  _qr.SetValue(i, k, _qr.GetValue(i, k) / nrm);
               }

               _qr.SetValue(k, k, _qr.GetValue(k, k) + 1.0);

               // Apply transformation to remaining columns.
               for (var j = k + 1; j < _qr.Columns; j++)
               {

                  var s = 0.0;

                  for (var i = k; i < _qr.Rows; i++)
                  {
                     s += _qr.GetValue(i, k) * _qr.GetValue(i, j);
                  }

                  s = (-s) / _qr.GetValue(k, k);

                  for (var i = k; i < _qr.Rows; i++)
                  {
                     _qr.SetValue(i, j, _qr.GetValue(i, j) + (s * _qr.GetValue(i, k)));
                  }
               }
            }
            _diagonal[k] = -nrm;
         }
      }

      #endregion

      #region IDecomposition Members

      /// <summary>
      /// Get the (economy-sized) orthogonal factor Q, with A=QR.
      /// </summary>
      /// <returns>the orthogonal factor.</returns>
      public Matrix LeftFactorMatrix
      {
         get { return OrthogonalFactor; }
      }


      /// <summary>
      /// Gets the the upper triangular factor R, with A=QR.
      /// </summary>
      /// <returns>The upper triangular factor.</returns>
      public Matrix RightFactorMatrix
      {
         get { return UpperTriangularMatrix; }
      }

      /// <summary>
      /// Least squares solution of A*X = B
      /// </summary>
      /// <param name="right">A Matrix with as many rows as A and any number of columns.</param>
      /// <returns>Matrix X that minimizes the two norm of Q*R*X-B.</returns>
      /// <exception cref="ArgumentException">Matrix row dimensions must agree.</exception>
      /// <exception cref="ArgumentException">Matrix is rank deficient.</exception>
      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "0#b")]
      public Matrix Solve(Matrix right)
      {
          Guard.ArgumentNotNull(right, "right");

          Matrix.ValidateEqualRows(right, _qr);

         if (!IsFullRank)
         {
             throw new ArgumentException("Matrix is rank deficient.");
         }

         // Copy right hand side
         var nx = right.Columns;
         var cloneMatrix = right.Clone();

         // Compute Y = transpose(Q)*B
         for (var k = 0; k < _qr.Columns; k++)
         {
            for (var j = 0; j < nx; j++)
            {
               var s = 0.0;
               for (var i = k; i < _qr.Rows; i++)
               {
                  s += _qr.GetValue(i, k) * cloneMatrix.GetValue(i, j);
               }

               s = (-s) / _qr.GetValue(k, k);

               for (var i = k; i < _qr.Rows; i++)
               {
                  cloneMatrix.SetValue(i, j, cloneMatrix.GetValue(i, j) + (s * _qr.GetValue(i, k)));
               }
            }
         }
         // Solve R*X = Y;
         for (var k = _qr.Columns - 1; k >= 0; k--)
         {
            for (var j = 0; j < nx; j++)
            {
               cloneMatrix.SetValue(k, j, cloneMatrix.GetValue(k, j) / _diagonal[k]);
            }
            for (var i = 0; i < k; i++)
            {
               for (var j = 0; j < nx; j++)
               {
                  cloneMatrix.SetValue(i, j, cloneMatrix.GetValue(i, j) - (cloneMatrix.GetValue(k, j) * _qr.GetValue(i, k)));
               }
            }
         }

         return cloneMatrix.GetSubMatrix(0, 0, _qr.Columns, nx);
      }

      #endregion
   }
}