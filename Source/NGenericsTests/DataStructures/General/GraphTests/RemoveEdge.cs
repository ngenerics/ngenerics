using System;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.GraphTest
{
    [TestFixture]
    public class RemoveEdge : GraphTests.GraphTest
    {
        [Test]
        public void OtherVertex()
        {
            var graph = new Graph<int>(true);
            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex3, vertex2);
            graph.AddEdge(vertex1, vertex3);

            Assert.AreEqual(graph.Edges.Count, 3);
            Assert.AreEqual(graph.Vertices.Count, 3);

            Assert.IsTrue(graph.RemoveEdge(vertex1, vertex2));
            Assert.AreEqual(graph.Edges.Count, 2);
            Assert.IsFalse(vertex1.HasEmanatingEdgeTo(vertex2));
            Assert.IsTrue(vertex3.HasEmanatingEdgeTo(vertex2));

            Assert.IsTrue(graph.RemoveEdge(vertex3, vertex2));
            Assert.AreEqual(graph.Edges.Count, 1);

            Assert.IsFalse(vertex1.HasEmanatingEdgeTo(vertex2));
            Assert.IsFalse(vertex3.HasEmanatingEdgeTo(vertex2));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullEdge()
        {
            var graph = new Graph<int>(true);
            graph.RemoveEdge(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVertex1()
        {
            var graph = new Graph<int>(true);
            graph.RemoveEdge(new Vertex<int>(3), null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVertex2()
        {
            var graph = new Graph<int>(true);
            graph.RemoveEdge(null, new Vertex<int>(3));
        }

        [Test]
        public void DirectedNotInGraph()
        {
            var graph = new Graph<int>(true);
            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex3, vertex2);
            graph.AddEdge(vertex1, vertex3);

            Assert.IsFalse(graph.RemoveEdge(new Edge<int>(vertex2, vertex3, true)));
        }

        [Test]
        public void UndirectedNotInGraph()
        {
            var graph = new Graph<int>(true);
            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex3, vertex2);
            graph.AddEdge(vertex1, vertex3);

            Assert.IsFalse(graph.RemoveEdge(new Edge<int>(vertex2, vertex3, false)));
        }

        [Test]
        public void DirectedFromVerticesNotInGraph()
        {
            var graph = new Graph<int>(true);
            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex3, vertex2);
            graph.AddEdge(vertex1, vertex3);

            Assert.IsFalse(graph.RemoveEdge(vertex2, vertex3));
        }

        [Test]
        public void UndirectedFromVerticesNotInGraph()
        {
            var graph = new Graph<int>(false);
            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex3, vertex2);

            Assert.IsTrue(graph.RemoveEdge(vertex2, vertex3));
            Assert.IsFalse(graph.RemoveEdge(vertex1, vertex3));
        }

        [Test]
        public void DirectedVertices()
        {
            var graph = new Graph<int>(true);
            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex3, vertex2);
            graph.AddEdge(vertex1, vertex3);

            Assert.AreEqual(graph.Edges.Count, 3);
            Assert.AreEqual(graph.Vertices.Count, 3);

            Assert.IsTrue(graph.RemoveEdge(vertex1, vertex2));

            Assert.AreEqual(graph.Edges.Count, 2);
            Assert.AreEqual(graph.Vertices.Count, 3);

            Assert.IsTrue(graph.RemoveEdge(vertex1, vertex3));

            Assert.AreEqual(graph.Edges.Count, 1);
            Assert.AreEqual(graph.Vertices.Count, 3);
        }

        [Test]
        public void UndirectedVertices()
        {
            var graph = new Graph<int>(false);
            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex3, vertex2);
            graph.AddEdge(vertex1, vertex3);

            Assert.AreEqual(graph.Edges.Count, 3);
            Assert.AreEqual(graph.Vertices.Count, 3);

            Assert.IsTrue(graph.RemoveEdge(vertex1, vertex2));

            Assert.AreEqual(graph.Edges.Count, 2);
            Assert.AreEqual(graph.Vertices.Count, 3);

            Assert.IsTrue(graph.RemoveEdge(vertex3, vertex1));

            Assert.AreEqual(graph.Edges.Count, 1);
            Assert.AreEqual(graph.Vertices.Count, 3);
        }
    }
}