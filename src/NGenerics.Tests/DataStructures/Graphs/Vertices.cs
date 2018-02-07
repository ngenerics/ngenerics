/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System.Linq;
using NGenerics.DataStructures.Graphs;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Graphs
{
    [TestFixture]
    public class Vertices : GraphTest
    {
        [Test]
        public void Simple()
        {
            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);
            var vertex4 = new Vertex<int>(4);

            var graph = new Graph<int>(true);

            graph.AddVertex(vertex1, vertex2, vertex3, vertex4);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex2, vertex3);
            graph.AddEdge(vertex3, vertex1);
            graph.AddEdge(vertex4, vertex2);

            var vertexList = graph.Vertices.ToList();

            Assert.IsTrue(vertexList.Contains(vertex1));
            Assert.IsTrue(vertexList.Contains(vertex2));
            Assert.IsTrue(vertexList.Contains(vertex3));
            Assert.IsTrue(vertexList.Contains(vertex4));
        }


        [Test]
        public void Undirected()
        {
            var graph = new Graph<int>(false);

            var vertices = new Vertex<int>[20];

            for (var i = 0; i < 20; i++)
            {
                vertices[i] = new Vertex<int>(i);
                graph.AddVertex(vertices[i]);
            }

            var enumeratedVertices = GetVertices(graph);

            Assert.AreEqual(20, enumeratedVertices.Count);

            for (var i = 0; i < enumeratedVertices.Count; i++)
            {
                Assert.IsTrue(enumeratedVertices.Contains(vertices[i]));
            }
        }

        [Test]
        public void DirectedGraph()
        {
            var graph = new Graph<int>(true);

            var vertices = new Vertex<int>[20];

            for (var i = 0; i < 20; i++)
            {
                vertices[i] = new Vertex<int>(i);
                graph.AddVertex(vertices[i]);
            }

            var enumeratedVertices = GetVertices(graph);

            Assert.AreEqual(20, enumeratedVertices.Count);

            for (var i = 0; i < enumeratedVertices.Count; i++)
            {
                Assert.IsTrue(enumeratedVertices.Contains(vertices[i]));
            }
        }

        [Test]
        public void DirectedVertices()
        {
            var graph = new Graph<int>(true);

            for (var i = 0; i < 20; i++)
            {
                var vertex = new Vertex<int>(i);
                graph.AddVertex(vertex);

                Assert.AreEqual(i * 2 + 1, graph.Vertices.Count);

                graph.AddVertex(i);

                Assert.AreEqual(i * 2 + 2, graph.Vertices.Count);
            }
        }

        [Test]
        public void UndirectedVertices()
        {
            var graph = new Graph<int>(false);

            for (var i = 0; i < 20; i++)
            {
                var vertex = new Vertex<int>(i);
                graph.AddVertex(vertex);

                Assert.AreEqual(i * 2 + 1, graph.Vertices.Count);

                graph.AddVertex(i);

                Assert.AreEqual(i * 2 + 2, graph.Vertices.Count);
            }
        }
    }
}