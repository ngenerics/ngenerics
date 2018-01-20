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
    public class Multiply
    {

        [Test]
        public void TimesDouble()
        {
            var matrix1 = new Matrix(2, 3);
            matrix1[0, 0] = 1;
            matrix1[0, 1] = 4;
            matrix1[0, 2] = 5;
            matrix1[1, 0] = -3;
            matrix1[1, 1] = 2;
            matrix1[1, 2] = 7;

            var expectedMatrix = new Matrix(2, 3);
            expectedMatrix[0, 0] = 2;
            expectedMatrix[0, 1] = 8;
            expectedMatrix[0, 2] = 10;
            expectedMatrix[1, 0] = -6;
            expectedMatrix[1, 1] = 4;
            expectedMatrix[1, 2] = 14;

            var result = matrix1 * 2;
            Assert.IsTrue(result.Equals(expectedMatrix));

            result = 2 * matrix1;
            Assert.IsTrue(result.Equals(expectedMatrix));
        }
        [Test]
        public void Multiplication()
        {
            var matrix1 = new Matrix(2, 3);
            matrix1[0, 0] = -2;
            matrix1[0, 1] = 3;
            matrix1[0, 2] = 2;
            matrix1[1, 0] = 4;
            matrix1[1, 1] = 6;
            matrix1[1, 2] = -2;

            var matrix2 = new Matrix(3, 4);
            matrix2[0, 0] = 4;
            matrix2[0, 1] = -1;
            matrix2[0, 2] = 2;
            matrix2[0, 3] = 5;
            matrix2[1, 0] = 3;
            matrix2[1, 1] = 0;
            matrix2[1, 2] = 1;
            matrix2[1, 3] = 1;
            matrix2[2, 0] = -2;
            matrix2[2, 1] = 3;
            matrix2[2, 2] = 5;
            matrix2[2, 3] = -3;

            var expectedMatrix = new Matrix(2, 4);
            expectedMatrix[0, 0] = -3;
            expectedMatrix[0, 1] = 8;
            expectedMatrix[0, 2] = 9;
            expectedMatrix[0, 3] = -13;
            expectedMatrix[1, 0] = 38;
            expectedMatrix[1, 1] = -10;
            expectedMatrix[1, 2] = 4;
            expectedMatrix[1, 3] = 32;

            var result = matrix1 * matrix2;

            Assert.IsTrue(result.Equals(expectedMatrix));
        }


        [Test]
        public void InterfaceTimesDouble()
        {
            var matrix1 = new Matrix(2, 3);
            matrix1[0, 0] = 1;
            matrix1[0, 1] = 4;
            matrix1[0, 2] = 5;
            matrix1[1, 0] = -3;
            matrix1[1, 1] = 2;
            matrix1[1, 2] = 7;

            var expectedMatrix = new Matrix(2, 3);
            expectedMatrix[0, 0] = 2;
            expectedMatrix[0, 1] = 8;
            expectedMatrix[0, 2] = 10;
            expectedMatrix[1, 0] = -6;
            expectedMatrix[1, 1] = 4;
            expectedMatrix[1, 2] = 14;

            var result = (Matrix)((IMathematicalMatrix)matrix1).Multiply(2);
            Assert.IsTrue(result.Equals(expectedMatrix));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionInterfaceIncompatibleMatrices()
        {
            IMathematicalMatrix matrix1 = new Matrix(2, 3);
            matrix1[0, 0] = 1;
            matrix1[0, 1] = 2;
            matrix1[0, 2] = -4;
            matrix1[1, 0] = 0;
            matrix1[1, 1] = 3;
            matrix1[1, 2] = -1;

            IMathematicalMatrix matrix2 = MatrixTest.GetTestMatrix();

            matrix1.Multiply(matrix2);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionInterfaceTimesNull()
        {
            IMathematicalMatrix matrix = MatrixTest.GetTestMatrix();
            matrix.Multiply(null);
        }

        [Test]
        public void InterfaceMultiplication()
        {
            var matrix1 = new Matrix(2, 3);
            matrix1[0, 0] = -2;
            matrix1[0, 1] = 3;
            matrix1[0, 2] = 2;
            matrix1[1, 0] = 4;
            matrix1[1, 1] = 6;
            matrix1[1, 2] = -2;

            var matrix2 = new Matrix(3, 4);
            matrix2[0, 0] = 4;
            matrix2[0, 1] = -1;
            matrix2[0, 2] = 2;
            matrix2[0, 3] = 5;
            matrix2[1, 0] = 3;
            matrix2[1, 1] = 0;
            matrix2[1, 2] = 1;
            matrix2[1, 3] = 1;
            matrix2[2, 0] = -2;
            matrix2[2, 1] = 3;
            matrix2[2, 2] = 5;
            matrix2[2, 3] = -3;

            var expectedMatrix = new Matrix(2, 4);
            expectedMatrix[0, 0] = -3;
            expectedMatrix[0, 1] = 8;
            expectedMatrix[0, 2] = 9;
            expectedMatrix[0, 3] = -13;
            expectedMatrix[1, 0] = 38;
            expectedMatrix[1, 1] = -10;
            expectedMatrix[1, 2] = 4;
            expectedMatrix[1, 3] = 32;

            var result = (Matrix)((IMathematicalMatrix)matrix1).Multiply(matrix2);

            Assert.IsTrue(result.Equals(expectedMatrix));
        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IncompatibleSizes()
        {
            var matrix1 = new Matrix(2, 3);
            var matrix2 = new Matrix(4, 2);
            var result = matrix1 * matrix2;							// Should throw an ArgumentException since the matrices are of incompatible sizes
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionMultiplicationNull1()
        {
            var matrix = new Matrix(2, 3);
            var result = matrix * null;
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNull2()
        {
            var matrix = new Matrix(2, 3);
            var result = null * matrix;
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNull3()
        {
            var result = ((Matrix)null) * 3;
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNull4()
        {
            var result = 3 * ((Matrix)null);
        }
    }
}