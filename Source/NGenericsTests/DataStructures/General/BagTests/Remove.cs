using System;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.BagTests
{
    [TestFixture]
    public class Remove : BagTest
    {

        [Test]
        public void Simple()
        {
            var bag = new Bag<string> { "aa", "bb", "aa", { "cc", 3 } };

            Assert.AreEqual(bag.Count, 6);

            Assert.IsTrue(bag.Remove("aa"));
            Assert.IsTrue(bag.Contains("aa"));
            Assert.AreEqual(bag["aa"], 1);
            Assert.AreEqual(bag.Count, 5);

            Assert.IsTrue(bag.Remove("aa"));
            Assert.IsFalse(bag.Contains("aa"));
            Assert.AreEqual(bag["aa"], 0);
            Assert.AreEqual(bag.Count, 4);

            Assert.IsFalse(bag.Remove("dd"));
            Assert.AreEqual(bag.Count, 4);

            Assert.IsTrue(bag.Remove("bb"));
            Assert.IsFalse(bag.Contains("bb"));
            Assert.AreEqual(bag["bb"], 0);
            Assert.AreEqual(bag.Count, 3);

            Assert.IsTrue(bag.Remove("cc"));
            Assert.IsTrue(bag.Contains("cc"));
            Assert.AreEqual(bag["cc"], 2);
            Assert.AreEqual(bag.Count, 2);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionMaximumBelowZero()
        {
            var bag = new Bag<string> { "aa", "bb", "aa", { "cc", 3 } };

            bag.Remove("aa", -1);
        }

        [Test]
        public void Max()
        {
            var bag = new Bag<string> { "aa", "bb", "aa", { "cc", 3 } };

            Assert.AreEqual(bag.Count, 6);

            Assert.IsTrue(bag.Remove("aa", 1));
            Assert.IsTrue(bag.Contains("aa"));
            Assert.AreEqual(bag["aa"], 1);
            Assert.AreEqual(bag.Count, 5);

            Assert.IsTrue(bag.Remove("aa", 2));
            Assert.IsFalse(bag.Contains("aa"));
            Assert.AreEqual(bag["aa"], 0);
            Assert.AreEqual(bag.Count, 4);

            Assert.IsTrue(bag.Remove("cc", 2));
            Assert.IsTrue(bag.Contains("cc"));
            Assert.AreEqual(bag["cc"], 1);
            Assert.AreEqual(bag.Count, 2);

            Assert.IsFalse(bag.Remove("dd", 2));
        }

    }
}