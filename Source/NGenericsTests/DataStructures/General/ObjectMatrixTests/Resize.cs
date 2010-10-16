using System;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ObjectMatrixTests
{
    [TestFixture]
    public class Resize:ObjectMatrixTest
    {
        [Test]
        public void Smaller()
        {
            var matrix = GetTestMatrix();

            matrix.Resize(2, 2);

            Assert.AreEqual(matrix.Columns, 2);
            Assert.AreEqual(matrix.Rows, 2);

            for (var i = 0; i < 2; i++)
            {
                for (var j = 0; j < 2; j++)
                {
                    Assert.AreEqual(matrix[i, j], i + j);
                }
            }
        }

        [Test]
        public void Larger()
        {
            var matrix = GetTestMatrix();

            var columnCount = matrix.Columns;
            var rowCount = matrix.Rows;

            matrix.Resize(20, 20);

            Assert.AreEqual(matrix.Columns, 20);
            Assert.AreEqual(matrix.Rows, 20);

            for (var i = 0; i < rowCount; i++)
            {
                for (var j = 0; j < columnCount; j++)
                {
                    Assert.AreEqual(matrix[i, j], i + j);
                }
            }

            for (var i = rowCount; i < 20; i++)
            {
                for (var j = columnCount; j < 20; j++)
                {
                    Assert.AreEqual(matrix[i, j], default(double));
                }
            }
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionNegativeNewNumberOfRows()
        {
            var matrix = GetTestMatrix();
            matrix.Resize(-1, 8);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionNegativeNewNumberOfColumns()
        {
            var matrix = GetTestMatrix();
            matrix.Resize(8, -1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionZeroNewNumberOfRows()
        {
            var matrix = GetTestMatrix();
            matrix.Resize(8, 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionZeroNewNumberOfColumns()
        {
            var matrix = GetTestMatrix();
            matrix.Resize(0, 8);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionNegativeNewNumberOfRowsAndNewNumberOfColumns()
        {
            var matrix = GetTestMatrix();
            matrix.Resize(-1, -1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionZeroNewNumberOfColumnsAndNewNumberOfRows()
        {
            var matrix = GetTestMatrix();
            matrix.Resize(0, 0);
        }
    }
}