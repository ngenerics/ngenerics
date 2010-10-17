/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinarySearchTreeTests
{
    [TestFixture]
    public class Minimum : BinarySearchTreeTest
    {

        [Test]
        public void Simple()
        {
            var tree = GetTestTree();
            var i = tree.Minimum;

            Assert.AreEqual(i.Key, 1);
            Assert.AreEqual(i.Value, "1");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionInvalidMin()
        {
            var tree = new BinarySearchTree<int, string>();
            var i = tree.Minimum;
        }

    }
}