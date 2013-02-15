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

namespace NGenerics.Tests.DataStructures.Mathematical.Vector3DTests
{
    [TestFixture]
    public class DivideOperator
    {
        [Test]
        public void Double()
        {
            var vector3D1 = new Vector3D(4, 12, 8);

            var vector = vector3D1 / 2;

            Assert.AreEqual(2, vector.X);
            Assert.AreEqual(6, vector.Y);
            Assert.AreEqual(4, vector.Z);

            Assert.AreNotSame(vector3D1, vector);

            Assert.AreEqual(4, vector3D1.X);
            Assert.AreEqual(12, vector3D1.Y);
            Assert.AreEqual(8, vector3D1.Z);
        }


        [Test]
        public void Vector()
        {
            var vector1 = new Vector3D(24, 48, 72);

            var vector2 = new Vector3D(2, 3, 4);

            var vector = vector1 / vector2;

            Assert.AreEqual(1, vector.X);
            Assert.AreEqual(2, vector.Y);
            Assert.AreEqual(3, vector.Z);

            Assert.AreNotSame(vector1, vector);
            Assert.AreNotSame(vector2, vector);

            Assert.AreEqual(24, vector1.X);
            Assert.AreEqual(48, vector1.Y);
            Assert.AreEqual(72, vector1.Z);

            Assert.AreEqual(2, vector2.X);
            Assert.AreEqual(3, vector2.Y);
            Assert.AreEqual(4, vector2.Z);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionDifferentDimensions()
        {
            var vector3D1 = new Vector3D();
            VectorBase<double> vectorBase = new VectorN(4);
            IVector<double> vector = vector3D1 / vectorBase;
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullLeft()
        {
            var vector3D1 = new Vector3D();
            var vector = null / vector3D1;
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullRight()
        {
            var vector3D1 = new Vector3D();
            var vector = vector3D1 / null;
        }
    }
}