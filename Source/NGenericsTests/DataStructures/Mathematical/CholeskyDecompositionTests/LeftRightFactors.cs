using System;
using NGenerics.DataStructures.Mathematical;
using NGenerics.Extensions;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.CholeskyDecompositionTests
{
    [TestFixture]
    public class LeftRightFactors
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


            var decomposition = new CholeskyDecomposition(matrixA);


            var AA = decomposition.LeftFactorMatrix * decomposition.RightFactorMatrix;
            Console.WriteLine(AA.ToString());

            Assert.AreEqual(AA.Rows, 5);
            Assert.AreEqual(AA.Columns, 5);


            Assert.IsTrue(matrixA.Equals(AA, DoubleExtensions.DefaultPrecision));


        }

    }
}