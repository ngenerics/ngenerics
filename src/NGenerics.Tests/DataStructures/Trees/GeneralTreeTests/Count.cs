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
    public class Count : GeneralTreeTest
    {

        [Test]
        public void Simple()
        {
            var generalTree = GetTestTree();

            Assert.AreEqual(generalTree.Count, 3);

            generalTree.Clear();
            Assert.AreEqual(generalTree.Count, 0);

            generalTree = new GeneralTree<int>(3);

            Assert.AreEqual(generalTree.Count, 0);
            Assert.AreEqual(generalTree.Degree, 0);

            generalTree = GetTestTree();

            Assert.AreEqual(generalTree.Count, 3);
            Assert.AreEqual(generalTree.Degree, 3);
        }

    }
}