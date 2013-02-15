/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using NGenerics.DataStructures.General.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.Observable.ObservableHashListTests
{
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

            ObservableCollectionTester.ExpectEvents(hashList, obj => obj.Remove("foo", "bar"), "Count", "Item[]", "IsEmpty", "ValueCount", "KeyCount");
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
}