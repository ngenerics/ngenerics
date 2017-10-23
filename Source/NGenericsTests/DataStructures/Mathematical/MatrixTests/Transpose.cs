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
    public class Transpose
    {

        [Test]
        public void Simple()
        {
            var matrix1 = new Matrix(2, 3);
            matrix1[0, 0] = 1;
            matrix1[0, 1] = 4;
            matrix1[0, 2] = 5;
            matrix1[1, 0] = -3;
            matrix1[1, 1] = 2;
            matrix1[1, 2] = 7;

            //            T			[ 1, -3]
            // [ 1, 4,  5]    =		[ 4,  2]
            // [-3, 2,  7]			[ 5,  7]

            var expectedMatrix = new Matrix(3, 2);
            expectedMatrix[0, 0] = 1;
            expectedMatrix[0, 1] = -3;
            expectedMatrix[1, 0] = 4;
            expectedMatrix[1, 1] = 2;
            expectedMatrix[2, 0] = 5;
            expectedMatrix[2, 1] = 7;

            var result = matrix1.Transpose();

            Assert.IsTrue(result.Equals(expectedMatrix));
        }

        [Test]
        public void InterfaceTranspose()
        {
            var matrix1 = new Matrix(2, 3);
            matrix1[0, 0] = 1;
            matrix1[0, 1] = 4;
            matrix1[0, 2] = 5;
            matrix1[1, 0] = -3;
            matrix1[1, 1] = 2;
            matrix1[1, 2] = 7;

            //            T			[ 1, -3]
            // [ 1, 4,  5]    =		[ 4,  2]
            // [-3, 2,  7]			[ 5,  7]

            var expectedMatrix = new Matrix(3, 2);
            expectedMatrix[0, 0] = 1;
            expectedMatrix[0, 1] = -3;
            expectedMatrix[1, 0] = 4;
            expectedMatrix[1, 1] = 2;
            expectedMatrix[2, 0] = 5;
            expectedMatrix[2, 1] = 7;

            var result = (Matrix)((IMathematicalMatrix)matrix1).Transpose();

            Assert.IsTrue(result.Equals(expectedMatrix));
        }

    }
}