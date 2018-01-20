/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/


using Moq;
using NGenerics.Patterns.Specification;
using NUnit.Framework;

namespace NGenerics.Tests.Patterns.Specification.CompositeSpecification
{
    [TestFixture]
    public class Construction
    {
        [Test]
        public void Arguments_Should_Be_Saved()
        {
            var spec1 = new PredicateSpecification<int>(x => x > 5);
            var spec2 = new PredicateSpecification<int>(x => x < 10);

            var compositeSpecification = new Mock<CompositeSpecification<int>>(spec1, spec2);

            Assert.AreEqual(compositeSpecification.Object.Left, spec1);
            Assert.AreEqual(compositeSpecification.Object.Right, spec2);
        }
    }
}