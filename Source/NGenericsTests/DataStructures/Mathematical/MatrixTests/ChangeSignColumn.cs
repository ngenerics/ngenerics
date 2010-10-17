using System;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.MatrixTests
{
    [TestFixture]
    public class ChangeSignColumn
    {

        [Test]
        public void Simple()
        {
            var matrix = new Matrix(3, 3);

            // [ 1,  4,  7 ]
            // [ 2,  5,  8 ]
            // [ 3,  6,  9 ]


            matrix[0, 0] = 1;
            matrix[0, 1] = 4;
            matrix[0, 2] = 7;

            matrix[1, 0] = 2;
            matrix[1, 1] = 5;
            matrix[1, 2] = 8;

            matrix[2, 0] = 3;
            matrix[2, 1] = 6;
            matrix[2, 2] = 9;

            matrix.ChangeSignColumn(1);

            Assert.AreEqual(matrix[0, 1], -4);
            Assert.AreEqual(matrix[1, 1], -5);
            Assert.AreEqual(matrix[2, 1], -6);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionColumnIndexLessThan0()
        {
            var matrix = new Matrix(3, 3);
            matrix.ChangeSignColumn(-1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionColumnIndexGreaterThanColumnCount()
        {
            var matrix = new Matrix(3, 3);
            matrix.ChangeSignColumn(3);
        }

    }
}