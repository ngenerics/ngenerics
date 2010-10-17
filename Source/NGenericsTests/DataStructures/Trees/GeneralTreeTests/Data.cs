using System;
using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.GeneralTreeTests
{
    [TestFixture]
    public class Data : GeneralTreeTest
    {

        [Test]
        public void Simple()
        {
            var tree = new GeneralTree<int>(2);

            Assert.AreEqual(tree.Data, 2);

            tree.Data = 5;

            Assert.AreEqual(tree.Data, 5);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionSetNull()
        {
            var tree = new GeneralTree<string>("asdas");
            Assert.AreEqual(tree.Data, "asdas");
            tree.Data = null;
        }

    }
}