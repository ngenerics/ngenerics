using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ListTests
{
    [TestFixture]
    public class Reverse
    {
        [Test]
        public void Simple()
        {
            var listBase = new ListBase<string> { "a", "b" };
            listBase.Reverse();

            Assert.AreEqual("b", listBase[0]);
            Assert.AreEqual("a", listBase[1]);
        }
        [Test]
        public void Complex()
        {
            var listBase = new ListBase<string> { "a", "b" };
            listBase.Reverse(0, 2);

            Assert.AreEqual("b", listBase[0]);
            Assert.AreEqual("a", listBase[1]);
        }
    }
}