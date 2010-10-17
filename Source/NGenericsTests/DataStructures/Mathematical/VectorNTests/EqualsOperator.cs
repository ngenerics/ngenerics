using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.VectorNTests
{
    [TestFixture]
    public class EqualsOperator
    {
        [Test]
        public void Simple()
        {
            var vector1 = new VectorN(2);
            vector1[0] = 1;
            vector1[1] = 2;
            var vector2 = new VectorN(2);
            vector2[0] = 1;
            vector2[1] = 2;
            Assert.IsTrue(vector1 == vector2);
        }


        [Test]
        public void LeftNull()
        {
            var vector1 = new VectorN(2);
            const VectorN vector2 = null;
            Assert.IsFalse(vector2 == vector1);
        }


        [Test]
        public void ReferenceEquals()
        {
            var vector1 = new VectorN(2);
            var vector2 = vector1;
            Assert.IsTrue(vector1 == vector2);
        }


        [Test]
        public void RightNull()
        {
            var vector1 = new VectorN(2);
            const VectorN vector2 = null;
            Assert.IsFalse(vector1 == vector2);
        }
    }
}