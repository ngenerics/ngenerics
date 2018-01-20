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
    public class Clone
    {

        [Test]
        public void Simple()
        {
            var vector = new Vector2D(3, 7);

            var clone = (Vector2D)vector.Clone();

            Assert.AreEqual(3, vector.X);
            Assert.AreEqual(7, vector.Y);

            Assert.AreEqual(3, clone.X);
            Assert.AreEqual(7, clone.Y);

            Assert.AreNotSame(clone, vector);
        }

    }
}