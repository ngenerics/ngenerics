using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.GraphTest
{
    [TestFixture]
    public class Remove : GraphTests.GraphTest
    {
        [Test]
        public void Interface()
        {
            var graph = new Graph<int>(true);
            ((ICollection<int>)graph).Add(4);
            Assert.AreEqual(graph.Vertices.Count, 1);

            Assert.IsTrue(((ICollection<int>)graph).Remove(4));
            Assert.AreEqual(graph.Vertices.Count, 0);
            Assert.IsFalse(((ICollection<int>)graph).Remove(3));
            Assert.AreEqual(graph.Vertices.Count, 0);
        }
    }
}