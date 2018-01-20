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
    public class IsDiagonal
    {

        [Test]
        public void DifferentNumberOfRowsAndColumns()
        {
            var matrix = new Matrix(5, 2);
            Assert.IsFalse(matrix.IsDiagonal);
        }

        [Test]
        public void True()
        {
            var matrix = new Matrix(2, 2);

            matrix[0, 0] = 1;
            matrix[0, 1] = 0;
            matrix[1, 0] = 0;
            matrix[1, 1] = 1;
            Assert.IsTrue(matrix.IsDiagonal);
        }

        [Test]
        public void False()
        {
            var matrix = new Matrix(2, 2);
            matrix[0, 0] = 1;
            matrix[0, 1] = 0;
            matrix[1, 0] = 1;
            matrix[1, 1] = 1;
            Assert.IsFalse(matrix.IsDiagonal);
        }
    }
}