using System.Collections.Generic;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.RedBlackTreeTests
{
    [TestFixture]
    public class Index : RedBlackTreeTest
    {

        [Test]
        public void Simple()
        {
            var redBlackTree = GetTestTree(20);

            for (var i = 0; i < 20; i++)
            {
                Assert.AreEqual(redBlackTree[i], i.ToString());
            }

            redBlackTree[0] = "50";
            Assert.AreEqual(redBlackTree[0], "50");

            redBlackTree[1] = "-20";
            Assert.AreEqual(redBlackTree[1], "-20");
        }

        [Test]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void ExceptionInvalidIndexSet()
        {
            var redBlackTree = GetTestTree(20);
            redBlackTree[50] = "50";
        }

        [Test]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void ExceptionInvalidIndexGet()
        {
            var redBlackTree = GetTestTree(20);

            for (var i = 0; i < 20; i++)
            {
                Assert.AreEqual(redBlackTree[i], i.ToString());
            }

            var s = redBlackTree[20];
        }
    }
}