using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.RedBlackTreeTests
{
    [TestFixture]
    public class TryGetValue : RedBlackTreeTest
    {

        [Test]
        public void Simple()
        {
            var redBlackTree = new RedBlackTree<int, string>();

            string value;

            for (var i = 0; i < 100; i++)
            {
                redBlackTree.Add(i, i.ToString());

                Assert.AreEqual(redBlackTree.Count, i + 1);
                Assert.IsTrue(redBlackTree.TryGetValue(i, out value));
                Assert.AreEqual(value, i.ToString());
            }


            Assert.IsFalse(redBlackTree.TryGetValue(101, out value));
            Assert.IsNull(value);

            Assert.IsFalse(redBlackTree.TryGetValue(102, out value));
            Assert.IsNull(value);
        }

    }
}