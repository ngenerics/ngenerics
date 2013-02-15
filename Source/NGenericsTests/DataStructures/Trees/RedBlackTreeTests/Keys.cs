/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.RedBlackTreeTests
{
    [TestFixture]
    public class Keys : RedBlackTreeTest
    {

        [Test]
        public void Simple()
        {
            var redBlackTree = GetTestTree(20);
            var keys = redBlackTree.Keys;

            Assert.AreEqual(keys.Count, 20);

            var counter = 0;

            using (var enumerator = keys.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Assert.AreEqual(enumerator.Current, counter);
                    counter++;
                }
            }

            redBlackTree = new RedBlackTree<int, string>();
            keys = redBlackTree.Keys;

            Assert.IsNotNull(keys);
            Assert.AreEqual(keys.Count, 0);
        }

    }
}