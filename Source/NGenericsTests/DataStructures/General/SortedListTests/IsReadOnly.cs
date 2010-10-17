using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SortedListTests
{
    [TestFixture]
    public class IsReadOnly
    {

        [Test]
        public void Simple()
        {
            var sortedList = new SortedList<int>();
            Assert.IsFalse(sortedList.IsReadOnly);

            sortedList = SortedListTest.GetTestList();
            Assert.IsFalse(sortedList.IsReadOnly);
        }

    }
}