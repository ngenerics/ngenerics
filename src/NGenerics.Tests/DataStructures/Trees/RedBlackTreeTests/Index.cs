/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System.Collections.Generic;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.RedBlackTreeTests
{
    [TestFixture]
    public class Index : RedBlackTreeTest
    {

        [Test]
        public void Simple()
        {
            var redBlackTree = GetTestTree(20);

            for (var i = 0; i < 20; i++)
            {
                Assert.AreEqual(redBlackTree[i], i.ToString());
            }

            redBlackTree[0] = "50";
            Assert.AreEqual(redBlackTree[0], "50");

            redBlackTree[1] = "-20";
            Assert.AreEqual(redBlackTree[1], "-20");
        }

        [Test]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void ExceptionInvalidIndexSet()
        {
            var redBlackTree = GetTestTree(20);
            redBlackTree[50] = "50";
        }

        [Test]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void ExceptionInvalidIndexGet()
        {
            var redBlackTree = GetTestTree(20);

            for (var i = 0; i < 20; i++)
            {
                Assert.AreEqual(redBlackTree[i], i.ToString());
            }

            var s = redBlackTree[20];
        }
    }
}