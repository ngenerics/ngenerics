/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinaryTreeTests
{
    [TestFixture]
    public class RemoveRight : BinaryTreeTest
    {

        [Test]
        public void Simple()
        {
            var binaryTree = GetTestTree();

            binaryTree.RemoveRight();

            Assert.IsNull(binaryTree.Right);
            Assert.IsNotNull(binaryTree.Left);
        }

    }
}