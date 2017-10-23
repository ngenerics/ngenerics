/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.RedBlackTreeTests
{
    [TestFixture]
    public class Clear : RedBlackTreeTest
    {

        [Test]
        public void Simple()
        {
            var redBlackTree = GetTestTree();
            redBlackTree.Clear();

            Assert.AreEqual(redBlackTree.Count, 0);
            Assert.IsFalse(redBlackTree.ContainsKey(40));
            Assert.IsFalse(redBlackTree.ContainsKey(41));
        }

    }
}