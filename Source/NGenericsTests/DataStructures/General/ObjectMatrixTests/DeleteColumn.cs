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
    public class DeleteColumn:ObjectMatrixTest
    {
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionOnlyColumn()
        {
            new ObjectMatrix<int>(4, 1).DeleteColumn(0);
        }


        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionNegativeColumn()
        {
            var matrix = GetTestMatrix();
            matrix.DeleteColumn(-1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionColumnInvalid()
        {
            var matrix = GetTestMatrix();
            matrix.DeleteColumn(matrix.Columns);
        }

        [Test]
        public void First()
        {
            var matrix = GetTestMatrix();

            var columnCount = matrix.Columns;
            var rowCount = matrix.Rows;

            matrix.DeleteColumn(0);

            Assert.AreEqual(matrix.Columns, columnCount - 1);
            Assert.AreEqual(matrix.Rows, rowCount);

            for (var i = 0; i < matrix.Rows; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {
                    Assert.AreEqual(matrix[i, j], i + j + 1);
                }
            }
        }

        [Test]
        public void Arbitrary()
        {
            var matrix = GetTestMatrix();

            var columnCount = matrix.Columns;
            var rowCount = matrix.Rows;

            matrix.DeleteColumn(2);

            Assert.AreEqual(matrix.Columns, columnCount - 1);
            Assert.AreEqual(matrix.Rows, rowCount);

            for (var i = 0; i < rowCount; i++)
            {
                for (var j = 0; j < 2; j++)
                {
                    Assert.AreEqual(matrix[i, j], i + j);
                }
            }

            for (var i = 0; i < matrix.Rows; i++)
            {
                for (var j = 3; j < matrix.Columns; j++)
                {
                    Assert.AreEqual(matrix[i, j], i + j + 1);
                }
            }
        }

        [Test]
        public void Last()
        {
            var matrix = GetTestMatrix();

            var columnCount = matrix.Columns;
            var rowCount = matrix.Rows;

            matrix.DeleteColumn(matrix.Columns - 1);

            Assert.AreEqual(matrix.Columns, columnCount - 1);
            Assert.AreEqual(matrix.Rows, rowCount);

            for (var i = 0; i < rowCount; i++)
            {
                for (var j = 0; j < columnCount - 1; j++)
                {
                    Assert.AreEqual(matrix[i, j], i + j);
                }
            }
        }
    }
}