using System;
using NGenerics.Tests.DataStructures.Mathematical.VectorBaseTestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.VectorBaseTests
{
    [TestFixture]
    public class Subtract
    {

        [Test]
        [ExpectedException(typeof(NotImplementedException), ExpectedMessage = "SubtractSafe")]
        public void Exception()
        {
            var vector1 = new VectorBaseTestObject(2);
            var vector2 = new VectorBaseTestObject(2);
            vector1.Subtract(vector2);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionVectorNull()
        {
            var vector1 = new VectorBaseTestObject(2);
            vector1.Subtract(null);
        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionDifferentDimensions()
        {
            var vector1 = new VectorBaseTestObject(2);
            var vector2 = new VectorBaseTestObject(3);
            vector1.Subtract(vector2);
        }

    }
}