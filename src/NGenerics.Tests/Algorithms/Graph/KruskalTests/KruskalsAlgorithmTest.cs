/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/


using System;
using System.Collections.Generic;
using System.Linq;
using NGenerics.Algorithms;
using NGenerics.DataStructures.Graphs;
using NUnit.Framework;

namespace NGenerics.Tests.Algorithms.Graph.KruskalTests
{
    [TestFixture]
    public class KruskalsAlgorithmTest
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

            var resultGraph = GraphAlgorithms.KruskalsAlgorithm(graph);


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

            Assert.AreEqual(13, resultGraph.Edges.Count);

            double totalCost = 0;

            foreach (var edge in resultGraph.Edges)
            {
                totalCost += edge.Weight;
            }

            Assert.AreEqual(58, totalCost);
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

            var resultGraph = GraphAlgorithms.KruskalsAlgorithm(graph);


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

            Assert.AreEqual(13, resultGraph.Edges.Count);

            double totalCost = 0;

            foreach (var edge in resultGraph.Edges)
            {
                totalCost += edge.Weight;
            }

            Assert.AreEqual(58, totalCost);
        }

        [Test]
        public void Undirected()
        {
            var graph = new Graph<int>(false);

            var vertexList = new List<Vertex<int>>();

            for (var i = 1; i < 7; i++)
            {
                vertexList.Add(graph.AddVertex(i));
            }

            /*            
             
             * a = 1
             * b = 2
             * c = 3
             * d = 4
             * e = 5
             * f = 6                          
              
            */

            // a
            AddEdge(graph, vertexList, 1, 4, 1);
            AddEdge(graph, vertexList, 1, 2, 13);
            AddEdge(graph, vertexList, 1, 3, 8);

            // b
            AddEdge(graph, vertexList, 2, 3, 15);

            // c
            AddEdge(graph, vertexList, 3, 4, 5);
            AddEdge(graph, vertexList, 3, 5, 3);

            // d
            AddEdge(graph, vertexList, 4, 5, 4);
            AddEdge(graph, vertexList, 4, 6, 5);

            // e
            AddEdge(graph, vertexList, 5, 6, 2);

            var resultGraph = GraphAlgorithms.KruskalsAlgorithm(graph);

            Assert.IsTrue(resultGraph.ContainsEdge(1, 2));
            Assert.IsTrue(resultGraph.ContainsEdge(1, 4));
            Assert.IsTrue(resultGraph.ContainsEdge(3, 5));
            Assert.IsTrue(resultGraph.ContainsEdge(4, 5));
            Assert.IsTrue(resultGraph.ContainsEdge(5, 6));

            Assert.AreEqual(5, resultGraph.Edges.Count);

            double totalCost = resultGraph.Edges.Sum(edge => edge.Weight);

            Assert.AreEqual(23, totalCost);
        }


        [Test]
        public void ExceptionNullGraph()
        {
            Assert.Throws<ArgumentNullException>(() => GraphAlgorithms.KruskalsAlgorithm<int>(null));
        }

        #region Private Members

        private static void AddEdge(Graph<int> graph, IList<Vertex<int>> vertices, int value1, int value2, int weight)
        {
            graph.AddEdge(vertices[value1 - 1], vertices[value2 - 1], weight);
        }

        #endregion
    }


}