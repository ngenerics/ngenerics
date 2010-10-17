using System;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.Vector2DTests
{
    [TestFixture]
    public class SetValues
    {

        [Test]
        public void Simple()
        {
            var vector = new Vector2D { X = 1, Y = 2 };
            vector.SetValues(4, 6);
            Assert.AreEqual(4, vector.X);
            Assert.AreEqual(6, vector.Y);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionNullValues()
        {
            var vector = new Vector2D();
            vector.SetValues();
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionNotEnoughValues()
        {
            var vector = new Vector2D();
            vector.SetValues(4);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionTooManyValues()
        {
            var vector = new Vector2D();
            vector.SetValues(4, 6, 3);
        }

    }
}