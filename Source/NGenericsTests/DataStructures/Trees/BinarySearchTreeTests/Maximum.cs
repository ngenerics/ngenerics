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
    public class Maximum : BinarySearchTreeTest
    {

        [Test]
        public void Simple()
        {
            var tree = GetTestTree();
            var i = tree.Maximum;

            Assert.AreEqual(i.Key, 19);
            Assert.AreEqual(i.Value, "19");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionInvalidMax()
        {
            var tree = new BinarySearchTree<int, string>();
            var i = tree.Maximum;
        }

    }
}