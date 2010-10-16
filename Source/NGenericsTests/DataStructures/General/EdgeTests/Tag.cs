using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.EdgeTests
{
    [TestFixture]
    public class Tag
    {
        [Test]
        public void Simple()
        {
            var edge = new Edge<int>(new Vertex<int>(5), new Vertex<int>(4), true);
            Assert.IsNull(edge.Tag);

            const string tag = "NGenerics";

            edge.Tag = tag;

            Assert.AreSame(edge.Tag, tag);
        }
    }
}