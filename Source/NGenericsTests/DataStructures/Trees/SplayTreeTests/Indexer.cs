using System;
using System.Collections.Generic;
using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.SplayTreeTests
{
    [TestFixture]
    public class Indexer : SplayTreeTest
    {

        [Test]
        public void Simple()
        {
            var splayTree = new SplayTree<int, string>();

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

                splayTree.Add(gen, gen.ToString());

                Assert.IsTrue(splayTree.ContainsKey(gen));
                Assert.AreEqual(splayTree[gen], gen.ToString());
            }
        }

        [Test]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void ExceptionInvalidIndexerGet()
        {
            var splayTree = new SplayTree<int, string>();
            var s = splayTree[4];
        }

        [Test]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void ExceptionInvalidIndexerSet()
        {
            var splayTree = new SplayTree<int, string>();
            splayTree[4] = "testString";
        }

        [Test]
        public void Set()
        {
            var splayTree = new SplayTree<int, string>();

            for (var i = 20; i > 10; i--)
            {
                splayTree.Add(i, i.ToString());
            }

            for (var i = 0; i < 10; i++)
            {
                splayTree.Add(i, i.ToString());
            }

            Assert.AreEqual(splayTree[0], "0");
            splayTree[0] = "1";
            Assert.AreEqual(splayTree[0], "1");

            splayTree[1] = "4";
            Assert.AreEqual(splayTree[1], "4");
        }

    }
}