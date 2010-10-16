using System;
using System.Collections;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.DictionaryBaseTests
{
    [TestFixture]
    public class DictionaryBaseIDictionaryTest
    {

        [Test]
        public void AddTest()
        {
            var target = new MockStringDictionary();
            ((IDictionary)target).Add("a", "b");
            Assert.IsTrue(target.ContainsKey("a"));
        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void AddInvalidKeyTypeTest()
        {
            var target = new MockStringDictionary();
            ((IDictionary)target).Add(2, "a");
        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void AddInvalidValueTypeTest()
        {
            var target = new MockStringDictionary();
            ((IDictionary)target).Add("a", 2);
        }


        [Test]
        public void ContainsTest()
        {
            var target = new MockStringDictionary { { "a", "b" } };
            IDictionary dictionary = target;
            Assert.IsTrue(dictionary.Contains("a"));
            Assert.IsFalse(dictionary.Contains("b"));
            Assert.IsFalse(dictionary.Contains("c"));
            Assert.IsFalse(dictionary.Contains(2));
        }


        [Test]
        public void GetEnumeratorTest()
        {
            var target = new MockStringDictionary { { "a", "b" }, { "s", "r" }, { "f", "t" } };
            IDictionary dictionary = target;
            var enumerator = dictionary.GetEnumerator();

            enumerator.MoveNext();
            var current = (DictionaryEntry)enumerator.Current;
            Assert.AreEqual("a", current.Key);
            Assert.AreEqual("b", current.Value);


            enumerator.MoveNext();
            current = (DictionaryEntry)enumerator.Current;
            Assert.AreEqual("s", current.Key);
            Assert.AreEqual("r", current.Value);

            enumerator.MoveNext();
            current = (DictionaryEntry)enumerator.Current;
            Assert.AreEqual("f", current.Key);
            Assert.AreEqual("t", current.Value);
        }


        [Test]
        public void KeysTest()
        {
            var target = new MockStringDictionary { { "a", "b" }, { "f", "b" }, { "g", "b" } };
            var keys = ((IDictionary)target).Keys;

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
            var target = new MockStringDictionary { { "a", "b" }, { "f", "z" }, { "g", "x" } };
            var values = ((IDictionary)target).Values;

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
            ((IDictionary)target)["a"] = "b";
            Assert.IsTrue(target.ContainsKey("a"));
        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IndexerSetInvalidKeyTypeTest()
        {
            var target = new MockStringDictionary();
            ((IDictionary)target)[2] = "a";
        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void IndexerSetInvalidValueTypeTest()
        {
            var target = new MockStringDictionary();
            ((IDictionary)target)["a"] = 2;
        }


        [Test]
        public void IndexerGetTest()
        {
            var target = new MockStringDictionary { { "a", "b" } };
            Assert.AreEqual("b", ((IDictionary)target)["a"]);
        }


        [Test]
        public void IsFixedSizeTest()
        {
            var target = new MockStringDictionary { { "a", "b" } };
            Assert.IsFalse(((IDictionary)target).IsFixedSize);
        }


        [Test]
        public void IsReadOnlyTest()
        {
            var target = new MockStringDictionary();
            Assert.IsFalse(((IDictionary)target).IsReadOnly);
        }


        [Test]
        public void RemoveTest()
        {
            var target = new MockStringDictionary { { "a", "b" } };
            ((IDictionary)target).Remove("a");

            Assert.IsFalse(target.ContainsKey("a"));
        }

    }
}