using NGenerics.Tests.DataStructures.Mathematical.VectorBaseTestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.VectorBaseTests
{
    [TestFixture]
    public class Contruction
    {

        [Test]
        public void Simple()
        {
            var vector = new VectorBaseTestObject(2);
            Assert.AreEqual(2, vector.DimensionCount);
        }

    }
}