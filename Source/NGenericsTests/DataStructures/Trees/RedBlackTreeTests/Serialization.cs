/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.Trees;
using NGenerics.Tests.TestObjects;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.RedBlackTreeTests
{
    [TestFixture]
    public class Serialization : RedBlackTreeTest
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
}