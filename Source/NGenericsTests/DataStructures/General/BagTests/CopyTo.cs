using System;
using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.BagTests
{
    [TestFixture]
    public class CopyTo : BagTests.BagTest
    {

        [Test]
        public void Simple()
        {
            var bag = new Bag<int> { 3, 4, 5, 6 };

            var array = new int[50];

            bag.CopyTo(array, 0);

            Assert.AreNotEqual(array[0], 0);
            Assert.AreNotEqual(array[1], 0);
            Assert.AreNotEqual(array[2], 0);
            Assert.AreNotEqual(array[3], 0);
            Assert.AreEqual(array[4], 0);

            var list = new List<int> { array[0], array[1], array[2], array[3] };

            Assert.IsTrue(list.Contains(3));
            Assert.IsTrue(list.Contains(4));
            Assert.IsTrue(list.Contains(5));
            Assert.IsTrue(list.Contains(6));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionInvalid1()
        {
            var bag = new Bag<int> { 3, 4, 5, 6 };

            var array = new int[3];

            bag.CopyTo(array, 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionInvalid2()
        {
            var bag = new Bag<int> { 3, 4, 5, 6 };

            var array = new int[4];

            bag.CopyTo(array, 1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionInvalid3()
        {
            var bag = new Bag<int> { 3, 4, 5, 6 };

            bag.CopyTo(null, 1);
        }
    }
}