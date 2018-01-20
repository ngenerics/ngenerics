/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.MatrixTests
{
    [TestFixture]
    public class Minor
    {

        [Test]
        public void TopLeft()
        {
            var matrix = MatrixTest.GetTestMatrix();

            var rows = matrix.Rows;
            var columns = matrix.Columns;

            var minor = matrix.Minor(0, 0);

            Assert.AreEqual(minor.Columns, columns - 1);
            Assert.AreEqual(minor.Rows, rows - 1);

            for (var i = 0; i < minor.Rows; i++)
            {
                for (var j = 0; j < minor.Columns; j++)
                {
                    Assert.AreEqual(minor[i, j], i + j + 2);
                }
            }

            Assert.IsTrue(MatrixTest.IsOriginalTestMatrix(matrix));
        }

        [Test]
        public void TopRight()
        {
            var matrix = MatrixTest.GetTestMatrix();

            var rows = matrix.Rows;
            var columns = matrix.Columns;

            var minor = matrix.Minor(0, matrix.Columns - 1);

            Assert.AreEqual(minor.Columns, columns - 1);
            Assert.AreEqual(minor.Rows, rows - 1);

            for (var i = 0; i < minor.Rows; i++)
            {
                for (var j = 0; j < minor.Columns; j++)
                {
                    Assert.AreEqual(minor[i, j], i + j + 1);
                }
            }

            Assert.IsTrue(MatrixTest.IsOriginalTestMatrix(matrix));
        }

        [Test]
        public void BottomLeft()
        {
            var matrix = MatrixTest.GetTestMatrix();

            var rows = matrix.Rows;
            var columns = matrix.Columns;

            var minor = matrix.Minor(matrix.Rows - 1, 0);

            Assert.AreEqual(minor.Columns, columns - 1);
            Assert.AreEqual(minor.Rows, rows - 1);

            for (var i = 0; i < minor.Rows; i++)
            {
                for (var j = 0; j < minor.Columns; j++)
                {
                    Assert.AreEqual(minor[i, j], i + j + 1);
                }
            }

            Assert.IsTrue(MatrixTest.IsOriginalTestMatrix(matrix));
        }

        [Test]
        public void BottomRight()
        {
            var matrix = MatrixTest.GetTestMatrix();

            var rows = matrix.Rows;
            var columns = matrix.Columns;

            var minor = matrix.Minor(matrix.Rows - 1, matrix.Columns - 1);

            Assert.AreEqual(minor.Columns, columns - 1);
            Assert.AreEqual(minor.Rows, rows - 1);

            for (var i = 0; i < minor.Rows; i++)
            {
                for (var j = 0; j < minor.Columns; j++)
                {
                    Assert.AreEqual(minor[i, j], i + j);
                }
            }

            Assert.IsTrue(MatrixTest.IsOriginalTestMatrix(matrix));
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionColumnNegative()
        {
            var matrix = MatrixTest.GetTestMatrix();
            matrix.Minor(2, -1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionColumnOutOfRange()
        {
            var matrix = MatrixTest.GetTestMatrix();
            matrix.Minor(2, matrix.Columns);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionRowNegative()
        {
            var matrix = MatrixTest.GetTestMatrix();
            matrix.Minor(-1, 2);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionRowOutOfRange()
        {
            var matrix = MatrixTest.GetTestMatrix();
            matrix.Minor(matrix.Rows, 2);
        }

        [Test]
        public void MinorArbitrary()
        {
            var matrix = MatrixTest.GetTestMatrix();

            var rows = matrix.Rows;
            var columns = matrix.Columns;

            var minor = matrix.Minor(2, 3);

            Assert.AreEqual(minor.Columns, columns - 1);
            Assert.AreEqual(minor.Rows, rows - 1);

            for (var i = 0; i < minor.Rows; i++)
            {
                for (var j = 0; j < minor.Columns; j++)
                {
                    var addAmount = 0;

                    if (i >= 2)
                    {
                        addAmount++;
                    }

                    if (j >= 3)
                    {
                        addAmount++;
                    }

                    Assert.AreEqual(minor[i, j], i + j + addAmount);
                }
            }

            Assert.IsTrue(MatrixTest.IsOriginalTestMatrix(matrix));
        }

        [Test]
        public void MinorTopLeftInterface()
        {
            IMathematicalMatrix matrix = MatrixTest.GetTestMatrix();

            var rows = matrix.Rows;
            var columns = matrix.Columns;

            var minor = matrix.Minor(0, 0);

            Assert.AreEqual(minor.Columns, columns - 1);
            Assert.AreEqual(minor.Rows, rows - 1);

            for (var i = 0; i < minor.Rows; i++)
            {
                for (var j = 0; j < minor.Columns; j++)
                {
                    Assert.AreEqual(minor[i, j], i + j + 2);
                }
            }

            Assert.IsTrue(MatrixTest.IsOriginalTestMatrix(matrix));
        }

        [Test]
        public void MinorTopRightInterface()
        {
            IMathematicalMatrix matrix = MatrixTest.GetTestMatrix();

            var rows = matrix.Rows;
            var columns = matrix.Columns;

            var minor = matrix.Minor(0, matrix.Columns - 1);

            Assert.AreEqual(minor.Columns, columns - 1);
            Assert.AreEqual(minor.Rows, rows - 1);

            for (var i = 0; i < minor.Rows; i++)
            {
                for (var j = 0; j < minor.Columns; j++)
                {
                    Assert.AreEqual(minor[i, j], i + j + 1);
                }
            }

            Assert.IsTrue(MatrixTest.IsOriginalTestMatrix(matrix));
        }

        [Test]
        public void MinorBottomLeftInterface()
        {
            IMathematicalMatrix matrix = MatrixTest.GetTestMatrix();

            var rows = matrix.Rows;
            var columns = matrix.Columns;

            var minor = matrix.Minor(matrix.Rows - 1, 0);

            Assert.AreEqual(minor.Columns, columns - 1);
            Assert.AreEqual(minor.Rows, rows - 1);

            for (var i = 0; i < minor.Rows; i++)
            {
                for (var j = 0; j < minor.Columns; j++)
                {
                    Assert.AreEqual(minor[i, j], i + j + 1);
                }
            }

            Assert.IsTrue(MatrixTest.IsOriginalTestMatrix(matrix));
        }

        [Test]
        public void MinorBottomRightInterface()
        {
            IMathematicalMatrix matrix = MatrixTest.GetTestMatrix();

            var rows = matrix.Rows;
            var columns = matrix.Columns;

            var minor = matrix.Minor(matrix.Rows - 1, matrix.Columns - 1);

            Assert.AreEqual(minor.Columns, columns - 1);
            Assert.AreEqual(minor.Rows, rows - 1);

            for (var i = 0; i < minor.Rows; i++)
            {
                for (var j = 0; j < minor.Columns; j++)
                {
                    Assert.AreEqual(minor[i, j], i + j);
                }
            }

            Assert.IsTrue(MatrixTest.IsOriginalTestMatrix(matrix));
        }

        [Test]
        public void MinorArbitraryInterface()
        {
            IMathematicalMatrix matrix = MatrixTest.GetTestMatrix();

            var rows = matrix.Rows;
            var columns = matrix.Columns;

            var minor = matrix.Minor(2, 3);

            Assert.AreEqual(minor.Columns, columns - 1);
            Assert.AreEqual(minor.Rows, rows - 1);

            for (var i = 0; i < minor.Rows; i++)
            {
                for (var j = 0; j < minor.Columns; j++)
                {
                    var addAmount = 0;

                    if (i >= 2)
                    {
                        addAmount++;
                    }

                    if (j >= 3)
                    {
                        addAmount++;
                    }

                    Assert.AreEqual(minor[i, j], i + j + addAmount);
                }
            }

            Assert.IsTrue(MatrixTest.IsOriginalTestMatrix(matrix));
        }
    }
}