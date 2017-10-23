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
    public class UnitVector
    {

        [Test]
        public void Simple()
        {
            var vector = Vector2D.UnitVector;
            Assert.AreEqual(1, vector.X);
            Assert.AreEqual(1, vector.Y);
        }

    }
}