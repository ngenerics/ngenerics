/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.GraphTests
{
    [TestFixture]
    public class Edges : GraphTest
    {
        [Test]
        public void Simple()
        {
            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);
            var vertex4 = new Vertex<int>(4);

            var graph = new Graph<int>(false);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);
            graph.AddVertex(vertex4);

            var edge1 = graph.AddEdge(vertex1, vertex2);
            var edge2 = graph.AddEdge(vertex2, vertex3);
            var edge3 = graph.AddEdge(vertex3, vertex1);
            var edge4 = graph.AddEdge(vertex4, vertex2);

            var edgeList = new List<Edge<int>>();

            foreach (var edge in graph.Edges)
            {
                edgeList.Add(edge);
            }

            Assert.IsTrue(edgeList.Contains(edge1));
            Assert.IsTrue(edgeList.Contains(edge2));
            Assert.IsTrue(edgeList.Contains(edge3));
            Assert.IsTrue(edgeList.Contains(edge4));
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

            for (var i = 0; i < 17; i += 2)
            {
                graph.AddEdge(vertices[i], vertices[i + 2]);
            }

            var edges = new List<Edge<int>>(graph.Edges.Count);
            edges.AddRange(graph.Edges);

            Assert.AreEqual(edges.Count, 9);

            for (var i = 0; i < 17; i += 2)
            {
                var found = false;

                foreach (var edge in edges)
                {
                    if ((edge.FromVertex == vertices[i]) && (edge.ToVertex == vertices[i + 2]))
                    {
                        found = true;
                        break;
                    }
                }

                Assert.IsTrue(found);
            }
        }

        [Test]
        public void Directed()
        {
            var graph = new Graph<int>(true);

            var vertices = new Vertex<int>[20];

            for (var i = 0; i < 20; i++)
            {
                vertices[i] = new Vertex<int>(i);
                graph.AddVertex(vertices[i]);
            }

            for (var i = 0; i < 17; i += 2)
            {
                graph.AddEdge(vertices[i], vertices[i + 2]);
            }

            var edges = GetEdgeList(graph.Edges.GetEnumerator());

            Assert.AreEqual(edges.Count, 9);

            for (var i = 0; i < 17; i += 2)
            {
                var found = false;

                foreach (var edge in edges)
                {
                    if ((edge.FromVertex == vertices[i]) && (edge.ToVertex == vertices[i + 2]))
                    {
                        found = true;
                        break;
                    }
                }

                Assert.IsTrue(found);
            }
        }

        [Test]
        public void DirectedEdges()
        {
            var graph = new Graph<int>(true);

            var vertices = new Vertex<int>[20];

            for (var i = 0; i < 20; i++)
            {
                vertices[i] = new Vertex<int>(i);
                graph.AddVertex(vertices[i]);
            }

            var counter = 0;

            for (var i = 0; i < 17; i += 2)
            {
                graph.AddEdge(vertices[i], vertices[i + 2]);
                counter++;

                Assert.AreEqual(graph.Edges.Count, counter);
            }
        }

        [Test]
        public void UndirectedEdges()
        {
            var graph = new Graph<int>(false);

            var vertices = new Vertex<int>[20];

            for (var i = 0; i < 20; i++)
            {
                vertices[i] = new Vertex<int>(i);
                graph.AddVertex(vertices[i]);
            }

            var counter = 0;

            for (var i = 0; i < 17; i += 2)
            {
                graph.AddEdge(vertices[i], vertices[i + 2]);
                counter++;

                Assert.AreEqual(graph.Edges.Count, counter);
            }
        }

    }
}