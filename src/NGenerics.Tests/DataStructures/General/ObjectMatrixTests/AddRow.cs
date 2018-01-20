/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ObjectMatrixTests
{
    [TestFixture]
    public class AddRow:ObjectMatrixTest
    {
        [Test]
        public void Simple()
        {
            var matrix = GetTestMatrix();

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
        public void Values1()
        {
            var matrix = GetTestMatrix();

            var columnCount = matrix.Columns;
            var rowCount = matrix.Rows;

            matrix.AddRow(0, -1, -2, -3, -4, -5, -6, -7, -8, -9, -10, -11, -12, -13, -14);

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
        public void Values2()
        {
            var matrix = GetTestMatrix();

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
        public void ExceptionNullValues()
        {
            var matrix = GetTestMatrix();
            Assert.Throws<ArgumentNullException>(() => matrix.AddRow(null));
        }

        [Test]
        public void ExceptionIncorrectNumberOfRows()
        {
            var matrix = GetTestMatrix();
            Assert.Throws<ArgumentException>(() =>
                matrix.AddRow(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16));
        }
    }
}