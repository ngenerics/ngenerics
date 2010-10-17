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
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.ObservableSplayTreeTests
{
    [TestFixture]
    public class Add
    {
        [Test]
        public void Simple()
        {
            var splayTree = new ObservableSplayTree<string, string>();
            ObservableCollectionTester.ExpectEvents(splayTree, obj => obj.Add("foo", "bar"), "Count", "Item[]", "IsEmpty");
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionSimpleReentrancy()
        {
            var splayTree = new ObservableSplayTree<string, string>();
            new ReentracyTester<ObservableSplayTree<string, string>>(splayTree, obj => obj.Add("foo", "bar"));
        }
        [Test]
        public void KeyValue()
        {
            var splayTree = new ObservableSplayTree<string, string>();
            var keyValuePair = new KeyValuePair<string, string>("foo", "bar");
            ObservableCollectionTester.ExpectEvents(splayTree, obj => obj.Add(keyValuePair), "Count", "Item[]", "IsEmpty");
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionKeyValueReentrancy()
        {
            var splayTree = new ObservableSplayTree<string, string>();
            var keyValuePair = new KeyValuePair<string, string>("foo", "bar");
            new ReentracyTester<ObservableSplayTree<string, string>>(splayTree, obj => obj.Add(keyValuePair));
        }

    }
}