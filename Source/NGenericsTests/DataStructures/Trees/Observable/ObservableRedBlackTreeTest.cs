/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using System.Collections.Generic;
using NGenerics.DataStructures.Trees.Observable;
using NGenerics.Tests.TestObjects;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.Observable
{
    [TestFixture]
    public class ObservableRedBlackTreeTest
    {

        [TestFixture]
        public class Contruction
        {

            [Test]
            public void Serialization()
            {
                var deserialize = SerializeUtil.BinarySerializeDeserialize(new ObservableRedBlackTree<int, int>());
                ObservableCollectionTester.CheckMonitor(deserialize);
            }
            [Test]
            public void Monitor1()
            {
                ObservableCollectionTester.CheckMonitor(new ObservableRedBlackTree<int, int>());
            }

            [Test]
            public void Monitor2()
            {
                ObservableCollectionTester.CheckMonitor(new ObservableRedBlackTree<int, int>(Comparer<int>.Default));
            }
        }
        [TestFixture]
        public class Add
        {
            [Test]
            public void Simple()
            {
                var redBlackTree = new ObservableRedBlackTree<string, string>();
                ObservableCollectionTester.ExpectEvents(redBlackTree, obj => obj.Add("foo", "bar"), "Count", "Item[]", "IsEmpty");
            }
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionSimpleReentrancy()
            {
                var redBlackTree = new ObservableRedBlackTree<string, string>();
                new ReentracyTester<ObservableRedBlackTree<string, string>>(redBlackTree, obj => obj.Add("foo", "bar"));
            }

            [Test]
            public void KeyValue()
            {
                var redBlackTree = new ObservableRedBlackTree<string, string>();
                var keyValuePair = new KeyValuePair<string, string>("foo", "bar");
                ObservableCollectionTester.ExpectEvents(redBlackTree, obj => obj.Add(keyValuePair), "Count", "Item[]", "IsEmpty");
            }

            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionKeyValueReentrancy()
            {
                var redBlackTree = new ObservableRedBlackTree<string, string>();
                var keyValuePair = new KeyValuePair<string, string>("foo", "bar");
                new ReentracyTester<ObservableRedBlackTree<string, string>>(redBlackTree, obj => obj.Add(keyValuePair));
            }
        }

        [TestFixture]
        public class Clear
        {
            [Test]
            public void Simple()
            {
                var redBlackTree = new ObservableRedBlackTree<string, string>
                                       {
                                           new KeyValuePair<string, string>("foo", "bar")
                                       };
                ObservableCollectionTester.ExpectEvents(redBlackTree, obj => obj.Clear(), "Count", "Item[]", "IsEmpty");
            }
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionReentrancy()
            {
                var redBlackTree = new ObservableRedBlackTree<string, string>();
                new ReentracyTester<ObservableRedBlackTree<string, string>>(redBlackTree, obj => obj.Clear());
            }

        }

        [TestFixture]
        public class Remove
        {
            [Test]
            public void Simple()
            {
                var redBlackTree = new ObservableRedBlackTree<string, string>
                                       {
                                           new KeyValuePair<string, string>("foo", "bar")
                                       };
                ObservableCollectionTester.ExpectEvents(redBlackTree, obj => obj.Remove("foo"), "Count", "Item[]", "IsEmpty");
            }
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionSimpleReentrancy()
            {
                var redBlackTree = new ObservableRedBlackTree<string, string>
                                       {
                                           new KeyValuePair<string, string>("foo", "bar")
                                       };
                new ReentracyTester<ObservableRedBlackTree<string, string>>(redBlackTree, obj => obj.Remove("foo"));
            }
            [Test]
            public void KeyValue()
            {
                var keyValuePair = new KeyValuePair<string, string>("foo", "bar");
                var redBlackTree = new ObservableRedBlackTree<string, string>
                                       {
                                           keyValuePair
                                       };
                ObservableCollectionTester.ExpectEvents(redBlackTree, obj => obj.Remove(keyValuePair), "Count", "Item[]", "IsEmpty");
            }
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionKeyValueReentrancy()
            {
                var keyValuePair = new KeyValuePair<string, string>("foo", "bar");
                var redBlackTree = new ObservableRedBlackTree<string, string>
                                       {
                                           keyValuePair
                                       };
                new ReentracyTester<ObservableRedBlackTree<string, string>>(redBlackTree, obj => obj.Remove(keyValuePair));
            }

        }

    }
}