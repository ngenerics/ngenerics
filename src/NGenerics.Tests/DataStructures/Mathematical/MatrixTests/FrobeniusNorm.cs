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
    public class FrobeniusNorm
    {

        [Test]
        public void Simple()
        {
            var matrix = new Matrix(1, 2);
            matrix[0, 0] = 3;
            matrix[0, 1] = 4;

            Assert.AreEqual(matrix.FrobeniusNorm, 5);
        }

    }
}