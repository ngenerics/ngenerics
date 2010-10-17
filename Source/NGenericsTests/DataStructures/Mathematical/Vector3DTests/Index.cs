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

namespace NGenerics.Tests.DataStructures.Mathematical.Vector3DTests
{
    [TestFixture]
    public class Index
    {

        [Test]
        public void Simple()
        {
            var vector = new Vector3D();
            Assert.AreEqual(3, vector.DimensionCount);

            Assert.AreEqual(0, vector.X);
            Assert.AreEqual(0, vector.Y);
            Assert.AreEqual(0, vector.Z);

            Assert.AreEqual(0, vector[0]);
            Assert.AreEqual(0, vector[1]);
            Assert.AreEqual(0, vector[2]);


            vector[0] = 4;
            vector[1] = 5;
            vector[2] = -2;

            Assert.AreEqual(4, vector.X);
            Assert.AreEqual(5, vector.Y);
            Assert.AreEqual(-2, vector.Z);

            Assert.AreEqual(4, vector[0]);
            Assert.AreEqual(5, vector[1]);
            Assert.AreEqual(-2, vector[2]);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionGetTooLarge()
        {
            var vector = new Vector3D();
            var d = vector[3];
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionGetTooSmall()
        {
            var vector = new Vector3D();
            var d = vector[-1];
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionSetTooLarge()
        {
            var vector = new Vector3D();
            vector[3] = 9;
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionSetTooSmall()
        {
            var vector = new Vector3D();
            vector[-1] = 9;
        }

    }
}