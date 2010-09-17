/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using NGenerics.DataStructures.Mathematical;
using NGenerics.Extensions;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.CholeskyDecompositionTest
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

    [TestFixture]
    public class Decompose
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

            //var matrixB = new Matrix(2, 2);

            //matrixB[0, 0] = 1;
            //matrixB[0, 1] = 0;

            //matrixB[1, 0] = 0;
            //matrixB[1, 1] = -1;

            Console.WriteLine(matrixA.ToString());

            var decomposition = new CholeskyDecomposition(matrixA);
            //  Matrix solveMatrix = decomposition.Solve(matrixB);

            var QCMatrix = decomposition.LeftFactorMatrix;

            Console.WriteLine(QCMatrix.ToString());

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

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionNonSymmetricMatrix()
        {
            var matrixA = new Matrix(2, 2);

            matrixA[0, 0] = 0;
            matrixA[0, 1] = 1;

            matrixA[1, 0] = 2;
            matrixA[1, 1] = 0;


            var decomposition = new CholeskyDecomposition(matrixA);
        }

    }

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

    [TestFixture]
    public class Solve
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

            var matrixB = new Matrix(5, 1);

            matrixB[0, 0] = -2;
            matrixB[1, 0] = 4;
            matrixB[2, 0] = 3;
            matrixB[3, 0] = -5;
            matrixB[4, 0] = 1;


            var decomposition = new CholeskyDecomposition(matrixA);

            var solveMatrix = decomposition.Solve(matrixB);


            Assert.AreEqual(solveMatrix.Rows, 5);
            Assert.AreEqual(solveMatrix.Columns, 1);

            Assert.IsTrue(solveMatrix[0, 0].IsSimilarTo(-629.0 / 98.0));
            Assert.IsTrue(solveMatrix[1, 0].IsSimilarTo(237.0 / 49.0));
            Assert.IsTrue(solveMatrix[2, 0].IsSimilarTo(-53.0 / 49.0));
            Assert.IsTrue(solveMatrix[3, 0].IsSimilarTo(62.0 / 49.0));
            Assert.IsTrue(solveMatrix[4, 0].IsSimilarTo(23.0 / 14.0));


        }
    }

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