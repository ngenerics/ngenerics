using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.VectorNTests
{
    [TestFixture]
    public class NegateOperator
    {
        [Test]
        public void Simple()
        {
            var vector1 = new VectorN(2);
            vector1[0] = 1;
            vector1[1] = 2;

            IVector<double> vector = -vector1;

            Assert.AreEqual(-1, vector[0]);
            Assert.AreEqual(-2, vector[1]);

            Assert.AreEqual(1, vector1[0]);
            Assert.AreEqual(2, vector1[1]);

            Assert.AreNotSame(vector1, vector);
        }
    }
}