using System;
using System.Collections.Generic;
using NGenerics.DataStructures.Trees;
using NGenerics.Patterns.Visitor;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.SplayTreeTests
{
    [TestFixture]
    public class Accept : SplayTreeTest
    {

        [Test]
        public void Simple()
        {
            var splayTree = GetTestTree();
            var visitor = new TrackingVisitor<KeyValuePair<int, string>>();

            splayTree.AcceptVisitor(visitor);

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
            var splayTree = GetTestTree();
            var visitor = new CompletedTrackingVisitor<KeyValuePair<int, string>>();

            splayTree.AcceptVisitor(visitor);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVisitor()
        {
            var splayTree = new SplayTree<int, string>();
            splayTree.AcceptVisitor(null);
        }

    }
}