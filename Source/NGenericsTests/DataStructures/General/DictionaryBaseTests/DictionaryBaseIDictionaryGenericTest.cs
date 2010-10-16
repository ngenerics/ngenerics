using System;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.DictionaryBaseTests
{
    [TestFixture]
    public class DictionaryBaseIDictionaryGenericTest
    {


        [Test]
        [ExpectedException(typeof(Exception), ExpectedMessage = "AddItem")]
        public void AddTest()
        {
            new MockExceptionDictionary
                {
                    {2, 2}
                };
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
            var target = new MockStringDictionary { { "a", "b" }, { "f", "b" }, { "g", "b" } };
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
            var target = new MockStringDictionary { { "a", "b" }, { "f", "s" }, { "g", "z" } };
            var values = target.Values;

            Assert.AreEqual(3, values.Count);
            Assert.IsTrue(values.Contains("b"));
            Assert.IsTrue(values.Contains("s"));
            Assert.IsTrue(values.Contains("z"));
        }

    }
}