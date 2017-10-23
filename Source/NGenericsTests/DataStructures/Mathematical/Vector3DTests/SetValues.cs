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
    public class SetValues
    {

        [Test]
        public void Simple()
        {
            var vector = new Vector3D(1, 2, 34);

            vector.SetValues(4, 6, 8);

            Assert.AreEqual(4, vector.X);
            Assert.AreEqual(6, vector.Y);
            Assert.AreEqual(8, vector.Z);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionNoValues()
        {
            var vector = new Vector3D();
            vector.SetValues();
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExcepionNotEnoughValues()
        {
            var vector = new Vector3D();
            vector.SetValues(4);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionTooManyValues()
        {
            var vector = new Vector3D();
            vector.SetValues(4, 6, 3, 7);
        }

    }
}