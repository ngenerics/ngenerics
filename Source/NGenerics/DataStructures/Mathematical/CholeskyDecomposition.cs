/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html. 
*/

using System;
using System.Diagnostics.CodeAnalysis;
using NGenerics.Util;

namespace NGenerics.DataStructures.Mathematical
{

   /// <summary>
   ///   Cholesky Decomposition of a rectangular Matrix.
   /// </summary>
   /// <remarks>
   /// Adapted from the JAMA package : http://math.nist.gov/javanumerics/jama/
   /// and from Numerical recipes
	/// </remarks>
#if (!SILVERLIGHT && !WINDOWSPHONE)
    [Serializable]
#endif
   public class CholeskyDecomposition : IDecomposition
   {
      #region Globals

       /// <summary>
      ///  Row and column dimension (square matrix).
      ///  @serial matrix dimension.
      /// </summary> 
       private readonly int dimension;
       const string isNotPositiveDefinite = "The Input matrix is not positive definite.";
       const string haveNonMatchingDimensions = "The input parameters supplied have non-matching dimensions.";

      #endregion Globals

      #region Public Members

      /// <summary>
      ///  Cholesky algorithm for symmetric and positive definite matrix.    
      /// </summary>
      /// <param name="matrix">Square, symmetric matrix. </param>
      /// <exception cref="ArgumentNullException"><paramref name="matrix"/> is a null reference.</exception>
      /// <exception cref="ArgumentException"><paramref name="matrix"/> is a not Symmetric.</exception>
      /// <exception cref="ArgumentException"><paramref name="matrix"/> is a null Square.</exception>
      public CholeskyDecomposition(Matrix matrix)
      {
         Guard.ArgumentNotNull(matrix, "matrix");

         dimension = matrix.Rows;
         Decompose(matrix);
      }

      /// <summary>
      /// Given a positive-definite symmetric matrix <c>A[0..n][0..n]</c>, 
      /// this routine constructs its Cholesky decomposition,  <c> A = L*(L^T) </c>. 
      /// </summary>
      /// <remarks>
      /// The operations count is <c>(N^3)/6</c> executions of the inner loop (consisting of 
      /// one multiply and one subtract), with also N square roots. 
      /// This is about a factor 2 better than LU decomposition of <c>A</c> 
      /// (where its symmetry would be ignored).
      /// </remarks>
      /// <param name="matrix">Square Symmetric Definite-defined matrix A. 
      /// </param>
      /// <exception cref="ArgumentNullException"><paramref name="matrix"/> is a null reference.</exception>
      /// <exception cref="ArgumentException"><paramref name="matrix"/> is a not Symmetric.</exception>
      /// <exception cref="ArgumentException"><paramref name="matrix"/> is a null Square.</exception>
      /// <returns> The Cholesky factor L is returned</returns>
      public void Decompose(Matrix matrix)
      {

         Guard.ArgumentNotNull(matrix, "a");


          matrix.ValidateIsSymmetric();
         

         var aRows = matrix.Rows;

         var res = new Matrix(aRows, aRows);

         for (var i = 0; i < aRows; i++)
         {
            int j;
            for (j = i; j < aRows; j++)
            {
               int k;
               double sum;
               for (sum = matrix[i, j], k = i - 1; k >= 0; k--)
               {
                  sum -= res[i, k] * res[j, k];
               }

               if (i == j)
               {
                  if (sum <= 0)
                  {
                      throw new ArgumentException(isNotPositiveDefinite);
                  }

                   res[i, i] = Math.Sqrt(sum);
               }
               else
               {
                  res[j, i] = sum / res[i, i];
               }
            }
         }
         LeftFactorMatrix = res;
      }

      /// <summary>
      /// Given a positive-definite symmetric matrix <c>A[0..n][0..n]</c>, 
      /// this routine constructs its Cholesky decomposition,  <c> A = L*(L^T) </c>. 
      /// </summary>
      /// <remarks>
      /// The operations count is <c>(N^3)/6</c> executions of the inner loop (consisting of 
      /// one multiply and one subtract), with also N square roots. 
      /// This is about a factor 2 better than LU decomposition of <c>A</c> 
      /// (where its symmetry would be ignored).
      /// </remarks>
      /// <param name="a">Square Symmetric Definite-defined matrix A. 
      /// </param>
      /// <exception cref="ArgumentNullException"><paramref name="a"/> is a null reference.</exception>
      /// <exception cref="ArgumentException"><paramref name="a"/> is a not Symmetric.</exception>
      /// <exception cref="ArgumentException"><paramref name="a"/> is a null Square.</exception>
      /// <returns> The Cholesky factor L is returned</returns>
      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "a")]
      public static Matrix QuickDecompose(Matrix a)
      {
         Guard.ArgumentNotNull(a, "a");

          a.ValidateIsSymmetric();

         var aRowCount = a.Rows;

         var res = new Matrix(aRowCount, aRowCount);

         for (var i = 0; i < aRowCount; i++)
         {
            int j;
            for (j = i; j < aRowCount; j++)
            {
               int k;
               double sum;
               for (sum = a[i, j], k = i - 1; k >= 0; k--)
               {
                  sum -= res[i, k] * res[j, k];
               }

               if (i == j)
               {
                  if (sum <= 0)
                  {
                      throw new ArgumentException(isNotPositiveDefinite);
                  }

                  res[i, i] = Math.Sqrt(sum);
               }
               else
               {
                  res[j, i] = sum / res[i, i];
               }
            }
         }
         return res;
      }

      /// <summary>
      /// Solves the set of <c>n</c> linear equations <c> A * x = b </c>.
      /// </summary>
      /// <param name="a">where a is a positive-definite symmetric matrix <c>[0..n][0..n]</c>  </param>
      /// <param name="b"> is input as the right-hand side vector <c>[0..n]</c>.</param>
      /// <exception cref="ArgumentNullException"><paramref name="a"/> is a null reference.</exception>
      /// <exception cref="ArgumentException"><paramref name="a"/> is a not Symmetric.</exception>
      /// <exception cref="ArgumentException"><paramref name="a"/> is a null Square.</exception>
      /// <exception cref="ArgumentException"><paramref name="b"/> and <paramref name="a"/> have different dimensions.</exception>
      /// <returns>The solution vector is returned as <c>[0..n]</c>.</returns>
      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "a")]
      [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "b")]
      public static double[] QuickSolveLinearEquation(Matrix a, double[] b)
      {
         #region Validation

         Guard.ArgumentNotNull(a, "a");
         Guard.ArgumentNotNull(b, "b");

         #endregion

          a.ValidateIsSymmetric();

         var aRowCount = a.Rows;

         if (b.Length != aRowCount)
         {
             throw new ArgumentException(haveNonMatchingDimensions);
         }

          //L is a Cholesky Decomposition
         var decomposeMatrix = QuickDecompose(a);
         var x = new double[aRowCount];
         int k;
         double sum;
         for (var i = 0; i < aRowCount; i++)
         {
            // Solve <c>L * y = b</c>, storing y in x.
            for (sum = b[i], k = i - 1; k >= 0; k--)
            {
               sum -= decomposeMatrix[i, k] * x[k];
            }
            x[i] = sum / decomposeMatrix[i, i];
         }

         for (var i = aRowCount - 1; i >= 0; i--)
         {
            // Solve L^T * x = y.
            for (sum = x[i], k = i + 1; k < aRowCount; k++)
            {
               sum -= decomposeMatrix[k, i] * x[k];
            }
            x[i] = sum / decomposeMatrix[i, i];
         }

         return x;
      }

      #endregion

      #region IDecomposition Members

       /// <summary>
       ///  Gets the lower triangular factor U^T, with A=U^T x U.
       /// </summary>
       /// <returns> L</returns>
       public Matrix LeftFactorMatrix { get; private set; }

       /// <summary>
      /// Gets the upper triangular factor U, with A=U^T x U.
      /// </summary>
      /// <returns> L</returns>
      public Matrix RightFactorMatrix
      {
         get { return LeftFactorMatrix.Transpose(); }
      }

      /// <summary>
      ///       /** Solve A*X = B
      /// </summary>
      /// <param name="right">A Matrix with as many rows as A and any number of columns.</param>
      /// <returns>X so that L*L'*X = B</returns>
      /// <exception cref="ArgumentNullException"><paramref name="right"/> is a null reference.</exception>
      /// <exception cref="ArgumentException"><paramref name="right"/> is not square.</exception>
      public Matrix Solve(Matrix right)
      {
         Guard.ArgumentNotNull(right, "b");

         if ((right.Columns != 1) || (right.Rows != dimension))
         {
             throw new ArgumentException(haveNonMatchingDimensions);
         }

         var x = new double[dimension];
         int k;
         double sum;

         var m = new double[dimension];

         for (var j = 0; j < dimension; j++)
         {
            m[j] = right.GetValue(j, 0);
         }

         for (var i = 0; i < dimension; i++)
         {
            // Solve <c>L * y = b</c>, storing y in x.
            for (sum = m[i], k = i - 1; k >= 0; k--)
            {
               sum -= LeftFactorMatrix[i, k] * x[k];
            }
            x[i] = sum / LeftFactorMatrix[i, i];
         }

         for (var i = dimension - 1; i >= 0; i--)
         {
            // Solve L^T * x = y.
            for (sum = x[i], k = i + 1; k < dimension; k++)
            {
               sum -= LeftFactorMatrix[k, i] * x[k];
            }
            x[i] = sum / LeftFactorMatrix[i, i];
         }


         return new Matrix(dimension, 1, x);
      }

      #endregion

   }
}
