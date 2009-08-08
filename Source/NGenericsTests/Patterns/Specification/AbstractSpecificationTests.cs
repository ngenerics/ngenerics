/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using NGenerics.Patterns.Specification;
using NUnit.Framework;

namespace NGenerics.Tests.Patterns.Specification
{
    [TestFixture]
    public class AbstractSpecificationTests
    {
        [TestFixture]
        public class And
        {
            [Test]
            public void AndSpecification_Should_Be_Returned_On_And_With_Paramters_Saved()
            {
                var spec1 = new PredicateSpecification<int>(x => x > 5);
                var spec2 = new PredicateSpecification<int>(x => x < 10);

                var andSpec = spec1.And(spec2);

                Assert.IsInstanceOfType(typeof (AndSpecification<int>), andSpec);

                Assert.AreEqual(((AndSpecification<int>) andSpec).Left, spec1);
                Assert.AreEqual(((AndSpecification<int>) andSpec).Right, spec2);

                ISpecification<int> interfaceSpec = spec1;
                var interfaceAndSpec = interfaceSpec.And(spec2);

                Assert.IsInstanceOfType(typeof(AndSpecification<int>), interfaceAndSpec);

                Assert.AreEqual(((AndSpecification<int>) interfaceAndSpec).Left, spec1);
                Assert.AreEqual(((AndSpecification<int>) interfaceAndSpec).Right, spec2);
                
            }

            [Test]
            public void AndSpecification_Should_Be_Returned_On_Operator_And_With_Paramters_Saved()
            {
                var spec1 = new PredicateSpecification<int>(x => x > 5);
                var spec2 = new PredicateSpecification<int>(x => x < 10);

                var andSpec = spec1 & spec2;

                Assert.IsInstanceOfType(typeof(AndSpecification<int>), andSpec);

                Assert.AreEqual(((AndSpecification<int>) andSpec).Left, spec1);
                Assert.AreEqual(((AndSpecification<int>) andSpec).Right, spec2);
            }
        }

        [TestFixture]
        public class Or
        {
            [Test]
            public void OrSpecification_Should_Be_Returned_On_Or_With_Paramters_Saved()
            {
                var spec1 = new PredicateSpecification<int>(x => x > 5);
                var spec2 = new PredicateSpecification<int>(x => x < 10);

                var orSpec = spec1.Or(spec2);

                Assert.IsInstanceOfType(typeof(OrSpecification<int>), orSpec);

                Assert.AreEqual(((OrSpecification<int>) orSpec).Left, spec1);
                Assert.AreEqual(((OrSpecification<int>) orSpec).Right, spec2);

                ISpecification<int> interfaceSpec = spec1;
                var interfaceResultSpec = interfaceSpec.Or(spec2);

                Assert.IsInstanceOfType(typeof(OrSpecification<int>), interfaceResultSpec);

                Assert.AreEqual(((OrSpecification<int>) interfaceResultSpec).Left, spec1);
                Assert.AreEqual(((OrSpecification<int>) interfaceResultSpec).Right, spec2);
            }

            [Test]
            public void OrSpecification_Should_Be_Returned_On_Operator_Or_With_Paramters_Saved()
            {
                var spec1 = new PredicateSpecification<int>(x => x > 5);
                var spec2 = new PredicateSpecification<int>(x => x < 10);

                var orSpec = spec1 | spec2;

                Assert.IsInstanceOfType(typeof(OrSpecification<int>), orSpec);

                Assert.AreEqual(((OrSpecification<int>) orSpec).Left, spec1);
                Assert.AreEqual(((OrSpecification<int>) orSpec).Right, spec2);
            }
        }

        [TestFixture]
        public class Not
        {
            [Test]
            public void NotSpecification_Should_Be_Returned_On_Not_With_Paramters_Saved()
            {
                var spec = new PredicateSpecification<int>(x => x > 5);
                var orSpec = spec.Not();

                Assert.IsInstanceOfType(typeof(NotSpecification<int>), orSpec);
                Assert.AreEqual(((NotSpecification<int>) orSpec).Specification, spec);


                ISpecification<int> interfaceSpec = spec.Not();

                Assert.IsInstanceOfType(typeof(NotSpecification<int>), interfaceSpec);
                Assert.AreEqual(((NotSpecification<int>) interfaceSpec).Specification, spec);
            }

            [Test]
            public void NotSpecification_Should_Be_Returned_On_Not_Operator_With_Paramters_Saved()
            {
                var spec = new PredicateSpecification<int>(x => x > 5);
                var orSpec = !spec;

                Assert.IsInstanceOfType(typeof(NotSpecification<int>), orSpec);
                Assert.AreEqual(((NotSpecification<int>) orSpec).Specification, spec);
            }
        }

        [TestFixture]
        public class Xor
        {
            [Test]
            public void XorSpecification_Should_Be_Returned_On_Xor_With_Paramters_Saved()
            {
                var spec1 = new PredicateSpecification<int>(x => x > 5);
                var spec2 = new PredicateSpecification<int>(x => x < 10);

                var xorSpec = spec1.Xor(spec2);

                Assert.AreEqual(((XorSpecification<int>) xorSpec).Left, spec1);
                Assert.AreEqual(((XorSpecification<int>) xorSpec).Right, spec2);

                ISpecification<int> interfaceSpec = spec1;
                var interfaceResultSpec = interfaceSpec.Xor(spec2);

                Assert.IsInstanceOfType(typeof(XorSpecification<int>), interfaceResultSpec);

                Assert.AreEqual(((XorSpecification<int>) interfaceResultSpec).Left, spec1);
                Assert.AreEqual(((XorSpecification<int>) interfaceResultSpec).Right, spec2);
            }

            [Test]
            public void XorSpecification_Should_Be_Returned_On_Operator_Xor_With_Paramters_Saved()
            {
                var spec1 = new PredicateSpecification<int>(x => x > 5);
                var spec2 = new PredicateSpecification<int>(x => x < 10);

                var xorSpec = spec1 ^ (spec2);

                Assert.AreEqual(((XorSpecification<int>) xorSpec).Left, spec1);
                Assert.AreEqual(((XorSpecification<int>) xorSpec).Right, spec2);
            }
        }
    }
}
