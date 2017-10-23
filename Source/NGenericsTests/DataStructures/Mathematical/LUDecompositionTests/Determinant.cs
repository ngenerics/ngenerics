/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.LUDecompositionTests
{
    [TestFixture]
    public class Determinant
    {

        [Test]
        public void Simple()
        {
            var matrix = new Matrix(3, 3);

            // [ 3,  1,  8 ]
            // [ 2, -5,  4 ]
            // [-1,  6, -2 ]
            // Determinant = 14

            matrix[0, 0] = 3;
            matrix[0, 1] = 1;
            matrix[0, 2] = 8;

            matrix[1, 0] = 2;
            matrix[1, 1] = -5;
            matrix[1, 2] = 4;

            matrix[2, 0] = -1;
            matrix[2, 1] = 6;
            matrix[2, 2] = -2;

            var decomposition = new LUDecomposition(matrix);

            Assert.AreEqual(14.0d, decomposition.Determinant(), 0.00000001d);
        }

    }
}