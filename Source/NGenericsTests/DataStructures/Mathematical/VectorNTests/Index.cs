using System;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.VectorNTests
{
    [TestFixture]
    public class Index
    {

        [Test]
        public void Simple()
        {
            var vector = new VectorN(2);
            Assert.AreEqual(2, vector.DimensionCount);

            Assert.AreEqual(0, vector[0]);
            Assert.AreEqual(0, vector[1]);

            vector[0] = 4;
            vector[1] = 5;

            Assert.AreEqual(4, vector[0]);
            Assert.AreEqual(5, vector[1]);
        }

        [Test]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ExceptionTooLarge()
        {
            var vector = new VectorN(2);
            var d = vector[2];
        }

        [Test]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ExceptionTooSmall()
        {
            var vector = new VectorN(2);
            var d = vector[-1];
        }

    }
}