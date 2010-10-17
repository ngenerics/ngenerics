/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinaryTreeTests
{
    [TestFixture]
    public class CopyTo : BinaryTreeTest
    {

        [Test]
        public void Simple()
        {
            var binaryTree = GetTestTree();

            var array = new int[6];

            binaryTree.CopyTo(array, 0);

            foreach (var t in array)
            {
                Assert.AreNotEqual(t, 0);
            }

            var list = new List<int>();
            list.AddRange(array);

            Assert.IsTrue(list.Contains(2));
            Assert.IsTrue(list.Contains(3));
            Assert.IsTrue(list.Contains(5));
            Assert.IsTrue(list.Contains(9));
            Assert.IsTrue(list.Contains(12));
            Assert.IsTrue(list.Contains(13));
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Exception1()
        {
            var binaryTree = GetTestTree();

            var array = new int[5];

            binaryTree.CopyTo(array, 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Exception2()
        {
            var binaryTree = GetTestTree();

            var array = new int[6];

            binaryTree.CopyTo(array, 1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullArray()
        {
            var binaryTree = GetTestTree();
            binaryTree.CopyTo(null, 1);
        }

    }
}