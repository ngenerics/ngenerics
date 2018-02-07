/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.DataStructures.Graphs;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Graphs
{
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
}