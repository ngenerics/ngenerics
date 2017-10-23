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

namespace NGenerics.Tests.DataStructures.Trees.RedBlackTreeTests
{
    [TestFixture]
    public class Add : RedBlackTreeTest
    {
        [Test]
        public void Simple()
        {
            var redBlackTree = new RedBlackTree<int, string>();

            for (var i = 0; i < 100; i++)
            {
                redBlackTree.Add(i, i.ToString());

                Assert.IsTrue(redBlackTree.ContainsKey(i));
                Assert.AreEqual(redBlackTree.Count, i + 1);
            }

            for (var i = 300; i > 200; i--)
            {
                redBlackTree.Add(i, i.ToString());

                Assert.IsTrue(redBlackTree.ContainsKey(i));
                Assert.AreEqual(redBlackTree.Count, 100 + (300 - i) + 1);
            }


            for (var i = 100; i < 200; i++)
            {
                redBlackTree.Add(i, i.ToString());

                Assert.IsTrue(redBlackTree.ContainsKey(i));
                Assert.AreEqual(redBlackTree.Count, 100 + i + 1);
            }

            for (var i = 301; i < 400; i++)
            {
                redBlackTree.Add(new KeyValuePair<int, string>(i, i.ToString()));

                Assert.IsTrue(redBlackTree.ContainsKey(i));
                Assert.AreEqual(redBlackTree[i], i.ToString());
                Assert.IsTrue(redBlackTree.Contains(new KeyValuePair<int, string>(i, i.ToString())));
            }



            Assert.IsFalse(redBlackTree.Contains(new KeyValuePair<int, string>(500, "500")));
            Assert.IsFalse(redBlackTree.Contains(new KeyValuePair<int, string>(300, "301")));
            Assert.IsTrue(redBlackTree.Contains(new KeyValuePair<int, string>(300, "300")));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionKeyAlreadyInTree()
        {
            var redBlackTree = new RedBlackTree<int, string>
                                   {
                                       {0, "50"}, 
                                       {0, "20"}
                                   };
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullKey()
        {
            var redBlackTree = new RedBlackTree<object, string>
                                   {
                                       {null, "a"}
                                   };
        }

        [Test]
        public void StressTestRandomData()
        {
            var data = new List<int>();
            var redBlackTree = new RedBlackTree<int, string>();

            var rand = new Random(Convert.ToInt32(DateTime.Now.Ticks % Int32.MaxValue));

            for (var i = 0; i < 2000; i++)
            {
                var randomNumber = rand.Next(100000);

                while (data.Contains(randomNumber))
                {
                    randomNumber = rand.Next(100000);
                }

                data.Add(randomNumber);
                redBlackTree.Add(randomNumber, randomNumber.ToString());

                Assert.AreEqual(redBlackTree.Count, i + 1);

                foreach (var t in data)
                {
                    Assert.IsTrue(redBlackTree.ContainsKey(t));
                }
            }

            while (data.Count != 0)
            {
                Assert.IsTrue(redBlackTree.Remove(data[0]));

                Assert.IsFalse(redBlackTree.ContainsKey(data[0]));

                data.RemoveAt(0);

                Assert.AreEqual(redBlackTree.Count, data.Count);

                foreach (var t in data)
                {
                    Assert.IsTrue(redBlackTree.ContainsKey(t));
                }
            }
        }

    }
}