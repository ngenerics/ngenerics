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

namespace NGenerics.Tests.Patterns.Specification.XorSpecification
{
    [TestFixture]
    public class IsSatisfiedBy
    {
        [TestCase(true, false, true)]
        [TestCase(false, true, true)]
        [TestCase(false, false, false)]
        [TestCase(true, true, false)]
        public void Xor_Should_Return_True_Only_If_Both_Specifications_Return_Different_Values(bool firstValue, bool secondValue, bool expected)
        {
            var s1 = new Mock<ISpecification<int>>();
            var s2 = new Mock<ISpecification<int>>();
            ISpecification<int> XorSpecification = new XorSpecification<int>(s1.Object, s2.Object);

            s1.Setup(x => x.IsSatisfiedBy(5)).Returns(firstValue);
            s2.Setup(x => x.IsSatisfiedBy(5)).Returns(secondValue);
            Assert.AreEqual(XorSpecification.IsSatisfiedBy(5), expected);
        }
    }
}