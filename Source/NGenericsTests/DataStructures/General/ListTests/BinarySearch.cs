using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ListTests
{
    [TestFixture]
    public class BinarySearch
    {
        [Test]
        public void Simple()
        {
            var listBase = new ListBase<int> {3, 4, 5};
            Assert.AreEqual(2, listBase.BinarySearch(5));
        }
        [Test]
        public void Comparer()
        {
            var listBase = new ListBase<int> {3, 4, 5};
            Assert.AreEqual(2, listBase.BinarySearch(5, Comparer<int>.Default));
        }
        [Test]
        public void ComparerIndex()
        {
            var listBase = new ListBase<int> {3, 4, 5};
            Assert.AreEqual(2, listBase.BinarySearch(0, 3, 5, Comparer<int>.Default));
        }
    }
}