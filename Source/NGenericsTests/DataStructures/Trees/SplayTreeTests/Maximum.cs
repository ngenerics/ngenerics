using System;
using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.SplayTreeTests
{
    [TestFixture]
    public class Maximum : SplayTreeTest
    {

        [Test]
        public void Simple()
        {
            var splayTree = GetTestTree();
            var i = splayTree.Maximum;

            Assert.AreEqual(i.Key, 19);
            Assert.AreEqual(i.Value, "19");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionEmpty()
        {
            var splayTree = new SplayTree<int, string>();
            var i = splayTree.Maximum;
        }

    }
}