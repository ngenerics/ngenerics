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

    public class GraphTest
    {
        internal static Graph<int> GetTestDirectedGraph()
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

            return graph;
        }

        internal static List<Edge<int>> GetEdgeList(IEnumerator<Edge<int>> edges)
        {
            var edgeList = new List<Edge<int>>();

            while (edges.MoveNext())
            {
                edgeList.Add(edges.Current);
            }
            return edgeList;
        }

        internal static void TestIsCopy(Vertex<int> vertex1, Vertex<int> vertex2)
        {
            Assert.AreNotSame(vertex1, vertex2);
            Assert.AreEqual(vertex1.Data, vertex2.Data);
        }

        internal static void TestIsCopy(Edge<int> edge1, Edge<int> edge2)
        {
            Assert.AreNotSame(edge1, edge2);
            Assert.AreEqual(edge1.Weight, edge2.Weight);
            Assert.AreEqual(edge1.IsDirected, edge2.IsDirected);
            Assert.AreEqual(edge1.FromVertex.Data, edge2.FromVertex.Data);
            Assert.AreEqual(edge1.ToVertex.Data, edge2.ToVertex.Data);
            Assert.AreEqual(edge1.ToVertex.Degree, edge2.ToVertex.Degree);
        }

        internal static void TestEnumerator(IEnumerable<int> g)
        {
            var enumerator = g.GetEnumerator();

            var list = new List<int>();

            while (enumerator.MoveNext())
            {
                list.Add(enumerator.Current);
            }

            Assert.AreEqual(list.Count, 20);

            for (var i = 0; i < list.Count; i++)
            {
                Assert.IsTrue(list.Contains(i));
            }
        }

        internal static List<Vertex<int>> GetVertices(Graph<int> g)
        {
            var vertices = g.Vertices;
            var ret = new List<Vertex<int>>(vertices.Count);

            using (var enumerator = vertices.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    ret.Add(enumerator.Current);
                }
            }

            return ret;
        }

        internal static Graph<int> GetTestUndirectedGraph()
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

            return graph;
        }

        internal static void TestCopyTo(ICollection<int> graph)
        {
            var array = new int[20];
            graph.CopyTo(array, 0);

            var list = new List<int>(array);

            for (var i = 0; i < 19; i++)
            {
                Assert.IsTrue(list.Contains(i));
            }
        }

        internal static List<Edge<int>> GetEdges(Graph<int> g)
        {
            var list = g.Edges;
            var edges = new List<Edge<int>>(list.Count);

            using (var enumerator = list.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    edges.Add(enumerator.Current);
                }
            }

            return edges;
        }

    }
}