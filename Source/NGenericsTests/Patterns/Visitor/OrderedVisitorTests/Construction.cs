using System;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;

namespace NGenerics.Tests.Patterns.Visitor.OrderedVisitorTests
{
    [TestFixture]
    public class Construction
    {
        [Test]
        public void Simple()
        {
            var visitor = new TrackingVisitor<int>();
            var orderedVisitor = new OrderedVisitor<int>(visitor);

            Assert.IsFalse(orderedVisitor.HasCompleted);
            Assert.AreSame(orderedVisitor.VisitorToUse, visitor);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVisitor()
        {
            new OrderedVisitor<int>(null);
        }
    }
}