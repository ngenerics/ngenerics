using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NGenerics.Tests.TestObjects;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SkipListTests
{
    [TestFixture]
    public class Serialization
    {
        [Test]
        public void Simple()
        {
            var skipList = new SkipList<int, string>();

            for (var i = 0; i < 100; i++)
            {
                skipList.Add(new KeyValuePair<int, string>(i, i.ToString()));
            }

            var newSkipList = SerializeUtil.BinarySerializeDeserialize(skipList);

            Assert.AreNotSame(skipList, newSkipList);
            Assert.AreEqual(skipList.Count, newSkipList.Count);

            var sEnumerator = skipList.GetEnumerator();
            var newSkipListEnumerator = newSkipList.GetEnumerator();

            while (sEnumerator.MoveNext())
            {
                Assert.IsTrue(newSkipListEnumerator.MoveNext());

                Assert.AreEqual(sEnumerator.Current.Key, newSkipListEnumerator.Current.Key);
                Assert.AreEqual(sEnumerator.Current.Value, newSkipListEnumerator.Current.Value);
            }

            Assert.IsFalse(newSkipListEnumerator.MoveNext());
        }


        [Test]
        public void NonIComparable()
        {
            var skipList = new SkipList<NonComparableTClass, string>();

            for (var i = 0; i < 100; i++)
            {
                skipList.Add(new KeyValuePair<NonComparableTClass, string>(new NonComparableTClass(i), i.ToString()));
            }

            var newSkipList = SerializeUtil.BinarySerializeDeserialize(skipList);

            Assert.AreNotSame(skipList, newSkipList);
            Assert.AreEqual(skipList.Count, newSkipList.Count);

            var sEnumerator = skipList.GetEnumerator();
            var newSkipListEnumerator = newSkipList.GetEnumerator();

            while (sEnumerator.MoveNext())
            {
                Assert.IsTrue(newSkipListEnumerator.MoveNext());

                Assert.AreEqual(sEnumerator.Current.Key.Number, newSkipListEnumerator.Current.Key.Number);
                Assert.AreEqual(sEnumerator.Current.Value, newSkipListEnumerator.Current.Value);
            }

            Assert.IsFalse(newSkipListEnumerator.MoveNext());
        }
    }
}