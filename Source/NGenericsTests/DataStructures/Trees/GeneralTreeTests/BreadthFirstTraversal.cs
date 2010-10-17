using NGenerics.Patterns.Visitor;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.GeneralTreeTests
{
    [TestFixture]
    public class BreadthFirstTraversal : GeneralTreeTest
    {
        [Test]
        public void Simple()
        {
            var generalTree = GetTestTree();
            var trackingVisitor = new TrackingVisitor<int>();

            generalTree.BreadthFirstTraversal(trackingVisitor);

            var tracks = trackingVisitor.TrackingList;

            Assert.AreEqual(tracks[0], 5);
            Assert.AreEqual(tracks[1], 2);
            Assert.AreEqual(tracks[2], 3);
            Assert.AreEqual(tracks[3], 1);
            Assert.AreEqual(tracks[4], 9);
            Assert.AreEqual(tracks[5], 12);
            Assert.AreEqual(tracks[6], 13);
        }

    }
}