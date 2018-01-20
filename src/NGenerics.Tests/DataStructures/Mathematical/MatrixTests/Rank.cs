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
    public class Rank
    {

        [Test]
        public void Simple()
        {
            var matrix = new Matrix(4, 4);

            // [ 2,  4,  1,  3 ]
            // [-1, -2,  1,  0 ]
            // [ 0,  0,  2,  2 ]
            // [ 3,  6,  2,  5 ]
            // rank 2

            matrix[0, 0] = 2;
            matrix[0, 1] = 4;
            matrix[0, 2] = 1;
            matrix[0, 3] = 3;

            matrix[1, 0] = -1;
            matrix[1, 1] = -2;
            matrix[1, 2] = 1;
            matrix[1, 3] = 0;

            matrix[2, 0] =  0;
            matrix[2, 1] = 0;
            matrix[2, 2] =  2;
            matrix[2, 3] =  2;

            matrix[3, 0] = 3;
            matrix[3, 1] =  6;
            matrix[3, 2] = 2;
            matrix[3, 3] = 5;

            Assert.AreEqual(2, matrix.Rank());
        }
    }
}