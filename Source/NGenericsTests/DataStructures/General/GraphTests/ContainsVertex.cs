using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.GraphTests
{
    [TestFixture]
    public class ContainsVertex : GraphTest
    {
        [Test]
        public void Simple()
        {
            var graph = new Graph<int>(false);

            for (var i = 0; i < 20; i++)
            {
                var vertex = new Vertex<int>(i);
                graph.AddVertex(vertex);

                Assert.IsTrue(graph.ContainsVertex(i));
                Assert.IsTrue(graph.ContainsVertex(vertex));
            }

            Assert.IsFalse(graph.ContainsVertex(new Vertex<int>(3)));
            Assert.IsFalse(graph.ContainsVertex(21));
        }
    }
}