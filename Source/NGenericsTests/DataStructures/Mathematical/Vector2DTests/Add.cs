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
    public class Add
    {

        [Test]
        public void Double()
        {
            var vector = new Vector2D(4, 7)
                             {
                                 1
                             };

            Assert.AreEqual(5, vector.X);
            Assert.AreEqual(8, vector.Y);
        }

        [Test]
        public void Vector2D()
        {
            var vector1 = new Vector2D(4, 7);

            var vector2 = new Vector2D(3, 4);

            vector1.Add(vector2);

            Assert.AreEqual(7, vector1.X);
            Assert.AreEqual(11, vector1.Y);

            Assert.AreEqual(3, vector2.X);
            Assert.AreEqual(4, vector2.Y);
        }

        [Test]
        public void IVector()
        {
            var vector1 = new Vector2D(4, 7);

            var vector2 = new VectorN(2);
            vector2.SetValues(3, 4);

            vector1.Add(vector2);

            Assert.AreEqual(7, vector1[0]);
            Assert.AreEqual(11, vector1[1]);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVector()
        {
            new Vector2D
                {
                    null
                };
        }

    }
}