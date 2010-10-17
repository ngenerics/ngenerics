using System;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.VectorNTests
{
    [TestFixture]
    public class GetZeroVector
    {

        [Test]
        public void Simple()
        {
            var vector = VectorN.GetZeroVector(3);
            Assert.AreEqual(3, vector.DimensionCount);
            Assert.AreEqual(0, vector[0]);
            Assert.AreEqual(0, vector[1]);
            Assert.AreEqual(0, vector[2]);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionZero()
        {
            VectorN.GetZeroVector(0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionNegative()
        {
            VectorN.GetZeroVector(-1);
        }

    }
}