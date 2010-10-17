using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.GraphTests
{
    [TestFixture]
    public class IsReadOnly : GraphTest
    {
        [Test]
        public void Simple()
        {
            var graph = new Graph<int>(true);
            Assert.IsFalse(graph.IsReadOnly);

            graph = GetTestDirectedGraph();
            Assert.IsFalse(graph.IsReadOnly);

            graph = GetTestUndirectedGraph();
            Assert.IsFalse(graph.IsReadOnly);
        }
    }
}