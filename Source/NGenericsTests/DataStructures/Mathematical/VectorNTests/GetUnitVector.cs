using System;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.VectorNTests
{
    [TestFixture]
    public class GetUnitVector
    {

        [Test]
        public void Simple()
        {
            var vector = VectorN.GetUnitVector(3);

            Assert.AreEqual(3, vector.DimensionCount);
            Assert.AreEqual(1, vector[0]);
            Assert.AreEqual(1, vector[1]);
            Assert.AreEqual(1, vector[2]);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionDimensionCountZero()
        {
            VectorN.GetUnitVector(0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionDimensionCountNegative()
        {
            VectorN.GetUnitVector(-1);
        }

    }
}