using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SkipListTests
{
    [TestFixture]
    public class Clear
    {

        [Test]
        public void Simple()
        {
            var skipList = new SkipList<int, string>();
            Assert.AreEqual(skipList.Count, 0);

            skipList.Add(4, "a");
            Assert.AreEqual(skipList.Count, 1);

            skipList.Clear();
            Assert.AreEqual(skipList.Count, 0);

            skipList.Add(5, "a");
            skipList.Add(6, "a");
            Assert.AreEqual(skipList.Count, 2);

            skipList.Clear();
            Assert.AreEqual(skipList.Count, 0);
        }

    }
}