using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SkipListTests
{
    [TestFixture]
    public class TryGetValue
    {

        [Test]
        public void Simple()
        {
            var skipList = new SkipList<int, string>();
            string val;
            Assert.IsFalse(skipList.TryGetValue(5, out val));

            skipList.Add(3, "4");
            Assert.IsFalse(skipList.TryGetValue(5, out val));
            Assert.IsTrue(skipList.TryGetValue(3, out val));
            Assert.AreEqual(val, "4");
        }

    }
}