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
using NGenerics.Sorting;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees
{
	[TestFixture]
	public class GeneralTreeTest
    {
        #region Tests

        [TestFixture]
		public class Accept
		{

			[Test]
			public void Simple()
			{
				var generalTree = GetTestTree();

				var trackingVisitor = new TrackingVisitor<int>();
				generalTree.AcceptVisitor(trackingVisitor);

				Assert.AreEqual(trackingVisitor.TrackingList.Count, 7);

				Assert.IsTrue(trackingVisitor.TrackingList.Contains(5));
				Assert.IsTrue(trackingVisitor.TrackingList.Contains(2));
				Assert.IsTrue(trackingVisitor.TrackingList.Contains(3));
				Assert.IsTrue(trackingVisitor.TrackingList.Contains(1));
				Assert.IsTrue(trackingVisitor.TrackingList.Contains(9));
				Assert.IsTrue(trackingVisitor.TrackingList.Contains(12));
				Assert.IsTrue(trackingVisitor.TrackingList.Contains(13));
			}

			[Test]
			public void AcceptCompletedVisitor()
			{
				var generalTree = GetTestTree();

				var completedTrackingVisitor = new CompletedTrackingVisitor<int>();
				generalTree.AcceptVisitor(completedTrackingVisitor);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullVisitor()
			{
				var generalTree = GetTestTree();
                generalTree.AcceptVisitor(null);
			}

		}

		[TestFixture]
		public class Add
		{

			[Test]
			public void Simple()
			{
			    var root = new GeneralTree<int>(5);

			    var child1 = new GeneralTree<int>(2);
			    var child2 = new GeneralTree<int>(3);

			    root.Add(child1);
			    root.Add(child2);

			    Assert.AreEqual(child1.Parent, root);
			    Assert.AreEqual(child2.Parent, root);

			    Assert.AreEqual(root.Count, 2);
			    Assert.AreEqual(root.Degree, 2);

			    Assert.AreEqual(root.GetChild(0), child1);
			    Assert.AreEqual(root.GetChild(0).Data, child1.Data);

			    Assert.AreEqual(root.GetChild(1).Data, child2.Data);
			    Assert.AreEqual(root.GetChild(1), child2);

			    root = new GeneralTree<int>(5)
			               {
			                   2,
			                   3
			               };

			    Assert.AreEqual(root.GetChild(0).Data, child1.Data);
			    Assert.AreEqual(root.GetChild(1).Data, child2.Data);

			    Assert.AreEqual(root.GetChild(0).Parent, root);
			    Assert.AreEqual(root.GetChild(1).Parent, root);

			    var anotherRoot = new GeneralTree<int>(2);

			    var movedChild = root.GetChild(0);
			    anotherRoot.Add(movedChild);

			    Assert.AreEqual(movedChild.Parent, anotherRoot);
			    Assert.AreEqual(root.Degree, 1);
			    Assert.AreEqual(root.GetChild(0).Parent, root);
			}

		    [Test]
			public void Interface()
			{
				var root = new GeneralTree<int>(5);

				var child1 = new GeneralTree<int>(2);
				var child2 = new GeneralTree<int>(3);

				((ITree<int>)root).Add(child1);
				((ITree<int>)root).Add(child2);

				Assert.AreEqual(root.Count, 2);
				Assert.AreEqual(root.Degree, 2);

				Assert.AreEqual(root.GetChild(0), child1);
				Assert.AreEqual(root.GetChild(0).Data, child1.Data);

				Assert.AreEqual(root.GetChild(1).Data, child2.Data);
				Assert.AreEqual(root.GetChild(1), child2);
			}

		}

		[TestFixture]
		public class Ancestors
		{
			[Test]
			public void Simple()
			{
				var tree = GetTestTree();
				var ancestors = tree.GetChild(0).GetChild(0).Ancestors;

				Assert.AreEqual(ancestors.Count, 2);
				Assert.AreEqual(ancestors[1], tree.GetChild(0));
				Assert.AreEqual(ancestors[0], tree);

				var root = new GeneralTree<int>(5);

				var child1 = new GeneralTree<int>(2);
				var child2 = new GeneralTree<int>(3);
				var child3 = new GeneralTree<int>(1);

				root.Add(child1);
				root.Add(child2);
				root.Add(child3);

				var child4 = new GeneralTree<int>(9);
				var child5 = new GeneralTree<int>(12);
				var child6 = new GeneralTree<int>(13);
				var child7 = new GeneralTree<int>(15);

				child1.Add(child4);
				child1.Add(child5);
				child2.Add(child6);

				child4.Add(child7);

				ancestors = child7.Ancestors;

				Assert.AreEqual(ancestors.Count, 3);
				
				Assert.AreEqual(ancestors[0], root);
                Assert.AreEqual(ancestors[1], child1);
                Assert.AreEqual(ancestors[2], child4);
			}
		}

		[TestFixture]
		public class ChildNodes
		{

			[Test]
			public void Simple()
			{
				var tree = new GeneralTree<int>(5);

				var originalNodes = new GeneralTree<int>[10];

				for (var i = 10; i < 20; i++)
				{
					originalNodes[i - 10] = new GeneralTree<int>(i);
					tree.Add(originalNodes[i - 10]);
				}

				var childNodes = tree.ChildNodes;

				Assert.AreEqual(childNodes.Count, 10);

				for (var i = 0; i < 10; i++)
				{
					Assert.IsTrue(childNodes.Contains(originalNodes[i]));
				}
			}

		}

		[TestFixture]
		public class Construcion
		{

			[Test]
			public void Simple()
			{
				var generalTree = new GeneralTree<int>(5);

				Assert.AreEqual(generalTree.Count, 0);
				Assert.AreEqual(generalTree.Degree, 0);
				Assert.AreEqual(generalTree.Height, 0);
				Assert.IsTrue(generalTree.IsEmpty);
				Assert.IsTrue(generalTree.IsLeafNode);
				Assert.IsNull(generalTree.Parent);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullData()
			{
				new GeneralTree<string>(null);
			}

		}

		[TestFixture]
		public class Count
		{

			[Test]
			public void Simple()
			{
				var generalTree = GetTestTree();

				Assert.AreEqual(generalTree.Count, 3);

                generalTree.Clear();
				Assert.AreEqual(generalTree.Count, 0);

                generalTree = new GeneralTree<int>(3);

				Assert.AreEqual(generalTree.Count, 0);
				Assert.AreEqual(generalTree.Degree, 0);

                generalTree = GetTestTree();

				Assert.AreEqual(generalTree.Count, 3);
				Assert.AreEqual(generalTree.Degree, 3);
			}

		}

		[TestFixture]
		public class CopyTo
		{

			[Test]
			public void Simple()
			{
				var generalTree = GetTestTree();

				var array = new int[7];
                generalTree.CopyTo(array, 0);

				var list = new List<int>(array);
				Assert.IsTrue(list.Contains(5));
				Assert.IsTrue(list.Contains(2));
				Assert.IsTrue(list.Contains(3));
				Assert.IsTrue(list.Contains(1));
				Assert.IsTrue(list.Contains(9));
				Assert.IsTrue(list.Contains(12));
				Assert.IsTrue(list.Contains(13));
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullArray()
			{
				var generalTree = GetTestTree();
                generalTree.CopyTo(null, 1);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionInvalid1()
			{
				var generalTree = GetTestTree();
				var array = new int[6];
                generalTree.CopyTo(array, 0);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
            public void ExceptionInvalid2()
			{
				var generalTree = GetTestTree();
				var array = new int[7];
                generalTree.CopyTo(array, 1);
			}

		}

		[TestFixture]
		public class Contains
		{

			[Test]
			public void Simple()
			{
				var generalTree = GetTestTree();
				Assert.IsTrue(generalTree.Contains(5));
				Assert.IsTrue(generalTree.Contains(2));
				Assert.IsTrue(generalTree.Contains(3));
				Assert.IsTrue(generalTree.Contains(1));
				Assert.IsTrue(generalTree.Contains(9));
				Assert.IsTrue(generalTree.Contains(12));
				Assert.IsTrue(generalTree.Contains(13));
				Assert.IsFalse(generalTree.Contains(4));
			}

		}

		[TestFixture]
		public class Data
		{

			[Test]
			public void Simple()
			{
				var tree = new GeneralTree<int>(2);

				Assert.AreEqual(tree.Data, 2);

				tree.Data = 5;

				Assert.AreEqual(tree.Data, 5);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionSetNull()
			{
				var tree = new GeneralTree<string>("asdas");
				Assert.AreEqual(tree.Data, "asdas");
				tree.Data = null;
			}

		}

		[TestFixture]
		public class FindNode
		{

			[Test]
			public void Simple()
			{
				var root = new GeneralTree<int>(5);

				var child1 = new GeneralTree<int>(2);
				var child2 = new GeneralTree<int>(3);
				var child3 = new GeneralTree<int>(1);

				root.Add(child1);
				root.Add(child2);
				root.Add(child3);

				var child4 = new GeneralTree<int>(9);
				var child5 = new GeneralTree<int>(12);
				var child6 = new GeneralTree<int>(13);

				child1.Add(child4);
				child1.Add(child5);
				child2.Add(child6);

				Assert.AreEqual(root.FindNode(target => target == 13), child6);

				Assert.AreEqual(root.FindNode(target => target == 2), child1);

				Assert.AreEqual(root.FindNode(target => target == 9), child4);

				Assert.AreEqual(root.FindNode(target => target == 57), null);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullCondition()
			{
				var tree = GetTestTree();
				tree.FindNode(null);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionInterfaceNullCondition()
			{
				var tree = GetTestTree();
				((ITree<int>)tree).FindNode(null);
			}

			[Test]
			public void Interface()
			{
				var root = new GeneralTree<int>(5);

				var child1 = new GeneralTree<int>(2);
				var child2 = new GeneralTree<int>(3);
				var child3 = new GeneralTree<int>(1);

				root.Add(child1);
				root.Add(child2);
				root.Add(child3);

				var child4 = new GeneralTree<int>(9);
				var child5 = new GeneralTree<int>(12);
				var child6 = new GeneralTree<int>(13);

				child1.Add(child4);
				child1.Add(child5);
				child2.Add(child6);

			    ITree<int> tree = root;
			    Assert.AreEqual(tree.FindNode(target => target == 13), child6);

				Assert.AreEqual(tree.FindNode(target => target == 2),child1);

				Assert.AreEqual(tree.FindNode(target => target == 9), child4);

				Assert.AreEqual(tree.FindNode(target => target == 57), null);
			}

		}

		[TestFixture]
		public class GetChild
		{

			[Test]
			public void Interface()
			{
				ITree<int> generalTree = GetTestTree();
				Assert.AreEqual(generalTree.GetChild(0).Data, 2);
				Assert.AreEqual(generalTree.GetChild(1).Data, 3);
				Assert.AreEqual(generalTree.GetChild(2).Data, 1);
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionInvalidSubTree()
			{
				var root = new GeneralTree<int>(5);

				var child1 = new GeneralTree<int>(2);
				var child2 = new GeneralTree<int>(3);

				root.Add(child1);
				root.Add(child2);

				root.GetChild(3);
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionInvalidSubTreeNegative()
			{
				var root = new GeneralTree<int>(5);
				var child1 = new GeneralTree<int>(2);

				root.Add(child1);
				root.GetChild(-1);
			}

		}

		[TestFixture]
		public class GetEnumerator
		{

			[Test]
			public void Simple()
			{
				var generalTree = GetTestTree();
                var enumerator = generalTree.GetEnumerator();

				var itemCount = 7;

				while (enumerator.MoveNext())
				{
					itemCount--;
				}

				Assert.AreEqual(itemCount, 0);
			}

			[Test]
			public void Interface()
			{
				var generalTree = GetTestTree();
                var enumerator = ((IEnumerable)generalTree).GetEnumerator();

				var itemCount = 7;

				while (enumerator.MoveNext())
				{
					itemCount--;
				}

				Assert.AreEqual(itemCount, 0);
			}

		}

        [TestFixture]
        public class GetPath
        {
            [Test]
            public void Simple()
            {
                var tree = GetTestTree();
                var data = tree[0][0].GetPath();

                Assert.AreEqual(data[0], tree);
                Assert.AreEqual(data[1], tree[0]);
            }

            [Test]
            public void SimpleWithConverter()
            {
                var tree = GetTestTree();
                var data = tree[0][0].GetPath(x => x.Data);

                Assert.AreEqual(data[0], 5);
                Assert.AreEqual(data[1], 2);
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void NullConverter()
            {
                var tree = GetTestTree();
                tree.GetPath<int>(null);
            }
        }

		[TestFixture]
		public class Height
		{

			[Test]
			public void Simple()
			{
				var generalTree = new GeneralTree<int>(5);

                Assert.AreEqual(generalTree.Height, 0);

				var s1 = new GeneralTree<int>(3);

                generalTree.Add(s1);

                Assert.AreEqual(generalTree.Height, 1);

				s1.Add(new GeneralTree<int>(6));

                Assert.AreEqual(generalTree.Height, 2);
                generalTree.Add(new GeneralTree<int>(4));

                Assert.AreEqual(generalTree.Height, 2);

                generalTree = GetTestTree();

                Assert.AreEqual(generalTree.Height, 2);
			}

		}

		[TestFixture]
		public class IsEmpty
		{

			[Test]
			public void Simple()
			{
				var generalTree = GetTestTree();
				Assert.IsFalse(generalTree.IsEmpty);

                generalTree.Clear();
				Assert.IsTrue(generalTree.IsEmpty);
			}

		}

		[TestFixture]
		public class IsLeafNode
		{

			[Test]
			public void Simple()
			{
				var generalTree = GetTestTree();
				Assert.IsFalse(generalTree.IsLeafNode);
				Assert.IsTrue(generalTree.GetChild(0).GetChild(0).IsLeafNode);

                generalTree.Clear();
				Assert.IsTrue(generalTree.IsLeafNode);
			}

		}

		[TestFixture]
		public class Index
		{

			[Test]
			public void Simple()
			{
				var generalTree = GetTestTree();
                Assert.AreEqual(generalTree[0].Data, 2);
                Assert.AreEqual(generalTree[1].Data, 3);
                Assert.AreEqual(generalTree[2].Data, 1);
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionInvalidIndex1()
			{
				var root = new GeneralTree<int>(5);

				var child1 = new GeneralTree<int>(2);
				var child2 = new GeneralTree<int>(3);

				root.Add(child1);
				root.Add(child2);

				var i = root[3].Data;
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionInvalidIndex2()
			{
				var root = new GeneralTree<int>(5);
				var i = root[0].Data;
			}

		}

		[TestFixture]
		public class IsReadOnly
		{

			[Test]
			public void Simple()
			{
				var generalTree = new GeneralTree<int>(4);
				Assert.IsFalse(generalTree.IsReadOnly);

                generalTree = GetTestTree();
				Assert.IsFalse(generalTree.IsReadOnly);
			}

		}


		[TestFixture]
		public class BreadthFirstTraversal
		{
			[Test]
			public void Simple()
			{
				var generalTree = GetTestTree();
				var trackingVisitor = new TrackingVisitor<int>();

                generalTree.BreadthFirstTraversal(trackingVisitor);

				var tracks = trackingVisitor.TrackingList;

				Assert.AreEqual(tracks[0], 5);
				Assert.AreEqual(tracks[1], 2);
				Assert.AreEqual(tracks[2], 3);
				Assert.AreEqual(tracks[3], 1);
				Assert.AreEqual(tracks[4], 9);
				Assert.AreEqual(tracks[5], 12);
				Assert.AreEqual(tracks[6], 13);
			}

		}

        [TestFixture]
		public class DepthFirstTraversal
		{

			[Test]
			public void VisitPre()
			{
				var generalTree = GetTestTree();
				var trackingVisitor = new TrackingVisitor<int>();
				var preVisitor = new PreOrderVisitor<int>(trackingVisitor);

                generalTree.DepthFirstTraversal(preVisitor);

				var tracks = trackingVisitor.TrackingList;

				Assert.AreEqual(tracks[0], 5);
				Assert.AreEqual(tracks[1], 2);
				Assert.AreEqual(tracks[2], 9);
				Assert.AreEqual(tracks[3], 12);
				Assert.AreEqual(tracks[4], 3);
				Assert.AreEqual(tracks[5], 13);
				Assert.AreEqual(tracks[6], 1);
			}

			[Test]
			public void TopVisitor()
			{
				var generalTree = GetTestTree();
				var visitor = new ComparableFindingVisitor<int>(13);

                generalTree.BreadthFirstTraversal(visitor);

				Assert.IsTrue(visitor.HasCompleted);
				Assert.IsTrue(visitor.Found);

				visitor = new ComparableFindingVisitor<int>(99);

                generalTree.BreadthFirstTraversal(visitor);

				Assert.IsFalse(visitor.HasCompleted);
				Assert.IsFalse(visitor.Found);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullVisitor()
			{
				var generalTree = GetTestTree();
                generalTree.DepthFirstTraversal(null);
			}

			[Test]
			public void StopVisitor()
			{
				var generalTree = GetTestTree();
				var visitor = new ComparableFindingVisitor<int>(13);
				var preVisitor = new PreOrderVisitor<int>(visitor);

                generalTree.DepthFirstTraversal(preVisitor);

				Assert.IsTrue(((ComparableFindingVisitor<int>)preVisitor.VisitorToUse).Found);
				Assert.IsTrue(((ComparableFindingVisitor<int>)preVisitor.VisitorToUse).HasCompleted);

				visitor = new ComparableFindingVisitor<int>(99);
				preVisitor = new PreOrderVisitor<int>(visitor);

                generalTree.DepthFirstTraversal(preVisitor);
				Assert.IsFalse(((ComparableFindingVisitor<int>)preVisitor.VisitorToUse).Found);
				Assert.IsFalse(((ComparableFindingVisitor<int>)preVisitor.VisitorToUse).HasCompleted);
			}

			[Test]
			public void VisitPost()
			{
				var generalTree = GetTestTree();
				var trackingVisitor = new TrackingVisitor<int>();
				var postVisitor = new PostOrderVisitor<int>(trackingVisitor);

                generalTree.DepthFirstTraversal(postVisitor);

				var tracks = trackingVisitor.TrackingList;

				Assert.AreEqual(tracks[0], 9);
				Assert.AreEqual(tracks[1], 12);
				Assert.AreEqual(tracks[2], 2);
				Assert.AreEqual(tracks[3], 13);
				Assert.AreEqual(tracks[4], 3);
				Assert.AreEqual(tracks[5], 1);
				Assert.AreEqual(tracks[6], 5);
			}

		}

		[TestFixture]
		public class Parent
		{

			[Test]
			public void Set()
			{
				var root = new GeneralTree<int>(5) {2, 3};

			    Assert.AreEqual(root.GetChild(0).Data, 2);
				Assert.AreEqual(root.GetChild(1).Data, 3);

				Assert.AreEqual(root.GetChild(0).Parent, root);
				Assert.AreEqual(root.GetChild(1).Parent, root);

				root.GetChild(0).Parent = root.GetChild(1);

				Assert.AreEqual(root.ChildNodes.Count, 1);
				Assert.AreEqual(root.GetChild(0).ChildNodes.Count, 1);
				Assert.AreEqual(root.GetChild(0).GetChild(0).Data, 2);
				Assert.AreEqual(root.GetChild(0).Data, 3);
				Assert.AreSame(root.GetChild(0).GetChild(0).Parent, root.GetChild(0));
				Assert.AreSame(root.GetChild(0).Parent, root);
			}

			[Test]
			public void Get()
			{
				var root = new GeneralTree<int>(5) {2, 3};


			    root.GetChild(0).Parent = root.GetChild(1);

				Assert.AreSame(((ITree<int>)root.GetChild(0)).Parent, root);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionSetNull()
			{
				var root = new GeneralTree<int>(5) {2, 3};
			    root.ChildNodes[0].Parent = null;
			}

		}

		[TestFixture]
		public class Remove
		{

			[Test]
			public void Simple()
			{
				var root = new GeneralTree<int>(5);

				var child1 = new GeneralTree<int>(2);
				var child2 = new GeneralTree<int>(3);
				var child3 = new GeneralTree<int>(5);
				var child4 = new GeneralTree<int>(7);

				root.Add(child1);
				root.Add(child2);

				Assert.AreEqual(root.Count, 2);
				Assert.AreEqual(root.Degree, 2);

				root.RemoveAt(0);

				Assert.IsNull(child1.Parent);

				Assert.AreEqual(root.Count, 1);
				Assert.AreEqual(root.Degree, 1);
				Assert.AreEqual(root.GetChild(0), child2);
				Assert.AreEqual(root.GetChild(0).Data, 3);

				root.Add(child1);

				Assert.AreEqual(child1.Parent, root);
				Assert.AreEqual(root.Count, 2);
				Assert.AreEqual(root.Degree, 2);

				Assert.IsTrue(root.Remove(child1));
				Assert.IsNull(child1.Parent);

				Assert.AreEqual(root.Count, 1);
				Assert.AreEqual(root.Degree, 1);
				Assert.AreEqual(root.GetChild(0), child2);
				Assert.AreEqual(root.GetChild(0).Data, 3);

				Assert.IsFalse(root.Remove(child3));

				root.Add(child3);
				root.Add(child4);

				Assert.AreEqual(root.Count, 3);
				Assert.AreEqual(root.Degree, 3);

				var fiveNode = root.FindNode(target => target == 5);
				Assert.IsTrue(root.Remove(5));

				Assert.IsNull(fiveNode.Parent);

				Assert.AreEqual(root.Count, 2);
				Assert.AreEqual(root.Degree, 2);
				Assert.AreEqual(root.GetChild(1).Data, 7);

				Assert.IsFalse(root.Remove(13));
			}

			[Test]
			public void Interface()
			{
				ITree<int> tree = new GeneralTree<int>(5);

				var child1 = new GeneralTree<int>(4);
				var child2 = new GeneralTree<int>(6);
				var child3 = new GeneralTree<int>(7);

				tree.Add(child1);
				tree.Add(child2);
				Assert.AreEqual(tree.Degree, 2);
				Assert.IsTrue(tree.Remove(child1));
				Assert.AreEqual(tree.Degree, 1);
				Assert.IsFalse(tree.Remove(child3));
				Assert.AreEqual(tree.Degree, 1);
				Assert.IsTrue(tree.Remove(child2));
				Assert.AreEqual(tree.Degree, 0);
			}

		}

		[TestFixture]
		public class RemoveAt
		{

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExcepionInvalidIndex1()
			{
				var generalTree = new GeneralTree<int>(3);
                generalTree.RemoveAt(1);
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionInvalidIndex2()
			{
				var generalTree = GetTestTree();
                generalTree.RemoveAt(5);
			}

		}

		[TestFixture]
		public class Serialization
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
					Assert.AreEqual(treeEnumerator.Current, newTreeEnumerator.Current);
					Assert.AreEqual(treeEnumerator.Current, newTreeEnumerator.Current);

					Assert.IsTrue(newTree.Contains(treeEnumerator.Current));
				}

				Assert.IsFalse(newTreeEnumerator.MoveNext());
			}

		}

		[TestFixture]
		public class Sort
		{

			[Test]
			[ExpectedException(typeof(NotSupportedException))]
			public void ExceptionInterface()
			{
				ISortable<GeneralTree<int>> tree = GetTestTree();
				tree.Sort(null);
			}

			[Test]
			public void Comparison()
			{
				var tree = GetTestTree();

				tree.Sort(new InsertionSorter<GeneralTree<int>>(), (x, y) => x.Data.CompareTo(y.Data));

				Assert.AreEqual(tree.ChildNodes[0].Data, 1);
				Assert.AreEqual(tree.ChildNodes[1].Data, 2);
				Assert.AreEqual(tree.ChildNodes[2].Data, 3);
			}

			[Test]
			public void Comparer()
			{
				var tree = GetTestTree();

				tree.Sort(new InsertionSorter<GeneralTree<int>>(),
					new GeneralTreeComparer<int>());

				Assert.AreEqual(tree.ChildNodes[0].Data, 1);
				Assert.AreEqual(tree.ChildNodes[1].Data, 2);
				Assert.AreEqual(tree.ChildNodes[2].Data, 3);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullComparisonSorter1()
			{
				var tree = GetTestTree();

				tree.Sort(null,(x, y) => x.Data.CompareTo(y.Data));
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullComparisonSorter2()
			{
				var tree = GetTestTree();

				tree.Sort(null, new GeneralTreeComparer<int>());
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullComparison1()
			{
				var tree = GetTestTree();
				tree.Sort(new InsertionSorter<GeneralTree<int>>(), (Comparison<GeneralTree<int>>)null);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullSorter()
			{
				var tree = GetTestTree();
				tree.Sort(null, SortOrder.Descending);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullComparer1()
			{
				var tree = GetTestTree();

				tree.Sort(new InsertionSorter<GeneralTree<int>>(), (IComparer<GeneralTree<int>>)null);
			}

		}

        [TestFixture]
        public class SortAllDescendants
        {

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullSorter1()
            {
                var tree = GetTestTree();
                tree.SortAllDescendants(null, (x, y) => x.Data.CompareTo(y.Data));
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullSorter2()
            {
                var tree = GetTestTree();
                tree.SortAllDescendants(null, new GeneralTreeComparer<int>());
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullComparison()
            {
                var tree = GetTestTree();
                tree.SortAllDescendants(null, (Comparison<GeneralTree<int>>)null);
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullComparer()
            {
                var tree = GetTestTree();
                tree.SortAllDescendants(null, (IComparer<GeneralTree<int>>)null);
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullSorter3()
            {
                var tree = GetTestTree();

                tree.SortAllDescendants(null, (x, y) => x.Data.CompareTo(y.Data));
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullSorter4()
            {
                var tree = GetTestTree();

                tree.SortAllDescendants(null, new GeneralTreeComparer<int>());
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullComparison2()
            {
                var tree = GetTestTree();
                tree.SortAllDescendants(new InsertionSorter<GeneralTree<int>>(), (Comparison<GeneralTree<int>>)null);
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullComparer2()
            {
                var tree = GetTestTree();

                tree.SortAllDescendants(new InsertionSorter<GeneralTree<int>>(), (IComparer<GeneralTree<int>>)null);
            }

            [Test]
            public void RecursiveSort1()
            {
                var tree = GetMixedTestTree();

                tree.SortAllDescendants(new InsertionSorter<GeneralTree<int>>(), (x, y) => x.Data.CompareTo(y.Data));

                Assert.AreEqual(tree.ChildNodes[0].Data, 1);
                Assert.AreEqual(tree.ChildNodes[1].Data, 2);
                Assert.AreEqual(tree.ChildNodes[2].Data, 3);

                Assert.AreEqual(tree[1].ChildNodes[0].Data, 11);
                Assert.AreEqual(tree[1].ChildNodes[1].Data, 15);

                Assert.AreEqual(tree[2].ChildNodes[0].Data, 13);
            }

            [Test]
            public void RecursiveSort2()
            {
                var tree = GetMixedTestTree();

                tree.SortAllDescendants(new InsertionSorter<GeneralTree<int>>(), new GeneralTreeComparer<int>());

                Assert.AreEqual(tree.ChildNodes[0].Data, 1);
                Assert.AreEqual(tree.ChildNodes[1].Data, 2);
                Assert.AreEqual(tree.ChildNodes[2].Data, 3);

                Assert.AreEqual(tree[1].ChildNodes[0].Data, 11);
                Assert.AreEqual(tree[1].ChildNodes[1].Data, 15);

                Assert.AreEqual(tree[2].ChildNodes[0].Data, 13);
            }
        }

		[TestFixture]
		public new class ToString
		{

			[Test]
			public void Simple()
			{
				var tree = new GeneralTree<int>(2);
				Assert.AreEqual("2", tree.ToString());
			}

        }

        #endregion

        #region Private Members

        private static GeneralTree<int> GetTestTree()
		{
			var root = new GeneralTree<int>(5);

			var child1 = new GeneralTree<int>(2);
			var child2 = new GeneralTree<int>(3);
			var child3 = new GeneralTree<int>(1);

			root.Add(child1);
			root.Add(child2);
			root.Add(child3);

			var child4 = new GeneralTree<int>(9);
			var child5 = new GeneralTree<int>(12);
			var child6 = new GeneralTree<int>(13);

			child1.Add(child4);
			child1.Add(child5);
			child2.Add(child6);

			return root;
		}

		private static GeneralTree<int> GetMixedTestTree()
		{
			var root = new GeneralTree<int>(5);

			var child1 = new GeneralTree<int>(2);
			var child2 = new GeneralTree<int>(3);
			var child3 = new GeneralTree<int>(1);

			root.Add(child1);
			root.Add(child2);
			root.Add(child3);

			var child4 = new GeneralTree<int>(15);
			var child5 = new GeneralTree<int>(11);
			var child6 = new GeneralTree<int>(13);

			child1.Add(child4);
			child1.Add(child5);
			child2.Add(child6);

			return root;
        }

        #endregion
    }
}


