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
    public class Negate
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

            var expectedMatrix = new Matrix(2, 3);
            expectedMatrix[0, 0] = -1;
            expectedMatrix[0, 1] = -4;
            expectedMatrix[0, 2] = -5;
            expectedMatrix[1, 0] = 3;
            expectedMatrix[1, 1] = -2;
            expectedMatrix[1, 2] = -7;

            var result = matrix1.Negate();

            Assert.IsTrue(result.Equals(expectedMatrix));
        }

        [Test]
        public void InterfaceNegate()
        {
            var matrix1 = new Matrix(2, 3);
            matrix1[0, 0] = 1;
            matrix1[0, 1] = 4;
            matrix1[0, 2] = 5;
            matrix1[1, 0] = -3;
            matrix1[1, 1] = 2;
            matrix1[1, 2] = 7;

            var expectedMatrix = new Matrix(2, 3);
            expectedMatrix[0, 0] = -1;
            expectedMatrix[0, 1] = -4;
            expectedMatrix[0, 2] = -5;
            expectedMatrix[1, 0] = 3;
            expectedMatrix[1, 1] = -2;
            expectedMatrix[1, 2] = -7;

            var result = (Matrix)((IMathematicalMatrix)matrix1).Negate();

            Assert.IsTrue(result.Equals(expectedMatrix));
        }

    }
}