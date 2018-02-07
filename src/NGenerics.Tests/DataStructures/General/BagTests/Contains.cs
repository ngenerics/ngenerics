/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.BagTests
{
    [TestFixture]
    public class Contains : BagTest
    {

        [Test]
        public void Simple()
        {
            var bag = new Bag<string> { "aa" };

            Assert.IsTrue(bag.Contains("aa"));
            Assert.AreEqual(1, bag["aa"]);

            bag.Add("bb");
            Assert.IsTrue(bag.Contains("bb"));
            Assert.AreEqual(1, bag["aa"]);
            Assert.AreEqual(1, bag["bb"]);

            bag.Add("aa");
            Assert.IsTrue(bag.Contains("aa"));
            Assert.AreEqual(2, bag["aa"]);
            Assert.AreEqual(1, bag["bb"]);

            bag.Add("cc", 3);
            Assert.IsTrue(bag.Contains("cc"));
            Assert.AreEqual(2, bag["aa"]);
            Assert.AreEqual(1, bag["bb"]);
            Assert.AreEqual(3, bag["cc"]);
        }
    }
}