/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/

using NGenerics.Patterns.Specification;
using NUnit.Framework;

namespace ExampleLibraryCSharp.Patterns.Specification
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
