/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.MatrixTests
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

            Assert.AreEqual(14, matrix.Determinant(), 0.000000001);
        }

        [Test]
        public void Simple2()
        {
            var matrix = new Matrix(4, 4);

            // [ 1,  2,  3,  4 ]
            // [ 5,  6,  7,  8 ]
            // [ 2,  6,  4,  8 ]
            // [ 3,  1,  1,  2 ]
            // Determinant = 72

            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[0, 2] = 3;
            matrix[0, 3] = 4;

            matrix[1, 0] = 5;
            matrix[1, 1] = 6;
            matrix[1, 2] = 7;
            matrix[1, 3] = 8;

            matrix[2, 0] = 2;
            matrix[2, 1] = 6;
            matrix[2, 2] = 4;
            matrix[2, 3] = 8;

            matrix[3, 0] = 3;
            matrix[3, 1] = 1;
            matrix[3, 2] = 1;
            matrix[3, 3] = 2;

            Assert.AreEqual(matrix.Determinant(), 72, 0.000000001);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionNotSquare()
        {
            var matrix = new Matrix(2, 3);
            matrix.Determinant();
        }

    }
}