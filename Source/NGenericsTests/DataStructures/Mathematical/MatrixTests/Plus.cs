/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.MatrixTests
{
    [TestFixture]
    public class Plus
    {

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
            expectedMatrix[0, 0] = 0;
            expectedMatrix[0, 1] = 2;
            expectedMatrix[0, 2] = -2;
            expectedMatrix[1, 0] = 1;
            expectedMatrix[1, 1] = -2;
            expectedMatrix[1, 2] = 2;

            var result = matrix1 + matrix2;

            Assert.IsTrue(result.Equals(expectedMatrix));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullOperatorPlus1()
        {
            var matrix = MatrixTest.GetTestMatrix();
            var newMatrix = null + matrix;
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullOperatorPlus2()
        {
            var matrix = MatrixTest.GetTestMatrix();
            var newMatrix = matrix + null;
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionIncompatibleMatrices()
        {
            IMathematicalMatrix matrix1 = new Matrix(2, 3);
            matrix1[0, 0] = 1;
            matrix1[0, 1] = 2;
            matrix1[0, 2] = -4;
            matrix1[1, 0] = 0;
            matrix1[1, 1] = 3;
            matrix1[1, 2] = -1;

            IMathematicalMatrix matrix2 = MatrixTest.GetTestMatrix();

            matrix1.Add(matrix2);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionPlusNull()
        {
            IMathematicalMatrix matrix = MatrixTest.GetTestMatrix();
            matrix.Add(null);
        }

        [Test]
        public void ExceptionInterfacePlus()
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
            expectedMatrix[0, 0] = 0;
            expectedMatrix[0, 1] = 2;
            expectedMatrix[0, 2] = -2;
            expectedMatrix[1, 0] = 1;
            expectedMatrix[1, 1] = -2;
            expectedMatrix[1, 2] = 2;

            var result = (Matrix)((IMathematicalMatrix)matrix1).Add(matrix2);

            Assert.IsTrue(result.Equals(expectedMatrix));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionDifferentSizes()
        {
            var matrix1 = new Matrix(2, 3);
            var matrix2 = new Matrix(3, 2);

            // Should throw an ArgumentException since the matrices are of different sizes
            var result = matrix1 + matrix2;
        }
    }
}