/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

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