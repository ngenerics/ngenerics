using System;
using System.Collections.Generic;
using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.SplayTreeTests
{
    [TestFixture]
    public class TryGetValue : SplayTreeTest
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

                string val;

                Assert.AreEqual(splayTree.Count, i + 1);

                splayTree.TryGetValue(gen, out val);
                Assert.AreEqual(val, gen.ToString());
                Assert.AreEqual(splayTree[gen], gen.ToString());
            }

            string val2;
            splayTree.TryGetValue(2001, out val2);
            Assert.IsNull(val2);
        }

    }
}