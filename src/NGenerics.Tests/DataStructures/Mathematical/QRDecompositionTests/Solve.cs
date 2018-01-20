/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.QRDecompositionTests
{
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
            Assert.Throws<ArgumentException>(() => qrDecomposition.Solve(matrixB));
        }

        [Test]
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
            Assert.Throws<ArgumentException>(() => qrDecomposition.Solve(matrixB));
        }

    }
}