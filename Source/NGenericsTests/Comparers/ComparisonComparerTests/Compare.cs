using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.Comparers.ComparisonComparerTests
{
    [TestFixture]
    public class Compare : ComparisonComparerTest
    {
        [Test]
        public void Simple()
        {
            var s1 = new SimpleClass("a");
            var s2 = new SimpleClass("b");
            var s3 = new SimpleClass("c");
            var s4 = new SimpleClass("a");

            var comparer = GetTestComparer();

            Assert.AreEqual(comparer.Compare(s1, s2), -1);
            Assert.AreEqual(comparer.Compare(s1, s3), -1);
            Assert.AreEqual(comparer.Compare(s1, s4), 0);

            Assert.AreEqual(comparer.Compare(s2, s1), 1);
            Assert.AreEqual(comparer.Compare(s3, s1), 1);
            Assert.AreEqual(comparer.Compare(s4, s1), 0);
        }
    }
}