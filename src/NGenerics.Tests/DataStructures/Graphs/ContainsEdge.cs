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
}