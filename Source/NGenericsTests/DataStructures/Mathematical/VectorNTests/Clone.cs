using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.VectorNTests
{
    [TestFixture]
    public class Clone
    {

        [Test]
        public void Simple()
        {
            var vector = new VectorN(3);
            vector.SetValues(3, 7, 9);

            var clone = (VectorN)vector.Clone();

            Assert.AreEqual(3, vector[0]);
            Assert.AreEqual(7, vector[1]);
            Assert.AreEqual(9, vector[2]);

            Assert.AreEqual(3, clone[0]);
            Assert.AreEqual(7, clone[1]);
            Assert.AreEqual(9, clone[2]);

            Assert.AreNotSame(clone, vector);
        }

    }
}