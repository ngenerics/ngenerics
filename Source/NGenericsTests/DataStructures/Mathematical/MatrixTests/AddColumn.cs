/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.MatrixTests
{
    [TestFixture]
    public class AddColumn
    {

        [Test]
        public void Simple()
        {
            var matrix = MatrixTest.GetTestMatrix();

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
        public void Simple2()
        {
            var matrix = MatrixTest.GetTestMatrix();

            var columnCount = matrix.Columns;
            var rowCount = matrix.Rows;

            matrix.AddColumn(0, -1, -2, -3);

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
        public void Simple3()
        {
            var matrix = MatrixTest.GetTestMatrix();

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
        public void MultipleColumns()
        {
            var matrix = MatrixTest.GetTestMatrix();

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
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullColumn()
        {
            var matrix = MatrixTest.GetTestMatrix();
            matrix.AddColumn(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionTooManyValues()
        {
            var matrix = MatrixTest.GetTestMatrix();
            matrix.AddColumn(1, 2, 3, 4, 5);
        }
        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionNegativeColumns()
        {
            var matrix = MatrixTest. GetTestMatrix();
            matrix.AddColumns(-1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionZeroColumns()
        {
            var matrix = MatrixTest.GetTestMatrix();
            matrix.AddColumns(0);
        }

    }
}