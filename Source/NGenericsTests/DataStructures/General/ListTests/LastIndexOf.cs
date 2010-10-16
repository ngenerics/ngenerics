using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ListTests
{
    [TestFixture]
    public class LastIndexOf
    {
        [Test]
        public void Simple()
        {
            var listBase = new ListBase<int> { 3, 4, 5, 4 };
            Assert.AreEqual(3, listBase.LastIndexOf(4));
            Assert.AreEqual(3, listBase.LastIndexOf(4, 3));
            Assert.AreEqual(3, listBase.LastIndexOf(4, 3, 4));
        }
    }
}