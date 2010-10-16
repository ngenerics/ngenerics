using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.BagTests
{
    [TestFixture]
    public class Clear : BagTest
    {

        [Test]
        public void Simple()
        {
            var bag = GetTestBag();

            bag.Clear();
            Assert.AreEqual(bag.Count, 0);
            Assert.IsTrue(bag.IsEmpty);

            bag.Add("aa");
            bag.Clear();

            Assert.AreEqual(bag.Count, 0);
            Assert.IsTrue(bag.IsEmpty);
        }
    }
}