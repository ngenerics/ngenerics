/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.QRDecompositionTests
{

    public class QRDecompositionTests
    {
        #region Private Members

        /*
         
        Hl = [1]  	H2 = [1, 1/2]  	H3 = [1, 1/2, 1/3]  	H4 = [1, 1/2,1/3,1/4]
	                     [1/2, 1/3] 	 [1/2, 1/3, 1/4] 	     [1/2,1/3,1/4,1/5]
		                                 [1/3, 1/4, 1/5] 	     [1/3,1/4,1/5,1/6]
			                                                     [1/4,1/5,1/6, 1/7]
         
         */

        internal static Matrix GetHilbertMatrix4()
        {
            var matrix = new Matrix(4, 4);

            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    matrix[i, j] = 1 / (j + 1d + i);
                }
            }

            return matrix;
        }

        internal static Matrix GetMatrix()
        {
            var matrix = new Matrix(3, 3);
            matrix[0, 0] = 12;
            matrix[0, 1] = -51;
            matrix[0, 2] = 4;

            matrix[1, 0] = 6;
            matrix[1, 1] = 167;
            matrix[1, 2] = -68;

            matrix[2, 0] = -4;
            matrix[2, 1] = 24;
            matrix[2, 2] = -4;

            return matrix;

        }

        #endregion
    }

    #region Tests

    [TestFixture]
    public class Q : QRDecompositionTests
    {
        [Test]
        public void Simple()
        {
            var decomposition = new QRDecomposition(GetMatrix());

            var matrixQ = decomposition.LeftFactorMatrix;


            Assert.AreEqual(matrixQ[0, 0], -6d / 7d, 0.0000001);
            Assert.AreEqual(matrixQ[0, 1], 69d / 175d, 0.0000001);
            Assert.AreEqual(matrixQ[0, 2], -58d / 175d, 0.0000001);

            Assert.AreEqual(matrixQ[1, 0], -3d / 7d, 0.0000001);
            Assert.AreEqual(matrixQ[1, 1], -158d / 175d, 0.0000001);
            Assert.AreEqual(matrixQ[1, 2], 6d / 175d, 0.0000001);

            Assert.AreEqual(matrixQ[2, 0], 2d / 7d, 0.0000001);
            Assert.AreEqual(matrixQ[2, 1], -6d / 35d, 0.0000001);
            Assert.AreEqual(matrixQ[2, 2], -33d / 35d, 0.0000001);
        }

        [Test]
        public void Hilbert()
        {
            var matrix = GetHilbertMatrix4();

            var decomposition = new QRDecomposition(matrix);
            var matrixQ = decomposition.LeftFactorMatrix;

            Assert.AreEqual(matrixQ[0, 0], -0.84, 0.01);
            Assert.AreEqual(matrixQ[0, 1], 0.52, 0.01);
            Assert.AreEqual(matrixQ[0, 2], -0.15, 0.01);
            Assert.AreEqual(matrixQ[0, 3], 0.03, 0.01);

            Assert.AreEqual(matrixQ[1, 0], -0.42, 0.01);
            Assert.AreEqual(matrixQ[1, 1], -0.44, 0.01);
            Assert.AreEqual(matrixQ[1, 2], 0.73, 0.01);
            Assert.AreEqual(matrixQ[1, 3], -0.32, 0.01);

            Assert.AreEqual(matrixQ[2, 0], -0.28, 0.01);
            Assert.AreEqual(matrixQ[2, 1], -0.53, 0.01);
            Assert.AreEqual(matrixQ[2, 2], -0.14, 0.01);
            Assert.AreEqual(matrixQ[2, 3], 0.79, 0.01);

            Assert.AreEqual(matrixQ[3, 0], -0.21, 0.01);
            Assert.AreEqual(matrixQ[3, 1], -0.50, 0.01);
            Assert.AreEqual(matrixQ[3, 2], -0.65, 0.01);
            Assert.AreEqual(matrixQ[3, 3], -0.53, 0.01);
        }

    }

    [TestFixture]
    public class R : QRDecompositionTests
    {

        [Test]
        public void Simple()
        {
            var decomposition = new QRDecomposition(GetMatrix());

            var matrixR = decomposition.RightFactorMatrix;

            Assert.AreEqual(matrixR[0, 0], -14d, 0.0000001);
            Assert.AreEqual(matrixR[0, 1], -21d, 0.0000001);
            Assert.AreEqual(matrixR[0, 2], 24.571428571428569d, 0.0000001);

            Assert.AreEqual(matrixR[1, 0], 0d, 0.0000001);
            Assert.AreEqual(matrixR[1, 1], -175d, 0.0000001);
            Assert.AreEqual(matrixR[1, 2], 63.657142857142844d, 0.0000001);

            Assert.AreEqual(matrixR[2, 0], 0d, 0.0000001);
            Assert.AreEqual(matrixR[2, 1], 0d, 0.0000001);
            Assert.AreEqual(matrixR[2, 2], 0.11428571428571477d, 0.0000001);
        }
        /* 
       * Hilbert order 4 QR decomposition :
       * 
      Q = 0.84  -0.52  0.15  0.03    R = 1.19  0.67  0.47  0.37
          0.42   0.44 -0.73  0.32        0     0.12  0.13  0.12
          0.28   0.53  0.14  0.79        0     0     0.01  0.01
          0.21   0.50  0.65  0.53        0     0     0     0.00
      */

        [Test]
        public void Hilbert()
        {

            var matrix = GetHilbertMatrix4();

            var decomposition = new QRDecomposition(matrix);
            var matrixR = decomposition.RightFactorMatrix;
            var matrixH = decomposition.H;

            Assert.AreEqual(matrixR[0, 0], -1.19, 0.01);
            Assert.AreEqual(matrixR[0, 1], -0.67, 0.01);
            Assert.AreEqual(matrixR[0, 2], -0.47, 0.01);
            Assert.AreEqual(matrixR[0, 3], -0.37, 0.01);

            Assert.AreEqual(matrixR[1, 0], 0);
            Assert.AreEqual(matrixR[1, 1], -0.12, 0.01);
            Assert.AreEqual(matrixR[1, 2], -0.13, 0.01);
            Assert.AreEqual(matrixR[1, 3], -0.12, 0.01);

            Assert.AreEqual(matrixR[2, 0], 0);
            Assert.AreEqual(matrixR[2, 1], 0);
            Assert.AreEqual(matrixR[2, 2], -0.01, 0.01);
            Assert.AreEqual(matrixR[2, 3], -0.01, 0.01);

            Assert.AreEqual(matrixR[3, 0], 0);
            Assert.AreEqual(matrixR[3, 1], 0);
            Assert.AreEqual(matrixR[3, 2], 0);
            Assert.AreEqual(matrixR[3, 3], -0.0001, 0.0001);
        }

    }

    [TestFixture]
    public class IsFullRank
    {

        [Test]
        public void Simple()
        {
            var a = new Matrix(2, 2);
            a[0, 0] = 0;
            a[0, 1] = 0;
            a[1, 0] = 1;
            a[1, 1] = 0;

            var b = new Matrix(2, 2);
            b[0, 0] = 0;
            b[0, 1] = 0;
            b[1, 0] = 0;
            b[1, 1] = 1;

            var qrDecomposition = new QRDecomposition(a);
            Assert.IsFalse(qrDecomposition.IsFullRank);

            qrDecomposition = new QRDecomposition(b);
            Assert.IsFalse(qrDecomposition.IsFullRank);

            qrDecomposition = new QRDecomposition(a * b);
            Assert.IsFalse(qrDecomposition.IsFullRank);
        }

    }

    [TestFixture]
    public class Solve
    {

        [Test]
        public void Simple()
        {
            var matrixA = new Matrix(3, 2);

            matrixA[0, 0] = 1;
            matrixA[0, 1] = 2;

            matrixA[1, 0] = 3;
            matrixA[1, 1] = 4;

            matrixA[2, 0] = 4;
            matrixA[2, 1] = 2;

            var matrixB = new Matrix(3, 2);

            matrixB[0, 0] = 3;
            matrixB[0, 1] = 4;

            matrixB[1, 0] = 4;
            matrixB[1, 1] = 2;

            matrixB[2, 0] = 1;
            matrixB[2, 1] = 2;

            var decomposition = new QRDecomposition(matrixA);
            var solveMatrix = decomposition.Solve(matrixB);

            Assert.AreEqual(solveMatrix.Rows, 2);
            Assert.AreEqual(solveMatrix.Columns, 2);

            Assert.AreEqual(solveMatrix[0, 0], -0.514285714, 0.00000001);
            Assert.AreEqual(solveMatrix[0, 1], -0.057142857, 0.00000001);

            Assert.AreEqual(solveMatrix[1, 0], 1.4714285714, 0.00000001);
            Assert.AreEqual(solveMatrix[1, 1], 0.8857142857, 0.00000001);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionRankDeficient()
        {
            var matrixA = new Matrix(3, 2);

            matrixA[0, 0] = 1;
            matrixA[0, 1] = 2;
            matrixA[1, 0] = 3;
            matrixA[1, 1] = 4;
            matrixA[2, 0] = 4;
            matrixA[2, 1] = 2;

            var matrixB = new Matrix(2, 2);
            matrixB[0, 0] = 0;
            matrixB[0, 1] = 0;
            matrixB[1, 0] = 0;
            matrixB[1, 1] = 1;

            var qrDecomposition = new QRDecomposition(matrixA);
            qrDecomposition.Solve(matrixB);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionDifferentRowCount()
        {
            var matrixA = new Matrix(2, 2);
            matrixA[0, 0] = 0;
            matrixA[0, 1] = 0;
            matrixA[1, 0] = 1;
            matrixA[1, 1] = 0;

            var matrixB = new Matrix(2, 2);
            matrixB[0, 0] = 0;
            matrixB[0, 1] = 0;
            matrixB[1, 0] = 0;
            matrixB[1, 1] = 1;

            var qrDecomposition = new QRDecomposition(matrixA);
            qrDecomposition.Solve(matrixB);
        }

    }

    #endregion

}
