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

namespace NGenerics.Tests.DataStructures.Trees.SplayTreeTests
{
    [TestFixture]
    public class Maximum : SplayTreeTest
    {

        [Test]
        public void Simple()
        {
            var splayTree = GetTestTree();
            var i = splayTree.Maximum;

            Assert.AreEqual(i.Key, 19);
            Assert.AreEqual(i.Value, "19");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionEmpty()
        {
            var splayTree = new SplayTree<int, string>();
            var i = splayTree.Maximum;
        }

    }
}