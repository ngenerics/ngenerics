/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
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
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionInvalidRow1()
        {
            var matrix = MatrixTest.GetTestMatrix();
            matrix.InterchangeRows(-1, 1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionInvalidRow2()
        {
            var matrix = MatrixTest.GetTestMatrix();
            matrix.InterchangeRows(matrix.Rows, 1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionInvalidRow3()
        {
            var matrix = MatrixTest.GetTestMatrix();
            matrix.InterchangeRows(0, -1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionInvalidRow4()
        {
            var matrix = MatrixTest.GetTestMatrix();
            matrix.InterchangeRows(0, matrix.Rows);
        }

    }
}