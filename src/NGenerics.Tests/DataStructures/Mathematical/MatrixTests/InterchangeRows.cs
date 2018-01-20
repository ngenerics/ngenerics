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
    public class InterchangeRows
    {

        [Test]
        public void Simple()
        {
            var matrix = MatrixTest.GetTestMatrix();

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
        public void ExceptionInvalidRow1()
        {
            var matrix = MatrixTest.GetTestMatrix();
            Assert.Throws<ArgumentOutOfRangeException>(() => matrix.InterchangeRows(-1, 1));
        }

        [Test]
        public void ExceptionInvalidRow2()
        {
            var matrix = MatrixTest.GetTestMatrix();
            Assert.Throws<ArgumentOutOfRangeException>(() => matrix.InterchangeRows(matrix.Rows, 1));
        }

        [Test]
        public void ExceptionInvalidRow3()
        {
            var matrix = MatrixTest.GetTestMatrix();
            Assert.Throws<ArgumentOutOfRangeException>(() => matrix.InterchangeRows(0, -1));
        }

        [Test]
        public void ExceptionInvalidRow4()
        {
            var matrix = MatrixTest.GetTestMatrix();
            Assert.Throws<ArgumentOutOfRangeException>(() => matrix.InterchangeRows(0, matrix.Rows));
        }
    }
}