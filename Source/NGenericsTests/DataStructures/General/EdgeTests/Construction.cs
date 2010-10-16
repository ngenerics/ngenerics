using System;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.EdgeTests
{
    [TestFixture]
    public class Construction
    {
        [Test]
        public void Edge()
        {
            var vertex1 = new Vertex<int>(6);
            var vertex2 = new Vertex<int>(4);

            var edge = new Edge<int>(vertex1, vertex2, true);
            Assert.AreEqual(edge.FromVertex, vertex1);
            Assert.AreEqual(edge.ToVertex, vertex2);
            Assert.AreEqual(edge.Weight, 0);

            edge = new Edge<int>(vertex1, vertex2, 55, true);
            Assert.AreEqual(edge.FromVertex, vertex1);
            Assert.AreEqual(edge.ToVertex, vertex2);
            Assert.AreEqual(edge.Weight, 55);

            edge = new Edge<int>(vertex1, vertex2, -2, true);
            Assert.AreEqual(edge.FromVertex, vertex1);
            Assert.AreEqual(edge.ToVertex, vertex2);
            Assert.AreEqual(edge.Weight, -2);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullFromVertexDirected()
        {
            new Edge<int>(null, new Vertex<int>(4), true);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullToVertexDirected()
        {
            new Edge<int>(new Vertex<int>(4), null, true);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullFromVertexUndirected()
        {
            new Edge<int>(null, new Vertex<int>(4), false);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullToVertexUndirected()
        {
            new Edge<int>(new Vertex<int>(4), null, false);
        }
    }
}