/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NGenerics.Patterns.Visitor;
using NGenerics.Tests.DataStructures.Trees.GeneralTreeTests;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees
{
    [TestFixture]
    public class GeneralTreeTestCollection : GeneralTreeTest
    {

        [Test]
        public void DepthFirstTraversal_VisitPre()
        {
            var generalTree = GetTestTree();
            var trackingVisitor = new AssertionVisitor<int>();
            var preVisitor = new PreOrderVisitor<int>(trackingVisitor);

            generalTree.DepthFirstTraversal(preVisitor);
            trackingVisitor.AssertTracked(5, 2, 9, 12, 3, 13, 1);
        }

        [Test]
        public void DepthFirstTraversal_TopVisitor()
        {
            var generalTree = GetTestTree();
            var visitor = new ComparableFindingVisitor<int>(13);

            generalTree.BreadthFirstTraversal(visitor);

            Assert.IsTrue(visitor.HasCompleted);
            Assert.IsTrue(visitor.Found);

            visitor = new ComparableFindingVisitor<int>(99);

            generalTree.BreadthFirstTraversal(visitor);

            Assert.IsFalse(visitor.HasCompleted);
            Assert.IsFalse(visitor.Found);
        }

        [Test]
        public void DepthFirstTraversal_ExceptionNullVisitor()
        {
            var generalTree = GetTestTree();
            Assert.Throws<ArgumentNullException>(() => generalTree.DepthFirstTraversal(null));
        }

        [Test]
        public void DepthFirstTraversal_StopVisitor()
        {
            var generalTree = GetTestTree();
            var visitor = new ComparableFindingVisitor<int>(13);
            var preVisitor = new PreOrderVisitor<int>(visitor);

            generalTree.DepthFirstTraversal(preVisitor);

            Assert.IsTrue(((ComparableFindingVisitor<int>)preVisitor.VisitorToUse).Found);
            Assert.IsTrue(((ComparableFindingVisitor<int>)preVisitor.VisitorToUse).HasCompleted);

            visitor = new ComparableFindingVisitor<int>(99);
            preVisitor = new PreOrderVisitor<int>(visitor);

            generalTree.DepthFirstTraversal(preVisitor);
            Assert.IsFalse(((ComparableFindingVisitor<int>)preVisitor.VisitorToUse).Found);
            Assert.IsFalse(((ComparableFindingVisitor<int>)preVisitor.VisitorToUse).HasCompleted);
        }

        [Test]
        public void DepthFirstTraversal_Stops_Once_Visitor_Completes()
        {
            var generalTree = GetTestTree();
            var visitor = new StoppingVisitor<int>();
            var preVisitor = new PreOrderVisitor<int>(visitor);

            generalTree.DepthFirstTraversal(preVisitor);
        }

        [Test]
        public void DepthFirstTraversal_VisitPost()
        {
            var generalTree = GetTestTree();
            var trackingVisitor = new AssertionVisitor<int>();
            var postVisitor = new PostOrderVisitor<int>(trackingVisitor);

            generalTree.DepthFirstTraversal(postVisitor);
            trackingVisitor.AssertTracked(9, 12, 2, 13, 3, 1, 5);
        }
    }
}
