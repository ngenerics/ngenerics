/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ObjectMatrixTests
{
    [TestFixture]
    public class DeleteRow:ObjectMatrixTest
    {
        [Test]
        public void ExceptionNegativeRow()
        {
            var matrix = GetTestMatrix();
            Assert.Throws<ArgumentOutOfRangeException>(() => matrix.DeleteRow(-1));
        }

        [Test]
        public void ExceptionRowInvalid()
        {
            var matrix = GetTestMatrix();
            Assert.Throws<ArgumentOutOfRangeException>(() => matrix.DeleteRow(matrix.Rows));
        }


        [Test]
        public void First()
        {
            var matrix = GetTestMatrix();

            var rows = matrix.Rows;
            var columns = matrix.Columns;

            matrix.DeleteRow(0);

            Assert.AreEqual(matrix.Rows, rows - 1);
            Assert.AreEqual(matrix.Columns, columns);

            for (var i = 1; i <= matrix.Rows; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {
                    Assert.AreEqual(matrix[i - 1, j], i + j);
                }
            }
        }

        [Test]
        public void Arbitrary()
        {
            var matrix = GetTestMatrix();

            var rows = matrix.Rows;
            var columns = matrix.Columns;

            matrix.DeleteRow(2);

            Assert.AreEqual(matrix.Rows, rows - 1);
            Assert.AreEqual(matrix.Columns, columns);

            for (var i = 0; i < 2; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {
                    Assert.AreEqual(matrix[i, j], i + j);
                }
            }

            for (var i = 2; i < matrix.Rows; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {
                    Assert.AreEqual(matrix[i, j], i + 1 + j);
                }
            }
        }

        [Test]
        public void Last()
        {
            var matrix = GetTestMatrix();

            var rows = matrix.Rows;
            var columns = matrix.Columns;

            matrix.DeleteRow(rows - 1);

            Assert.AreEqual(matrix.Rows, rows - 1);
            Assert.AreEqual(matrix.Columns, columns);

            for (var i = 0; i < matrix.Rows - 1; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {
                    Assert.AreEqual(matrix[i, j], i + j);
                }
            }
        }

        [Test]
        public void ExceptionOnlyRow()
        {
            Assert.Throws<InvalidOperationException>(() => new ObjectMatrix<int>(1, 4).DeleteRow(0));
        }
    }
}