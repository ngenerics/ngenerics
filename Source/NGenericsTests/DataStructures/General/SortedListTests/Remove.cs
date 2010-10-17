using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SortedListTests
{
    [TestFixture]
    public class Remove
    {

        [Test]
        public void Simple()
        {
            var sortedList = new SortedList<int>();

            for (var i = 50; i >= 0; i--)
            {
                sortedList.Add(i * 2);
            }

            Assert.AreEqual(sortedList.Count, 51);

            Assert.IsTrue(sortedList.Remove(50));
            Assert.AreEqual(sortedList.Count, 50);

            Assert.IsFalse(sortedList.Remove(3));
            Assert.AreEqual(sortedList.Count, 50);
        }

    }
}