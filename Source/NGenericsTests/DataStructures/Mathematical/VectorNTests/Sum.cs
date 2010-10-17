using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.VectorNTests
{
    [TestFixture]
    public class Sum
    {

        [Test]
        public void Simple()
        {
            var vector = new VectorN(2);
            vector.SetValues(2, 3);
            Assert.AreEqual(5, vector.Sum());
        }

    }
}