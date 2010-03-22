/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html. 
*/

using System;
using System.Collections.Generic;
using NGenerics.Tests.Util;
using NUnit.Framework;
using NGenerics.DataStructures.General;

namespace NGenerics.Tests.DataStructures.General
{
    [TestFixture]
    public class HashListTest
    {
        [TestFixture]
        public class Add
        {
            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionInvalidRange()
            {
                var hashList = new HashList<int, string>
                               {
                                   {3, (List<string>) null}
                               };
            }

            [Test]
            public void Simple()
            {
                var hashList = new HashList<int, string>
                               {
                                   {2, "a"}
                               };

                Assert.AreEqual(hashList.ValueCount, 1);
                Assert.AreEqual(hashList.KeyCount, 1);

                hashList.Add(4, new List<string>(new[] { "2", "3", "4", "5" }));

                Assert.AreEqual(hashList.ValueCount, 5);
                Assert.AreEqual(hashList.KeyCount, 2);

                hashList.Add(2, new List<string>(new[] { "2", "3", "4", "5" }));

                Assert.AreEqual(hashList.ValueCount, 9);
                Assert.AreEqual(hashList.KeyCount, 2);
            }


            [Test]
            public void Params()
            {
                var hashList = new HashList<int, string>
                               {
                                   {2, "a", "b"}
                               };

                Assert.AreEqual(hashList.ValueCount, 2);
                Assert.AreEqual(hashList.KeyCount, 1);

                hashList.Add(4, "2", "3", "4", "5");

                Assert.AreEqual(hashList.ValueCount, 6);
                Assert.AreEqual(hashList.KeyCount, 2);

                hashList.Add(2, "2", "3", "4", "5");

                Assert.AreEqual(hashList.ValueCount, 10);
                Assert.AreEqual(hashList.KeyCount, 2);
            }
        }

        [TestFixture]
        public class Construction
        {
            [Test]
            public void Simple()
            {
                var hashList = new HashList<string, int>();

                Assert.AreEqual(hashList.Count, 0);

                var dictionary = new Dictionary<string, IList<int>>
                                                                {
                                                                    {"aa", new List<int>()},
                                                                    {"bb", new List<int>()},
                                                                    {"cc", new List<int>()}
                                                                };

                dictionary["bb"].Add(5);
                dictionary["bb"].Add(6);
                dictionary["cc"].Add(2);

                hashList = new HashList<string, int>(dictionary);

                Assert.AreEqual(hashList.Count, 3);
                Assert.AreEqual(hashList.ValueCount, 3);

                Assert.AreEqual(hashList["aa"].Count, 0);
                Assert.AreEqual(hashList["bb"].Count, 2);
                Assert.AreEqual(hashList["cc"].Count, 1);

                Assert.AreEqual(hashList["bb"][0], 5);
                Assert.AreEqual(hashList["bb"][1], 6);
                Assert.AreEqual(hashList["cc"][0], 2);

                hashList = new HashList<string, int>(50);

                Assert.AreEqual(hashList.Count, 0);
                Assert.AreEqual(hashList.ValueCount, 0);

                hashList = new HashList<string, int>(EqualityComparer<string>.Default);

                Assert.AreEqual(hashList.Count, 0);
                Assert.AreEqual(hashList.ValueCount, 0);

                hashList = new HashList<string, int>(20, EqualityComparer<string>.Default);

                Assert.AreEqual(hashList.Count, 0);
                Assert.AreEqual(hashList.ValueCount, 0);
            }
        }

        [TestFixture]
        public class GetValueEnumerator
        {
            [Test]
            public void Simple()
            {
                var hashList = new HashList<int, string> {{2, "a"}};

                Assert.AreEqual(hashList.ValueCount, 1);
                Assert.AreEqual(hashList.KeyCount, 1);

                hashList.Add(4, new List<string>(new[] { "2", "3", "4", "5" }));

                Assert.AreEqual(hashList.ValueCount, 5);
                Assert.AreEqual(hashList.KeyCount, 2);

                var enumerator = hashList.GetValueEnumerator();

                var list = new List<string>();

                while (enumerator.MoveNext())
                {
                    list.Add(enumerator.Current);
                }

                Assert.AreEqual(list.Count, 5);
                Assert.IsTrue(list.Contains("a"));
                Assert.IsTrue(list.Contains("2"));
                Assert.IsTrue(list.Contains("3"));
                Assert.IsTrue(list.Contains("4"));
                Assert.IsTrue(list.Contains("5"));
            }
        }

        [TestFixture]
        public class KeyCount
        {
            [Test]
            public void Simple()
            {
                var hashList = new HashList<int, string> {{2, "a"}};

                Assert.AreEqual(hashList.ValueCount, 1);
                Assert.AreEqual(hashList.KeyCount, 1);

                hashList.Add(4, new List<string>(new[] { "2", "3", "4", "5" }));

                Assert.AreEqual(hashList.ValueCount, 5);
                Assert.AreEqual(hashList.KeyCount, 2);
            }
        }

        [TestFixture]
        public class Remove
        {
            [Test]
			public void Simple()
            {
                var hashList = new HashList<int, string> {{2, "a"}};

                Assert.AreEqual(hashList.ValueCount, 1);
                Assert.AreEqual(hashList.KeyCount, 1);

                hashList.Add(4, new List<string>(new[] { "2", "3", "4", "5" }));

                Assert.AreEqual(hashList.ValueCount, 5);
                Assert.AreEqual(hashList.KeyCount, 2);

                Assert.IsTrue(hashList.Remove(2));
                Assert.AreEqual(hashList.KeyCount, 1);
                Assert.AreEqual(hashList.ValueCount, 4);

                Assert.IsFalse(hashList.Remove(2));
                Assert.AreEqual(hashList.KeyCount, 1);
                Assert.AreEqual(hashList.ValueCount, 4);

                Assert.IsTrue(hashList.RemoveValue("2"));

                Assert.AreEqual(hashList.KeyCount, 1);
                Assert.AreEqual(hashList.ValueCount, 3);

                Assert.IsFalse(hashList.Remove(3, "2"));

                Assert.AreEqual(hashList.KeyCount, 1);
                Assert.AreEqual(hashList.ValueCount, 3);

                Assert.IsFalse(hashList.Remove(4, "2"));

                Assert.AreEqual(hashList.KeyCount, 1);
                Assert.AreEqual(hashList.ValueCount, 3);

                Assert.IsTrue(hashList.Remove(4, "5"));

                Assert.AreEqual(hashList.KeyCount, 1);
                Assert.AreEqual(hashList.ValueCount, 2);

                hashList.Add(4, "4");

                Assert.AreEqual(hashList.KeyCount, 1);
                Assert.AreEqual(hashList.ValueCount, 3);

                hashList.RemoveAll("4");

                Assert.AreEqual(hashList.KeyCount, 1);
                Assert.AreEqual(hashList.ValueCount, 1);

                Assert.IsFalse(hashList.Remove(10));

                hashList.Add(4, "5");
                hashList.Add(4, "6");

                Assert.AreEqual(hashList.KeyCount, 1);
                Assert.AreEqual(hashList.ValueCount, 3);


                Assert.IsTrue(hashList.RemoveValue("5"));

                Assert.AreEqual(hashList.KeyCount, 1);
                Assert.AreEqual(hashList.ValueCount, 2);

                Assert.IsFalse(hashList.RemoveValue("5"));

                Assert.AreEqual(hashList.KeyCount, 1);
                Assert.AreEqual(hashList.ValueCount, 2);
            }
        }

        [TestFixture]
        public class Serializable
        {
            [Test]
			public void Simple()
            {
                var hashList = new HashList<int, string>
                                              {
                                                  {2, "a"},
                                                  {2, "b"},
                                                  {3, "b"},
                                                  {3, "c"},
                                                  {3, "d"},
                                                  {4, "c"}
                                              };

                var newHash = SerializeUtil.BinarySerializeDeserialize(hashList);

                Assert.AreNotSame(hashList, newHash);
                Assert.AreEqual(hashList.Count, newHash.Count);

                var hashListEnumerator = hashList.GetEnumerator();
                var newHashEnumerator = newHash.GetEnumerator();

                while (hashListEnumerator.MoveNext())
                {
                    Assert.IsTrue(newHashEnumerator.MoveNext());

                    Assert.AreEqual(hashListEnumerator.Current.Key, newHashEnumerator.Current.Key);

                    var l1 = hashListEnumerator.Current.Value;
                    var l2 = newHashEnumerator.Current.Value;

                    Assert.AreNotSame(l1, l2);
                    Assert.AreEqual(l1.Count, l2.Count);

                    for (var i = 0; i < l1.Count; i++)
                    {
                        Assert.AreEqual(l1[i], l2[i]);
                    }
                }

                Assert.IsFalse(newHashEnumerator.MoveNext());
            }
        }
    }
}
