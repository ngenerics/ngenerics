/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NGenerics.DataStructures.General;
using NGenerics.Patterns.Visitor;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.GraphTest
{

    public class GraphTest
    {

        #region Private Members

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

        #endregion
    }

    #region Tests

    [TestFixture]
    public class Construction : GraphTest
    {
        [Test]
        public void Simple()
        {
            var graph = new Graph<int>(false);

            Assert.AreEqual(graph.Vertices.Count, 0);
            Assert.AreEqual(graph.Vertices.Count, 0);
            Assert.AreEqual(graph.Edges.Count, 0);
            Assert.IsFalse(graph.IsDirected);

            graph = new Graph<int>(true);

            Assert.AreEqual(graph.Vertices.Count, 0);
            Assert.AreEqual(graph.Vertices.Count, 0);
            Assert.AreEqual(graph.Edges.Count, 0);
            Assert.IsTrue(graph.IsDirected);
        }
    }

    [TestFixture]
    public class Accept : GraphTest
    {
        [Test]
        public void Simple()
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
                var edge = new Edge<int>(vertices[i], vertices[i + 2], false);
                graph.AddEdge(edge);
            }

            var trackingVisitor = new TrackingVisitor<int>();

            graph.AcceptVisitor(trackingVisitor);

            Assert.AreEqual(trackingVisitor.TrackingList.Count, 20);

            for (var i = 0; i < 20; i++)
            {
                Assert.IsTrue(trackingVisitor.TrackingList.Contains(i));
            }
        }

        [Test]
        public void CompletedVisitor()
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
                var edge = new Edge<int>(vertices[i], vertices[i + 2], false);
                graph.AddEdge(edge);
            }

            var completedTrackingVisitor = new CompletedTrackingVisitor<int>();

            graph.AcceptVisitor(completedTrackingVisitor);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVisitor()
        {
            var graph = new Graph<int>(false);
            graph.AcceptVisitor(null);
        }
    }

    [TestFixture]
    public class Add : GraphTest
    {
        [Test]
        public void Interface()
        {
            var graph = new Graph<int>(true);
            ((ICollection<int>)graph).Add(4);
            Assert.AreEqual(graph.Vertices.Count, 1);
        }
    }

    [TestFixture]
    public class AddEdge : GraphTest
    {
        [Test]
        public void DuplicateEdge()
        {
            var graph = new Graph<int>(false);
            var random = new Random();

            var vertices = new List<Vertex<int>>();

            for (var i = 0; i < 100; i++)
            {
                vertices.Add(graph.AddVertex(i));
            }

            var edges = new List<Edge<int>>();

            for (var i = 0; i < 2000; i++)
            {
                var fromVertex = random.Next(100);
                var toVertex = random.Next(100);

                if (!graph.ContainsEdge(vertices[fromVertex], vertices[toVertex]))
                {
                    edges.Add(
                        graph.AddEdge(vertices[fromVertex], vertices[toVertex])
                    );
                }
            }

            foreach (var edge in edges)
            {
                Assert.IsTrue(graph.ContainsEdge(edge));
                Assert.IsTrue(graph.ContainsEdge(edge.FromVertex, edge.ToVertex));
                Assert.IsTrue(graph.ContainsEdge(edge.FromVertex.Data, edge.ToVertex.Data));
            }
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionInvalidEdgeDirected()
        {
            var graph = GetTestDirectedGraph();

            var vertices = graph.Vertices;

            var enumerator = vertices.GetEnumerator();

            enumerator.MoveNext();
            var vertex1 = enumerator.Current;

            enumerator.MoveNext();
            var vertex2 = enumerator.Current;

            var edge = new Edge<int>(vertex1, vertex2, false);
            graph.AddEdge(edge);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionInvalidEdgeUndirected()
        {
            var graph = GetTestUndirectedGraph();

            var vertices = graph.Vertices;

            var enumerator = vertices.GetEnumerator();

            enumerator.MoveNext();
            var vertex1 = enumerator.Current;

            enumerator.MoveNext();
            var vertex2 = enumerator.Current;

            var edge = new Edge<int>(vertex1, vertex2, true);
            graph.AddEdge(edge);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullToVertex()
        {
            var graph = new Graph<int>(true);
            graph.AddEdge(null, new Vertex<int>(3));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullFromVertex()
        {
            var graph = new Graph<int>(true);
            graph.AddEdge(new Vertex<int>(3), null);
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

            var counter = 0;

            for (var i = 0; i < 17; i += 2)
            {
                var edge = new Edge<int>(vertices[i], vertices[i + 2], false);
                graph.AddEdge(edge);

                counter++;

                Assert.AreEqual(graph.Edges.Count, counter);
                Assert.IsTrue(graph.ContainsEdge(edge));
                Assert.IsTrue(vertices[i].HasEmanatingEdgeTo(vertices[i + 2]));
                Assert.IsTrue(vertices[i].HasIncidentEdgeWith(vertices[i + 2]));

            }
        }

        [Test]
        public void VerticesAndWeightDirected()
        {
            var graph = new Graph<int>(true);
            var vertex1 = new Vertex<int>(4);
            var vertex2 = new Vertex<int>(5);
            var vertex3 = new Vertex<int>(6);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            graph.AddEdge(vertex1, vertex2, 10);
            graph.AddEdge(vertex1, vertex3, 12);
            graph.AddEdge(vertex2, vertex3, 14);

            Assert.AreEqual(graph.Edges.Count, 3);

            Assert.IsTrue(vertex1.HasEmanatingEdgeTo(vertex2));
            Assert.IsTrue(vertex1.HasEmanatingEdgeTo(vertex3));
            Assert.IsTrue(vertex2.HasEmanatingEdgeTo(vertex3));

            Assert.IsFalse(vertex2.HasEmanatingEdgeTo(vertex1));
            Assert.IsFalse(vertex3.HasEmanatingEdgeTo(vertex1));
            Assert.IsFalse(vertex3.HasEmanatingEdgeTo(vertex2));

            Assert.IsTrue(graph.ContainsEdge(vertex1, vertex2));
            Assert.IsTrue(graph.ContainsEdge(vertex1, vertex3));
            Assert.IsTrue(graph.ContainsEdge(vertex2, vertex3));

            Assert.IsFalse(graph.ContainsEdge(vertex2, vertex1));
            Assert.IsFalse(graph.ContainsEdge(vertex3, vertex1));
            Assert.IsFalse(graph.ContainsEdge(vertex3, vertex2));
        }

        [Test]
        public void VerticesAndWeightUndirected()
        {
            var graph = new Graph<int>(false);
            var vertex1 = new Vertex<int>(4);
            var vertex2 = new Vertex<int>(5);
            var vertex3 = new Vertex<int>(6);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            graph.AddEdge(vertex1, vertex2, 10);
            graph.AddEdge(vertex1, vertex3, 12);
            graph.AddEdge(vertex2, vertex3, 14);

            Assert.AreEqual(graph.Edges.Count, 3);

            Assert.IsTrue(vertex1.HasEmanatingEdgeTo(vertex2));
            Assert.IsTrue(vertex1.HasEmanatingEdgeTo(vertex3));
            Assert.IsTrue(vertex2.HasEmanatingEdgeTo(vertex3));

            Assert.IsTrue(vertex2.HasEmanatingEdgeTo(vertex1));
            Assert.IsTrue(vertex3.HasEmanatingEdgeTo(vertex1));
            Assert.IsTrue(vertex3.HasEmanatingEdgeTo(vertex2));

            Assert.IsTrue(graph.ContainsEdge(vertex1, vertex2));
            Assert.IsTrue(graph.ContainsEdge(vertex1, vertex3));
            Assert.IsTrue(graph.ContainsEdge(vertex2, vertex3));

            Assert.IsTrue(graph.ContainsEdge(vertex2, vertex1));
            Assert.IsTrue(graph.ContainsEdge(vertex3, vertex1));
            Assert.IsTrue(graph.ContainsEdge(vertex3, vertex2));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullEdge()
        {
            var graph = new Graph<int>(false);
            graph.AddEdge(null);
        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionVertexNotInGraphUndirected()
        {
            var graph = GetTestUndirectedGraph();

            var edge = new Edge<int>(new Vertex<int>(1), new Vertex<int>(1), false);
            graph.AddEdge(edge);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionVertexNotInGraphDirected()
        {
            var graph = GetTestDirectedGraph();

            var edge = new Edge<int>(new Vertex<int>(1), new Vertex<int>(1), true);
            graph.AddEdge(edge);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExcetionDuplicateEdgeUndirected1()
        {
            var graph = new Graph<int>(false);

            var vertices = new Vertex<int>[20];

            for (var i = 0; i < 20; i++)
            {
                vertices[i] = new Vertex<int>(i);
                graph.AddVertex(vertices[i]);
            }

            var edge = new Edge<int>(vertices[0], vertices[2], false);
            graph.AddEdge(edge);

            graph.AddEdge(edge);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionDuplicateEdgeUndirected2()
        {
            var graph = new Graph<int>(false);

            var vertices = new Vertex<int>[20];

            for (var i = 0; i < 20; i++)
            {
                vertices[i] = new Vertex<int>(i);
                graph.AddVertex(vertices[i]);
            }

            var edge = new Edge<int>(vertices[0], vertices[2], false);
            graph.AddEdge(edge);

            graph.AddEdge(new Edge<int>(vertices[2], vertices[0], false));
        }
    }

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
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionAddDuplicateUndirected()
        {
            var vertex = new Vertex<int>(5);
            var graph = new Graph<int>(false);

            graph.AddVertex(vertex);
            graph.AddVertex(vertex);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionAddDuplicateDirected()
        {
            var vertex = new Vertex<int>(5);
            var graph = new Graph<int>(true);

            graph.AddVertex(vertex);
            graph.AddVertex(vertex);
        }
    }

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

    [TestFixture]
    public class Clear : GraphTest
    {
        [Test]
        public void Simple()
        {
            var graph = GetTestUndirectedGraph();
            graph.Clear();

            Assert.AreEqual(graph.Vertices.Count, 0);
            Assert.AreEqual(graph.Vertices.Count, 0);
            Assert.AreEqual(graph.Edges.Count, 0);
        }
    }

    [TestFixture]
    public class Contains : GraphTest
    {
        [Test]
        public void Interface()
        {
            var graph = new Graph<int>(true);
            ((ICollection<int>)graph).Add(4);
            Assert.AreEqual(graph.Vertices.Count, 1);

            Assert.IsTrue(((ICollection<int>)graph).Contains(4));
            Assert.IsFalse(((ICollection<int>)graph).Contains(3));
        }
    }

    [TestFixture]
    public class Count : GraphTest
    {
        [Test]
        public void Directed()
        {
            var graph = new Graph<int>(true);
            ICollection<int> visitableCollection = graph;

            for (var i = 0; i < 20; i++)
            {
                var vertex = new Vertex<int>(i);
                graph.AddVertex(vertex);

                Assert.AreEqual(visitableCollection.Count, i * 2 + 1);

                graph.AddVertex(i);

                Assert.AreEqual(visitableCollection.Count, i * 2 + 2);
            }
        }

        [Test]
        public void Undirected()
        {
            var graph = new Graph<int>(false);
            ICollection<int> c = graph;

            for (var i = 0; i < 20; i++)
            {
                var vertex = new Vertex<int>(i);
                graph.AddVertex(vertex);

                Assert.AreEqual(c.Count, i * 2 + 1);

                graph.AddVertex(i);

                Assert.AreEqual(c.Count, i * 2 + 2);
            }
        }
    }

    [TestFixture]
    public class ContainsEdge : GraphTest
    {
        [Test]
        public void Directed()
        {
            var graph = GetTestDirectedGraph();

            var edgeList = GetEdges(graph);

            foreach (var t in edgeList)
            {
                Assert.IsTrue(graph.ContainsEdge(t.FromVertex, t.ToVertex));
                Assert.IsTrue(graph.ContainsEdge(t.FromVertex.Data, t.ToVertex.Data));

                Assert.IsFalse(graph.ContainsEdge(t.ToVertex, t.FromVertex));
                Assert.IsFalse(graph.ContainsEdge(t.ToVertex.Data, t.FromVertex.Data));
            }

            Assert.IsFalse(graph.ContainsEdge(100, 200));
            Assert.IsFalse(graph.ContainsEdge(new Vertex<int>(100), new Vertex<int>(200)));
        }

        [Test]
        public void Undirected()
        {
            var graph = GetTestUndirectedGraph();

            var edgeList = GetEdges(graph);

            foreach (var edge in edgeList)
            {
                Assert.IsTrue(graph.ContainsEdge(edge.FromVertex, edge.ToVertex));
                Assert.IsTrue(graph.ContainsEdge(edge.FromVertex.Data, edge.ToVertex.Data));

                Assert.IsTrue(graph.ContainsEdge(edge.ToVertex, edge.FromVertex));
                Assert.IsTrue(graph.ContainsEdge(edge.ToVertex.Data, edge.FromVertex.Data));
            }

            Assert.IsFalse(graph.ContainsEdge(100, 200));
            Assert.IsFalse(graph.ContainsEdge(new Vertex<int>(100), new Vertex<int>(200)));
        }
    }

    [TestFixture]
    public class ContainsVertex : GraphTest
    {
        [Test]
        public void Simple()
        {
            var graph = new Graph<int>(false);

            for (var i = 0; i < 20; i++)
            {
                var vertex = new Vertex<int>(i);
                graph.AddVertex(vertex);

                Assert.IsTrue(graph.ContainsVertex(i));
                Assert.IsTrue(graph.ContainsVertex(vertex));
            }

            Assert.IsFalse(graph.ContainsVertex(new Vertex<int>(3)));
            Assert.IsFalse(graph.ContainsVertex(21));
        }
    }

    [TestFixture]
    public class CopyTo : GraphTest
    {
        [Test]
        public void Undirected()
        {
            TestCopyTo(GetTestUndirectedGraph());
        }

        [Test]
        public void Directed()
        {
            TestCopyTo(GetTestDirectedGraph());
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullArrayDirected()
        {
            var graph = new Graph<int>(true);
            graph.CopyTo(null, 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullArrayUndirected()
        {
            var graph = new Graph<int>(false);
            graph.CopyTo(null, 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionDirectedInvalid1()
        {
            var graph = GetTestDirectedGraph();

            var array = new int[20];
            graph.CopyTo(array, 1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionUndirectedInvalid1()
        {
            var graph = GetTestUndirectedGraph();

            var array = new int[20];
            graph.CopyTo(array, 1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionUndirectedInvalid2()
        {
            var graph = GetTestUndirectedGraph();

            var array = new int[19];
            graph.CopyTo(array, 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionDirectedInvalid2()
        {
            var graph = GetTestDirectedGraph();
            var array = new int[19];
            graph.CopyTo(array, 0);
        }
    }

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

    [TestFixture]
    public class FindCycles : GraphTest
    {
        [Test]
        public void NotCyclic()
        {
            var graph = new Graph<int>(true);
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);
            var vertex3 = graph.AddVertex(3);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex2, vertex3);

            var cycles = graph.FindCycles(true);

            Assert.AreEqual(0, cycles.Count, "There should not be any cycles");
        }

        [Test]
        public void SingleCycle()
        {
            var graph = new Graph<int>(true);
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);
            var vertex3 = graph.AddVertex(3);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex2, vertex3);
            graph.AddEdge(vertex3, vertex1);

            var cycles = graph.FindCycles(true);

            Assert.AreEqual(1, cycles.Count, "There is a single cycle");

            IList<Vertex<int>> cycle1 = cycles[0];
            Assert.IsTrue(cycle1.Any(v => v.Data == 1), "Vertex 1 missing from the cycle");
            Assert.IsTrue(cycle1.Any(v => v.Data == 2), "Vertex 2 missing from the cycle");
            Assert.IsTrue(cycle1.Any(v => v.Data == 3), "Vertex 3 missing from the cycle");
            Assert.AreEqual(3, cycle1.Count, "There should be three items in the cycle");
        }

        [Test]
        public void SingleCycleWithManyEdgesDirected()
        {
            var graph = new Graph<int>(true);
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);
            var vertex3 = graph.AddVertex(3);
            var vertex4 = graph.AddVertex(4);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex2, vertex3);
            graph.AddEdge(vertex3, vertex1);
            graph.AddEdge(vertex3, vertex4);
            graph.AddEdge(vertex4, vertex1);
            graph.AddEdge(vertex4, vertex2);


            var cycles = graph.FindCycles(true);

            Assert.AreEqual(1, cycles.Count, "There is a single cycle");

            IList<Vertex<int>> cycle1 = cycles[0];
            Assert.IsTrue(cycle1.Any(v => v.Data == 1), "Vertex 1 missing from the cycle");
            Assert.IsTrue(cycle1.Any(v => v.Data == 2), "Vertex 2 missing from the cycle");
            Assert.IsTrue(cycle1.Any(v => v.Data == 3), "Vertex 3 missing from the cycle");
            Assert.IsTrue(cycle1.Any(v => v.Data == 3), "Vertex 4 missing from the cycle");
            Assert.AreEqual(4, cycle1.Count, "There should be four items in the cycle");
        }

        [Test]
        public void SingleCycleWithManyEdgesUndirected()
        {
            var graph = new Graph<int>(false);
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);
            var vertex3 = graph.AddVertex(3);
            var vertex4 = graph.AddVertex(4);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex2, vertex3);
            graph.AddEdge(vertex3, vertex1);
            graph.AddEdge(vertex3, vertex4);
            graph.AddEdge(vertex4, vertex1);
            graph.AddEdge(vertex4, vertex2);


            var cycles = graph.FindCycles(true);

            Assert.AreEqual(1, cycles.Count, "There is a single cycle");

            IList<Vertex<int>> cycle1 = cycles[0];
            Assert.IsTrue(cycle1.Any(v => v.Data == 1), "Vertex 1 missing from the cycle");
            Assert.IsTrue(cycle1.Any(v => v.Data == 2), "Vertex 2 missing from the cycle");
            Assert.IsTrue(cycle1.Any(v => v.Data == 3), "Vertex 3 missing from the cycle");
            Assert.IsTrue(cycle1.Any(v => v.Data == 3), "Vertex 4 missing from the cycle");
            Assert.AreEqual(4, cycle1.Count, "There should be four items in the cycle");
        }

        [Test]
        public void MultipleCyclesDirected()
        {
            var graph = new Graph<int>(true);
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);
            var vertex3 = graph.AddVertex(3);
            var vertex4 = graph.AddVertex(4);
            var vertex5 = graph.AddVertex(5);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex2, vertex3);
            graph.AddEdge(vertex3, vertex1);

            graph.AddEdge(vertex4, vertex5);
            graph.AddEdge(vertex5, vertex4);


            var cycles = graph.FindCycles(true);

            Assert.AreEqual(2, cycles.Count, "There are two cycles");

            IList<Vertex<int>> cycle1 = cycles[0];
            IList<Vertex<int>> cycle2 = cycles[1];

            Assert.IsTrue(((cycle1.Count == 3) && (cycle2.Count == 2)) || ((cycle1.Count == 2) && (cycle2.Count == 3)), "Wrong number of items in the cycles");

            var index = (cycle1.Count == 3) ? 0 : 1;
            Assert.IsTrue(cycles[index].Any(v => v.Data == 1), "Vertex 1 missing from the cycle");
            Assert.IsTrue(cycles[index].Any(v => v.Data == 2), "Vertex 2 missing from the cycle");
            Assert.IsTrue(cycles[index].Any(v => v.Data == 3), "Vertex 3 missing from the cycle");

            index = (cycle1.Count == 2) ? 0 : 1;
            Assert.IsTrue(cycles[index].Any(v => v.Data == 4), "Vertex 1 missing from the cycle");
            Assert.IsTrue(cycles[index].Any(v => v.Data == 5), "Vertex 2 missing from the cycle");
        }

        [Test]
        public void MultipleCyclesUndirected()
        {
            var graph = new Graph<int>(false);
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);
            var vertex3 = graph.AddVertex(3);
            var vertex4 = graph.AddVertex(4);
            var vertex5 = graph.AddVertex(5);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex2, vertex3);
            graph.AddEdge(vertex3, vertex1);

            graph.AddEdge(vertex4, vertex5);

            var cycles = graph.FindCycles(true);

            Assert.AreEqual(1, cycles.Count, "There are two cycles");

            IList<Vertex<int>> cycle1 = cycles[0];

            Assert.IsTrue((cycle1.Count == 3) || (cycle1.Count == 2), "Wrong number of items in the cycles");

            Assert.IsTrue(cycles[0].Any(v => v.Data == 1), "Vertex 1 missing from the cycle");
            Assert.IsTrue(cycles[0].Any(v => v.Data == 2), "Vertex 2 missing from the cycle");
            Assert.IsTrue(cycles[0].Any(v => v.Data == 3), "Vertex 3 missing from the cycle");
        }

        [Test]
        public void IncludeSingleItems()
        {
            var graph = new Graph<int>(true);
            graph.AddVertex(1);

            var cycles = graph.FindCycles(false);

            Assert.AreEqual(1, cycles.Count, "Wrong number of cycles");
            Assert.AreEqual(1, cycles[0].Length, "Wrong number of nodes in the cycle");
            Assert.AreEqual(1, cycles[0][0].Data, "Wrong number of nodes in the cycle");
        }

        [Test]
        public void ExcludeSingleItems()
        {
            var graph = new Graph<int>(true);
            graph.AddVertex(1);

            var cycles = graph.FindCycles();

            Assert.AreEqual(0, cycles.Count, "Wrong number of cycles");
        }
    }

    [TestFixture]
    public class FindVertices : GraphTest
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullPredicateDirected()
        {
            var graph = GetTestDirectedGraph();
            graph.FindVertices(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullPredicateUndirected()
        {
            var graph = GetTestUndirectedGraph();
            graph.FindVertices(null);
        }

        [Test]
        public void Directed()
        {
            var graph = GetTestDirectedGraph();

            var list = graph.FindVertices(value => value == 5 || value == 10);

            Assert.AreEqual(list.Count, 2);
            Assert.IsTrue(((list[0].Data == 5) || (list[0].Data == 10)));
            Assert.IsTrue(((list[1].Data == 5) || (list[1].Data == 10)));
            Assert.AreNotEqual(list[0].Data, list[1].Data);
        }

        [Test]
        public void Undirected()
        {
            var graph = GetTestUndirectedGraph();

            var list = graph.FindVertices(value => value == 5 || value == 10);

            Assert.AreEqual(list.Count, 2);
            Assert.IsTrue(((list[0].Data == 5) || (list[0].Data == 10)));
            Assert.IsTrue(((list[1].Data == 5) || (list[1].Data == 10)));
            Assert.AreNotEqual(list[0].Data, list[1].Data);
        }
    }

    [TestFixture]
    public class GetEdge : GraphTest
    {
        [Test]
        public void Directed()
        {
            var graph = new Graph<int>(true);
            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex3, vertex2);
            graph.AddEdge(vertex1, vertex3);

            var edge = graph.GetEdge(vertex1, vertex2);

            Assert.IsNotNull(edge);
            Assert.AreEqual(edge.FromVertex, vertex1);
            Assert.AreEqual(edge.ToVertex, vertex2);

            edge = graph.GetEdge(vertex3, vertex2);

            Assert.IsNotNull(edge);
            Assert.AreEqual(edge.FromVertex, vertex3);
            Assert.AreEqual(edge.ToVertex, vertex2);

            edge = graph.GetEdge(vertex1, vertex3);

            Assert.IsNotNull(edge);
            Assert.AreEqual(edge.FromVertex, vertex1);
            Assert.AreEqual(edge.ToVertex, vertex3);

            edge = graph.GetEdge(vertex2, vertex1);
            Assert.IsNull(edge);

            edge = graph.GetEdge(vertex2, vertex3);
            Assert.IsNull(edge);

            edge = graph.GetEdge(vertex3, vertex1);
            Assert.IsNull(edge);
        }

        [Test]
        public void Undirected()
        {
            var graph = new Graph<int>(false);
            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex3, vertex2);
            graph.AddEdge(vertex1, vertex3);

            var edge = graph.GetEdge(vertex1, vertex2);

            Assert.IsNotNull(edge);
            Assert.AreEqual(edge.FromVertex, vertex1);
            Assert.AreEqual(edge.ToVertex, vertex2);

            edge = graph.GetEdge(vertex3, vertex2);

            Assert.IsNotNull(edge);
            Assert.AreEqual(edge.FromVertex, vertex3);
            Assert.AreEqual(edge.ToVertex, vertex2);

            edge = graph.GetEdge(vertex1, vertex3);

            Assert.IsNotNull(edge);
            Assert.AreEqual(edge.FromVertex, vertex1);
            Assert.AreEqual(edge.ToVertex, vertex3);

            edge = graph.GetEdge(vertex2, vertex1);

            Assert.IsNotNull(edge);
            Assert.AreEqual(edge.FromVertex, vertex1);
            Assert.AreEqual(edge.ToVertex, vertex2);

            edge = graph.GetEdge(vertex2, vertex3);

            Assert.IsNotNull(edge);
            Assert.AreEqual(edge.FromVertex, vertex3);
            Assert.AreEqual(edge.ToVertex, vertex2);

            edge = graph.GetEdge(vertex3, vertex1);

            Assert.IsNotNull(edge);
            Assert.AreEqual(edge.FromVertex, vertex1);
            Assert.AreEqual(edge.ToVertex, vertex3);
        }

        [Test]
        public void ValuesDirected()
        {
            var graph = GetTestDirectedGraph();

            for (var i = 0; i < 17; i += 2)
            {
                var edge = graph.GetEdge(i, i + 2);

                Assert.IsNotNull(edge);
                Assert.AreEqual(edge.FromVertex.Data, i);
                Assert.AreEqual(edge.ToVertex.Data, i + 2);

                edge = graph.GetEdge(i + 2, i);

                Assert.IsNull(edge);
            }
        }

        [Test]
        public void ValuesUndirected()
        {
            var graph = GetTestUndirectedGraph();

            for (var i = 0; i < 17; i += 2)
            {
                var edge = graph.GetEdge(i, i + 2);

                Assert.IsNotNull(edge);
                Assert.AreEqual(edge.FromVertex.Data, i);
                Assert.AreEqual(edge.ToVertex.Data, i + 2);
            }
        }
    }

    [TestFixture]
    public class GetEnumerator : GraphTest
    {
        [Test]
        public void Undirected()
        {
            TestEnumerator(GetTestUndirectedGraph());
        }

        [Test]
        public void Directed()
        {
            TestEnumerator(GetTestDirectedGraph());
        }

        [Test]
        public void Interface()
        {
            var graph = GetTestUndirectedGraph();
            var enumerator = ((IEnumerable)graph).GetEnumerator();

            var list = new List<int>();

            while (enumerator.MoveNext())
            {
                list.Add((int)enumerator.Current);
            }

            Assert.AreEqual(list.Count, 20);

            for (var i = 0; i < list.Count; i++)
            {
                Assert.IsTrue(list.Contains(i));
            }
        }
    }

    [TestFixture]
    public class GetVertex : GraphTest
    {
        [Test]
        public void Directed()
        {
            var graph = GetTestDirectedGraph();

            for (var i = 0; i < 20; i++)
            {
                var vertex = graph.GetVertex(i);

                Assert.IsNotNull(vertex);
                Assert.AreEqual(vertex.Data, i);
            }

            Assert.IsNull(graph.GetVertex(21));
        }

        [Test]
        public void Undirected()
        {
            var graph = GetTestUndirectedGraph();

            for (var i = 0; i < 20; i++)
            {
                var vertex = graph.GetVertex(i);

                Assert.IsNotNull(vertex);
                Assert.AreEqual(vertex.Data, i);
            }

            Assert.IsNull(graph.GetVertex(21));
        }
    }

    [TestFixture]
    public class IncomingEdgeCount : GraphTest
    {
        [Test]
        public void Directed()
        {
            var graph = new Graph<int>(true);
            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            graph.AddEdge(vertex1, vertex2);

            Assert.AreEqual(vertex1.IncomingEdgeCount, 0);
            Assert.AreEqual(vertex2.IncomingEdgeCount, 1);

            graph.AddEdge(vertex3, vertex2);

            Assert.AreEqual(vertex3.IncomingEdgeCount, 0);
            Assert.AreEqual(vertex2.IncomingEdgeCount, 2);

            graph.AddEdge(vertex1, vertex3);

            Assert.AreEqual(vertex1.IncomingEdgeCount, 0);
            Assert.AreEqual(vertex3.IncomingEdgeCount, 1);
        }

        [Test]
        public void tUndirected()
        {
            var graph = new Graph<int>(false);
            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            graph.AddEdge(vertex1, vertex2);

            Assert.AreEqual(vertex1.IncomingEdgeCount, 0);
            Assert.AreEqual(vertex2.IncomingEdgeCount, 0);

            graph.AddEdge(vertex3, vertex2);

            Assert.AreEqual(vertex3.IncomingEdgeCount, 0);
            Assert.AreEqual(vertex2.IncomingEdgeCount, 0);

            graph.AddEdge(vertex1, vertex3);

            Assert.AreEqual(vertex1.IncomingEdgeCount, 0);
            Assert.AreEqual(vertex3.IncomingEdgeCount, 0);
        }
    }

    [TestFixture]
    public class IsCyclic : GraphTest
    {
        [Test]
        public void Simple()
        {
            var graph = new Graph<int>(true);
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);
            var vertex3 = graph.AddVertex(3);
            var vertex4 = graph.AddVertex(4);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex2, vertex3);
            graph.AddEdge(vertex2, vertex4);
            graph.AddEdge(vertex3, vertex4);

            Assert.IsFalse(graph.IsCyclic());

            // Add a cycle
            graph.AddEdge(vertex4, vertex1);

            Assert.IsTrue(graph.IsCyclic());

            // Remove the cycle again
            graph.RemoveEdge(vertex4, vertex1);

            Assert.IsFalse(graph.IsCyclic());

            // Add a cycle again
            graph.AddEdge(vertex2, vertex1);

            Assert.IsTrue(graph.IsCyclic());

            // Remove the cycle
            graph.RemoveEdge(vertex2, vertex1);

            Assert.IsFalse(graph.IsCyclic());
        }
    }

    [TestFixture]
    public class IsDirected : GraphTest
    {
        [Test]
        public void Simple()
        {
            var graph = new Graph<int>(true);
            Assert.IsTrue(graph.IsDirected);

            graph = new Graph<int>(false);
            Assert.IsFalse(graph.IsDirected);
        }
    }

    [TestFixture]
    public class IsEmpty : GraphTest
    {
        [Test]
        public void Simple()
        {
            var graph = new Graph<int>(true);
            Assert.IsTrue(graph.IsEmpty);

            graph.AddVertex(5);
            Assert.IsFalse(graph.IsEmpty);

            graph.AddVertex(3);
            Assert.IsFalse(graph.IsEmpty);

            graph.Clear();
            Assert.IsTrue(graph.IsEmpty);
        }
    }

    [TestFixture]
    public class IsReadOnly : GraphTest
    {
        [Test]
        public void Simple()
        {
            var graph = new Graph<int>(true);
            Assert.IsFalse(graph.IsReadOnly);

            graph = GetTestDirectedGraph();
            Assert.IsFalse(graph.IsReadOnly);

            graph = GetTestUndirectedGraph();
            Assert.IsFalse(graph.IsReadOnly);
        }
    }

    [TestFixture]
    public class IsStronglyConnected : GraphTest
    {
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionEmptyDirected()
        {
            var graph = new Graph<int>(true);
            graph.IsStronglyConnected();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionEmptyUndirected()
        {
            var graph = new Graph<int>(false);
            graph.IsStronglyConnected();
        }

        [Test]
        public void Undirected()
        {
            var graph = new Graph<int>(false);
            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);
            var vertex4 = new Vertex<int>(4);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);
            graph.AddVertex(vertex4);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex3, vertex2);
            graph.AddEdge(vertex1, vertex3);

            Assert.IsFalse(graph.IsStronglyConnected());

            graph.AddEdge(vertex2, vertex4);

            Assert.IsTrue(graph.IsStronglyConnected());

            graph.RemoveEdge(vertex2, vertex3);

            Assert.IsTrue(graph.IsStronglyConnected());

            graph.RemoveEdge(vertex1, vertex3);

            Assert.IsFalse(graph.IsStronglyConnected());
        }
    }

    [TestFixture]
    public class IsWeaklyConnected : GraphTest
    {
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionEmptyDirected()
        {
            var graph = new Graph<int>(true);
            graph.IsWeaklyConnected();
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionEmptyUndirected()
        {
            var graph = new Graph<int>(false);
            graph.IsWeaklyConnected();
        }

        [Test]
        public void Undirected()
        {
            var graph = new Graph<int>(false);
            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);
            var vertex4 = new Vertex<int>(4);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);
            graph.AddVertex(vertex4);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex3, vertex2);
            graph.AddEdge(vertex1, vertex3);

            Assert.IsFalse(graph.IsWeaklyConnected());

            graph.AddEdge(vertex2, vertex4);

            Assert.IsTrue(graph.IsWeaklyConnected());

            graph.RemoveEdge(vertex2, vertex3);

            Assert.IsTrue(graph.IsWeaklyConnected());

            graph.RemoveEdge(vertex1, vertex3);

            Assert.IsFalse(graph.IsWeaklyConnected());
        }

        [Test]
        public void Directed()
        {
            var graph = new Graph<int>(true);
            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);
            var vertex4 = new Vertex<int>(4);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);
            graph.AddVertex(vertex4);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex3, vertex2);
            graph.AddEdge(vertex1, vertex3);

            Assert.IsFalse(graph.IsWeaklyConnected());

            graph.AddEdge(vertex2, vertex4);

            Assert.IsTrue(graph.IsWeaklyConnected());

            graph.RemoveEdge(vertex2, vertex3);

            Assert.IsTrue(graph.IsWeaklyConnected());

            graph.RemoveEdge(vertex1, vertex3);

            Assert.IsFalse(graph.IsWeaklyConnected());
        }
    }

    [TestFixture]
    public class Remove : GraphTest
    {
        [Test]
        public void Interface()
        {
            var graph = new Graph<int>(true);
            ((ICollection<int>)graph).Add(4);
            Assert.AreEqual(graph.Vertices.Count, 1);

            Assert.IsTrue(((ICollection<int>)graph).Remove(4));
            Assert.AreEqual(graph.Vertices.Count, 0);
            Assert.IsFalse(((ICollection<int>)graph).Remove(3));
            Assert.AreEqual(graph.Vertices.Count, 0);
        }
    }

    [TestFixture]
    public class RemoveEdge : GraphTest
    {
        [Test]
        public void OtherVertex()
        {
            var graph = new Graph<int>(true);
            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex3, vertex2);
            graph.AddEdge(vertex1, vertex3);

            Assert.AreEqual(graph.Edges.Count, 3);
            Assert.AreEqual(graph.Vertices.Count, 3);

            Assert.IsTrue(graph.RemoveEdge(vertex1, vertex2));
            Assert.AreEqual(graph.Edges.Count, 2);
            Assert.IsFalse(vertex1.HasEmanatingEdgeTo(vertex2));
            Assert.IsTrue(vertex3.HasEmanatingEdgeTo(vertex2));

            Assert.IsTrue(graph.RemoveEdge(vertex3, vertex2));
            Assert.AreEqual(graph.Edges.Count, 1);

            Assert.IsFalse(vertex1.HasEmanatingEdgeTo(vertex2));
            Assert.IsFalse(vertex3.HasEmanatingEdgeTo(vertex2));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullEdge()
        {
            var graph = new Graph<int>(true);
            graph.RemoveEdge(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVertex1()
        {
            var graph = new Graph<int>(true);
            graph.RemoveEdge(new Vertex<int>(3), null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVertex2()
        {
            var graph = new Graph<int>(true);
            graph.RemoveEdge(null, new Vertex<int>(3));
        }

        [Test]
        public void DirectedNotInGraph()
        {
            var graph = new Graph<int>(true);
            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex3, vertex2);
            graph.AddEdge(vertex1, vertex3);

            Assert.IsFalse(graph.RemoveEdge(new Edge<int>(vertex2, vertex3, true)));
        }

        [Test]
        public void UndirectedNotInGraph()
        {
            var graph = new Graph<int>(true);
            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex3, vertex2);
            graph.AddEdge(vertex1, vertex3);

            Assert.IsFalse(graph.RemoveEdge(new Edge<int>(vertex2, vertex3, false)));
        }

        [Test]
        public void DirectedFromVerticesNotInGraph()
        {
            var graph = new Graph<int>(true);
            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex3, vertex2);
            graph.AddEdge(vertex1, vertex3);

            Assert.IsFalse(graph.RemoveEdge(vertex2, vertex3));
        }

        [Test]
        public void UndirectedFromVerticesNotInGraph()
        {
            var graph = new Graph<int>(false);
            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex3, vertex2);

            Assert.IsTrue(graph.RemoveEdge(vertex2, vertex3));
            Assert.IsFalse(graph.RemoveEdge(vertex1, vertex3));
        }

        [Test]
        public void DirectedVertices()
        {
            var graph = new Graph<int>(true);
            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex3, vertex2);
            graph.AddEdge(vertex1, vertex3);

            Assert.AreEqual(graph.Edges.Count, 3);
            Assert.AreEqual(graph.Vertices.Count, 3);

            Assert.IsTrue(graph.RemoveEdge(vertex1, vertex2));

            Assert.AreEqual(graph.Edges.Count, 2);
            Assert.AreEqual(graph.Vertices.Count, 3);

            Assert.IsTrue(graph.RemoveEdge(vertex1, vertex3));

            Assert.AreEqual(graph.Edges.Count, 1);
            Assert.AreEqual(graph.Vertices.Count, 3);
        }

        [Test]
        public void UndirectedVertices()
        {
            var graph = new Graph<int>(false);
            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex3, vertex2);
            graph.AddEdge(vertex1, vertex3);

            Assert.AreEqual(graph.Edges.Count, 3);
            Assert.AreEqual(graph.Vertices.Count, 3);

            Assert.IsTrue(graph.RemoveEdge(vertex1, vertex2));

            Assert.AreEqual(graph.Edges.Count, 2);
            Assert.AreEqual(graph.Vertices.Count, 3);

            Assert.IsTrue(graph.RemoveEdge(vertex3, vertex1));

            Assert.AreEqual(graph.Edges.Count, 1);
            Assert.AreEqual(graph.Vertices.Count, 3);
        }
    }

    [TestFixture]
    public class RemoveVertex : GraphTest
    {
        [Test]
        public void Undirected()
        {
            var graph = new Graph<int>(false);
            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);
            var vertex4 = new Vertex<int>(4);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex3, vertex2);
            graph.AddEdge(vertex1, vertex3);

            Assert.AreEqual(graph.Edges.Count, 3);
            Assert.AreEqual(graph.Vertices.Count, 3);

            Assert.IsTrue(graph.RemoveVertex(vertex1));

            Assert.AreEqual(graph.Edges.Count, 1);
            Assert.AreEqual(graph.Vertices.Count, 2);

            Assert.IsFalse(graph.RemoveVertex(vertex4));

            Assert.AreEqual(graph.Edges.Count, 1);
            Assert.AreEqual(graph.Vertices.Count, 2);

        }

        [Test]
        public void Directed()
        {
            var graph = new Graph<int>(true);
            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);
            var vertex4 = new Vertex<int>(4);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex3, vertex2);
            graph.AddEdge(vertex1, vertex3);

            Assert.AreEqual(graph.Edges.Count, 3);
            Assert.AreEqual(graph.Vertices.Count, 3);

            Assert.IsTrue(graph.RemoveVertex(vertex1));

            Assert.AreEqual(graph.Edges.Count, 1);
            Assert.AreEqual(graph.Vertices.Count, 2);

            Assert.IsFalse(graph.RemoveVertex(vertex4));

            Assert.AreEqual(graph.Edges.Count, 1);
            Assert.AreEqual(graph.Vertices.Count, 2);
        }

        [Test]
        public void UndirectedValue()
        {
            var graph = new Graph<int>(false);
            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex3, vertex2);
            graph.AddEdge(vertex1, vertex3);

            Assert.AreEqual(graph.Edges.Count, 3);
            Assert.AreEqual(graph.Vertices.Count, 3);

            Assert.IsTrue(graph.RemoveVertex(1));

            Assert.AreEqual(graph.Edges.Count, 1);
            Assert.AreEqual(graph.Vertices.Count, 2);

            Assert.IsFalse(graph.RemoveVertex(4));
            Assert.AreEqual(graph.Edges.Count, 1);
            Assert.AreEqual(graph.Vertices.Count, 2);
        }

        [Test]
        public void DirectedValue()
        {
            var graph = new Graph<int>(true);
            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex3, vertex2);
            graph.AddEdge(vertex1, vertex3);

            Assert.AreEqual(graph.Edges.Count, 3);
            Assert.AreEqual(graph.Vertices.Count, 3);

            Assert.IsTrue(graph.RemoveVertex(1));

            Assert.AreEqual(graph.Edges.Count, 1);
            Assert.AreEqual(graph.Vertices.Count, 2);

            Assert.IsFalse(graph.RemoveVertex(4));
            Assert.AreEqual(graph.Edges.Count, 1);
            Assert.AreEqual(graph.Vertices.Count, 2);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVertex()
        {
            var graph = new Graph<int>(true);
            graph.RemoveVertex(null);
        }
    }

    [TestFixture]
    public class Serializable : GraphTest
    {
        [Test]
        public void Simple()
        {
            var graph = GetTestDirectedGraph();
            var copyGraph = SerializeUtil.BinarySerializeDeserialize(graph);

            Assert.AreNotSame(graph, copyGraph);
            Assert.AreEqual(graph.Vertices.Count, copyGraph.Vertices.Count);
            Assert.AreEqual(graph.Edges.Count, copyGraph.Edges.Count);

            var gEnumerator = graph.Edges.GetEnumerator();

            while (gEnumerator.MoveNext())
            {
                var edge = copyGraph.GetEdge(
                    gEnumerator.Current.FromVertex.Data,
                    gEnumerator.Current.ToVertex.Data
                );

                Assert.IsNotNull(edge);
                TestIsCopy(gEnumerator.Current, edge);
            }
        }

        [Test]
        public void VertexAndEdge()
        {
            var graph = new Graph<int>(true);

            var vertex1 = new Vertex<int>(3);

            var vertex2 = new Vertex<int>(4);

            var vertex3 = new Vertex<int>(5);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            graph.AddEdge(vertex2, vertex1);

            vertex2 = SerializeUtil.BinarySerializeDeserialize(vertex1);

            TestIsCopy(vertex1, vertex2);

            Assert.AreEqual(vertex2.IncidentEdges.Count, 1);
            Assert.AreEqual(vertex1.IncidentEdges.Count, 1);

            Assert.AreEqual(vertex2.EmanatingEdges.Count, 0);
            Assert.AreEqual(vertex1.EmanatingEdges.Count, 0);

            TestIsCopy(vertex2.IncidentEdges[0], vertex1.IncidentEdges[0]);
        }

    }

    [TestFixture]
    public class TopologicalSort : GraphTest
    {
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionUndirectedGraph()
        {
            var graph = new Graph<int>(false);
            graph.TopologicalSort();
        }

        [Test]
        public void Simple()
        {
            var graph = new Graph<int>(true);
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);
            var vertex3 = graph.AddVertex(3);
            var vertex4 = graph.AddVertex(4);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex2, vertex3);
            graph.AddEdge(vertex2, vertex4);
            graph.AddEdge(vertex3, vertex4);

            var vertices = graph.TopologicalSort();

            Assert.AreEqual(vertices.Count, 4);
            Assert.AreSame(vertices[0], vertex1);
            Assert.AreSame(vertices[1], vertex2);
            Assert.AreSame(vertices[2], vertex3);
            Assert.AreSame(vertices[3], vertex4);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionTraversalException()
        {
            var graph = new Graph<int>(true);
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);
            var vertex3 = graph.AddVertex(3);
            var vertex4 = graph.AddVertex(4);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex2, vertex3);
            graph.AddEdge(vertex2, vertex4);
            graph.AddEdge(vertex3, vertex4);
            graph.AddEdge(vertex4, vertex1);

            var visitor = new TrackingVisitor<Vertex<int>>();

            graph.TopologicalSortTraversal(visitor);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Exception()
        {
            var graph = new Graph<int>(true);
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);
            var vertex3 = graph.AddVertex(3);
            var vertex4 = graph.AddVertex(4);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex2, vertex3);
            graph.AddEdge(vertex2, vertex4);
            graph.AddEdge(vertex3, vertex4);
            graph.AddEdge(vertex4, vertex1);

            graph.TopologicalSort();
        }
    }

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

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);
            graph.AddVertex(vertex4);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex2, vertex3);
            graph.AddEdge(vertex3, vertex1);
            graph.AddEdge(vertex4, vertex2);

            var vertexList = new List<Vertex<int>>();

            foreach (var vertex in graph.Vertices)
            {
                vertexList.Add(vertex);
            }

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

            Assert.AreEqual(enumeratedVertices.Count, 20);

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

            Assert.AreEqual(enumeratedVertices.Count, 20);

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

                Assert.AreEqual(graph.Vertices.Count, i * 2 + 1);

                graph.AddVertex(i);

                Assert.AreEqual(graph.Vertices.Count, i * 2 + 2);
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

                Assert.AreEqual(graph.Vertices.Count, i * 2 + 1);

                graph.AddVertex(i);

                Assert.AreEqual(graph.Vertices.Count, i * 2 + 2);
            }
        }
    }

    #endregion


}