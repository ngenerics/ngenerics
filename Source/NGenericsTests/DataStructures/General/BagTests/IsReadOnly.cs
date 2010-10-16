using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.BagTests
{
    [TestFixture]
    public class IsReadOnly : BagTest
    {
        [Test]
        public void Simple()
        {
            var bag = GetTestBag();
            Assert.IsFalse(bag.IsReadOnly);
        }

    }
}