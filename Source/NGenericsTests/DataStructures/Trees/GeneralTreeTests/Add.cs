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
    public class Add : GeneralTreeTest
    {

        [Test]
        public void Simple()
        {
            var root = new GeneralTree<int>(5);

            var child1 = new GeneralTree<int>(2);
            var child2 = new GeneralTree<int>(3);

            root.Add(child1);
            root.Add(child2);

            Assert.AreEqual(child1.Parent, root);
            Assert.AreEqual(child2.Parent, root);

            Assert.AreEqual(root.Count, 2);
            Assert.AreEqual(root.Degree, 2);

            Assert.AreEqual(root.GetChild(0), child1);
            Assert.AreEqual(root.GetChild(0).Data, child1.Data);

            Assert.AreEqual(root.GetChild(1).Data, child2.Data);
            Assert.AreEqual(root.GetChild(1), child2);

            root = new GeneralTree<int>(5)
                       {
                           2,
                           3
                       };

            Assert.AreEqual(root.GetChild(0).Data, child1.Data);
            Assert.AreEqual(root.GetChild(1).Data, child2.Data);

            Assert.AreEqual(root.GetChild(0).Parent, root);
            Assert.AreEqual(root.GetChild(1).Parent, root);

            var anotherRoot = new GeneralTree<int>(2);

            var movedChild = root.GetChild(0);
            anotherRoot.Add(movedChild);

            Assert.AreEqual(movedChild.Parent, anotherRoot);
            Assert.AreEqual(root.Degree, 1);
            Assert.AreEqual(root.GetChild(0).Parent, root);
        }

        [Test]
        public void Interface()
        {
            var root = new GeneralTree<int>(5);

            var child1 = new GeneralTree<int>(2);
            var child2 = new GeneralTree<int>(3);

            ((ITree<int>)root).Add(child1);
            ((ITree<int>)root).Add(child2);

            Assert.AreEqual(root.Count, 2);
            Assert.AreEqual(root.Degree, 2);

            Assert.AreEqual(root.GetChild(0), child1);
            Assert.AreEqual(root.GetChild(0).Data, child1.Data);

            Assert.AreEqual(root.GetChild(1).Data, child2.Data);
            Assert.AreEqual(root.GetChild(1), child2);
        }

    }
}