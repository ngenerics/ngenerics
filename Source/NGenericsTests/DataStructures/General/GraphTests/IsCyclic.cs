using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.GraphTest
{
    [TestFixture]
    public class IsCyclic : GraphTests.GraphTest
    {
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

            Assert.IsFalse(graph.IsCyclic());

            // Add a cycle
            graph.AddEdge(vertex4, vertex1);

            Assert.IsTrue(graph.IsCyclic());

            // Remove the cycle again
            graph.RemoveEdge(vertex4, vertex1);

            Assert.IsFalse(graph.IsCyclic());

            // Add a cycle again
            graph.AddEdge(vertex2, vertex1);

            Assert.IsTrue(graph.IsCyclic());

            // Remove the cycle
            graph.RemoveEdge(vertex2, vertex1);

            Assert.IsFalse(graph.IsCyclic());
        }
    }
}