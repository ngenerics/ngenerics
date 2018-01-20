/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NGenerics.DataStructures.General;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.MatrixTests
{
    [TestFixture]
    public class GetSubMatrix
    {

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionInvalidGetSubMatrix1()
        {
            var matrix = MatrixTest.GetTestMatrix();
            matrix.GetSubMatrix(-1, 0, 1, 1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionInvalidGetSubMatrix2()
        {
            var matrix = MatrixTest.GetTestMatrix();
            matrix.GetSubMatrix(0, -1, 1, 1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionInvalidGetSubMatrix3()
        {
            var matrix = MatrixTest.GetTestMatrix();
            matrix.GetSubMatrix(0, 0, 0, 1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionInvalidGetSubMatrix4()
        {
            var matrix = MatrixTest.GetTestMatrix();
            matrix.GetSubMatrix(0, 0, 1, 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionInvalidGetSubMatrix5()
        {
            var matrix = MatrixTest.GetTestMatrix();
            matrix.GetSubMatrix(0, 0, 6, 6);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionInvalidGetSubMatrix6()
        {
            var matrix = MatrixTest.GetTestMatrix();
            matrix.GetSubMatrix(0, 0, 4, 7);
        }

        [Test]
        public void Simple()
        {
            var matrix = MatrixTest.GetTestMatrix();

            var subMatrix = matrix.GetSubMatrix(0, 0, 3, 3);

            Assert.AreEqual(subMatrix.Rows, 3);
            Assert.AreEqual(subMatrix.Columns, 3);

            for (var i = 0; i < subMatrix.Rows; i++)
            {
                for (var j = 0; j < subMatrix.Columns; j++)
                {
                    Assert.AreEqual(subMatrix[i, j], i + j);
                }
            }

            subMatrix = matrix.GetSubMatrix(1, 2, 3, 3);

            for (var i = 0; i < subMatrix.Rows; i++)
            {
                for (var j = 0; j < subMatrix.Columns; j++)
                {
                    Assert.AreEqual(subMatrix[i, j], i + 1 + j + 2);
                }
            }
        }

        [Test]
        public void InterfaceGetSubMatrix()
        {
            var matrix = MatrixTest.GetTestMatrix();

            var subMatrix = matrix.GetSubMatrix(0, 0, 3, 3);

            Assert.AreEqual(subMatrix.Rows, 3);
            Assert.AreEqual(subMatrix.Columns, 3);

            for (var i = 0; i < subMatrix.Rows; i++)
            {
                for (var j = 0; j < subMatrix.Columns; j++)
                {
                    Assert.AreEqual(subMatrix[i, j], i + j);
                }
            }

            subMatrix = (Matrix)((IMatrix<double>)matrix).GetSubMatrix(1, 2, 3, 3);

            for (var i = 0; i < subMatrix.Rows; i++)
            {
                for (var j = 0; j < subMatrix.Columns; j++)
                {
                    Assert.AreEqual(subMatrix[i, j], i + 1 + j + 2);
                }
            }
        }

    }
}