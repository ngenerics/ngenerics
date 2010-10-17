using NGenerics.Patterns.Specification;
using NUnit.Framework;

namespace NGenerics.Tests.Patterns.Specification.NotSpecification
{
    [TestFixture]
    public class Construction
    {
        [Test]
        public void Specification_Should_Be_Saved()
        {
            ISpecification<int> spec = new PredicateSpecification<int>(x => x == 5);
            var notSpec = spec.Not();

            Assert.IsInstanceOf<NotSpecification<int>>(notSpec);
            Assert.AreEqual(((NotSpecification<int>)notSpec).Specification, spec);
        }
    }
}