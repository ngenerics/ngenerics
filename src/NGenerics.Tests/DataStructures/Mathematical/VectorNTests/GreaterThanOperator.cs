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

namespace NGenerics.Tests.DataStructures.Mathematical.VectorNTests
{
    [TestFixture]
    public class GreaterThanOperator
    {
        [Test]
        public void Simple2()
        {
            var vector1 = new VectorN(2);
            vector1.SetValues(2, 2);

            var vector2 = new VectorN(2);
            vector2.SetValues(1, 1);

            var vector3 = new VectorN(2);
            vector3.SetValues(2, 2);

            var vector4 = new VectorN(2);
            vector4.SetValues(3, 3);

            Assert.IsTrue(vector1 > vector2);

            Assert.IsFalse(vector1 > vector3);

            Assert.IsFalse(vector1 > vector4);
        }

        [Test]
        public void Simple1()
        {
            var vector1 = new VectorN(3);
            vector1.SetValues(1, 1, 1);
            var vector2 = new VectorN(3);
            vector2.SetValues(2, 2, 2);
            var vector3 = new VectorN(3);
            vector3.SetValues(2, 2, 2);

            Assert.IsFalse(vector1 > vector2);
            Assert.IsTrue(vector2 > vector1);
            Assert.IsFalse(vector2 > vector3);
        }

        [Test]
        public void ExceptionLeftNull()
        {
            const VectorN vector1 = null;
            var vector2 = new VectorN(3);
            vector2.SetValues(2, 2, 2);

            bool condition;
            Assert.Throws<ArgumentNullException>(() => condition = vector1 > vector2);
        }

        [Test]
        public void ExceptionRightNull()
        {
            var vector1 = new VectorN(3);
            vector1.SetValues(1, 1, 1);
            const VectorN vector2 = null;

            bool condition;
            Assert.Throws<ArgumentNullException>(() => condition = vector1 > vector2);
        }
    }
}