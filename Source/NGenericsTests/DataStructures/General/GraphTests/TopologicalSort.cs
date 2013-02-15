/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using NGenerics.DataStructures.General;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.GraphTests
{
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
}