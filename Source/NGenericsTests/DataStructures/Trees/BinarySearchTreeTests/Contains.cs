using System;
using System.Collections.Generic;
using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinarySearchTreeTests
{
    [TestFixture]
    public class Contains : BinarySearchTreeTest
    {

        [Test]
        public void Simple()
        {
            var tree = new BinarySearchTree<int, string>();

            Assert.IsFalse(tree.ContainsKey(5));

            tree.Add(4, "4");
            Assert.AreEqual(tree[4], "4");
            Assert.IsTrue(tree.ContainsKey(4));
            Assert.IsFalse(tree.ContainsKey(5));

            tree.Add(6, "6");
            Assert.AreEqual(tree[6], "6");
            Assert.IsTrue(tree.ContainsKey(4));
            Assert.IsFalse(tree.ContainsKey(5));
            Assert.IsTrue(tree.ContainsKey(6));

            tree.Add(2, "2");
            Assert.AreEqual(tree[2], "2");
            Assert.IsTrue(tree.ContainsKey(2));
            Assert.IsTrue(tree.ContainsKey(4));
            Assert.IsFalse(tree.ContainsKey(5));
            Assert.IsTrue(tree.ContainsKey(6));

            tree.Add(5, "5");
            Assert.AreEqual(tree[5], "5");
            Assert.IsTrue(tree.ContainsKey(2));
            Assert.IsTrue(tree.ContainsKey(4));
            Assert.IsTrue(tree.ContainsKey(5));
            Assert.IsTrue(tree.ContainsKey(6));


            var rand = new Random();

            tree = new BinarySearchTree<int, string>();

            var list = new List<int>();

            for (var i = 0; i < 100; i++)
            {
                int r;

                do
                {
                    r = rand.Next(5000);
                }
                while (list.Contains(r));

                list.Add(r);

                tree.Add(r, null);

                Assert.IsTrue(tree.ContainsKey(r));
            }
        }


        [Test]
        public void KeyValuePair()
        {
            var tree = new BinarySearchTree<int, string>();

            Assert.IsFalse(tree.Contains(new KeyValuePair<int, string>(5, "5")));

            tree.Add(4, "4");
            Assert.IsTrue(tree.Contains(new KeyValuePair<int, string>(4, "4")));
            Assert.IsFalse(tree.Contains(new KeyValuePair<int, string>(4, "5")));

            tree.Add(6, "6");
            Assert.IsTrue(tree.Contains(new KeyValuePair<int, string>(6, "6")));
            Assert.IsFalse(tree.Contains(new KeyValuePair<int, string>(6, "5")));
        }

    }
}