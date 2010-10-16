using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ListTests
{
    [TestFixture]
    public class Capacity
    {
        [Test]
        public void Simple()
        {
            var listBase = new ListBase<int>();
            Assert.AreEqual(0, listBase.Capacity);
            listBase.Capacity = 10;
            Assert.AreEqual(10, listBase.Capacity);
        }
    }
}