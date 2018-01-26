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
    public class GetHashCodeObj
    {

        [Test]
        public void GetHashCode_Does_Not_Return_Zero()
        {
            var vector = new Vector2D { X = 1, Y = 2 };
            Assert.AreNotEqual(0, vector.GetHashCode());
        }
        
        [Test]
        public void GetHashCode_Returns_A_Consistent_Hashcode()
        {
            var random = new Random();

            for (int i = 0; i < 10; i++)
            {
                var vector = new Vector2D {X = random.Next(), Y = random.Next()};
                Assert.AreEqual(vector.GetHashCode(), vector.GetHashCode());
            }
        }

        [Test]
        public void GetHashCode_For_Opposite_Vectors_Do_Not_Collide()
        {
            var v1 = new Vector2D(2, 8);
            var v2 = new Vector2D(8, 2);
            Assert.AreNotEqual(v1.GetHashCode(), v2.GetHashCode());
        }
    }
}