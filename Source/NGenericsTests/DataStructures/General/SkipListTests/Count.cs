using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SkipListTests
{
    [TestFixture]
    public class Count
    {

        [Test]
        public void Simple()
        {
            var skipList = new SkipList<int, string>();
            Assert.AreEqual(skipList.Count, 0);

            skipList.Add(2, "2");
            Assert.AreEqual(skipList.Count, 1);

            skipList.Add(3, "3");
            Assert.AreEqual(skipList.Count, 2);
        }

    }
}