using NGenerics.Patterns.Visitor;
using NUnit.Framework;

namespace NGenerics.Tests.Patterns.Visitor.ComparableFindingVisitorTests
{
    [TestFixture]
    public class Construction
    {
        [Test]
        public void Simple()
        {
            var visitor = new ComparableFindingVisitor<int>(50);
            Assert.AreEqual(visitor.SearchValue, 50);
            Assert.IsFalse(visitor.HasCompleted);
            Assert.IsFalse(visitor.Found);
        }
    }
}