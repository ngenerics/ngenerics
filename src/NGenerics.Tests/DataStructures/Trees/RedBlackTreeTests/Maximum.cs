/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
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
        public void ExceptionInvalidMax()
        {
            var redBlackTree = new RedBlackTree<int, string>();
            int value;
            Assert.Throws<InvalidOperationException>(() => value = redBlackTree.Maximum.Key);
        }
    }
}