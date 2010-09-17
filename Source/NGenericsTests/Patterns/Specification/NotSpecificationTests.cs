/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using NGenerics.Patterns.Specification;
using NUnit.Framework;
using Rhino.Mocks;

namespace NGenerics.Tests.Patterns.Specification.NotSpecificationTests
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
