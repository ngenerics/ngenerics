using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.GeneralTreeTests
{
    [TestFixture]
    public class Remove : GeneralTreeTest
    {

        [Test]
        public void Simple()
        {
            var root = new GeneralTree<int>(5);

            var child1 = new GeneralTree<int>(2);
            var child2 = new GeneralTree<int>(3);
            var child3 = new GeneralTree<int>(5);
            var child4 = new GeneralTree<int>(7);

            root.Add(child1);
            root.Add(child2);

            Assert.AreEqual(root.Count, 2);
            Assert.AreEqual(root.Degree, 2);

            root.RemoveAt(0);

            Assert.IsNull(child1.Parent);

            Assert.AreEqual(root.Count, 1);
            Assert.AreEqual(root.Degree, 1);
            Assert.AreEqual(root.GetChild(0), child2);
            Assert.AreEqual(root.GetChild(0).Data, 3);

            root.Add(child1);

            Assert.AreEqual(child1.Parent, root);
            Assert.AreEqual(root.Count, 2);
            Assert.AreEqual(root.Degree, 2);

            Assert.IsTrue(root.Remove(child1));
            Assert.IsNull(child1.Parent);

            Assert.AreEqual(root.Count, 1);
            Assert.AreEqual(root.Degree, 1);
            Assert.AreEqual(root.GetChild(0), child2);
            Assert.AreEqual(root.GetChild(0).Data, 3);

            Assert.IsFalse(root.Remove(child3));

            root.Add(child3);
            root.Add(child4);

            Assert.AreEqual(root.Count, 3);
            Assert.AreEqual(root.Degree, 3);

            var fiveNode = root.FindNode(target => target == 5);
            Assert.IsTrue(root.Remove(5));

            Assert.IsNull(fiveNode.Parent);

            Assert.AreEqual(root.Count, 2);
            Assert.AreEqual(root.Degree, 2);
            Assert.AreEqual(root.GetChild(1).Data, 7);

            Assert.IsFalse(root.Remove(13));
        }

        [Test]
        public void Interface()
        {
            ITree<int> tree = new GeneralTree<int>(5);

            var child1 = new GeneralTree<int>(4);
            var child2 = new GeneralTree<int>(6);
            var child3 = new GeneralTree<int>(7);

            tree.Add(child1);
            tree.Add(child2);
            Assert.AreEqual(tree.Degree, 2);
            Assert.IsTrue(tree.Remove(child1));
            Assert.AreEqual(tree.Degree, 1);
            Assert.IsFalse(tree.Remove(child3));
            Assert.AreEqual(tree.Degree, 1);
            Assert.IsTrue(tree.Remove(child2));
            Assert.AreEqual(tree.Degree, 0);
        }

    }
}