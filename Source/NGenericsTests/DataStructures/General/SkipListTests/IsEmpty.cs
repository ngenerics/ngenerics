using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SkipListTests
{
    [TestFixture]
    public class IsEmpty
    {

        [Test]
        public void Simple()
        {
            var skipList = new SkipList<int, string>();
            Assert.IsTrue(skipList.IsEmpty);

            skipList.Add(4, "a");
            Assert.IsFalse(skipList.IsEmpty);

            skipList.Clear();
            Assert.IsTrue(skipList.IsEmpty);
        }

    }
}