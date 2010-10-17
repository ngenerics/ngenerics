/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.GeneralTreeTests
{
    [TestFixture]
    public class FindNode : GeneralTreeTest
    {

        [Test]
        public void Simple()
        {
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

            child1.Add(child4);
            child1.Add(child5);
            child2.Add(child6);

            Assert.AreEqual(root.FindNode(target => target == 13), child6);

            Assert.AreEqual(root.FindNode(target => target == 2), child1);

            Assert.AreEqual(root.FindNode(target => target == 9), child4);

            Assert.AreEqual(root.FindNode(target => target == 57), null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullCondition()
        {
            var tree = GetTestTree();
            tree.FindNode(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionInterfaceNullCondition()
        {
            var tree = GetTestTree();
            ((ITree<int>)tree).FindNode(null);
        }

        [Test]
        public void Interface()
        {
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

            child1.Add(child4);
            child1.Add(child5);
            child2.Add(child6);

            ITree<int> tree = root;
            Assert.AreEqual(tree.FindNode(target => target == 13), child6);

            Assert.AreEqual(tree.FindNode(target => target == 2), child1);

            Assert.AreEqual(tree.FindNode(target => target == 9), child4);

            Assert.AreEqual(tree.FindNode(target => target == 57), null);
        }

    }
}