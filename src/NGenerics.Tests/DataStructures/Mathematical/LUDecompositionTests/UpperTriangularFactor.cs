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
    public class UpperTriangularFactor
    {

        [Test]
        public void Simple()
        {
            var matrix = new Matrix(3, 3);

            /*
            A = [ 1    2    3
                 4    5    6
                 7    8    0 ];
             
            L =
               1.0000         0         0
               0.1429    1.0000         0
               0.5714    0.5000    1.0000  
             
            U =
               7.0000    8.0000         0
                   0    0.8571    3.0000
                   0         0    4.5000 
            */

            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[0, 2] = 3;
            matrix[1, 0] = 4;
            matrix[1, 1] = 5;
            matrix[1, 2] = 6;
            matrix[2, 0] = 7;
            matrix[2, 1] = 8;
            matrix[2, 2] = 0;

            var decomposition = new LUDecomposition(matrix);

            var upperTriangularFactorMatrix = decomposition.RightFactorMatrix;

            Assert.AreEqual(upperTriangularFactorMatrix[0, 0], 7.0000, 0.0001);
            Assert.AreEqual(upperTriangularFactorMatrix[0, 1], 8.0000, 0.0001);
            Assert.AreEqual(upperTriangularFactorMatrix[0, 2], 0.0000, 0.0001);

            Assert.AreEqual(upperTriangularFactorMatrix[1, 0], 0.0000, 0.0001);
            Assert.AreEqual(upperTriangularFactorMatrix[1, 1], 0.8571, 0.0001);
            Assert.AreEqual(upperTriangularFactorMatrix[1, 2], 3.0000, 0.0001);

            Assert.AreEqual(upperTriangularFactorMatrix[2, 0], 0.0000, 0.0001);
            Assert.AreEqual(upperTriangularFactorMatrix[2, 1], 0.0000, 0.0001);
            Assert.AreEqual(upperTriangularFactorMatrix[2, 2], 4.5000, 0.0001);
        }

    }
}