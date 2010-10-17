using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SkipListTests
{
    [TestFixture]
    public class IsReadOnly
    {

        [Test]
        public void Simple()
        {
            var skipList = new SkipList<int, string>();
            Assert.IsFalse(skipList.IsReadOnly);

            skipList.Add(4, "a");
            Assert.IsFalse(skipList.IsReadOnly);
        }

    }
}