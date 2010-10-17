using System;
using System.Collections.Generic;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.RedBlackTreeTests
{
    [TestFixture]
    public class Accept : RedBlackTreeTest
    {

        [Test]
        public void Simple()
        {
            var redBlackTree = GetTestTree();

            var visitor = new TrackingVisitor<KeyValuePair<int, string>>();

            redBlackTree.AcceptVisitor(visitor);

            Assert.AreEqual(visitor.TrackingList.Count, 100);

            for (var i = 0; i < 100; i++)
            {
                Assert.IsTrue(visitor.TrackingList.Contains(new KeyValuePair<int, string>(i, i.ToString())));
            }
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVisitor()
        {
            var redBlackTree = GetTestTree();
            redBlackTree.AcceptVisitor(null);
        }

    }
}