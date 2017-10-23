/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using System.Collections.Generic;
using NGenerics.DataStructures.Trees;
using NGenerics.Sorting;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.GeneralTreeTests
{
    [TestFixture]
    public class SortAllDescendants : GeneralTreeTest
    {

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullSorter1()
        {
            var tree = GetTestTree();
            tree.SortAllDescendants(null, (x, y) => x.Data.CompareTo(y.Data));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullSorter2()
        {
            var tree = GetTestTree();
            tree.SortAllDescendants(null, new GeneralTreeComparer<int>());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullComparison()
        {
            var tree = GetTestTree();
            tree.SortAllDescendants(null, (Comparison<GeneralTree<int>>)null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullComparer()
        {
            var tree = GetTestTree();
            tree.SortAllDescendants(null, (IComparer<GeneralTree<int>>)null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullSorter3()
        {
            var tree = GetTestTree();

            tree.SortAllDescendants(null, (x, y) => x.Data.CompareTo(y.Data));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullSorter4()
        {
            var tree = GetTestTree();

            tree.SortAllDescendants(null, new GeneralTreeComparer<int>());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullComparison2()
        {
            var tree = GetTestTree();
            tree.SortAllDescendants(new InsertionSorter<GeneralTree<int>>(), (Comparison<GeneralTree<int>>)null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullComparer2()
        {
            var tree = GetTestTree();

            tree.SortAllDescendants(new InsertionSorter<GeneralTree<int>>(), (IComparer<GeneralTree<int>>)null);
        }

        [Test]
        public void RecursiveSort1()
        {
            var tree = GetMixedTestTree();

            tree.SortAllDescendants(new InsertionSorter<GeneralTree<int>>(), (x, y) => x.Data.CompareTo(y.Data));

            Assert.AreEqual(tree.ChildNodes[0].Data, 1);
            Assert.AreEqual(tree.ChildNodes[1].Data, 2);
            Assert.AreEqual(tree.ChildNodes[2].Data, 3);

            Assert.AreEqual(tree[1].ChildNodes[0].Data, 11);
            Assert.AreEqual(tree[1].ChildNodes[1].Data, 15);

            Assert.AreEqual(tree[2].ChildNodes[0].Data, 13);
        }

        [Test]
        public void RecursiveSort2()
        {
            var tree = GetMixedTestTree();

            tree.SortAllDescendants(new InsertionSorter<GeneralTree<int>>(), new GeneralTreeComparer<int>());

            Assert.AreEqual(tree.ChildNodes[0].Data, 1);
            Assert.AreEqual(tree.ChildNodes[1].Data, 2);
            Assert.AreEqual(tree.ChildNodes[2].Data, 3);

            Assert.AreEqual(tree[1].ChildNodes[0].Data, 11);
            Assert.AreEqual(tree[1].ChildNodes[1].Data, 15);

            Assert.AreEqual(tree[2].ChildNodes[0].Data, 13);
        }
    }
}