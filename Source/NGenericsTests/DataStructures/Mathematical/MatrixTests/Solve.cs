/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.MatrixTests
{
    [TestFixture]
    public class Solve
    {

        [Test]
        public void Square()
        {
            // A: [2,2]((0,1),(2,0))
            // > B: [2,2]((1,0),(0,-1))
            // > X: [2,2]((0,-0.5),(1,0))

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

            var solveMatrix = matrixA.Solve(matrixB);

            Assert.AreEqual(solveMatrix.Rows, 2);
            Assert.AreEqual(solveMatrix.Columns, 2);

            Assert.AreEqual(solveMatrix[0, 0], 0);
            Assert.AreEqual(solveMatrix[0, 1], -0.5);

            Assert.AreEqual(solveMatrix[1, 0], 1);
            Assert.AreEqual(solveMatrix[1, 1], 0);
        }

        [Test]
        public void Rectangular()
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

            var solveMatrix = matrixA.Solve(matrixB);

            Assert.AreEqual(solveMatrix.Rows, 2);
            Assert.AreEqual(solveMatrix.Columns, 2);

            Assert.AreEqual(solveMatrix[0, 0], -0.514285714, 0.00000001);
            Assert.AreEqual(solveMatrix[0, 1], -0.057142857, 0.00000001);

            Assert.AreEqual(solveMatrix[1, 0], 1.4714285714, 0.00000001);
            Assert.AreEqual(solveMatrix[1, 1], 0.8857142857, 0.00000001);
        }

    }
}