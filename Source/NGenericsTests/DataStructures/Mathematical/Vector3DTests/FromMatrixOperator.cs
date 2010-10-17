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

namespace NGenerics.Tests.DataStructures.Mathematical.Vector3DTests
{
    [TestFixture]
    public class FromMatrixOperator
    {
        [Test]
        public void Simple3D()
        {

            var matrix = new Matrix(3, 1);
            matrix[0, 0] = 7;
            matrix[1, 0] = 4;
            matrix[2, 0] = 8;

            var actual = (Vector3D)matrix;

            Assert.AreEqual(7, actual.X);
            Assert.AreEqual(4, actual.Y);
            Assert.AreEqual(8, actual.Z);
        }

        [Test]
        public void Simple2D()
        {

            var matrix = new Matrix(2, 1);
            matrix[0, 0] = 7;
            matrix[1, 0] = 4;

            var actual = (Vector3D)matrix;

            Assert.AreEqual(7, actual.X);
            Assert.AreEqual(4, actual.Y);
            Assert.AreEqual(0, actual.Z);
        }

        [Test]
        public void Simple1D()
        {

            var matrix = new Matrix(1, 1);
            matrix[0, 0] = 7;

            var actual = (Vector3D)matrix;

            Assert.AreEqual(7, actual.X);
            Assert.AreEqual(0, actual.Y);
            Assert.AreEqual(0, actual.Z);
        }


        [Test]
        [ExpectedException(typeof(InvalidCastException))]
        public void ExceptionInvalidColumns()
        {

            var matrix = new Matrix(2, 2);
            var actual = (Vector3D)matrix;

        }


        [Test]
        [ExpectedException(typeof(InvalidCastException))]
        public void ExceptionInvalidRows()
        {

            var matrix = new Matrix(4, 1);
            var actual = (Vector3D)matrix;
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullMatrix()
        {
            const Matrix matrix = null;
            var actual = (Vector3D)matrix;
        }
    }
}