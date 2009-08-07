/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/

using NGenerics.Patterns.Specification;
using NUnit.Framework;
using Rhino.Mocks;

namespace NGenerics.Tests.Patterns.Specification
{
    [TestFixture]
    public class CompositeSpecificationTests
    {
        [TestFixture]
        public class Construction
        {
            [Test]
            public void Arguments_Should_Be_Saved()
            {
                var spec1 = new PredicateSpecification<int>(x => x > 5);
                var spec2 = new PredicateSpecification<int>(x => x < 10);

                var mocks = new MockRepository();

                var compositeSpecification = mocks.Stub<CompositeSpecification<int>>(spec1, spec2);
                
                mocks.ReplayAll();

                Assert.AreEqual(compositeSpecification.Left, spec1);
                Assert.AreEqual(compositeSpecification.Right, spec2);

                mocks.VerifyAll();
            }
        }
    }
}
