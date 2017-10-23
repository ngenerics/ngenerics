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
    public class Parent : GeneralTreeTest
    {

        [Test]
        public void Set()
        {
            var root = new GeneralTree<int>(5) { 2, 3 };

            Assert.AreEqual(root.GetChild(0).Data, 2);
            Assert.AreEqual(root.GetChild(1).Data, 3);

            Assert.AreEqual(root.GetChild(0).Parent, root);
            Assert.AreEqual(root.GetChild(1).Parent, root);

            root.GetChild(0).Parent = root.GetChild(1);

            Assert.AreEqual(root.ChildNodes.Count, 1);
            Assert.AreEqual(root.GetChild(0).ChildNodes.Count, 1);
            Assert.AreEqual(root.GetChild(0).GetChild(0).Data, 2);
            Assert.AreEqual(root.GetChild(0).Data, 3);
            Assert.AreSame(root.GetChild(0).GetChild(0).Parent, root.GetChild(0));
            Assert.AreSame(root.GetChild(0).Parent, root);
        }

        [Test]
        public void Get()
        {
            var root = new GeneralTree<int>(5) { 2, 3 };


            root.GetChild(0).Parent = root.GetChild(1);

            Assert.AreSame(((ITree<int>)root.GetChild(0)).Parent, root);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionSetNull()
        {
            var root = new GeneralTree<int>(5) { 2, 3 };
            root.ChildNodes[0].Parent = null;
        }

    }
}