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
            Assert.AreEqual(bag["aa"], 1);

            bag.Add("bb");
            Assert.IsTrue(bag.Contains("bb"));
            Assert.AreEqual(bag["aa"], 1);
            Assert.AreEqual(bag["bb"], 1);

            bag.Add("aa");
            Assert.IsTrue(bag.Contains("aa"));
            Assert.AreEqual(bag["aa"], 2);
            Assert.AreEqual(bag["bb"], 1);

            bag.Add("cc", 3);
            Assert.IsTrue(bag.Contains("cc"));
            Assert.AreEqual(bag["aa"], 2);
            Assert.AreEqual(bag["bb"], 1);
            Assert.AreEqual(bag["cc"], 3);
        }
    }
}