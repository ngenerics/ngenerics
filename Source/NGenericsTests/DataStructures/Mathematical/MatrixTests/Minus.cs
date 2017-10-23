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

namespace NGenerics.Tests.DataStructures.Mathematical.MatrixTests
{
    [TestFixture]
    public class Minus
    {

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionIncompatibleMatrices()
        {
            var matrix1 = new Matrix(2, 3);
            matrix1[0, 0] = 1;
            matrix1[0, 1] = 2;
            matrix1[0, 2] = -4;
            matrix1[1, 0] = 0;
            matrix1[1, 1] = 3;
            matrix1[1, 2] = -1;

            var matrix2 = MatrixTest.GetTestMatrix();

            matrix1.Subtract(matrix2);
        }

        [Test]
        public void Simple()
        {
            var matrix1 = new Matrix(2, 3);
            matrix1[0, 0] = 1;
            matrix1[0, 1] = 2;
            matrix1[0, 2] = -4;
            matrix1[1, 0] = 0;
            matrix1[1, 1] = 3;
            matrix1[1, 2] = -1;

            var matrix2 = new Matrix(2, 3);
            matrix2[0, 0] = -1;
            matrix2[0, 1] = 0;
            matrix2[0, 2] = 2;
            matrix2[1, 0] = 1;
            matrix2[1, 1] = -5;
            matrix2[1, 2] = 3;

            var expectedMatrix = new Matrix(2, 3);
            expectedMatrix[0, 0] = 2;
            expectedMatrix[0, 1] = 2;
            expectedMatrix[0, 2] = -6;
            expectedMatrix[1, 0] = -1;
            expectedMatrix[1, 1] = 8;
            expectedMatrix[1, 2] = -4;

            var result = matrix1 - matrix2;

            Assert.IsTrue(result.Equals(expectedMatrix));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionIncompatibleMatrices2()
        {
            IMathematicalMatrix matrix1 = new Matrix(2, 3);
            matrix1[0, 0] = 1;
            matrix1[0, 1] = 2;
            matrix1[0, 2] = -4;
            matrix1[1, 0] = 0;
            matrix1[1, 1] = 3;
            matrix1[1, 2] = -1;

            IMathematicalMatrix matrix2 = MatrixTest.GetTestMatrix();

            matrix1.Subtract(matrix2);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionInterfaceMinusNull()
        {
            IMathematicalMatrix matrix = MatrixTest.GetTestMatrix();
            matrix.Subtract(null);
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionSubtractNull()
        {
            var matrix = MatrixTest.GetTestMatrix();
            matrix.Subtract(null);
        }

        [Test]
        public void InterfaceMinus()
        {
            var matrix1 = new Matrix(2, 3);
            matrix1[0, 0] = 1;
            matrix1[0, 1] = 2;
            matrix1[0, 2] = -4;
            matrix1[1, 0] = 0;
            matrix1[1, 1] = 3;
            matrix1[1, 2] = -1;

            var matrix2 = new Matrix(2, 3);
            matrix2[0, 0] = -1;
            matrix2[0, 1] = 0;
            matrix2[0, 2] = 2;
            matrix2[1, 0] = 1;
            matrix2[1, 1] = -5;
            matrix2[1, 2] = 3;

            var expectedMatrix = new Matrix(2, 3);
            expectedMatrix[0, 0] = 2;
            expectedMatrix[0, 1] = 2;
            expectedMatrix[0, 2] = -6;
            expectedMatrix[1, 0] = -1;
            expectedMatrix[1, 1] = 8;
            expectedMatrix[1, 2] = -4;

            var result = (Matrix)((IMathematicalMatrix)matrix1).Subtract(matrix2);

            Assert.IsTrue(result.Equals(expectedMatrix));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullMinus1()
        {
            var matrix1 = new Matrix(2, 3);
            var result = matrix1 - null;
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullMinus2()
        {
            var matrix1 = new Matrix(2, 3);
            var result = null - matrix1;
        }

    }
}