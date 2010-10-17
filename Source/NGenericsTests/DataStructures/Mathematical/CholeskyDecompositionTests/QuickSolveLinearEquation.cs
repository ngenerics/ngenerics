using NGenerics.DataStructures.Mathematical;
using NGenerics.Extensions;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.CholeskyDecompositionTests
{
    [TestFixture]
    public class QuickSolveLinearEquation
    {
        [Test]
        public void Simple()
        {
            var matrixA = new Matrix(5, 5);

            //      // [ 2,  1,  1,  3,  2 ]
            //      // [ 1,  2,  2,  1,  1 ]
            //      // [ 1,  2,  9,  1,  5 ]
            //      // [ 3,  1,  1,  7,  1 ]
            //      // [ 2,  1,  5,  1,  8 ]

            matrixA[0, 0] = 2;
            matrixA[0, 1] = 1;
            matrixA[0, 2] = 1;
            matrixA[0, 3] = 3;
            matrixA[0, 4] = 2;

            matrixA[1, 0] = 1;
            matrixA[1, 1] = 2;
            matrixA[1, 2] = 2;
            matrixA[1, 3] = 1;
            matrixA[1, 4] = 1;

            matrixA[2, 0] = 1;
            matrixA[2, 1] = 2;
            matrixA[2, 2] = 9;
            matrixA[2, 3] = 1;
            matrixA[2, 4] = 5;

            matrixA[3, 0] = 3;
            matrixA[3, 1] = 1;
            matrixA[3, 2] = 1;
            matrixA[3, 3] = 7;
            matrixA[3, 4] = 1;

            matrixA[4, 0] = 2;
            matrixA[4, 1] = 1;
            matrixA[4, 2] = 5;
            matrixA[4, 3] = 1;
            matrixA[4, 4] = 8;


            var B = new double[5];

            B[0] = -2;
            B[1] = 4;
            B[2] = 3;
            B[3] = -5;
            B[4] = 1;


            var solveMatrix = CholeskyDecomposition.QuickSolveLinearEquation(matrixA, B);

            Assert.AreEqual(solveMatrix.Length, 5);

            Assert.IsTrue(solveMatrix[0].IsSimilarTo(-629.0 / 98.0));
            Assert.IsTrue(solveMatrix[1].IsSimilarTo(237.0 / 49.0));
            Assert.IsTrue(solveMatrix[2].IsSimilarTo(-53.0 / 49.0));
            Assert.IsTrue(solveMatrix[3].IsSimilarTo(62.0 / 49.0));
            Assert.IsTrue(solveMatrix[4].IsSimilarTo(23.0 / 14.0));


        }

    }
}