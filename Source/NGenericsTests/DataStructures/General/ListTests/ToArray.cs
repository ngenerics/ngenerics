using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ListTests
{
    [TestFixture]
    public class ToArray
    {
        [Test]
        public void Simple()
        {
            var listBase = new ListBase<string> { "a", "b" };

            var array = listBase.ToArray();

            Assert.AreEqual("a", array[0]);
            Assert.AreEqual("b", array[1]);
        }
    }
}