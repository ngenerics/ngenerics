/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.GeneralTreeTests
{
    [TestFixture]
    public class GetChild : GeneralTreeTest
    {

        [Test]
        public void Interface()
        {
            ITree<int> generalTree = GetTestTree();
            Assert.AreEqual(generalTree.GetChild(0).Data, 2);
            Assert.AreEqual(generalTree.GetChild(1).Data, 3);
            Assert.AreEqual(generalTree.GetChild(2).Data, 1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionInvalidSubTree()
        {
            var root = new GeneralTree<int>(5);

            var child1 = new GeneralTree<int>(2);
            var child2 = new GeneralTree<int>(3);

            root.Add(child1);
            root.Add(child2);

            root.GetChild(3);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionInvalidSubTreeNegative()
        {
            var root = new GeneralTree<int>(5);
            var child1 = new GeneralTree<int>(2);

            root.Add(child1);
            root.GetChild(-1);
        }

    }
}