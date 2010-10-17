using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.VertexTests
{
    [TestFixture]
    public class Data:VertexTest
    {
        [Test]
        public void Simple()
        {
            var vertex = new Vertex<int>(5);
            Assert.AreEqual(vertex.Data, 5);

            vertex.Data = 2;
            Assert.AreEqual(vertex.Data, 2);

            vertex.Data = 10;
            Assert.AreEqual(vertex.Data, 10);
        }
    }
}