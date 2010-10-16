using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SetTests
{
    [TestFixture]
    public class IsEmpty
    {

        [Test]
        public void Simple()
        {
            var pascalSet = new PascalSet(0, 500);
            Assert.IsTrue(pascalSet.IsEmpty);

            pascalSet.Add(50);
            Assert.IsFalse(pascalSet.IsEmpty);

            pascalSet.Add(100);
            Assert.IsFalse(pascalSet.IsEmpty);

            pascalSet.Clear();
            Assert.IsTrue(pascalSet.IsEmpty);
        }

    }
}