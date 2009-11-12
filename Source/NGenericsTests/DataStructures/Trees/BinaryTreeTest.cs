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
using NGenerics.DataStructures.Trees;
using NGenerics.Patterns.Visitor;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees
{
    [TestFixture]
    public class BinaryTreeTest
    {
        #region Tests

        [TestFixture]
        public class Accept
        {

            [Test]
            public void Simple()
            {
                var binaryTree = GetTestTree();
                var trackingVisitor = new TrackingVisitor<int>();
                binaryTree.AcceptVisitor(trackingVisitor);

                Assert.AreEqual(trackingVisitor.TrackingList.Count, 6);

                Assert.IsTrue(trackingVisitor.TrackingList.Contains(5));
                Assert.IsTrue(trackingVisitor.TrackingList.Contains(2));
                Assert.IsTrue(trackingVisitor.TrackingList.Contains(3));
                Assert.IsTrue(trackingVisitor.TrackingList.Contains(9));
                Assert.IsTrue(trackingVisitor.TrackingList.Contains(12));
                Assert.IsTrue(trackingVisitor.TrackingList.Contains(13));
            }

            [Test]
            public void Completed()
            {
                var binaryTree = GetTestTree();
                var completedTrackingVisitor = new CompletedTrackingVisitor<int>();
                binaryTree.AcceptVisitor(completedTrackingVisitor);
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullVisitor()
            {
                var binaryTree = GetTestTree();
                binaryTree.AcceptVisitor(null);
            }

        }

        [TestFixture]
        public class Add
        {

            [Test]
            public void Simple()
            {
                var binaryTree = new BinaryTree<int>(5);

                Assert.AreEqual(binaryTree.Count, 0);
                Assert.AreEqual(binaryTree.Degree, 0);
                Assert.AreEqual(binaryTree.Data, 5);

                binaryTree.Add(3);

                Assert.AreEqual(binaryTree.Count, 1);
                Assert.AreEqual(binaryTree.Degree, 1);
                Assert.AreEqual(binaryTree.Data, 5);

                Assert.AreEqual(binaryTree.Left.Data, 3);
                Assert.IsNull(binaryTree.Right);

                binaryTree.Add(4);

                Assert.AreEqual(binaryTree.Count, 2);
                Assert.AreEqual(binaryTree.Degree, 2);
                Assert.AreEqual(binaryTree.Data, 5);

                Assert.AreEqual(binaryTree.Left.Data, 3);
                Assert.AreEqual(binaryTree.Right.Data, 4);
            }

            [Test]
            public void Interface()
            {
                ITree<int> binaryTree = new BinaryTree<int>(5);

                var child = new BinaryTree<int>(4);
                binaryTree.Add(child);
                Assert.AreEqual(binaryTree.Degree, 1);
                Assert.AreEqual(binaryTree.GetChild(0), child);
            }

            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionBadAdd1()
            {
                new BinaryTree<int>(5, new BinaryTree<int>(3), new BinaryTree<int>(4))
                                 {
                                     99
                                 };
            }

            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionBadAdd2()
            {
                new BinaryTree<int>(5, new BinaryTree<int>(3), new BinaryTree<int>(4))
                                 {
                                     new BinaryTree<int>(99)
                                 };
            }

        }

        [TestFixture]
        public class BreadthFirstTraversal
        {

            [Test]
            public void Simple()
            {
                var binaryTree = GetTestTree();
                var trackingVisitor = new TrackingVisitor<int>();

                binaryTree.BreadthFirstTraversal(trackingVisitor);

                var tracks = trackingVisitor.TrackingList;

                Assert.AreEqual(tracks[0], 5);
                Assert.AreEqual(tracks[1], 2);
                Assert.AreEqual(tracks[2], 3);
                Assert.AreEqual(tracks[3], 9);
                Assert.AreEqual(tracks[4], 12);
                Assert.AreEqual(tracks[5], 13);
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullVisitor()
            {
                var binaryTree = GetTestTree();
                binaryTree.BreadthFirstTraversal(null);
            }

            [Test]
            public void CompletedVisitor()
            {
                var binaryTree = GetTestTree();
                binaryTree.BreadthFirstTraversal(new CompletedTrackingVisitor<int>());
            }

            [Test]
            public void StopVisitor()
            {
                var binaryTree = GetTestTree();
                var visitor = new ComparableFindingVisitor<int>(13);

                binaryTree.BreadthFirstTraversal(visitor);

                Assert.IsTrue(visitor.HasCompleted);
                Assert.IsTrue(visitor.Found);

                visitor = new ComparableFindingVisitor<int>(99);

                binaryTree.BreadthFirstTraversal(visitor);

                Assert.IsFalse(visitor.HasCompleted);
                Assert.IsFalse(visitor.Found);
            }
        }

        [TestFixture]
        public class Contruction
        {
            [Test]
            public void Simple()
            {
                var binaryTree = new BinaryTree<int>(5);

                Assert.AreEqual(binaryTree.Count, 0);
                Assert.AreEqual(binaryTree.Degree, 0);
                Assert.AreEqual(binaryTree.Data, 5);

                binaryTree = new BinaryTree<int>(5, new BinaryTree<int>(3), new BinaryTree<int>(4));

                Assert.AreEqual(binaryTree.Count, 2);
                Assert.AreEqual(binaryTree.Degree, 2);
                Assert.AreEqual(binaryTree.Data, 5);

                Assert.AreEqual(binaryTree.Left.Data, 3);
                Assert.AreEqual(binaryTree.Right.Data, 4);

                binaryTree = new BinaryTree<int>(5, 3, 4);

                Assert.AreEqual(binaryTree.Count, 2);
                Assert.AreEqual(binaryTree.Degree, 2);
                Assert.AreEqual(binaryTree.Data, 5);

                Assert.AreEqual(binaryTree.Left.Data, 3);
                Assert.AreEqual(binaryTree.Right.Data, 4);
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullData()
            {
                new BinaryTree<string>(null);
            }

        }

        [TestFixture]
        public class Clear
        {

            [Test]
            public void Simple()
            {
                var binaryTree = new BinaryTree<int>(5);
                binaryTree.Clear();

                Assert.AreEqual(binaryTree.Count, 0);
                Assert.IsTrue(binaryTree.IsEmpty);

                binaryTree = GetTestTree();
                binaryTree.Clear();

                Assert.AreEqual(binaryTree.Count, 0);
                Assert.IsTrue(binaryTree.IsEmpty);
            }

        }

        [TestFixture]
        public class Contains
        {

            [Test]
            public void Simple()
            {
                var binaryTree = GetTestTree();
                Assert.IsTrue(binaryTree.Contains(9));
                Assert.IsTrue(binaryTree.Contains(12));
                Assert.IsTrue(binaryTree.Contains(13));
                Assert.IsFalse(binaryTree.Contains(15));
            }

        }

        [TestFixture]
        public class CopyTo
        {

            [Test]
            public void Simple()
            {
                var binaryTree = GetTestTree();

                var array = new int[6];

                binaryTree.CopyTo(array, 0);

                for (var i = 0; i < array.Length; i++)
                {
                    Assert.AreNotEqual(array[i], 0);
                }

                var list = new List<int>();
                list.AddRange(array);

                Assert.IsTrue(list.Contains(2));
                Assert.IsTrue(list.Contains(3));
                Assert.IsTrue(list.Contains(5));
                Assert.IsTrue(list.Contains(9));
                Assert.IsTrue(list.Contains(12));
                Assert.IsTrue(list.Contains(13));
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void Exception1()
            {
                var binaryTree = GetTestTree();

                var array = new int[5];

                binaryTree.CopyTo(array, 0);
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void Exception2()
            {
                var binaryTree = GetTestTree();

                var array = new int[6];

                binaryTree.CopyTo(array, 1);
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullArray()
            {
                var binaryTree = GetTestTree();
                binaryTree.CopyTo(null, 1);
            }

        }

        [TestFixture]
        public class Data
        {

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNull()
            {
                var binaryTree = new BinaryTree<string>("asdasd");
                Assert.AreEqual(binaryTree.Data, "asdasd");

                binaryTree.Data = null;
            }

            [Test]
            public void Simple()
            {
                var binaryTree = GetTestTree();
                binaryTree.Data = 2;

                Assert.AreEqual(binaryTree.Data, 2);
            }

        }

        [TestFixture]
        public class DepthFirstTraversal
        {

            [Test]
            public void Pre()
            {
                var binaryTree = GetTestTree();
                var trackingVisitor = new TrackingVisitor<int>();
                var preVisitor = new PreOrderVisitor<int>(trackingVisitor);

                binaryTree.DepthFirstTraversal(preVisitor);

                var tracks = trackingVisitor.TrackingList;

                Assert.AreEqual(tracks[0], 5);
                Assert.AreEqual(tracks[1], 2);
                Assert.AreEqual(tracks[2], 9);
                Assert.AreEqual(tracks[3], 12);
                Assert.AreEqual(tracks[4], 3);
                Assert.AreEqual(tracks[5], 13);
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullVisitor()
            {
                var binaryTree = GetTestTree();
                binaryTree.DepthFirstTraversal(null);
            }

            [Test]
            public void VisitIn()
            {
                var binaryTree = GetTestTree();
                var trackingVisitor = new TrackingVisitor<int>();
                var inVisitor = new InOrderVisitor<int>(trackingVisitor);

                binaryTree.DepthFirstTraversal(inVisitor);

                var tracks = trackingVisitor.TrackingList;

                Assert.AreEqual(tracks[0], 9);
                Assert.AreEqual(tracks[1], 2);
                Assert.AreEqual(tracks[2], 12);
                Assert.AreEqual(tracks[3], 5);
                Assert.AreEqual(tracks[4], 13);
                Assert.AreEqual(tracks[5], 3);
            }

            [Test]
            public void StopVisitor()
            {
                var binaryTree = GetTestTree();
                var visitor = new CompletedTrackingVisitor<int>();
                var preVisitor = new PreOrderVisitor<int>(visitor);

                binaryTree.DepthFirstTraversal(preVisitor);
            }

            [Test]
            public void Post()
            {
                var binaryTree = GetTestTree();
                var trackingVisitor = new TrackingVisitor<int>();
                var postVisitor = new PostOrderVisitor<int>(trackingVisitor);

                binaryTree.DepthFirstTraversal(postVisitor);

                var tracks = trackingVisitor.TrackingList;

                Assert.AreEqual(tracks[0], 9);
                Assert.AreEqual(tracks[1], 12);
                Assert.AreEqual(tracks[2], 2);
                Assert.AreEqual(tracks[3], 13);
                Assert.AreEqual(tracks[4], 3);
                Assert.AreEqual(tracks[5], 5);
            }

        }

        [TestFixture]
        public class FindNode
        {

            [Test]
            public void Simple()
            {
                var binaryTree = new BinaryTree<int>(5);

                var child1 = new BinaryTree<int>(2);
                var child2 = new BinaryTree<int>(3);

                binaryTree.Add(child1);
                binaryTree.Add(child2);

                var child4 = new BinaryTree<int>(9);
                var child5 = new BinaryTree<int>(12);
                var child6 = new BinaryTree<int>(13);

                child1.Add(child4);
                child1.Add(child5);
                child2.Add(child6);

                Assert.AreEqual(binaryTree.FindNode(target => target == 2), child1);

                Assert.AreEqual(binaryTree.FindNode(target => target == 9), child4);

                Assert.AreEqual(binaryTree.FindNode(target => target == 13), child6);

                Assert.AreEqual(binaryTree.FindNode(target => target == 57), null);
            }

            [Test]
            public void Interface()
            {
                var rootBinaryTree = new BinaryTree<int>(5);

                var child1 = new BinaryTree<int>(2);
                var child2 = new BinaryTree<int>(3);

                rootBinaryTree.Add(child1);
                rootBinaryTree.Add(child2);

                var child4 = new BinaryTree<int>(9);
                var child5 = new BinaryTree<int>(12);
                var child6 = new BinaryTree<int>(13);

                child1.Add(child4);
                child1.Add(child5);
                child2.Add(child6);

                ITree<int> tree = rootBinaryTree;
                Assert.AreEqual(tree.FindNode(target => target == 2), child1);

                Assert.AreEqual(tree.FindNode(target => target == 9), child4);

                Assert.AreEqual(tree.FindNode(target => target == 13), child6
                    );

                Assert.AreEqual(tree.FindNode(target => target == 57), null);
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExcetpionInterfaceNullCondition()
            {
                var binaryTree = GetTestTree();
                ((ITree<int>)binaryTree).FindNode(null);
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExcepionNullCondition()
            {
                var binaryTree = GetTestTree();
                binaryTree.FindNode(null);
            }

        }

        [TestFixture]
        public class GetChild
        {

            [Test]
            public void Simple()
            {
                ITree<int> binaryTree = new BinaryTree<int>(5);

                var child1 = new BinaryTree<int>(4);
                var child2 = new BinaryTree<int>(6);

                binaryTree.Add(child1);
                binaryTree.Add(child2);
                Assert.AreEqual(binaryTree.Degree, 2);
                Assert.AreEqual(binaryTree.GetChild(0), child1);
                Assert.AreEqual(binaryTree.GetChild(1), child2);
            }

        }

        [TestFixture]
        public class GetEnumerator
        {

            [Test]
            public void Simple()
            {
                var binaryTree = GetTestTree();
                var enumerator = binaryTree.GetEnumerator();

                var itemCount = 6;

                while (enumerator.MoveNext())
                {
                    itemCount--;
                }

                Assert.AreEqual(itemCount, 0);
            }

            [Test]
            public void Interface()
            {
                IEnumerable binaryTree = GetTestTree();
                var enumerator = binaryTree.GetEnumerator();

                var itemCount = 6;

                while (enumerator.MoveNext())
                {
                    itemCount--;
                }

                Assert.AreEqual(itemCount, 0);
            }

        }

        [TestFixture]
        public class Height
        {

            [Test]
            public void Simple()
            {
                var binaryTree = new BinaryTree<int>(5);

                Assert.AreEqual(binaryTree.Height, 0);

                binaryTree.Add(3);

                var s1 = binaryTree.Left;


                Assert.AreEqual(binaryTree.Height, 1);

                s1.Add(6);

                Assert.AreEqual(binaryTree.Height, 2);
                binaryTree.Add(4);

                Assert.AreEqual(binaryTree.Height, 2);

                binaryTree = GetTestTree();

                Assert.AreEqual(binaryTree.Height, 2);
            }

        }

        [TestFixture]
        public class IsLeafNode
        {

            [Test]
            public void Simple()
            {
                var binaryTree = GetTestTree();
                Assert.IsFalse(binaryTree.IsLeafNode);
                Assert.IsTrue(binaryTree.GetChild(0).GetChild(0).IsLeafNode);

                binaryTree.Clear();
                Assert.IsTrue(binaryTree.IsLeafNode);
            }

        }

        [TestFixture]
        public class Index
        {

            [Test]
            public void Simple()
            {
                var binaryTree = GetTestTree();

                Assert.AreEqual(binaryTree[0].Data, 2);
                Assert.AreEqual(binaryTree[1].Data, 3);
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ExceptionBadIndexer()
            {
                var binaryTree = GetTestTree();

                var i = binaryTree[2].Data;
            }

        }

        [TestFixture]
        public class IsReadOnly
        {

            [Test]
            public void Simple()
            {
                var binaryTree = GetTestTree();
                Assert.IsFalse(binaryTree.IsReadOnly);
            }

        }

        [TestFixture]
        public class IsFull
        {

            [Test]
            public void Simple()
            {
                var binaryTree = new BinaryTree<int>(4);
                Assert.IsFalse(binaryTree.IsFull);

                binaryTree.Left = new BinaryTree<int>(3);
                Assert.IsFalse(binaryTree.IsFull);

                binaryTree.Right = new BinaryTree<int>(4);
                Assert.IsTrue(binaryTree.IsFull);

                binaryTree.RemoveLeft();
                Assert.IsFalse(binaryTree.IsFull);
            }

        }


        [TestFixture]
        public class Left
        {
            [Test]
            public void Simple()
            {
                var binaryTree = GetTestTree();
                binaryTree.Left = new BinaryTree<int>(99);
                Assert.AreEqual(binaryTree.Left.Data, 99);
                Assert.IsNotNull(binaryTree.Right);
                Assert.AreNotEqual(binaryTree.Right.Data, 99);
            }
        }

        [TestFixture]
        public class Remove
        {

            [Test]
            public void Interface()
            {
                ITree<int> binaryTree = new BinaryTree<int>(5);

                var child1 = new BinaryTree<int>(4);
                var child2 = new BinaryTree<int>(6);
                var child3 = new BinaryTree<int>(7);

                binaryTree.Add(child1);
                binaryTree.Add(child2);
                Assert.AreEqual(binaryTree.Degree, 2);
                Assert.IsTrue(binaryTree.Remove(child1));
                Assert.AreEqual(binaryTree.Degree, 1);
                Assert.IsFalse(binaryTree.Remove(child3));
                Assert.AreEqual(binaryTree.Degree, 1);
                Assert.IsTrue(binaryTree.Remove(child2));
                Assert.AreEqual(binaryTree.Degree, 0);
            }

            [Test]
            public void Simple()
            {
                var binaryTree = GetTestTree();

                Assert.IsTrue(binaryTree.Remove(2));
                Assert.IsFalse(binaryTree.Remove(5));
                Assert.IsTrue(binaryTree.Remove(3));

                Assert.IsNull(binaryTree.Left);
                Assert.IsNull(binaryTree.Right);
            }

        }

        [TestFixture]
        public class RemoveRight
        {

            [Test]
            public void Simple()
            {
                var binaryTree = GetTestTree();

                binaryTree.RemoveRight();

                Assert.IsNull(binaryTree.Right);
                Assert.IsNotNull(binaryTree.Left);
            }

        }

        [TestFixture]
        public class RemoveLeft
        {

            [Test]
            public void Simple()
            {
                var binaryTree = GetTestTree();

                binaryTree.RemoveLeft();

                Assert.IsNull(binaryTree.Left);
                Assert.IsNotNull(binaryTree.Right);
            }

        }

        [TestFixture]
        public class Right
        {

            [Test]
            public void Simple()
            {
                var binaryTree = GetTestTree();
                binaryTree.Right = new BinaryTree<int>(99);

                Assert.IsNotNull(binaryTree.Left);
                Assert.AreNotEqual(binaryTree.Left.Data, 99);
                Assert.AreEqual(binaryTree.Right.Data, 99);
            }

        }

        [TestFixture]
        public class Serialization
        {

            [Test]
            public void Simple()
            {
                var binaryTree = GetTestTree();
                var newTree = SerializeUtil.BinarySerializeDeserialize(binaryTree);

                Assert.AreNotSame(binaryTree, newTree);
                Assert.AreEqual(binaryTree.Count, newTree.Count);

                var treeEnumerator = binaryTree.GetEnumerator();
                var newTreeEnumerator = newTree.GetEnumerator();

                while (treeEnumerator.MoveNext())
                {
                    Assert.IsTrue(newTreeEnumerator.MoveNext());
                    Assert.AreEqual(treeEnumerator.Current, newTreeEnumerator.Current);
                    Assert.AreEqual(treeEnumerator.Current, newTreeEnumerator.Current);

                    Assert.IsTrue(newTree.Contains(treeEnumerator.Current));
                }

                Assert.IsFalse(newTreeEnumerator.MoveNext());
            }

        }

        #endregion

        #region Private Members

        private static BinaryTree<int> GetTestTree()
        {
            var rootBinaryTree = new BinaryTree<int>(5);

            var child1 = new BinaryTree<int>(2);
            var child2 = new BinaryTree<int>(3);

            rootBinaryTree.Add(child1);
            rootBinaryTree.Add(child2);

            var child4 = new BinaryTree<int>(9);
            var child5 = new BinaryTree<int>(12);
            var child6 = new BinaryTree<int>(13);

            child1.Add(child4);
            child1.Add(child5);
            child2.Add(child6);

            return rootBinaryTree;
        }

        #endregion
    }
}