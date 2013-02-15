/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using NGenerics.Patterns.Specification;
using NUnit.Framework;

namespace NGenerics.Tests.Patterns.Specification.OrSpecification
{
    [TestFixture]
    public class Construction
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Should_Throw_If_Left_Specification_Is_Null()
        {
            new OrSpecification<int>(null, new PredicateSpecification<int>(x => x == 5));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Should_Throw_If_Right_Specification_Is_Null()
        {
            new OrSpecification<int>(new PredicateSpecification<int>(x => x == 5), null);
        }

        [Test]
        public void Should_Be_Fine_If_None_Are_Null()
        {
            var p1 = new PredicateSpecification<int>(x => x == 5);
            var p2 = new PredicateSpecification<int>(x => x >= 5);

            var spec = new OrSpecification<int>(p1, p2);

            Assert.AreEqual(spec.Left, p1);
            Assert.AreEqual(spec.Right, p2);
        }
    }
}