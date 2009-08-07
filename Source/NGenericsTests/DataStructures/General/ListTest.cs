/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/

using System;
using System.Collections;
using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NGenerics.Extensions;
using NGenerics.Patterns.Visitor;
using NGenerics.Tests.Util;
using NUnit.Framework;
using Rhino.Mocks;

namespace NGenerics.Tests.DataStructures.General
{
    public class ListTest
    {
        #region Tests

        [TestFixture]
        public class Construction
        {
            [Test]
            public void Simple()
            {
                var listBase = new ListBase<int>();
				
            }
            [Test]
            public void Capacity()
            {
                var listBase = new ListBase<int>(3);
                Assert.AreEqual(3, listBase.Capacity);
            }
            [Test]
            public void Collection()
            {
                var listBase = new ListBase<int>(new[]{3});
                Assert.IsTrue(listBase.Contains(3));
            }
        }

        [TestFixture]
        public class Add : ListBase<int>
        {
            [Test]
            public void Simple()
            {

                var listBase = new ListBase<int> {3};
                Assert.IsTrue(listBase.Contains(3));
            }
            [Test]
            public void Interface()
            {
                var listBase = (IList)new ListBase<int>(); 
                listBase.Add(3);
                Assert.IsTrue(listBase.Contains(3));
            }
            [Test]
            public void SimpleEnsureInsertItemCall()
            {
                var mockRepository = new MockRepository();
                var listBase = mockRepository.CreateMock<Add>();
                listBase.InsertItem(0, 5);
                mockRepository.ReplayAll();
                listBase.Add(5);
                mockRepository.VerifyAll();
            }

            [Test]
            public void InterfaceEnsureInsertItemCall()
            {
                var mockRepository = new MockRepository();
                var listBase = mockRepository.CreateMock<Add>();
                listBase.InsertItem(0, 5);
                mockRepository.ReplayAll();
                ((IList)listBase).Add(5);
                mockRepository.VerifyAll();
            }
        }
        [TestFixture]
        public class Sort 
        {
            [Test]
            public void Simple()
            {
                var listBase = new ListBase<int> {3,2,6,9,1};
                listBase.Sort();
                Assert.AreEqual(1, listBase[0]);
                Assert.AreEqual(2, listBase[1]);
                Assert.AreEqual(3, listBase[2]);
                Assert.AreEqual(6, listBase[3]);
                Assert.AreEqual(9, listBase[4]);
            }

			//[Test]
			//public void EnsureSortItemsCall()
			//{
			//    var mockRepository = new MockRepository();
			//    Sort listBase = mockRepository.PartialMock<Sort>();
			//    listBase.SortItems();
			//    mockRepository.ReplayAll();
			//    listBase.Add(5);
			//    listBase.Sort();
			//    mockRepository.VerifyAll();
			//}
            [Test]
            public void Comparison()
            {
                var listBase = new ListBase<int> {3,2,6,9,1};
                Comparison<int> comparison = IntComparison;
                listBase.Sort(comparison);
                Assert.AreEqual(1, listBase[0]);
                Assert.AreEqual(2, listBase[1]);
                Assert.AreEqual(3, listBase[2]);
                Assert.AreEqual(6, listBase[3]);
                Assert.AreEqual(9, listBase[4]);
            }
			//[Test]
			//public void EnsureComparisonSortItemsCall()
			//{
			//    Comparison<int> comparison = IntComparison;
			//    var mockRepository = new MockRepository();
			//    Sort listBase = mockRepository.PartialMock<Sort>();
			//    listBase.SortItems(comparison);
			//    mockRepository.ReplayAll();
			//    listBase.Add(5);
			//    listBase.Sort(comparison);
			//    mockRepository.VerifyAll();
			//}
            [Test]
            public void Comparer()
            {
                var listBase = new ListBase<int> {3,2,6,9,1};
                listBase.Sort(Comparer<int>.Default);
                Assert.AreEqual(1, listBase[0]);
                Assert.AreEqual(2, listBase[1]);
                Assert.AreEqual(3, listBase[2]);
                Assert.AreEqual(6, listBase[3]);
                Assert.AreEqual(9, listBase[4]);
            }
			//[Test]
			//public void EnsureComparerSortItemsCall()
			//{
			//    var mockRepository = new MockRepository();
			//    Sort listBase = mockRepository.PartialMock<Sort>();
			//    listBase.SortItems(Comparer<int>.Default);
			//    mockRepository.ReplayAll();
			//    listBase.Add(5);
			//    listBase.Sort(Comparer<int>.Default);
			//    mockRepository.VerifyAll();
			//}
            [Test]
            public void IndexCountComparer()
            {
                var listBase = new ListBase<int> {3,2,6,9,1};
                listBase.Sort(0, 5, Comparer<int>.Default);
                Assert.AreEqual(1, listBase[0]);
                Assert.AreEqual(2, listBase[1]);
                Assert.AreEqual(3, listBase[2]);
                Assert.AreEqual(6, listBase[3]);
                Assert.AreEqual(9, listBase[4]);
            }
			//[Test]
			//public void EnsureIndexCountComparerSortItemsCall()
			//{
			//    var mockRepository = new MockRepository();
			//    Sort listBase = mockRepository.PartialMock<Sort>();
			//    listBase.SortItems(0, 5, Comparer<int>.Default);
			//    mockRepository.ReplayAll();
			//    listBase.Add(5);
			//    listBase.Sort(0, 5, Comparer<int>.Default);
			//    mockRepository.VerifyAll();
			//}

            private static int IntComparison(int x, int y)
            {
                return x.CompareTo(y);
            }
        }
        [TestFixture]
        public class Indexer : ListBase<int>
        {
            [Test]
            public void Simple()
            {

                var listBase = new ListBase<int> {3};
                listBase[0] = 4;
                Assert.IsTrue(listBase.Contains(4));
                Assert.IsFalse(listBase.Contains(3));
            }
            [Test]
            public void Interface()
            {
                var listBase = (IList)new ListBase<int>();
                listBase.Add(3);
                listBase[0] = 4;
                Assert.IsTrue(listBase.Contains(4));
                Assert.IsFalse(listBase.Contains(3));
            }
            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void ExceptionInvalidType()
            {
                var listBase = (IList)new ListBase<int>();
                listBase.Add(3);
                listBase[0] = "a";
            }
            [Test]
            public void SimpleEnsureInsertItemCall()
            {
                var mockRepository = new MockRepository();
                var listBase = mockRepository.PartialMock<Indexer>();
                listBase.SetItem(0, 4);
                mockRepository.ReplayAll();
                listBase.Add(3);
                listBase[0] = 4;
                mockRepository.VerifyAll();
            }

            [Test]
            public void InterfaceEnsureInsertItemCall()
            {
                var mockRepository = new MockRepository();
                var listBase = mockRepository.PartialMock<Indexer>();
                listBase.SetItem(0, 4);
                mockRepository.ReplayAll();
                listBase.Add(3);
                ((IList)listBase)[0] = 4;
                mockRepository.VerifyAll();
            }
        }
        [TestFixture]
        public class AddRange : ListBase<int>
        {
            [Test]
            public void Simple()
            {

                var listBase = new ListBase<int>(); 
                listBase.AddRange(new []{3});
                Assert.IsTrue(listBase.Contains(3));
            }
            [Test]
            public void SimpleEnsureInsertItemCall()
            {
                var collection = new[] { 3 };
                var mockRepository = new MockRepository();
                var listBase = mockRepository.CreateMock<AddRange>();
                listBase.AddRangeItems(collection);
                mockRepository.ReplayAll();
                listBase.AddRange(collection);
                mockRepository.VerifyAll();
            }

        }
        [TestFixture]
        public class Insert : ListBase<int>
        {
            [Test]
            public void Simple()
            {

                var listBase = new ListBase<int>(); 
                listBase.Insert(0,3);
                Assert.IsTrue(listBase.Contains(3));
            }
            [Test]
            public void Interface()
            {
                var listBase = (IList)new ListBase<int>(); 
                listBase.Insert(0,3);
                Assert.IsTrue(listBase.Contains(3));
            }
            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void ExceptionInvalidType()
            {
                var listBase = (IList)new ListBase<int>(); 
                listBase.Insert(0,"d");
            }
            [Test]
            public void EnsureInsertItemCall()
            {
                var mockRepository = new MockRepository();
                var listBase = mockRepository.CreateMock<Insert>();
                listBase.InsertItem(0, 5);
                mockRepository.ReplayAll();
                listBase.Insert(0, 5);
                mockRepository.VerifyAll();
            }

            [Test]
            public void InterfaceEnsureInsertItemCall()
            {
                var mockRepository = new MockRepository();
                var listBase = mockRepository.CreateMock<Insert>();
                listBase.InsertItem(0, 5);
                mockRepository.ReplayAll();
                ((IList)listBase).Insert(0,5);
                mockRepository.VerifyAll();
            }
        }

        [TestFixture]
        public class AsReadOnly
        {
            [Test]
            public void Simple()
            {
                var listBase = new ListBase<int> {3};
                Assert.IsTrue(listBase.AsReadOnly().Contains(3));
            }
        }
   
        [TestFixture]
        public class RemoveAll : ListBase<string>
        {
            [Test]
            public void Simple()
            {
                var listBase = new ListBase<string> { "as", "bs", "c" };
                Assert.AreEqual(2, listBase.RemoveAll(EndsWiths));
                Assert.AreEqual("c", listBase[0]);
                Assert.AreEqual(1, listBase.Count);
            }


            [Test]
            public void EnsureRemoveItem()
            {
                var mockRepository = new MockRepository();
                var listBase = mockRepository.PartialMock<RemoveAll>();
                listBase.RemoveItem(0, "as");
                listBase.RemoveItem(0, "bs");
                mockRepository.ReplayAll();
                listBase.Add("as");
                listBase.Add("bs");
                listBase.Add("c");
                listBase.RemoveAll(EndsWiths);
                mockRepository.VerifyAll();
            }

            private static bool EndsWiths(string s)
            {
                return s.EndsWith("s");
            }

        }
        [TestFixture]
        public class Remove : ListBase<int>
        {
            [Test]
            public void Simple()
            {
                var listBase = new ListBase<int> { 4, 7, 9 };
                Assert.IsTrue(listBase.Remove(7));
                Assert.AreEqual(4, listBase[0]);
                Assert.AreEqual(9, listBase[1]);
                Assert.AreEqual(2, listBase.Count);
            }
            [Test]
            public void Interface()
            {
                var listBase = (IList)new ListBase<int> { 4, 7, 9 };
                listBase.Remove(7);
                Assert.AreEqual(4, listBase[0]);
                Assert.AreEqual(9, listBase[1]);
                Assert.AreEqual(2, listBase.Count);
            }
            [Test]
            public void InvalidType()
            {
                var listBase = (IList)new ListBase<int> ();
                listBase.Remove("d");
            }


            [Test]
            public void EnsureRemoveItem()
            {
                var mockRepository = new MockRepository();
                var listBase = mockRepository.PartialMock<Remove>();
                listBase.RemoveItem(1, 7);
                mockRepository.ReplayAll();
                listBase.Add(4);
                listBase.Add(7);
                listBase.Add(8);
                listBase.Remove(7);
                mockRepository.VerifyAll();
            }
            [Test]
            public void InterfaceEnsureRemoveItem()
            {
                var mockRepository = new MockRepository();
                var listBase = mockRepository.PartialMock<Remove>();
                listBase.RemoveItem(1, 7);
                mockRepository.ReplayAll();
                listBase.Add(4);
                listBase.Add(7);
                listBase.Add(8);
               ((IList) listBase).Remove(7);
                mockRepository.VerifyAll();
            }


        }
        [TestFixture]
        public class TrimExcess
        {
            [Test]
            public void Simple()
            {
                var listBase = new ListBase<string>(5) { "as", "bs", "c" };
                listBase.TrimExcess();
                Assert.AreEqual(3, listBase.Capacity);
            }


        }
        [TestFixture]
        public class FindLastIndex
        {
            [Test]
            public void Simple()
            {
                var listBase = new ListBase<string> { "as", "bs", "c" };
                Assert.AreEqual(1, listBase.FindLastIndex(EndsWiths));
            }
            [Test]
            public void Index()
            {
                var listBase = new ListBase<string> { "as", "bs", "c" };
                Assert.AreEqual(1, listBase.FindLastIndex(2, EndsWiths));
            }
            [Test]
            public void IndexCount()
            {
                var listBase = new ListBase<string> { "as", "bs", "c" };
                Assert.AreEqual(1, listBase.FindLastIndex(2,2,EndsWiths));
            }

            private static bool EndsWiths(string s)
            {
                return s.EndsWith("s");
            }

        }
        [TestFixture]
        public class FindIndex
        {
            [Test]
            public void Simple()
            {
                var listBase = new ListBase<string> { "as", "bs", "c" };
                Assert.AreEqual(0, listBase.FindIndex(EndsWiths));
            }
            [Test]
            public void Index()
            {
                var listBase = new ListBase<string> { "as", "bs", "c" };
                Assert.AreEqual(0, listBase.FindIndex(0, EndsWiths));
            }
            [Test]
            public void IndexCount()
            {
                var listBase = new ListBase<string> { "as", "bs", "c" };
                Assert.AreEqual(0, listBase.FindIndex(0, 1, EndsWiths));
            }

            private static bool EndsWiths(string s)
            {
                return s.EndsWith("s");
            }

        }
        [TestFixture]
        public class Reverse
        {
            [Test]
            public void Simple()
            {
                var listBase = new ListBase<string> { "a", "b" };
                listBase.Reverse();

                Assert.AreEqual("b", listBase[0]);
                Assert.AreEqual("a", listBase[1]);
            }
            [Test]
            public void Complex()
            {
                var listBase = new ListBase<string> { "a", "b" };
                listBase.Reverse(0, 2);

                Assert.AreEqual("b", listBase[0]);
                Assert.AreEqual("a", listBase[1]);
            }
        }
        [TestFixture]
        public class GetEnumerator
        {

            [Test]
            public void Simple()
            {
                var listBase = new ListBase<string> { "a", "b", "c" };
                var enumerator = listBase.GetEnumerator();

                var counter = 0;

                while (enumerator.MoveNext())
                {
                    counter++;

                }

                Assert.AreEqual(counter, 3);
            }

            [Test]
            public void GenericInterface()
            {
                var bag = new ListBase<string> { "a", "b", "c" };
                var enumerator = bag.GetEnumerator();

                var counter = 0;

                while (enumerator.MoveNext())
                {
                    counter++;

                }

                Assert.AreEqual(counter, 3);
            }

            [Test]
            public void Interface()
            {
                var listBase = (IEnumerable)new ListBase<string> { "a", "b", "c" };
                var enumerator = listBase.GetEnumerator();

                var counter = 0;

                while (enumerator.MoveNext())
                {
                    counter++;
                }

                Assert.AreEqual(counter, 3);
            }

        }

        [TestFixture]
        public class ToArray
        {
            [Test]
            public void Simple()
            {
                var listBase = new ListBase<string> { "a", "b" };

                var array = listBase.ToArray();

                Assert.AreEqual("a", array[0]);
                Assert.AreEqual("b", array[1]);
            }
        }
        [TestFixture]
        public class CopyTo
        {
            [Test]
            public void Simple()
            {
                var listBase = new ListBase<string> {"a", "b"};

                var array = new string[2];

                listBase.CopyTo(array);

                Assert.AreEqual("a", array[0]);
                Assert.AreEqual("b", array[1]);
            }
            [Test]
            public void Interface()
            {
                var listBase = (ICollection)new ListBase<string>{"a","b"};


                var array = new string[2];

                listBase.CopyTo(array,0);

                Assert.AreEqual("a", array[0]);
                Assert.AreEqual("b", array[1]);
            }
            [Test]
            public void ArrayIndex()
            {
                var listBase = new ListBase<string> {"a", "b"};

                var array = new string[2];

                listBase.CopyTo(array, 0);

                Assert.AreEqual("a", array[0]);
                Assert.AreEqual("b", array[1]);
            }
            [Test]
            public void Complex()
            {
                var listBase = new ListBase<string> {"a", "b"};

                var array = new string[2];

                listBase.CopyTo(0, array, 0, 2);

                Assert.AreEqual("a", array[0]);
                Assert.AreEqual("b", array[1]);
            }
        }
        [TestFixture]
        public class ConvertAll
        {
            [Test]
            public void Simple()
            {
                var intListBase = new ListBase<int> {4};

                var longListBase = intListBase.ConvertAll(new Converter<int, long>(IntToLong));

                Assert.IsTrue(longListBase.Contains(4));
            }

            public static long IntToLong(int x)
            {
                return x;
            }
        }
        [TestFixture]
        public class Contains
        {
            [Test]
            public void Simple()
            {
                var listBase = new ListBase<int> {3};
                Assert.IsTrue(listBase.Contains(3));
            }
            [Test]
            public void Interface()
            {
                var listBase = new ListBase<int> {3};
                Assert.IsTrue(((IList)listBase).Contains(3));
            }
        }
        [TestFixture]
        public class Capacity
        {
            [Test]
            public void Simple()
            {
                var listBase = new ListBase<int>();
                Assert.AreEqual(0, listBase.Capacity);
                listBase.Capacity = 10;
                Assert.AreEqual(10, listBase.Capacity);
            }
        }
        [TestFixture]
        public class IndexOf
        {
            [Test]
            public void Simple()
            {
                var listBase = new ListBase<int> { 3, 4, 5 };
                Assert.AreEqual(1, listBase.IndexOf(4));
                Assert.AreEqual(1, listBase.IndexOf(4, 0));
                Assert.AreEqual(1, listBase.IndexOf(4, 0, 3));
            }
            [Test]
            public void Interface()
            {
                var listBase = (IList)new ListBase<int> { 3, 4, 5 };
                Assert.AreEqual(1, listBase.IndexOf(4));
                Assert.AreEqual(-1, listBase.IndexOf(9));
                Assert.AreEqual(-1, listBase.IndexOf("b"));
            }
        }
        [TestFixture]
        public class LastIndexOf
        {
            [Test]
            public void Simple()
            {
                var listBase = new ListBase<int> { 3, 4, 5, 4 };
                Assert.AreEqual(3, listBase.LastIndexOf(4));
                Assert.AreEqual(3, listBase.LastIndexOf(4, 3));
                Assert.AreEqual(3, listBase.LastIndexOf(4, 3, 4));
            }
        }
        [TestFixture]
        public class BinarySearch
        {
            [Test]
            public void Simple()
            {
                var listBase = new ListBase<int> {3, 4, 5};
                Assert.AreEqual(2, listBase.BinarySearch(5));
            }
            [Test]
            public void Comparer()
            {
                var listBase = new ListBase<int> {3, 4, 5};
                Assert.AreEqual(2, listBase.BinarySearch(5, Comparer<int>.Default));
            }
            [Test]
            public void ComparerIndex()
            {
                var listBase = new ListBase<int> {3, 4, 5};
                Assert.AreEqual(2, listBase.BinarySearch(0, 3, 5, Comparer<int>.Default));
            }
        }
        [TestFixture]
        public class Accept
        {
            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullVisitor()
            {
                var visitableList = new ListBase<int>(); 
                visitableList.AcceptVisitor(null);
            }

            [Test]
            public void Simple()
            {
                var visitableList = GetTestList();
                var visitor = new SumVisitor();

                visitableList.AcceptVisitor(visitor);

                Assert.AreEqual(visitor.Sum, 0 + 3 + 6 + 9 + 12);
            }

            [Test]
            public void StoppingVisitor()
            {
                var visitableList = GetTestList();

                var visitor = new ComparableFindingVisitor<int>(6);
                visitableList.AcceptVisitor(visitor);

                Assert.IsTrue(visitor.Found);

                visitor = new ComparableFindingVisitor<int>(99);
                visitableList.AcceptVisitor(visitor);
                Assert.IsFalse(visitor.Found);
            }
        }

     

        [TestFixture]
        public class IsFixedSize
        {
            [Test]
            public void Simple()
            {
                var listBase = new ListBase<int>();
                Assert.IsFalse(listBase.IsFixedSize);

                listBase = GetTestList();
                Assert.IsFalse(listBase.IsFixedSize);
            }
        }



        [TestFixture]
        public class Serializable
        {
            [Test]
            public void Simple()
            {
                var listBase = new ListBase<int>();

                for (var i = 0; i < 100; i++)
                {
                    listBase.Add(i);
                }

                for (var i = 200; i >= 100; i--)
                {
                    listBase.Add(i);
                }

                var newList = SerializeUtil.BinarySerializeDeserialize(listBase);

                for (var i = 0; i < 100; i++)
                {
                    Assert.AreEqual(newList[i], i);
                }

                var counter = 100;

                for (var i = 200; i >= 100; i--)
                {
                    Assert.AreEqual(newList[counter], i);
                    counter++;
                }
            }
        }

        #endregion

        #region Private Members

        private static ListBase<int> GetTestList()
        {
            var visitableList = new ListBase<int>(5);

            for (var i = 0; i < 5; i++)
            {
                visitableList.Add(i * 3);
            }

            return visitableList;
        }

        #endregion
    }
}
