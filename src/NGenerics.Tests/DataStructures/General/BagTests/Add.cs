/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.BagTests
{
    [TestFixture]
    public class Add : BagTest
    {

        [Test]
        public void Simple()
        {
            var bag = new Bag<string> {"aa"};

            Assert.AreEqual(1, bag.Count);
            Assert.IsTrue(bag.Contains("aa"));
            Assert.AreEqual(1, bag["aa"]);

            bag.Add("bb");
            Assert.AreEqual(2, bag.Count);
            Assert.IsTrue(bag.Contains("bb"));
            Assert.AreEqual(1, bag["bb"]);

            bag.Add("aa");
            Assert.AreEqual(3, bag.Count);
            Assert.IsTrue(bag.Contains("aa"));
            Assert.AreEqual(2, bag["aa"]);

            bag.Add("cc", 3);
            Assert.AreEqual(6, bag.Count);
            Assert.IsTrue(bag.Contains("cc"));
            Assert.AreEqual(3, bag["cc"]);

            bag.Add("cc", 2);

            Assert.AreEqual(8, bag.Count);
            Assert.IsTrue(bag.Contains("cc"));
            Assert.AreEqual(5, bag["cc"]);
        }

        [Test]
        public void ExceptionZeroAmount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => 
                new Bag<string> { {"aa", 0} }
            );
        }

        [Test]
        public void ExceptionNegativeAmount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>  
                new Bag<string> { {"aa", -1} }
            );
        }

    }
}