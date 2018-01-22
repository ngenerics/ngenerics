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

            vector1.CrossProduct(vector2).AssertEquals(0, 0, -2);
        }


        [Test]
        public void Vector2D2x2_Returns_Non_Zero_Vector_When_Left_Y_Is_0()
        {
            var vector1 = new Vector2D(2, 0);
            var vector2 = new Vector2D(4, 5);

            vector1.CrossProduct(vector2).AssertEquals(0, 0, 10);

            vector1 = new Vector2D(2, 4);
            vector2 = new Vector2D(4, 0);

            vector1.CrossProduct(vector2).AssertEquals(0, 0, -16);
        }

        [Test]
        public void Vector2D2x3()
        {
            var vector2D = new Vector2D(4, 5);
            var vector3D = new Vector3D(1, 2, 3);

            vector2D.CrossProduct(vector3D).AssertEquals(15, -12, 3);
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

            IVector<double> vector = vector2D.CrossProduct(vectorN);

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