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

namespace NGenerics.Tests.Patterns.Specification.XorSpecification
{
    [TestFixture]
    public class IsSatisfiedBy
    {
        [Test]
        public void Xor_Should_Return_True_Only_If_Both_Specifications_Return_Different_Values()
        {
            var mocks = new MockRepository();
            var s1 = mocks.StrictMock<ISpecification<int>>();
            var s2 = mocks.StrictMock<ISpecification<int>>();

            // 1st call
            Expect.Call(s1.IsSatisfiedBy(5)).Return(true);
            Expect.Call(s2.IsSatisfiedBy(5)).Return(false);

            // 2nd call
            Expect.Call(s1.IsSatisfiedBy(5)).Return(false);
            Expect.Call(s2.IsSatisfiedBy(5)).Return(true);

            // 3rd call
            Expect.Call(s1.IsSatisfiedBy(5)).Return(true);
            Expect.Call(s2.IsSatisfiedBy(5)).Return(true);

            // 4th call
            Expect.Call(s1.IsSatisfiedBy(5)).Return(false);
            Expect.Call(s2.IsSatisfiedBy(5)).Return(false);

            mocks.ReplayAll();

            ISpecification<int> XorSpecification = new XorSpecification<int>(s1, s2);

            Assert.AreEqual(XorSpecification.IsSatisfiedBy(5), true);
            Assert.AreEqual(XorSpecification.IsSatisfiedBy(5), true);
            Assert.AreEqual(XorSpecification.IsSatisfiedBy(5), false);
            Assert.AreEqual(XorSpecification.IsSatisfiedBy(5), false);

            mocks.VerifyAll();
        }
    }

}