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
    public class CrossProduct
    {

        [Test]
        public void IVector3x3()
        {
            var vector3D = new Vector3D(1, 2, 3);

            var vectorN = new VectorN(3);
            vectorN.SetValues(4, 5, 6);

            var vector = vector3D.CrossProduct(vectorN);

            Assert.AreEqual(-3, vector[0]);
            Assert.AreEqual(6, vector[1]);
            Assert.AreEqual(-3, vector[2]);
        }

        [Test]
        public void IVector3x2()
        {
            var vector3D = new Vector3D(1, 2, 3);

            var vectorN = new VectorN(2);
            vectorN.SetValues(4, 5);

            var vector = vector3D.CrossProduct(vectorN);

            Assert.AreEqual(-15, vector[0]);
            Assert.AreEqual(12, vector[1]);
            Assert.AreEqual(-3, vector[2]);
        }

        [Test]
        public void Vector3D3x3()
        {
            var vector1 = new Vector3D(1, 2, 3);

            var vector2 = new Vector3D(4, 5, 6);

            var vector = vector1.CrossProduct(vector2);

            Assert.AreEqual(-3, vector.X);
            Assert.AreEqual(6, vector.Y);
            Assert.AreEqual(-3, vector.Z);
        }

        [Test]
        public void Vector3D3x2()
        {
            var vector3D = new Vector3D(1, 2, 3);

            var vector2D = new Vector2D(4, 5);

            var vector = vector3D.CrossProduct(vector2D);

            Assert.AreEqual(-15, vector.X);
            Assert.AreEqual(12, vector.Y);
            Assert.AreEqual(-3, vector.Z);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVector3D()
        {
            var vector = new Vector3D();
            vector.CrossProduct((Vector3D)null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVector2D()
        {
            var vector = new Vector3D();
            vector.CrossProduct((Vector2D)null);
        }

    }
}