/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.MatrixTests
{
    [TestFixture]
    public class Equality
    {

        [Test]
        public void Simple()
        {
            var matrix1 = new Matrix(5, 6);
            var matrix2 = new Matrix(5, 6);

            Assert.IsTrue(matrix1.Equals(matrix2));

            for (var i = 0; i < matrix1.Rows; i++)
            {
                for (var j = 0; j < matrix1.Columns; j++)
                {
                    matrix1[i, j] = i + j;
                    matrix2[i, j] = i + j;
                }
            }

            Assert.IsTrue(matrix1.Equals(matrix2));
            Assert.IsFalse(matrix1.Equals(null));
        }

        [Test]
        public void NotEquals()
        {
            var matrix1 = new Matrix(5, 6);
            var matrix2 = new Matrix(5, 7);
            var matrix3 = new Matrix(5, 6);
            var matrix4 = new Matrix(6, 6);

            // Columns are not the same
            Assert.IsFalse(matrix1.Equals(matrix2));

            // Rows are not the same
            Assert.IsFalse(matrix1.Equals(matrix4));

            for (var i = 0; i < matrix1.Rows; i++)
            {
                for (var j = 0; j < matrix1.Columns; j++)
                {
                    matrix1[i, j] = i + j;
                    matrix3[i, j] = i + j;
                }
            }

            // One value is different
            matrix3[4, 4] = 0;

            Assert.IsFalse(matrix1.Equals(matrix3));

        }

        [Test]
        public void NotEqualsOperator()
        {
            var matrix1 = new Matrix(5, 6);
            var matrix2 = new Matrix(5, 7);
            var matrix3 = new Matrix(5, 6);
            var matrix4 = new Matrix(6, 6);

            // Columns are not the same
            Assert.IsTrue(matrix1 != (matrix2));

            // Rows are not the same
            Assert.IsTrue(matrix1 != matrix4);

            for (var i = 0; i < matrix1.Rows; i++)
            {
                for (var j = 0; j < matrix1.Columns; j++)
                {
                    matrix1[i, j] = i + j;
                    matrix3[i, j] = i + j;
                }
            }

            // One value is different
            matrix3[4, 4] = 0;

            Assert.IsTrue(matrix1 != matrix3);

            // Disable warning C1718 : Testing equality of same variable
#pragma warning disable 1718

            Assert.IsFalse(matrix1 != matrix1);
            Assert.IsFalse(matrix2 != matrix2);

#pragma warning restore 1718
        }

    }
}