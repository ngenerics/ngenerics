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

namespace NGenerics.Tests.DataStructures.Trees.RedBlackTreeTests
{
    [TestFixture]
    public class Maximum : RedBlackTreeTest
    {
        [Test]
        public void Simple()
        {
            var redBlackTree = GetTestTree(20);
            Assert.AreEqual(redBlackTree.Maximum.Key, 19);
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionInvalidMax()
        {
            var redBlackTree = new RedBlackTree<int, string>();
            var i = redBlackTree.Maximum.Key;
        }
    }
}