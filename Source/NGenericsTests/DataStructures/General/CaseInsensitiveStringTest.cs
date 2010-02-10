using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General
{
    [TestFixture]
    public class CaseInsensitiveStringTest
    {

        [Test]
        public void ReplaceString()
        {
            CaseInsensitiveString value = "AbcDEf";

            Assert.AreEqual("AbEf", value.Replace("Cd", string.Empty).Value);
            Assert.AreEqual("AbXyEf", value.Replace("Cd", "Xy").Value);
        }
        [Test]
        public void ReplaceChar()
        {
            CaseInsensitiveString value = "AbcDEf";

            Assert.AreEqual("AbFDEf", value.Replace('C', 'F').Value);
        }
    }
}