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
    public class RemoveRight
    {
        [Test]
        public void Simple()
        {
            var rootBinaryTree = new ObservableBinaryTree<string>("root")
                                         {
                                             "foo",
                                             "bar"
                                         };
            ObservableCollectionTester.ExpectEvents(rootBinaryTree, obj => obj.RemoveRight(), "Count", "Item[]", "IsEmpty");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionSimpleReentrancy()
        {
            var rootBinaryTree = new ObservableBinaryTree<string>("root")
                                         {
                                             "foo",
                                             "bar"
                                         };
            new ReentracyTester<ObservableBinaryTree<string>>(rootBinaryTree, obj => obj.RemoveRight());
        }
    }


}