using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.VertexTests
{
    [TestFixture]
    public class Construction:VertexTest
    {
        [Test]
        public void Simple()
        {
            var vertex = new Vertex<int>(4);
            Assert.AreEqual(vertex.Data, 4);
            Assert.AreEqual(vertex.Degree, 0);
            Assert.AreEqual(vertex.IncidentEdges.Count, 0);
            Assert.AreEqual(vertex.Weight, 0);

            vertex = new Vertex<int>(999);
            Assert.AreEqual(vertex.Data, 999);
            Assert.AreEqual(vertex.Degree, 0);
            Assert.AreEqual(vertex.IncidentEdges.Count, 0);
            Assert.AreEqual(vertex.Weight, 0);

            vertex = new Vertex<int>(4, 6.2);
            Assert.AreEqual(vertex.Data, 4);
            Assert.AreEqual(vertex.Degree, 0);
            Assert.AreEqual(vertex.IncidentEdges.Count, 0);
            Assert.AreEqual(vertex.Weight, 6.2);

            vertex = new Vertex<int>(999, 32.45);
            Assert.AreEqual(vertex.Data, 999);
            Assert.AreEqual(vertex.Degree, 0);
            Assert.AreEqual(vertex.IncidentEdges.Count, 0);
            Assert.AreEqual(vertex.Weight, 32.45);

            vertex.Weight = 55;
            Assert.AreEqual(vertex.Weight, 55);
        }

    }
}