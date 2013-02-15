/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using NGenerics.Patterns.Specification;
using NUnit.Framework;
using Rhino.Mocks;

namespace NGenerics.Tests.Patterns.Specification.OrSpecification
{
    [TestFixture]
    public class IsSatisfiedBy
    {
        [Test]
        public void Or_Should_Return_True_If_One_Is_True()
        {
            var mocks = new MockRepository();
            var s1 = mocks.StrictMock<ISpecification<int>>();
            var s2 = mocks.StrictMock<ISpecification<int>>();

            // 1st call
            Expect.Call(s1.IsSatisfiedBy(5)).Return(true);

            // 2nd call
            Expect.Call(s1.IsSatisfiedBy(5)).Return(false);
            Expect.Call(s2.IsSatisfiedBy(5)).Return(true);

            mocks.ReplayAll();

            ISpecification<int> orSpecification = new OrSpecification<int>(s1, s2);

            Assert.AreEqual(orSpecification.IsSatisfiedBy(5), true);
            Assert.AreEqual(orSpecification.IsSatisfiedBy(5), true);

            mocks.VerifyAll();
        }

        [Test]
        public void Or_Should_Return_True_If_Both_Are_False()
        {
            var mocks = new MockRepository();
            var s1 = mocks.StrictMock<ISpecification<int>>();
            var s2 = mocks.StrictMock<ISpecification<int>>();

            Expect.Call(s1.IsSatisfiedBy(5)).Return(false);
            Expect.Call(s2.IsSatisfiedBy(5)).Return(false);

            mocks.ReplayAll();

            ISpecification<int> orSpecification = new OrSpecification<int>(s1, s2);

            Assert.AreEqual(orSpecification.IsSatisfiedBy(5), false);

            mocks.VerifyAll();
        }
    }
}