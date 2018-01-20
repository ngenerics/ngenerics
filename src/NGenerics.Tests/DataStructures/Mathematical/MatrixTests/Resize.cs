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
    public class Resize
    {

        [Test]
        public void Smaller()
        {
            var matrix = MatrixTest.GetTestMatrix();

            matrix.Resize(2, 2);

            Assert.AreEqual(matrix.Columns, 2);
            Assert.AreEqual(matrix.Rows, 2);

            for (var i = 0; i < 2; i++)
            {
                for (var j = 0; j < 2; j++)
                {
                    Assert.AreEqual(matrix[i, j], i + j);
                }
            }
        }

        [Test]
        public void Larger()
        {
            var matrix = MatrixTest.GetTestMatrix();

            var columnCount = matrix.Columns;
            var rowCount = matrix.Rows;

            matrix.Resize(8, 8);

            Assert.AreEqual(matrix.Columns, 8);
            Assert.AreEqual(matrix.Rows, 8);

            for (var i = 0; i < rowCount; i++)
            {
                for (var j = 0; j < columnCount; j++)
                {
                    Assert.AreEqual(matrix[i, j], i + j);
                }
            }

            for (var i = rowCount; i < 8; i++)
            {
                for (var j = columnCount; j < 8; j++)
                {
                    Assert.AreEqual(matrix[i, j], default(double));
                }
            }
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionNewRowsNegative()
        {
            var matrix = MatrixTest.GetTestMatrix();
            matrix.Resize(-1, 8);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionNewColumnsNegative()
        {
            var matrix = MatrixTest.GetTestMatrix();
            matrix.Resize(8, -1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionNewRowsZero()
        {
            var matrix = MatrixTest.GetTestMatrix();
            matrix.Resize(8, 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionNewColumnsZero()
        {
            var matrix = MatrixTest.GetTestMatrix();
            matrix.Resize(0, 8);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionInvalidSize5()
        {
            var matrix = MatrixTest.GetTestMatrix();
            matrix.Resize(-1, -1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionNewColumnsAndNewRowsTooSmall()
        {
            var matrix = MatrixTest.GetTestMatrix();
            matrix.Resize(0, 0);
        }

    }
}