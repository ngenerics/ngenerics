/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NGenerics.DataStructures.Graphs;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Graphs
{
    [TestFixture]
    public class RemoveVertex : GraphTest
    {
        [Test]
        public void Undirected()
        {
            var graph = new Graph<int>(false);
            var v1 = new Vertex<int>(1);
            var v2 = new Vertex<int>(2);
            var v3 = new Vertex<int>(3);
            var v4 = new Vertex<int>(4);

            graph.AddVertex(v1, v2, v3);
            graph.AddVertex(v2);
            graph.AddVertex(v3);

            graph.AddEdge(v1, v2);
            graph.AddEdge(v3, v2);
            graph.AddEdge(v1, v3);

            Assert.AreEqual(3, graph.Edges.Count);
            Assert.AreEqual(3, graph.Vertices.Count);

            Assert.IsTrue(graph.RemoveVertex(v1));

            Assert.AreEqual(1, graph.Edges.Count);
            Assert.AreEqual(2, graph.Vertices.Count);

            Assert.IsFalse(graph.RemoveVertex(v4));

            Assert.AreEqual(1, graph.Edges.Count);
            Assert.AreEqual(2, graph.Vertices.Count);

        }

        [Test]
        public void Directed()
        {
            var graph = new Graph<int>(true);
            var v1 = new Vertex<int>(1);
            var v2 = new Vertex<int>(2);
            var v3 = new Vertex<int>(3);
            var v4 = new Vertex<int>(4);

            graph.AddVertex(v1, v2, v3);

            graph.AddEdge(v1, v2);
            graph.AddEdge(v3, v2);
            graph.AddEdge(v1, v3);

            Assert.AreEqual(3, graph.Edges.Count);
            Assert.AreEqual(3, graph.Vertices.Count);

            Assert.IsTrue(graph.RemoveVertex(v1));

            Assert.AreEqual(1, graph.Edges.Count);
            Assert.AreEqual(2, graph.Vertices.Count);

            Assert.IsFalse(graph.RemoveVertex(v4));

            Assert.AreEqual(1, graph.Edges.Count);
            Assert.AreEqual(2, graph.Vertices.Count);
        }

        [Test]
        public void UndirectedValue()
        {
            var graph = new Graph<int>(false);
            var v1 = new Vertex<int>(1);
            var v2 = new Vertex<int>(2);
            var v3 = new Vertex<int>(3);

            graph.AddVertex(v1, v2, v3);

            graph.AddEdge(v1, v2);
            graph.AddEdge(v3, v2);
            graph.AddEdge(v1, v3);

            Assert.AreEqual(3, graph.Edges.Count);
            Assert.AreEqual(3, graph.Vertices.Count);

            Assert.IsTrue(graph.RemoveVertex(1));

            Assert.AreEqual(1, graph.Edges.Count);
            Assert.AreEqual(2, graph.Vertices.Count);

            Assert.IsFalse(graph.RemoveVertex(4));
            Assert.AreEqual(1, graph.Edges.Count);
            Assert.AreEqual(2, graph.Vertices.Count);
        }

        [Test]
        public void DirectedValue()
        {
            var graph = new Graph<int>(true);
            var v1 = new Vertex<int>(1);
            var v2 = new Vertex<int>(2);
            var v3 = new Vertex<int>(3);

            graph.AddVertex(v1, v2, v3);

            graph.AddEdge(v1, v2);
            graph.AddEdge(v3, v2);
            graph.AddEdge(v1, v3);

            Assert.AreEqual(3, graph.Edges.Count);
            Assert.AreEqual(3, graph.Vertices.Count);

            Assert.IsTrue(graph.RemoveVertex(1));

            Assert.AreEqual(1, graph.Edges.Count);
            Assert.AreEqual(2, graph.Vertices.Count);

            Assert.IsFalse(graph.RemoveVertex(4));
            Assert.AreEqual(1, graph.Edges.Count);
            Assert.AreEqual(2, graph.Vertices.Count);
        }

        [Test]
        public void ExceptionNullVertex()
        {
            var graph = new Graph<int>(true);
            Assert.Throws<ArgumentNullException>(() => graph.RemoveVertex(null));
        }
    }
}