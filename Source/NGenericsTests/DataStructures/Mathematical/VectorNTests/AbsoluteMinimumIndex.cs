using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.VectorNTests
{
    [TestFixture]
    public class AbsoluteMinimumIndex
    {

        [Test]
        public void Simple()
        {
            var vector1 = new VectorN(5);
            vector1[0] = 7;
            vector1[1] = -4;
            vector1[2] = 3;
            vector1[3] = 5;
            vector1[4] = 1;

            Assert.AreEqual(4, vector1.AbsoluteMinimumIndex());
        }

    }
}