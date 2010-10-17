using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SortedListTests
{
    [TestFixture]
    public class Clear
    {

        [Test]
        public void Simple()
        {
            var sortedList = SortedListTest.GetTestList();
            Assert.AreEqual(sortedList.Count, 51);

            sortedList.Clear();
            Assert.AreEqual(sortedList.Count, 0);
        }

    }
}