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
        public void ExceptionGetTooLarge()
        {
            var vector = new Vector3D();
            double d;
            Assert.Throws<ArgumentOutOfRangeException>(() => d = vector[3]);
        }

        [Test]
        public void ExceptionGetTooSmall()
        {
            var vector = new Vector3D();
            double d;
            Assert.Throws<ArgumentOutOfRangeException>(() => d = vector[-1]);
        }

        [Test]
        public void ExceptionSetTooLarge()
        {
            var vector = new Vector3D();
            Assert.Throws<ArgumentOutOfRangeException>(() => vector[3] = 9);
        }

        [Test]
        public void ExceptionSetTooSmall()
        {
            var vector = new Vector3D();
            Assert.Throws<ArgumentOutOfRangeException>(() => vector[-1] = 9);
        }
    }
}