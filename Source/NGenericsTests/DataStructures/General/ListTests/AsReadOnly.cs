using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ListTests
{
    [TestFixture]
    public class AsReadOnly
    {
        [Test]
        public void Simple()
        {
            var listBase = new ListBase<int> {3};
            Assert.IsTrue(listBase.AsReadOnly().Contains(3));
        }
    }
}