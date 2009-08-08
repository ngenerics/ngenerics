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
using NGenerics.DataStructures.General;
using NGenerics.Patterns.Visitor;
using NGenerics.Tests.TestObjects;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General
{
	[TestFixture]
	public class SkipListTest
	{

		[TestFixture]
		public class Accept
		{

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullVisitor()
			{
				var skipList = new SkipList<int, string>();
				skipList.AcceptVisitor(null);
			}

			[Test]
			public void Simple()
			{
				var skipList = new SkipList<int, string>();

				for (var i = 0; i < 100; i++)
				{
					skipList.Add(i, i.ToString());
				}

				var visitor = new TrackingVisitor<KeyValuePair<int, string>>();

                skipList.AcceptVisitor(visitor);

				Assert.AreEqual(visitor.TrackingList.Count, 100);

				using (var enumerator = skipList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						Assert.IsTrue(visitor.TrackingList.Contains(enumerator.Current));
					}
				}
			}

			[Test]
			public void DoneVisitor()
			{
				var skipList = new SkipList<int, string>();

				for (var i = 0; i < 20; i++)
				{
					skipList.Add(i, i.ToString());
				}

				var completedTrackingVisitor = new CompletedTrackingVisitor<KeyValuePair<int, string>>();

                skipList.AcceptVisitor(completedTrackingVisitor);
			}

		}

		[TestFixture]
		public class Add
		{

			[Test]
			public void Sequential()
			{
				var skipList = new SkipList<int, string>();

				for (var i = 0; i < 500; i++)
				{
					if ((i % 2) == 0)
					{
						skipList.Add(i, i.ToString());
					}
					else
					{
						skipList.Add(new KeyValuePair<int, string>(i, i.ToString()));
					}

					Assert.AreEqual(skipList.Count, i + 1);
					Assert.AreEqual(skipList[i], i.ToString());
				}
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionDuplicate1()
			{
                var skipList = new SkipList<int, string>();

				for (var i = 0; i < 20; i++)
				{
					skipList.Add(i, i.ToString());
				}

				skipList.Add(5, "5");
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionDuplicate2()
			{
                var skipList = new SkipList<int, string>();

				for (var i = 0; i < 20; i++)
				{
					skipList.Add(i, i.ToString());
				}

				skipList.Add(0, "0");
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionDuplicate3()
			{
                var skipList = new SkipList<int, string>();

				for (var i = 0; i < 20; i++)
				{
					skipList.Add(i, i.ToString());
				}

				skipList.Add(19, "19");
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExcetpionDuplicate4()
			{
                var skipList = new SkipList<int, string>();

				for (var i = 0; i < 20; i++)
				{
					skipList.Add(i, i.ToString());
				}

				skipList.Add(10, "15");
			}

			[Test]
			public void Reverse()
			{
                var skipList = new SkipList<int, string>();

				var counter = 0;

				for (var i = 499; i >= 0; i--)
				{
					if ((i % 2) == 0)
					{
						skipList.Add(i, i.ToString());
					}
					else
					{
						skipList.Add(new KeyValuePair<int, string>(i, i.ToString()));
					}

					counter++;

					Assert.AreEqual(skipList.Count, counter);
					Assert.AreEqual(skipList[i], i.ToString());
				}
			}

		}
	
		[TestFixture]
		public class Construction
		{

			[Test]
			public void Simple1()
			{
                var skipList = new SkipList<int, string>();

				Assert.AreEqual(0, skipList.Count);
                Assert.AreEqual(Comparer<int>.Default, skipList.Comparer);
                Assert.AreEqual(.5, skipList.Probability);
                Assert.AreEqual(16, skipList.MaximumListLevel);

			}
			[Test]
			public void Simple2()
			{
                var skipList = new SkipList<int, string>(Comparer<int>.Default);

                Assert.AreEqual(0, skipList.Count);
                Assert.AreEqual(Comparer<int>.Default, skipList.Comparer);
                Assert.AreEqual(.5, skipList.Probability);
                Assert.AreEqual(16, skipList.MaximumListLevel);

			}
			[Test]
			public void Simple3()
			{
                var skipList = new SkipList<int, string>(Comparer<int>.Default);
				Assert.AreEqual(0, skipList.Count);
                Assert.AreEqual(Comparer<int>.Default, skipList.Comparer);
                Assert.AreEqual(.5, skipList.Probability);
                Assert.AreEqual(16, skipList.MaximumListLevel);
			}
			[Test]
			public void Simple4()
			{
			    var comparison = new Comparison<int>(CompareMethod);
			    var skipList = new SkipList<int, string>(10, .2, comparison);
				Assert.AreEqual(0, skipList.Count);
                Assert.IsTrue(skipList.Comparer is ComparisonComparer<int>);
                Assert.AreEqual(.2, skipList.Probability);
                Assert.AreEqual(10, skipList.MaximumListLevel);
			}

		    private int CompareMethod(int x, int y)
		    {
		        throw new NotImplementedException();
		    }

		    [Test]
			public void Simple5()
			{
                var skipList = new SkipList<int, string>(14, 0.7, Comparer<int>.Default);
				Assert.AreEqual(skipList.Count, 0);
                Assert.AreEqual(Comparer<int>.Default, skipList.Comparer);
                Assert.AreEqual(0.7, skipList.Probability);
                Assert.AreEqual(14, skipList.MaximumListLevel);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullComparer1()
			{
				new SkipList<int, string>((IComparer<int>) null);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullComparer2()
			{
                new SkipList<int, string>(2, 0.6, (IComparer<int>) null);
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionMaximumLevelBelowOne1()
			{
				new SkipList<int, string>(-1, 0.5, Comparer<int>.Default);
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionMaximumLevelBelowOne2()
			{
				new SkipList<int, string>(0, 1, Comparer<int>.Default);
			}

			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionInvalidProbability1()
			{
				new SkipList<int, string>(0, 0.5, Comparer<int>.Default);
			}
			[Test]
			[ExpectedException(typeof(ArgumentOutOfRangeException))]
			public void ExceptionInvalidProbability2()
			{
				new SkipList<int, string>(5, 0, Comparer<int>.Default);
			}


		}

		[TestFixture]
		public class Count
		{

			[Test]
			public void Simple()
			{
                var skipList = new SkipList<int, string>();
				Assert.AreEqual(skipList.Count, 0);

				skipList.Add(2, "2");
				Assert.AreEqual(skipList.Count, 1);

				skipList.Add(3, "3");
				Assert.AreEqual(skipList.Count, 2);
			}

		}

		[TestFixture]
		public class Clear
		{

			[Test]
			public void Simple()
			{
				var skipList = new SkipList<int, string>();
				Assert.AreEqual(skipList.Count, 0);

				skipList.Add(4, "a");
				Assert.AreEqual(skipList.Count, 1);

				skipList.Clear();
				Assert.AreEqual(skipList.Count, 0);

				skipList.Add(5, "a");
				skipList.Add(6, "a");
				Assert.AreEqual(skipList.Count, 2);

				skipList.Clear();
				Assert.AreEqual(skipList.Count, 0);
			}

		}

		[TestFixture]
		public class Contains
		{

			[Test]
			public void KeyValuePair()
			{
				var skipList = new SkipList<int, string>();

				for (var i = 0; i < 100; i++)
				{
					skipList.Add(i, i.ToString());
				}

				Assert.IsTrue(skipList.Contains(new KeyValuePair<int, string>(5, "5")));
				Assert.IsTrue(skipList.Contains(new KeyValuePair<int, string>(6, "6")));

				Assert.IsFalse(skipList.Contains(new KeyValuePair<int, string>(5, "6")));
				Assert.IsFalse(skipList.Contains(new KeyValuePair<int, string>(100, "100")));
			}

		}

		[TestFixture]
		public class ContainsKey
		{

			[Test]
			public void Simple()
			{
				var skipList = new SkipList<int, string>();

				for (var i = 0; i < 100; i++)
				{
					skipList.Add(i, i.ToString());
					Assert.IsTrue(skipList.ContainsKey(i));
				}

				for (var i = 100; i < 150; i++)
				{
					Assert.IsFalse(skipList.ContainsKey(i));
				}
			}

		}

		[TestFixture]
		public class CurrentListLevel
		{

			[Test]
			public void Simple()
			{
				var skipList = new SkipList<int, string>();
				Assert.AreEqual(skipList.CurrentListLevel, 0);

				for (var i = 0; i < 100; i++)
				{
					skipList.Add(new KeyValuePair<int, string>(i, i.ToString()));
				}

				Assert.Greater(skipList.CurrentListLevel, 0);
			}

		}

		[TestFixture]
		public class CopyTo
		{

			[Test]
			public void Simple()
			{
				var skipList = new SkipList<int, string>();

				var pairs = new KeyValuePair<int, string>[5];

				for (var i = 0; i < pairs.Length; i++)
				{
					pairs[i] = new KeyValuePair<int, string>(i, i.ToString());
					skipList.Add(pairs[i]);
				}

				var array = new KeyValuePair<int, string>[50];

				skipList.CopyTo(array, 0);

				var list = new List<KeyValuePair<int, string>>
				                                        {
				                                            array[0],
				                                            array[1],
				                                            array[2],
				                                            array[3],
				                                            array[4],
				                                            array[5]
				                                        };

			    for (var i = 0; i < pairs.Length; i++)
				{
					Assert.IsTrue(list.Contains(pairs[i]));
				}
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionInvalid1()
			{
				var skipList = new SkipList<int, string>();

				var pairs = new KeyValuePair<int, string>[5];

				for (var i = 0; i < pairs.Length; i++)
				{
					pairs[i] = new KeyValuePair<int, string>(i, i.ToString());
					skipList.Add(pairs[i]);
				}

				var array = new KeyValuePair<int, string>[4];

				skipList.CopyTo(array, 0);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionInvalid2()
			{
				var skipList = new SkipList<int, string>();

				var pairs = new KeyValuePair<int, string>[5];

				for (var i = 0; i < pairs.Length; i++)
				{
					pairs[i] = new KeyValuePair<int, string>(i, i.ToString());
					skipList.Add(pairs[i]);
				}

				var array = new KeyValuePair<int, string>[4];

				skipList.CopyTo(array, 0);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionInvalid3()
			{
				var skipList = new SkipList<int, string>();

				var pairs = new KeyValuePair<int, string>[5];

				for (var i = 0; i < pairs.Length; i++)
				{
					pairs[i] = new KeyValuePair<int, string>(i, i.ToString());
					skipList.Add(pairs[i]);
				}

				skipList.CopyTo(null, 0);
			}

		}

		[TestFixture]
		public class GetEnumerator
		{

			[Test]
			public void Simple()
			{
				var skipList = new SkipList<int, string>();

				var originalList = new List<KeyValuePair<int, string>>();

				for (var i = 0; i < 100; i++)
				{
					originalList.Add(new KeyValuePair<int, string>(i, i.ToString()));
					skipList.Add(originalList[i]);
				}

				var list = new List<KeyValuePair<int, string>>();

				using (var enumerator = skipList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						list.Add(enumerator.Current);
					}
				}

				Assert.AreEqual(list.Count, 100);

				for (var i = 0; i < 100; i++)
				{
					Assert.IsTrue(list.Contains(originalList[i]));
				}
			}

			[Test]
			public void Interface()
			{
				var skipList = new SkipList<int, string>();

				var originalList = new List<KeyValuePair<int, string>>();

				for (var i = 0; i < 100; i++)
				{
					originalList.Add(new KeyValuePair<int, string>(i, i.ToString()));
					skipList.Add(originalList[i]);
				}

				var list = new List<KeyValuePair<int, string>>();

				var enumerator = ((IEnumerable)skipList).GetEnumerator();
				{
					while (enumerator.MoveNext())
					{
						list.Add((KeyValuePair<int, string>)enumerator.Current);
					}
				}

				Assert.AreEqual(list.Count, 100);

				for (var i = 0; i < 100; i++)
				{
					Assert.IsTrue(list.Contains(originalList[i]));
				}
			}

		}

		[TestFixture]
		public class IsReadOnly
		{

			[Test]
			public void Simple()
			{
				var skipList = new SkipList<int, string>();
				Assert.IsFalse(skipList.IsReadOnly);

				skipList.Add(4, "a");
				Assert.IsFalse(skipList.IsReadOnly);
			}

		}

	

		[TestFixture]
		public class Index
		{

			[Test]
			public void Set()
			{
				var skipList = new SkipList<int, string> {{1, "1"}};

			    skipList[1] = "2";

				Assert.AreEqual(skipList[1], "2");

				skipList.Add(2, "2");

				skipList[2] = "3";

				Assert.AreEqual(skipList[2], "3");
			}

			[Test]
			[ExpectedException(typeof(KeyNotFoundException))]
			public void ExceptionInvalidItemGet1()
			{
				var skipList = new SkipList<int, string>();
				var v = skipList[10];
			}

			[Test]
			[ExpectedException(typeof(KeyNotFoundException))]
			public void ExceptionInvalidItemGet2()
			{
				var skipList = new SkipList<int, string> {{1, "aa"}};
			    var v = skipList[2];
			}

			[Test]
			[ExpectedException(typeof(KeyNotFoundException))]
			public void ExceptionInvalidItemset1()
			{
				var skipList = new SkipList<int, string>();
				skipList[10] = "2";
			}

			[Test]
			[ExpectedException(typeof(KeyNotFoundException))]
			public void ExceptionInvalidItemset2()
			{
				var skipList = new SkipList<int, string> {{1, "aa"}};
			    skipList[10] = "2";
			}

		}


		[TestFixture]
		public class IsEmpty
		{

			[Test]
			public void Simple()
			{
				var skipList = new SkipList<int, string>();
				Assert.IsTrue(skipList.IsEmpty);

				skipList.Add(4, "a");
				Assert.IsFalse(skipList.IsEmpty);

				skipList.Clear();
				Assert.IsTrue(skipList.IsEmpty);
			}

		}

		[TestFixture]
		public class Keys
		{

			[Test]
			public void Simple()
			{
				var skipList = new SkipList<int, string>();

				for (var i = 0; i < 100; i++)
				{
					skipList.Add(i, i.ToString());
				}

				var list = new List<int>();
				list.AddRange(skipList.Keys);

				Assert.AreEqual(list.Count, 100);

				for (var i = 0; i < 100; i++)
				{
					Assert.IsTrue(list.Contains(i));
				}
			}

		}

		[TestFixture]
		public class Remove
		{

			[Test]
			public void Simple()
			{
				var skipList = new SkipList<int, string>();

				for (var i = 0; i < 100; i++)
				{
					skipList.Add(i, i.ToString());
				}

				for (var i = 0; i < 100; i++)
				{
					if ((i % 2) == 0)
					{
						Assert.IsTrue(skipList.Remove(i));
					}
					else
					{
						Assert.IsTrue(skipList.Remove(new KeyValuePair<int, string>(i, "a")));
					}

					Assert.AreEqual(skipList.Count, 99 - i);
					Assert.IsFalse(skipList.ContainsKey(i));
				}
			}
			[Test]
			public void ItemNotInList1()
			{
				var skipList = new SkipList<int, string>();
				Assert.IsFalse(skipList.Remove(4));
			}

			[Test]
			public void ItemNotInList2()
			{
				var skipList = new SkipList<int, string>();
				Assert.IsFalse(skipList.Remove(new KeyValuePair<int, string>(3, "3")));
			}

		}

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

		[TestFixture]
		public class TryGetValue
		{

			[Test]
			public void Simple()
			{
				var skipList = new SkipList<int, string>();
				string val;
				Assert.IsFalse(skipList.TryGetValue(5, out val));

				skipList.Add(3, "4");
				Assert.IsFalse(skipList.TryGetValue(5, out val));
				Assert.IsTrue(skipList.TryGetValue(3, out val));
				Assert.AreEqual(val, "4");
			}

		}

		[TestFixture]
		public class Values
		{

			[Test]
			public void Simple()
			{
				var skipList = new SkipList<int, string>();

				for (var i = 0; i < 100; i++)
				{
					skipList.Add(i, i.ToString());
				}

				var list = new List<string>();
				list.AddRange(skipList.Values);

				Assert.AreEqual(list.Count, 100);

				for (var i = 0; i < 100; i++)
				{
					Assert.IsTrue(list.Contains(i.ToString()));
				}
			}

		}
    }
}
