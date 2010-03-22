/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using System.Collections;
using System.Collections.Generic;
using NGenerics.Comparers;
using NGenerics.DataStructures.Trees;
using NGenerics.Patterns.Visitor;
using NGenerics.Tests.TestObjects;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees
{
    [TestFixture]
    public class RedBlackTreeTest
    {
        #region Tests

        [TestFixture]
        public class Add
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

        [TestFixture]
        public class Accept
        {

            [Test]
            public void Simple()
            {
                var redBlackTree = GetTestTree();

                var visitor = new TrackingVisitor<KeyValuePair<int, string>>();

                redBlackTree.AcceptVisitor(visitor);

                Assert.AreEqual(visitor.TrackingList.Count, 100);

                for (var i = 0; i < 100; i++)
                {
                    Assert.IsTrue(visitor.TrackingList.Contains(new KeyValuePair<int, string>(i, i.ToString())));
                }
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullVisitor()
            {
                var redBlackTree = GetTestTree();
                redBlackTree.AcceptVisitor(null);
            }

        }

        [TestFixture]
        public class Count
        {

            [Test]
            public void Simple()
            {
                var redBlackTree = GetTestTree();
                Assert.IsFalse(redBlackTree.IsEmpty);

                redBlackTree.Clear();
                Assert.IsTrue(redBlackTree.IsEmpty);

                redBlackTree = new RedBlackTree<int, string>();
                Assert.IsTrue(redBlackTree.IsEmpty);
            }

        }

        [TestFixture]
        public class CopyTo
        {

            [Test]
            public void Simple()
            {
                var redBlackTree = GetTestTree(10);

                var array = new KeyValuePair<int, string>[10];
                redBlackTree.CopyTo(array, 0);

                var list = new List<KeyValuePair<int, string>>(array);

                for (var i = 0; i < 10; i++)
                {
                    Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(i, i.ToString())));
                }

                Assert.AreEqual(list.Count, 10);
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullArray()
            {
                var redBlackTree = GetTestTree(10);
                redBlackTree.CopyTo(null, 1);
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void ExceptionNotEnoughSpaceInTargetArray1()
            {
                var redBlackTree = GetTestTree(10);
                var array = new KeyValuePair<int, string>[9];
                redBlackTree.CopyTo(array, 0);
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void ExceptionNotEnoughSpaceInTargetArray2()
            {
                var redBlackTree = GetTestTree(10);
                var array = new KeyValuePair<int, string>[10];
                redBlackTree.CopyTo(array, 1);
            }

        }

        [TestFixture]
        public class Clear
        {

            [Test]
            public void Simple()
            {
                var redBlackTree = GetTestTree();
                redBlackTree.Clear();

                Assert.AreEqual(redBlackTree.Count, 0);
                Assert.IsFalse(redBlackTree.ContainsKey(40));
                Assert.IsFalse(redBlackTree.ContainsKey(41));
            }

        }

        [TestFixture]
        public class Contruction
        {

            [Test]
            public void Simple()
            {
                var redBlackTree = new RedBlackTree<int, string>();
                Assert.AreEqual(redBlackTree.Count, 0);
                Assert.IsTrue(redBlackTree.Comparer is KeyValuePairComparer<int, string>);

                redBlackTree = new RedBlackTree<int, string>(new ReverseComparer<int>());
                Assert.AreEqual(redBlackTree.Count, 0);
                Assert.IsTrue(redBlackTree.Comparer.GetType().IsAssignableFrom(typeof(KeyValuePairComparer<int, string>)));
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullComparer()
            {
                new RedBlackTree<int, string>((IComparer<int>)null);
            }

        }

        [TestFixture]
        public class DepthFirstTraversal
        {

            [Test]
            public void Simple()
            {
                var redBlackTree = new RedBlackTree<string, int>
				                                     {
				                                         new KeyValuePair<string, int>("horse", 4),
				                                         new KeyValuePair<string, int>("cat", 1),
				                                         new KeyValuePair<string, int>("dog", 2),
				                                         new KeyValuePair<string, int>("canary", 3)
				                                     };

                var visitor = new TrackingVisitor<KeyValuePair<string, int>>();

                var inOrderVisitor =
                    new InOrderVisitor<KeyValuePair<string, int>>(visitor);

                redBlackTree.DepthFirstTraversal(inOrderVisitor);

                Assert.AreEqual(visitor.TrackingList[0].Key, "canary");
                Assert.AreEqual(visitor.TrackingList[1].Key, "cat");
                Assert.AreEqual(visitor.TrackingList[2].Key, "dog");
                Assert.AreEqual(visitor.TrackingList[3].Key, "horse");
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullVisitor()
            {
                var redBlackTree = GetTestTree(20);
                redBlackTree.DepthFirstTraversal(null);
            }

        }

        [TestFixture]
        public class GetEnumerator
        {

            [Test]
            public void Simple1()
            {
                var list = new List<KeyValuePair<int, string>>();
                var redBlackTree = GetTestTree();

                using (var enumerator = redBlackTree.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        list.Add(enumerator.Current);
                    }

                }
            }

            [Test]
            public void Simple2()
            {
                var redBlackTree = GetTestTree();
                var list = new List<KeyValuePair<int, string>>();

                using (var enumerator = redBlackTree.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        list.Add(enumerator.Current);
                    }
                }

                Assert.AreEqual(list.Count, 100);

                for (var i = 0; i < 100; i++)
                {
                    Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(i, i.ToString())));
                }
            }

            [Test]
            public void Interface()
            {
                var list = new List<KeyValuePair<int, string>>();
                var redBlackTree = GetTestTree();

                using (var enumerator = redBlackTree.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        list.Add(enumerator.Current);
                    }

                }
            }

            [Test]
            public void Interface1()
            {
                IEnumerable<KeyValuePair<int, string>> redBlackTree = GetTestTree();
                var list = new List<KeyValuePair<int, string>>();

                using (var enumerator = redBlackTree.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        list.Add(enumerator.Current);
                    }
                }

                Assert.AreEqual(list.Count, 100);

                for (var i = 0; i < 100; i++)
                {
                    Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(i, i.ToString())));
                }
            }

            [Test]
            public void Interface2()
            {
                var redBlackTree = GetTestTree();
                var list = new List<KeyValuePair<int, string>>();

                var enumerator = ((IEnumerable)redBlackTree).GetEnumerator();
                {
                    while (enumerator.MoveNext())
                    {
                        list.Add((KeyValuePair<int, string>)enumerator.Current);
                    }
                }

                Assert.AreEqual(list.Count, 100);

                for (var i = 0; i < 100; i++)
                {
                    Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(i, i.ToString())));
                }
            }

        }


        [TestFixture]
        public class IsReadOnly
        {

            [Test]
            public void Simple()
            {
                var redBlackTree = new RedBlackTree<int, string>();
                Assert.IsFalse(redBlackTree.IsReadOnly);
            }

        }

        [TestFixture]
        public class IsEmpty
        {

            [Test]
            public void Simple()
            {
                var redBlackTree = new RedBlackTree<int, string>();
                Assert.IsTrue(redBlackTree.IsEmpty);

                redBlackTree = GetTestTree();
                Assert.IsFalse(redBlackTree.IsEmpty);

                redBlackTree.Clear();
                Assert.IsTrue(redBlackTree.IsEmpty);
            }

        }



        [TestFixture]
        public class Index
        {

            [Test]
            public void Simple()
            {
                var redBlackTree = GetTestTree(20);

                for (var i = 0; i < 20; i++)
                {
                    Assert.AreEqual(redBlackTree[i], i.ToString());
                }

                redBlackTree[0] = "50";
                Assert.AreEqual(redBlackTree[0], "50");

                redBlackTree[1] = "-20";
                Assert.AreEqual(redBlackTree[1], "-20");
            }

            [Test]
            [ExpectedException(typeof(KeyNotFoundException))]
            public void ExceptionInvalidIndexSet()
            {
                var redBlackTree = GetTestTree(20);
                redBlackTree[50] = "50";
            }

            [Test]
            [ExpectedException(typeof(KeyNotFoundException))]
            public void ExceptionInvalidIndexGet()
            {
                var redBlackTree = GetTestTree(20);

                for (var i = 0; i < 20; i++)
                {
                    Assert.AreEqual(redBlackTree[i], i.ToString());
                }

                var s = redBlackTree[20];
            }
        }

        [TestFixture]
        public class Keys
        {

            [Test]
            public void Simple()
            {
                var redBlackTree = GetTestTree(20);
                var keys = redBlackTree.Keys;

                Assert.AreEqual(keys.Count, 20);

                var counter = 0;

                using (var enumerator = keys.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        Assert.AreEqual(enumerator.Current, counter);
                        counter++;
                    }
                }

                redBlackTree = new RedBlackTree<int, string>();
                keys = redBlackTree.Keys;

                Assert.IsNotNull(keys);
                Assert.AreEqual(keys.Count, 0);
            }

        }

        [TestFixture]
        public class Minimum
        {

            [Test]
            public void Simple()
            {
                var redBlackTree = GetTestTree(20);
                Assert.AreEqual(redBlackTree.Minimum.Key, 0);
            }

            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionInvalidMin()
            {
                var redBlackTree = new RedBlackTree<int, string>();
                var i = redBlackTree.Minimum.Key;
            }

        }

        [TestFixture]
        public class Maximum
        {
            [Test]
            public void Simple()
            {
                var redBlackTree = GetTestTree(20);
                Assert.AreEqual(redBlackTree.Maximum.Key, 19);
            }

            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionInvalidMax()
            {
                var redBlackTree = new RedBlackTree<int, string>();
                var i = redBlackTree.Maximum.Key;
            }
        }

        [TestFixture]
        public class Remove
        {

            [Test]
            public void Small()
            {
                var redBlackTree = GetTestTree(5);

                for (var i = 0; i < 5; i++)
                {
                    Assert.IsTrue(redBlackTree.Remove(i));
                    Assert.AreEqual(redBlackTree.Count, 5 - i - 1);
                    Assert.IsFalse(redBlackTree.ContainsKey(i));

                    for (var j = i + 1; j < 5; j++)
                    {
                        Assert.IsTrue(redBlackTree.ContainsKey(j));
                    }
                }
            }

            [Test]
            public void Big()
            {
                var redBlackTree = GetTestTree();

                for (var i = 0; i < 100; i++)
                {
                    Assert.IsTrue(redBlackTree.Remove(i));
                    Assert.AreEqual(redBlackTree.Count, 100 - i - 1);
                    Assert.IsFalse(redBlackTree.ContainsKey(i));

                    for (var j = i + 1; j < 100; j++)
                    {
                        Assert.IsTrue(redBlackTree.ContainsKey(j));
                    }
                }
            }

            [Test]
            public void RemoveNotFound()
            {
                var redBlackTree = GetTestTree(20);

                for (var i = 20; i < 40; i++)
                {
                    Assert.IsFalse(redBlackTree.Remove(i));
                    Assert.AreEqual(redBlackTree.Count, 20);
                }
            }

        }

        [TestFixture]
        public class Serialization
        {

            [Test]
            public void Simple()
            {
                var redBlackTree = GetTestTree();
                var newTree = SerializeUtil.BinarySerializeDeserialize(redBlackTree);

                Assert.AreNotSame(redBlackTree, newTree);
                Assert.AreEqual(redBlackTree.Count, newTree.Count);

                var redBlackTreeEnumerator = redBlackTree.GetEnumerator();
                var newTreeEnumerator = newTree.GetEnumerator();

                while (redBlackTreeEnumerator.MoveNext())
                {
                    Assert.IsTrue(newTreeEnumerator.MoveNext());
                    Assert.AreEqual(redBlackTreeEnumerator.Current.Key, newTreeEnumerator.Current.Key);
                    Assert.AreEqual(redBlackTreeEnumerator.Current.Value, newTreeEnumerator.Current.Value);

                    Assert.IsTrue(newTree.ContainsKey(redBlackTreeEnumerator.Current.Key));
                    Assert.AreEqual(newTree[redBlackTreeEnumerator.Current.Key], redBlackTreeEnumerator.Current.Value);
                }

                Assert.IsFalse(newTreeEnumerator.MoveNext());
            }

            [Test]
            public void NonIComparable()
            {
                var redBlackTree = new RedBlackTree<NonComparableTClass, string>();

                for (var i = 0; i < 100; i++)
                {
                    redBlackTree.Add(new NonComparableTClass(i), i.ToString());
                }

                var newTree = SerializeUtil.BinarySerializeDeserialize(redBlackTree);

                Assert.AreNotSame(redBlackTree, newTree);
                Assert.AreEqual(redBlackTree.Count, newTree.Count);

                var redBlackTreeEnumerator = redBlackTree.GetEnumerator();
                var newTreeEnumerator = newTree.GetEnumerator();

                while (redBlackTreeEnumerator.MoveNext())
                {
                    Assert.IsTrue(newTreeEnumerator.MoveNext());
                    Assert.AreEqual(redBlackTreeEnumerator.Current.Key.Number, newTreeEnumerator.Current.Key.Number);
                    Assert.AreEqual(redBlackTreeEnumerator.Current.Value, newTreeEnumerator.Current.Value);

                    Assert.IsTrue(newTree.ContainsKey(redBlackTreeEnumerator.Current.Key));
                    Assert.AreEqual(newTree[redBlackTreeEnumerator.Current.Key], redBlackTreeEnumerator.Current.Value);
                }

                Assert.IsFalse(newTreeEnumerator.MoveNext());
            }

        }

        [TestFixture]
        public class TryGetValue
        {

            [Test]
            public void Simple()
            {
                var redBlackTree = new RedBlackTree<int, string>();

                string value;

                for (var i = 0; i < 100; i++)
                {
                    redBlackTree.Add(i, i.ToString());

                    Assert.AreEqual(redBlackTree.Count, i + 1);
                    Assert.IsTrue(redBlackTree.TryGetValue(i, out value));
                    Assert.AreEqual(value, i.ToString());
                }


                Assert.IsFalse(redBlackTree.TryGetValue(101, out value));
                Assert.IsNull(value);

                Assert.IsFalse(redBlackTree.TryGetValue(102, out value));
                Assert.IsNull(value);
            }

        }

        [TestFixture]
        public class Values
        {

            [Test]
            public void Simple()
            {
                var redBlackTree = GetTestTree(20);
                var values = redBlackTree.Values;

                Assert.AreEqual(values.Count, 20);

                var counter = 0;

                using (var enumerator = values.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        Assert.AreEqual(enumerator.Current, counter.ToString());
                        counter++;
                    }
                }

                redBlackTree = new RedBlackTree<int, string>();
                values = redBlackTree.Values;

                Assert.IsNotNull(values);
                Assert.AreEqual(values.Count, 0);
            }

        }

        #endregion

        #region Private Members

        private static RedBlackTree<int, string> GetTestTree()
        {
            var redBlackTree = new RedBlackTree<int, string>();

            for (var i = 0; i < 100; i++)
            {
                redBlackTree.Add(i, i.ToString());
            }

            return redBlackTree;
        }

        private static RedBlackTree<int, string> GetTestTree(int noOfItems)
        {
            var redBlackTree = new RedBlackTree<int, string>();

            for (var i = 0; i < noOfItems; i++)
            {
                redBlackTree.Add(i, i.ToString());
            }

            return redBlackTree;
        }

        #endregion
    }
}