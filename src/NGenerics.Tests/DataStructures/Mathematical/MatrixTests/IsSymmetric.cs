/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.MatrixTests
{
    [TestFixture]
    public class IsSymmetric
    {

        [Test]
        public void Simple()
        {
            // Columns != Rows
            var matrix1 = new Matrix(2, 3);
            matrix1[0, 0] = -2;
            matrix1[0, 1] = 3;
            matrix1[0, 2] = 2;
            matrix1[1, 0] = 4;
            matrix1[1, 1] = 6;
            matrix1[1, 2] = -2;

            Assert.IsFalse(matrix1.IsSymmetric);

            // Not symmetric because of values
            var matrix2 = new Matrix(2, 2);
            matrix2[0, 0] = -2;
            matrix2[0, 1] = 3;
            matrix2[1, 0] = 4;
            matrix2[1, 1] = 6;

            Assert.IsFalse(matrix2.IsSymmetric);

            // Symmetric
            var matrix3 = new Matrix(2, 2);
            matrix3[0, 0] = 1;
            matrix3[0, 1] = 1;
            matrix3[1, 0] = 1;
            matrix3[1, 1] = 1;

            Assert.IsTrue(matrix3.IsSymmetric);

            // Symmetric
            var matrix4 = new Matrix(3, 3);
            matrix4[0, 0] = 1;
            matrix4[0, 1] = 2;
            matrix4[0, 2] = 3;
            matrix4[1, 0] = 2;
            matrix4[1, 1] = -4;
            matrix4[1, 2] = 5;
            matrix4[2, 0] = 3;
            matrix4[2, 1] = 5;
            matrix4[2, 2] = 6;

            Assert.IsTrue(matrix4.IsSymmetric);
        }

    }
}