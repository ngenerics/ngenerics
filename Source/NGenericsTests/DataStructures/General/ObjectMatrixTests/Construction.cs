using System;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ObjectMatrixTests
{
    [TestFixture]
    public class Construction:ObjectMatrixTest
    {
        [Test]
        public void Simple()
        {
            var matrix = new ObjectMatrix<int>(10, 15);
            Assert.AreEqual(matrix.Rows, 10);
            Assert.AreEqual(matrix.Columns, 15);

            matrix = new ObjectMatrix<int>(5, 13);
            Assert.AreEqual(matrix.Rows, 5);
            Assert.AreEqual(matrix.Columns, 13);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionNegativeRows()
        {
            new ObjectMatrix<int>(-1, 20);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionZeroRows()
        {
            new ObjectMatrix<int>(0, 20);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionNegativeColomns()
        {
            new ObjectMatrix<int>(50, -1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionZeroColumns()
        {
            new ObjectMatrix<int>(50, 0);
        }
    }
}