using System;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.GraphTests
{
    [TestFixture]
    public class IsStronglyConnected : GraphTest
    {
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionEmptyDirected()
        {
            var graph = new Graph<int>(true);
            graph.IsStronglyConnected();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionEmptyUndirected()
        {
            var graph = new Graph<int>(false);
            graph.IsStronglyConnected();
        }

        [Test]
        public void Undirected()
        {
            var graph = new Graph<int>(false);
            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);
            var vertex4 = new Vertex<int>(4);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);
            graph.AddVertex(vertex4);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex3, vertex2);
            graph.AddEdge(vertex1, vertex3);

            Assert.IsFalse(graph.IsStronglyConnected());

            graph.AddEdge(vertex2, vertex4);

            Assert.IsTrue(graph.IsStronglyConnected());

            graph.RemoveEdge(vertex2, vertex3);

            Assert.IsTrue(graph.IsStronglyConnected());

            graph.RemoveEdge(vertex1, vertex3);

            Assert.IsFalse(graph.IsStronglyConnected());
        }
    }
}