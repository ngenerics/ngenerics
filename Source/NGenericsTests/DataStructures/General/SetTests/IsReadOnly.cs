using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SetTests
{
    [TestFixture]
    public class IsReadOnly
    {

        [Test]
        public void Simple()
        {
            var pascalSet = new PascalSet(0, 500);
            Assert.IsFalse(pascalSet.IsReadOnly);

            pascalSet.Add(50);
            Assert.IsFalse(pascalSet.IsReadOnly);

            pascalSet.Add(100);
            Assert.IsFalse(pascalSet.IsReadOnly);
        }

    }
}