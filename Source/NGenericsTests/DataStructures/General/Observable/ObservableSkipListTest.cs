/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using System.Collections.Generic;
using NGenerics.DataStructures.General.Observable;
using NGenerics.Tests.TestObjects;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.Observable
{
    [TestFixture]
    public class ObservableSkipListTest
    {

        [TestFixture]
        public class Contruction
        {

            [Test]
            public void Serialization()
            {
                var deserialize = SerializeUtil.BinarySerializeDeserialize(new ObservableSkipList<int, int>());
                ObservableCollectionTester.CheckMonitor(deserialize);
            }

            [Test]
            public void Monitor1()
            {
                ObservableCollectionTester.CheckMonitor(new ObservableSkipList<int, int>());
            }
            [Test]
            public void Monitor2()
            {
                ObservableCollectionTester.CheckMonitor(new ObservableSkipList<int, int>(Comparer<int>.Default));
            }
            [Test]
            public void Monitor3()
            {
                ObservableCollectionTester.CheckMonitor(new ObservableSkipList<int, int>(2, .4, Comparer<int>.Default));
            }
        }


        [TestFixture]
        public class Add
        {
            [Test]
            public void Simple()
            {
                var skipList = new ObservableSkipList<string, string>();
                ObservableCollectionTester.ExpectEvents(skipList, obj => obj.Add("foo", "bar"), "Count", "CurrentListLevel", "IsEmpty", "Values");
            }
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionSimpleReentrancy()
            {
                var skipList = new ObservableSkipList<string, string>();
                new ReentracyTester<ObservableSkipList<string, string>>(skipList, obj => obj.Add("foo", "bar"));
            }
            [Test]
            public void KeyValuePair()
            {
                var skipList = new ObservableSkipList<string, string>();
                var keyValuePair = new KeyValuePair<string, string>("foo", "bar");
                ObservableCollectionTester.ExpectEvents(skipList, obj => obj.Add(keyValuePair), "Count", "CurrentListLevel", "IsEmpty", "Values");
            }
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionKeyValuePairReentrancy()
            {
                var skipList = new ObservableSkipList<string, string>();
                var keyValuePair = new KeyValuePair<string, string>("foo", "bar");
                new ReentracyTester<ObservableSkipList<string, string>>(skipList, obj => obj.Add(keyValuePair));
            }

        }

        [TestFixture]
        public class Clear
        {
            [Test]
            public void Simple()
            {

                var skipList = new ObservableSkipList<string, string> { new KeyValuePair<string, string>("foo", "bar") };

                ObservableCollectionTester.ExpectEvents(skipList, obj => obj.Clear(), "Count", "CurrentListLevel", "IsEmpty", "Values");
            }
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionReentrancy()
            {
                var skipList = new ObservableSkipList<string, string> { new KeyValuePair<string, string>("foo", "bar") };
                new ReentracyTester<ObservableSkipList<string, string>>(skipList, obj => obj.Clear());
            }
        }

        [TestFixture]
        public class Remove
        {
            [Test]
            public void Simple()
            {
                var skipList = new ObservableSkipList<string, string> { new KeyValuePair<string, string>("foo", "bar") };

                ObservableCollectionTester.ExpectEvents(skipList, obj => obj.Remove("foo"), "Count", "CurrentListLevel", "IsEmpty", "Values");
            }
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionSimpleReentrancy()
            {
                var skipList = new ObservableSkipList<string, string> { new KeyValuePair<string, string>("foo", "bar") };
                new ReentracyTester<ObservableSkipList<string, string>>(skipList, obj => obj.Remove("foo"));
            }
            [Test]
            public void KeyValue()
            {
                var keyValuePair = new KeyValuePair<string, string>("foo", "bar");
                var skipList = new ObservableSkipList<string, string> { keyValuePair };

                ObservableCollectionTester.ExpectEvents(skipList, obj => obj.Remove(keyValuePair), "Count", "CurrentListLevel", "IsEmpty", "Values");
            }
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionKeyValueReentrancy()
            {
                var keyValuePair = new KeyValuePair<string, string>("foo", "bar");
                var skipList = new ObservableSkipList<string, string> { keyValuePair };
                new ReentracyTester<ObservableSkipList<string, string>>(skipList, obj => obj.Remove(keyValuePair));
            }

            [Test]
            public void NotInList()
            {
                var skipList = new ObservableSkipList<string, string>();

                ObservableCollectionTester.ExpectNoEvents(skipList, obj => obj.Remove("foo"));
            }
        }

    }
}