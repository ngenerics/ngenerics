/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.General;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.GraphTests
{
    [TestFixture]
    public class Serializable : GraphTest
    {
        [Test]
        public void Simple()
        {
            var graph = GetTestDirectedGraph();
            var copyGraph = SerializeUtil.BinarySerializeDeserialize(graph);

            Assert.AreNotSame(graph, copyGraph);
            Assert.AreEqual(graph.Vertices.Count, copyGraph.Vertices.Count);
            Assert.AreEqual(graph.Edges.Count, copyGraph.Edges.Count);

            var gEnumerator = graph.Edges.GetEnumerator();

            while (gEnumerator.MoveNext())
            {
                var edge = copyGraph.GetEdge(
                    gEnumerator.Current.FromVertex.Data,
                    gEnumerator.Current.ToVertex.Data
                    );

                Assert.IsNotNull(edge);
                TestIsCopy(gEnumerator.Current, edge);
            }
        }

        [Test]
        public void VertexAndEdge()
        {
            var graph = new Graph<int>(true);

            var vertex1 = new Vertex<int>(3);

            var vertex2 = new Vertex<int>(4);

            var vertex3 = new Vertex<int>(5);

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);

            graph.AddEdge(vertex2, vertex1);

            vertex2 = SerializeUtil.BinarySerializeDeserialize(vertex1);

            TestIsCopy(vertex1, vertex2);

            Assert.AreEqual(vertex2.IncidentEdges.Count, 1);
            Assert.AreEqual(vertex1.IncidentEdges.Count, 1);

            Assert.AreEqual(vertex2.EmanatingEdges.Count, 0);
            Assert.AreEqual(vertex1.EmanatingEdges.Count, 0);

            TestIsCopy(vertex2.IncidentEdges[0], vertex1.IncidentEdges[0]);
        }

    }
}