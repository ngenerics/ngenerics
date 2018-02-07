/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NGenerics.DataStructures.Graphs;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Graphs
{
    [TestFixture]
    public class BreadthFirstTraversal : GraphTest
    {
        [Test]
        public void ExceptionNullVertex()
        {
            var graph = new Graph<int>(true);
            Assert.Throws<ArgumentNullException>(() => graph.BreadthFirstTraversal(new TrackingVisitor<Vertex<int>>(), null));
        }

        [Test]
        public void ExceptionNullVisitor()
        {
            var graph = new Graph<int>(true);
            Assert.Throws<ArgumentNullException>(() => graph.BreadthFirstTraversal(null, new Vertex<int>(4)));
        }

        [Test]
        public void Directed()
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

            graph.BreadthFirstTraversal(trackingVisitor, vertex1);

            Assert.AreEqual(trackingVisitor.TrackingList.Count, graph.Vertices.Count);

            Assert.AreEqual(1, trackingVisitor.TrackingList[0].Data);
            Assert.AreEqual(2, trackingVisitor.TrackingList[1].Data);
            Assert.AreEqual(3, trackingVisitor.TrackingList[2].Data);
            Assert.AreEqual(5, trackingVisitor.TrackingList[3].Data);
            Assert.AreEqual(7, trackingVisitor.TrackingList[4].Data);
            Assert.AreEqual(6, trackingVisitor.TrackingList[5].Data);
            Assert.AreEqual(4, trackingVisitor.TrackingList[6].Data);
        }

        [Test]
        public void Undirected()
        {
            var graph = new Graph<int>(false);
            var v1 = new Vertex<int>(1);
            var v2 = new Vertex<int>(2);
            var v3 = new Vertex<int>(3);
            var v4 = new Vertex<int>(4);
            var v5 = new Vertex<int>(5);
            var v6 = new Vertex<int>(6);
            var v7 = new Vertex<int>(7);

            graph.AddVertex(v1, v2, v3, v4, v5, v6, v7);

            graph.AddEdge(v1, v2);
            graph.AddEdge(v1, v3);
            graph.AddEdge(v1, v5);
            graph.AddEdge(v5, v3);

            graph.AddEdge(v3, v6);
            graph.AddEdge(v3, v4);
            graph.AddEdge(v2, v7);

            var trackingVisitor = new TrackingVisitor<Vertex<int>>();

            graph.BreadthFirstTraversal(trackingVisitor, v1);

            Assert.AreEqual(trackingVisitor.TrackingList.Count, graph.Vertices.Count);

            Assert.AreEqual(1, trackingVisitor.TrackingList[0].Data);
            Assert.AreEqual(2, trackingVisitor.TrackingList[1].Data);
            Assert.AreEqual(3, trackingVisitor.TrackingList[2].Data);
            Assert.AreEqual(5, trackingVisitor.TrackingList[3].Data);
            Assert.AreEqual(7, trackingVisitor.TrackingList[4].Data);
            Assert.AreEqual(6, trackingVisitor.TrackingList[5].Data);
            Assert.AreEqual(4, trackingVisitor.TrackingList[6].Data);
        }
    }
}