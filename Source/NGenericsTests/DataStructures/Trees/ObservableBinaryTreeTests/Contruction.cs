using NGenerics.DataStructures.Trees;
using NGenerics.DataStructures.Trees.Observable;
using NGenerics.Tests.TestObjects;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.ObservableBinaryTreeTests
{
    [TestFixture]
    public class Contruction
    {

        [Test]
        public void Serialization()
        {
            var deserialize = SerializeUtil.BinarySerializeDeserialize(new ObservableBinaryTree<int>(4));
            ObservableCollectionTester.CheckMonitor(deserialize);
        }
        [Test]
        public void Monitor1()
        {
            ObservableCollectionTester.CheckMonitor(new ObservableBinaryTree<int>(4));
        }
        [Test]
        public void Monitor2()
        {
            var left = new BinaryTree<int>(2);
            var right = new BinaryTree<int>(2);
            ObservableCollectionTester.CheckMonitor(new ObservableBinaryTree<int>(4, left, right));
        }
        [Test]
        public void Monitor3()
        {
            ObservableCollectionTester.CheckMonitor(new ObservableBinaryTree<int>(4, 5, 6));
        }
    }
}