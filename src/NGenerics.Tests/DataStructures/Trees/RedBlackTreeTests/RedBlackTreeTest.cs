/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/



using NGenerics.DataStructures.Trees;

namespace NGenerics.Tests.DataStructures.Trees.RedBlackTreeTests
{


    public class RedBlackTreeTest
    {

        internal static RedBlackTree<int, string> GetTestTree()
        {
            var redBlackTree = new RedBlackTree<int, string>();

            for (var i = 0; i < 100; i++)
            {
                redBlackTree.Add(i, i.ToString());
            }

            return redBlackTree;
        }

        internal static RedBlackTree<int, string> GetTestTree(int noOfItems)
        {
            var redBlackTree = new RedBlackTree<int, string>();

            for (var i = 0; i < noOfItems; i++)
            {
                redBlackTree.Add(i, i.ToString());
            }

            return redBlackTree;
        }

    }

}