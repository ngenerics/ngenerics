/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.Patterns.Specification;
using NUnit.Framework;

namespace NGenerics.Tests.Patterns.Specification.NotSpecification
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
}