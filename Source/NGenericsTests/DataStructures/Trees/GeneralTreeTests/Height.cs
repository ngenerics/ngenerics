using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.GeneralTreeTests
{
    [TestFixture]
    public class Height : GeneralTreeTest
    {

        [Test]
        public void Simple()
        {
            var generalTree = new GeneralTree<int>(5);

            Assert.AreEqual(generalTree.Height, 0);

            var s1 = new GeneralTree<int>(3);

            generalTree.Add(s1);

            Assert.AreEqual(generalTree.Height, 1);

            s1.Add(new GeneralTree<int>(6));

            Assert.AreEqual(generalTree.Height, 2);
            generalTree.Add(new GeneralTree<int>(4));

            Assert.AreEqual(generalTree.Height, 2);

            generalTree = GetTestTree();

            Assert.AreEqual(generalTree.Height, 2);
        }

    }
}