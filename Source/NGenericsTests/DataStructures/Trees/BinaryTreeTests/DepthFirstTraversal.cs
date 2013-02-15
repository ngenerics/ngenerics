/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using NGenerics.Patterns.Visitor;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinaryTreeTests
{
    [TestFixture]
    public class DepthFirstTraversal : BinaryTreeTest
    {

        [Test]
        public void Pre()
        {
            var binaryTree = GetTestTree();
            var trackingVisitor = new TrackingVisitor<int>();
            var preVisitor = new PreOrderVisitor<int>(trackingVisitor);

            binaryTree.DepthFirstTraversal(preVisitor);

            var tracks = trackingVisitor.TrackingList;

            Assert.AreEqual(tracks[0], 5);
            Assert.AreEqual(tracks[1], 2);
            Assert.AreEqual(tracks[2], 9);
            Assert.AreEqual(tracks[3], 12);
            Assert.AreEqual(tracks[4], 3);
            Assert.AreEqual(tracks[5], 13);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVisitor()
        {
            var binaryTree = GetTestTree();
            binaryTree.DepthFirstTraversal(null);
        }

        [Test]
        public void VisitIn()
        {
            var binaryTree = GetTestTree();
            var trackingVisitor = new TrackingVisitor<int>();
            var inVisitor = new InOrderVisitor<int>(trackingVisitor);

            binaryTree.DepthFirstTraversal(inVisitor);

            var tracks = trackingVisitor.TrackingList;

            Assert.AreEqual(tracks[0], 9);
            Assert.AreEqual(tracks[1], 2);
            Assert.AreEqual(tracks[2], 12);
            Assert.AreEqual(tracks[3], 5);
            Assert.AreEqual(tracks[4], 13);
            Assert.AreEqual(tracks[5], 3);
        }

        [Test]
        public void StopVisitor()
        {
            var binaryTree = GetTestTree();
            var visitor = new CompletedTrackingVisitor<int>();
            var preVisitor = new PreOrderVisitor<int>(visitor);

            binaryTree.DepthFirstTraversal(preVisitor);
        }

        [Test]
        public void Post()
        {
            var binaryTree = GetTestTree();
            var trackingVisitor = new TrackingVisitor<int>();
            var postVisitor = new PostOrderVisitor<int>(trackingVisitor);

            binaryTree.DepthFirstTraversal(postVisitor);

            var tracks = trackingVisitor.TrackingList;

            Assert.AreEqual(tracks[0], 9);
            Assert.AreEqual(tracks[1], 12);
            Assert.AreEqual(tracks[2], 2);
            Assert.AreEqual(tracks[3], 13);
            Assert.AreEqual(tracks[4], 3);
            Assert.AreEqual(tracks[5], 5);
        }

    }
}