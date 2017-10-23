/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.GeneralTreeTests
{
    [TestFixture]
    public class Height : GeneralTreeTest
    {

        [Test]
        public void Simple()
        {
            var generalTree = new GeneralTree<int>(5);

            Assert.AreEqual(generalTree.Height, 0);

            var s1 = new GeneralTree<int>(3);

            generalTree.Add(s1);

            Assert.AreEqual(generalTree.Height, 1);

            s1.Add(new GeneralTree<int>(6));

            Assert.AreEqual(generalTree.Height, 2);
            generalTree.Add(new GeneralTree<int>(4));

            Assert.AreEqual(generalTree.Height, 2);

            generalTree = GetTestTree();

            Assert.AreEqual(generalTree.Height, 2);
        }

    }
}