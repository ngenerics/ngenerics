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

namespace NGenerics.Tests.DataStructures.Mathematical.Vector2DTests
{
    [TestFixture]
    public class GreaterThanOperator
    {
        [Test]
        public void Simple()
        {
            var vector1 = new Vector2D(1, 1);
            var vector2 = new Vector2D(2, 2);
            var vector3 = new Vector2D(2, 2);

            Assert.IsFalse(vector1 > vector2);
            Assert.IsTrue(vector2 > vector1);
            Assert.IsFalse(vector2 > vector3);
        }

        [Test]
        public void ExceptionLeftNull()
        {
            const Vector2D vector1 = null;
            var vector2 = new Vector2D(2, 2);

            bool condition;
            Assert.Throws<ArgumentNullException>(() => condition = vector1 > vector2);
        }

        [Test]
        public void ExceptionRightNull()
        {
            var vector1 = new Vector2D(2, 2);
            const Vector2D vector2 = null;

            bool condition;
            Assert.Throws<ArgumentNullException>(() => condition = vector1 > vector2);

        }
    }
}