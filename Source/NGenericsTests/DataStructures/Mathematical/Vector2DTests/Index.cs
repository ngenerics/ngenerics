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
    public class Index
    {

        [Test]
        public void Simple()
        {
            var vector = new Vector2D();
            Assert.AreEqual(2, vector.DimensionCount);

            Assert.AreEqual(0, vector.X);
            Assert.AreEqual(0, vector.Y);
            Assert.AreEqual(0, vector[0]);
            Assert.AreEqual(0, vector[1]);

            vector[0] = 4;
            vector[1] = 5;

            Assert.AreEqual(4, vector.X);
            Assert.AreEqual(5, vector.Y);
            Assert.AreEqual(4, vector[0]);
            Assert.AreEqual(5, vector[1]);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionGetTooLarge()
        {
            var vector = new Vector2D();
            var d = vector[2];
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionGetTooSmall()
        {
            var vector = new Vector2D();
            var d = vector[-1];
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionSetTooLarge()
        {
            var vector = new Vector2D();
            vector[2] = 8;
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionSetTooSmall()
        {
            var vector = new Vector2D();
            vector[-1] = 8;
        }

    }
}