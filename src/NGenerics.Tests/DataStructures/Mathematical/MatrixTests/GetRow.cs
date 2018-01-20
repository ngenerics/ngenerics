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
    public class GetRow
    {

        [Test]
        public void Simple()
        {
            var matrix = MatrixTest.GetTestMatrix();

            var columnCount = matrix.Columns;
            var rowCount = matrix.Rows;

            var row = matrix.GetRow(0);

            Assert.AreEqual(matrix.Columns, columnCount);
            Assert.AreEqual(matrix.Rows, rowCount);

            Assert.AreEqual(row.Length, matrix.Columns);

            for (var i = 0; i < row.Length; i++)
            {
                Assert.AreEqual(row[i], i);
            }

            row = matrix.GetRow(1);

            Assert.AreEqual(row.Length, matrix.Columns);

            for (var i = 0; i < row.Length; i++)
            {
                Assert.AreEqual(row[i], i + 1);
            }
        }

        [Test]
        public void ExceptionInvalidGetRow1()
        {
            var matrix = MatrixTest.GetTestMatrix();
            Assert.Throws<ArgumentOutOfRangeException>(() => matrix.GetRow(-1));
        }

        [Test]
        public void ExceptionInvalidGetRow2()
        {
            var matrix = MatrixTest.GetTestMatrix();
            Assert.Throws<ArgumentOutOfRangeException>(() => matrix.GetRow(matrix.Rows));
        }

        [Test]
        public void ExceptionInvalidGetRow3()
        {
            var matrix = MatrixTest.GetTestMatrix();
            Assert.Throws<ArgumentOutOfRangeException>(() => matrix.GetRow(matrix.Rows + 1));
        }
    }
}