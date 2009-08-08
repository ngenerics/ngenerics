/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using System.Collections;
using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General
{
    [TestFixture]
    public class DictionaryBaseTest
    {
        [TestFixture]
        public class Construction
        {
            [Test]
            public void Simple()
            {
                new MockStringDictionary();
            }

            [Test]
            public void Capacity()
            {
                new MockStringDictionary(1);
            }

            [Test]
            public void CapacityComparer()
            {
                var target = new MockStringDictionary(1, StringComparer.InvariantCultureIgnoreCase);
                Assert.AreEqual(StringComparer.InvariantCultureIgnoreCase, target.Comparer);
            }

            [Test]
            public void DictionaryCompare()
            {
                var dictionary = new Dictionary<string, string> {{"a", "a"}};
                var target =
                    new MockStringDictionary(dictionary, StringComparer.InvariantCultureIgnoreCase);
                Assert.AreEqual(StringComparer.InvariantCultureIgnoreCase, target.Comparer);
                Assert.AreEqual(1, target.Count);
            }

            [Test]
            public void Dictionary()
            {
                var dictionary = new Dictionary<string, string> {{"a", "a"}};
                var target = new MockStringDictionary(dictionary);
                Assert.AreEqual(1, target.Count);
            }
        }


        [TestFixture]
        public class DictionaryBaseICollectionGenericTest
        {
            [Test]
            public void AddTest()
            {
                var target = new MockStringDictionary();
                ICollection<KeyValuePair<string, string>> collection = target;
                collection.Add(new KeyValuePair<string, string>("a", "b"));
                Assert.IsTrue(target.ContainsKey("a"));
            }

            [Test]
            public void ContainsTest()
            {
                var target = new MockStringDictionary {{"a", "b"}};
                ICollection<KeyValuePair<string, string>> collection = target;
                Assert.IsTrue(collection.Contains(new KeyValuePair<string, string>("a", "b")));
                Assert.IsFalse(collection.Contains(new KeyValuePair<string, string>("b", "b")));
                Assert.IsFalse(collection.Contains(new KeyValuePair<string, string>("a", "c")));
            }



            [Test]
            public void CopyToTest()
            {
                var target = new MockStringDictionary {{"a", "b"}, {"g", "s"}, {"h", "x"}};
                ICollection<KeyValuePair<string, string>> collection = target;
                var pairs = new KeyValuePair<string, string>[3];
                collection.CopyTo(pairs, 0);
                Assert.AreEqual("a", pairs[0].Key);
                Assert.AreEqual("g", pairs[1].Key);
                Assert.AreEqual("h", pairs[2].Key);
                Assert.AreEqual("b", pairs[0].Value);
                Assert.AreEqual("s", pairs[1].Value);
                Assert.AreEqual("x", pairs[2].Value);
            }



            [Test]
            public void GetEnumeratorTest()
            {
                var target = new MockStringDictionary {{"a", "b"}, {"s", "r"}, {"f", "t"}};
                ICollection<KeyValuePair<string, string>> dictionary = target;
                IEnumerator enumerator = dictionary.GetEnumerator();

                enumerator.MoveNext();
                var current = (KeyValuePair<string, string>) enumerator.Current;
                Assert.AreEqual("a", current.Key);
                Assert.AreEqual("b", current.Value);


                enumerator.MoveNext();
                current = (KeyValuePair<string, string>) enumerator.Current;
                Assert.AreEqual("s", current.Key);
                Assert.AreEqual("r", current.Value);

                enumerator.MoveNext();
                current = (KeyValuePair<string, string>) enumerator.Current;
                Assert.AreEqual("f", current.Key);
                Assert.AreEqual("t", current.Value);

            }

            [Test]
            public void IsReadOnlyTest()
            {
                var target = new MockStringDictionary();
                ICollection<KeyValuePair<string, string>> collection = target;
                Assert.IsFalse(collection.IsReadOnly);
            }

            [Test]
            public void RemoveNonExistingKeyTest()
            {
                var target = new MockStringDictionary {{"a", "a"}};
                ICollection<KeyValuePair<string, string>> collection = target;
                Assert.IsFalse(collection.Remove(new KeyValuePair<string, string>("b", "a")));
            }


            [Test]
            public void RemoveNonEqualValueTest()
            {
                var target = new MockStringDictionary {{"a", "b"}};
                ICollection<KeyValuePair<string, string>> collection = target;
                Assert.IsFalse(collection.Remove(new KeyValuePair<string, string>("a", "c")));
            }


            [Test]
            public void RemoveTest()
            {
                var target = new MockStringDictionary {{"a", "b"}};
                ICollection<KeyValuePair<string, string>> collection = target;
                Assert.IsTrue(collection.Remove(new KeyValuePair<string, string>("a", "b")));
                Assert.IsFalse(target.ContainsKey("a"));
                Assert.IsFalse(collection.Remove(new KeyValuePair<string, string>("a", "b")));
            }


        }

        [TestFixture]
        public class DictionaryBaseICollectionTest
        {


            [Test]
            public void CopyToTest()
            {
                var target = new MockStringDictionary {{"a", "b"}, {"g", "s"}, {"h", "x"}};
                ICollection collection = target;
                var pairs = new KeyValuePair<string, string>[3];
                collection.CopyTo(pairs, 0);
                Assert.AreEqual("a", pairs[0].Key);
                Assert.AreEqual("g", pairs[1].Key);
                Assert.AreEqual("h", pairs[2].Key);
                Assert.AreEqual("b", pairs[0].Value);
                Assert.AreEqual("s", pairs[1].Value);
                Assert.AreEqual("x", pairs[2].Value);
            }


            [Test]
            public void GetEnumeratorTest()
            {
                var target = new MockStringDictionary {{"a", "b"}, {"s", "r"}, {"f", "t"}};
                ICollection collection = target;
                var enumerator = collection.GetEnumerator();

                enumerator.MoveNext();
                var current = (KeyValuePair<string, string>) enumerator.Current;
                Assert.AreEqual("a", current.Key);
                Assert.AreEqual("b", current.Value);


                enumerator.MoveNext();
                current = (KeyValuePair<string, string>) enumerator.Current;
                Assert.AreEqual("s", current.Key);
                Assert.AreEqual("r", current.Value);

                enumerator.MoveNext();
                current = (KeyValuePair<string, string>) enumerator.Current;
                Assert.AreEqual("f", current.Key);
                Assert.AreEqual("t", current.Value);

            }


            [Test]
            public void IsSynchronizedTest()
            {
                var target = new MockStringDictionary();
                ICollection collection = target;
                Assert.IsFalse(collection.IsSynchronized);
            }


            [Test]
            public void IsSyncRootTest()
            {
                var target = new MockStringDictionary();
                ICollection collection = target;
                Assert.IsNotNull(collection.SyncRoot);

            }
        }

        [TestFixture]
        public class DictionaryBaseIDictionaryGenericTest
        {


            [Test]
            [ExpectedException(typeof(Exception), ExpectedMessage = "AddItem")]
            public void AddTest()
            {
                var target = new MockExceptionDictionary();
                target.Add(2, 2);
            }


            [Test]
            [ExpectedException(typeof(Exception), ExpectedMessage = "ClearItems")]
            public void ClearTest()
            {
                var target = new MockExceptionDictionary();
                target.Clear();
            }


            [Test]
            public void KeysTest()
            {
                var target = new MockStringDictionary {{"a", "b"}, {"f", "b"}, {"g", "b"}};
                var keys = target.Keys;

                Assert.AreEqual(3, keys.Count);
                Assert.IsTrue(keys.Contains("a"));
                Assert.IsTrue(keys.Contains("f"));
                Assert.IsTrue(keys.Contains("g"));
            }


            [Test]
            [ExpectedException(typeof(Exception), ExpectedMessage = "SetItem")]
            public void IndexerTest()
            {
                var target = new MockExceptionDictionary();
                target[2] = 2;
            }


            [Test]
            [ExpectedException(typeof(Exception), ExpectedMessage = "RemoveItem")]
            public void RemoveTest()
            {
                var target = new MockExceptionDictionary();
                target.Remove(2);
            }


            [Test]
            public void ValuesTest()
            {
                var target = new MockStringDictionary {{"a", "b"}, {"f", "s"}, {"g", "z"}};
                var values = target.Values;

                Assert.AreEqual(3, values.Count);
                Assert.IsTrue(values.Contains("b"));
                Assert.IsTrue(values.Contains("s"));
                Assert.IsTrue(values.Contains("z"));
            }

        }

        [TestFixture]
        public class DictionaryBaseIDictionaryTest
        {

            [Test]
            public void AddTest()
            {
                var target = new MockStringDictionary();
                ((IDictionary) target).Add("a", "b");
                Assert.IsTrue(target.ContainsKey("a"));
            }


            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void AddInvalidKeyTypeTest()
            {
                var target = new MockStringDictionary();
                ((IDictionary) target).Add(2, "a");
            }


            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void AddInvalidValueTypeTest()
            {
                var target = new MockStringDictionary();
                ((IDictionary) target).Add("a", 2);
            }


            [Test]
            public void ContainsTest()
            {
                var target = new MockStringDictionary {{"a", "b"}};
                IDictionary dictionary = target;
                Assert.IsTrue(dictionary.Contains("a"));
                Assert.IsFalse(dictionary.Contains("b"));
                Assert.IsFalse(dictionary.Contains("c"));
                Assert.IsFalse(dictionary.Contains(2));
            }


            [Test]
            public void GetEnumeratorTest()
            {
                var target = new MockStringDictionary {{"a", "b"}, {"s", "r"}, {"f", "t"}};
                IDictionary dictionary = target;
                var enumerator = dictionary.GetEnumerator();

                enumerator.MoveNext();
                var current = (DictionaryEntry) enumerator.Current;
                Assert.AreEqual("a", current.Key);
                Assert.AreEqual("b", current.Value);


                enumerator.MoveNext();
                current = (DictionaryEntry) enumerator.Current;
                Assert.AreEqual("s", current.Key);
                Assert.AreEqual("r", current.Value);

                enumerator.MoveNext();
                current = (DictionaryEntry) enumerator.Current;
                Assert.AreEqual("f", current.Key);
                Assert.AreEqual("t", current.Value);
            }


            [Test]
            public void KeysTest()
            {
                var target = new MockStringDictionary {{"a", "b"}, {"f", "b"}, {"g", "b"}};
                var keys = ((IDictionary) target).Keys;

                Assert.AreEqual(3, keys.Count);
                var strings = new string[3];
                keys.CopyTo(strings, 0);
                Assert.AreEqual("a", strings[0]);
                Assert.AreEqual("f", strings[1]);
                Assert.AreEqual("g", strings[2]);
            }


            [Test]
            public void ValuesTest()
            {
                var target = new MockStringDictionary {{"a", "b"}, {"f", "z"}, {"g", "x"}};
                var values = ((IDictionary) target).Values;

                Assert.AreEqual(3, values.Count);
                var strings = new string[3];
                values.CopyTo(strings, 0);
                Assert.AreEqual("b", strings[0]);
                Assert.AreEqual("z", strings[1]);
                Assert.AreEqual("x", strings[2]);
            }


            [Test]
            public void IndexerSetTest()
            {
                var target = new MockStringDictionary();
                ((IDictionary) target)["a"] = "b";
                Assert.IsTrue(target.ContainsKey("a"));
            }


            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void IndexerSetInvalidKeyTypeTest()
            {
                var target = new MockStringDictionary();
                ((IDictionary) target)[2] = "a";
            }


            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void IndexerSetInvalidValueTypeTest()
            {
                var target = new MockStringDictionary();
                ((IDictionary) target)["a"] = 2;
            }


            [Test]
            public void IndexerGetTest()
            {
                var target = new MockStringDictionary {{"a", "b"}};
                Assert.AreEqual("b", ((IDictionary) target)["a"]);
            }


            [Test]
            public void IsFixedSizeTest()
            {
                var target = new MockStringDictionary {{"a", "b"}};
                Assert.IsFalse(((IDictionary) target).IsFixedSize);
            }


            [Test]
            public void IsReadOnlyTest()
            {
                var target = new MockStringDictionary();
                Assert.IsFalse(((IDictionary) target).IsReadOnly);
            }


            [Test]
            public void RemoveTest()
            {
                var target = new MockStringDictionary {{"a", "b"}};
                ((IDictionary) target).Remove("a");

                Assert.IsFalse(target.ContainsKey("a"));
            }

        }


        internal class MockExceptionDictionary : DictionaryBase<int, int>
        {
            protected override void AddItem(int key, int value)
            {
                throw new Exception("AddItem");
            }


            protected override bool RemoveItem(int key)
            {
                throw new Exception("RemoveItem");
            }


            protected override void ClearItems()
            {
                throw new Exception("ClearItems");
            }


            protected override void SetItem(int key, int value)
            {
                throw new Exception("SetItem");
            }

        }

        internal class MockStringDictionary : DictionaryBase<string, string>
        {
            public MockStringDictionary()
            {
            }


            public MockStringDictionary(IDictionary<string, string> dictionary)
                : base(dictionary)
            {
            }


            public MockStringDictionary(IEqualityComparer<string> comparer)
                : base(comparer)
            {
            }


            public MockStringDictionary(int capacity)
                : base(capacity)
            {
            }


            public MockStringDictionary(IDictionary<string, string> dictionary, IEqualityComparer<string> comparer)
                : base(dictionary, comparer)
            {
            }


            public MockStringDictionary(int capacity, IEqualityComparer<string> comparer)
                : base(capacity, comparer)
            {
            }

        }
    }
}