using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.GraphTests
{
    [TestFixture]
    public class IsDirected : GraphTest
    {
        [Test]
        public void Simple()
        {
            var graph = new Graph<int>(true);
            Assert.IsTrue(graph.IsDirected);

            graph = new Graph<int>(false);
            Assert.IsFalse(graph.IsDirected);
        }
    }
}