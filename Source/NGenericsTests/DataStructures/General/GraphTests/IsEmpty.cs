using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.GraphTests
{
    [TestFixture]
    public class IsEmpty : GraphTest
    {
        [Test]
        public void Simple()
        {
            var graph = new Graph<int>(true);
            Assert.IsTrue(graph.IsEmpty);

            graph.AddVertex(5);
            Assert.IsFalse(graph.IsEmpty);

            graph.AddVertex(3);
            Assert.IsFalse(graph.IsEmpty);

            graph.Clear();
            Assert.IsTrue(graph.IsEmpty);
        }
    }
}