using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SetTests
{
    [TestFixture]
    public class Capacity
    {

        [Test]
        public void Simple()
        {
            var pascalSet = new PascalSet(100);
            Assert.AreEqual(pascalSet.Capacity, 101);

            pascalSet = new PascalSet(1, 100);
            Assert.AreEqual(pascalSet.Capacity, 100);

            pascalSet = new PascalSet(55, 100);
            Assert.AreEqual(pascalSet.Capacity, 46);
        }

    }
}