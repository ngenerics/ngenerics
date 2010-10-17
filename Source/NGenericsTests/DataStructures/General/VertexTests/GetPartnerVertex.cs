using System;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.VertexTests
{
    [TestFixture]
    public class GetPartnerVertex:VertexTest
    {
        [Test]
        public void Simple()
        {
            var graph = new Graph<int>(false);
            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            var v1v2 = graph.AddEdge(vertex1, vertex2);
            var v3v2 = graph.AddEdge(vertex3, vertex2);

            Assert.AreEqual(v1v2.GetPartnerVertex(vertex1), vertex2);
            Assert.AreEqual(v1v2.GetPartnerVertex(vertex2), vertex1);

            Assert.AreEqual(v3v2.GetPartnerVertex(vertex2), vertex3);
            Assert.AreEqual(v3v2.GetPartnerVertex(vertex3), vertex2);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionVertexNotPartOfEdge()
        {
            var graph = new Graph<int>(false);
            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            var edge = graph.AddEdge(vertex1, vertex2);

            edge.GetPartnerVertex(vertex3);
        }
    }
}