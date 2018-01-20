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
    public class NonSingular
    {

        [Test]
        public void Simple()
        {
            var matrix = new Matrix(3, 3);

            // [ 4,  4,  4 ]
            // [ 4,  4,  4 ]
            // [ 4,  4,  4 ]
            // Determinant = 0

            matrix[0, 0] = 4;
            matrix[0, 1] = 4;
            matrix[0, 2] = 4;

            matrix[1, 0] = 4;
            matrix[1, 1] = 4;
            matrix[1, 2] = 4;

            var decomposition = new LUDecomposition(matrix);
            Assert.IsFalse(decomposition.NonSingular);
        }

    }
}