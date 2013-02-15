/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using System.Collections.Generic;
using NGenerics.DataStructures.Trees.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.ObservableBinarySearchTreeTests
{
    [TestFixture]
    public class Remove
    {
        [Test]
        public void Simple()
        {
            var binarySearchTree = new ObservableBinarySearchTree<string, string>
                                           {
                                               new KeyValuePair<string, string>("foo", "bar")
                                           };
            ObservableCollectionTester.ExpectEvents(binarySearchTree, obj => obj.Remove("foo"), "Count", "Item[]", "IsEmpty");
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionSimpleReentrancy()
        {
            var binarySearchTree = new ObservableBinarySearchTree<string, string>
                                           {
                                               new KeyValuePair<string, string>("foo", "bar")
                                           };
            new ReentracyTester<ObservableBinarySearchTree<string, string>>(binarySearchTree, obj => obj.Remove("foo"));
        }
        [Test]
        public void KeyValue()
        {
            var keyValuePair = new KeyValuePair<string, string>("foo", "bar");
            var binarySearchTree = new ObservableBinarySearchTree<string, string>
                                           {
                                               keyValuePair
                                           };
            ObservableCollectionTester.ExpectEvents(binarySearchTree, obj => obj.Remove(keyValuePair), "Count", "Item[]", "IsEmpty");
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionKeyValueReentrancy()
        {
            var keyValuePair = new KeyValuePair<string, string>("foo", "bar");
            var binarySearchTree = new ObservableBinarySearchTree<string, string>
                                           {
                                               keyValuePair
                                           };
            new ReentracyTester<ObservableBinarySearchTree<string, string>>(binarySearchTree, obj => obj.Remove(keyValuePair));
        }

    }

}