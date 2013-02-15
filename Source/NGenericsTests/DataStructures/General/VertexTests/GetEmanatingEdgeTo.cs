/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.VertexTests
{
    [TestFixture]
    public class GetEmanatingEdgeTo:VertexTest
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
}