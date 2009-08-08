/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical
{
   [TestFixture]
   public class LUDecompositionTest
   {
      [TestFixture]
      public class Determinant
      {

         [Test]
         public void Simple()
         {
            var matrix = new Matrix(3, 3);

            // [ 3,  1,  8 ]
            // [ 2, -5,  4 ]
            // [-1,  6, -2 ]
            // Determinant = 14

            matrix[0, 0] = 3;
            matrix[0, 1] = 1;
            matrix[0, 2] = 8;

            matrix[1, 0] = 2;
            matrix[1, 1] = -5;
            matrix[1, 2] = 4;

            matrix[2, 0] = -1;
            matrix[2, 1] = 6;
            matrix[2, 2] = -2;

            var decomposition = new LUDecomposition(matrix);

            Assert.AreEqual(14.0d, decomposition.Determinant(), 0.00000001d);
         }

      }

      [TestFixture]
      public class LowerTriangularFactor
      {

         [Test]
         public void Simple()
         {
            var matrix = new Matrix(3, 3);

            /*
            A = [ 1    2    3
                  4    5    6
                  7    8    0 ];
             
            L =
                1.0000         0         0
                0.1429    1.0000         0
                0.5714    0.5000    1.0000  
             
            U =
                7.0000    8.0000         0
                     0    0.8571    3.0000
                     0         0    4.5000 
            */

            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[0, 2] = 3;
            matrix[1, 0] = 4;
            matrix[1, 1] = 5;
            matrix[1, 2] = 6;
            matrix[2, 0] = 7;
            matrix[2, 1] = 8;
            matrix[2, 2] = 0;

            var decomposition = new LUDecomposition(matrix);

            var L = decomposition.LeftFactorMatrix;

            Assert.AreEqual(L[0, 0], 1.000, 0.0001);
            Assert.AreEqual(L[0, 1], 0.000, 0.0001);
            Assert.AreEqual(L[0, 2], 0.000, 0.0001);

            Assert.AreEqual(L[1, 0], 0.1429, 0.0001);
            Assert.AreEqual(L[1, 1], 1.0000, 0.0001);
            Assert.AreEqual(L[1, 2], 0.0000, 0.0001);

            Assert.AreEqual(L[2, 0], 0.5714, 0.0001);
            Assert.AreEqual(L[2, 1], 0.5000, 0.0001);
            Assert.AreEqual(L[2, 2], 1.000, 0.0001);
         }

      }

      [TestFixture]
      public class NonSingular
      {

         [Test]
         public void Simple()
         {
            var matrix = new Matrix(3, 3);

            // [ 4,  4,  4 ]
            // [ 4,  4,  4 ]
            // [ 4,  4,  4 ]
            // Determinant = 0

            matrix[0, 0] = 4;
            matrix[0, 1] = 4;
            matrix[0, 2] = 4;

            matrix[1, 0] = 4;
            matrix[1, 1] = 4;
            matrix[1, 2] = 4;

            var decomposition = new LUDecomposition(matrix);
            Assert.IsFalse(decomposition.NonSingular);
         }

      }

      [TestFixture]
      public class Solve
      {
         [Test]
         public void Simple()
         {
            var matrixA = new Matrix(2, 2);

            matrixA[0, 0] = 0;
            matrixA[0, 1] = 1;

            matrixA[1, 0] = 2;
            matrixA[1, 1] = 0;

            var matrixB = new Matrix(2, 2);

            matrixB[0, 0] = 1;
            matrixB[0, 1] = 0;

            matrixB[1, 0] = 0;
            matrixB[1, 1] = -1;

            var decomposition = new LUDecomposition(matrixA);
            var solveMatrix = decomposition.Solve(matrixB);

            Assert.AreEqual(solveMatrix.Rows, 2);
            Assert.AreEqual(solveMatrix.Columns, 2);

            Assert.AreEqual(solveMatrix[0, 0], 0);
            Assert.AreEqual(solveMatrix[0, 1], -0.5);

            Assert.AreEqual(solveMatrix[1, 0], 1);
            Assert.AreEqual(solveMatrix[1, 1], 0);
         }

         [Test]
         [ExpectedException(typeof(ArgumentException))]
         public void ExceptionDifferentRowCounts()
         {
            var matrixA = new Matrix(2, 2);

            matrixA[0, 0] = 0;
            matrixA[0, 1] = 1;

            matrixA[1, 0] = 2;
            matrixA[1, 1] = 0;

            var matrixB = new Matrix(3, 2);

            matrixB[0, 0] = 1;
            matrixB[0, 1] = 0;

            matrixB[1, 0] = 0;
            matrixB[1, 1] = -1;

            matrixB[2, 0] = 1;
            matrixB[2, 1] = 3;

            var decomposition = new LUDecomposition(matrixA);
            var solveMatrix = decomposition.Solve(matrixB);
         }

      }

      [TestFixture]
      public class UpperTriangularFactor
      {

         [Test]
         public void Simple()
         {
            var matrix = new Matrix(3, 3);

            /*
            A = [ 1    2    3
                 4    5    6
                 7    8    0 ];
             
            L =
               1.0000         0         0
               0.1429    1.0000         0
               0.5714    0.5000    1.0000  
             
            U =
               7.0000    8.0000         0
                   0    0.8571    3.0000
                   0         0    4.5000 
            */

            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[0, 2] = 3;
            matrix[1, 0] = 4;
            matrix[1, 1] = 5;
            matrix[1, 2] = 6;
            matrix[2, 0] = 7;
            matrix[2, 1] = 8;
            matrix[2, 2] = 0;

            var decomposition = new LUDecomposition(matrix);

            var upperTriangularFactorMatrix = decomposition.RightFactorMatrix;

            Assert.AreEqual(upperTriangularFactorMatrix[0, 0], 7.0000, 0.0001);
            Assert.AreEqual(upperTriangularFactorMatrix[0, 1], 8.0000, 0.0001);
            Assert.AreEqual(upperTriangularFactorMatrix[0, 2], 0.0000, 0.0001);

            Assert.AreEqual(upperTriangularFactorMatrix[1, 0], 0.0000, 0.0001);
            Assert.AreEqual(upperTriangularFactorMatrix[1, 1], 0.8571, 0.0001);
            Assert.AreEqual(upperTriangularFactorMatrix[1, 2], 3.0000, 0.0001);

            Assert.AreEqual(upperTriangularFactorMatrix[2, 0], 0.0000, 0.0001);
            Assert.AreEqual(upperTriangularFactorMatrix[2, 1], 0.0000, 0.0001);
            Assert.AreEqual(upperTriangularFactorMatrix[2, 2], 4.5000, 0.0001);
         }

      }
   }
}