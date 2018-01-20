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
    public class Data : GeneralTreeTest
    {

        [Test]
        public void Simple()
        {
            var tree = new GeneralTree<int>(2);

            Assert.AreEqual(tree.Data, 2);

            tree.Data = 5;

            Assert.AreEqual(tree.Data, 5);
        }

        [Test]
        public void ExceptionSetNull()
        {
            var tree = new GeneralTree<string>("asdas");
            Assert.AreEqual(tree.Data, "asdas");
            Assert.Throws<ArgumentNullException>(() => tree.Data = null);
        }
    }
}