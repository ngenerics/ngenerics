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
    public class Clone
    {

        [Test]
        public void Simple()
        {
            var vector = new VectorN(3);
            vector.SetValues(3, 7, 9);

            var clone = (VectorN)vector.Clone();

            Assert.AreEqual(3, vector[0]);
            Assert.AreEqual(7, vector[1]);
            Assert.AreEqual(9, vector[2]);

            Assert.AreEqual(3, clone[0]);
            Assert.AreEqual(7, clone[1]);
            Assert.AreEqual(9, clone[2]);

            Assert.AreNotSame(clone, vector);
        }

    }
}