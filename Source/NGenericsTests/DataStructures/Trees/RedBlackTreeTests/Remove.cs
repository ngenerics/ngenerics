/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.RedBlackTreeTests
{
    [TestFixture]
    public class Remove : RedBlackTreeTest
    {

        [Test]
        public void Small()
        {
            var redBlackTree = GetTestTree(5);

            for (var i = 0; i < 5; i++)
            {
                Assert.IsTrue(redBlackTree.Remove(i));
                Assert.AreEqual(redBlackTree.Count, 5 - i - 1);
                Assert.IsFalse(redBlackTree.ContainsKey(i));

                for (var j = i + 1; j < 5; j++)
                {
                    Assert.IsTrue(redBlackTree.ContainsKey(j));
                }
            }
        }

        [Test]
        public void Big()
        {
            var redBlackTree = GetTestTree();

            for (var i = 0; i < 100; i++)
            {
                Assert.IsTrue(redBlackTree.Remove(i));
                Assert.AreEqual(redBlackTree.Count, 100 - i - 1);
                Assert.IsFalse(redBlackTree.ContainsKey(i));

                for (var j = i + 1; j < 100; j++)
                {
                    Assert.IsTrue(redBlackTree.ContainsKey(j));
                }
            }
        }

        [Test]
        public void RemoveNotFound()
        {
            var redBlackTree = GetTestTree(20);

            for (var i = 20; i < 40; i++)
            {
                Assert.IsFalse(redBlackTree.Remove(i));
                Assert.AreEqual(redBlackTree.Count, 20);
            }
        }

    }
}