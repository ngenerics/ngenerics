/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.BagTests
{
    [TestFixture]
    public class Subtract : BagTest
    {

        [Test]
        public void Simple()
        {
            var bag1 = new Bag<int> { 3, 4, 5, 6 };

            var bag2 = new Bag<int> { 3, 4, 5 };

            var shouldBe = new Bag<int> { 6 };

            var resultBag = bag1 - bag2;

            Assert.IsTrue(resultBag.Equals(shouldBe));

            bag1.Clear();
            bag2.Clear();

            bag1.Add(3, 3);
            bag2.Add(3, 2);

            bag1.Add(5, 5);
            bag2.Add(5, 7);

            shouldBe.Clear();
            shouldBe.Add(3, 1);

            resultBag = bag1 - bag2;

            Assert.IsTrue(resultBag.Equals(shouldBe));
        }

        [Test]
        public void Interface()
        {
            var bag1 = new Bag<int> { 3, 4, 5, 6 };

            var bag2 = new Bag<int> { 3, 4, 5 };

            var shouldBe = new Bag<int> { 6 };

            var resultBag = (Bag<int>)((IBag<int>)bag1).Subtract(bag2);

            Assert.IsTrue(resultBag.Equals(shouldBe));

            bag1.Clear();
            bag2.Clear();

            bag1.Add(3, 3);
            bag2.Add(3, 2);

            bag1.Add(5, 5);
            bag2.Add(5, 7);

            shouldBe.Clear();
            shouldBe.Add(3, 1);

            resultBag = bag1.Subtract(bag2);

            Assert.IsTrue(resultBag.Equals(shouldBe));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullBag()
        {
            var bag = new Bag<int>();
            bag.Subtract(null);
        }

    }
}