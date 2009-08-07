using System;
using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General
{
    [TestFixture]
    public class VertexTest
    {
        #region Tests

        [TestFixture]
		public class Construction
		{
            [Test]
			public void Simple()
			{
				var vertex = new Vertex<int>(4);
				Assert.AreEqual(vertex.Data, 4);
				Assert.AreEqual(vertex.Degree, 0);
				Assert.AreEqual(vertex.IncidentEdges.Count, 0);
				Assert.AreEqual(vertex.Weight, 0);

				vertex = new Vertex<int>(999);
				Assert.AreEqual(vertex.Data, 999);
				Assert.AreEqual(vertex.Degree, 0);
				Assert.AreEqual(vertex.IncidentEdges.Count, 0);
				Assert.AreEqual(vertex.Weight, 0);

				vertex = new Vertex<int>(4, 6.2);
				Assert.AreEqual(vertex.Data, 4);
				Assert.AreEqual(vertex.Degree, 0);
				Assert.AreEqual(vertex.IncidentEdges.Count, 0);
				Assert.AreEqual(vertex.Weight, 6.2);

				vertex = new Vertex<int>(999, 32.45);
				Assert.AreEqual(vertex.Data, 999);
				Assert.AreEqual(vertex.Degree, 0);
				Assert.AreEqual(vertex.IncidentEdges.Count, 0);
				Assert.AreEqual(vertex.Weight, 32.45);

				vertex.Weight = 55;
				Assert.AreEqual(vertex.Weight, 55);
			}

		}

        [TestFixture]
        public class Data
        {
            [Test]
			public void Simple()
            {
                var vertex = new Vertex<int>(5);
                Assert.AreEqual(vertex.Data, 5);

                vertex.Data = 2;
                Assert.AreEqual(vertex.Data, 2);

                vertex.Data = 10;
                Assert.AreEqual(vertex.Data, 10);
            }
        }

		[TestFixture]
		public class EmanatingEdges
		{
			[Test]
			[ExpectedException(typeof(NotSupportedException))]
			public void ExceptionReadOnly()
			{
				var vertex1 = new Vertex<int>(5);
				var vertex2 = new Vertex<int>(5);
				vertex1.EmanatingEdges.Add(new Edge<int>(vertex1, vertex2, false));
			}

            [Test]
            public void Undirected()
            {
                var vertex1 = new Vertex<int>(3);
                var vertex2 = new Vertex<int>(5);
                var vertex3 = new Vertex<int>(8);

                var graph = new Graph<int>(false);
                graph.AddVertex(vertex1);
                graph.AddVertex(vertex2);
                graph.AddVertex(vertex3);

                graph.AddEdge(vertex1, vertex2);
                graph.AddEdge(vertex3, vertex1);

                var edgeList = vertex1.EmanatingEdges;

                Assert.AreEqual(edgeList.Count, 2);

                AssertContainsEdges(edgeList, true,
                    vertex1.GetEmanatingEdgeTo(vertex2),
                    vertex1.GetEmanatingEdgeTo(vertex3),
                    vertex3.GetEmanatingEdgeTo(vertex1));
            }

            [Test]
            public void UndirectedEnumerator()
            {
                var vertex1 = new Vertex<int>(3);
                var vertex2 = new Vertex<int>(5);
                var vertex3 = new Vertex<int>(8);

                var graph = new Graph<int>(false);
                graph.AddVertex(vertex1);
                graph.AddVertex(vertex2);
                graph.AddVertex(vertex3);

                graph.AddEdge(vertex1, vertex2);
                graph.AddEdge(vertex3, vertex1);

                var edgeList = vertex1.EmanatingEdges;

                foreach (var edge in edgeList)
                {
                    Console.WriteLine(edge.Weight);
                }

                Assert.AreEqual(edgeList.Count, 2);

                AssertContainsEdges(edgeList, true,
                    vertex1.GetEmanatingEdgeTo(vertex2),
                    vertex1.GetEmanatingEdgeTo(vertex3),
                    vertex3.GetEmanatingEdgeTo(vertex1));
            }

            [Test]
            public void Directed()
            {
                var vertex1 = new Vertex<int>(3);
                var vertex2 = new Vertex<int>(5);
                var vertex3 = new Vertex<int>(8);

                var graph = new Graph<int>(true);
                graph.AddVertex(vertex1);
                graph.AddVertex(vertex2);
                graph.AddVertex(vertex3);

                graph.AddEdge(vertex1, vertex2);
                graph.AddEdge(vertex3, vertex1);

                var edgeList = vertex3.EmanatingEdges;

                Assert.AreEqual(edgeList.Count, 1);
                AssertContainsEdges(edgeList, true,
                    vertex3.GetEmanatingEdgeTo(vertex1)
                );

                edgeList = vertex1.EmanatingEdges;

                Assert.AreEqual(edgeList.Count, 1);
                AssertContainsEdges(edgeList, true,
                    vertex1.GetEmanatingEdgeTo(vertex2)
                );
            }
		}

        [TestFixture]
        public class GetEmanatingEdgeTo
        {
            [Test]
            public void Undirected()
            {
                var vertex1 = new Vertex<int>(3);
                var vertex2 = new Vertex<int>(5);
                var vertex3 = new Vertex<int>(8);

                var graph = new Graph<int>(false);
                graph.AddVertex(vertex1);
                graph.AddVertex(vertex2);

                graph.AddEdge(vertex1, vertex2);

                var edge = vertex1.GetEmanatingEdgeTo(vertex2);
                Assert.AreEqual(edge.FromVertex, vertex1);
                Assert.AreEqual(edge.ToVertex, vertex2);

                edge = vertex2.GetEmanatingEdgeTo(vertex1);
                Assert.AreEqual(edge.FromVertex, vertex1);
                Assert.AreEqual(edge.ToVertex, vertex2);

                Assert.IsNull(vertex1.GetEmanatingEdgeTo(vertex3));
            }

            [Test]
            public void Directed()
            {
                var vertex1 = new Vertex<int>(3);
                var vertex2 = new Vertex<int>(5);
                var vertex3 = new Vertex<int>(8);

                var graph = new Graph<int>(true);
                graph.AddVertex(vertex1);
                graph.AddVertex(vertex2);

                graph.AddEdge(vertex1, vertex2);

                var edge = vertex1.GetEmanatingEdgeTo(vertex2);
                Assert.AreEqual(edge.FromVertex, vertex1);
                Assert.AreEqual(edge.ToVertex, vertex2);

                edge = vertex2.GetEmanatingEdgeTo(vertex1);
                Assert.IsNull(edge);
                Assert.IsNull(vertex1.GetEmanatingEdgeTo(vertex3));
            }
        }

        [TestFixture]
        public class GetIncidentEdgeWith
        {
            [Test]
            public void Undirected()
            {
                var vertex1 = new Vertex<int>(3);
                var vertex2 = new Vertex<int>(5);
                var vertex3 = new Vertex<int>(8);

                var graph = new Graph<int>(false);
                graph.AddVertex(vertex1);
                graph.AddVertex(vertex2);

                graph.AddEdge(vertex1, vertex2);

                var edge = vertex1.GetIncidentEdgeWith(vertex2);
                Assert.AreEqual(edge.FromVertex, vertex1);
                Assert.AreEqual(edge.ToVertex, vertex2);

                edge = vertex2.GetIncidentEdgeWith(vertex1);
                Assert.AreEqual(edge.FromVertex, vertex1);
                Assert.AreEqual(edge.ToVertex, vertex2);

                Assert.IsNull(vertex1.GetIncidentEdgeWith(vertex3));
            }

            [Test]
            public void Directed()
            {
                var vertex1 = new Vertex<int>(3);
                var vertex2 = new Vertex<int>(5);
                var vertex3 = new Vertex<int>(8);

                var graph = new Graph<int>(true);
                graph.AddVertex(vertex1);
                graph.AddVertex(vertex2);

                graph.AddEdge(vertex1, vertex2);

                var edge = vertex1.GetIncidentEdgeWith(vertex2);
                Assert.AreEqual(edge.FromVertex, vertex1);
                Assert.AreEqual(edge.ToVertex, vertex2);

                edge = vertex2.GetIncidentEdgeWith(vertex1);
                Assert.AreEqual(edge.FromVertex, vertex1);
                Assert.AreEqual(edge.ToVertex, vertex2);

                Assert.IsNull(vertex1.GetIncidentEdgeWith(vertex3));
            }
        }

        [TestFixture]
        public class GetPartnerVertex
        {
            [Test]
			public void Simple()
            {
                var graph = new Graph<int>(false);
                var vertex1 = new Vertex<int>(1);
                var vertex2 = new Vertex<int>(2);
                var vertex3 = new Vertex<int>(3);

                graph.AddVertex(vertex1);
                graph.AddVertex(vertex2);
                graph.AddVertex(vertex3);

                var v1v2 = graph.AddEdge(vertex1, vertex2);
                var v3v2 = graph.AddEdge(vertex3, vertex2);

                Assert.AreEqual(v1v2.GetPartnerVertex(vertex1), vertex2);
                Assert.AreEqual(v1v2.GetPartnerVertex(vertex2), vertex1);

                Assert.AreEqual(v3v2.GetPartnerVertex(vertex2), vertex3);
                Assert.AreEqual(v3v2.GetPartnerVertex(vertex3), vertex2);
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void ExceptionVertexNotPartOfEdge()
            {
                var graph = new Graph<int>(false);
                var vertex1 = new Vertex<int>(1);
                var vertex2 = new Vertex<int>(2);
                var vertex3 = new Vertex<int>(3);

                graph.AddVertex(vertex1);
                graph.AddVertex(vertex2);
                graph.AddVertex(vertex3);

                var edge = graph.AddEdge(vertex1, vertex2);

                edge.GetPartnerVertex(vertex3);
            }
        }

		[TestFixture]
		public class IncidentEdges
		{
            [Test]
            public void Directed()
            {
                var vertex1 = new Vertex<int>(3);
                var vertex2 = new Vertex<int>(5);
                var vertex3 = new Vertex<int>(8);

                var graph = new Graph<int>(true);
                graph.AddVertex(vertex1);
                graph.AddVertex(vertex2);
                graph.AddVertex(vertex3);

                graph.AddEdge(vertex1, vertex2);
                graph.AddEdge(vertex3, vertex1);

                var edgeList = vertex3.IncidentEdges;

                Assert.AreEqual(edgeList.Count, 1);
                AssertContainsEdges(edgeList, true,
                    vertex3.GetEmanatingEdgeTo(vertex1)
                );

                edgeList = vertex1.IncidentEdges;

                Assert.AreEqual(edgeList.Count, 2);

                AssertContainsEdges(edgeList, true,
                    vertex1.GetEmanatingEdgeTo(vertex2),
                    vertex3.GetEmanatingEdgeTo(vertex1)
                );
            }

            [Test]
            public void DirectedEnumerator()
            {
                var vertex1 = new Vertex<int>(3);
                var vertex2 = new Vertex<int>(5);
                var vertex3 = new Vertex<int>(8);

                var graph = new Graph<int>(true);
                graph.AddVertex(vertex1);
                graph.AddVertex(vertex2);
                graph.AddVertex(vertex3);

                graph.AddEdge(vertex1, vertex2);
                graph.AddEdge(vertex3, vertex1);

                var edgeList = vertex3.IncidentEdges;

                foreach (var edge in edgeList)
                {
                    Console.Write(edge.Weight.ToString());
                }

                Assert.AreEqual(edgeList.Count, 1);
                AssertContainsEdges(edgeList, true,
                    vertex3.GetEmanatingEdgeTo(vertex1)
                );

                edgeList = vertex1.IncidentEdges;

                Assert.AreEqual(edgeList.Count, 2);

                AssertContainsEdges(edgeList, true,
                    vertex1.GetEmanatingEdgeTo(vertex2),
                    vertex3.GetEmanatingEdgeTo(vertex1)
                );
            }

            [Test]
            public void Undirected()
            {
                var vertex1 = new Vertex<int>(3);
                var vertex2 = new Vertex<int>(5);
                var vertex3 = new Vertex<int>(8);

                var graph = new Graph<int>(false);
                graph.AddVertex(vertex1);
                graph.AddVertex(vertex2);
                graph.AddVertex(vertex3);

                graph.AddEdge(vertex1, vertex2);
                graph.AddEdge(vertex3, vertex1);

                var edgeList = vertex3.IncidentEdges;

                Assert.AreEqual(edgeList.Count, 1);
                AssertContainsEdges(edgeList, true,
                    vertex3.GetEmanatingEdgeTo(vertex1)
                );

                edgeList = vertex1.IncidentEdges;

                Assert.AreEqual(edgeList.Count, 2);
                AssertContainsEdges(edgeList, true,
                    vertex1.GetEmanatingEdgeTo(vertex2),
                    vertex3.GetEmanatingEdgeTo(vertex1)
                );
            }

			[Test]
			[ExpectedException(typeof(NotSupportedException))]
			public void ExceptionReadOnly()
			{
				var vertex1 = new Vertex<int>(5);
				var vertex2 = new Vertex<int>(5);
				vertex1.IncidentEdges.Add(new Edge<int>(vertex1, vertex2, false));
			}

        }

        #endregion

        #region Private Members

        private static void AssertContainsEdges(ICollection<Edge<int>> edgeList, bool containsValue, params Edge<int>[] edges)
        {
            for (var i = 0; i < edges.Length; i++)
            {
                Assert.AreEqual(edgeList.Contains(edges[i]), containsValue);
            }
        }

        #endregion
    }
}
