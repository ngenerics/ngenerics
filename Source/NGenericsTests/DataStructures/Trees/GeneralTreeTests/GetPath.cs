using System;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.GeneralTreeTests
{
    [TestFixture]
    public class GetPath : GeneralTreeTest
    {
        [Test]
        public void Simple()
        {
            var tree = GetTestTree();
            var data = tree[0][0].GetPath();

            Assert.AreEqual(data[0], tree);
            Assert.AreEqual(data[1], tree[0]);
        }

        [Test]
        public void SimpleWithConverter()
        {
            var tree = GetTestTree();
            var data = tree[0][0].GetPath(x => x.Data);

            Assert.AreEqual(data[0], 5);
            Assert.AreEqual(data[1], 2);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullConverter()
        {
            var tree = GetTestTree();
            tree.GetPath<int>(null);
        }
    }
}