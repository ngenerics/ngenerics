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
    public class SubtractOperator
    {
        [Test]
        public void Double()
        {
            var vector2D = new Vector2D(4, 7);
            var vector = vector2D - 2;
            Assert.AreEqual(2, vector.X);
            Assert.AreEqual(5, vector.Y);
            Assert.AreEqual(4, vector2D.X);
            Assert.AreEqual(7, vector2D.Y);
            Assert.AreNotSame(vector2D, vector);
        }


        [Test]
        public void Vector()
        {
            var vector2D1 = new Vector2D(4, 7);
            var vector2D2 = new Vector2D(3, 4);
            var vector = vector2D1 - vector2D2;
            Assert.AreEqual(1, vector.X);
            Assert.AreEqual(3, vector.Y);
            Assert.AreEqual(4, vector2D1.X);
            Assert.AreEqual(7, vector2D1.Y);
            Assert.AreEqual(3, vector2D2.X);
            Assert.AreEqual(4, vector2D2.Y);
            Assert.AreNotSame(vector2D1, vector);
            Assert.AreNotSame(vector2D2, vector);
        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionDifferentDimensions()
        {
            var vector2D = new Vector2D();
            var vector3D = new Vector3D();
            IVector<double> vector = vector2D - vector3D;
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionLeftNull()
        {
            var vector2D1 = new Vector2D();
            var vector = null - vector2D1;
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionRightNull()
        {
            var vector2D1 = new Vector2D();
            var vector = vector2D1 - null;
        }
    }
}