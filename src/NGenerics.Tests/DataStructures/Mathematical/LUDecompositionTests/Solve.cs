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

namespace NGenerics.Tests.DataStructures.Mathematical.LUDecompositionTests
{
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
            Assert.Throws<ArgumentException>(() => decomposition.Solve(matrixB));
        }

    }
}