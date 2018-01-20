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

namespace NGenerics.Tests.Patterns.Specification.NotSpecification
{
    [TestFixture]
    public class IsSatisfiedBy
    {
        [Test]
        public void Not_Should_Reverse_SatisfiedBy_Value()
        {
            var s = new Mock<ISpecification<int>>();

            s.Setup(x => x.IsSatisfiedBy(5)).Returns(true);
            
            var not = new NotSpecification<int>(s.Object);

            Assert.IsFalse(not.IsSatisfiedBy(5));

            s.Setup(x => x.IsSatisfiedBy(6)).Returns(false);
            Assert.IsTrue(not.IsSatisfiedBy(6));
        }
    }
}
