/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using System.Collections.Generic;
using NGenerics.Comparers;
using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinarySearchTreeTests
{
    [TestFixture]
    public class Construction : BinarySearchTreeTest
    {

        [Test]
        public void Simple()
        {
            var tree = new BinarySearchTree<int, string>();

            Assert.AreEqual(tree.Count, 0);
            Assert.IsTrue(tree.Comparer is KeyValuePairComparer<int, string>);

            tree = new BinarySearchTree<int, string>(new ReverseComparer<int>(Comparer<int>.Default));

            Assert.AreEqual(tree.Count, 0);
            Assert.IsTrue(tree.Comparer.GetType().IsAssignableFrom(typeof(KeyValuePairComparer<int, string>)));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullComparer()
        {
            new BinarySearchTree<int, string>((IComparer<int>)null);
        }

    }
}