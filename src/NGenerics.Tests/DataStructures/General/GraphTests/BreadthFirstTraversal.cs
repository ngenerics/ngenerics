/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NGenerics.DataStructures.General;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.GraphTests
{
    [TestFixture]
    public class BreadthFirstTraversal : GraphTest
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVertex()
        {
            var graph = new Graph<int>(true);
            graph.BreadthFirstTraversal(new TrackingVisitor<Vertex<int>>(), null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVisitor()
        {
            var graph = new Graph<int>(true);
            graph.BreadthFirstTraversal(null, new Vertex<int>(4));
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

            Assert.AreEqual(trackingVisitor.TrackingList[0].Data, 1);
            Assert.AreEqual(trackingVisitor.TrackingList[1].Data, 2);
            Assert.AreEqual(trackingVisitor.TrackingList[2].Data, 3);
            Assert.AreEqual(trackingVisitor.TrackingList[3].Data, 5);
            Assert.AreEqual(trackingVisitor.TrackingList[4].Data, 7);
            Assert.AreEqual(trackingVisitor.TrackingList[5].Data, 6);
            Assert.AreEqual(trackingVisitor.TrackingList[6].Data, 4);
        }

        [Test]
        public void Undirected()
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

            graph.BreadthFirstTraversal(trackingVisitor, vertex1);

            Assert.AreEqual(trackingVisitor.TrackingList.Count, graph.Vertices.Count);

            Assert.AreEqual(trackingVisitor.TrackingList[0].Data, 1);
            Assert.AreEqual(trackingVisitor.TrackingList[1].Data, 2);
            Assert.AreEqual(trackingVisitor.TrackingList[2].Data, 3);
            Assert.AreEqual(trackingVisitor.TrackingList[3].Data, 5);
            Assert.AreEqual(trackingVisitor.TrackingList[4].Data, 7);
            Assert.AreEqual(trackingVisitor.TrackingList[5].Data, 6);
            Assert.AreEqual(trackingVisitor.TrackingList[6].Data, 4);
        }

    }
}