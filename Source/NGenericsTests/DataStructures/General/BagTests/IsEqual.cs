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
    public class IsEqual : BagTest
    {

        [Test]
        public void Null()
        {
            var bag1 = new Bag<int>();
            bag1.Equals(null);
        }

        [Test]
        public void Simple()
        {
            var bag1 = new Bag<int>();
            var bag2 = new Bag<int>();

            Assert.IsFalse(bag1.Equals(null));

            Assert.IsTrue(bag1.Equals(bag2));
            Assert.IsTrue(bag2.Equals(bag1));

            bag2.Add(5);

            Assert.IsFalse(bag1.Equals(bag2));
            Assert.IsFalse(bag2.Equals(bag1));

            bag1.Add(5);

            Assert.IsTrue(bag1.Equals(bag2));
            Assert.IsTrue(bag2.Equals(bag1));

            // Add 6 now so that the count is the same
            bag1.Add(5);
            bag2.Add(6);
            Assert.IsFalse(bag1.Equals(bag2));
            Assert.IsFalse(bag2.Equals(bag1));

            bag1.Remove(5, 1);
            bag2.Remove(6);

            Assert.IsTrue(bag1.Equals(bag2));
            Assert.IsTrue(bag2.Equals(bag1));

            bag2.Add(6);

            Assert.IsFalse(bag1.Equals(bag2));
            Assert.IsFalse(bag2.Equals(bag1));

            bag1.Add(7);

            Assert.IsFalse(bag1.Equals(bag2));
            Assert.IsFalse(bag2.Equals(bag1));
        }

    }
}