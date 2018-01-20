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

namespace NGenerics.Tests.DataStructures.Mathematical.Vector2DTests
{
    [TestFixture]
    public class CrossProduct
    {

        [Test]
        public void Vector2D2x2()
        {
            var vector1 = new Vector2D(2, 3);

            var vector2 = new Vector2D(4, 5);

            IVector<double> vector = vector1.CrossProduct(vector2);

            Assert.AreEqual(0, vector[0]);
            Assert.AreEqual(0, vector[1]);
            Assert.AreEqual(-5, vector[2]);
        }


        [Test]
        public void Vector2D2x3()
        {
            var vector2D = new Vector2D(4, 5);

            var vector3D = new Vector3D(1, 2, 3);

            IVector<double> vector = vector2D.CrossProduct(vector3D);

            Assert.AreEqual(15, vector[0]);
            Assert.AreEqual(-12, vector[1]);
            Assert.AreEqual(3, vector[2]);
        }

        [Test]
        public void IVector2x2()
        {
            var vector2D = new Vector2D(2, 3);

            var vectorN = new VectorN(2);
            vectorN.SetValues(4, 5);

            var vector = vector2D.CrossProduct(vectorN);

            Assert.AreEqual(0, vector[0]);
            Assert.AreEqual(0, vector[1]);
            Assert.AreEqual(-5, vector[2]);
        }

        [Test]
        public void IVector2x3()
        {
            var vector2D = new Vector2D(4, 5);

            var vectorN = new VectorN(3);
            vectorN.SetValues(1, 2, 3);

            var vector = vector2D.CrossProduct(vectorN);

            Assert.AreEqual(15, vector[0]);
            Assert.AreEqual(-12, vector[1]);
            Assert.AreEqual(3, vector[2]);
        }

        [Test]
        public void ExceptionNullVector2D()
        {
            var vector = new Vector2D();
            Assert.Throws<ArgumentNullException>(() => vector.CrossProduct((Vector2D)null));
        }

        [Test]
        public void ExceptionNullVector3D()
        {
            var vector = new Vector2D();
            Assert.Throws<ArgumentNullException>(() => vector.CrossProduct((Vector3D)null));
        }
    }
}