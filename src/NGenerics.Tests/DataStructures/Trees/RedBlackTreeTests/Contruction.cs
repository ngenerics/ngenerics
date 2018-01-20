/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using System.Collections.Generic;
using NGenerics.Comparers;
using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.RedBlackTreeTests
{
    [TestFixture]
    public class Contruction : RedBlackTreeTest
    {

        [Test]
        public void Simple()
        {
            var redBlackTree = new RedBlackTree<int, string>();
            Assert.AreEqual(redBlackTree.Count, 0);
            Assert.IsTrue(redBlackTree.Comparer is KeyValuePairComparer<int, string>);

            redBlackTree = new RedBlackTree<int, string>(new ReverseComparer<int>());
            Assert.AreEqual(redBlackTree.Count, 0);
            Assert.IsTrue(redBlackTree.Comparer.GetType().IsAssignableFrom(typeof(KeyValuePairComparer<int, string>)));
        }

        [Test]
        public void ExceptionNullComparer()
        {
            Assert.Throws<ArgumentNullException>(() => new RedBlackTree<int, string>((IComparer<int>) null));
        }

    }
}