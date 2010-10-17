using System;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.MatrixTests
{
    [TestFixture]
    public class MultiplyRow
    {

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionIndexNegative()
        {
            var matrix = MatrixTest.GetTestMatrix();
            matrix.MultiplyRow(-1, 2);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionRowGreaterThanRows()
        {
            var matrix = MatrixTest.GetTestMatrix();
            matrix.MultiplyRow(matrix.Rows, 2);
        }

        [Test]
        public void RowFirst()
        {
            var matrix = MatrixTest.GetTestMatrix();
            matrix.MultiplyRow(0, 2);

            for (var i = 0; i < matrix.Rows; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {
                    if (i == 0)
                    {
                        Assert.AreEqual(matrix[i, j], 2 * (i + j));
                    }
                    else
                    {
                        Assert.AreEqual(matrix[i, j], i + j);
                    }
                }
            }
        }

        [Test]
        public void RowLast()
        {
            var matrix = MatrixTest.GetTestMatrix();
            matrix.MultiplyRow(matrix.Rows - 1, 2);

            for (var i = 0; i < matrix.Rows; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {
                    if (i == matrix.Rows - 1)
                    {
                        Assert.AreEqual(matrix[i, j], 2 * (i + j));
                    }
                    else
                    {
                        Assert.AreEqual(matrix[i, j], i + j);
                    }
                }
            }
        }

        [Test]
        public void RowArbitrary()
        {
            var matrix = MatrixTest.GetTestMatrix();
            matrix.MultiplyRow(3, 2);

            for (var i = 0; i < matrix.Rows; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {
                    if (i == 3)
                    {
                        Assert.AreEqual(matrix[i, j], 2 * (i + j));
                    }
                    else
                    {
                        Assert.AreEqual(matrix[i, j], i + j);
                    }
                }
            }
        }

        [Test]
        public void RowArbitraryInterface()
        {
            IMathematicalMatrix matrix = MatrixTest.GetTestMatrix();
            matrix.MultiplyRow(3, 2);

            for (var i = 0; i < matrix.Rows; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {
                    if (i == 3)
                    {
                        Assert.AreEqual(matrix[i, j], 2 * (i + j));
                    }
                    else
                    {
                        Assert.AreEqual(matrix[i, j], i + j);
                    }
                }
            }
        }

    }
}