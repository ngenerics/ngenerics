using System;
using System.Collections.Generic;
using NGenerics.DataStructures.General;
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

            Assert.AreEqual(bag.Count, 0);
            Assert.IsTrue(bag.IsEmpty);

            bag = new Bag<string>(EqualityComparer<string>.Default);

            Assert.AreEqual(bag.Count, 0);
            Assert.IsTrue(bag.IsEmpty);

            bag = new Bag<string>(50);

            Assert.AreEqual(bag.Count, 0);
            Assert.IsTrue(bag.IsEmpty);

            bag = new Bag<string>(50);

            Assert.AreEqual(bag.Count, 0);
            Assert.IsTrue(bag.IsEmpty);

            bag = new Bag<string>(50, EqualityComparer<string>.Default);

            Assert.AreEqual(bag.Count, 0);
            Assert.IsTrue(bag.IsEmpty);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullComparer1()
        {
            new Bag<string>(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullComparer2()
        {
            new Bag<string>(5, null);
        }

    }
}