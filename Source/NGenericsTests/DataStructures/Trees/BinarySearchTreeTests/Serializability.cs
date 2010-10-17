/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.Trees;
using NGenerics.Tests.TestObjects;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinarySearchTreeTests
{
    [TestFixture]
    public class Serializability : BinarySearchTreeTest
    {

        [Test]
        public void Simple()
        {
            var tree = GetTestTree();
            var newTree = SerializeUtil.BinarySerializeDeserialize(tree);

            Assert.AreNotSame(tree, newTree);
            Assert.AreEqual(tree.Count, newTree.Count);

            var treeEnumerator = tree.GetEnumerator();
            var newTreeEnumerator = newTree.GetEnumerator();

            while (treeEnumerator.MoveNext())
            {
                Assert.IsTrue(newTreeEnumerator.MoveNext());
                Assert.AreEqual(treeEnumerator.Current.Key, newTreeEnumerator.Current.Key);
                Assert.AreEqual(treeEnumerator.Current.Value, newTreeEnumerator.Current.Value);

                Assert.IsTrue(newTree.ContainsKey(treeEnumerator.Current.Key));
                Assert.AreEqual(newTree[treeEnumerator.Current.Key], treeEnumerator.Current.Value);
            }

            Assert.IsFalse(newTreeEnumerator.MoveNext());
        }

        [Test]
        public void NonIComparable()
        {
            var tree = new BinarySearchTree<NonComparableTClass, string>
                           {
                               {new NonComparableTClass(4), "4"},
                               {new NonComparableTClass(6), "6"},
                               {new NonComparableTClass(2), "2"},
                               {new NonComparableTClass(5), "5"},
                               {new NonComparableTClass(19), "19"},
                               {new NonComparableTClass(1), "1"}
                           };
            var newTree = SerializeUtil.BinarySerializeDeserialize(tree);

            Assert.AreNotSame(tree, newTree);
            Assert.AreEqual(tree.Count, newTree.Count);

            var treeEnumerator = tree.GetEnumerator();
            var newTreeEnumerator = newTree.GetEnumerator();

            while (treeEnumerator.MoveNext())
            {
                Assert.IsTrue(newTreeEnumerator.MoveNext());
                Assert.AreEqual(treeEnumerator.Current.Key.Number, newTreeEnumerator.Current.Key.Number);
                Assert.AreEqual(treeEnumerator.Current.Value, newTreeEnumerator.Current.Value);

                Assert.IsTrue(newTree.ContainsKey(treeEnumerator.Current.Key));
                Assert.AreEqual(newTree[treeEnumerator.Current.Key], treeEnumerator.Current.Value);
            }

            Assert.IsFalse(newTreeEnumerator.MoveNext());
        }

    }
}