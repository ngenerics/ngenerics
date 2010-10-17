/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using NGenerics.DataStructures.General;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ListTests
{
    [TestFixture]
    public class Accept
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVisitor()
        {
            var visitableList = new ListBase<int>(); 
            visitableList.AcceptVisitor(null);
        }

        [Test]
        public void Simple()
        {
            var visitableList = ListTest.GetTestList();
            var visitor = new SumVisitor();

            visitableList.AcceptVisitor(visitor);

            Assert.AreEqual(visitor.Sum, 0 + 3 + 6 + 9 + 12);
        }

        [Test]
        public void StoppingVisitor()
        {
            var visitableList = ListTest.GetTestList();

            var visitor = new ComparableFindingVisitor<int>(6);
            visitableList.AcceptVisitor(visitor);

            Assert.IsTrue(visitor.Found);

            visitor = new ComparableFindingVisitor<int>(99);
            visitableList.AcceptVisitor(visitor);
            Assert.IsFalse(visitor.Found);
        }
    }
}