using System;
using System.Collections.Generic;
using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinarySearchTreeTests
{
    [TestFixture]
    public class Add : BinarySearchTreeTest
    {

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionDuplicateAdd()
        {
            new BinarySearchTree<int, string>
                {
                    {4, "4"}, 
                    {4, "4"}
                };
        }

        [Test]
        public void KeyValuePair()
        {
            var tree = new BinarySearchTree<int, string>();

            var dictionary = new Dictionary<int, string>();

            var rand = new Random(Convert.ToInt32(DateTime.Now.Ticks % Int32.MaxValue));

            for (var i = 0; i < 50; i++)
            {
                var gen = rand.Next(2000);

                while (dictionary.ContainsKey(gen))
                {
                    gen = rand.Next(2000);
                }

                dictionary.Add(gen, null);

                tree.Add(new KeyValuePair<int, string>(gen, gen.ToString()));

                Assert.AreEqual(tree.Count, i + 1);
                Assert.IsTrue(tree.ContainsKey(gen));
            }
        }

        [Test]
        public void Simple()
        {
            var tree = new BinarySearchTree<int, string>();

            var dictionary = new Dictionary<int, string>();

            var rand = new Random(Convert.ToInt32(DateTime.Now.Ticks % Int32.MaxValue));

            for (var i = 0; i < 50; i++)
            {
                var gen = rand.Next(2000);

                while (dictionary.ContainsKey(gen))
                {
                    gen = rand.Next(2000);
                }

                dictionary.Add(gen, null);

                tree.Add(gen, gen.ToString());

                Assert.AreEqual(tree.Count, i + 1);
                Assert.IsTrue(tree.ContainsKey(gen));
            }
        }

    }
}