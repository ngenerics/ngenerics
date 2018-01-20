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

namespace NGenerics.Tests.Patterns.Specification.NotSpecification
{
    [TestFixture]
    public class IsSatisfiedBy
    {
        [Test]
        public void Not_Should_Reverse_SatisfiedBy_Value()
        {
            var mocks = new MockRepository();
            var s = mocks.StrictMock<ISpecification<int>>();

            Expect.Call(s.IsSatisfiedBy(5)).Return(true);
            Expect.Call(s.IsSatisfiedBy(6)).Return(false);

            mocks.ReplayAll();

            var not = new NotSpecification<int>(s);

            Assert.IsFalse(not.IsSatisfiedBy(5));
            Assert.IsTrue(not.IsSatisfiedBy(6));

            mocks.VerifyAll();
        }
    }
}
