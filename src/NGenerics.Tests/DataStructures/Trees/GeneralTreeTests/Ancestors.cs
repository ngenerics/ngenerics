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
    public class Ancestors : GeneralTreeTest
    {
        [Test]
        public void Simple()
        {
            var tree = GetTestTree();
            var ancestors = tree.GetChild(0).GetChild(0).Ancestors;

            Assert.AreEqual(ancestors.Count, 2);
            Assert.AreEqual(ancestors[1], tree.GetChild(0));
            Assert.AreEqual(ancestors[0], tree);

            var root = new GeneralTree<int>(5);

            var child1 = new GeneralTree<int>(2);
            var child2 = new GeneralTree<int>(3);
            var child3 = new GeneralTree<int>(1);

            root.Add(child1);
            root.Add(child2);
            root.Add(child3);

            var child4 = new GeneralTree<int>(9);
            var child5 = new GeneralTree<int>(12);
            var child6 = new GeneralTree<int>(13);
            var child7 = new GeneralTree<int>(15);

            child1.Add(child4);
            child1.Add(child5);
            child2.Add(child6);

            child4.Add(child7);

            ancestors = child7.Ancestors;

            Assert.AreEqual(ancestors.Count, 3);

            Assert.AreEqual(ancestors[0], root);
            Assert.AreEqual(ancestors[1], child1);
            Assert.AreEqual(ancestors[2], child4);
        }
    }
}