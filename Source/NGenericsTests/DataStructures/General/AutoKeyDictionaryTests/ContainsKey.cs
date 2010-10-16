using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.AutoKeyDictionaryTests
{
    [TestFixture]
    public class ContainsKey
    {
        [Test]
        public void Simple()
        {
            var target = new AutoKeyDictionary<string, int>(x => x.ToString()) { 2 };
            Assert.IsTrue(target.ContainsKey("2"));
            Assert.IsFalse(target.ContainsKey("1"));
            Assert.IsFalse(target.ContainsKey("3"));
        }
    }
}