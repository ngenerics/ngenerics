/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using NGenerics.Patterns.Specification;
using NUnit.Framework;
using Rhino.Mocks;

namespace NGenerics.Tests.Patterns.Specification
{
    [TestFixture]
    public class XorSpecificationTests
    {
        [TestFixture]
        public class Construction
        {
            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void Should_Throw_If_Left_Specification_Is_Null()
            {
                new XorSpecification<int>(null, new PredicateSpecification<int>(x => x == 5));
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void Should_Throw_If_Right_Specification_Is_Null()
            {
                new XorSpecification<int>(new PredicateSpecification<int>(x => x == 5), null);
            }

            [Test]
            public void Should_Be_Fine_If_None_Are_Null()
            {
                var p1 = new PredicateSpecification<int>(x => x == 5);
                var p2 = new PredicateSpecification<int>(x => x >= 5);

                var spec = new XorSpecification<int>(p1, p2);

                Assert.AreEqual(spec.Left, p1);
                Assert.AreEqual(spec.Right, p2);
            }
        }

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
}