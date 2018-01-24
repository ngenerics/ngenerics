/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using System.Collections.Generic;
using NGenerics.Algorithms;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.Algorithms.Graph.DjikstraTests
{

    [TestFixture]
    public class DijkstrasAlgorithmTests
    {
        [Test]
        public void DirectedSimple()
        {
            var graph = new Graph<int>(true);

            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            graph.AddEdge(vertex1, vertex3, 5);
            graph.AddEdge(vertex1, vertex2, 3);
            graph.AddEdge(vertex2, vertex3, 4);
            graph.AddEdge(vertex3, vertex1, 3);

            var resultGraph = GraphAlgorithms.DijkstrasAlgorithm(graph, vertex1);

            Assert.AreEqual(2, resultGraph.Edges.Count);

            var edges = GetEdgeList(resultGraph.Edges.GetEnumerator());

            foreach (var edge in edges)
            {
                switch (edge.FromVertex.Data)
                {
                    case 1 when (edge.ToVertex.Data == 2):
                        edge.AssertWeights(3, 0, 3);
                        break;
                    case 1 when (edge.ToVertex.Data == 3):
                        edge.AssertWeights(5, 0, 5);
                        break;
                    default:
                        Assert.Fail("Incorrect edge found for shortest path.");
                        break;
                }
            }
        }

        [Test]
        public void DirectedSimple2()
        {
            var graph = new Graph<int>(true);

            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            graph.AddEdge(vertex1, vertex3, 5);
            graph.AddEdge(vertex1, vertex2, 3);
            graph.AddEdge(vertex2, vertex3, 4);
            graph.AddEdge(vertex3, vertex1, 3);

            var resultGraph = GraphAlgorithms.DijkstrasAlgorithm(graph, vertex2);

            Assert.AreEqual(2, resultGraph.Edges.Count);

            var edges = GetEdgeList(resultGraph.Edges.GetEnumerator());

            foreach (var edge in edges)
            {
                switch (edge.FromVertex.Data)
                {
                    case 2 when (edge.ToVertex.Data == 3):
                        edge.AssertWeights(4, 0, 4);
                        break;
                    case 3 when (edge.ToVertex.Data == 1):
                        edge.AssertWeights(3, 4, 7);
                        break;
                    default:
                        Assert.Fail("Incorrect edge found for shortest path.");
                        break;
                }
            }
        }

        [Test]
        public void UndirectedSimple1()
        {
            var graph = new Graph<int>(false);

            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            graph.AddEdge(vertex1, vertex3, 1);
            graph.AddEdge(vertex1, vertex2, 3);
            graph.AddEdge(vertex2, vertex3, 5);

            var resultGraph = GraphAlgorithms.DijkstrasAlgorithm(graph, vertex1);

            Assert.AreEqual(2, resultGraph.Edges.Count);

            var edges = GetEdgeList(resultGraph.Edges.GetEnumerator());

            foreach (var edge in edges)
            {
                switch (edge.FromVertex.Data)
                {
                    case 1 when (edge.ToVertex.Data == 2):
                        edge.AssertWeights(3, 0, 3);
                        break;
                    case 1 when (edge.ToVertex.Data == 3):
                        edge.AssertWeights(1, 0, 1);
                        break;
                    default:
                        Assert.Fail("Incorrect edge found for shortest path.");
                        break;
                }
            }
        }

        [Test]
        public void UndirectedSimple2()
        {
            var graph = new Graph<int>(false);

            var vertex1 = new Vertex<int>(1);
            var vertex2 = new Vertex<int>(2);
            var vertex3 = new Vertex<int>(3);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            graph.AddEdge(vertex1, vertex3, 1);
            graph.AddEdge(vertex1, vertex2, 3);
            graph.AddEdge(vertex2, vertex3, 5);

            var resultGraph = GraphAlgorithms.DijkstrasAlgorithm(graph, vertex2);

            Assert.AreEqual(2, resultGraph.Edges.Count);

            var edges = GetEdgeList(resultGraph.Edges.GetEnumerator());

            foreach (var edge in edges)
            {
                switch (edge.FromVertex.Data)
                {
                    case 2 when (edge.ToVertex.Data == 1):
                        edge.AssertWeights(3, 0, 3);
                        break;
                    case 1 when (edge.ToVertex.Data == 3):
                        edge.AssertWeights(1, 3, 4);
                        break;
                    default:
                        Assert.Fail("Incorrect edge found for shortest path.");
                        break;
                }
            }
        }

        [Test]
        public void Directed2()
        {
            var graph = new Graph<string>(true);

            var vertex1 = new Vertex<string>("a");
            var vertex2 = new Vertex<string>("b");
            var vertex3 = new Vertex<string>("c");
            var vertex4 = new Vertex<string>("d");
            var vertex5 = new Vertex<string>("e");
            var vertex6 = new Vertex<string>("f");

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);
            graph.AddVertex(vertex4);
            graph.AddVertex(vertex5);
            graph.AddVertex(vertex6);

            graph.AddEdge(vertex1, vertex2, 5);
            graph.AddEdge(vertex1, vertex3, 5);
            graph.AddEdge(vertex1, vertex4, 5);
            graph.AddEdge(vertex1, vertex5, 5);
            graph.AddEdge(vertex1, vertex6, 1);

            graph.AddEdge(vertex2, vertex3, 1);

            graph.AddEdge(vertex3, vertex4, 1);

            graph.AddEdge(vertex5, vertex4, 2);

            graph.AddEdge(vertex6, vertex5, 2);
            graph.AddEdge(vertex6, vertex2, 2);

            var resultGraph = GraphAlgorithms.DijkstrasAlgorithm(graph, vertex1);

            Assert.AreEqual(6, resultGraph.Vertices.Count);
            Assert.AreEqual(5, resultGraph.Edges.Count);

            var edges = GetEdgeList(resultGraph.Edges.GetEnumerator());

            foreach (var edge in edges)
            {
                switch (edge.FromVertex.Data)
                {
                    case "a" when (edge.ToVertex.Data == "d"):
                        edge.AssertWeights(5, 0, 5);
                        break;
                    case "a" when (edge.ToVertex.Data == "f"):
                        edge.AssertWeights(1, 0, 1);
                        break;
                    case "b" when (edge.ToVertex.Data == "c"):
                        edge.AssertWeights(1, 3, 4);
                        break;
                    case "f" when (edge.ToVertex.Data == "b"):
                        edge.AssertWeights(2, 1, 3);
                        break;
                    case "f" when (edge.ToVertex.Data == "e"):
                        edge.AssertWeights(2, 1, 3);
                        break;
                    default:
                        Assert.Fail("Incorrect edge found for shortest path.");
                        break;
                }
            }
        }

        [Test]
        public void MoreComplicatedDirectedGraph()
        {
            var graph = new Graph<string>(true);


            var vertex1 = new Vertex<string>("a");
            var vertex2 = new Vertex<string>("b");
            var vertex3 = new Vertex<string>("c");
            var vertex4 = new Vertex<string>("d");
            var vertex5 = new Vertex<string>("e");
            var vertex6 = new Vertex<string>("f");
            var vertex7 = new Vertex<string>("g");

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);
            graph.AddVertex(vertex4);
            graph.AddVertex(vertex5);
            graph.AddVertex(vertex6);
            graph.AddVertex(vertex7);

            graph.AddEdge(vertex1, vertex6, 4);

            graph.AddEdge(vertex2, vertex1, 2);
            graph.AddEdge(vertex2, vertex7, 2);

            graph.AddEdge(vertex3, vertex2, 3);

            graph.AddEdge(vertex4, vertex3, 2);
            graph.AddEdge(vertex4, vertex5, 1);

            graph.AddEdge(vertex5, vertex6, 3);
            graph.AddEdge(vertex5, vertex7, 2);

            graph.AddEdge(vertex6, vertex7, 1);

            graph.AddEdge(vertex7, vertex6, 1);
            graph.AddEdge(vertex7, vertex4, 3);
            graph.AddEdge(vertex7, vertex3, 4);
            graph.AddEdge(vertex7, vertex1, 1);

            var resultGraph = GraphAlgorithms.DijkstrasAlgorithm(graph, vertex7);

            Assert.AreEqual(7, resultGraph.Vertices.Count);
            Assert.AreEqual(6, resultGraph.Edges.Count);

            var edges = GetEdgeList(resultGraph.Edges.GetEnumerator());

            foreach (var edge in edges)
            {
                switch (edge.FromVertex.Data)
                {
                    case "g" when (edge.ToVertex.Data == "a"):
                        edge.AssertWeights(1, 0, 1);
                        break;
                    case "c" when (edge.ToVertex.Data == "b"):
                        edge.AssertWeights(3, 4, 7);
                        break;
                    case "g" when (edge.ToVertex.Data == "c"):
                        edge.AssertWeights(4, 0, 4);
                        break;
                    case "g" when (edge.ToVertex.Data == "d"):
                        edge.AssertWeights(3, 0, 3);
                        break;
                    case "d" when (edge.ToVertex.Data == "e"):
                        edge.AssertWeights(1, 3, 4);
                        break;
                    case "g" when (edge.ToVertex.Data == "f"):
                        edge.AssertWeights(1, 0, 1);
                        break;
                    default:
                        Assert.Fail("Incorrect edge found for shortest path.");
                        break;
                }
            }
        }

        [Test]
        public void ExceptionNullGraph()
        {
            Assert.Throws<ArgumentNullException>(() => GraphAlgorithms.DijkstrasAlgorithm(null, new Vertex<int>(5)));
        }

        [Test]
        public void ExceptionNullVertex()
        {
            Assert.Throws<ArgumentNullException>(() => GraphAlgorithms.DijkstrasAlgorithm(new Graph<int>(true), null));
        }

        [Test]
        public void ExceptionInvalidVertex()
        {
            Assert.Throws<ArgumentException>(() => GraphAlgorithms.DijkstrasAlgorithm(new Graph<int>(true), new Vertex<int>(5)));
        }

        #region Private Members

        private static List<Edge<T>> GetEdgeList<T>(IEnumerator<Edge<T>> edges)
        {
            var edgeList = new List<Edge<T>>();

            while (edges.MoveNext())
            {
                edgeList.Add(edges.Current);
            }
            return edgeList;
        }

        #endregion
    }





}
