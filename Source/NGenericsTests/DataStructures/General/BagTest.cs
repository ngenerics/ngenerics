/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using System.Collections.Generic;
using NGenerics.Patterns.Visitor;
using NGenerics.Tests.Util;
using NUnit.Framework;
using NGenerics.DataStructures.General;
using System.Collections;

namespace NGenerics.Tests.DataStructures.General
{
    [TestFixture]
    public class BagTest
    {
               
        [TestFixture]
        public class Construction
        {

            [Test]
            public void Simple()
            {
                var bag = new Bag<string>();

                Assert.AreEqual(bag.Count, 0);
                Assert.IsTrue(bag.IsEmpty);

                bag = new Bag<string>(EqualityComparer<string>.Default);

                Assert.AreEqual(bag.Count, 0);
                Assert.IsTrue(bag.IsEmpty);

                bag = new Bag<string>(50);

                Assert.AreEqual(bag.Count, 0);
                Assert.IsTrue(bag.IsEmpty);

                bag = new Bag<string>(50);

                Assert.AreEqual(bag.Count, 0);
                Assert.IsTrue(bag.IsEmpty);

                bag = new Bag<string>(50, EqualityComparer<string>.Default);

                Assert.AreEqual(bag.Count, 0);
                Assert.IsTrue(bag.IsEmpty);
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullComparer1()
            {
                new Bag<string>(null);
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullComparer2()
            {
                new Bag<string>(5, null);
            }

        }
        
        [TestFixture]
        public class Accept
        {

            [Test]
            public void Simple()
            {
                var bag = new Bag<string> {"5", "4", "3", "2"};

                var visitor = new TrackingVisitor<string>();
                bag.AcceptVisitor<string>(visitor);

                Assert.AreEqual(visitor.TrackingList.Count, 4);
                Assert.IsTrue(visitor.TrackingList.Contains("5"));
                Assert.IsTrue(visitor.TrackingList.Contains("4"));
                Assert.IsTrue(visitor.TrackingList.Contains("3"));
                Assert.IsTrue(visitor.TrackingList.Contains("2"));
            }

            [Test]
            public void CompletedVisitor1()
            {
                var bag = new Bag<string> {"5", "4", "3", "2"};

                var visitor = new CompletedTrackingVisitor<KeyValuePair<string, int>>();
                bag.AcceptVisitor<KeyValuePair<string, int>>(visitor);
            }

            [Test]
            public void CompletedVisitor2()
            {
                var bag = new Bag<string> {"5", "4", "3", "2"};

                var visitor = new CompletedTrackingVisitor<string>();
                bag.AcceptVisitor<string>(visitor);
            }

            [Test]
            public void Simple2()
            {
                var bag = new Bag<string> {"5", "4", "3", "2"};

                var visitor = new TrackingVisitor<KeyValuePair<string, int>>();
                bag.AcceptVisitor<KeyValuePair<string, int>>(visitor);

                Assert.AreEqual(visitor.TrackingList.Count, 4);
                Assert.IsTrue(visitor.TrackingList.Contains(new KeyValuePair<string, int>("5", 1)));
                Assert.IsTrue(visitor.TrackingList.Contains(new KeyValuePair<string, int>("4", 1)));
                Assert.IsTrue(visitor.TrackingList.Contains(new KeyValuePair<string, int>("3", 1)));
                Assert.IsTrue(visitor.TrackingList.Contains(new KeyValuePair<string, int>("2", 1)));
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionNullVisitor1()
            {
                var bag = new Bag<string>();
                bag.AcceptVisitor<string>(null);
            }

          

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
			public void ExceptionInvalid1()
            {
                var bag = new Bag<string>();
                bag.AcceptVisitor<string>(null);
            }

      

        }

        [TestFixture]
        public class Add
        {

            [Test]
			public void Simple()
            {
                var bag = new Bag<string>();

                bag.Add("aa");
                Assert.AreEqual(bag.Count, 1);
                Assert.IsTrue(bag.Contains("aa"));
                Assert.AreEqual(bag["aa"], 1);

                bag.Add("bb");
                Assert.AreEqual(bag.Count, 2);
                Assert.IsTrue(bag.Contains("bb"));
                Assert.AreEqual(bag["bb"], 1);

                bag.Add("aa");
                Assert.AreEqual(bag.Count, 3);
                Assert.IsTrue(bag.Contains("aa"));
                Assert.AreEqual(bag["aa"], 2);

                bag.Add("cc", 3);
                Assert.AreEqual(bag.Count, 6);
                Assert.IsTrue(bag.Contains("cc"));
                Assert.AreEqual(bag["cc"], 3);

                bag.Add("cc", 2);

                Assert.AreEqual(bag.Count, 8);
                Assert.IsTrue(bag.Contains("cc"));
                Assert.AreEqual(bag["cc"], 5);
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ExceptionZeroAmount()
            {
                var bag = new Bag<string>();
                bag.Add("aa", 0);
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ExceptionNegativeAmount()
            {
                var bag = new Bag<string>();
                bag.Add("aa", -1);
            }

        }

        [TestFixture]
        public class Clear
        {

            [Test]
			public void Simple()
            {
                var bag = GetTestBag();

                bag.Clear();
                Assert.AreEqual(bag.Count, 0);
                Assert.IsTrue(bag.IsEmpty);

                bag.Add("aa");
                bag.Clear();

                Assert.AreEqual(bag.Count, 0);
                Assert.IsTrue(bag.IsEmpty);
            }
        }
                        
        [TestFixture]
        public class Contains
        {

            [Test]
			public void Simple()
            {
                var bag = new Bag<string> {"aa"};

                Assert.IsTrue(bag.Contains("aa"));
                Assert.AreEqual(bag["aa"], 1);

                bag.Add("bb");
                Assert.IsTrue(bag.Contains("bb"));
                Assert.AreEqual(bag["aa"], 1);
                Assert.AreEqual(bag["bb"], 1);

                bag.Add("aa");
                Assert.IsTrue(bag.Contains("aa"));
                Assert.AreEqual(bag["aa"], 2);
                Assert.AreEqual(bag["bb"], 1);

                bag.Add("cc", 3);
                Assert.IsTrue(bag.Contains("cc"));
                Assert.AreEqual(bag["aa"], 2);
                Assert.AreEqual(bag["bb"], 1);
                Assert.AreEqual(bag["cc"], 3);
            }
        }

        [TestFixture]
        public class CopyTo
        {

            [Test]
			public void Simple()
            {
                var bag = new Bag<int> {3, 4, 5, 6};

                var array = new int[50];

                bag.CopyTo(array, 0);

                Assert.AreNotEqual(array[0], 0);
                Assert.AreNotEqual(array[1], 0);
                Assert.AreNotEqual(array[2], 0);
                Assert.AreNotEqual(array[3], 0);
                Assert.AreEqual(array[4], 0);

                var list = new List<int> { array[0], array[1], array[2], array[3] };

                Assert.IsTrue(list.Contains(3));
                Assert.IsTrue(list.Contains(4));
                Assert.IsTrue(list.Contains(5));
                Assert.IsTrue(list.Contains(6));
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
			public void ExceptionInvalid1()
            {
                var bag = new Bag<int> {3, 4, 5, 6};

                var array = new int[3];

                bag.CopyTo(array, 0);
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
			public void ExceptionInvalid2()
            {
                var bag = new Bag<int> {3, 4, 5, 6};

                var array = new int[4];

                bag.CopyTo(array, 1);
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionInvalid3()
            {
                var bag = new Bag<int> {3, 4, 5, 6};

                bag.CopyTo(null, 1);
            }
        }
               
        [TestFixture]
        public class Count
        {

            [Test]
			public void Simple()
            {
                var bag = GetTestBag();
                Assert.AreEqual(bag.Count, 35);
                Assert.IsFalse(bag.IsEmpty);

                bag = new Bag<string>();
                Assert.AreEqual(bag.Count, 0);
                Assert.IsTrue(bag.IsEmpty);

                bag.Add("aa");
                Assert.AreEqual(bag.Count, 1);
                Assert.IsFalse(bag.IsEmpty);

                bag.Add("aa");
                Assert.AreEqual(bag.Count, 2);
                Assert.IsFalse(bag.IsEmpty);

                bag.Add("bb");
                Assert.AreEqual(bag.Count, 3);
                Assert.IsFalse(bag.IsEmpty);
            }
        }
              
        [TestFixture]
        public class Subtract
        {

            [Test]
			public void Simple()
            {
                var bag1 = new Bag<int> {3, 4, 5, 6};

                var bag2 = new Bag<int> {3, 4, 5};

                var shouldBe = new Bag<int> {6};

                var resultBag = bag1 - bag2;

                Assert.IsTrue(resultBag.Equals(shouldBe));

                bag1.Clear();
                bag2.Clear();

                bag1.Add(3, 3);
                bag2.Add(3, 2);

                bag1.Add(5, 5);
                bag2.Add(5, 7);

                shouldBe.Clear();
                shouldBe.Add(3, 1);

                resultBag = bag1 - bag2;

                Assert.IsTrue(resultBag.Equals(shouldBe));
            }

            [Test]
            public void Interface()
            {
                var bag1 = new Bag<int> {3, 4, 5, 6};

                var bag2 = new Bag<int> {3, 4, 5};

                var shouldBe = new Bag<int> {6};

                var resultBag = (Bag<int>) ((IBag<int>) bag1).Subtract(bag2);

                Assert.IsTrue(resultBag.Equals(shouldBe));

                bag1.Clear();
                bag2.Clear();

                bag1.Add(3, 3);
                bag2.Add(3, 2);

                bag1.Add(5, 5);
                bag2.Add(5, 7);

                shouldBe.Clear();
                shouldBe.Add(3, 1);

                resultBag = bag1.Subtract(bag2);

                Assert.IsTrue(resultBag.Equals(shouldBe));
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullBag()
            {
                var bag = new Bag<int>();
                bag.Subtract(null);
            }

        }
        
        [TestFixture]
        public class GetCountEnumerator
        {

            [Test]
			public void Simple()
            {
                var bag = GetTestBag();

                var enumerator = bag.GetCountEnumerator();

                var counter = 0;

                while (enumerator.MoveNext())
                {
                    if (Int32.Parse(enumerator.Current.Key) < 5)
                    {
                        Assert.AreEqual(enumerator.Current.Value, 3);
                    }
                    else if (Int32.Parse(enumerator.Current.Key) < 10)
                    {
                        Assert.AreEqual(enumerator.Current.Value, 2);
                    }
                    else if (Int32.Parse(enumerator.Current.Key) < 20)
                    {
                        Assert.AreEqual(enumerator.Current.Value, 1);
                    }

                    counter++;
                }

                Assert.AreEqual(counter, 20);
            }

        }
              
        [TestFixture]
        public class GetEnumerator
        {

            [Test]
			public void Simple()
            {
                var bag = GetTestBag();
                var enumerator = bag.GetEnumerator();

                var counter = 0;

                while (enumerator.MoveNext())
                {
                    counter++;

                }

                Assert.AreEqual(counter, 20);
            }

            [Test]
            public void GenericInterface()
            {
                IEnumerable<string> bag = GetTestBag();
                var enumerator = bag.GetEnumerator();

                var counter = 0;

                while (enumerator.MoveNext())
                {
                    counter++;

                }

                Assert.AreEqual(counter, 20);
            }

            [Test]
            public void Interface()
            {
                IEnumerable bag = GetTestBag();
                var enumerator = bag.GetEnumerator();

                var counter = 0;

                while (enumerator.MoveNext())
                {
                    counter++;
                }

                Assert.AreEqual(counter, 20);
            }

        }
              
        [TestFixture]
        public class GetHashCodeObject
        {

            [Test]
			public void Simple()
            {
                var dictionary = new Dictionary<Bag<string>, string>();

                for (var i = 0; i < dictionary.Count; i++)
                {
                    var bag = GetTestBag();

                    bag.GetHashCode();

                    Assert.IsFalse(dictionary.ContainsKey(bag));

                    dictionary.Add(bag, null);
                }
            }

        }
               
        [TestFixture]
        public class Intersection
        {

            [Test]
			public void Simple()
            {
                var bag1 = new Bag<string>();
                var bag2 = GetTestBag();

                var resultBag = bag1 * bag2;

                Assert.IsTrue(resultBag.Equals(bag1));

                bag1.Add("50", 2);

                var shouldBe = new Bag<string>();

                resultBag = bag1 * bag2;

                Assert.IsTrue(shouldBe.Equals(resultBag));

                bag1.Add("2", 2);

                shouldBe.Add("2", 2);

                resultBag = bag1 * bag2;

                Assert.IsTrue(shouldBe.Equals(resultBag));
            }

            [Test]
            public void Interface()
            {
                var bag1 = new Bag<string>();
                var bag2 = GetTestBag();

                var resultBag = (Bag<string>) ((IBag<string>) bag1).Intersection(bag2);

                Assert.IsTrue(resultBag.Equals(bag1));

                bag1.Add("50", 2);

                var shouldBe = new Bag<string>();

                resultBag = (Bag<string>) ((IBag<string>) bag1).Intersection(bag2);

                Assert.IsTrue(shouldBe.Equals(resultBag));

                bag1.Add("2", 2);

                shouldBe.Add("2", 2);

                resultBag = (Bag<string>) ((IBag<string>) bag1).Intersection(bag2);

                Assert.IsTrue(shouldBe.Equals(resultBag));
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullb2()
            {
                var bag1 = new Bag<int>();
                var resultBag = bag1 * null;
            }

        }
               
        [TestFixture]
        public class IsEqual
        {

            [Test]
            public void Null()
            {
                var bag1 = new Bag<int>();
                bag1.Equals(null);
            }

            [Test]
			public void Simple()
            {
                var bag1 = new Bag<int>();
                var bag2 = new Bag<int>();

                Assert.IsFalse(bag1.Equals(null));

                Assert.IsTrue(bag1.Equals(bag2));
                Assert.IsTrue(bag2.Equals(bag1));

                bag2.Add(5);

                Assert.IsFalse(bag1.Equals(bag2));
                Assert.IsFalse(bag2.Equals(bag1));

                bag1.Add(5);

                Assert.IsTrue(bag1.Equals(bag2));
                Assert.IsTrue(bag2.Equals(bag1));

                // Add 6 now so that the count is the same
                bag1.Add(5);
                bag2.Add(6);
                Assert.IsFalse(bag1.Equals(bag2));
                Assert.IsFalse(bag2.Equals(bag1));

                bag1.Remove(5, 1);
                bag2.Remove(6);

                Assert.IsTrue(bag1.Equals(bag2));
                Assert.IsTrue(bag2.Equals(bag1));

                bag2.Add(6);

                Assert.IsFalse(bag1.Equals(bag2));
                Assert.IsFalse(bag2.Equals(bag1));

                bag1.Add(7);

                Assert.IsFalse(bag1.Equals(bag2));
                Assert.IsFalse(bag2.Equals(bag1));
            }

        }
          

        [TestFixture]
        public class IsReadOnly
        {
            [Test]
			public void Simple()
            {
                var bag = GetTestBag();
                Assert.IsFalse(bag.IsReadOnly);
            }

        }

        [TestFixture]
        public class Remove
        {

            [Test]
			public void Simple()
            {
                var bag = new Bag<string> {"aa", "bb", "aa", {"cc", 3}};

                Assert.AreEqual(bag.Count, 6);

                Assert.IsTrue(bag.Remove("aa"));
                Assert.IsTrue(bag.Contains("aa"));
                Assert.AreEqual(bag["aa"], 1);
                Assert.AreEqual(bag.Count, 5);

                Assert.IsTrue(bag.Remove("aa"));
                Assert.IsFalse(bag.Contains("aa"));
                Assert.AreEqual(bag["aa"], 0);
                Assert.AreEqual(bag.Count, 4);

                Assert.IsFalse(bag.Remove("dd"));
                Assert.AreEqual(bag.Count, 4);

                Assert.IsTrue(bag.Remove("bb"));
                Assert.IsFalse(bag.Contains("bb"));
                Assert.AreEqual(bag["bb"], 0);
                Assert.AreEqual(bag.Count, 3);

                Assert.IsTrue(bag.Remove("cc"));
                Assert.IsTrue(bag.Contains("cc"));
                Assert.AreEqual(bag["cc"], 2);
                Assert.AreEqual(bag.Count, 2);
            }

            [Test]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void ExceptionMaximumBelowZero()
            {
                var bag = new Bag<string> {"aa", "bb", "aa", {"cc", 3}};

                bag.Remove("aa", -1);
            }

            [Test]
            public void Max()
            {
                var bag = new Bag<string> {"aa", "bb", "aa", {"cc", 3}};

                Assert.AreEqual(bag.Count, 6);

                Assert.IsTrue(bag.Remove("aa", 1));
                Assert.IsTrue(bag.Contains("aa"));
                Assert.AreEqual(bag["aa"], 1);
                Assert.AreEqual(bag.Count, 5);

                Assert.IsTrue(bag.Remove("aa", 2));
                Assert.IsFalse(bag.Contains("aa"));
                Assert.AreEqual(bag["aa"], 0);
                Assert.AreEqual(bag.Count, 4);

                Assert.IsTrue(bag.Remove("cc", 2));
                Assert.IsTrue(bag.Contains("cc"));
                Assert.AreEqual(bag["cc"], 1);
                Assert.AreEqual(bag.Count, 2);

                Assert.IsFalse(bag.Remove("dd", 2));
            }

        }

        [TestFixture]
        public class RemoveAll
        {

            [Test]
			public void Simple()
            {
                var bag = new Bag<string> {"aa", "bb", "aa", {"cc", 3}};

                Assert.AreEqual(bag.Count, 6);

                Assert.IsTrue(bag.RemoveAll("aa"));
                Assert.IsFalse(bag.Contains("aa"));
                Assert.AreEqual(bag["aa"], 0);
                Assert.AreEqual(bag.Count, 4);

                Assert.IsFalse(bag.RemoveAll("dd"));
                Assert.AreEqual(bag.Count, 4);


                Assert.IsTrue(bag.RemoveAll("cc"));
                Assert.IsFalse(bag.Contains("cc"));
                Assert.AreEqual(bag["cc"], 0);
                Assert.AreEqual(bag.Count, 1);
            }
        }
              
        [TestFixture]
        public class Serializable
        {

            [Test]
			public void Simple()
            {
                var bag1 = new Bag<int>();
                var bag2 = SerializeUtil.BinarySerializeDeserialize(bag1);

                Assert.AreNotSame(bag1, bag2);
                Assert.IsTrue(bag1.Equals(bag2));
            }

        }
               
        [TestFixture]
        public class Union
        {
            [Test]
            public void Simple()
            {
                var bag1 = new Bag<int>();
                var bag2 = new Bag<int>();

                bag1.Add(2, 2);
                bag1.Add(3, 3);
                bag1.Add(4, 5);

                bag2.Add(3, 2);
                bag2.Add(4, 3);
                bag2.Add(5, 2);
                bag2.Add(6, 2);

                var shouldBe = new Bag<int> {{2, 2}, {3, 5}, {4, 8}, {5, 2}, {6, 2}};

                var resultBag = bag1 + bag2;

                Assert.IsTrue(shouldBe.Equals(resultBag));

                resultBag = bag2 + bag1;

                Assert.IsTrue(shouldBe.Equals(resultBag));
            }

            [Test]
            public void Interface()
            {
                var bag1 = new Bag<int>();
                var bag2 = new Bag<int>();

                bag1.Add(2, 2);
                bag1.Add(3, 3);
                bag1.Add(4, 5);

                bag2.Add(3, 2);
                bag2.Add(4, 3);
                bag2.Add(5, 2);

                var shouldBe = new Bag<int> {{2, 2}, {3, 5}, {4, 8}, {5, 2}};

                var resultBag = (Bag<int>) ((IBag<int>) bag1).Union(bag2);

                Assert.IsTrue(shouldBe.Equals(resultBag));

                resultBag = (Bag<int>)((IBag<int>)bag2).Union(bag1);

                Assert.IsTrue(shouldBe.Equals(resultBag));
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullb2()
            {
                var bag1 = new Bag<int>();
                var resultBag = bag1 + null;
            }

        }
      

        #region Private Members

        private static Bag<string> GetTestBag()
        {
            var bag = new Bag<string>();

            for (var i = 0; i < 20; i++)
            {
                bag.Add(i.ToString());
            }

            for (var i = 0; i < 10; i++)
            {
                bag.Add(i.ToString());
            }

            for (var i = 0; i < 5; i++)
            {
                bag.Add(i.ToString());
            }

            return bag;
        }

        #endregion
    }
}
