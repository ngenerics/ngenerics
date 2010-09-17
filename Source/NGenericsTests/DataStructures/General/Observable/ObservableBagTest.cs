/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Threading;
using NGenerics.DataStructures.General.Observable;
using NGenerics.Tests.TestObjects;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.Observable.ObservableBagTest
{

    [TestFixture]
    public class Reentrancy
    {
        ObservableBag<int> bag;
        [Test]
        public void Simple()
        {
            bag = new ObservableBag<int>();
            bag.CollectionChanged += bag_CollectionChanged1;

            ThreadStart start = FireAdd;
            Debug.WriteLine("1");
            var thread = new Thread(start);
            thread.Start();
            Debug.WriteLine("2");
            bag.Add(3);
            Debug.WriteLine("3");
            thread.Join(5000);
        }

        private void FireAdd()
        {
            Debug.WriteLine("FireAdd start");
            bag.Add(2);
            Debug.WriteLine("FireAdd end");
        }

        static void bag_CollectionChanged1(object sender, NotifyCollectionChangedEventArgs e)
        {
            Debug.WriteLine("bag_CollectionChanged1");
            Thread.Sleep(10000);
        }

    }
    [TestFixture]
    public class Construction
    {

        [Test]
        public void Serialization()
        {
            var deserialize = SerializeUtil.BinarySerializeDeserialize(new ObservableBag<int>());
            ObservableCollectionTester.CheckMonitor(deserialize);
        }
        [Test]
        public void Monitor1()
        {
            ObservableCollectionTester.CheckMonitor(new ObservableBag<int>());
        }
        [Test]
        public void Monitor2()
        {
            ObservableCollectionTester.CheckMonitor(new ObservableBag<int>(EqualityComparer<int>.Default));
        }
        [Test]
        public void Monitor3()
        {
            ObservableCollectionTester.CheckMonitor(new ObservableBag<int>(2));
        }
        [Test]
        public void Monitor4()
        {
            ObservableCollectionTester.CheckMonitor(new ObservableBag<int>(2, EqualityComparer<int>.Default));
        }
    }

    [TestFixture]
    public class Add
    {
        [Test]
        public void Simple()
        {
            var bag = new ObservableBag<string>();
            ObservableCollectionTester.ExpectEvents(bag, obj => obj.Add("foo"), "Count", "Item[]", "IsEmpty");
        }

        [Test]
        public void Amount()
        {
            var bag = new ObservableBag<string>();
            ObservableCollectionTester.ExpectEvents(bag, obj => obj.Add("foo", 2), "Count", "Item[]", "IsEmpty");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionReentrancy()
        {
            var bag = new ObservableBag<string>();
            new ReentracyTester<ObservableBag<string>>(bag, obj => obj.Add("foo"));
        }
    }
    [TestFixture]
    public class Clear
    {
        [Test]
        public void Simple()
        {
            var bag = new ObservableBag<string> { "foo" };

            ObservableCollectionTester.ExpectEvents(bag, obj => obj.Clear(), "Count", "Item[]", "IsEmpty");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionReentrancy()
        {
            var bag = new ObservableBag<string> { "foo" };
            new ReentracyTester<ObservableBag<string>>(bag, obj => obj.Clear());
        }
    }

    [TestFixture]
    public class Remove
    {
        [Test]
        public void Simple()
        {

            var bag = new ObservableBag<string> { "foo" };

            ObservableCollectionTester.ExpectEvents(bag, obj => obj.Remove("foo"), "Count", "Item[]", "IsEmpty");

        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionReentrancy()
        {
            var bag = new ObservableBag<string> { "foo", "bar" };
            new ReentracyTester<ObservableBag<string>>(bag, obj => obj.Remove("foo"), obj => obj.Remove("bar"));
        }
        [Test]
        public void Amount()
        {

            var bag = new ObservableBag<string> { { "foo", 2 } };

            ObservableCollectionTester.ExpectEvents(bag, obj => obj.Remove("foo", 1), "Count", "Item[]", "IsEmpty");

        }

    }


}