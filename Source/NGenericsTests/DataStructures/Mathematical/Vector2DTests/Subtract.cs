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
    public class Subtract
    {

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVector()
        {
            var vector = new Vector2D();
            vector.Subtract(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionDifferentDimensions()
        {
            var vector2D = new Vector2D();
            var vector3D = new Vector3D();
            vector2D.Subtract(vector3D);
        }

        [Test]
        public void Double()
        {
            var vector = new Vector2D(1, 2);

            vector.Subtract(2);

            Assert.AreEqual(-1, vector.X);
            Assert.AreEqual(0, vector.Y);
        }

        [Test]
        public void Vector2D()
        {
            var vector1 = new Vector2D(1, 2);

            var vector2 = new Vector2D(8, 4);

            vector1.Subtract(vector2);

            Assert.AreEqual(-7, vector1.X);
            Assert.AreEqual(-2, vector1.Y);
            Assert.AreEqual(8, vector2.X);
            Assert.AreEqual(4, vector2.Y);
        }

        [Test]
        public void IVector()
        {
            var vector2D = new Vector2D(1, 2);

            var vectorN = new VectorN(2);
            vectorN.SetValues(8, 4);

            vector2D.Subtract(vectorN);

            Assert.AreEqual(-7, vector2D.X);
            Assert.AreEqual(-2, vector2D.Y);
            Assert.AreEqual(8, vectorN[0]);
            Assert.AreEqual(4, vectorN[1]);
        }

    }
}