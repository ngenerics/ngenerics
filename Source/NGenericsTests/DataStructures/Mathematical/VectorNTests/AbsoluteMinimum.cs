using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.VectorNTests
{
    [TestFixture]
    public class AbsoluteMinimum
    {

        [Test]
        public void Simple()
        {
            var vector1 = new VectorN(4);
            vector1[0] = 1;
            vector1[1] = -4;
            vector1[2] = 3;
            vector1[3] = 2;
            Assert.AreEqual(1, vector1.AbsoluteMinimum());
        }

    }
}