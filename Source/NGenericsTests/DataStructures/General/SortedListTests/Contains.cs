using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SortedListTests
{
    [TestFixture]
    public class Contains
    {

        [Test]
        public void Simple()
        {
            var sortedList = new SortedList<int>();

            for (var i = 0; i < 20; i++)
            {
                sortedList.Add(i);
            }

            Assert.IsTrue(sortedList.Contains(5));
            Assert.IsFalse(sortedList.Contains(50));
        }

    }
}