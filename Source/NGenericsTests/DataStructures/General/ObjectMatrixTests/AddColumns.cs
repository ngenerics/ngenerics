using System;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ObjectMatrixTests
{
    [TestFixture]
    public class AddColumns:ObjectMatrixTest
    {
        [Test]
        public void Multiple()
        {
            var matrix = GetTestMatrix();

            var columnCount = matrix.Columns;
            var rowCount = matrix.Rows;

            matrix.AddColumns(3);

            Assert.AreEqual(matrix.Columns, columnCount + 3);
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
                for (var j = 0; j < 3; j++)
                {
                    Assert.AreEqual(matrix[i, matrix.Columns - j - 1], default(double));
                }
            }
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ESimpletionNegativeColumnCount()
        {
            var matrix = GetTestMatrix();
            matrix.AddColumns(-1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionZeroColumnCount()
        {
            var matrix = GetTestMatrix();
            matrix.AddColumns(0);
        }
    }
}