/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using System.Collections.Generic;
using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinarySearchTreeTests
{
    [TestFixture]
    public class Remove : BinarySearchTreeTest
    {

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

            using (var enumerator = dictionary.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Assert.IsTrue(tree.Remove(enumerator.Current));
                }
            }
        }

        [Test]
        public void Simple2()
        {
            var tree = new BinarySearchTree<int, string>
                           {
                               {4, "4"},
                               {6, "6"},
                               {2, "2"},
                               {5, "5"},
                               {19, "19"},
                               {1, "1"}
                           };

            Assert.AreEqual(tree.Count, 6);

            Assert.IsTrue(tree.ContainsKey(4));
            Assert.IsTrue(tree.ContainsKey(6));
            Assert.IsTrue(tree.ContainsKey(2));
            Assert.IsTrue(tree.ContainsKey(5));
            Assert.IsTrue(tree.ContainsKey(19));
            Assert.IsTrue(tree.ContainsKey(1));

            Assert.IsFalse(tree.Remove(20));

            Assert.IsTrue(tree.Remove(4));
            Assert.AreEqual(tree.Count, 5);

            Assert.IsFalse(tree.ContainsKey(4));
            Assert.IsTrue(tree.ContainsKey(6));
            Assert.IsTrue(tree.ContainsKey(2));
            Assert.IsTrue(tree.ContainsKey(5));
            Assert.IsTrue(tree.ContainsKey(19));
            Assert.IsTrue(tree.ContainsKey(1));

            Assert.IsTrue(tree.Remove(2));
            Assert.AreEqual(tree.Count, 4);

            Assert.IsFalse(tree.ContainsKey(4));
            Assert.IsTrue(tree.ContainsKey(6));
            Assert.IsFalse(tree.ContainsKey(2));
            Assert.IsTrue(tree.ContainsKey(5));
            Assert.IsTrue(tree.ContainsKey(19));
            Assert.IsTrue(tree.ContainsKey(1));

            Assert.IsTrue(tree.Remove(19));
            Assert.AreEqual(tree.Count, 3);

            Assert.IsFalse(tree.ContainsKey(4));
            Assert.IsTrue(tree.ContainsKey(6));
            Assert.IsFalse(tree.ContainsKey(2));
            Assert.IsTrue(tree.ContainsKey(5));
            Assert.IsFalse(tree.ContainsKey(19));
            Assert.IsTrue(tree.ContainsKey(1));

            Assert.IsFalse(tree.Remove(20));


            Assert.IsTrue(tree.Remove(1));
            Assert.AreEqual(tree.Count, 2);

            Assert.IsFalse(tree.ContainsKey(4));
            Assert.IsTrue(tree.ContainsKey(6));
            Assert.IsFalse(tree.ContainsKey(2));
            Assert.IsTrue(tree.ContainsKey(5));
            Assert.IsFalse(tree.ContainsKey(19));
            Assert.IsFalse(tree.ContainsKey(1));

            Assert.IsTrue(tree.Remove(6));
            Assert.AreEqual(tree.Count, 1);

            Assert.IsFalse(tree.ContainsKey(4));
            Assert.IsFalse(tree.ContainsKey(6));
            Assert.IsFalse(tree.ContainsKey(2));
            Assert.IsTrue(tree.ContainsKey(5));
            Assert.IsFalse(tree.ContainsKey(19));
            Assert.IsFalse(tree.ContainsKey(1));

            Assert.IsTrue(tree.Remove(5));
            Assert.AreEqual(tree.Count, 0);

            Assert.IsFalse(tree.ContainsKey(4));
            Assert.IsFalse(tree.ContainsKey(6));
            Assert.IsFalse(tree.ContainsKey(2));
            Assert.IsFalse(tree.ContainsKey(5));
            Assert.IsFalse(tree.ContainsKey(19));
            Assert.IsFalse(tree.ContainsKey(1));

            Assert.IsFalse(tree.Remove(1));
        }

        [Test]
        public void KeyValuePair()
        {
            var tree = new BinarySearchTree<int, string>
                           {
                               {4, "4"},
                               {6, "6"},
                               {2, "2"},
                               {5, "5"},
                               {19, "19"},
                               {1, "1"}
                           };

            Assert.AreEqual(tree.Count, 6);

            Assert.IsTrue(tree.ContainsKey(4));
            Assert.IsTrue(tree.ContainsKey(6));
            Assert.IsTrue(tree.ContainsKey(2));
            Assert.IsTrue(tree.ContainsKey(5));
            Assert.IsTrue(tree.ContainsKey(19));
            Assert.IsTrue(tree.ContainsKey(1));

            Assert.IsFalse(tree.Remove(new KeyValuePair<int, string>(20, "20")));

            Assert.IsTrue(tree.Remove(new KeyValuePair<int, string>(4, "4")));
            Assert.AreEqual(tree.Count, 5);

            Assert.IsFalse(tree.ContainsKey(4));
            Assert.IsTrue(tree.ContainsKey(6));
            Assert.IsTrue(tree.ContainsKey(2));
            Assert.IsTrue(tree.ContainsKey(5));
            Assert.IsTrue(tree.ContainsKey(19));
            Assert.IsTrue(tree.ContainsKey(1));
        }

    }
}