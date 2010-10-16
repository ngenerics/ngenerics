using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ListTests
{
    [TestFixture]
    public class IsFixedSize
    {
        [Test]
        public void Simple()
        {
            var listBase = new ListBase<int>();
            Assert.IsFalse(listBase.IsFixedSize);

            listBase = ListTest.GetTestList();
            Assert.IsFalse(listBase.IsFixedSize);
        }
    }
}