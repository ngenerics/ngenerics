/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.GeneralTreeTests
{
    [TestFixture]
    public class DepthFirstTraversal : GeneralTreeTest
    {

        [Test]
        public void VisitPre()
        {
            var generalTree = GetTestTree();
            var trackingVisitor = new TrackingVisitor<int>();
            var preVisitor = new PreOrderVisitor<int>(trackingVisitor);

            generalTree.DepthFirstTraversal(preVisitor);

            var tracks = trackingVisitor.TrackingList;

            Assert.AreEqual(tracks[0], 5);
            Assert.AreEqual(tracks[1], 2);
            Assert.AreEqual(tracks[2], 9);
            Assert.AreEqual(tracks[3], 12);
            Assert.AreEqual(tracks[4], 3);
            Assert.AreEqual(tracks[5], 13);
            Assert.AreEqual(tracks[6], 1);
        }

        [Test]
        public void TopVisitor()
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
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVisitor()
        {
            var generalTree = GetTestTree();
            generalTree.DepthFirstTraversal(null);
        }

        [Test]
        public void StopVisitor()
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
        public void VisitPost()
        {
            var generalTree = GetTestTree();
            var trackingVisitor = new TrackingVisitor<int>();
            var postVisitor = new PostOrderVisitor<int>(trackingVisitor);

            generalTree.DepthFirstTraversal(postVisitor);

            var tracks = trackingVisitor.TrackingList;

            Assert.AreEqual(tracks[0], 9);
            Assert.AreEqual(tracks[1], 12);
            Assert.AreEqual(tracks[2], 2);
            Assert.AreEqual(tracks[3], 13);
            Assert.AreEqual(tracks[4], 3);
            Assert.AreEqual(tracks[5], 1);
            Assert.AreEqual(tracks[6], 5);
        }

    }
}