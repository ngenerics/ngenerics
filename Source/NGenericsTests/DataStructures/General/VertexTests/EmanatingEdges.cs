using System;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.VertexTests
{
    [TestFixture]
    public class EmanatingEdges:VertexTest
    {
        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void ExceptionReadOnly()
        {
            var vertex1 = new Vertex<int>(5);
            var vertex2 = new Vertex<int>(5);
            vertex1.EmanatingEdges.Add(new Edge<int>(vertex1, vertex2, false));
        }

        [Test]
        public void Undirected()
        {
            var vertex1 = new Vertex<int>(3);
            var vertex2 = new Vertex<int>(5);
            var vertex3 = new Vertex<int>(8);

            var graph = new Graph<int>(false);
            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex3, vertex1);

            var edgeList = vertex1.EmanatingEdges;

            Assert.AreEqual(edgeList.Count, 2);

            AssertContainsEdges(edgeList, true,
                                vertex1.GetEmanatingEdgeTo(vertex2),
                                vertex1.GetEmanatingEdgeTo(vertex3),
                                vertex3.GetEmanatingEdgeTo(vertex1));
        }

        [Test]
        public void UndirectedEnumerator()
        {
            var vertex1 = new Vertex<int>(3);
            var vertex2 = new Vertex<int>(5);
            var vertex3 = new Vertex<int>(8);

            var graph = new Graph<int>(false);
            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex3, vertex1);

            var edgeList = vertex1.EmanatingEdges;

            foreach (var edge in edgeList)
            {
                Console.WriteLine(edge.Weight);
            }

            Assert.AreEqual(edgeList.Count, 2);

            AssertContainsEdges(edgeList, true,
                                vertex1.GetEmanatingEdgeTo(vertex2),
                                vertex1.GetEmanatingEdgeTo(vertex3),
                                vertex3.GetEmanatingEdgeTo(vertex1));
        }

        [Test]
        public void Directed()
        {
            var vertex1 = new Vertex<int>(3);
            var vertex2 = new Vertex<int>(5);
            var vertex3 = new Vertex<int>(8);

            var graph = new Graph<int>(true);
            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex3, vertex1);

            var edgeList = vertex3.EmanatingEdges;

            Assert.AreEqual(edgeList.Count, 1);
            AssertContainsEdges(edgeList, true,
                                vertex3.GetEmanatingEdgeTo(vertex1)
                );

            edgeList = vertex1.EmanatingEdges;

            Assert.AreEqual(edgeList.Count, 1);
            AssertContainsEdges(edgeList, true,
                                vertex1.GetEmanatingEdgeTo(vertex2)
                );
        }
    }
}