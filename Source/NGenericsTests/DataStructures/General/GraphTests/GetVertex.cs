using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.GraphTests
{
    [TestFixture]
    public class GetVertex : GraphTest
    {
        [Test]
        public void Directed()
        {
            var graph = GetTestDirectedGraph();

            for (var i = 0; i < 20; i++)
            {
                var vertex = graph.GetVertex(i);

                Assert.IsNotNull(vertex);
                Assert.AreEqual(vertex.Data, i);
            }

            Assert.IsNull(graph.GetVertex(21));
        }

        [Test]
        public void Undirected()
        {
            var graph = GetTestUndirectedGraph();

            for (var i = 0; i < 20; i++)
            {
                var vertex = graph.GetVertex(i);

                Assert.IsNotNull(vertex);
                Assert.AreEqual(vertex.Data, i);
            }

            Assert.IsNull(graph.GetVertex(21));
        }
    }
}