using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.VectorBaseTests
{
    [TestFixture]
    public class Minimum
    {

        [Test]
        public void Simple()
        {
            var vector = new VectorN(3);
            vector.SetValues(1, -4, 3);

            Assert.AreEqual(-4, vector.Minimum());
            Assert.AreEqual(1, vector[0]);
            Assert.AreEqual(-4, vector[1]);
            Assert.AreEqual(3, vector[2]);
        }

    }
}