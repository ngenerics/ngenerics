/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NGenerics.Extensions;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.BagTests
{
    [TestFixture]
    public class Construction : BagTest
    {

        [Test]
        public void Simple()
        {
            var bag = new Bag<string>();

            Assert.AreEqual(0, bag.Count);
            Assert.IsTrue(bag.IsEmpty());

            bag = new Bag<string>(EqualityComparer<string>.Default);

            Assert.AreEqual(0, bag.Count);
            Assert.IsTrue(bag.IsEmpty());

            bag = new Bag<string>(50);

            Assert.AreEqual(0, bag.Count);
            Assert.IsTrue(bag.IsEmpty());

            bag = new Bag<string>(50);

            Assert.AreEqual(0, bag.Count);
            Assert.IsTrue(bag.IsEmpty());

            bag = new Bag<string>(50, EqualityComparer<string>.Default);

            Assert.AreEqual(0, bag.Count);
            Assert.IsTrue(bag.IsEmpty());
        }

        [Test]
        public void ExceptionNullComparer1()
        {
            Assert.Throws<ArgumentNullException>(() => new Bag<string>(null));
        }

        [Test]
        public void ExceptionNullComparer2()
        {
            Assert.Throws<ArgumentNullException>(() => new Bag<string>(5, null));
        }
    }
}