/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/


using NGenerics.Patterns.Specification;
using NUnit.Framework;

namespace NGenerics.Examples.Patterns.Specification
{
    [TestFixture]
    public class AndSpecificationExamples
    {
        #region IsSatisfiedBy

        public class Person
        {
            public string Name { get; set; }
            public string Surname { get; set; }
        }

        [Test]
        public void IsSatisfiedByExample()
        {
            // Our model to test on
            var p = new Person {Name = "Hilton", Surname = "Goosen"};

            // Build up two specifications to AND together
            var nameSpecification = new PredicateSpecification<Person>(x => x.Name == "Hilton");
            var surnameSpecification = new PredicateSpecification<Person>(x => x.Surname == "Goosen");

            // Create a new And Specification
            var specification = new AndSpecification<Person>(nameSpecification, surnameSpecification);
            
            Assert.IsTrue(specification.IsSatisfiedBy(p));

            // Set the surname to something else
            surnameSpecification = new PredicateSpecification<Person>(x => x.Surname == "Hanekom");
            specification = new AndSpecification<Person>(nameSpecification, surnameSpecification);

            // Surname specification is not satisfied by this person
            Assert.IsFalse(specification.IsSatisfiedBy(p));
        }

        #endregion
    }
}
