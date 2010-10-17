/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using NGenerics.DataStructures.Trees.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.ObservableBinaryTreeTests
{
    [TestFixture]
    public class Clear
    {
        [Test]
        public void Simple()
        {
            var binaryTree = new ObservableBinaryTree<string>("root")
                                 {
                                     "foo"
                                 };
            ObservableCollectionTester.ExpectEvents(binaryTree, obj => obj.Clear(), "Count", "Item[]", "IsEmpty");
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionSimpleReentrancy()
        {
            var binaryTree = new ObservableBinaryTree<string>("root");
            new ReentracyTester<ObservableBinaryTree<string>>(binaryTree, obj => obj.Add("foo"));
        }
    }
}