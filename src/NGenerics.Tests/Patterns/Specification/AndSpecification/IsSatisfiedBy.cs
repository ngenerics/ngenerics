/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/


using NGenerics.Patterns.Specification;
using NUnit.Framework;
using Rhino.Mocks;

namespace NGenerics.Tests.Patterns.Specification.AndSpecification
{
    [TestFixture]
    public class IsSatisfiedBy
    {
        [Test]
        public void And_Should_Return_False_If_Different_Or_Both_Are_False()
        {
            var mocks = new MockRepository();
            var s1 = mocks.StrictMock<ISpecification<int>>();
            var s2 = mocks.StrictMock<ISpecification<int>>();

            Expect.Call(s1.IsSatisfiedBy(5)).Return(true);
            Expect.Call(s2.IsSatisfiedBy(5)).Return(false);

            Expect.Call(s1.IsSatisfiedBy(5)).Return(false);

            mocks.ReplayAll();

            var andSpecification = new AndSpecification<int>(s1, s2);

            Assert.AreEqual(andSpecification.IsSatisfiedBy(5), false);
            Assert.AreEqual(andSpecification.IsSatisfiedBy(5), false);

            mocks.VerifyAll();
        }

        [Test]
        public void And_Should_Return_True_If_Both_Arguments_Are_True()
        {
            var mocks = new MockRepository();
            var s1 = mocks.StrictMock<ISpecification<int>>();
            var s2 = mocks.StrictMock<ISpecification<int>>();

            Expect.Call(s1.IsSatisfiedBy(5)).Return(true);
            Expect.Call(s2.IsSatisfiedBy(5)).Return(true);

            mocks.ReplayAll();

            var andSpecification = new AndSpecification<int>(s1, s2);

            Assert.AreEqual(andSpecification.IsSatisfiedBy(5), true);

            mocks.VerifyAll();
        }
    }

}
