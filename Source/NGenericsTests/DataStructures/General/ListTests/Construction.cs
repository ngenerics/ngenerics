using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ListTests
{
    [TestFixture]
    public class Construction
    {
        [Test]
        public void Simple()
        {
            var listBase = new ListBase<int>();
				
        }
        [Test]
        public void Capacity()
        {
            var listBase = new ListBase<int>(3);
            Assert.AreEqual(3, listBase.Capacity);
        }
        [Test]
        public void Collection()
        {
            var listBase = new ListBase<int>(new[]{3});
            Assert.IsTrue(listBase.Contains(3));
        }
    }
}