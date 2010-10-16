using System;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ObjectMatrixTests
{
    [TestFixture]
    public class InterchangeRows:ObjectMatrixTest
    {
        [Test]
        public void Simple()
        {
            var matrix = GetTestMatrix();

            var columnCount = matrix.Columns;
            var rowCount = matrix.Rows;

            matrix.InterchangeRows(0, 1);

            Assert.AreEqual(matrix.Columns, columnCount);
            Assert.AreEqual(matrix.Rows, rowCount);

            for (var i = 0; i < matrix.Rows; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {
                    if (i == 0)
                    {
                        Assert.AreEqual(matrix[i, j], (i + 1) + (j));
                    }
                    else if (i == 1)
                    {
                        Assert.AreEqual(matrix[i, j], (i - 1) + (j));
                    }
                    else
                    {
                        Assert.AreEqual(matrix[i, j], i + j);
                    }
                }
            }
        }

        [Test]
        public void SameRow()
        {
            var matrix = GetTestMatrix();

            var columnCount = matrix.Columns;
            var rowCount = matrix.Rows;

            matrix.InterchangeRows(1, 1);

            Assert.AreEqual(matrix.Columns, columnCount);
            Assert.AreEqual(matrix.Rows, rowCount);

            TestIfEqual(GetTestMatrix(), matrix);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionNegativeFirstRow()
        {
            var matrix = GetTestMatrix();
            matrix.InterchangeRows(-1, 1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionFirstRowTooLarge()
        {
            var matrix = GetTestMatrix();
            matrix.InterchangeRows(matrix.Rows, 1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionNegativeSecondRow()
        {
            var matrix = GetTestMatrix();
            matrix.InterchangeRows(0, -1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionSecondRowTooLarge()
        {
            var matrix = GetTestMatrix();
            matrix.InterchangeRows(0, matrix.Rows);
        }
    }
}