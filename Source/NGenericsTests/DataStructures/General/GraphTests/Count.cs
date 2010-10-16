using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.GraphTests
{
    [TestFixture]
    public class Count : GraphTest
    {
        [Test]
        public void Directed()
        {
            var graph = new Graph<int>(true);
            ICollection<int> visitableCollection = graph;

            for (var i = 0; i < 20; i++)
            {
                var vertex = new Vertex<int>(i);
                graph.AddVertex(vertex);

                Assert.AreEqual(visitableCollection.Count, i * 2 + 1);

                graph.AddVertex(i);

                Assert.AreEqual(visitableCollection.Count, i * 2 + 2);
            }
        }

        [Test]
        public void Undirected()
        {
            var graph = new Graph<int>(false);
            ICollection<int> c = graph;

            for (var i = 0; i < 20; i++)
            {
                var vertex = new Vertex<int>(i);
                graph.AddVertex(vertex);

                Assert.AreEqual(c.Count, i * 2 + 1);

                graph.AddVertex(i);

                Assert.AreEqual(c.Count, i * 2 + 2);
            }
        }
    }
}