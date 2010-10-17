using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinarySearchTreeTests
{
    [TestFixture]
    public class Keys : BinarySearchTreeTest
    {

        [Test]
        public void Simple()
        {
            var tree = new BinarySearchTree<int, string>();

            for (var i = 20; i > 10; i--)
            {
                tree.Add(i, i.ToString());
            }

            for (var i = 0; i <= 10; i++)
            {
                tree.Add(i, i.ToString());
            }

            var keys = tree.Keys;

            for (var i = 0; i <= 20; i++)
            {
                Assert.IsTrue(keys.Contains(i));
            }

            Assert.AreEqual(keys.Count, 21);
        }

    }
}