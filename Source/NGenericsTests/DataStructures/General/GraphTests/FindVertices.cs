using System;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.GraphTests
{
    [TestFixture]
    public class FindVertices : GraphTest
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullPredicateDirected()
        {
            var graph = GetTestDirectedGraph();
            graph.FindVertices(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullPredicateUndirected()
        {
            var graph = GetTestUndirectedGraph();
            graph.FindVertices(null);
        }

        [Test]
        public void Directed()
        {
            var graph = GetTestDirectedGraph();

            var list = graph.FindVertices(value => value == 5 || value == 10);

            Assert.AreEqual(list.Count, 2);
            Assert.IsTrue(((list[0].Data == 5) || (list[0].Data == 10)));
            Assert.IsTrue(((list[1].Data == 5) || (list[1].Data == 10)));
            Assert.AreNotEqual(list[0].Data, list[1].Data);
        }

        [Test]
        public void Undirected()
        {
            var graph = GetTestUndirectedGraph();

            var list = graph.FindVertices(value => value == 5 || value == 10);

            Assert.AreEqual(list.Count, 2);
            Assert.IsTrue(((list[0].Data == 5) || (list[0].Data == 10)));
            Assert.IsTrue(((list[1].Data == 5) || (list[1].Data == 10)));
            Assert.AreNotEqual(list[0].Data, list[1].Data);
        }
    }
}