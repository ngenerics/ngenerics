/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/

using System;
using NGenerics.Patterns.Specification;
using NUnit.Framework;

namespace NGenerics.Tests.Patterns.Specification
{
    [TestFixture]
    public class PredicateSpecificationTests
    {
        [TestFixture]
        public class IsSatisfiedBy
        {
            [Test]
            public void Specification_Should_Save_And_Use_Predicate_Supplied_Correctly()
            {
                Predicate<int> predicate = x => x == 5;
                var specification = new PredicateSpecification<int>(predicate);
                Assert.AreEqual(specification.Predicate, predicate);

                Assert.IsTrue(specification.IsSatisfiedBy(5));

                Assert.IsFalse(specification.IsSatisfiedBy(3));
                Assert.IsFalse(specification.IsSatisfiedBy(6));
            }
        }
   }
}
