using NGenerics.Comparers;
using NUnit.Framework;

namespace NGenerics.Tests.Comparers.ReverseComparerTests
{
    [TestFixture]
    public class Compare
    {
        [Test]
        public void Simple()
        {
            var comparer = new ReverseComparer<int>();

            Assert.AreEqual(comparer.Compare(2, 3), 1);
            Assert.AreEqual(comparer.Compare(3, 2), -1);
            Assert.AreEqual(comparer.Compare(0, 0), 0);
            Assert.AreEqual(comparer.Compare(0, 1), 1);
            Assert.AreEqual(comparer.Compare(1, 0), -1);
        }
    }
}