/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.MatrixTests
{
    [TestFixture]
    public class Concatenate
    {

        [Test]
        public void Simple()
        {
            var matrix1 = MatrixTest.GetTestMatrix();
            var matrix2 = GetTestMinusMatrix();

            var concat = matrix1.Concatenate(matrix2);

            Assert.AreEqual(concat.Rows, matrix1.Rows);
            Assert.AreEqual(concat.Columns, matrix1.Columns + matrix2.Columns);

            for (var i = 0; i < matrix1.Rows; i++)
            {
                for (var j = 0; j < matrix1.Columns; j++)
                {
                    Assert.AreEqual(concat[i, j], matrix1[i, j]);
                }
            }

            for (var i = 0; i < matrix2.Rows; i++)
            {
                for (var j = 0; j < matrix2.Columns; j++)
                {
                    Assert.AreEqual(concat[i, j + matrix1.Columns], matrix2[i, j]);
                }
            }
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullMatrix()
        {
            var matrix1 = MatrixTest.GetTestMatrix();
            matrix1.Concatenate(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionDifferentRowSizesLarger()
        {
            var matrix1 = MatrixTest.GetTestMatrix();
            var matrix2 = GetTestMinusMatrix();

            // Add a row to make the row sizes different
            matrix2.AddRow();

            matrix1.Concatenate(matrix2);
        }
        private static Matrix GetTestMinusMatrix()
        {
            var matrix = new Matrix(4, 5);

            for (var i = 0; i < matrix.Rows; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {
                    matrix[i, j] = i - j;
                }
            }

            return matrix;
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionDifferentRowSizesSmaller()
        {
            var matrix1 = MatrixTest.GetTestMatrix();
            var matrix2 = GetTestMinusMatrix();

            // Add a row to make the row sizes different
            matrix2.DeleteRow(0);

            matrix1.Concatenate(matrix2);
        }

        [Test]
        public void ConcatenateInterface()
        {
            IMathematicalMatrix matrix1 = MatrixTest.GetTestMatrix();
            IMathematicalMatrix matrix2 = GetTestMinusMatrix();

            var concat = matrix1.Concatenate(matrix2);

            Assert.AreEqual(concat.Rows, matrix1.Rows);
            Assert.AreEqual(concat.Columns, matrix1.Columns + matrix2.Columns);

            for (var i = 0; i < matrix1.Rows; i++)
            {
                for (var j = 0; j < matrix1.Columns; j++)
                {
                    Assert.AreEqual(concat[i, j], matrix1[i, j]);
                }
            }

            for (var i = 0; i < matrix2.Rows; i++)
            {
                for (var j = 0; j < matrix2.Columns; j++)
                {
                    Assert.AreEqual(concat[i, j + matrix1.Columns], matrix2[i, j]);
                }
            }
        }

    }
}