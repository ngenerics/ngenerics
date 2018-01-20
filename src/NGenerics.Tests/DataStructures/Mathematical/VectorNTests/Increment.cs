/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.VectorNTests
{
    [TestFixture]
    public class Increment
    {

        [Test]
        public void Simple()
        {
            var vector1 = new VectorN(2);
            vector1.SetValues(4, 7);
            vector1.Increment();
            Assert.AreEqual(5, vector1[0]);
            Assert.AreEqual(8, vector1[1]);
        }

    }
}