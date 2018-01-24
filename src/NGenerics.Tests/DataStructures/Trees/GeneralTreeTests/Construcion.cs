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
    public class Construcion : GeneralTreeTest
    {

        [Test]
        public void Simple()
        {
            var generalTree = new GeneralTree<int>(5);

            Assert.AreEqual(0, generalTree.Count);
            Assert.AreEqual(0, generalTree.Degree);
            Assert.AreEqual(0, generalTree.Height);
            Assert.IsTrue(generalTree.IsLeafNode);
            Assert.IsNull(generalTree.Parent);
        }

        [Test]
        public void ExceptionNullData()
        {
            Assert.Throws<ArgumentNullException>(() => new GeneralTree<string>(null));
        }

    }
}