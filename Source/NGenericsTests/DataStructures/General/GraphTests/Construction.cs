using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.GraphTests
{
    [TestFixture]
    public class Construction : GraphTest
    {
        [Test]
        public void Simple()
        {
            var graph = new Graph<int>(false);

            Assert.AreEqual(graph.Vertices.Count, 0);
            Assert.AreEqual(graph.Vertices.Count, 0);
            Assert.AreEqual(graph.Edges.Count, 0);
            Assert.IsFalse(graph.IsDirected);

            graph = new Graph<int>(true);

            Assert.AreEqual(graph.Vertices.Count, 0);
            Assert.AreEqual(graph.Vertices.Count, 0);
            Assert.AreEqual(graph.Edges.Count, 0);
            Assert.IsTrue(graph.IsDirected);
        }
    }
}