using System.Collections.Generic;
using NGenerics.DataStructures.Trees;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.SplayTreeTests
{
    [TestFixture]
    public class DepthFirstTraversal : SplayTreeTest
    {

        [Test]
        public void Simple()
        {
            var splayTree = new SplayTree<string, int>
                                {
                                    new KeyValuePair<string, int>("horse", 4),
                                    new KeyValuePair<string, int>("cat", 1),
                                    new KeyValuePair<string, int>("dog", 2),
                                    new KeyValuePair<string, int>("canary", 3)
                                };

            var visitor = new TrackingVisitor<KeyValuePair<string, int>>();

            var inOrderVisitor =
                new InOrderVisitor<KeyValuePair<string, int>>(visitor);

            splayTree.DepthFirstTraversal(inOrderVisitor);

            Assert.AreEqual(visitor.TrackingList[0].Key, "canary");
            Assert.AreEqual(visitor.TrackingList[1].Key, "cat");
            Assert.AreEqual(visitor.TrackingList[2].Key, "dog");
            Assert.AreEqual(visitor.TrackingList[3].Key, "horse");
        }

    }
}