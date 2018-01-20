/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector3DTests
{
    [TestFixture]
    public class Subtract
    {

        [Test]
        public void ExceptionNullVector()
        {
            var vector = new Vector3D();
            Assert.Throws<ArgumentNullException>(() => vector.Subtract(null));
        }

        [Test]
        public void ExceptionDifferentDimensions()
        {
            var vector3D = new Vector3D();
            VectorBase<double> vectorBase = new VectorN(4);
            Assert.Throws<ArgumentException>(() => vector3D.Subtract(vectorBase));
        }

        [Test]
        public void Double()
        {
            var vector = new Vector3D(1, 2, -2);

            vector.Subtract(2);

            Assert.AreEqual(-1, vector.X);
            Assert.AreEqual(0, vector.Y);
            Assert.AreEqual(-4, vector.Z);
        }

        [Test]
        public void Vector3D()
        {
            var vector1 = new Vector3D(1, 2, 9);

            var vector2 = new Vector3D(8, 4, 2);

            vector1.Subtract(vector2);

            Assert.AreEqual(-7, vector1.X);
            Assert.AreEqual(-2, vector1.Y);
            Assert.AreEqual(7, vector1.Z);

            Assert.AreEqual(8, vector2.X);
            Assert.AreEqual(4, vector2.Y);
            Assert.AreEqual(2, vector2.Z);
        }

        [Test]
        public void IVector()
        {
            var vector3D = new Vector3D(1, 2, 9);

            var vectorN = new VectorN(3);
            vectorN.SetValues(8, 4, 2);

            vector3D.Subtract(vectorN);

            Assert.AreEqual(-7, vector3D.X);
            Assert.AreEqual(-2, vector3D.Y);
            Assert.AreEqual(7, vector3D.Z);

            Assert.AreEqual(8, vectorN[0]);
            Assert.AreEqual(4, vectorN[1]);
            Assert.AreEqual(2, vectorN[2]);
        }

    }
}