using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SetTests
{
    [TestFixture]
    public class Contains
    {

        [Test]
        public void Simple()
        {
            var pascalSet = new PascalSet(0, 50, new[] { 20, 30, 40 });

            Assert.IsTrue(pascalSet.Contains(20));
            Assert.IsTrue(pascalSet.Contains(30));
            Assert.IsTrue(pascalSet.Contains(40));

            Assert.IsFalse(pascalSet.Contains(25));
            Assert.IsFalse(pascalSet.Contains(35));
            Assert.IsFalse(pascalSet.Contains(45));
        }

    }
}