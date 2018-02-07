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
    public class AddVertex : GraphTest
    {
        [Test]
        public void Undirected()
        {
            var graph = new Graph<int>(false);

            for (var i = 0; i < 20; i++)
            {
                var vertex = new Vertex<int>(i);
                graph.AddVertex(vertex);

                Assert.AreEqual(graph.Vertices.Count, i + 1);
                Assert.IsTrue(graph.ContainsVertex(i));
                Assert.IsTrue(graph.ContainsVertex(vertex));
                Assert.AreEqual(graph.Edges.Count, 0);
            }
        }

        [Test]
        public void Directed()
        {
            var graph = new Graph<int>(true);

            for (var i = 0; i < 20; i++)
            {
                var vertex = new Vertex<int>(i);
                graph.AddVertex(vertex);

                Assert.AreEqual(graph.Vertices.Count, i + 1);
                Assert.IsTrue(graph.ContainsVertex(i));
                Assert.IsTrue(graph.ContainsVertex(vertex));
                Assert.AreEqual(graph.Edges.Count, 0);
            }
        }

        [Test]
        public void UndirectedVertexValue()
        {
            var graph = new Graph<int>(false);

            for (var i = 0; i < 20; i++)
            {
                graph.AddVertex(i);

                Assert.AreEqual(graph.Vertices.Count, i + 1);
                Assert.IsTrue(graph.ContainsVertex(i));
                Assert.AreEqual(graph.Edges.Count, 0);
            }
        }

        [Test]
        public void DirectedVertexValue()
        {
            var graph = new Graph<int>(true);

            for (var i = 0; i < 20; i++)
            {
                graph.AddVertex(i);

                Assert.AreEqual(graph.Vertices.Count, i + 1);
                Assert.IsTrue(graph.ContainsVertex(i));
                Assert.AreEqual(graph.Edges.Count, 0);
            }
        }

        [Test]
        public void ExceptionAddDuplicateUndirected()
        {
            var vertex = new Vertex<int>(5);
            var graph = new Graph<int>(false);

            graph.AddVertex(vertex);
            Assert.Throws<ArgumentException>(() => graph.AddVertex(vertex));
        }

        [Test]
        public void ExceptionAddDuplicateDirected()
        {
            var vertex = new Vertex<int>(5);
            var graph = new Graph<int>(true);

            graph.AddVertex(vertex);
            Assert.Throws<ArgumentException>(() => graph.AddVertex(vertex));
        }
    }
}