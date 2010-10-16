/*  
  Copyright 2007-2010 The NGenerics Team
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


            Assert.AreEqual(resultGraph.ContainsEdge(1, 2), true);
            Assert.AreEqual(resultGraph.ContainsEdge(1, 5), true);
            Assert.AreEqual(resultGraph.ContainsEdge(5, 6), true);
            Assert.AreEqual(resultGraph.ContainsEdge(6, 8), true);
            Assert.AreEqual(resultGraph.ContainsEdge(6, 7), true);
            Assert.AreEqual(resultGraph.ContainsEdge(7, 3), true);
            Assert.AreEqual(resultGraph.ContainsEdge(3, 4), true);
            Assert.AreEqual(resultGraph.ContainsEdge(7, 9), true);
            Assert.AreEqual(resultGraph.ContainsEdge(7, 10), true);
            Assert.AreEqual(resultGraph.ContainsEdge(9, 12), true);
            Assert.AreEqual(resultGraph.ContainsEdge(12, 11), true);
            Assert.AreEqual(resultGraph.ContainsEdge(11, 13), true);
            Assert.AreEqual(resultGraph.ContainsEdge(13, 14), true);

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

            var resultGraph = GraphAlgorithms.KruskalsAlgorithm(graph);


            Assert.AreEqual(resultGraph.ContainsEdge(1, 2), true);
            Assert.AreEqual(resultGraph.ContainsEdge(1, 5), true);
            Assert.AreEqual(resultGraph.ContainsEdge(5, 6), true);
            Assert.AreEqual(resultGraph.ContainsEdge(6, 8), true);
            Assert.AreEqual(resultGraph.ContainsEdge(6, 7), true);
            Assert.AreEqual(resultGraph.ContainsEdge(7, 3), true);
            Assert.AreEqual(resultGraph.ContainsEdge(3, 4), true);
            Assert.AreEqual(resultGraph.ContainsEdge(7, 9), true);
            Assert.AreEqual(resultGraph.ContainsEdge(7, 10), true);
            Assert.AreEqual(resultGraph.ContainsEdge(9, 12), true);
            Assert.AreEqual(resultGraph.ContainsEdge(12, 11), true);
            Assert.AreEqual(resultGraph.ContainsEdge(11, 13), true);
            Assert.AreEqual(resultGraph.ContainsEdge(13, 14), true);

            Assert.AreEqual(resultGraph.Edges.Count, 13);

            double totalCost = 0;

            foreach (var edge in resultGraph.Edges)
            {
                totalCost += edge.Weight;
            }

            Assert.AreEqual(totalCost, 58);
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

            Assert.AreEqual(resultGraph.ContainsEdge(1, 2), true);
            Assert.AreEqual(resultGraph.ContainsEdge(1, 4), true);
            Assert.AreEqual(resultGraph.ContainsEdge(3, 5), true);
            Assert.AreEqual(resultGraph.ContainsEdge(4, 5), true);
            Assert.AreEqual(resultGraph.ContainsEdge(5, 6), true);

            Assert.AreEqual(resultGraph.Edges.Count, 5);

            double totalCost = 0;

            foreach (var edge in resultGraph.Edges)
            {
                totalCost += edge.Weight;
            }

            Assert.AreEqual(totalCost, 23);
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullGraph()
        {
            GraphAlgorithms.KruskalsAlgorithm<int>(null);
        }

        #region Private Members

        private static void AddEdge(Graph<int> graph, IList<Vertex<int>> vertices, int value1, int value2, int weight)
        {
            graph.AddEdge(vertices[value1 - 1], vertices[value2 - 1], weight);
        }

        #endregion
    }


}