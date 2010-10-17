/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.RedBlackTreeTests
{
    [TestFixture]
    public class TryGetValue : RedBlackTreeTest
    {

        [Test]
        public void Simple()
        {
            var redBlackTree = new RedBlackTree<int, string>();

            string value;

            for (var i = 0; i < 100; i++)
            {
                redBlackTree.Add(i, i.ToString());

                Assert.AreEqual(redBlackTree.Count, i + 1);
                Assert.IsTrue(redBlackTree.TryGetValue(i, out value));
                Assert.AreEqual(value, i.ToString());
            }


            Assert.IsFalse(redBlackTree.TryGetValue(101, out value));
            Assert.IsNull(value);

            Assert.IsFalse(redBlackTree.TryGetValue(102, out value));
            Assert.IsNull(value);
        }

    }
}