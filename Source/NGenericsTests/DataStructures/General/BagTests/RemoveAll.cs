using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.BagTests
{
    [TestFixture]
    public class RemoveAll : BagTest
    {

        [Test]
        public void Simple()
        {
            var bag = new Bag<string> { "aa", "bb", "aa", { "cc", 3 } };

            Assert.AreEqual(bag.Count, 6);

            Assert.IsTrue(bag.RemoveAll("aa"));
            Assert.IsFalse(bag.Contains("aa"));
            Assert.AreEqual(bag["aa"], 0);
            Assert.AreEqual(bag.Count, 4);

            Assert.IsFalse(bag.RemoveAll("dd"));
            Assert.AreEqual(bag.Count, 4);


            Assert.IsTrue(bag.RemoveAll("cc"));
            Assert.IsFalse(bag.Contains("cc"));
            Assert.AreEqual(bag["cc"], 0);
            Assert.AreEqual(bag.Count, 1);
        }
    }
}