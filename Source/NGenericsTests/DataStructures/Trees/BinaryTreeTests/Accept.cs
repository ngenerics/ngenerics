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
    public class Accept : BinaryTreeTest
    {

        [Test]
        public void Simple()
        {
            var binaryTree = GetTestTree();
            var trackingVisitor = new TrackingVisitor<int>();
            binaryTree.AcceptVisitor(trackingVisitor);

            Assert.AreEqual(trackingVisitor.TrackingList.Count, 6);

            Assert.IsTrue(trackingVisitor.TrackingList.Contains(5));
            Assert.IsTrue(trackingVisitor.TrackingList.Contains(2));
            Assert.IsTrue(trackingVisitor.TrackingList.Contains(3));
            Assert.IsTrue(trackingVisitor.TrackingList.Contains(9));
            Assert.IsTrue(trackingVisitor.TrackingList.Contains(12));
            Assert.IsTrue(trackingVisitor.TrackingList.Contains(13));
        }

        [Test]
        public void Completed()
        {
            var binaryTree = GetTestTree();
            var completedTrackingVisitor = new CompletedTrackingVisitor<int>();
            binaryTree.AcceptVisitor(completedTrackingVisitor);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVisitor()
        {
            var binaryTree = GetTestTree();
            binaryTree.AcceptVisitor(null);
        }

    }
}