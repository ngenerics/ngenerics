/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ObjectMatrixTests
{
    [TestFixture]
    public class InterchangeColumns:ObjectMatrixTest
    {
        [Test]
        public void SameColumn()
        {
            var matrix = GetTestMatrix();

            var columnCount = matrix.Columns;
            var rowCount = matrix.Rows;

            matrix.InterchangeColumns(1, 1);

            Assert.AreEqual(matrix.Columns, columnCount);
            Assert.AreEqual(matrix.Rows, rowCount);

            TestIfEqual(GetTestMatrix(), matrix);
        }

        [Test]
        public void Simple()
        {
            var matrix = GetTestMatrix();

            var columnCount = matrix.Columns;
            var rowCount = matrix.Rows;

            matrix.InterchangeColumns(0, 1);

            Assert.AreEqual(matrix.Columns, columnCount);
            Assert.AreEqual(matrix.Rows, rowCount);

            for (var i = 0; i < matrix.Rows; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {
                    if (j == 0)
                    {
                        Assert.AreEqual(matrix[i, j], (i) + (j + 1));
                    }
                    else if (j == 1)
                    {
                        Assert.AreEqual(matrix[i, j], (i) + (j - 1));
                    }
                    else
                    {
                        Assert.AreEqual(matrix[i, j], i + j);
                    }
                }
            }
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionNegativeFirstColumn()
        {
            var matrix = GetTestMatrix();
            matrix.InterchangeColumns(-1, 1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionFirstColumnTooLarge()
        {
            var matrix = GetTestMatrix();
            matrix.InterchangeColumns(matrix.Columns, 1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionNegativeSecondColumn()
        {
            var matrix = GetTestMatrix();
            matrix.InterchangeColumns(0, -1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionSecondColumnTooLarge()
        {
            var matrix = GetTestMatrix();
            matrix.InterchangeColumns(0, matrix.Columns);
        }
    }
}