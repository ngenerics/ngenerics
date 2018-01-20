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
    public class DotProduct
    {

        [Test]
        public void Vector2D()
        {
            var vector1 = new Vector2D(4, 7);

            var vector2 = new Vector2D(3, 4);

            var dotProduct = vector1.DotProduct(vector2);
            Assert.AreEqual(40, dotProduct);

            Assert.AreEqual(4, vector1.X);
            Assert.AreEqual(7, vector1.Y);

            Assert.AreEqual(3, vector2.X);
            Assert.AreEqual(4, vector2.Y);
        }

        [Test]
        public void IVector()
        {
            var vector2D = new Vector2D(4, 7);

            var vectorN = new VectorN(2);
            vectorN.SetValues(3, 4);

            var dotProduct = vector2D.DotProduct(vectorN);
            Assert.AreEqual(40, dotProduct);

            Assert.AreEqual(4, vector2D.X);
            Assert.AreEqual(7, vector2D.Y);

            Assert.AreEqual(3, vectorN[0]);
            Assert.AreEqual(4, vectorN[1]);

        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionDifferentDimensions()
        {
            var vector = new Vector2D();
            VectorBase<double> vectorBase2 = new VectorN(4);
            vector.DotProduct(vectorBase2);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVector()
        {
            var vector = new Vector2D();
            vector.DotProduct(null);
        }

    }
}