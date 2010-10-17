using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.SplayTreeTests
{
    [TestFixture]
    public class Values : SplayTreeTest
    {

        [Test]
        public void Simple()
        {
            var splayTree = new SplayTree<int, string>();

            for (var i = 20; i > 10; i--)
            {
                splayTree.Add(i, i.ToString());
            }

            for (var i = 0; i <= 10; i++)
            {
                splayTree.Add(i, i.ToString());
            }

            var values = splayTree.Values;

            for (var i = 0; i <= 20; i++)
            {
                Assert.IsTrue(values.Contains(i.ToString()));
            }

            Assert.AreEqual(values.Count, 21);
        }

    }
}