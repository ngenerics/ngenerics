using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SortedListTests
{
    [TestFixture]
    public class IndexOf
    {

        [Test]
        public void Simple()
        {
            var sortedList = new SortedList<int>();
            Assert.Less(sortedList.IndexOf(2), 0);

            sortedList.Add(5);
            Assert.AreEqual(sortedList.IndexOf(5), 0);

            sortedList.Add(2);
            Assert.AreEqual(sortedList.IndexOf(5), 1);
            Assert.AreEqual(sortedList.IndexOf(2), 0);

            Assert.Less(sortedList.IndexOf(10), 0);
        }

    }
}