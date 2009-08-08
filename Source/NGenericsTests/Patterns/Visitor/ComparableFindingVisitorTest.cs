/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System.Collections.Generic;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;

namespace NGenerics.Tests.Patterns.Visitor
{
    [TestFixture]
    public class ComparableFindingVisitorTest
    {
        [TestFixture]
        public class Construction
        {
            [Test]
            public void Simple()
            {
                var visitor = new ComparableFindingVisitor<int>(50);
                Assert.AreEqual(visitor.SearchValue, 50);
                Assert.IsFalse(visitor.HasCompleted);
                Assert.IsFalse(visitor.Found);
            }
        }

        [TestFixture]
        public class Visit
        {
            [Test]
            public void Find()
            {
                var list = new List<int>();
                list.AddRange(new[] { 3, 4, 76, 34, 50, 23, 45 });

                var visitor = new ComparableFindingVisitor<int>(50);

                list.AcceptVisitor(visitor);
                Assert.IsTrue(visitor.Found);
                Assert.IsTrue(visitor.HasCompleted);

                visitor = new ComparableFindingVisitor<int>(50);
                list.Clear();
                list.AddRange(new[] { 50, 3, 4, 76, 34, 23, 45 });

                list.AcceptVisitor(visitor);
                Assert.IsTrue(visitor.Found);
                Assert.IsTrue(visitor.HasCompleted);

                visitor = new ComparableFindingVisitor<int>(50);
                list.Clear();
                list.AddRange(new[] { 3, 4, 76, 34, 23, 45, 50 });

                list.AcceptVisitor(visitor);
                Assert.IsTrue(visitor.Found);
                Assert.IsTrue(visitor.HasCompleted);

                visitor = new ComparableFindingVisitor<int>(50);
                list.Clear();
                list.AddRange(new[] { 3, 4, 76, 34, 23, 45 });

                list.AcceptVisitor(visitor);
                Assert.IsFalse(visitor.Found);
                Assert.IsFalse(visitor.HasCompleted);
            }
        }
    }
}