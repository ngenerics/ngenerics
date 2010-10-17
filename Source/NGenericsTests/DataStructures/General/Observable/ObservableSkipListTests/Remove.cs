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
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.Observable.ObservableSkipListTests
{
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