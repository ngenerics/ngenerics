/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ObjectMatrixTests
{
    [TestFixture]
    public class GetColumn:ObjectMatrixTest
    {
        [Test]
        public void Simple()
        {
            var matrix = GetTestMatrix();

            var columnCount = matrix.Columns;
            var rowCount = matrix.Rows;

            var column = matrix.GetColumn(0);

            Assert.AreEqual(matrix.Columns, columnCount);
            Assert.AreEqual(matrix.Rows, rowCount);

            Assert.AreEqual(column.Length, matrix.Rows);

            for (var i = 0; i < column.Length; i++)
            {
                Assert.AreEqual(column[i], i);
            }

            column = matrix.GetColumn(1);

            Assert.AreEqual(column.Length, matrix.Rows);

            for (var i = 0; i < column.Length; i++)
            {
                Assert.AreEqual(column[i], i + 1);
            }
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionNegativeColumnIndex()
        {
            var matrix = GetTestMatrix();
            matrix.GetColumn(-1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionColumnTooLarge()
        {
            var matrix = GetTestMatrix();
            matrix.GetColumn(matrix.Columns);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionColumnTooLarge2()
        {
            var matrix = GetTestMatrix();
            matrix.GetColumn(matrix.Columns + 1);
        }
    }
}