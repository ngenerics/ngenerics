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

namespace NGenerics.Tests.DataStructures.Mathematical.Vector2DTests
{
    [TestFixture]
    public class DivideOperator
    {
        [Test]
        public void Double()
        {
            var vector2D = new Vector2D(4, 12);
            var vector = vector2D / 2;
            Assert.AreEqual(2, vector.X);
            Assert.AreEqual(6, vector.Y);
            Assert.AreEqual(4, vector2D.X);
            Assert.AreEqual(12, vector2D.Y);
            Assert.AreNotSame(vector2D, vector);
        }

        [Test]
        public void Vector()
        {
            var vector1 = new Vector2D(4, 8);
            var vector2 = new Vector2D(2, 2);
            var vector = vector1 / vector2;
            Assert.AreEqual(1, vector.X);
            Assert.AreEqual(2, vector.Y);
            Assert.AreEqual(4, vector1.X);
            Assert.AreEqual(8, vector1.Y);
            Assert.AreEqual(2, vector2.X);
            Assert.AreEqual(2, vector2.Y);
            Assert.AreNotSame(vector1, vector);
            Assert.AreNotSame(vector2, vector);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionDifferentDimensions()
        {
            var vector2D1 = new Vector2D();
            VectorBase<double> vectorBase = new VectorN(4);
            IVector<double> vector = vector2D1 / vectorBase;
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullLeft()
        {
            var vector2D1 = new Vector2D();
            var vector = null / vector2D1;
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullRight()
        {
            var vector2D1 = new Vector2D();
            var vector = vector2D1 / null;
        }
    }
}