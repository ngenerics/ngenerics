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
    public class Divide
    {

        [Test]
        public void Double()
        {
            var vector = new Vector2D(9, 3);

            vector.Divide(3);

            Assert.AreEqual(3, vector.X);
            Assert.AreEqual(1, vector.Y);
        }

        [Test]
        public void Vector2D()
        {
            var vector1 = new Vector2D(24, 32);

            var vector2 = new Vector2D(2, 4);

            vector1.Divide(vector2);

            Assert.AreEqual(3, vector1.X);
            Assert.AreEqual(4, vector1.Y);

            Assert.AreEqual(2, vector2.X);
            Assert.AreEqual(4, vector2.Y);
        }

        [Test]
        public void IVector()
        {
            var vector2D = new Vector2D(24, 32);

            var vectorN = new VectorN(2);
            vectorN.SetValues(2, 4);

            vector2D.Divide(vectorN);

            Assert.AreEqual(3, vector2D.X);
            Assert.AreEqual(4, vector2D.Y);

            Assert.AreEqual(2, vectorN[0]);
            Assert.AreEqual(4, vectorN[1]);
        }

        [Test]
        public void ExceptionNullVector()
        {
            var vector = new Vector2D();
            Assert.Throws<ArgumentNullException>(() => vector.Divide(null));
        }

        [Test]
        public void ExceptionDifferentDimensions()
        {
            var vector2D = new Vector2D();
            var vector3D = new Vector3D();
            Assert.Throws<ArgumentException>(() => vector2D.Divide(vector3D));
        }

    }
}