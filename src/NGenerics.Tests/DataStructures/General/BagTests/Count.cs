/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.DataStructures.General;
using NGenerics.Extensions;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.BagTests
{
    [TestFixture]
    public class Count : BagTest
    {

        [Test]
        public void Simple()
        {
            var bag = GetTestBag();
            Assert.AreEqual(35, bag.Count);
            Assert.IsFalse(bag.IsEmpty());

            bag = new Bag<string>();
            Assert.AreEqual(0, bag.Count);
            Assert.IsTrue(bag.IsEmpty());

            bag.Add("aa");
            Assert.AreEqual(1, bag.Count);
            Assert.IsFalse(bag.IsEmpty());

            bag.Add("aa");
            Assert.AreEqual(2, bag.Count);
            Assert.IsFalse(bag.IsEmpty());

            bag.Add("bb");
            Assert.AreEqual(3, bag.Count);
            Assert.IsFalse(bag.IsEmpty());
        }
    }
}