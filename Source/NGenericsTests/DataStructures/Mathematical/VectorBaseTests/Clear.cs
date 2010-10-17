using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.VectorBaseTests
{
    [TestFixture]
    public class Clear
    {
        [Test]
        public void Simple()
        {
            var vector = new VectorN(3);
            vector.SetValues(3, 7, 8);

            vector.Clear();

            Assert.AreEqual(0, vector[0]);
            Assert.AreEqual(0, vector[1]);
            Assert.AreEqual(0, vector[0]);
        }
    }
}