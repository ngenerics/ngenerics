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
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Graphs
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

            Assert.That(trackingVisitor.TrackingList, Is.EqualTo(new[] { 1, 2, 7, 3, 5, 6, 4}));
        }

        [Test]
        public void UndirectedPostVisit()
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
            var postOrderVisitor = new PostOrderVisitor<Vertex<int>>(trackingVisitor);

            graph.DepthFirstTraversal(postOrderVisitor, v1);

            Assert.That(trackingVisitor.TrackingList, Is.EqualTo(new[] { 7, 2, 5, 6, 4, 3, 1}));
        }

        [Test]
        public void DirectedPreVisit()
        {
            var graph = new Graph<int>(true);
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
            var preOrderVisitor = new PreOrderVisitor<Vertex<int>>(trackingVisitor);

            graph.DepthFirstTraversal(preOrderVisitor, v1);

            Assert.That(trackingVisitor.TrackingList, Is.EqualTo(new[] { 1, 2, 7, 3, 6, 4, 5 }));
        }

        [Test]
        public void DirectedPostVisit()
        {
            var graph = new Graph<int>(true);
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
            var postOrderVisitor = new PostOrderVisitor<Vertex<int>>(trackingVisitor);

            graph.DepthFirstTraversal(postOrderVisitor, v1);

            Assert.That(trackingVisitor.TrackingList, Is.EqualTo(new[] { 7, 2, 6, 4, 3, 5, 1 }));
        }

        [Test]
        public void ExceptionNullVertex()
        {
            var graph = new Graph<int>(true);
            Assert.Throws<ArgumentNullException>(() => graph.DepthFirstTraversal(
                new PreOrderVisitor<Vertex<int>>(new TrackingVisitor<Vertex<int>>()), null));
        }

        [Test]
        public void CompletedVisitor()
        {
            var graph = new Graph<int>(true);

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

            graph.DepthFirstTraversal(new PreOrderVisitor<Vertex<int>>(new CompletedTrackingVisitor<Vertex<int>>()), v1);
        }


        [Test]
        public void ExceptionNullVisitor()
        {
            var graph = new Graph<int>(true);
            Assert.Throws<ArgumentNullException>(() => graph.DepthFirstTraversal(null, new Vertex<int>(4)));
        }
    }
}