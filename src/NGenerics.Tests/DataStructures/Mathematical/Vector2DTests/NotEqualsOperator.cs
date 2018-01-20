/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector2DTests
{
    [TestFixture]
    public class NotEqualsOperator
    {
        [Test]
        public void Simple()
        {
            var vector2D1 = new Vector2D(1, 2);
            var vector2D2 = new Vector2D(1, 2);
            Assert.IsFalse(vector2D1 != vector2D2);
            Assert.AreEqual(1, vector2D1.X);
            Assert.AreEqual(2, vector2D1.Y);
            Assert.AreEqual(1, vector2D2.X);
            Assert.AreEqual(2, vector2D2.Y);
        }
    }
}