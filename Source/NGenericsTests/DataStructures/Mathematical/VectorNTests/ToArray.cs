using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.VectorNTests
{
    [TestFixture]
    public class ToArray
    {

        [Test]
        public void Simple()
        {
            var vector = new VectorN(2);
            vector.SetValues(8, 3);

            var actual = vector.ToArray();

            Assert.AreEqual(2, actual.Length);
            Assert.AreEqual(8, actual[0]);
            Assert.AreEqual(3, actual[1]);
        }

    }
}