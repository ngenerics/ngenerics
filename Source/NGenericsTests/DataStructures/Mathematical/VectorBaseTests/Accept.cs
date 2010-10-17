using System;
using NGenerics.DataStructures.Mathematical;
using NGenerics.Patterns.Visitor;
using NGenerics.Tests.DataStructures.Mathematical.VectorBaseTestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.VectorBaseTests
{
    [TestFixture]
    public class Accept
    {

        [Test]
        public void Simple()
        {
            var visitor = new CountingVisitor<double>();
            var vector = new VectorN(2);
            vector.AcceptVisitor(visitor);
            Assert.AreEqual(2, visitor.Count);
        }

        [Test]
        public void Completed()
        {
            var visitor = new ComparableFindingVisitor<double>(5);
            var vector = new VectorN(3);
            vector.SetValues(2, 5, 9);
            vector.AcceptVisitor(visitor);
            Assert.IsTrue(visitor.Found);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVisitor()
        {
            var vector = new VectorBaseTestObject(2);
            vector.AcceptVisitor(null);
        }

    }
}