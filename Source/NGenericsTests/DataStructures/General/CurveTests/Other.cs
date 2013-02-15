/*  
 Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.CurveTests
{
    [TestFixture]
    public class Other
    {
        [Test]
        public void IsEmpty()
        {
            var curve = new Curve<int, int>();
            Assert.IsTrue(curve.IsEmpty);
            curve.Add(3, 2);
            Assert.IsFalse(curve.IsEmpty);
            curve.Clear();
            Assert.IsTrue(curve.IsEmpty);

        }

        [Test]
        public void GetValue()
        {
            var curve = new Curve<int, int> { { 3, 2 } };

            Assert.IsTrue(curve.GetValue(3) == 2);
            // Assert.IsTrue(curve[0].Value == 2);
        }

        [Test]
        public void Remove()
        {
            var curve = new Curve<int, int> { { 3, 2 } };
            var a = new Association<int, int>(11, 32);
            curve.Remove(a);
            Assert.IsFalse(curve.Contains(a));

        }



        //    //[Test]
        //    //public void EnsureSortItemsCall()
        //    //{
        //    //    var mockRepository = new MockRepository();
        //    //    Sort curve = mockRepository.PartialMock<Sort>();
        //    //    curve.SortItems();
        //    //    mockRepository.ReplayAll();
        //    //    curve.Add(5);
        //    //    curve.Sort();
        //    //    mockRepository.VerifyAll();
        //    //}
        //    [Test]
        //    public void Comparison()
        //    {
        //        var curve = new Curve<int,int> { 3, 2, 6, 9, 1 };
        //        Comparison<int> comparison = IntComparison;
        //        curve.Sort(comparison);
        //        Assert.AreEqual(1, curve[0]);
        //        Assert.AreEqual(2, curve[1]);
        //        Assert.AreEqual(3, curve[2]);
        //        Assert.AreEqual(6, curve[3]);
        //        Assert.AreEqual(9, curve[4]);
        //    }
        //    //[Test]
        //    //public void EnsureComparisonSortItemsCall()
        //    //{
        //    //    Comparison<int> comparison = IntComparison;
        //    //    var mockRepository = new MockRepository();
        //    //    Sort curve = mockRepository.PartialMock<Sort>();
        //    //    curve.SortItems(comparison);
        //    //    mockRepository.ReplayAll();
        //    //    curve.Add(5);
        //    //    curve.Sort(comparison);
        //    //    mockRepository.VerifyAll();
        //    //}
        //    [Test]
        //    public void Comparer()
        //    {
        //        var curve = new Curve<int,int> { 3, 2, 6, 9, 1 };
        //        curve.Sort(Comparer<int>.Default);
        //        Assert.AreEqual(1, curve[0]);
        //        Assert.AreEqual(2, curve[1]);
        //        Assert.AreEqual(3, curve[2]);
        //        Assert.AreEqual(6, curve[3]);
        //        Assert.AreEqual(9, curve[4]);
        //    }
        //    //[Test]
        //    //public void EnsureComparerSortItemsCall()
        //    //{
        //    //    var mockRepository = new MockRepository();
        //    //    Sort curve = mockRepository.PartialMock<Sort>();
        //    //    curve.SortItems(Comparer<int>.Default);
        //    //    mockRepository.ReplayAll();
        //    //    curve.Add(5);
        //    //    curve.Sort(Comparer<int>.Default);
        //    //    mockRepository.VerifyAll();
        //    //}
        //    [Test]
        //    public void IndexCountComparer()
        //    {
        //        var curve = new Curve<int,int> { 3, 2, 6, 9, 1 };
        //        curve.Sort(0, 5, Comparer<int>.Default);
        //        Assert.AreEqual(1, curve[0]);
        //        Assert.AreEqual(2, curve[1]);
        //        Assert.AreEqual(3, curve[2]);
        //        Assert.AreEqual(6, curve[3]);
        //        Assert.AreEqual(9, curve[4]);
        //    }
        //    //[Test]
        //    //public void EnsureIndexCountComparerSortItemsCall()
        //    //{
        //    //    var mockRepository = new MockRepository();
        //    //    Sort curve = mockRepository.PartialMock<Sort>();
        //    //    curve.SortItems(0, 5, Comparer<int>.Default);
        //    //    mockRepository.ReplayAll();
        //    //    curve.Add(5);
        //    //    curve.Sort(0, 5, Comparer<int>.Default);
        //    //    mockRepository.VerifyAll();
        //    //}

        //    private static int IntComparison(int x, int y)
        //    {
        //        return x.CompareTo(y);
        //    }
    }
    //[TestFixture]
    //public class Indexer : Curve<int,int>
    //{
    //    [Test]
    //    public void Simple()
    //    {

    //        var curve = new Curve<int,int> { 3 };
    //        curve[0] = 4;
    //        Assert.IsTrue(curve.Contains(4));
    //        Assert.IsFalse(curve.Contains(3));
    //    }
    //    [Test]
    //    public void Interface()
    //    {
    //        var curve = (IList)new Curve<int,int>();
    //        curve.Add(3);
    //        curve[0] = 4;
    //        Assert.IsTrue(curve.Contains(4));
    //        Assert.IsFalse(curve.Contains(3));
    //    }
    //    [Test]
    //    [ExpectedException(typeof(ArgumentException))]
    //    public void ExceptionInvalidType()
    //    {
    //        var curve = (IList)new Curve<int,int>();
    //        curve.Add(3);
    //        curve[0] = "a";
    //    }
    //    [Test]
    //    public void SimpleEnsureInsertItemCall()
    //    {
    //        var mockRepository = new MockRepository();
    //        var curve = mockRepository.PartialMock<Indexer>();
    //        curve.SetItem(0, 4);
    //        mockRepository.ReplayAll();
    //        curve.Add(3);
    //        curve[0] = 4;
    //        mockRepository.VerifyAll();
    //    }

    //    [Test]
    //    public void InterfaceEnsureInsertItemCall()
    //    {
    //        var mockRepository = new MockRepository();
    //        var curve = mockRepository.PartialMock<Indexer>();
    //        curve.SetItem(0, 4);
    //        mockRepository.ReplayAll();
    //        curve.Add(3);
    //        ((IList)curve)[0] = 4;
    //        mockRepository.VerifyAll();
    //    }
    //}
    //[TestFixture]
    //public class AddRange : Curve<int,int>
    //{
    //    [Test]
    //    public void Simple()
    //    {

    //        var curve = new Curve<int,int>();
    //        curve.AddRange(new[] { 3 });
    //        Assert.IsTrue(curve.Contains(3));
    //    }
    //    [Test]
    //    public void SimpleEnsureInsertItemCall()
    //    {
    //        var collection = new[] { 3 };
    //        var mockRepository = new MockRepository();
    //        var curve = mockRepository.StrictMock<AddRange>();
    //        curve.AddRangeItems(collection);
    //        mockRepository.ReplayAll();
    //        curve.AddRange(collection);
    //        mockRepository.VerifyAll();
    //    }

    //}
    //[TestFixture]
    //public class Insert : Curve<int,int>
    //{
    //    [Test]
    //    public void Simple()
    //    {

    //        var curve = new Curve<int,int>();
    //        curve.Insert(0, 3);
    //        Assert.IsTrue(curve.Contains(3));
    //    }
    //    [Test]
    //    public void Interface()
    //    {
    //        var curve = (IList)new Curve<int,int>();
    //        curve.Insert(0, 3);
    //        Assert.IsTrue(curve.Contains(3));
    //    }
    //    [Test]
    //    [ExpectedException(typeof(ArgumentException))]
    //    public void ExceptionInvalidType()
    //    {
    //        var curve = (IList)new Curve<int,int>();
    //        curve.Insert(0, "d");
    //    }
    //    [Test]
    //    public void EnsureInsertItemCall()
    //    {
    //        var mockRepository = new MockRepository();
    //        var curve = mockRepository.StrictMock<Insert>();
    //        curve.InsertItem(0, 5);
    //        mockRepository.ReplayAll();
    //        curve.Insert(0, 5);
    //        mockRepository.VerifyAll();
    //    }

    //    [Test]
    //    public void InterfaceEnsureInsertItemCall()
    //    {
    //        var mockRepository = new MockRepository();
    //        var curve = mockRepository.StrictMock<Insert>();
    //        curve.InsertItem(0, 5);
    //        mockRepository.ReplayAll();
    //        ((IList)curve).Insert(0, 5);
    //        mockRepository.VerifyAll();
    //    }
    //}

    //[TestFixture]
    //public class AsReadOnly
    //{
    //    [Test]
    //    public void Simple()
    //    {
    //        var curve = new Curve<int,int> { 3 };
    //        Assert.IsTrue(curve.AsReadOnly().Contains(3));
    //    }
    //}

    //[TestFixture]
    //public class RemoveAll : Curve<string>
    //{
    //    [Test]
    //    public void Simple()
    //    {
    //        var curve = new Curve<string> { "as", "bs", "c" };
    //        Assert.AreEqual(2, curve.RemoveAll(EndsWiths));
    //        Assert.AreEqual("c", curve[0]);
    //        Assert.AreEqual(1, curve.Count);
    //    }


    //    [Test]
    //    public void EnsureRemoveItem()
    //    {
    //        var mockRepository = new MockRepository();
    //        var curve = mockRepository.PartialMock<RemoveAll>();
    //        curve.RemoveItem(0, "as");
    //        curve.RemoveItem(0, "bs");
    //        mockRepository.ReplayAll();
    //        curve.Add("as");
    //        curve.Add("bs");
    //        curve.Add("c");
    //        curve.RemoveAll(EndsWiths);
    //        mockRepository.VerifyAll();
    //    }

    //    private static bool EndsWiths(string s)
    //    {
    //        return s.EndsWith("s");
    //    }

    //}
    //[TestFixture]
    //public class Remove : Curve<int,int>
    //{
    //    [Test]
    //    public void Simple()
    //    {
    //        var curve = new Curve<int,int> { 4, 7, 9 };
    //        Assert.IsTrue(curve.Remove(7));
    //        Assert.AreEqual(4, curve[0]);
    //        Assert.AreEqual(9, curve[1]);
    //        Assert.AreEqual(2, curve.Count);
    //    }
    //    [Test]
    //    public void Interface()
    //    {
    //        var curve = (IList)new Curve<int,int> { 4, 7, 9 };
    //        curve.Remove(7);
    //        Assert.AreEqual(4, curve[0]);
    //        Assert.AreEqual(9, curve[1]);
    //        Assert.AreEqual(2, curve.Count);
    //    }
    //    [Test]
    //    public void InvalidType()
    //    {
    //        var curve = (IList)new Curve<int,int>();
    //        curve.Remove("d");
    //    }


    //    [Test]
    //    public void EnsureRemoveItem()
    //    {
    //        var mockRepository = new MockRepository();
    //        var curve = mockRepository.PartialMock<Remove>();
    //        curve.RemoveItem(1, 7);
    //        mockRepository.ReplayAll();
    //        curve.Add(4);
    //        curve.Add(7);
    //        curve.Add(8);
    //        curve.Remove(7);
    //        mockRepository.VerifyAll();
    //    }
    //    [Test]
    //    public void InterfaceEnsureRemoveItem()
    //    {
    //        var mockRepository = new MockRepository();
    //        var curve = mockRepository.PartialMock<Remove>();
    //        curve.RemoveItem(1, 7);
    //        mockRepository.ReplayAll();
    //        curve.Add(4);
    //        curve.Add(7);
    //        curve.Add(8);
    //        ((IList)curve).Remove(7);
    //        mockRepository.VerifyAll();
    //    }


    //}
    //[TestFixture]
    //public class TrimExcess
    //{
    //    [Test]
    //    public void Simple()
    //    {
    //        var curve = new Curve<string>(5) { "as", "bs", "c" };
    //        curve.TrimExcess();
    //        Assert.AreEqual(3, curve.Capacity);
    //    }


    //}
    //[TestFixture]
    //public class FindLastIndex
    //{
    //    [Test]
    //    public void Simple()
    //    {
    //        var curve = new Curve<string> { "as", "bs", "c" };
    //        Assert.AreEqual(1, curve.FindLastIndex(EndsWiths));
    //    }
    //    [Test]
    //    public void Index()
    //    {
    //        var curve = new Curve<string> { "as", "bs", "c" };
    //        Assert.AreEqual(1, curve.FindLastIndex(2, EndsWiths));
    //    }
    //    [Test]
    //    public void IndexCount()
    //    {
    //        var curve = new Curve<string> { "as", "bs", "c" };
    //        Assert.AreEqual(1, curve.FindLastIndex(2, 2, EndsWiths));
    //    }

    //    private static bool EndsWiths(string s)
    //    {
    //        return s.EndsWith("s");
    //    }

    //}
    //[TestFixture]
    //public class FindIndex
    //{
    //    [Test]
    //    public void Simple()
    //    {
    //        var curve = new Curve<string> { "as", "bs", "c" };
    //        Assert.AreEqual(0, curve.FindIndex(EndsWiths));
    //    }
    //    [Test]
    //    public void Index()
    //    {
    //        var curve = new Curve<string> { "as", "bs", "c" };
    //        Assert.AreEqual(0, curve.FindIndex(0, EndsWiths));
    //    }
    //    [Test]
    //    public void IndexCount()
    //    {
    //        var curve = new Curve<string> { "as", "bs", "c" };
    //        Assert.AreEqual(0, curve.FindIndex(0, 1, EndsWiths));
    //    }

    //    private static bool EndsWiths(string s)
    //    {
    //        return s.EndsWith("s");
    //    }

    //}
    //[TestFixture]
    //public class Reverse
    //{
    //    [Test]
    //    public void Simple()
    //    {
    //        var curve = new Curve<string> { "a", "b" };
    //        curve.Reverse();

    //        Assert.AreEqual("b", curve[0]);
    //        Assert.AreEqual("a", curve[1]);
    //    }
    //    [Test]
    //    public void Complex()
    //    {
    //        var curve = new Curve<string> { "a", "b" };
    //        curve.Reverse(0, 2);

    //        Assert.AreEqual("b", curve[0]);
    //        Assert.AreEqual("a", curve[1]);
    //    }
    //}
    //[TestFixture]
    //public class GetEnumerator
    //{

    //    [Test]
    //    public void Simple()
    //    {
    //        var curve = new Curve<string> { "a", "b", "c" };
    //        var enumerator = curve.GetEnumerator();

    //        var counter = 0;

    //        while (enumerator.MoveNext())
    //        {
    //            counter++;

    //        }

    //        Assert.AreEqual(counter, 3);
    //    }

    //    [Test]
    //    public void GenericInterface()
    //    {
    //        var bag = new Curve<string> { "a", "b", "c" };
    //        var enumerator = bag.GetEnumerator();

    //        var counter = 0;

    //        while (enumerator.MoveNext())
    //        {
    //            counter++;

    //        }

    //        Assert.AreEqual(counter, 3);
    //    }

    //    [Test]
    //    public void Interface()
    //    {
    //        var curve = (IEnumerable)new Curve<string> { "a", "b", "c" };
    //        var enumerator = curve.GetEnumerator();

    //        var counter = 0;

    //        while (enumerator.MoveNext())
    //        {
    //            counter++;
    //        }

    //        Assert.AreEqual(counter, 3);
    //    }

    //}

    //[TestFixture]
    //public class ToArray
    //{
    //    [Test]
    //    public void Simple()
    //    {
    //        var curve = new Curve<string> { "a", "b" };

    //        var array = curve.ToArray();

    //        Assert.AreEqual("a", array[0]);
    //        Assert.AreEqual("b", array[1]);
    //    }
    //}
    //[TestFixture]
    //public class CopyTo
    //{
    //    [Test]
    //    public void Simple()
    //    {
    //        var curve = new Curve<string> { "a", "b" };

    //        var array = new string[2];

    //        curve.CopyTo(array);

    //        Assert.AreEqual("a", array[0]);
    //        Assert.AreEqual("b", array[1]);
    //    }
    //    [Test]
    //    public void Interface()
    //    {
    //        var curve = (ICollection)new Curve<string> { "a", "b" };


    //        var array = new string[2];

    //        curve.CopyTo(array, 0);

    //        Assert.AreEqual("a", array[0]);
    //        Assert.AreEqual("b", array[1]);
    //    }
    //    [Test]
    //    public void ArrayIndex()
    //    {
    //        var curve = new Curve<string> { "a", "b" };

    //        var array = new string[2];

    //        curve.CopyTo(array, 0);

    //        Assert.AreEqual("a", array[0]);
    //        Assert.AreEqual("b", array[1]);
    //    }
    //    [Test]
    //    public void Complex()
    //    {
    //        var curve = new Curve<string> { "a", "b" };

    //        var array = new string[2];

    //        curve.CopyTo(0, array, 0, 2);

    //        Assert.AreEqual("a", array[0]);
    //        Assert.AreEqual("b", array[1]);
    //    }
    //}
    //[TestFixture]
    //public class ConvertAll
    //{
    //    [Test]
    //    public void Simple()
    //    {
    //        var intCurve = new Curve<int,int> { 4 };

    //        var longCurve = intCurve.ConvertAll(new Converter<int, long>(IntToLong));

    //        Assert.IsTrue(longCurve.Contains(4));
    //    }

    //    public static long IntToLong(int x)
    //    {
    //        return x;
    //    }
    //}
    //[TestFixture]
    //public class Contains
    //{
    //    [Test]
    //    public void Simple()
    //    {
    //        var curve = new Curve<int,int> { 3 };
    //        Assert.IsTrue(curve.Contains(3));
    //    }
    //    [Test]
    //    public void Interface()
    //    {
    //        var curve = new Curve<int,int> { 3 };
    //        Assert.IsTrue(((IList)curve).Contains(3));
    //    }
    //}
    //[TestFixture]
    //public class Capacity
    //{
    //    [Test]
    //    public void Simple()
    //    {
    //        var curve = new Curve<int,int>();
    //        Assert.AreEqual(0, curve.Capacity);
    //        curve.Capacity = 10;
    //        Assert.AreEqual(10, curve.Capacity);
    //    }
    //}
    //[TestFixture]
    //public class IndexOf
    //{
    //    [Test]
    //    public void Simple()
    //    {
    //        var curve = new Curve<int,int> { 3, 4, 5 };
    //        Assert.AreEqual(1, curve.IndexOf(4));
    //        Assert.AreEqual(1, curve.IndexOf(4, 0));
    //        Assert.AreEqual(1, curve.IndexOf(4, 0, 3));
    //    }
    //    [Test]
    //    public void Interface()
    //    {
    //        var curve = (IList)new Curve<int,int> { 3, 4, 5 };
    //        Assert.AreEqual(1, curve.IndexOf(4));
    //        Assert.AreEqual(-1, curve.IndexOf(9));
    //        Assert.AreEqual(-1, curve.IndexOf("b"));
    //    }
    //}
    //[TestFixture]
    //public class LastIndexOf
    //{
    //    [Test]
    //    public void Simple()
    //    {
    //        var curve = new Curve<int,int> { 3, 4, 5, 4 };
    //        Assert.AreEqual(3, curve.LastIndexOf(4));
    //        Assert.AreEqual(3, curve.LastIndexOf(4, 3));
    //        Assert.AreEqual(3, curve.LastIndexOf(4, 3, 4));
    //    }
    //}
    //[TestFixture]
    //public class BinarySearch
    //{
    //    [Test]
    //    public void Simple()
    //    {
    //        var curve = new Curve<int,int> { 3, 4, 5 };
    //        Assert.AreEqual(2, curve.BinarySearch(5));
    //    }
    //    [Test]
    //    public void Comparer()
    //    {
    //        var curve = new Curve<int,int> { 3, 4, 5 };
    //        Assert.AreEqual(2, curve.BinarySearch(5, Comparer<int>.Default));
    //    }
    //    [Test]
    //    public void ComparerIndex()
    //    {
    //        var curve = new Curve<int,int> { 3, 4, 5 };
    //        Assert.AreEqual(2, curve.BinarySearch(0, 3, 5, Comparer<int>.Default));
    //    }
    //}
    //[TestFixture]
    //public class Accept
    //{
    //    [Test]
    //    [ExpectedException(typeof(ArgumentNullException))]
    //    public void ExceptionNullVisitor()
    //    {
    //        var visitableList = new Curve<int,int>();
    //        visitableList.AcceptVisitor(null);
    //    }

    //    [Test]
    //    public void Simple()
    //    {
    //        var visitableList = GetTestList();
    //        var visitor = new SumVisitor();

    //        visitableList.AcceptVisitor(visitor);

    //        Assert.AreEqual(visitor.Sum, 0 + 3 + 6 + 9 + 12);
    //    }

    //    [Test]
    //    public void StoppingVisitor()
    //    {
    //        var visitableList = GetTestList();

    //        var visitor = new ComparableFindingVisitor<int>(6);
    //        visitableList.AcceptVisitor(visitor);

    //        Assert.IsTrue(visitor.Found);

    //        visitor = new ComparableFindingVisitor<int>(99);
    //        visitableList.AcceptVisitor(visitor);
    //        Assert.IsFalse(visitor.Found);
    //    }
    //}



    //[TestFixture]
    //public class IsFixedSize
    //{
    //    [Test]
    //    public void Simple()
    //    {
    //        var curve = new Curve<int,int>();
    //        Assert.IsFalse(curve.IsFixedSize);

    //        curve = GetTestList();
    //        Assert.IsFalse(curve.IsFixedSize);
    //    }
    //}



    //[TestFixture]
    //public class Serializable
    //{
    //    [Test]
    //    public void Simple()
    //    {
    //        var curve = new Curve<int,int>();

    //        for (var i = 0; i < 100; i++)
    //        {
    //            curve.Add(i);
    //        }

    //        for (var i = 200; i >= 100; i--)
    //        {
    //            curve.Add(i);
    //        }

    //        var newList = SerializeUtil.BinarySerializeDeserialize(curve);

    //        for (var i = 0; i < 100; i++)
    //        {
    //            Assert.AreEqual(newList[i], i);
    //        }

    //        var counter = 100;

    //        for (var i = 200; i >= 100; i--)
    //        {
    //            Assert.AreEqual(newList[counter], i);
    //            counter++;
    //        }
    //    }
    //}


}