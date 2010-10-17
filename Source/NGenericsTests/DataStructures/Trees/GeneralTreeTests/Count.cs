using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.GeneralTreeTests
{
    [TestFixture]
    public class Count : GeneralTreeTest
    {

        [Test]
        public void Simple()
        {
            var generalTree = GetTestTree();

            Assert.AreEqual(generalTree.Count, 3);

            generalTree.Clear();
            Assert.AreEqual(generalTree.Count, 0);

            generalTree = new GeneralTree<int>(3);

            Assert.AreEqual(generalTree.Count, 0);
            Assert.AreEqual(generalTree.Degree, 0);

            generalTree = GetTestTree();

            Assert.AreEqual(generalTree.Count, 3);
            Assert.AreEqual(generalTree.Degree, 3);
        }

    }
}