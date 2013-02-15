/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

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
    public class Adjoint
    {

        [Test]
        public void TwoByTwo()
        {
            //A = [ a, b ]
            //    [ c, d ]
            //
            // AdjA = [ d, -b]
            //        [ -c, a]

            var matrix = new Matrix(2, 2);
            matrix[0, 0] = 2;
            matrix[0, 1] = 4;
            matrix[1, 0] = 1;
            matrix[1, 1] = 3;

            var a = matrix.Adjoint();

            Assert.AreEqual(a[0, 0], 3);
            Assert.AreEqual(a[0, 1], -4);
            Assert.AreEqual(a[1, 0], -1);
            Assert.AreEqual(a[1, 1], 2);
        }

        [Test]
        public void ThreeByThree()
        {
            //A = [ 3, 0,  2 ]
            //    [ 0, 1, -1 ]
            //    [ 0, 4,  5 ]
            //
            // AdjA = [ 9,   8, -2 ]
            //        [ 0,  15,  3 ]
            //        [ 0, -12,  3 ]


            var matrix = new Matrix(3, 3);
            matrix[0, 0] = 3;
            matrix[0, 1] = 0;
            matrix[0, 2] = 2;

            matrix[1, 0] = 0;
            matrix[1, 1] = 1;
            matrix[1, 2] = -1;

            matrix[2, 0] = 0;
            matrix[2, 1] = 4;
            matrix[2, 2] = 5;

            var a = matrix.Adjoint();

            Assert.AreEqual(a[0, 0], 9);
            Assert.AreEqual(a[0, 1], 8);
            Assert.AreEqual(a[0, 2], -2);

            Assert.AreEqual(a[1, 0], 0);
            Assert.AreEqual(a[1, 1], 15);
            Assert.AreEqual(a[1, 2], 3);

            Assert.AreEqual(a[2, 0], 0);
            Assert.AreEqual(a[2, 1], -12);
            Assert.AreEqual(a[2, 2], 3);
        }

        [Test]
        public void AdjointInterface()
        {
            //A = [ 3, 0,  2 ]
            //    [ 0, 1, -1 ]
            //    [ 0, 4,  5 ]
            //
            // AdjA = [ 9,   8, -2 ]
            //        [ 0,  15,  3 ]
            //        [ 0, -12,  3 ]


            IMathematicalMatrix matrix = new Matrix(3, 3);
            matrix[0, 0] = 3;
            matrix[0, 1] = 0;
            matrix[0, 2] = 2;

            matrix[1, 0] = 0;
            matrix[1, 1] = 1;
            matrix[1, 2] = -1;

            matrix[2, 0] = 0;
            matrix[2, 1] = 4;
            matrix[2, 2] = 5;

            var a = matrix.Adjoint();

            Assert.AreEqual(a[0, 0], 9);
            Assert.AreEqual(a[0, 1], 8);
            Assert.AreEqual(a[0, 2], -2);

            Assert.AreEqual(a[1, 0], 0);
            Assert.AreEqual(a[1, 1], 15);
            Assert.AreEqual(a[1, 2], 3);

            Assert.AreEqual(a[2, 0], 0);
            Assert.AreEqual(a[2, 1], -12);
            Assert.AreEqual(a[2, 2], 3);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionNonSquare()
        {
            var matrix = new Matrix(3, 2);
            matrix.Adjoint();
        }

    }
}