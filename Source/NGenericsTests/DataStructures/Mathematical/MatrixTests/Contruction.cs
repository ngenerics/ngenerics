using System;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.MatrixTests
{
    [TestFixture]
    public class Contruction
    {

        [Test]
        public void Simple()
        {
            var matrix = new Matrix(2, 3);
            Assert.AreEqual(matrix.Rows, 2);
            Assert.AreEqual(matrix.Columns, 3);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void UnsuccessfulRowNegative()
        {
            new Matrix(-1, 2);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionRowZero()
        {
            new Matrix(0, 2);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionColumnNegative()
        {
            new Matrix(2, -1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionColumnZero()
        {
            new Matrix(2, 0);
        }

    }
}