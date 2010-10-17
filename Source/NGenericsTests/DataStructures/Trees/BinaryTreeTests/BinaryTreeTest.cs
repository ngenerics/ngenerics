/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using NGenerics.DataStructures.Trees;

namespace NGenerics.Tests.DataStructures.Trees.BinaryTreeTests
{

    public class BinaryTreeTest
    {

        internal static BinaryTree<int> GetTestTree()
        {
            var rootBinaryTree = new BinaryTree<int>(5);

            var child1 = new BinaryTree<int>(2);
            var child2 = new BinaryTree<int>(3);

            rootBinaryTree.Add(child1);
            rootBinaryTree.Add(child2);

            var child4 = new BinaryTree<int>(9);
            var child5 = new BinaryTree<int>(12);
            var child6 = new BinaryTree<int>(13);

            child1.Add(child4);
            child1.Add(child5);
            child2.Add(child6);

            return rootBinaryTree;
        }

    }
}