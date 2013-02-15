/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using NGenerics.DataStructures.Trees;

namespace NGenerics.Tests.DataStructures.Trees.GeneralTreeTests
{

    public class GeneralTreeTest
    {

        internal static GeneralTree<int> GetTestTree()
        {
            var root = new GeneralTree<int>(5);

            var child1 = new GeneralTree<int>(2);
            var child2 = new GeneralTree<int>(3);
            var child3 = new GeneralTree<int>(1);

            root.Add(child1);
            root.Add(child2);
            root.Add(child3);

            var child4 = new GeneralTree<int>(9);
            var child5 = new GeneralTree<int>(12);
            var child6 = new GeneralTree<int>(13);

            child1.Add(child4);
            child1.Add(child5);
            child2.Add(child6);

            return root;
        }

        internal static GeneralTree<int> GetMixedTestTree()
        {
            var root = new GeneralTree<int>(5);

            var child1 = new GeneralTree<int>(2);
            var child2 = new GeneralTree<int>(3);
            var child3 = new GeneralTree<int>(1);

            root.Add(child1);
            root.Add(child2);
            root.Add(child3);

            var child4 = new GeneralTree<int>(15);
            var child5 = new GeneralTree<int>(11);
            var child6 = new GeneralTree<int>(13);

            child1.Add(child4);
            child1.Add(child5);
            child2.Add(child6);

            return root;
        }

    }

}


