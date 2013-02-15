/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

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
    public class Swap
    {

        [Test]
        public void Vector2D()
        {
            var vector1 = new Vector2D(1, 2);

            var vector2 = new Vector2D(3, 4);

            vector1.Swap(vector2);

            Assert.AreEqual(3, vector1.X);
            Assert.AreEqual(4, vector1.Y);
            Assert.AreEqual(1, vector2.X);
            Assert.AreEqual(2, vector2.Y);
        }

        [Test]
        public void IVector()
        {
            var vector1 = new Vector2D(1, 2);

            var vector2 = new VectorN(2);
            vector2.SetValues(3, 4);

            vector1.Swap(vector2);

            Assert.AreEqual(3, vector1.X);
            Assert.AreEqual(4, vector1.Y);
            Assert.AreEqual(1, vector2[0]);
            Assert.AreEqual(2, vector2[1]);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVector()
        {
            var vector = new Vector2D();
            vector.Swap(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionDifferentDimensions()
        {
            var vector = new Vector2D();
            VectorBase<double> vectorBase = new VectorN(4);
            vector.Swap(vectorBase);
        }

    }
}