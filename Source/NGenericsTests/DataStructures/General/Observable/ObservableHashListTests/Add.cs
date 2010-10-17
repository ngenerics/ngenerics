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

namespace NGenerics.Tests.DataStructures.General.Observable.ObservableHashListTests
{
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
}