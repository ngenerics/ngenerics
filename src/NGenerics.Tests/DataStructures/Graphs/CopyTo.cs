/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NGenerics.DataStructures.Graphs;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Graphs
{
    [TestFixture]
    public class CopyTo : GraphTest
    {
        [Test]
        public void Undirected()
        {
            TestCopyTo(GetTestUndirectedGraph());
        }

        [Test]
        public void Directed()
        {
            TestCopyTo(GetTestDirectedGraph());
        }


        [Test]
        public void ExceptionNullArrayDirected()
        {
            var graph = new Graph<int>(true);
            Assert.Throws<ArgumentNullException>(() => graph.CopyTo(null, 0));
        }

        [Test]
        public void ExceptionNullArrayUndirected()
        {
            var graph = new Graph<int>(false);
            Assert.Throws<ArgumentNullException>(() => graph.CopyTo(null, 0));
        }

        [Test]
        public void ExceptionDirectedInvalid1()
        {
            var graph = GetTestDirectedGraph();
            var array = new int[20];
            Assert.Throws<ArgumentException>(() => graph.CopyTo(array, 1));
        }

        [Test]
        public void ExceptionUndirectedInvalid1()
        {
            var graph = GetTestUndirectedGraph();
            var array = new int[20];
            Assert.Throws<ArgumentException>(() => graph.CopyTo(array, 1));
        }

        [Test]
        public void ExceptionUndirectedInvalid2()
        {
            var graph = GetTestUndirectedGraph();
            var array = new int[19];
            Assert.Throws<ArgumentException>(() => graph.CopyTo(array, 0));
        }

        [Test]
        public void ExceptionDirectedInvalid2()
        {
            var graph = GetTestDirectedGraph();
            var array = new int[19];
            Assert.Throws<ArgumentException>(() => graph.CopyTo(array, 0));
        }
    }
}