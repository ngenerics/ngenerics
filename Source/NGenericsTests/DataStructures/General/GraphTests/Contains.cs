using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.GraphTests
{
    [TestFixture]
    public class Contains : GraphTest
    {
        [Test]
        public void Interface()
        {
            var graph = new Graph<int>(true);
            ((ICollection<int>)graph).Add(4);
            Assert.AreEqual(graph.Vertices.Count, 1);

            Assert.IsTrue(((ICollection<int>)graph).Contains(4));
            Assert.IsFalse(((ICollection<int>)graph).Contains(3));
        }
    }
}