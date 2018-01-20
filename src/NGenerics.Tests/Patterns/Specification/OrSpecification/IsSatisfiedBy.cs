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

namespace NGenerics.Tests.Patterns.Specification.OrSpecification
{
    [TestFixture]
    public class IsSatisfiedBy
    {
        [Test]
        public void Or_Should_Return_True_If_One_Is_True()
        {
            var s1 = new Mock<ISpecification<int>>();
            var s2 = new Mock<ISpecification<int>>();

            s1.Setup(x => x.IsSatisfiedBy(5)).Returns(true);
            s2.Setup(x => x.IsSatisfiedBy(5)).Returns(false);

            ISpecification<int> orSpecification = new OrSpecification<int>(s1.Object, s2.Object);

            Assert.AreEqual(orSpecification.IsSatisfiedBy(5), true);
            Assert.AreEqual(orSpecification.IsSatisfiedBy(5), true);
        }

        [Test]
        public void Or_Should_Return_True_If_Both_Are_False()
        {
            var s1 = new Mock<ISpecification<int>>();
            var s2 = new Mock<ISpecification<int>>();

            s1.Setup(x => x.IsSatisfiedBy(5)).Returns(false);
            s2.Setup(x => x.IsSatisfiedBy(5)).Returns(false);

            ISpecification<int> orSpecification = new OrSpecification<int>(s1.Object, s2.Object);

            Assert.AreEqual(orSpecification.IsSatisfiedBy(5), false);
        }
    }
}