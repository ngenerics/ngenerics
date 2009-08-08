/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System.Collections.Generic;
using NGenerics.DataStructures.Trees;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;

namespace NGenerics.Tests.Patterns.Visitor
{
    [TestFixture]
    public class ValueTrackingVisitorTest
    {
        [TestFixture]
        public class Construction
        {
            [Test]
            public void Simple()
            {
                var visitor = new ValueTrackingVisitor<int, string>();
                Assert.IsFalse(visitor.HasCompleted);
                Assert.AreEqual(visitor.TrackingList.Count, 0);
            }
        }

        [TestFixture]
        public class Visit
        {
            [Test]
            public void Simple()
            {
                var tree = new RedBlackTree<int, string>();

                for (var i = 0; i < 50; i++)
                {
                    tree.Add(i, i.ToString());
                }

                var visitor = new ValueTrackingVisitor<int, string>();
                tree.AcceptVisitor(visitor);

                Assert.IsFalse(visitor.HasCompleted);

                Assert.AreEqual(visitor.TrackingList.Count, 50);

                var list = new List<string>(visitor.TrackingList);

                for (var i = 0; i < 50; i++)
                {
                    Assert.IsTrue(list.Contains(i.ToString()));
                }
            }
        }
    }
}