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
    public class Values : RedBlackTreeTest
    {

        [Test]
        public void Simple()
        {
            var redBlackTree = GetTestTree(20);
            var values = redBlackTree.Values;

            Assert.AreEqual(values.Count, 20);

            var counter = 0;

            using (var enumerator = values.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Assert.AreEqual(enumerator.Current, counter.ToString());
                    counter++;
                }
            }

            redBlackTree = new RedBlackTree<int, string>();
            values = redBlackTree.Values;

            Assert.IsNotNull(values);
            Assert.AreEqual(values.Count, 0);
        }

    }
}