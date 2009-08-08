/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using System.Collections.Generic;
using NGenerics.Algorithms;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.Algorithms.Graph
{
    [TestFixture]
    public class PrimTest
    {
        [TestFixture]
        public class PrimsAlgorithm
        {
            [Test]
            public void Simple()
            {
                var graph = new Graph<int>(false);

                var vertexList = new List<Vertex<int>>();

                for (var i = 1; i < 15; i++)
                {
                    vertexList.Add(graph.AddVertex(i));
                }

                AddEdge(graph, vertexList, 1, 2, 5);
                AddEdge(graph, vertexList, 1, 5, 4);
                AddEdge(graph, vertexList, 2, 4, 10);
                AddEdge(graph, vertexList, 2, 3, 6);
                AddEdge(graph, vertexList, 3, 4, 2);
                AddEdge(graph, vertexList, 3, 5, 6);
                AddEdge(graph, vertexList, 3, 7, 4);
                AddEdge(graph, vertexList, 5, 6, 1);
                AddEdge(graph, vertexList, 6, 7, 1);
                AddEdge(graph, vertexList, 6, 8, 9);
                AddEdge(graph, vertexList, 6, 9, 5);
                AddEdge(graph, vertexList, 7, 9, 3);
                AddEdge(graph, vertexList, 7, 10, 4);
                AddEdge(graph, vertexList, 9, 10, 6);
                AddEdge(graph, vertexList, 9, 12, 2);
                AddEdge(graph, vertexList, 11, 12, 9);
                AddEdge(graph, vertexList, 11, 13, 8);
                AddEdge(graph, vertexList, 13, 14, 6);

                var resultGraph = GraphAlgorithms.PrimsAlgorithm(graph, vertexList[0]);

                Assert.IsTrue(resultGraph.ContainsEdge(1, 2));
                Assert.IsTrue(resultGraph.ContainsEdge(1, 5));
                Assert.IsTrue(resultGraph.ContainsEdge(5, 6));
                Assert.IsTrue(resultGraph.ContainsEdge(6, 8));
                Assert.IsTrue(resultGraph.ContainsEdge(6, 7));
                Assert.IsTrue(resultGraph.ContainsEdge(7, 3));
                Assert.IsTrue(resultGraph.ContainsEdge(3, 4));
                Assert.IsTrue(resultGraph.ContainsEdge(7, 9));
                Assert.IsTrue(resultGraph.ContainsEdge(7, 10));
                Assert.IsTrue(resultGraph.ContainsEdge(9, 12));
                Assert.IsTrue(resultGraph.ContainsEdge(12, 11));
                Assert.IsTrue(resultGraph.ContainsEdge(11, 13));
                Assert.IsTrue(resultGraph.ContainsEdge(13, 14));

                Assert.AreEqual(resultGraph.Edges.Count, 13);

                double totalCost = 0;

                foreach (var edge in resultGraph.Edges)
                {
                    totalCost += edge.Weight;
                }

                Assert.AreEqual(totalCost, 58);
            }

            [Test]
            public void Directed()
            {
                var graph = new Graph<int>(true);

                var vertexList = new List<Vertex<int>>();

                for (var i = 1; i < 15; i++)
                {
                    vertexList.Add(graph.AddVertex(i));
                }

                AddEdge(graph, vertexList, 1, 2, 5);
                AddEdge(graph, vertexList, 1, 5, 4);
                AddEdge(graph, vertexList, 2, 4, 10);
                AddEdge(graph, vertexList, 2, 3, 6);
                AddEdge(graph, vertexList, 3, 4, 2);
                AddEdge(graph, vertexList, 3, 5, 6);
                AddEdge(graph, vertexList, 3, 7, 4);
                AddEdge(graph, vertexList, 5, 6, 1);
                AddEdge(graph, vertexList, 6, 7, 1);
                AddEdge(graph, vertexList, 6, 8, 9);
                AddEdge(graph, vertexList, 6, 9, 5);
                AddEdge(graph, vertexList, 7, 9, 3);
                AddEdge(graph, vertexList, 7, 10, 4);
                AddEdge(graph, vertexList, 9, 10, 6);
                AddEdge(graph, vertexList, 9, 12, 2);
                AddEdge(graph, vertexList, 11, 12, 9);
                AddEdge(graph, vertexList, 11, 13, 8);
                AddEdge(graph, vertexList, 13, 14, 6);

                var resultGraph = GraphAlgorithms.PrimsAlgorithm(graph, vertexList[0]);

                Assert.IsTrue(resultGraph.ContainsEdge(1, 2));
                Assert.IsTrue(resultGraph.ContainsEdge(1, 5));
                Assert.IsTrue(resultGraph.ContainsEdge(5, 6));
                Assert.IsTrue(resultGraph.ContainsEdge(6, 8));
                Assert.IsTrue(resultGraph.ContainsEdge(6, 7));
                Assert.IsTrue(resultGraph.ContainsEdge(7, 3));
                Assert.IsTrue(resultGraph.ContainsEdge(3, 4));
                Assert.IsTrue(resultGraph.ContainsEdge(7, 9));
                Assert.IsTrue(resultGraph.ContainsEdge(7, 10));
                Assert.IsTrue(resultGraph.ContainsEdge(9, 12));
                Assert.IsTrue(resultGraph.ContainsEdge(12, 11));
                Assert.IsTrue(resultGraph.ContainsEdge(11, 13));
                Assert.IsTrue(resultGraph.ContainsEdge(13, 14));

                Assert.AreEqual(resultGraph.Edges.Count, 13);

                double totalCost = 0;

                foreach (var edge in resultGraph.Edges)
                {
                    totalCost += edge.Weight;
                }

                Assert.AreEqual(totalCost, 58);
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullGraph()
            {
                GraphAlgorithms.PrimsAlgorithm(null, new Vertex<int>(5));
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullVertex()
            {
                GraphAlgorithms.PrimsAlgorithm(new Graph<int>(true), null);
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void ExceptionInvalidVertex()
            {
                GraphAlgorithms.PrimsAlgorithm(new Graph<int>(true), new Vertex<int>(5));
            }
        }


        #region Private Members

        private static void AddEdge(Graph<int> g, List<Vertex<int>> vertices, int value1, int value2, int weight)
        {
            g.AddEdge(vertices[value1 - 1], vertices[value2 - 1], weight);
        }

        #endregion
    }
}