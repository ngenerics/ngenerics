using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.VectorNTests
{
    [TestFixture]
    public class DecrementOperator
    {
        [Test]
        public void Simple()
        {
            VectorBase<double> vector1 = new VectorN(2);
            vector1.SetValues(4, 7);

            vector1--;

            Assert.AreEqual(3, vector1[0]);
            Assert.AreEqual(6, vector1[1]);
        }
    }
}