/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.DataStructures.Trees;
using NGenerics.Tests.TestObjects;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.SplayTreeTests
{
    [TestFixture]
    public class Serialization : SplayTreeTest
    {

        [Test]
        public void Simple()
        {
            var splayTree = GetTestTree();
            var newTree = SerializeUtil.BinarySerializeDeserialize(splayTree);

            Assert.AreNotSame(splayTree, newTree);
            Assert.AreEqual(splayTree.Count, newTree.Count);

            var splayTreeEnumerator = splayTree.GetEnumerator();
            var newTreeEnumerator = newTree.GetEnumerator();

            while (splayTreeEnumerator.MoveNext())
            {
                Assert.IsTrue(newTreeEnumerator.MoveNext());
                Assert.AreEqual(splayTreeEnumerator.Current.Key, newTreeEnumerator.Current.Key);
                Assert.AreEqual(splayTreeEnumerator.Current.Value, newTreeEnumerator.Current.Value);

                //TODO: Need a way of accessing an item without splaying
                //Assert.AreEqual(newTree.ContainsKey(splayTreeEnumerator.Current.Key));
                //Assert.AreEqual(newTree[treeEnumerator.Current.Key], splayTreeEnumerator.Current.Value);
            }

            Assert.IsFalse(newTreeEnumerator.MoveNext());
        }

        [Test]
        public void NonIComparable()
        {
            var splayTree = new SplayTree<NonComparableTClass, string>
                                {
                                    {new NonComparableTClass(4), "4"},
                                    {new NonComparableTClass(6), "6"},
                                    {new NonComparableTClass(2), "2"},
                                    {new NonComparableTClass(5), "5"},
                                    {new NonComparableTClass(19), "19"},
                                    {new NonComparableTClass(1), "1"}
                                };


            var newTree = SerializeUtil.BinarySerializeDeserialize(splayTree);

            Assert.AreNotSame(splayTree, newTree);
            Assert.AreEqual(splayTree.Count, newTree.Count);

            var splayTreeEnumerator = splayTree.GetEnumerator();
            var newTreeEnumerator = newTree.GetEnumerator();

            while (splayTreeEnumerator.MoveNext())
            {
                Assert.IsTrue(newTreeEnumerator.MoveNext());
                Assert.AreEqual(splayTreeEnumerator.Current.Key.Number, newTreeEnumerator.Current.Key.Number);
                Assert.AreEqual(splayTreeEnumerator.Current.Value, newTreeEnumerator.Current.Value);

                //TODO: Need a way of accessing an item without splaying
                //Assert.AreEqual(newTree.ContainsKey(splayTreeEnumerator.Current.Key));
                //Assert.AreEqual(newTree[treeEnumerator.Current.Key], splayTreeEnumerator.Current.Value);
            }

            Assert.IsFalse(newTreeEnumerator.MoveNext());
        }

    }
}