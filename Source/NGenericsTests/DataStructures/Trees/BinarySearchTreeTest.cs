/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using System.Collections;
using System.Collections.Generic;
using NGenerics.Comparers;
using NGenerics.DataStructures.Trees;
using NGenerics.Patterns.Visitor;
using NGenerics.Tests.TestObjects;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees
{
	[TestFixture]
	public class BinarySearchTreeTest
    {
        #region Tests

        [TestFixture]
		public class Accept
		{

			[Test]
			public void Simple()
			{
				var tree = GetTestTree();
				var visitor = new TrackingVisitor<KeyValuePair<int, string>>();

				tree.AcceptVisitor(visitor);

				Assert.IsTrue(visitor.TrackingList.Contains(new KeyValuePair<int, string>(4, "4")));
				Assert.IsTrue(visitor.TrackingList.Contains(new KeyValuePair<int, string>(6, "6")));
				Assert.IsTrue(visitor.TrackingList.Contains(new KeyValuePair<int, string>(2, "2")));
				Assert.IsTrue(visitor.TrackingList.Contains(new KeyValuePair<int, string>(5, "5")));
				Assert.IsTrue(visitor.TrackingList.Contains(new KeyValuePair<int, string>(19, "19")));
				Assert.IsTrue(visitor.TrackingList.Contains(new KeyValuePair<int, string>(1, "1")));

				Assert.AreEqual(visitor.TrackingList.Count, 6);
			}

			[Test]
			public void CompletedVisitor()
			{
				var tree = GetTestTree();
				var visitor = new CompletedTrackingVisitor<KeyValuePair<int, string>>();

				tree.AcceptVisitor(visitor);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullVisitor()
			{
				var tree = new BinarySearchTree<int, string>();
				tree.AcceptVisitor(null);
			}

		}

		[TestFixture]
		public class Add
		{

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionDuplicateAdd()
			{
				var tree = new BinarySearchTree<int, string>();
				tree.Add(4, "4");
				tree.Add(4, "4");
			}

			[Test]
			public void KeyValuePair()
			{
				var tree = new BinarySearchTree<int, string>();

				var dictionary = new Dictionary<int, string>();

				var rand = new Random(Convert.ToInt32(DateTime.Now.Ticks % Int32.MaxValue));

				for (var i = 0; i < 50; i++)
				{
					var gen = rand.Next(2000);

					while (dictionary.ContainsKey(gen))
					{
						gen = rand.Next(2000);
					}

					dictionary.Add(gen, null);

					tree.Add(new KeyValuePair<int, string>(gen, gen.ToString()));

					Assert.AreEqual(tree.Count, i + 1);
					Assert.IsTrue(tree.ContainsKey(gen));
				}
			}

			[Test]
			public void Simple()
			{
				var tree = new BinarySearchTree<int, string>();

				var dictionary = new Dictionary<int, string>();

				var rand = new Random(Convert.ToInt32(DateTime.Now.Ticks % Int32.MaxValue));

				for (var i = 0; i < 50; i++)
				{
					var gen = rand.Next(2000);

					while (dictionary.ContainsKey(gen))
					{
						gen = rand.Next(2000);
					}

					dictionary.Add(gen, null);

					tree.Add(gen, gen.ToString());

					Assert.AreEqual(tree.Count, i + 1);
					Assert.IsTrue(tree.ContainsKey(gen));
				}
			}

		}
	
		[TestFixture]
		public class Construction
		{

			[Test]
			public void Simple()
			{
				var tree = new BinarySearchTree<int, string>();

				Assert.AreEqual(tree.Count, 0);
				Assert.IsTrue(tree.Comparer is KeyValuePairComparer<int, string>);

				tree = new BinarySearchTree<int, string>(new ReverseComparer<int>(Comparer<int>.Default));

				Assert.AreEqual(tree.Count, 0);
                Assert.IsTrue(tree.Comparer.GetType().IsAssignableFrom(typeof(KeyValuePairComparer<int, string>)));
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullComparer()
			{
                new BinarySearchTree<int, string>((IComparer<int>) null);
			}

		}

		[TestFixture]
		public class DepthFirstTraversal
		{

			[Test]
			public void Simple()
			{
				var tree = new BinarySearchTree<string, int>
				                                         {
				                                             new KeyValuePair<string, int>("horse", 4),
				                                             new KeyValuePair<string, int>("cat", 1),
				                                             new KeyValuePair<string, int>("dog", 2),
				                                             new KeyValuePair<string, int>("canary", 3)
				                                         };

			    var visitor = new TrackingVisitor<KeyValuePair<string, int>>();

				var inOrderVisitor =
					new InOrderVisitor<KeyValuePair<string, int>>(visitor);

				tree.DepthFirstTraversal(inOrderVisitor);

				Assert.AreEqual(visitor.TrackingList[0].Key, "canary");
				Assert.AreEqual(visitor.TrackingList[1].Key, "cat");
				Assert.AreEqual(visitor.TrackingList[2].Key, "dog");
				Assert.AreEqual(visitor.TrackingList[3].Key, "horse");
			}

		}

		[TestFixture]
		public class Contains
		{

			[Test]
			public void Simple()
			{
				var tree = new BinarySearchTree<int, string>();

				Assert.IsFalse(tree.ContainsKey(5));

				tree.Add(4, "4");
				Assert.AreEqual(tree[4], "4");
				Assert.IsTrue(tree.ContainsKey(4));
				Assert.IsFalse(tree.ContainsKey(5));

				tree.Add(6, "6");
				Assert.AreEqual(tree[6], "6");
				Assert.IsTrue(tree.ContainsKey(4));
				Assert.IsFalse(tree.ContainsKey(5));
				Assert.IsTrue(tree.ContainsKey(6));

				tree.Add(2, "2");
				Assert.AreEqual(tree[2], "2");
				Assert.IsTrue(tree.ContainsKey(2));
				Assert.IsTrue(tree.ContainsKey(4));
				Assert.IsFalse(tree.ContainsKey(5));
				Assert.IsTrue(tree.ContainsKey(6));

				tree.Add(5, "5");
				Assert.AreEqual(tree[5], "5");
				Assert.IsTrue(tree.ContainsKey(2));
				Assert.IsTrue(tree.ContainsKey(4));
				Assert.IsTrue(tree.ContainsKey(5));
				Assert.IsTrue(tree.ContainsKey(6));


				var rand = new Random();

				tree = new BinarySearchTree<int, string>();

				var list = new List<int>();

				for (var i = 0; i < 100; i++)
				{
					int r;

					do
					{
						r = rand.Next(5000);
					}
					while (list.Contains(r));

					list.Add(r);

					tree.Add(r, null);

					Assert.IsTrue(tree.ContainsKey(r));
				}
			}


			[Test]
			public void KeyValuePair()
			{
				var tree = new BinarySearchTree<int, string>();

				Assert.IsFalse(tree.Contains(new KeyValuePair<int, string>(5, "5")));

				tree.Add(4, "4");
				Assert.IsTrue(tree.Contains(new KeyValuePair<int, string>(4, "4")));
				Assert.IsFalse(tree.Contains(new KeyValuePair<int, string>(4, "5")));

				tree.Add(6, "6");
				Assert.IsTrue(tree.Contains(new KeyValuePair<int, string>(6, "6")));
				Assert.IsFalse(tree.Contains(new KeyValuePair<int, string>(6, "5")));
			}

		}

		[TestFixture]
		public class Clear
		{

			[Test]
			public void Simple()
			{
				var tree = new BinarySearchTree<int, string>();
				tree.Clear();

				Assert.AreEqual(tree.Count, 0);

				tree = GetTestTree();
				Assert.IsTrue(tree.ContainsKey(19));

				tree.Clear();
				Assert.AreEqual(tree.Count, 0);
				Assert.IsFalse(tree.ContainsKey(19));
			}

		}

		[TestFixture]
		public class CopyTo
		{

			[Test]
			public void Simple()
			{
				var binarySearchTree = GetTestTree();

				var array = new KeyValuePair<int, string>[6];
				binarySearchTree.CopyTo(array, 0);

				var list = new List<KeyValuePair<int, string>>(array);

				Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(4, "4")));
				Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(6, "6")));
				Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(2, "2")));
				Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(5, "5")));
				Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(19, "19")));
				Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(1, "1")));

				Assert.AreEqual(list.Count, 6);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullArray()
			{
                var binarySearchTree = GetTestTree();
				binarySearchTree.CopyTo(null, 1);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionInvalidArrayLength1()
			{
                var binarySearchTree = GetTestTree();
				var array = new KeyValuePair<int, string>[5];
				binarySearchTree.CopyTo(array, 0);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionInvalidArrayLength2()
			{
                var binarySearchTree = GetTestTree();
				var array = new KeyValuePair<int, string>[6];
				binarySearchTree.CopyTo(array, 1);
			}

		}

		[TestFixture]
		public class GetEnumerator
		{

			[Test]
			public void Simple()
			{
				var tree = GetTestTree();
				var enumerator = tree.GetEnumerator();

				var list = new List<KeyValuePair<int, string>>();

				while (enumerator.MoveNext())
				{
					list.Add(enumerator.Current);
				}

				Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(4, "4")));
				Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(6, "6")));
				Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(2, "2")));
				Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(5, "5")));
				Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(19, "19")));
				Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(1, "1")));

				Assert.AreEqual(list.Count, 6);
			}

			[Test]
			public void Interface()
			{
				var tree = GetTestTree();
				var enumerator = ((IEnumerable)tree).GetEnumerator();

				var list = new List<KeyValuePair<int, string>>();

				while (enumerator.MoveNext())
				{
					list.Add((KeyValuePair<int, string>)enumerator.Current);
				}

				Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(4, "4")));
				Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(6, "6")));
				Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(2, "2")));
				Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(5, "5")));
				Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(19, "19")));
				Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(1, "1")));

				Assert.AreEqual(list.Count, 6);
			}

			[Test]
			public void InterfaceKeyValuePair()
			{
				IEnumerable<KeyValuePair<int, string>> tree = GetTestTree();
				var enumerator = tree.GetEnumerator();

				var list = new List<KeyValuePair<int, string>>();

				while (enumerator.MoveNext())
				{
					list.Add(enumerator.Current);
				}

				Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(4, "4")));
				Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(6, "6")));
				Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(2, "2")));
				Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(5, "5")));
				Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(19, "19")));
				Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(1, "1")));

				Assert.AreEqual(list.Count, 6);
			}

		}

		[TestFixture]
        public class GetOrderedEnumerator
		{

			[Test]
			public void Simple()
			{
				var tree = GetTestTree();
				var enumerator = tree.GetOrderedEnumerator();

				var list = new List<KeyValuePair<int, string>>();

				while (enumerator.MoveNext())
				{
					list.Add(enumerator.Current);
				}

				Assert.AreEqual(1, list[0].Key);
				Assert.AreEqual("1", list[0].Value);
				Assert.AreEqual(2, list[1].Key);
				Assert.AreEqual("2", list[1].Value);
				Assert.AreEqual(4, list[2].Key);
				Assert.AreEqual("4", list[2].Value);
				Assert.AreEqual(5, list[3].Key);
				Assert.AreEqual("5", list[3].Value);
				Assert.AreEqual(6, list[4].Key);
				Assert.AreEqual("6", list[4].Value);
				Assert.AreEqual(19, list[5].Key);
				Assert.AreEqual("19", list[5].Value);

				Assert.AreEqual(list.Count, 6);
			}

		}

		[TestFixture]
		public class Index
		{

			[Test]
			public void Simple()
			{
				var tree = new BinarySearchTree<int, string>();

				var dictionary = new Dictionary<int, string>();

				var rand = new Random(Convert.ToInt32(DateTime.Now.Ticks % Int32.MaxValue));

				for (var i = 0; i < 50; i++)
				{
					var gen = rand.Next(2000);

					while (dictionary.ContainsKey(gen))
					{
						gen = rand.Next(2000);
					}

					dictionary.Add(gen, null);

					tree.Add(gen, gen.ToString());

					Assert.IsTrue(tree.ContainsKey(gen));
					Assert.AreEqual(tree[gen], gen.ToString());
				}
			}

			[Test]
			public void Set()
			{
				var tree = new BinarySearchTree<int, string>();

				for (var i = 20; i > 10; i--)
				{
					tree.Add(i, i.ToString());
				}

				for (var i = 0; i < 10; i++)
				{
					tree.Add(i, i.ToString());
				}

				Assert.AreEqual(tree[0], "0");
				tree[0] = "1";
				Assert.AreEqual(tree[0], "1");

				tree[1] = "4";
				Assert.AreEqual(tree[1], "4");
			}

			[Test]
			[ExpectedException(typeof(KeyNotFoundException))]
			public void ExceptionGetInvalidKey()
			{
				var tree = new BinarySearchTree<int, string>();
				var s = tree[4];
			}

			[Test]
			[ExpectedException(typeof(KeyNotFoundException))]
			public void ExceptionSetInvalidKey()
			{
				var tree = new BinarySearchTree<int, string>();
				tree[4] = "testString";
			}

		}

		[TestFixture]
		public class IsEmpty
		{

			[Test]
			public void Simple()
			{
				var tree = new BinarySearchTree<int, string>();
				Assert.IsTrue(tree.IsEmpty);

				tree = GetTestTree();
				Assert.IsFalse(tree.IsEmpty);

				tree.Clear();
				Assert.IsTrue(tree.IsEmpty);
			}

		}



		[TestFixture]
		public class IsReadOnly
		{

			[Test]
			public void Simple()
			{
				var tree = new BinarySearchTree<int, string>();
				Assert.IsFalse(tree.IsReadOnly);

				tree = GetTestTree();
				Assert.IsFalse(tree.IsReadOnly);
			}

		}

		[TestFixture]
		public class Keys
		{

			[Test]
			public void Simple()
			{
				var tree = new BinarySearchTree<int, string>();

				for (var i = 20; i > 10; i--)
				{
					tree.Add(i, i.ToString());
				}

				for (var i = 0; i <= 10; i++)
				{
					tree.Add(i, i.ToString());
				}

				var keys = tree.Keys;

				for (var i = 0; i <= 20; i++)
				{
					Assert.IsTrue(keys.Contains(i));
				}

				Assert.AreEqual(keys.Count, 21);
			}

		}

		[TestFixture]
		public class Maximum
		{

			[Test]
			public void Simple()
			{
				var tree = GetTestTree();
				var i = tree.Maximum;

				Assert.AreEqual(i.Key, 19);
				Assert.AreEqual(i.Value, "19");
			}

			[Test]
			[ExpectedException(typeof(InvalidOperationException))]
			public void ExceptionInvalidMax()
			{
				var tree = new BinarySearchTree<int, string>();
				var i = tree.Maximum;
			}

		}

		[TestFixture]
		public class Minimum
		{

			[Test]
			public void Simple()
			{
				var tree = GetTestTree();
				var i = tree.Minimum;

				Assert.AreEqual(i.Key, 1);
				Assert.AreEqual(i.Value, "1");
			}

			[Test]
			[ExpectedException(typeof(InvalidOperationException))]
			public void ExceptionInvalidMin()
			{
				var tree = new BinarySearchTree<int, string>();
				var i = tree.Minimum;
			}

		}

		[TestFixture]
		public class Remove
		{

			[Test]
			public void Simple()
			{
				var tree = new BinarySearchTree<int, string>();

				var dictionary = new Dictionary<int, string>();

				var rand = new Random(Convert.ToInt32(DateTime.Now.Ticks % Int32.MaxValue));

				for (var i = 0; i < 50; i++)
				{
					var gen = rand.Next(2000);

					while (dictionary.ContainsKey(gen))
					{
						gen = rand.Next(2000);
					}

					dictionary.Add(gen, null);

					tree.Add(gen, gen.ToString());

					Assert.AreEqual(tree.Count, i + 1);
					Assert.IsTrue(tree.ContainsKey(gen));
				}

				using (var enumerator = dictionary.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Assert.IsTrue(tree.Remove(enumerator.Current));
					}
				}
			}

			[Test]
			public void Simple2()
			{
				var tree = new BinarySearchTree<int, string>
				                                         {
				                                             {4, "4"},
				                                             {6, "6"},
				                                             {2, "2"},
				                                             {5, "5"},
				                                             {19, "19"},
				                                             {1, "1"}
				                                         };

			    Assert.AreEqual(tree.Count, 6);

				Assert.IsTrue(tree.ContainsKey(4));
				Assert.IsTrue(tree.ContainsKey(6));
				Assert.IsTrue(tree.ContainsKey(2));
				Assert.IsTrue(tree.ContainsKey(5));
				Assert.IsTrue(tree.ContainsKey(19));
				Assert.IsTrue(tree.ContainsKey(1));

				Assert.IsFalse(tree.Remove(20));

				Assert.IsTrue(tree.Remove(4));
				Assert.AreEqual(tree.Count, 5);

				Assert.IsFalse(tree.ContainsKey(4));
				Assert.IsTrue(tree.ContainsKey(6));
				Assert.IsTrue(tree.ContainsKey(2));
				Assert.IsTrue(tree.ContainsKey(5));
				Assert.IsTrue(tree.ContainsKey(19));
				Assert.IsTrue(tree.ContainsKey(1));

				Assert.IsTrue(tree.Remove(2));
				Assert.AreEqual(tree.Count, 4);

				Assert.IsFalse(tree.ContainsKey(4));
				Assert.IsTrue(tree.ContainsKey(6));
				Assert.IsFalse(tree.ContainsKey(2));
				Assert.IsTrue(tree.ContainsKey(5));
				Assert.IsTrue(tree.ContainsKey(19));
				Assert.IsTrue(tree.ContainsKey(1));

				Assert.IsTrue(tree.Remove(19));
				Assert.AreEqual(tree.Count, 3);

				Assert.IsFalse(tree.ContainsKey(4));
				Assert.IsTrue(tree.ContainsKey(6));
				Assert.IsFalse(tree.ContainsKey(2));
				Assert.IsTrue(tree.ContainsKey(5));
				Assert.IsFalse(tree.ContainsKey(19));
				Assert.IsTrue(tree.ContainsKey(1));

				Assert.IsFalse(tree.Remove(20));


				Assert.IsTrue(tree.Remove(1));
				Assert.AreEqual(tree.Count, 2);

				Assert.IsFalse(tree.ContainsKey(4));
				Assert.IsTrue(tree.ContainsKey(6));
				Assert.IsFalse(tree.ContainsKey(2));
				Assert.IsTrue(tree.ContainsKey(5));
				Assert.IsFalse(tree.ContainsKey(19));
				Assert.IsFalse(tree.ContainsKey(1));

				Assert.IsTrue(tree.Remove(6));
				Assert.AreEqual(tree.Count, 1);

				Assert.IsFalse(tree.ContainsKey(4));
				Assert.IsFalse(tree.ContainsKey(6));
				Assert.IsFalse(tree.ContainsKey(2));
				Assert.IsTrue(tree.ContainsKey(5));
				Assert.IsFalse(tree.ContainsKey(19));
				Assert.IsFalse(tree.ContainsKey(1));

				Assert.IsTrue(tree.Remove(5));
				Assert.AreEqual(tree.Count, 0);

				Assert.IsFalse(tree.ContainsKey(4));
				Assert.IsFalse(tree.ContainsKey(6));
				Assert.IsFalse(tree.ContainsKey(2));
				Assert.IsFalse(tree.ContainsKey(5));
				Assert.IsFalse(tree.ContainsKey(19));
				Assert.IsFalse(tree.ContainsKey(1));

				Assert.IsFalse(tree.Remove(1));
			}

			[Test]
			public void KeyValuePair()
			{
				var tree = new BinarySearchTree<int, string>
				                                         {
				                                             {4, "4"},
				                                             {6, "6"},
				                                             {2, "2"},
				                                             {5, "5"},
				                                             {19, "19"},
				                                             {1, "1"}
				                                         };

			    Assert.AreEqual(tree.Count, 6);

				Assert.IsTrue(tree.ContainsKey(4));
				Assert.IsTrue(tree.ContainsKey(6));
				Assert.IsTrue(tree.ContainsKey(2));
				Assert.IsTrue(tree.ContainsKey(5));
				Assert.IsTrue(tree.ContainsKey(19));
				Assert.IsTrue(tree.ContainsKey(1));

				Assert.IsFalse(tree.Remove(new KeyValuePair<int, string>(20, "20")));

				Assert.IsTrue(tree.Remove(new KeyValuePair<int, string>(4, "4")));
				Assert.AreEqual(tree.Count, 5);

				Assert.IsFalse(tree.ContainsKey(4));
				Assert.IsTrue(tree.ContainsKey(6));
				Assert.IsTrue(tree.ContainsKey(2));
				Assert.IsTrue(tree.ContainsKey(5));
				Assert.IsTrue(tree.ContainsKey(19));
				Assert.IsTrue(tree.ContainsKey(1));
			}

		}

		[TestFixture]
		public class Serializability
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

		[TestFixture]
		public class TryGetValue
		{

			[Test]
			public void Simple()
			{
				var tree = new BinarySearchTree<int, string>();

				var dictionary = new Dictionary<int, string>();

				var rand = new Random(Convert.ToInt32(DateTime.Now.Ticks % Int32.MaxValue));

				for (var i = 0; i < 50; i++)
				{
					var gen = rand.Next(2000);

					while (dictionary.ContainsKey(gen))
					{
						gen = rand.Next(2000);
					}

					dictionary.Add(gen, null);

					tree.Add(gen, gen.ToString());

					string val;

					Assert.AreEqual(tree.Count, i + 1);

					tree.TryGetValue(gen, out val);
					Assert.AreEqual(val, gen.ToString());
					Assert.AreEqual(tree[gen], gen.ToString());
				}

				string val2;
				tree.TryGetValue(2001, out val2);
				Assert.IsNull(val2);
			}

		}

		[TestFixture]
		public class Values
		{

			[Test]
			public void Simple()
			{
				var tree = new BinarySearchTree<int, string>();

				for (var i = 20; i > 10; i--)
				{
					tree.Add(i, i.ToString());
				}

				for (var i = 0; i <= 10; i++)
				{
					tree.Add(i, i.ToString());
				}

				var values = tree.Values;

				for (var i = 0; i <= 20; i++)
				{
					Assert.IsTrue(values.Contains(i.ToString()));
				}

				Assert.AreEqual(values.Count, 21);
			}

        }

        #endregion

        #region Private Members

        private static BinarySearchTree<int, string> GetTestTree()
		{
			var tree = new BinarySearchTree<int, string>
			                                         {
			                                             {4, "4"},
			                                             {6, "6"},
			                                             {2, "2"},
			                                             {5, "5"},
			                                             {19, "19"},
			                                             {1, "1"}
			                                         };

            return tree;
        }

        #endregion 
    }
}
