/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/



using System;
using NGenerics.DataStructures.Mathematical;
using NGenerics.Extensions;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.CholeskyDecompositionTests
{
    [TestFixture]
    public class QuickCholeskyDecomposition
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


            var QCMatrix = CholeskyDecomposition.QuickDecompose(matrixA);


            Assert.AreEqual(QCMatrix.Rows, 5);
            Assert.AreEqual(QCMatrix.Columns, 5);

            Assert.AreEqual(QCMatrix.IsTriangular, TriangularMatrixType.Lower);

            var sqrt2 = Math.Sqrt(2.0);
            var sqrt2inv = 1.0 / sqrt2;

            Assert.IsTrue(QCMatrix[0, 0].IsSimilarTo(sqrt2));

            Assert.IsTrue(QCMatrix[1, 0].IsSimilarTo(sqrt2inv));
            Assert.IsTrue(QCMatrix[1, 1].IsSimilarTo(Math.Sqrt(1.5)));

            Assert.IsTrue(QCMatrix[2, 0].IsSimilarTo(sqrt2inv));
            Assert.IsTrue(QCMatrix[2, 1].IsSimilarTo(Math.Sqrt(1.5)));
            Assert.IsTrue(QCMatrix[2, 2].IsSimilarTo(Math.Sqrt(7.0)));

            Assert.IsTrue(QCMatrix[3, 0].IsSimilarTo(Math.Sqrt(4.5)));
            Assert.IsTrue(QCMatrix[3, 1].IsSimilarTo(-Math.Sqrt(1.0 / 6.0)));
            Assert.IsTrue(QCMatrix[3, 2].IsSimilarTo(0));
            Assert.IsTrue(QCMatrix[3, 3].IsSimilarTo(Math.Sqrt(7.0 / 3.0)));

            Assert.IsTrue(QCMatrix[4, 0].IsSimilarTo(sqrt2));
            Assert.IsTrue(QCMatrix[4, 1].IsSimilarTo(0));
            Assert.IsTrue(QCMatrix[4, 2].IsSimilarTo(4.0 / Math.Sqrt(7.0)));
            Assert.IsTrue(QCMatrix[4, 3].IsSimilarTo(-Math.Sqrt(12.0 / 7.0)));
            Assert.IsTrue(QCMatrix[4, 4].IsSimilarTo(sqrt2));
        }
    }
}