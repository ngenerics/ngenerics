using System;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.MatrixTests
{
    [TestFixture]
    public class Diagonal
    {

        [Test]
        public void Simple()
        {
            var matrix = Matrix.Diagonal(10, 10, 5);
            MatrixTest.TestDiagonalValues(matrix, 10, 10, 5);

            matrix = Matrix.Diagonal(4, 7, 9);
            MatrixTest.TestDiagonalValues(matrix, 4, 7, 9);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionInvalidRow1()
        {
            Matrix.Diagonal(-1, 10, 4);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionInvalidColumn1()
        {
            Matrix.Diagonal(10, -1, 4);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionInvalidRow2()
        {
            Matrix.Diagonal(0, 10, 4);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionInvalidColumn2()
        {
            Matrix.Diagonal(10, 0, 4);
        }

    }
}