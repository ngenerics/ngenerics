/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NGenerics.Patterns.Visitor;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinaryTreeTests
{
    [TestFixture]
    public class BreadthFirstTraversal : BinaryTreeTest
    {

        [Test]
        public void Simple()
        {
            var binaryTree = GetTestTree();
            var trackingVisitor = new TrackingVisitor<int>();

            binaryTree.BreadthFirstTraversal(trackingVisitor);

            var tracks = trackingVisitor.TrackingList;

            Assert.AreEqual(tracks[0], 5);
            Assert.AreEqual(tracks[1], 2);
            Assert.AreEqual(tracks[2], 3);
            Assert.AreEqual(tracks[3], 9);
            Assert.AreEqual(tracks[4], 12);
            Assert.AreEqual(tracks[5], 13);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVisitor()
        {
            var binaryTree = GetTestTree();
            binaryTree.BreadthFirstTraversal(null);
        }

        [Test]
        public void CompletedVisitor()
        {
            var binaryTree = GetTestTree();
            binaryTree.BreadthFirstTraversal(new CompletedTrackingVisitor<int>());
        }

        [Test]
        public void StopVisitor()
        {
            var binaryTree = GetTestTree();
            var visitor = new ComparableFindingVisitor<int>(13);

            binaryTree.BreadthFirstTraversal(visitor);

            Assert.IsTrue(visitor.HasCompleted);
            Assert.IsTrue(visitor.Found);

            visitor = new ComparableFindingVisitor<int>(99);

            binaryTree.BreadthFirstTraversal(visitor);

            Assert.IsFalse(visitor.HasCompleted);
            Assert.IsFalse(visitor.Found);
        }
    }
}