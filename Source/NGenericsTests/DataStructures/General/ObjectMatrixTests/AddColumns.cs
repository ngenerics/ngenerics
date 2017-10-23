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
    public class AddColumns:ObjectMatrixTest
    {
        [Test]
        public void Multiple()
        {
            var matrix = GetTestMatrix();

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
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ESimpletionNegativeColumnCount()
        {
            var matrix = GetTestMatrix();
            matrix.AddColumns(-1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionZeroColumnCount()
        {
            var matrix = GetTestMatrix();
            matrix.AddColumns(0);
        }
    }
}