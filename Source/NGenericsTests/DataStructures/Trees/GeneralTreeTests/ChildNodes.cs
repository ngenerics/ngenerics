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
    public class ChildNodes : GeneralTreeTest
    {

        [Test]
        public void Simple()
        {
            var tree = new GeneralTree<int>(5);

            var originalNodes = new GeneralTree<int>[10];

            for (var i = 10; i < 20; i++)
            {
                originalNodes[i - 10] = new GeneralTree<int>(i);
                tree.Add(originalNodes[i - 10]);
            }

            var childNodes = tree.ChildNodes;

            Assert.AreEqual(childNodes.Count, 10);

            for (var i = 0; i < 10; i++)
            {
                Assert.IsTrue(childNodes.Contains(originalNodes[i]));
            }
        }

    }
}