/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.GeneralTreeTests
{
    [TestFixture]
    public class Contains : GeneralTreeTest
    {

        [Test]
        public void Simple()
        {
            var generalTree = GetTestTree();
            Assert.IsTrue(generalTree.Contains(5));
            Assert.IsTrue(generalTree.Contains(2));
            Assert.IsTrue(generalTree.Contains(3));
            Assert.IsTrue(generalTree.Contains(1));
            Assert.IsTrue(generalTree.Contains(9));
            Assert.IsTrue(generalTree.Contains(12));
            Assert.IsTrue(generalTree.Contains(13));
            Assert.IsFalse(generalTree.Contains(4));
        }

    }
}