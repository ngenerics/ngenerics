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
    public class GreaterThanEqualToOperator
    {
        [Test]
        public void Simple()
        {
            var vector1 = new Vector3D(1, 1, 1);
            var vector2 = new Vector3D(2, 2, 2);
            var vector3 = new Vector3D(2, 2, 2);

            Assert.IsFalse(vector1 >= vector2);
            Assert.IsTrue(vector2 >= vector1);
            Assert.IsTrue(vector2 >= vector3);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionLeftNull()
        {
            const Vector3D vector1 = null;
            var vector2 = new Vector3D(2, 2, 2);

            var condition = vector1 >= vector2;
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionRightNull()
        {
            var vector1 = new Vector3D(2, 2, 2);
            const Vector3D vector2 = null;

            var condition = vector1 >= vector2;
        }
    }
}