/*  
  Copyright 2007-2010 The NGenerics Team
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
    public class ObservableHashListTest
    {


        [TestFixture]
        public class Contruction
        {

            [Test]
            public void Serialization()
            {
                var deserialize = SerializeUtil.BinarySerializeDeserialize(new ObservableHashList<int, int>());
                ObservableCollectionTester.CheckMonitor(deserialize);
            }
            [Test]
            public void Monitor1()
            {
                ObservableCollectionTester.CheckMonitor(new ObservableHashList<int,int>());
            }
            [Test]
            public void Monitor2()
            {
                var capacity = new Dictionary<int,IList<int>>();
                ObservableCollectionTester.CheckMonitor(new ObservableHashList<int,int>(capacity));
            }

            [Test]
            public void Monitor3()
            {
                ObservableCollectionTester.CheckMonitor(new ObservableHashList<int, int>(EqualityComparer<int>.Default));
            }
            [Test]
            public void Monitor4()
            {
                ObservableCollectionTester.CheckMonitor(new ObservableHashList<int, int>(2));
            }
            [Test]
            public void Monitor5()
            {
                ObservableCollectionTester.CheckMonitor(new ObservableHashList<int, int>(2, EqualityComparer<int>.Default));
            }
        }

        [TestFixture]
        public class Add
        {
            [Test]
            public void Simple()
            {
                var hashList = new ObservableHashList<string, string>();
                ObservableCollectionTester.ExpectEvents(hashList, obj => obj.Add("foo"), "Count", "Item[]", "IsEmpty", "ValueCount", "KeyCount");
            }
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionSimpleReentrancy()
            {
                var hashList = new ObservableHashList<string, string>();
                new ReentracyTester<ObservableHashList<string, string>>(hashList, obj => obj.Add("foo"));
            }


            [Test]
            public void List()
            {
                var hashList = new ObservableHashList<string, string>();
                IList<string> list = new List<string> { "Value1", "Value2" };
                ObservableCollectionTester.ExpectEvents(hashList, obj => obj.Add("foo", list), "Count", "Item[]", "IsEmpty", "ValueCount", "KeyCount");
            }
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionListReentrancy()
            {
                var hashList = new ObservableHashList<string, string>();
                IList<string> list = new List<string> { "Value1", "Value2" };
                new ReentracyTester<ObservableHashList<string, string>>(hashList, obj => obj.Add("foo", list));
            }

            [Test]
            public void Params()
            {
                var hashList = new ObservableHashList<string, string>();
                ObservableCollectionTester.ExpectEvents(hashList, obj => obj.Add("foo", "Value1", "Value2"), "Count", "Item[]", "IsEmpty", "ValueCount", "KeyCount");
            }
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionParamsReentrancy()
            {
                var hashList = new ObservableHashList<string, string>();
                new ReentracyTester<ObservableHashList<string, string>>(hashList, obj => obj.Add("foo", "Value1", "Value2"));
            }
            [Test]
            public void KeyValue()
            {
                var hashList = new ObservableHashList<string, string>();
                ObservableCollectionTester.ExpectEvents(hashList, obj => obj.Add("foo", "Value"), "Count", "Item[]", "IsEmpty", "ValueCount", "KeyCount");
            }
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionKeyValueReentrancy()
            {
                var hashList = new ObservableHashList<string, string>();
                new ReentracyTester<ObservableHashList<string, string>>(hashList, obj => obj.Add("foo", "Value"));
            }
        }


        [TestFixture]
        public class AddItem
        {


            [Test]
            public void KeyValue()
            {
                var hashList = new ObservableHashList<string, string>();
                ObservableCollectionTester.ExpectEvents(hashList, obj => obj.AddItem(new KeyValuePair<string, string>("foo", "foo")), "Count", "Item[]", "IsEmpty", "ValueCount", "KeyCount");
            }

            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionReentrancy()
            {
                var hashList = new ObservableHashList<string, string>();
                new ReentracyTester<ObservableHashList<string, string>>(hashList, obj => obj.AddItem(new KeyValuePair<string, string>("foo", "foo")));
            }

        }

        [TestFixture]
        public class Clear
        {
            [Test]
            public void Simple()
            {
                var hashList = new ObservableHashList<string, string>
                                   {
                                       "foo"
                                   };

                ObservableCollectionTester.ExpectEvents(hashList, obj => obj.Clear(), "Count", "Item[]", "IsEmpty", "ValueCount", "KeyCount");
            }
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionReentrancy()
            {
                var hashList = new ObservableHashList<string, string>
                                   {
                                       "foo"
                                   };
                new ReentracyTester<ObservableHashList<string, string>>(hashList, obj => obj.Clear());
            }
        }

        [TestFixture]
        public class Remove
        {
            [Test]
            public void Simple()
            {
                var hashList = new ObservableHashList<string, string>
                                   {
                                       "foo"
                                   };

                ObservableCollectionTester.ExpectEvents(hashList, obj => obj.Remove("foo"), "Count", "Item[]", "IsEmpty", "ValueCount", "KeyCount");
            }
            [Test]
            public void NotInList()
            {
                var hashList = new ObservableHashList<string, string>();

                ObservableCollectionTester.ExpectNoEvents(hashList, obj => obj.Remove("foo"));
            }

            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionSimpleReentrancy()
            {
                var hashList = new ObservableHashList<string, string>
                                   {
                                       "foo",
                                       "bar"
                                   };
                new ReentracyTester<ObservableHashList<string, string>>(hashList, obj => obj.Remove("foo"), obj => obj.Remove("bar"));
            }

            [Test]
            public void KeyValue()
            {
                var hashList = new ObservableHashList<string, string>
                                   {
                                       {"foo", "bar"}
                                   };

                ObservableCollectionTester.ExpectEvents(hashList, obj => obj.Remove("foo","bar"), "Count", "Item[]", "IsEmpty", "ValueCount", "KeyCount");
            }
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionKeyValueReentrancy()
            {
                var hashList = new ObservableHashList<string, string>
                                   {
                                       {"foo1", "bar1"},
                                       {"foo2", "bar2"}
                                   };
                new ReentracyTester<ObservableHashList<string, string>>(hashList, obj => obj.Remove("foo1", "bar1"), obj => obj.Remove("foo2", "bar2"));
            }
        }

        [TestFixture]
        public class RemoveAll
        {
            [Test]
            public void Simple()
            {
                var hashList = new ObservableHashList<string, string> {"foo"};

                ObservableCollectionTester.ExpectEvents(hashList, obj => obj.RemoveAll("foo"), "Count", "Item[]", "IsEmpty", "ValueCount", "KeyCount");
            }

            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionReentrancy()
            {
                var hashList = new ObservableHashList<string, string> { "foo" };
                new ReentracyTester<ObservableHashList<string, string>>(hashList, obj => obj.RemoveAll("foo"));
            }
        }

        [TestFixture]
        public class RemoveValue
        {
            [Test]
            public void Simple()
            {
                var hashList = new ObservableHashList<string, string> {{"foo","bar"}};

                ObservableCollectionTester.ExpectEvents(hashList, obj => obj.RemoveValue("bar"), "Count", "Item[]", "IsEmpty", "ValueCount", "KeyCount");
            }

            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionReentrancy()
            {
                var hashList = new ObservableHashList<string, string>();
                new ReentracyTester<ObservableHashList<string, string>>(hashList, obj => obj.AddItem(new KeyValuePair<string, string>("foo", "foo")));
            }
        }

    }
}