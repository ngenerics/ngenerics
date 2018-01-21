/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinaryTreeTests
{
    [TestFixture]
    public class Index : BinaryTreeTest
    {

        [Test]
        public void Simple()
        {
            var binaryTree = GetTestTree();

            Assert.AreEqual(binaryTree[0].Data, 2);
            Assert.AreEqual(binaryTree[1].Data, 3);
        }

        [Test]
        public void ExceptionBadIndexer()
        {
            var binaryTree = GetTestTree();
            int i;
            Assert.Throws<ArgumentOutOfRangeException>(() => i = binaryTree[2].Data);
        }
    }
}