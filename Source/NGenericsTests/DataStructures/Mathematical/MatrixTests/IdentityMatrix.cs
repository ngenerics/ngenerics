using System;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.MatrixTests
{
    [TestFixture]
    public class IdentityMatrix
    {

        [Test]
        public void Simple()
        {
            var matrix = Matrix.IdentityMatrix(10, 10);
            MatrixTest.TestDiagonalValues(matrix, 10, 10, 1);

            matrix = Matrix.IdentityMatrix(4, 7);
            MatrixTest.TestDiagonalValues(matrix, 4, 7, 1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionInvalidRow1()
        {
            Matrix.IdentityMatrix(-1, 10);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionInvalidColumn1()
        {
            Matrix.IdentityMatrix(10, -1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionInvalidRow2()
        {
            Matrix.IdentityMatrix(0, 10);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionInvalidColumn2()
        {
            Matrix.IdentityMatrix(10, 0);
        }

    }
}