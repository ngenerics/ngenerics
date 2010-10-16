using System.Collections;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ListTests
{
    [TestFixture]
    public class IndexOf
    {
        [Test]
        public void Simple()
        {
            var listBase = new ListBase<int> { 3, 4, 5 };
            Assert.AreEqual(1, listBase.IndexOf(4));
            Assert.AreEqual(1, listBase.IndexOf(4, 0));
            Assert.AreEqual(1, listBase.IndexOf(4, 0, 3));
        }
        [Test]
        public void Interface()
        {
            var listBase = (IList)new ListBase<int> { 3, 4, 5 };
            Assert.AreEqual(1, listBase.IndexOf(4));
            Assert.AreEqual(-1, listBase.IndexOf(9));
            Assert.AreEqual(-1, listBase.IndexOf("b"));
        }
    }
}