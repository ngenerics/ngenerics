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
    public class AbsoluteMaximum
    {
        [Test]
        public void Simple()
        {
            var vector1 = new Vector2D(1, -4);

            Assert.AreEqual(4, vector1.AbsoluteMaximum());

            Assert.AreEqual(1, vector1.X);
            Assert.AreEqual(-4, vector1.Y);


            var vector2 = new Vector2D(5, -4);

            Assert.AreEqual(5, vector2.AbsoluteMaximum());

            Assert.AreEqual(5, vector2.X);
            Assert.AreEqual(-4, vector2.Y);
        }

    }
}