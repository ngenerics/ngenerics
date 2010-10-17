using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.RedBlackTreeTests
{
    [TestFixture]
    public class Values : RedBlackTreeTest
    {

        [Test]
        public void Simple()
        {
            var redBlackTree = GetTestTree(20);
            var values = redBlackTree.Values;

            Assert.AreEqual(values.Count, 20);

            var counter = 0;

            using (var enumerator = values.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Assert.AreEqual(enumerator.Current, counter.ToString());
                    counter++;
                }
            }

            redBlackTree = new RedBlackTree<int, string>();
            values = redBlackTree.Values;

            Assert.IsNotNull(values);
            Assert.AreEqual(values.Count, 0);
        }

    }
}