using System;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ObjectMatrixTests
{
    [TestFixture]
    public class AddColumn:ObjectMatrixTest
    {
        [Test]
        public void Simple()
        {
            var matrix = GetTestMatrix();

            var columnCount = matrix.Columns;
            var rowCount = matrix.Rows;

            matrix.AddColumn();

            Assert.AreEqual(matrix.Columns, columnCount + 1);
            Assert.AreEqual(matrix.Rows, rowCount);

            for (var i = 0; i < rowCount; i++)
            {
                for (var j = 0; j < columnCount; j++)
                {
                    Assert.AreEqual(matrix[i, j], i + j);
                }
            }

            for (var i = 0; i < rowCount; i++)
            {
                Assert.AreEqual(matrix[i, columnCount], default(double));
            }
        }

        [Test]
        public void Values1()
        {
            var matrix = GetTestMatrix();

            var columnCount = matrix.Columns;
            var rowCount = matrix.Rows;

            matrix.AddColumn(0, -1, -2, -3, -4, -5, -6, -7, -8, -9);

            Assert.AreEqual(matrix.Columns, columnCount + 1);
            Assert.AreEqual(matrix.Rows, rowCount);

            for (var i = 0; i < rowCount; i++)
            {
                for (var j = 0; j < columnCount; j++)
                {
                    Assert.AreEqual(matrix[i, j], i + j);
                }
            }

            for (var i = 0; i < rowCount; i++)
            {
                Assert.AreEqual(matrix[i, columnCount], -1 * i);
            }
        }

        [Test]
        public void Values2()
        {
            var matrix = GetTestMatrix();

            var columnCount = matrix.Columns;
            var rowCount = matrix.Rows;

            matrix.AddColumn(0, -1, -2);

            Assert.AreEqual(matrix.Columns, columnCount + 1);
            Assert.AreEqual(matrix.Rows, rowCount);

            for (var i = 0; i < rowCount; i++)
            {
                for (var j = 0; j < columnCount; j++)
                {
                    Assert.AreEqual(matrix[i, j], i + j);
                }
            }

            Assert.AreEqual(matrix[0, columnCount], 0);
            Assert.AreEqual(matrix[1, columnCount], -1);
            Assert.AreEqual(matrix[2, columnCount], -2);
            Assert.AreEqual(matrix[3, columnCount], 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullValues()
        {
            var matrix = GetTestMatrix();
            matrix.AddColumn(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionIncorrectNumberOfColumns()
        {
            var matrix = GetTestMatrix();
            matrix.AddColumn(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
        }
    }
}