/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.DataStructures.General;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.BagTests
{
    [TestFixture]
    public class Serializable : BagTest
    {

        [Test]
        public void Simple()
        {
            var bag1 = new Bag<int>();
            var bag2 = SerializeUtil.BinarySerializeDeserialize(bag1);

            Assert.AreNotSame(bag1, bag2);
            Assert.IsTrue(bag1.Equals(bag2));
        }

    }
}