/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/


using NGenerics.Patterns.Specification;
using NUnit.Framework;

namespace NGenerics.Examples.Patterns.Specification {
    
    [TestFixture]
    public class NotSpecificationExamples {

        #region IsSatisfiedBy

        public enum CustomerType {
            Bronze,
            Silver,
            Gold
        }

        public class Customer {
            public string Name { get; set; }
            public CustomerType Type { get; set; }
        }

        [Test]
        public void IsSatisfiedByExample() {
            var goldCustomer = new Customer { Name = "Customer1", Type = CustomerType.Gold };
            var silverCustomer = new Customer { Name = "Customer2", Type = CustomerType.Silver };

            var notGoldSpecification = new PredicateSpecification<Customer>(x => x.Type == CustomerType.Gold).Not();

            // Gold customer
            Assert.IsFalse(notGoldSpecification.IsSatisfiedBy(goldCustomer));

            // Silver customer
            Assert.IsTrue(notGoldSpecification.IsSatisfiedBy(silverCustomer));
        }

        #endregion
    }
}
