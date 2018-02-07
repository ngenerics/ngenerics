/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NGenerics.DataStructures.Graphs;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Graphs
{
    [TestFixture]
    public class IsStronglyConnected : GraphTest
    {
        [Test]
        public void ExceptionEmptyDirected()
        {
            var graph = new Graph<int>(true);
            Assert.Throws<InvalidOperationException>(() => graph.IsStronglyConnected());
        }

        [Test]
        public void ExceptionEmptyUndirected()
        {
            var graph = new Graph<int>(false);
            Assert.Throws<InvalidOperationException>(() => graph.IsStronglyConnected());
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
}