using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.GraphTests
{
    [TestFixture]
    public class IncomingEdgeCount : GraphTest
    {
        [Test]
        public void Directed()
        {
            var graph = new Graph<int>(true);
            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            graph.AddEdge(vertex1, vertex2);

            Assert.AreEqual(vertex1.IncomingEdgeCount, 0);
            Assert.AreEqual(vertex2.IncomingEdgeCount, 1);

            graph.AddEdge(vertex3, vertex2);

            Assert.AreEqual(vertex3.IncomingEdgeCount, 0);
            Assert.AreEqual(vertex2.IncomingEdgeCount, 2);

            graph.AddEdge(vertex1, vertex3);

            Assert.AreEqual(vertex1.IncomingEdgeCount, 0);
            Assert.AreEqual(vertex3.IncomingEdgeCount, 1);
        }

        [Test]
        public void tUndirected()
        {
            var graph = new Graph<int>(false);
            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            graph.AddEdge(vertex1, vertex2);

            Assert.AreEqual(vertex1.IncomingEdgeCount, 0);
            Assert.AreEqual(vertex2.IncomingEdgeCount, 0);

            graph.AddEdge(vertex3, vertex2);

            Assert.AreEqual(vertex3.IncomingEdgeCount, 0);
            Assert.AreEqual(vertex2.IncomingEdgeCount, 0);

            graph.AddEdge(vertex1, vertex3);

            Assert.AreEqual(vertex1.IncomingEdgeCount, 0);
            Assert.AreEqual(vertex3.IncomingEdgeCount, 0);
        }
    }
}