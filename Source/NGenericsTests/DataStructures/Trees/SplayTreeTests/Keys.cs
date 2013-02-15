/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.SplayTreeTests
{
    [TestFixture]
    public class Keys : SplayTreeTest
    {

        [Test]
        public void Simple()
        {
            var splayTree = new SplayTree<int, string>();

            for (var i = 20; i > 10; i--)
            {
                splayTree.Add(i, i.ToString());
            }

            for (var i = 0; i <= 10; i++)
            {
                splayTree.Add(i, i.ToString());
            }

            var keys = splayTree.Keys;

            for (var i = 0; i <= 20; i++)
            {
                Assert.IsTrue(keys.Contains(i));
            }

            Assert.AreEqual(keys.Count, 21);
        }

    }
}