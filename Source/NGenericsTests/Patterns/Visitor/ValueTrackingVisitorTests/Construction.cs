using NGenerics.Patterns.Visitor;
using NUnit.Framework;

namespace NGenerics.Tests.Patterns.Visitor.ValueTrackingVisitorTests
{
    [TestFixture]
    public class Construction
    {
        [Test]
        public void Simple()
        {
            var visitor = new ValueTrackingVisitor<int, string>();
            Assert.IsFalse(visitor.HasCompleted);
            Assert.AreEqual(visitor.TrackingList.Count, 0);
        }
    }
}