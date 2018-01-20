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
    public class Multiply
    {

        [Test]
        public void ExceptionNullVector()
        {
            var vector = new Vector2D();
            Assert.Throws<ArgumentNullException>(() => vector.Multiply(null));
        }

        [Test]
        public void Double()
        {
            var vector = new Vector2D(1, 2);

            vector.Multiply(2);

            Assert.AreEqual(2, vector.X);
            Assert.AreEqual(4, vector.Y);
        }

        [Test]
        public void Vector2D()
        {
            var vector1 = new Vector2D(1, 2);

            var vector2 = new Vector2D(3, 4);

            var matrix = vector1.Multiply(vector2);
            Assert.AreEqual(2, matrix.Columns);
            Assert.AreEqual(2, matrix.Rows);

            Assert.AreEqual(3, matrix[0, 0]);
            Assert.AreEqual(4, matrix[0, 1]);
            Assert.AreEqual(6, matrix[1, 0]);
            Assert.AreEqual(8, matrix[1, 1]);

            Assert.AreEqual(1, vector1.X);
            Assert.AreEqual(2, vector1.Y);

            Assert.AreEqual(3, vector2.X);
            Assert.AreEqual(4, vector2.Y);
        }

        [Test]
        public void IVector()
        {
            var vector2D = new Vector2D(1, 2);

            var vectorN = new VectorN(2);
            vectorN.SetValues(3, 4);

            var matrix = vector2D.Multiply(vectorN);
            Assert.AreEqual(2, matrix.Columns);
            Assert.AreEqual(2, matrix.Rows);

            Assert.AreEqual(3, matrix[0, 0]);
            Assert.AreEqual(4, matrix[0, 1]);
            Assert.AreEqual(6, matrix[1, 0]);
            Assert.AreEqual(8, matrix[1, 1]);

            Assert.AreEqual(1, vector2D.X);
            Assert.AreEqual(2, vector2D.Y);

            Assert.AreEqual(3, vectorN[0]);
            Assert.AreEqual(4, vectorN[1]);
        }

        [Test]
        public void ExceptionDifferentDimensions()
        {
            var vector2D = new Vector2D();
            var vector3D = new Vector3D();
            Assert.Throws<ArgumentException>(() => vector2D.Multiply(vector3D));
        }
    }
}