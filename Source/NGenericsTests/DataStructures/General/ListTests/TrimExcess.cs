using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ListTests
{
    [TestFixture]
    public class TrimExcess
    {
        [Test]
        public void Simple()
        {
            var listBase = new ListBase<string>(5) { "as", "bs", "c" };
            listBase.TrimExcess();
            Assert.AreEqual(3, listBase.Capacity);
        }


    }
}