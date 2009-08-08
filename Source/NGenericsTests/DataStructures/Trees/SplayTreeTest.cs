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
using NGenerics.Comparers;
using NGenerics.DataStructures.Trees;
using NGenerics.Patterns.Visitor;
using NGenerics.Tests.TestObjects;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees
{
	[TestFixture]
	public class SplayTreeTest
    {
        #region Tests

        [TestFixture]
		public class Accept
		{

			[Test]
			public void Simple()
			{
				var splayTree = GetTestTree();
				var visitor = new TrackingVisitor<KeyValuePair<int, string>>();

				splayTree.AcceptVisitor(visitor);

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
				var splayTree = GetTestTree();
				var visitor = new CompletedTrackingVisitor<KeyValuePair<int, string>>();

				splayTree.AcceptVisitor(visitor);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullVisitor()
			{
				var splayTree = new SplayTree<int, string>();
				splayTree.AcceptVisitor(null);
			}

		}

		[TestFixture]
		public class Add
		{
			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionDuplicate()
			{
				var splayTree = new SplayTree<int, string> {{4, "4"}, {4, "4"}};
			}

			[Test]
			public void Simple()
			{
				var splayTree = new SplayTree<int, string>();

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

					splayTree.Add(gen, gen.ToString());

					Assert.AreEqual(splayTree.Count, i + 1);
					Assert.IsTrue(splayTree.ContainsKey(gen));
				}
			}

			[Test]
			public void KeyValuePair()
			{
				var splayTree = new SplayTree<int, string>();

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

					splayTree.Add(new KeyValuePair<int, string>(gen, gen.ToString()));

					Assert.AreEqual(splayTree.Count, i + 1);
					Assert.IsTrue(splayTree.ContainsKey(gen));
				}
			}

		}

		[TestFixture]
		public class Clear
		{

			[Test]
			public void Simple()
			{
				var splayTree = new SplayTree<int, string>();
				splayTree.Clear();

				Assert.AreEqual(splayTree.Count, 0);

				splayTree = GetTestTree();
				Assert.IsTrue(splayTree.ContainsKey(19));

				splayTree.Clear();
				Assert.AreEqual(splayTree.Count, 0);
				Assert.IsFalse(splayTree.ContainsKey(19));
			}

		}

		[TestFixture]
		public class Contains
		{

			[Test]
			public void Simple()
			{
				var splayTree = new SplayTree<int, string>();

				Assert.IsFalse(splayTree.ContainsKey(5));

				splayTree.Add(4, "4");
				Assert.AreEqual(splayTree[4], "4");
				Assert.IsTrue(splayTree.ContainsKey(4));
				Assert.IsFalse(splayTree.ContainsKey(5));

				splayTree.Add(6, "6");
				Assert.AreEqual(splayTree[6], "6");
				Assert.IsTrue(splayTree.ContainsKey(4));
				Assert.IsFalse(splayTree.ContainsKey(5));
				Assert.IsTrue(splayTree.ContainsKey(6));

				splayTree.Add(2, "2");
				Assert.AreEqual(splayTree[2], "2");
				Assert.IsTrue(splayTree.ContainsKey(2));
				Assert.IsTrue(splayTree.ContainsKey(4));
				Assert.IsFalse(splayTree.ContainsKey(5));
				Assert.IsTrue(splayTree.ContainsKey(6));

				splayTree.Add(5, "5");
				Assert.AreEqual(splayTree[5], "5");
				Assert.IsTrue(splayTree.ContainsKey(2));
				Assert.IsTrue(splayTree.ContainsKey(4));
				Assert.IsTrue(splayTree.ContainsKey(5));
				Assert.IsTrue(splayTree.ContainsKey(6));


				var rand = new Random();

				splayTree = new SplayTree<int, string>();

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

					splayTree.Add(r, null);

					Assert.IsTrue(splayTree.ContainsKey(r));
				}
			}


			[Test]
			public void KeyValuePair()
			{
				var splayTree = new SplayTree<int, string>();

				Assert.IsFalse(splayTree.Contains(new KeyValuePair<int, string>(5, "5")));

				splayTree.Add(4, "4");
				Assert.IsTrue(splayTree.Contains(new KeyValuePair<int, string>(4, "4")));
				Assert.IsFalse(splayTree.Contains(new KeyValuePair<int, string>(4, "5")));

				splayTree.Add(6, "6");
				Assert.IsTrue(splayTree.Contains(new KeyValuePair<int, string>(6, "6")));
				Assert.IsFalse(splayTree.Contains(new KeyValuePair<int, string>(6, "5")));
			}

		}
	
		[TestFixture]
		public class Construcion
		{

			[Test]
			public void Simple()
			{
				var splayTree = new SplayTree<int, string>();

				Assert.AreEqual(splayTree.Count, 0);
                Assert.IsTrue(splayTree.Comparer is KeyValuePairComparer<int, string>);

				splayTree = new SplayTree<int, string>(new ReverseComparer<int>(Comparer<int>.Default));

				Assert.AreEqual(splayTree.Count, 0);
                Assert.IsTrue(splayTree.Comparer.GetType().IsAssignableFrom(typeof(KeyValuePairComparer<int, string>)));
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullComparer()
			{
				new SplayTree<int, string>((IComparer<int>) null);
			}

		}

		[TestFixture]
		public class CopyTo
		{

			[Test]
			public void Simple()
			{
				var splayTree = GetTestTree();

				var array = new KeyValuePair<int, string>[6];
				splayTree.CopyTo(array, 0);

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
                var splayTree = GetTestTree();
				splayTree.CopyTo(null, 1);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExeptionNotEnoughSpaceInTargetArray1()
			{
                var splayTree = GetTestTree();
				var array = new KeyValuePair<int, string>[5];
				splayTree.CopyTo(array, 0);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExeptionNotEnoughSpaceInTargetArray2()
			{
                var splayTree = GetTestTree();
				var array = new KeyValuePair<int, string>[6];
				splayTree.CopyTo(array, 1);
			}

		}

		[TestFixture]
		public class DepthFirstTraversal
		{

			[Test]
			public void Simple()
			{
				var splayTree = new SplayTree<string, int>
				                                  {
				                                      new KeyValuePair<string, int>("horse", 4),
				                                      new KeyValuePair<string, int>("cat", 1),
				                                      new KeyValuePair<string, int>("dog", 2),
				                                      new KeyValuePair<string, int>("canary", 3)
				                                  };

			    var visitor = new TrackingVisitor<KeyValuePair<string, int>>();

				var inOrderVisitor =
					new InOrderVisitor<KeyValuePair<string, int>>(visitor);

				splayTree.DepthFirstTraversal(inOrderVisitor);

				Assert.AreEqual(visitor.TrackingList[0].Key, "canary");
				Assert.AreEqual(visitor.TrackingList[1].Key, "cat");
				Assert.AreEqual(visitor.TrackingList[2].Key, "dog");
				Assert.AreEqual(visitor.TrackingList[3].Key, "horse");
			}

		}

		[TestFixture]
		public class GetEnumerator
		{

			[Test]
			public void Simple()
			{
				var splayTree = GetTestTree();
				var enumerator = splayTree.GetEnumerator();

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
				var splayTree = GetTestTree();
                var enumerator = ((IEnumerable)splayTree).GetEnumerator();

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
			public void KeyValuePairInterface()
			{
				IEnumerable<KeyValuePair<int, string>> splayTree = GetTestTree();
				var enumerator = splayTree.GetEnumerator();

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
		public class GetSortedEnumerator
		{

			[Test]
			public void Simple()
			{
				var splayTree = GetTestTree();
				var enumerator = splayTree.GetOrderedEnumerator();

				var list = new List<KeyValuePair<int, string>>();

				while (enumerator.MoveNext())
				{
					list.Add(enumerator.Current);
				}

				Assert.AreEqual(list.Count, 6);

				Assert.AreEqual(list[0], new KeyValuePair<int, string>(1, "1"));
				Assert.AreEqual(list[1], new KeyValuePair<int, string>(2, "2"));
				Assert.AreEqual(list[2], new KeyValuePair<int, string>(4, "4"));
				Assert.AreEqual(list[3], new KeyValuePair<int, string>(5, "5"));
				Assert.AreEqual(list[4], new KeyValuePair<int, string>(6, "6"));
				Assert.AreEqual(list[5], new KeyValuePair<int, string>(19, "19"));
			}

		}

		[TestFixture]
		public class Indexer
		{

			[Test]
			public void Simple()
			{
				var splayTree = new SplayTree<int, string>();

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

					splayTree.Add(gen, gen.ToString());

					Assert.IsTrue(splayTree.ContainsKey(gen));
					Assert.AreEqual(splayTree[gen], gen.ToString());
				}
			}

			[Test]
			[ExpectedException(typeof(KeyNotFoundException))]
			public void ExceptionInvalidIndexerGet()
			{
				var splayTree = new SplayTree<int, string>();
				var s = splayTree[4];
			}

			[Test]
			[ExpectedException(typeof(KeyNotFoundException))]
            public void ExceptionInvalidIndexerSet()
			{
				var splayTree = new SplayTree<int, string>();
				splayTree[4] = "testString";
			}

			[Test]
			public void Set()
			{
				var splayTree = new SplayTree<int, string>();

				for (var i = 20; i > 10; i--)
				{
					splayTree.Add(i, i.ToString());
				}

				for (var i = 0; i < 10; i++)
				{
					splayTree.Add(i, i.ToString());
				}

				Assert.AreEqual(splayTree[0], "0");
				splayTree[0] = "1";
				Assert.AreEqual(splayTree[0], "1");

				splayTree[1] = "4";
				Assert.AreEqual(splayTree[1], "4");
			}

		}

		[TestFixture]
		public class IsEmpty
		{

			[Test]
			public void Simple()
			{
				var splayTree = new SplayTree<int, string>();
				Assert.IsTrue(splayTree.IsEmpty);

				splayTree = GetTestTree();
				Assert.IsFalse(splayTree.IsEmpty);

				splayTree.Clear();
				Assert.IsTrue(splayTree.IsEmpty);
			}
	
        }

	

		

		[TestFixture]
		public class IsReadOnly
		{

			[Test]
			public void Simple()
			{
				var splayTree = new SplayTree<int, string>();
				Assert.IsFalse(splayTree.IsReadOnly);

				splayTree = GetTestTree();
				Assert.IsFalse(splayTree.IsReadOnly);
			}

		}

		[TestFixture]
		public class Keys
		{

			[Test]
			public void Simple()
			{
				var splayTree = new SplayTree<int, string>();

				for (var i = 20; i > 10; i--)
				{
					splayTree.Add(i, i.ToString());
				}

				for (var i = 0; i <= 10; i++)
				{
					splayTree.Add(i, i.ToString());
				}

				var keys = splayTree.Keys;

				for (var i = 0; i <= 20; i++)
				{
					Assert.IsTrue(keys.Contains(i));
				}

				Assert.AreEqual(keys.Count, 21);
			}

		}

		[TestFixture]
		public class Minimum
		{

			[Test]
			public void Simple()
			{
				var splayTree = GetTestTree();
				var i = splayTree.Minimum;

				Assert.AreEqual(i.Key, 1);
				Assert.AreEqual(i.Value, "1");
			}

			[Test]
			[ExpectedException(typeof(InvalidOperationException))]
			public void ExceptionEmpty()
			{
				var splayTree = new SplayTree<int, string>();
				var i = splayTree.Minimum;
			}

		}

		[TestFixture]
		public class Maximum
		{

			[Test]
			public void Simple()
			{
				var splayTree = GetTestTree();
				var i = splayTree.Maximum;

				Assert.AreEqual(i.Key, 19);
				Assert.AreEqual(i.Value, "19");
			}

			[Test]
			[ExpectedException(typeof(InvalidOperationException))]
			public void ExceptionEmpty()
			{
				var splayTree = new SplayTree<int, string>();
				var i = splayTree.Maximum;
			}

		}

		[TestFixture]
		public class Remove
		{

			[Test]
			public void Simple2()
			{
				var splayTree = new SplayTree<int, string>();

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

					splayTree.Add(gen, gen.ToString());

					Assert.AreEqual(splayTree.Count, i + 1);
					Assert.IsTrue(splayTree.ContainsKey(gen));
				}

				using (var enumerator = dictionary.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Assert.IsTrue(splayTree.Remove(enumerator.Current));
					}
				}
			}

			[Test]
			public void Simple1()
			{
				var splayTree = new SplayTree<int, string>
				                                  {
				                                      {4, "4"},
				                                      {6, "6"},
				                                      {2, "2"},
				                                      {5, "5"},
				                                      {19, "19"},
				                                      {1, "1"}
				                                  };

			    Assert.AreEqual(splayTree.Count, 6);

				Assert.IsTrue(splayTree.ContainsKey(4));
				Assert.IsTrue(splayTree.ContainsKey(6));
				Assert.IsTrue(splayTree.ContainsKey(2));
				Assert.IsTrue(splayTree.ContainsKey(5));
				Assert.IsTrue(splayTree.ContainsKey(19));
				Assert.IsTrue(splayTree.ContainsKey(1));

				Assert.IsFalse(splayTree.Remove(20));

				Assert.IsTrue(splayTree.Remove(4));
				Assert.AreEqual(splayTree.Count, 5);

				Assert.IsFalse(splayTree.ContainsKey(4));
				Assert.IsTrue(splayTree.ContainsKey(6));
				Assert.IsTrue(splayTree.ContainsKey(2));
				Assert.IsTrue(splayTree.ContainsKey(5));
				Assert.IsTrue(splayTree.ContainsKey(19));
				Assert.IsTrue(splayTree.ContainsKey(1));

				Assert.IsTrue(splayTree.Remove(2));
				Assert.AreEqual(splayTree.Count, 4);

				Assert.IsFalse(splayTree.ContainsKey(4));
				Assert.IsTrue(splayTree.ContainsKey(6));
				Assert.IsFalse(splayTree.ContainsKey(2));
				Assert.IsTrue(splayTree.ContainsKey(5));
				Assert.IsTrue(splayTree.ContainsKey(19));
				Assert.IsTrue(splayTree.ContainsKey(1));

				Assert.IsTrue(splayTree.Remove(19));
				Assert.AreEqual(splayTree.Count, 3);

				Assert.IsFalse(splayTree.ContainsKey(4));
				Assert.IsTrue(splayTree.ContainsKey(6));
				Assert.IsFalse(splayTree.ContainsKey(2));
				Assert.IsTrue(splayTree.ContainsKey(5));
				Assert.IsFalse(splayTree.ContainsKey(19));
				Assert.IsTrue(splayTree.ContainsKey(1));

				Assert.IsFalse(splayTree.Remove(20));


				Assert.IsTrue(splayTree.Remove(1));
				Assert.AreEqual(splayTree.Count, 2);

				Assert.IsFalse(splayTree.ContainsKey(4));
				Assert.IsTrue(splayTree.ContainsKey(6));
				Assert.IsFalse(splayTree.ContainsKey(2));
				Assert.IsTrue(splayTree.ContainsKey(5));
				Assert.IsFalse(splayTree.ContainsKey(19));
				Assert.IsFalse(splayTree.ContainsKey(1));

				Assert.IsTrue(splayTree.Remove(6));
				Assert.AreEqual(splayTree.Count, 1);

				Assert.IsFalse(splayTree.ContainsKey(4));
				Assert.IsFalse(splayTree.ContainsKey(6));
				Assert.IsFalse(splayTree.ContainsKey(2));
				Assert.IsTrue(splayTree.ContainsKey(5));
				Assert.IsFalse(splayTree.ContainsKey(19));
				Assert.IsFalse(splayTree.ContainsKey(1));

				Assert.IsTrue(splayTree.Remove(5));
				Assert.AreEqual(splayTree.Count, 0);

				Assert.IsFalse(splayTree.ContainsKey(4));
				Assert.IsFalse(splayTree.ContainsKey(6));
				Assert.IsFalse(splayTree.ContainsKey(2));
				Assert.IsFalse(splayTree.ContainsKey(5));
				Assert.IsFalse(splayTree.ContainsKey(19));
				Assert.IsFalse(splayTree.ContainsKey(1));

				Assert.IsFalse(splayTree.Remove(1));
			}

			[Test]
			public void KeyValuePair()
			{
				var splayTree = new SplayTree<int, string>
				                                  {
				                                      {4, "4"},
				                                      {6, "6"},
				                                      {2, "2"},
				                                      {5, "5"},
				                                      {19, "19"},
				                                      {1, "1"}
				                                  };

			    Assert.AreEqual(splayTree.Count, 6);

				Assert.IsTrue(splayTree.ContainsKey(4));
				Assert.IsTrue(splayTree.ContainsKey(6));
				Assert.IsTrue(splayTree.ContainsKey(2));
				Assert.IsTrue(splayTree.ContainsKey(5));
				Assert.IsTrue(splayTree.ContainsKey(19));
				Assert.IsTrue(splayTree.ContainsKey(1));

				Assert.IsFalse(splayTree.Remove(new KeyValuePair<int, string>(20, "20")));

				Assert.IsTrue(splayTree.Remove(new KeyValuePair<int, string>(4, "4")));
				Assert.AreEqual(splayTree.Count, 5);

				Assert.IsFalse(splayTree.ContainsKey(4));
				Assert.IsTrue(splayTree.ContainsKey(6));
				Assert.IsTrue(splayTree.ContainsKey(2));
				Assert.IsTrue(splayTree.ContainsKey(5));
				Assert.IsTrue(splayTree.ContainsKey(19));
				Assert.IsTrue(splayTree.ContainsKey(1));
			}

		}

		[TestFixture]
		public class Serialization
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

		[TestFixture]
		public class TryGetValue
		{

			[Test]
			public void Simple()
			{
				var splayTree = new SplayTree<int, string>();

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

					splayTree.Add(gen, gen.ToString());

					string val;

					Assert.AreEqual(splayTree.Count, i + 1);

					splayTree.TryGetValue(gen, out val);
					Assert.AreEqual(val, gen.ToString());
					Assert.AreEqual(splayTree[gen], gen.ToString());
				}

				string val2;
				splayTree.TryGetValue(2001, out val2);
				Assert.IsNull(val2);
			}

		}

		[TestFixture]
		public class Values
		{

			[Test]
			public void Simple()
			{
				var splayTree = new SplayTree<int, string>();

				for (var i = 20; i > 10; i--)
				{
					splayTree.Add(i, i.ToString());
				}

				for (var i = 0; i <= 10; i++)
				{
					splayTree.Add(i, i.ToString());
				}

				var values = splayTree.Values;

				for (var i = 0; i <= 20; i++)
				{
					Assert.IsTrue(values.Contains(i.ToString()));
				}

				Assert.AreEqual(values.Count, 21);
			}

        }

        #endregion

        #region Private Members

        private static SplayTree<int, string> GetTestTree()
		{
			var splayTree = new SplayTree<int, string>
			                                  {
			                                      {4, "4"},
			                                      {6, "6"},
			                                      {2, "2"},
			                                      {5, "5"},
			                                      {19, "19"},
			                                      {1, "1"}
			                                  };

            return splayTree;
        }

        #endregion
    }
}
