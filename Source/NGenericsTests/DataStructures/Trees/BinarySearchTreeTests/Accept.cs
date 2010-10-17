using System;
using System.Collections.Generic;
using NGenerics.DataStructures.Trees;
using NGenerics.Patterns.Visitor;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinarySearchTreeTests
{
    [TestFixture]
    public class Accept : BinarySearchTreeTest
    {

        [Test]
        public void Simple()
        {
            var tree = GetTestTree();
            var visitor = new TrackingVisitor<KeyValuePair<int, string>>();

            tree.AcceptVisitor(visitor);

            Assert.IsTrue(visitor.TrackingList.Contains(new KeyValuePair<int, string>(4, "4")));
            Assert.IsTrue(visitor.TrackingList.Contains(new KeyValuePair<int, string>(6, "6")));
            Assert.IsTrue(visitor.TrackingList.Contains(new KeyValuePair<int, string>(2, "2")));
            Assert.IsTrue(visitor.TrackingList.Contains(new KeyValuePair<int, string>(5, "5")));
            Assert.IsTrue(visitor.TrackingList.Contains(new KeyValuePair<int, string>(19, "19")));
            Assert.IsTrue(visitor.TrackingList.Contains(new KeyValuePair<int, string>(1, "1")));

            Assert.AreEqual(visitor.TrackingList.Count, 6);
        }

        [Test]
        public void CompletedVisitor()
        {
            var tree = GetTestTree();
            var visitor = new CompletedTrackingVisitor<KeyValuePair<int, string>>();

            tree.AcceptVisitor(visitor);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVisitor()
        {
            var tree = new BinarySearchTree<int, string>();
            tree.AcceptVisitor(null);
        }

    }
}