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
    public class ObservableSortedListTest
    {


        [TestFixture]
        public class Contruction
        {

            [Test]
            public void Serialization()
            {
                var deserialize = SerializeUtil.BinarySerializeDeserialize(new ObservableSortedList<int>());
                ObservableCollectionTester.CheckMonitor(deserialize);
            }
            [Test]
            public void Monitor1()
            {
                ObservableCollectionTester.CheckMonitor(new ObservableSortedList<int>());
            }
            [Test]
            public void Monitor2()
            {
                ObservableCollectionTester.CheckMonitor(new ObservableSortedList<int>(Comparer<int>.Default));
            }
        }

        [TestFixture]
        public class Add
        {
            [Test]
            public void Simple()
            {
                var hashList = new ObservableSortedList<string>();
                ObservableCollectionTester.ExpectEvents(hashList, obj => obj.Add("foo"), "Count", "Item[]", "IsEmpty");
            }
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionSimpleReentrancy()
            {
                var hashList = new ObservableSortedList<string>();
                new ReentracyTester<ObservableSortedList<string>>(hashList, obj => obj.Add("foo"));
            }



        }


     

        [TestFixture]
        public class Clear
        {
            [Test]
            public void Simple()
            {
                var hashList = new ObservableSortedList<string>
                                   {
                                       "foo"
                                   };

                ObservableCollectionTester.ExpectEvents(hashList, obj => obj.Clear(), "Count", "Item[]", "IsEmpty");
            }
            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionReentrancy()
            {
                var hashList = new ObservableSortedList<string>
                                   {
                                       "foo"
                                   };
                new ReentracyTester<ObservableSortedList<string>>(hashList, obj => obj.Clear());
            }
        }

        [TestFixture]
        public class Remove
        {
            [Test]
            public void Simple()
            {
                var hashList = new ObservableSortedList<string>
                                   {
                                       "foo"
                                   };

                ObservableCollectionTester.ExpectEvents(hashList, obj => obj.Remove("foo"), "Count", "Item[]", "IsEmpty");
            }
            [Test]
            public void NotInList()
            {
                var hashList = new ObservableSortedList<string>();

                ObservableCollectionTester.ExpectNoEvents(hashList, obj => obj.Remove("foo"));
            }

            [Test]
            [ExpectedException(typeof(InvalidOperationException))]
            public void ExceptionSimpleReentrancy()
            {
                var hashList = new ObservableSortedList<string>
                                   {
                                       "foo",
                                       "bar"
                                   };
                new ReentracyTester<ObservableSortedList<string>>(hashList, obj => obj.Remove("foo"), obj => obj.Remove("bar"));
            }

           
         
        }




    }
}