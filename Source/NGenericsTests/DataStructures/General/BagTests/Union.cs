/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

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
    public class Union : BagTest
    {
        [Test]
        public void Simple()
        {
            var bag1 = new Bag<int>();
            var bag2 = new Bag<int>();

            bag1.Add(2, 2);
            bag1.Add(3, 3);
            bag1.Add(4, 5);

            bag2.Add(3, 2);
            bag2.Add(4, 3);
            bag2.Add(5, 2);
            bag2.Add(6, 2);

            var shouldBe = new Bag<int> { { 2, 2 }, { 3, 5 }, { 4, 8 }, { 5, 2 }, { 6, 2 } };

            var resultBag = bag1 + bag2;

            Assert.IsTrue(shouldBe.Equals(resultBag));

            resultBag = bag2 + bag1;

            Assert.IsTrue(shouldBe.Equals(resultBag));
        }

        [Test]
        public void Interface()
        {
            var bag1 = new Bag<int>();
            var bag2 = new Bag<int>();

            bag1.Add(2, 2);
            bag1.Add(3, 3);
            bag1.Add(4, 5);

            bag2.Add(3, 2);
            bag2.Add(4, 3);
            bag2.Add(5, 2);

            var shouldBe = new Bag<int> { { 2, 2 }, { 3, 5 }, { 4, 8 }, { 5, 2 } };

            var resultBag = (Bag<int>)((IBag<int>)bag1).Union(bag2);

            Assert.IsTrue(shouldBe.Equals(resultBag));

            resultBag = (Bag<int>)((IBag<int>)bag2).Union(bag1);

            Assert.IsTrue(shouldBe.Equals(resultBag));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullb2()
        {
            var bag1 = new Bag<int>();
            var resultBag = bag1 + null;
        }

    }
}