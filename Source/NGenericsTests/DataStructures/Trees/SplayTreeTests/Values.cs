/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.SplayTreeTests
{
    [TestFixture]
    public class Values : SplayTreeTest
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

            var values = splayTree.Values;

            for (var i = 0; i <= 20; i++)
            {
                Assert.IsTrue(values.Contains(i.ToString()));
            }

            Assert.AreEqual(values.Count, 21);
        }

    }
}