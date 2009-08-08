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
using NGenerics.DataStructures.General;
using NGenerics.Patterns.Visitor;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General
{
	[TestFixture]
	public class SetTest
	{

		[TestFixture]
		public class Accepct
		{

			[Test]
			public void Simple()
			{
				var pascalSet = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });

				var trackingVisitor = new TrackingVisitor<int>();

				pascalSet.AcceptVisitor(trackingVisitor);

				Assert.AreEqual(trackingVisitor.TrackingList.Count, 5);
				Assert.IsTrue(trackingVisitor.TrackingList.Contains(15));
				Assert.IsTrue(trackingVisitor.TrackingList.Contains(20));
				Assert.IsTrue(trackingVisitor.TrackingList.Contains(30));
				Assert.IsTrue(trackingVisitor.TrackingList.Contains(40));
				Assert.IsTrue(trackingVisitor.TrackingList.Contains(34));
			}

			[Test]
			public void CompletedVisitor()
			{
                var pascalSet = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });

				var completedTrackingVisitor = new CompletedTrackingVisitor<int>();

				pascalSet.AcceptVisitor(completedTrackingVisitor);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullVisitor()
			{
                var pascalSet = new PascalSet(10);
                pascalSet.AcceptVisitor(null);
			}

		}

		[TestFixture]
		public class Capacity
		{

			[Test]
			public void Simple()
			{
                var pascalSet = new PascalSet(100);
				Assert.AreEqual(pascalSet.Capacity, 101);

				pascalSet = new PascalSet(1, 100);
				Assert.AreEqual(pascalSet.Capacity, 100);

				pascalSet = new PascalSet(55, 100);
				Assert.AreEqual(pascalSet.Capacity, 46);
			}
		
		}

		[TestFixture]
		public class Construction
		{
			[Test]
			public void UpperBound()
			{
                var pascalSet = new PascalSet(50);
				Assert.AreEqual(pascalSet.LowerBound, 0);
				Assert.AreEqual(pascalSet.UpperBound, 50);
				Assert.AreEqual(pascalSet.Count, 0);

				for (var i = 0; i <= 50; i++)
				{
					Assert.IsFalse(pascalSet[i]);
				}
			}

			[Test]
			public void LowerBoundUpperBound()
			{
                var pascalSet = new PascalSet(10, 50);

				Assert.AreEqual(pascalSet.LowerBound, 10);
				Assert.AreEqual(pascalSet.UpperBound, 50);
				Assert.AreEqual(pascalSet.Count, 0);

				for (var i = 10; i <= 50; i++)
				{
					Assert.IsFalse(pascalSet[i]);
				}
			}

            [Test]
            public void UpperBoundInitial()
            {
                var values = new[] { 20, 30, 40 };

                var pascalSet = new PascalSet(50, values);

                Assert.AreEqual(pascalSet.LowerBound, 0);
                Assert.AreEqual(pascalSet.UpperBound, 50);
                Assert.AreEqual(pascalSet.Count, 3);

                for (var i = 0; i <= 50; i++)
                {
                    if ((i == 20) || (i == 30) || (i == 40))
                    {
                        Assert.IsTrue(pascalSet[i]);
                    }
                    else
                    {
                        Assert.IsFalse(pascalSet[i]);
                    }
                }
            }

            [Test]
            public void LowerBoundUpperBoundInitialValues()
            {
                var values = new[] { 20, 30, 40 };

                var pascalSet = new PascalSet(10, 50, values);

                Assert.AreEqual(pascalSet.LowerBound, 10);
                Assert.AreEqual(pascalSet.UpperBound, 50);
                Assert.AreEqual(pascalSet.Count, 3);

                for (var i = 10; i <= 50; i++)
                {
                    if ((i == 20) || (i == 30) || (i == 40))
                    {
                        Assert.IsTrue(pascalSet[i]);
                    }
                    else
                    {
                        Assert.IsFalse(pascalSet[i]);
                    }
                }
            }

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionInvalidLowerBounds1()
			{
				new PascalSet(-1, 10);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionInvalidLowerBounds2()
			{
				new PascalSet(-1, 10, new[] { 3, 4 });
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionUpperBoundSmallerThanLowerBound1()
			{
				new PascalSet(12, 10);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionUpperBoundSmallerThanLowerBound2()
			{
				new PascalSet(12, 10, new[] { 3, 4 });
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullValues()
			{
				new PascalSet(5, 10, null);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExcetpionUpperBoundNull()
			{
				new PascalSet(10, null);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionInvalidInitialValues1()
			{
				new PascalSet(10, 20, new[] { 3, 4, 15, 16 });
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionInvalidInitialValues2()
			{
				new PascalSet(10, 20, new[] { 22, 12, 15, 16 });
			}

		}

		[TestFixture]
		public class Clear
		{

			[Test]
			public void Simple()
			{
				var values = new[] { 20, 30, 40 };
                var pascalSet = new PascalSet(0, 50, values);

				Assert.AreEqual(pascalSet.Count, 3);

				pascalSet.Clear();

				for (var i = 0; i <= 50; i++)
				{
					Assert.IsFalse(pascalSet[i]);
				}

				Assert.AreEqual(pascalSet.Count, 0);
			}

		}

		[TestFixture]
		public class CopyTo
		{

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExcepionNullArray()
			{
                var pascalSet = new PascalSet(20);
				pascalSet.CopyTo(null, 0);
			}

			[Test]
			public void Simple()
			{
                var pascalSet = new PascalSet(10, new[] { 1, 2, 5, 6 });

				var array = new int[4];
				pascalSet.CopyTo(array, 0);

				var list = new List<int>(array);

				Assert.IsTrue(list.Contains(1));
				Assert.IsTrue(list.Contains(2));
				Assert.IsTrue(list.Contains(5));
				Assert.IsTrue(list.Contains(6));
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionInvalid1()
			{
                var pascalSet = new PascalSet(10, new[] { 1, 2, 5, 6 });

				var array = new int[3];
				pascalSet.CopyTo(array, 0);
			}

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionInvalid2()
			{
                var pascalSet = new PascalSet(10, new[] { 1, 2, 5, 6 });

				var array = new int[4];
				pascalSet.CopyTo(array, 1);
			}

		}

		[TestFixture]
		public class Contains
		{

			[Test]
			public void Simple()
			{
                var pascalSet = new PascalSet(0, 50, new[] { 20, 30, 40 });

				Assert.IsTrue(pascalSet.Contains(20));
				Assert.IsTrue(pascalSet.Contains(30));
				Assert.IsTrue(pascalSet.Contains(40));

				Assert.IsFalse(pascalSet.Contains(25));
				Assert.IsFalse(pascalSet.Contains(35));
				Assert.IsFalse(pascalSet.Contains(45));
			}

		}

		[TestFixture]
		public class EqualsObj
		{

			[Test]
			public void Null()
			{
                var pascalSet = new PascalSet(20);
				Assert.IsFalse(pascalSet.Equals(null));
			}

			[Test]
			public void Simple()
			{
                var pascalSet1 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });
                var pascalSet2 = new PascalSet(0, 50, new[] { 20, 25, 30, 35, 40 });
                var pascalSet3 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });
                var pascalSet4 = new PascalSet(10, 50, new[] { 15, 20, 30, 40, 34 });

				Assert.IsTrue(pascalSet1.Equals(pascalSet3));
				Assert.IsFalse(pascalSet1.Equals(pascalSet2));
				Assert.IsFalse(pascalSet1.Equals(pascalSet4));
			}

		}

		[TestFixture]
		public class GetEnumerator
		{

			[Test]
			public void Simple()
			{
                var pascalSet = new PascalSet(0, 50, new[] { 20, 25, 30, 35, 40 });

				var enumerator = pascalSet.GetEnumerator();

				Assert.IsTrue(enumerator.MoveNext());
				Assert.AreEqual(enumerator.Current, 20);

				Assert.IsTrue(enumerator.MoveNext());
				Assert.AreEqual(enumerator.Current, 25);

				Assert.IsTrue(enumerator.MoveNext());
				Assert.AreEqual(enumerator.Current, 30);

				Assert.IsTrue(enumerator.MoveNext());
				Assert.AreEqual(enumerator.Current, 35);

				Assert.IsTrue(enumerator.MoveNext());
				Assert.AreEqual(enumerator.Current, 40);

				Assert.IsFalse(enumerator.MoveNext());
			}

			[Test]
			public void Interface()
			{
                var pascalSet = new PascalSet(0, 50, new[] { 20, 25, 30, 35, 40 });

				var enumerator = ((IEnumerable)pascalSet).GetEnumerator();

				Assert.IsTrue(enumerator.MoveNext());
				Assert.AreEqual((int)enumerator.Current, 20);

				Assert.IsTrue(enumerator.MoveNext());
				Assert.AreEqual((int)enumerator.Current, 25);

				Assert.IsTrue(enumerator.MoveNext());
				Assert.AreEqual((int)enumerator.Current, 30);

				Assert.IsTrue(enumerator.MoveNext());
				Assert.AreEqual((int)enumerator.Current, 35);

				Assert.IsTrue(enumerator.MoveNext());
				Assert.AreEqual((int)enumerator.Current, 40);

				Assert.IsFalse(enumerator.MoveNext());
			}

		}
	
		[TestFixture]
		public class IsEmpty
		{

			[Test]
			public void Simple()
			{
                var pascalSet = new PascalSet(0, 500);
				Assert.IsTrue(pascalSet.IsEmpty);

				pascalSet.Add(50);
				Assert.IsFalse(pascalSet.IsEmpty);

				pascalSet.Add(100);
				Assert.IsFalse(pascalSet.IsEmpty);

				pascalSet.Clear();
				Assert.IsTrue(pascalSet.IsEmpty);
			}
		
		}
		
		[TestFixture]
		public class IsFull
		{

			[Test]
			public void Simple()
			{
                var pascalSet = new PascalSet(0, 100);
				Assert.IsFalse(pascalSet.IsFull);

				for (var i = 0; i <= 100; i++)
				{
					pascalSet.Add(i);

					if (i < 100)
					{
						Assert.IsFalse(pascalSet.IsFull);
					}
					else
					{
						Assert.IsTrue(pascalSet.IsFull);
					}
				}

				pascalSet.Clear();

				Assert.IsFalse(pascalSet.IsFull);
			}
	
		}

		[TestFixture]
		public class Intersection
		{
	
			[Test]
			public void Simple()
			{
				var s1 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });
				var s2 = new PascalSet(0, 50, new[] { 20, 25, 30, 35, 40 });

				var intersection = s1.Intersection(s2);

				for (var i = 0; i <= 50; i++)
				{
					if ((i == 20) || (i == 30) || (i == 40))
					{
						Assert.IsTrue(intersection[i]);
					}
					else
					{
						Assert.IsFalse(intersection[i]);
					}
				}

				var intersection2 = s1 * s2;
				Assert.IsTrue(intersection.Equals(intersection2));
			}

			[Test]
			public void Interface()
			{
				var s1 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });
				var s2 = new PascalSet(0, 50, new[] { 20, 25, 30, 35, 40 });

				var intersection = (PascalSet)((ISet)s1).Intersection(s2);

				for (var i = 0; i <= 50; i++)
				{
					if ((i == 20) || (i == 30) || (i == 40))
					{
						Assert.IsTrue(intersection[i]);
					}
					else
					{
						Assert.IsFalse(intersection[i]);
					}
				}
			}
			
			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionInvalidIntersectionOperator1()
			{
                var pascalSet = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });
				var a = pascalSet * null;
			}
			
			
			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullSet()
			{
                var pascalSet = new PascalSet(500);
				pascalSet.Intersection(null);
			}
		
			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExcetionNullOperator()
			{
                var pascalSet = new PascalSet(500);
				var newSet = null * pascalSet;
			}
		
		}

		[TestFixture]
		public class IsProperSubsetOf
		{

			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionInvalidProperSubsetOf()
			{
				var s1 = new PascalSet(0, 50, new[] { 15, 20, 30 });
				var s2 = new PascalSet(10, 60, new[] { 15, 20, 60 });

				s1.IsProperSubsetOf(s2);
			}
			
			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExcetpionNullS1()
			{
                var pascalSet = new PascalSet(0, 50, new[] { 15, 20, 30 });
				var b = null < pascalSet;
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullS2()
			{
                var pascalSet = new PascalSet(0, 50, new[] { 15, 20, 30 });
				var b = pascalSet < null;
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullSet()
			{
                var pascalSet = new PascalSet(500);
				pascalSet.IsProperSubsetOf(null);
			}
		
			[Test]
			public void Simple()
			{
				var s1 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });
				var s2 = new PascalSet(0, 50, new[] { 15, 20, 30 });
				var s3 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });

				Assert.IsFalse(s1.IsProperSubsetOf(s2));
				Assert.IsTrue(s2.IsProperSubsetOf(s1));
				Assert.IsFalse(s3.IsProperSubsetOf(s1));
				Assert.IsFalse(s1.IsProperSubsetOf(s3));

				Assert.IsFalse(s1 < s2);
				Assert.IsTrue(s2 < s1);
				Assert.IsFalse(s3 < s1);
				Assert.IsFalse(s1 < s3);
			}

			[Test]
			public void Interface()
			{
				var s1 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });
				var s2 = new PascalSet(0, 50, new[] { 15, 20, 30 });
				var s3 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });

				Assert.IsFalse(((ISet)s1).IsProperSubsetOf(s2));
				Assert.IsTrue(((ISet)s2).IsProperSubsetOf(s1));
				Assert.IsFalse(((ISet)s3).IsProperSubsetOf(s1));
				Assert.IsFalse(((ISet)s1).IsProperSubsetOf(s3));
			}
			
			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullS1()
			{
                var pascalSet = new PascalSet(500);
				var p = null < pascalSet;
			}
		
		}

		[TestFixture]
		public class IsSubsetOf
		{

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void NullSet()
			{
                var pascalSet = new PascalSet(500);
				pascalSet.IsSubsetOf(null);
			}
		
			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void NullS1()
			{
                var pascalSet = new PascalSet(0, 50, new[] { 15, 20, 30 });
				var b = null <= pascalSet;
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void NullS2()
			{
                var pascalSet = new PascalSet(0, 50, new[] { 15, 20, 30 });
				var b = pascalSet <= null;
			}
			
			[Test]
			public void Interface()
			{
				var s1 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });
				var s2 = new PascalSet(0, 50, new[] { 15, 20, 30 });
				var s3 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });

				Assert.IsFalse(((ISet)s1).IsSubsetOf(s2));
				Assert.IsTrue(((ISet)s2).IsSubsetOf(s1));
				Assert.IsTrue(((ISet)s3).IsSubsetOf(s1));
				Assert.IsTrue(((ISet)s1).IsSubsetOf(s3));
			}

			[Test]
			public void Simple()
			{
				var s1 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });
				var s2 = new PascalSet(0, 50, new[] { 15, 20, 30 });
				var s3 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });

				Assert.IsFalse(s1.IsSubsetOf(s2));
				Assert.IsTrue(s2.IsSubsetOf(s1));
				Assert.IsTrue(s3.IsSubsetOf(s1));
				Assert.IsTrue(s1.IsSubsetOf(s3));

				Assert.IsFalse(s1 <= s2);
				Assert.IsTrue(s2 <= s1);
				Assert.IsTrue(s3 <= s1);
				Assert.IsTrue(s1 <= s3);
			}

		}

	

		[TestFixture]
		public class IsProperSupersetOf
		{
			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullSet()
			{
                var pascalSet = new PascalSet(500);
				pascalSet.IsProperSupersetOf(null);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullS1()
			{
                var pascalSet = new PascalSet(500);
				var p = null > pascalSet;
			}
			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionInvalid()
			{
				var s1 = new PascalSet(0, 50, new[] { 15, 20, 30 });
				var s2 = new PascalSet(10, 60, new[] { 15, 20, 60 });

				s1.IsProperSupersetOf(s2);
			}


			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullS2()
			{
                var pascalSet = new PascalSet(0, 50, new[] { 15, 20, 30 });
				var b = pascalSet > null;
			}

			[Test]
			public void Interface()
			{
				var s1 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });
				var s2 = new PascalSet(0, 50, new[] { 15, 20, 30 });
				var s3 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });

				Assert.IsTrue(((ISet)s1).IsProperSupersetOf(s2));
				Assert.IsFalse(((ISet)s2).IsProperSupersetOf(s1));
				Assert.IsFalse(((ISet)s3).IsProperSupersetOf(s1));
				Assert.IsFalse(((ISet)s1).IsProperSupersetOf(s3));
			}

			[Test]
			public void Simple()
			{
				var s1 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });
				var s2 = new PascalSet(0, 50, new[] { 15, 20, 30 });
				var s3 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });

				Assert.IsTrue(s1.IsProperSupersetOf(s2));
				Assert.IsFalse(s2.IsProperSupersetOf(s1));
				Assert.IsFalse(s3.IsProperSupersetOf(s1));
				Assert.IsFalse(s1.IsProperSupersetOf(s3));

				Assert.IsTrue(s1 > s2);
				Assert.IsFalse(s2 > s1);
				Assert.IsFalse(s3 > s1);
				Assert.IsFalse(s1 > s3);
			}

		}

		[TestFixture]
		public class IsSuperSetOf
		{

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void NullS1()
			{
                var pascalSet = new PascalSet(0, 50, new[] { 15, 20, 30 });
				var b = null >= pascalSet;
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void NullS2()
			{
                var pascalSet = new PascalSet(0, 50, new[] { 15, 20, 30 });
				var b = pascalSet >= null;
			}
		
			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionUniverseNotSame()
			{
				var s1 = new PascalSet(0, 50, new[] {15, 20, 30});
				var s2 = new PascalSet(10, 60, new[] {15, 20, 60});

				s1.IsSupersetOf(s2);
			}

			[Test]
			public void Interface()
			{
				var s1 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });
				var s2 = new PascalSet(0, 50, new[] { 15, 20, 30 });
				var s3 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });

				Assert.IsTrue(((ISet)s1).IsSupersetOf(s2));
				Assert.IsFalse(((ISet)s2).IsSupersetOf(s1));
				Assert.IsTrue(((ISet)s3).IsSupersetOf(s1));
				Assert.IsTrue(((ISet)s1).IsSupersetOf(s3));
			}

			[Test]
			public void Simple()
			{
				var s1 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });
				var s2 = new PascalSet(0, 50, new[] { 15, 20, 30 });
				var s3 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });

				Assert.IsTrue(s1.IsSupersetOf(s2));
				Assert.IsFalse(s2.IsSupersetOf(s1));
				Assert.IsTrue(s3.IsSupersetOf(s1));
				Assert.IsTrue(s1.IsSupersetOf(s3));

				Assert.IsTrue(s1 >= s2);
				Assert.IsFalse(s2 >= s1);
				Assert.IsTrue(s3 >= s1);
				Assert.IsTrue(s1 >= s3);
			}
			
			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void NullSet()
			{
                var pascalSet = new PascalSet(500);
				pascalSet.IsSupersetOf(null);
			}
		
		}

		[TestFixture]
		public class Invert
		{
	
			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void Null()
			{
				var newSet = !(PascalSet)null;
			}

			[Test]
			public void Interface()
			{
                var pascalSet = new PascalSet(0, 50, new[] { 15, 20, 30 });

				var inverse = (PascalSet)((ISet)pascalSet).Inverse();

				for (var i = 0; i <= 50; i++)
				{
					if ((i == 15) || (i == 20) || (i == 30))
					{
						Assert.IsFalse(inverse[i]);
					}
					else
					{
						Assert.IsTrue(inverse[i]);
					}
				}
			}

			[Test]
			public void Simple()
			{
                var pascalSet = new PascalSet(0, 50, new[] { 15, 20, 30 });

				var inverse = pascalSet.Inverse();

				for (var i = 0; i <= 50; i++)
				{
					if ((i == 15) || (i == 20) || (i == 30))
					{
						Assert.IsFalse(inverse[i]);
					}
					else
					{
						Assert.IsTrue(inverse[i]);
					}
				}

				var inverse2 = !pascalSet;
				Assert.IsTrue(inverse.Equals(inverse2));
			}

		}

		[TestFixture]
		public class IsReadOnly
		{

			[Test]
			public void Simple()
			{
                var pascalSet = new PascalSet(0, 500);
				Assert.IsFalse(pascalSet.IsReadOnly);

				pascalSet.Add(50);
				Assert.IsFalse(pascalSet.IsReadOnly);

				pascalSet.Add(100);
				Assert.IsFalse(pascalSet.IsReadOnly);
			}

		}

		[TestFixture]
		public class Remove
		{

			[Test]
			public void Simple()
			{
				var s1 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });

				Assert.AreEqual(s1.Count, 5);
				Assert.IsTrue(s1.Remove(20));
				Assert.AreEqual(s1.Count, 4);

				Assert.IsFalse(s1.Remove(20));
				Assert.AreEqual(s1.Count, 4);

				Assert.IsTrue(s1.Remove(40));
				Assert.AreEqual(s1.Count, 3);
			}
	
		}

		[TestFixture]
		public class Subtract
		{
		
			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullSet()
			{
                var pascalSet = new PascalSet(500);
				pascalSet.Subtract(null);
			}
		
			[Test]
			public void Simple()
			{
				var s1 = new PascalSet(0, 50, new[] { 20, 30, 40 });
				var s2 = new PascalSet(0, 50, new[] { 20, 25, 30, 35, 40 });

				var difference = s1.Subtract(s2);

				for (var i = 0; i < 50; i++)
				{
					if ((i == 25) || (i == 35))
					{
						Assert.IsTrue(difference[i]);
					}
					else
					{
						Assert.IsFalse(difference[i]);
					}
				}

				var difference2 = s1 - s2;
				Assert.IsTrue(difference.Equals(difference2));
			}

			[Test]
			public void Interface()
			{
				var s1 = new PascalSet(0, 50, new[] { 20, 30, 40 });
				var s2 = new PascalSet(0, 50, new[] { 20, 25, 30, 35, 40 });

				var difference = (PascalSet)((ISet)s1).Subtract(s2);

				for (var i = 0; i < 50; i++)
				{
					if ((i == 25) || (i == 35))
					{
						Assert.IsTrue(difference[i]);
					}
					else
					{
						Assert.IsFalse(difference[i]);
					}
				}
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullSetOperator2()
			{
                var pascalSet = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });
				var a = null - pascalSet;
			}
		
			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullSetOperator1()
			{
                var pascalSet = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });
				var a = pascalSet - null;
			}
	
		}

		[TestFixture]
		public class Union
		{
			
			[Test]
			[ExpectedException(typeof(ArgumentException))]
			public void ExceptionInvalid1()
			{
				var s1 = new PascalSet(0, 50, new[] { 15, 20, 30 });
				var s2 = new PascalSet(10, 60, new[] { 15, 20, 60 });

				s1.Union(s2);
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullOperatorS1()
			{
                var pascalSet = new PascalSet(0, 50, new[] { 15, 20, 30 });

				var union = null + pascalSet;
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void ExceptioNullS2()
			{
                var pascalSet = new PascalSet(0, 50, new[] { 15, 20, 30 });
				var union = pascalSet + null;
			}

			[Test]
			public void Interface()
			{
				var s1 = new PascalSet(0, 50, new[] { 15, 20, 30 });
				var s2 = new PascalSet(0, 50, new[] { 15, 25, 30 });
				var s3 = new PascalSet(0, 50, new[] { 1, 2, 3, 4 });

				var union = (PascalSet)((ISet)s1).Union(s2);

				Assert.AreEqual(union.Count, 4);

				for (var i = 0; i <= 50; i++)
				{
					if ((i == 15) || (i == 20) || (i == 25) || (i == 30))
					{
						Assert.IsTrue(union[i]);
					}
					else
					{
						Assert.IsFalse(union[i]);
					}
				}

				union = (PascalSet)((ISet)s2).Union(s3);

				Assert.AreEqual(union.Count, 7);

				for (var i = 0; i <= 50; i++)
				{
					if ((i == 15) || (i == 25) || (i == 30) || (i == 1) || (i == 2) || (i == 3) || (i == 4))
					{
						Assert.IsTrue(union[i]);
					}
					else
					{
						Assert.IsFalse(union[i]);
					}
				}
			}

			[Test]
			public void Simple()
			{
				var s1 = new PascalSet(0, 50, new[] { 15, 20, 30 });
				var s2 = new PascalSet(0, 50, new[] { 15, 25, 30 });
				var s3 = new PascalSet(0, 50, new[] { 1, 2, 3, 4 });

				var union = s1.Union(s2);

				Assert.AreEqual(union.Count, 4);

				for (var i = 0; i <= 50; i++)
				{
					if ((i == 15) || (i == 20) || (i == 25) || (i == 30))
					{
						Assert.IsTrue(union[i]);
					}
					else
					{
						Assert.IsFalse(union[i]);
					}
				}

				union = s2.Union(s3);

				Assert.AreEqual(union.Count, 7);

				for (var i = 0; i <= 50; i++)
				{
					if ((i == 15) || (i == 25) || (i == 30) || (i == 1) || (i == 2) || (i == 3) || (i == 4))
					{
						Assert.IsTrue(union[i]);
					}
					else
					{
						Assert.IsFalse(union[i]);
					}
				}

				var union2 = s2 + s3;
				Assert.IsTrue(union2.Equals(union));
			}

			[Test]
			[ExpectedException(typeof(ArgumentNullException))]
			public void NullSet()
			{
                var pascalSet = new PascalSet(500);
				pascalSet.Union(null);
			}
	
		}
	}
}