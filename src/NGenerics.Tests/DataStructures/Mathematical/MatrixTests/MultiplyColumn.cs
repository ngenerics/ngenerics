/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.MatrixTests
{
    [TestFixture]
    public class MultiplyColumn
    {

        [Test]
        public void ColumnFirst()
        {
            var matrix = MatrixTest.GetTestMatrix();
            matrix.MultiplyColumn(0, 2);

            for (var i = 0; i < matrix.Rows; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {
                    if (j == 0)
                    {
                        Assert.AreEqual(matrix[i, j], 2 * (i + j));
                    }
                    else
                    {
                        Assert.AreEqual(matrix[i, j], i + j);
                    }
                }
            }
        }

        [Test]
        public void ColumnLast()
        {
            var matrix = MatrixTest.GetTestMatrix();
            matrix.MultiplyColumn(matrix.Columns - 1, 2);

            for (var i = 0; i < matrix.Rows; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {
                    if (j == matrix.Columns - 1)
                    {
                        Assert.AreEqual(matrix[i, j], 2 * (i + j));
                    }
                    else
                    {
                        Assert.AreEqual(matrix[i, j], i + j);
                    }
                }
            }
        }

        [Test]
        public void ColumnArbitrary()
        {
            var matrix = MatrixTest.GetTestMatrix();
            matrix.MultiplyColumn(3, 2);

            for (var i = 0; i < matrix.Rows; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {
                    if (j == 3)
                    {
                        Assert.AreEqual(matrix[i, j], 2 * (i + j));
                    }
                    else
                    {
                        Assert.AreEqual(matrix[i, j], i + j);
                    }
                }
            }
        }

        [Test]
        public void ColumnArbitraryInterface()
        {
            IMathematicalMatrix matrix = MatrixTest.GetTestMatrix();
            matrix.MultiplyColumn(3, 3);

            for (var i = 0; i < matrix.Rows; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {
                    if (j == 3)
                    {
                        Assert.AreEqual(matrix[i, j], 3 * (i + j));
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
        public void ExceptionIndexNegative()
        {
            var matrix = MatrixTest.GetTestMatrix();
            matrix.MultiplyColumn(-1, 2);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionInvalidIndex()
        {
            var matrix = MatrixTest.GetTestMatrix();
            matrix.MultiplyColumn(matrix.Columns, 2);
        }

    }
}