using System;
using NGenerics.DataStructures.General;
using NGenerics.Patterns.Visitor;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.GraphTests
{
    [TestFixture]
    public class DepthFirstTraversal : GraphTest
    {
        [Test]
        public void UndirectedPreVisit()
        {
            var graph = new Graph<int>(false);
            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);
            var vertex4 = new Vertex<int>(4);
            var vertex5 = new Vertex<int>(5);
            var vertex6 = new Vertex<int>(6);
            var vertex7 = new Vertex<int>(7);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);
            graph.AddVertex(vertex4);
            graph.AddVertex(vertex5);
            graph.AddVertex(vertex6);
            graph.AddVertex(vertex7);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex1, vertex3);
            graph.AddEdge(vertex1, vertex5);
            graph.AddEdge(vertex5, vertex3);

            graph.AddEdge(vertex3, vertex6);
            graph.AddEdge(vertex3, vertex4);
            graph.AddEdge(vertex2, vertex7);

            var trackingVisitor = new TrackingVisitor<Vertex<int>>();
            var preOrderVisitor = new PreOrderVisitor<Vertex<int>>(trackingVisitor);

            graph.DepthFirstTraversal(preOrderVisitor, vertex1);

            Assert.AreEqual(trackingVisitor.TrackingList.Count, graph.Vertices.Count);

            Assert.AreEqual(trackingVisitor.TrackingList[0].Data, 1);
            Assert.AreEqual(trackingVisitor.TrackingList[1].Data, 2);
            Assert.AreEqual(trackingVisitor.TrackingList[2].Data, 7);
            Assert.AreEqual(trackingVisitor.TrackingList[3].Data, 3);
            Assert.AreEqual(trackingVisitor.TrackingList[4].Data, 5);
            Assert.AreEqual(trackingVisitor.TrackingList[5].Data, 6);
            Assert.AreEqual(trackingVisitor.TrackingList[6].Data, 4);
        }

        [Test]
        public void UndirectedPostVisit()
        {
            var graph = new Graph<int>(false);
            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);
            var vertex4 = new Vertex<int>(4);
            var vertex5 = new Vertex<int>(5);
            var vertex6 = new Vertex<int>(6);
            var vertex7 = new Vertex<int>(7);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);
            graph.AddVertex(vertex4);
            graph.AddVertex(vertex5);
            graph.AddVertex(vertex6);
            graph.AddVertex(vertex7);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex1, vertex3);
            graph.AddEdge(vertex1, vertex5);
            graph.AddEdge(vertex5, vertex3);

            graph.AddEdge(vertex3, vertex6);
            graph.AddEdge(vertex3, vertex4);
            graph.AddEdge(vertex2, vertex7);

            var trackingVisitor = new TrackingVisitor<Vertex<int>>();
            var postOrderVisitor = new PostOrderVisitor<Vertex<int>>(trackingVisitor);

            graph.DepthFirstTraversal(postOrderVisitor, vertex1);

            Assert.AreEqual(trackingVisitor.TrackingList.Count, graph.Vertices.Count);

            Assert.AreEqual(trackingVisitor.TrackingList[0].Data, 7);
            Assert.AreEqual(trackingVisitor.TrackingList[1].Data, 2);
            Assert.AreEqual(trackingVisitor.TrackingList[2].Data, 5);
            Assert.AreEqual(trackingVisitor.TrackingList[3].Data, 6);
            Assert.AreEqual(trackingVisitor.TrackingList[4].Data, 4);
            Assert.AreEqual(trackingVisitor.TrackingList[5].Data, 3);
            Assert.AreEqual(trackingVisitor.TrackingList[6].Data, 1);
        }

        [Test]
        public void DirectedPreVisit()
        {
            var graph = new Graph<int>(true);
            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);
            var vertex4 = new Vertex<int>(4);
            var vertex5 = new Vertex<int>(5);
            var vertex6 = new Vertex<int>(6);
            var vertex7 = new Vertex<int>(7);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);
            graph.AddVertex(vertex4);
            graph.AddVertex(vertex5);
            graph.AddVertex(vertex6);
            graph.AddVertex(vertex7);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex1, vertex3);
            graph.AddEdge(vertex1, vertex5);
            graph.AddEdge(vertex5, vertex3);

            graph.AddEdge(vertex3, vertex6);
            graph.AddEdge(vertex3, vertex4);
            graph.AddEdge(vertex2, vertex7);

            var trackingVisitor = new TrackingVisitor<Vertex<int>>();
            var preOrderVisitor = new PreOrderVisitor<Vertex<int>>(trackingVisitor);

            graph.DepthFirstTraversal(preOrderVisitor, vertex1);

            Assert.AreEqual(trackingVisitor.TrackingList.Count, graph.Vertices.Count);

            Assert.AreEqual(trackingVisitor.TrackingList[0].Data, 1);
            Assert.AreEqual(trackingVisitor.TrackingList[1].Data, 2);
            Assert.AreEqual(trackingVisitor.TrackingList[2].Data, 7);
            Assert.AreEqual(trackingVisitor.TrackingList[3].Data, 3);
            Assert.AreEqual(trackingVisitor.TrackingList[4].Data, 6);
            Assert.AreEqual(trackingVisitor.TrackingList[5].Data, 4);
            Assert.AreEqual(trackingVisitor.TrackingList[6].Data, 5);
        }

        [Test]
        public void DirectedPostVisit()
        {
            var graph = new Graph<int>(true);
            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);
            var vertex4 = new Vertex<int>(4);
            var vertex5 = new Vertex<int>(5);
            var vertex6 = new Vertex<int>(6);
            var vertex7 = new Vertex<int>(7);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);
            graph.AddVertex(vertex4);
            graph.AddVertex(vertex5);
            graph.AddVertex(vertex6);
            graph.AddVertex(vertex7);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex1, vertex3);
            graph.AddEdge(vertex1, vertex5);
            graph.AddEdge(vertex5, vertex3);

            graph.AddEdge(vertex3, vertex6);
            graph.AddEdge(vertex3, vertex4);
            graph.AddEdge(vertex2, vertex7);

            var trackingVisitor = new TrackingVisitor<Vertex<int>>();
            var postOrderVisitor = new PostOrderVisitor<Vertex<int>>(trackingVisitor);

            graph.DepthFirstTraversal(postOrderVisitor, vertex1);

            Assert.AreEqual(trackingVisitor.TrackingList.Count, graph.Vertices.Count);

            Assert.AreEqual(trackingVisitor.TrackingList[0].Data, 7);
            Assert.AreEqual(trackingVisitor.TrackingList[1].Data, 2);
            Assert.AreEqual(trackingVisitor.TrackingList[2].Data, 6);
            Assert.AreEqual(trackingVisitor.TrackingList[3].Data, 4);
            Assert.AreEqual(trackingVisitor.TrackingList[4].Data, 3);
            Assert.AreEqual(trackingVisitor.TrackingList[5].Data, 5);
            Assert.AreEqual(trackingVisitor.TrackingList[6].Data, 1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVertex()
        {
            var graph = new Graph<int>(true);
            graph.DepthFirstTraversal(new PreOrderVisitor<Vertex<int>>(new TrackingVisitor<Vertex<int>>()), null);
        }

        [Test]
        public void CompletedVisitor()
        {
            var graph = new Graph<int>(true);

            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);
            var vertex4 = new Vertex<int>(4);
            var vertex5 = new Vertex<int>(5);
            var vertex6 = new Vertex<int>(6);
            var vertex7 = new Vertex<int>(7);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);
            graph.AddVertex(vertex4);
            graph.AddVertex(vertex5);
            graph.AddVertex(vertex6);
            graph.AddVertex(vertex7);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex1, vertex3);
            graph.AddEdge(vertex1, vertex5);
            graph.AddEdge(vertex5, vertex3);

            graph.AddEdge(vertex3, vertex6);
            graph.AddEdge(vertex3, vertex4);
            graph.AddEdge(vertex2, vertex7);

            graph.DepthFirstTraversal(new PreOrderVisitor<Vertex<int>>(new CompletedTrackingVisitor<Vertex<int>>()), vertex1);
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVisitor()
        {
            var graph = new Graph<int>(true);
            graph.DepthFirstTraversal(null, new Vertex<int>(4));
        }
    }
}