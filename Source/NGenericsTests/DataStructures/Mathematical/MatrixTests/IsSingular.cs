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
    public class IsSingular
    {

        [Test]
        public void True()
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

            Assert.AreEqual(matrix.IsSingular, true);
        }

        [Test]
        public void False()
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

            Assert.AreEqual(matrix.IsSingular, false);
        }

        [Test]
        public void InterfaceIsSingular()
        {
            IMathematicalMatrix matrix = new Matrix(3, 3);

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

            Assert.AreEqual(matrix.IsSingular, true);
        }
			
    }
}