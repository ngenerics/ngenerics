using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.RedBlackTreeTests
{
    [TestFixture]
    public class Keys : RedBlackTreeTest
    {

        [Test]
        public void Simple()
        {
            var redBlackTree = GetTestTree(20);
            var keys = redBlackTree.Keys;

            Assert.AreEqual(keys.Count, 20);

            var counter = 0;

            using (var enumerator = keys.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Assert.AreEqual(enumerator.Current, counter);
                    counter++;
                }
            }

            redBlackTree = new RedBlackTree<int, string>();
            keys = redBlackTree.Keys;

            Assert.IsNotNull(keys);
            Assert.AreEqual(keys.Count, 0);
        }

    }
}