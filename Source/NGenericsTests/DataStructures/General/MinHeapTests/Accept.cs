using System;
using NGenerics.Patterns.Visitor;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.MinHeapTests
{
    [TestFixture]
    public class Accept : MinHeapTest
    {
        [Test]
        public void Simple()
        {
            var visitor = new TrackingVisitor<int>();
            var heap = GetTestHeap();

            heap.AcceptVisitor(visitor);

            Assert.AreEqual(visitor.TrackingList.Count, heap.Count);
            Assert.IsTrue(visitor.TrackingList.Contains(5));
            Assert.IsTrue(visitor.TrackingList.Contains(4));
            Assert.IsTrue(visitor.TrackingList.Contains(99));
            Assert.IsTrue(visitor.TrackingList.Contains(12));
            Assert.IsTrue(visitor.TrackingList.Contains(5));
        }

        [Test]
        public void Stopping()
        {
            var visitor = new CompletedTrackingVisitor<int>();
            var heap = GetTestHeap();
            heap.AcceptVisitor(visitor);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVisitor()
        {
            var heap = GetTestHeap();
            heap.AcceptVisitor(null);
        }
    }
}