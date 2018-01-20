/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.MatrixTests
{
    [TestFixture]
    public class AddRow
    {

        [Test]
        public void Simple1()
        {
            var matrix = MatrixTest.GetTestMatrix();

            var columnCount = matrix.Columns;
            var rowCount = matrix.Rows;

            matrix.AddRow();

            Assert.AreEqual(matrix.Columns, columnCount);
            Assert.AreEqual(matrix.Rows, rowCount + 1);

            for (var i = 0; i < rowCount; i++)
            {
                for (var j = 0; j < columnCount; j++)
                {
                    Assert.AreEqual(matrix[i, j], i + j);
                }
            }

            for (var i = 0; i < columnCount; i++)
            {
                Assert.AreEqual(matrix[rowCount, i], default(double));
            }
        }

        [Test]
        public void Simple2()
        {
            var matrix = MatrixTest.GetTestMatrix();

            var columnCount = matrix.Columns;
            var rowCount = matrix.Rows;

            matrix.AddRow(0, -1, -2, -3, -4);

            Assert.AreEqual(matrix.Columns, columnCount);
            Assert.AreEqual(matrix.Rows, rowCount + 1);

            for (var i = 0; i < rowCount; i++)
            {
                for (var j = 0; j < columnCount; j++)
                {
                    Assert.AreEqual(matrix[i, j], i + j);
                }
            }

            for (var i = 0; i < columnCount; i++)
            {
                Assert.AreEqual(matrix[rowCount, i], -1 * i);
            }
        }

        [Test]
        public void Simple3()
        {
            var matrix = MatrixTest.GetTestMatrix();

            var columnCount = matrix.Columns;
            var rowCount = matrix.Rows;

            matrix.AddRow(0, -1, -2);

            Assert.AreEqual(matrix.Columns, columnCount);
            Assert.AreEqual(matrix.Rows, rowCount + 1);

            for (var i = 0; i < rowCount; i++)
            {
                for (var j = 0; j < columnCount; j++)
                {
                    Assert.AreEqual(matrix[i, j], i + j);
                }
            }

            Assert.AreEqual(matrix[rowCount, 0], 0);
            Assert.AreEqual(matrix[rowCount, 1], -1);
            Assert.AreEqual(matrix[rowCount, 2], -2);
            Assert.AreEqual(matrix[rowCount, 3], 0);
            Assert.AreEqual(matrix[rowCount, 4], 0);
        }

        [Test]
        public void ExceptionNull1()
        {
            var matrix = MatrixTest.GetTestMatrix();
            Assert.Throws<ArgumentNullException>(() => matrix.AddRow(null));
        }

        [Test]
        public void Exception1()
        {
            var matrix = MatrixTest.GetTestMatrix();
            Assert.Throws<ArgumentException>(() => matrix.AddRow(1, 2, 3, 4, 5, 6));
        }

        [Test]
        public void MultipleRows()
        {
            var matrix = MatrixTest.GetTestMatrix();
            
            var columnCount = matrix.Columns;
            var rowCount = matrix.Rows;

            matrix.AddRows(3);

            Assert.AreEqual(matrix.Columns, columnCount);
            Assert.AreEqual(matrix.Rows, rowCount + 3);

            for (var i = 0; i < rowCount; i++)
            {
                for (var j = 0; j < columnCount; j++)
                {
                    Assert.AreEqual(matrix[i, j], i + j);
                }
            }

            for (var i = 0; i < columnCount; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    Assert.AreEqual(matrix[rowCount + j, i], default(double));
                }
            }
        }

        [Test]
        public void ExceptionNegativeRows()
        {
            var matrix = MatrixTest.GetTestMatrix();
            Assert.Throws<ArgumentOutOfRangeException>(() => matrix.AddRows(-1));
        }

        [Test]
        public void ExceptionZeroRows()
        {
            var matrix = MatrixTest.GetTestMatrix();
            Assert.Throws<ArgumentOutOfRangeException>(() => matrix.AddRows(0));
        }
    }
}