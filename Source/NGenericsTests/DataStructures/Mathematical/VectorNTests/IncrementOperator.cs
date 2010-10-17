using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.VectorNTests
{
    [TestFixture]
    public class IncrementOperator
    {
        [Test]
        public void Simple()
        {
            VectorBase<double> vector1 = new VectorN(2);
            vector1.SetValues(4, 7);

            vector1++;

            Assert.AreEqual(5, vector1[0]);
            Assert.AreEqual(8, vector1[1]);
        }
    }
}