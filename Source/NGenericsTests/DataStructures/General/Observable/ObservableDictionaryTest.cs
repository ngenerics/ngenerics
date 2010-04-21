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
    public class ObservableDictionaryTest
    {


        [TestFixture]
        public class Contruction
        {

            [Test]
            public void Serialization()
            {
				var deserialize = SerializeUtil.BinarySerializeDeserialize(new ObservableDictionary<int, int>());
                ObservableCollectionTester.CheckMonitor(deserialize);
            }
            [Test]
            public void Monitor1()
            {
				ObservableCollectionTester.CheckMonitor(new ObservableDictionary<int, int>());
            }
        
			[Test]
            public void Monitor2()
            {
				ObservableCollectionTester.CheckMonitor(new ObservableDictionary<int, int>(EqualityComparer<int>.Default));
            }
            [Test]
            public void Monitor3()
            {
				ObservableCollectionTester.CheckMonitor(new ObservableDictionary<int, int>(2));
            }
            [Test]
            public void Monitor4()
            {
				ObservableCollectionTester.CheckMonitor(new ObservableDictionary<int, int>(2, EqualityComparer<int>.Default));
            }
        }

        [TestFixture]
        public class Add
        {
            [Test]
            public void Simple()
            {
				var observableDictionary = new ObservableDictionary<string, string>();
                ObservableCollectionTester.ExpectEvents(observableDictionary, obj => obj.Add("foo","bar"), "Count", "Item[]", "IsEmpty", "ValueCount", "KeyCount");
            }
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionSimpleReentrancy()
            {
				var observableDictionary = new ObservableDictionary<string, string>();
				new ReentracyTester<ObservableDictionary<string, string>>(observableDictionary, obj => obj.Add("foo","bar"));
            }


            [Test]
            public void KeyValue()
            {
				var observableDictionary = new ObservableDictionary<string, string>();
                ObservableCollectionTester.ExpectEvents(observableDictionary, obj => obj.Add("foo", "Value"), "Count", "Item[]", "IsEmpty", "ValueCount", "KeyCount");
            }
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionKeyValueReentrancy()
            {
				var observableDictionary = new ObservableDictionary<string, string>();
				new ReentracyTester<ObservableDictionary<string, string>>(observableDictionary, obj => obj.Add("foo", "Value"));
            }
        }

        [TestFixture]
        public class Clear
        {
            [Test]
            public void Simple()
            {
				var observableDictionary = new ObservableDictionary<string, string>
                                   {
                                       {"foo", "Bar"}
                                   };

                ObservableCollectionTester.ExpectEvents(observableDictionary, obj => obj.Clear(), "Count", "Item[]", "IsEmpty", "ValueCount", "KeyCount");
            }
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionReentrancy()
            {
				var observableDictionary = new ObservableDictionary<string, string>
                                   {
                                       {"foo", "Bar"}
                                   };
				new ReentracyTester<ObservableDictionary<string, string>>(observableDictionary, obj => obj.Clear());
            }
        }

        [TestFixture]
        public class Remove
        {
            [Test]
            public void Simple()
            {
				var observableDictionary = new ObservableDictionary<string, string>
                                   {
                                       {"foo", "Bar"}
                                   };

                ObservableCollectionTester.ExpectEvents(observableDictionary, obj => obj.Remove("foo"), "Count", "Item[]", "IsEmpty", "ValueCount", "KeyCount");
            }
            [Test]
            public void NotInList()
            {
				var observableDictionary = new ObservableDictionary<string, string>();

                ObservableCollectionTester.ExpectNoEvents(observableDictionary, obj => obj.Remove("foo"));
            }

            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionSimpleReentrancy()
            {
				var observableDictionary = new ObservableDictionary<string, string>
                                   {
                                       {"foo","bar"},
                                       {"bar","foo"}
                                   };
				new ReentracyTester<ObservableDictionary<string, string>>(observableDictionary, obj => obj.Remove("foo"), obj => obj.Remove("bar"));
            }

      
        }


    }
}