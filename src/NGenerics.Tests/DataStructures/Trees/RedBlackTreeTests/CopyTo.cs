/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.RedBlackTreeTests
{
    [TestFixture]
    public class CopyTo : RedBlackTreeTest
    {

        [Test]
        public void Simple()
        {
            var redBlackTree = GetTestTree(10);

            var array = new KeyValuePair<int, string>[10];
            redBlackTree.CopyTo(array, 0);

            var list = new List<KeyValuePair<int, string>>(array);

            for (var i = 0; i < 10; i++)
            {
                Assert.IsTrue(list.Contains(new KeyValuePair<int, string>(i, i.ToString())));
            }

            Assert.AreEqual(list.Count, 10);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullArray()
        {
            var redBlackTree = GetTestTree(10);
            redBlackTree.CopyTo(null, 1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionNotEnoughSpaceInTargetArray1()
        {
            var redBlackTree = GetTestTree(10);
            var array = new KeyValuePair<int, string>[9];
            redBlackTree.CopyTo(array, 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionNotEnoughSpaceInTargetArray2()
        {
            var redBlackTree = GetTestTree(10);
            var array = new KeyValuePair<int, string>[10];
            redBlackTree.CopyTo(array, 1);
        }

    }
}