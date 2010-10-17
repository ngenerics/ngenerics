using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SkipListTests
{
    [TestFixture]
    public class ContainsKey
    {

        [Test]
        public void Simple()
        {
            var skipList = new SkipList<int, string>();

            for (var i = 0; i < 100; i++)
            {
                skipList.Add(i, i.ToString());
                Assert.IsTrue(skipList.ContainsKey(i));
            }

            for (var i = 100; i < 150; i++)
            {
                Assert.IsFalse(skipList.ContainsKey(i));
            }
        }

    }
}