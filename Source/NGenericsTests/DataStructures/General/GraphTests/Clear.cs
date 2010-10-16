using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.GraphTests
{
    [TestFixture]
    public class Clear : GraphTest
    {
        [Test]
        public void Simple()
        {
            var graph = GetTestUndirectedGraph();
            graph.Clear();

            Assert.AreEqual(graph.Vertices.Count, 0);
            Assert.AreEqual(graph.Vertices.Count, 0);
            Assert.AreEqual(graph.Edges.Count, 0);
        }
    }
}