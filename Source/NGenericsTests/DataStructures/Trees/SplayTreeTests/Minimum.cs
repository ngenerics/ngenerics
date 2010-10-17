using System;
using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.SplayTreeTests
{
    [TestFixture]
    public class Minimum : SplayTreeTest
    {

        [Test]
        public void Simple()
        {
            var splayTree = GetTestTree();
            var i = splayTree.Minimum;

            Assert.AreEqual(i.Key, 1);
            Assert.AreEqual(i.Value, "1");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionEmpty()
        {
            var splayTree = new SplayTree<int, string>();
            var i = splayTree.Minimum;
        }

    }
}