/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using System.Collections.Generic;
using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.SplayTreeTests
{
    [TestFixture]
    public class Remove : SplayTreeTest
    {

        [Test]
        public void Simple2()
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

                Assert.AreEqual(splayTree.Count, i + 1);
                Assert.IsTrue(splayTree.ContainsKey(gen));
            }

            using (var enumerator = dictionary.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Assert.IsTrue(splayTree.Remove(enumerator.Current));
                }
            }
        }

        [Test]
        public void Simple1()
        {
            var splayTree = new SplayTree<int, string>
                                {
                                    {4, "4"},
                                    {6, "6"},
                                    {2, "2"},
                                    {5, "5"},
                                    {19, "19"},
                                    {1, "1"}
                                };

            Assert.AreEqual(splayTree.Count, 6);

            Assert.IsTrue(splayTree.ContainsKey(4));
            Assert.IsTrue(splayTree.ContainsKey(6));
            Assert.IsTrue(splayTree.ContainsKey(2));
            Assert.IsTrue(splayTree.ContainsKey(5));
            Assert.IsTrue(splayTree.ContainsKey(19));
            Assert.IsTrue(splayTree.ContainsKey(1));

            Assert.IsFalse(splayTree.Remove(20));

            Assert.IsTrue(splayTree.Remove(4));
            Assert.AreEqual(splayTree.Count, 5);

            Assert.IsFalse(splayTree.ContainsKey(4));
            Assert.IsTrue(splayTree.ContainsKey(6));
            Assert.IsTrue(splayTree.ContainsKey(2));
            Assert.IsTrue(splayTree.ContainsKey(5));
            Assert.IsTrue(splayTree.ContainsKey(19));
            Assert.IsTrue(splayTree.ContainsKey(1));

            Assert.IsTrue(splayTree.Remove(2));
            Assert.AreEqual(splayTree.Count, 4);

            Assert.IsFalse(splayTree.ContainsKey(4));
            Assert.IsTrue(splayTree.ContainsKey(6));
            Assert.IsFalse(splayTree.ContainsKey(2));
            Assert.IsTrue(splayTree.ContainsKey(5));
            Assert.IsTrue(splayTree.ContainsKey(19));
            Assert.IsTrue(splayTree.ContainsKey(1));

            Assert.IsTrue(splayTree.Remove(19));
            Assert.AreEqual(splayTree.Count, 3);

            Assert.IsFalse(splayTree.ContainsKey(4));
            Assert.IsTrue(splayTree.ContainsKey(6));
            Assert.IsFalse(splayTree.ContainsKey(2));
            Assert.IsTrue(splayTree.ContainsKey(5));
            Assert.IsFalse(splayTree.ContainsKey(19));
            Assert.IsTrue(splayTree.ContainsKey(1));

            Assert.IsFalse(splayTree.Remove(20));


            Assert.IsTrue(splayTree.Remove(1));
            Assert.AreEqual(splayTree.Count, 2);

            Assert.IsFalse(splayTree.ContainsKey(4));
            Assert.IsTrue(splayTree.ContainsKey(6));
            Assert.IsFalse(splayTree.ContainsKey(2));
            Assert.IsTrue(splayTree.ContainsKey(5));
            Assert.IsFalse(splayTree.ContainsKey(19));
            Assert.IsFalse(splayTree.ContainsKey(1));

            Assert.IsTrue(splayTree.Remove(6));
            Assert.AreEqual(splayTree.Count, 1);

            Assert.IsFalse(splayTree.ContainsKey(4));
            Assert.IsFalse(splayTree.ContainsKey(6));
            Assert.IsFalse(splayTree.ContainsKey(2));
            Assert.IsTrue(splayTree.ContainsKey(5));
            Assert.IsFalse(splayTree.ContainsKey(19));
            Assert.IsFalse(splayTree.ContainsKey(1));

            Assert.IsTrue(splayTree.Remove(5));
            Assert.AreEqual(splayTree.Count, 0);

            Assert.IsFalse(splayTree.ContainsKey(4));
            Assert.IsFalse(splayTree.ContainsKey(6));
            Assert.IsFalse(splayTree.ContainsKey(2));
            Assert.IsFalse(splayTree.ContainsKey(5));
            Assert.IsFalse(splayTree.ContainsKey(19));
            Assert.IsFalse(splayTree.ContainsKey(1));

            Assert.IsFalse(splayTree.Remove(1));
        }

        [Test]
        public void KeyValuePair()
        {
            var splayTree = new SplayTree<int, string>
                                {
                                    {4, "4"},
                                    {6, "6"},
                                    {2, "2"},
                                    {5, "5"},
                                    {19, "19"},
                                    {1, "1"}
                                };

            Assert.AreEqual(splayTree.Count, 6);

            Assert.IsTrue(splayTree.ContainsKey(4));
            Assert.IsTrue(splayTree.ContainsKey(6));
            Assert.IsTrue(splayTree.ContainsKey(2));
            Assert.IsTrue(splayTree.ContainsKey(5));
            Assert.IsTrue(splayTree.ContainsKey(19));
            Assert.IsTrue(splayTree.ContainsKey(1));

            Assert.IsFalse(splayTree.Remove(new KeyValuePair<int, string>(20, "20")));

            Assert.IsTrue(splayTree.Remove(new KeyValuePair<int, string>(4, "4")));
            Assert.AreEqual(splayTree.Count, 5);

            Assert.IsFalse(splayTree.ContainsKey(4));
            Assert.IsTrue(splayTree.ContainsKey(6));
            Assert.IsTrue(splayTree.ContainsKey(2));
            Assert.IsTrue(splayTree.ContainsKey(5));
            Assert.IsTrue(splayTree.ContainsKey(19));
            Assert.IsTrue(splayTree.ContainsKey(1));
        }

    }
}