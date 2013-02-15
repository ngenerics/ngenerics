/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.GraphTests
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
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullArrayDirected()
        {
            var graph = new Graph<int>(true);
            graph.CopyTo(null, 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullArrayUndirected()
        {
            var graph = new Graph<int>(false);
            graph.CopyTo(null, 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionDirectedInvalid1()
        {
            var graph = GetTestDirectedGraph();

            var array = new int[20];
            graph.CopyTo(array, 1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionUndirectedInvalid1()
        {
            var graph = GetTestUndirectedGraph();

            var array = new int[20];
            graph.CopyTo(array, 1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionUndirectedInvalid2()
        {
            var graph = GetTestUndirectedGraph();

            var array = new int[19];
            graph.CopyTo(array, 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionDirectedInvalid2()
        {
            var graph = GetTestDirectedGraph();
            var array = new int[19];
            graph.CopyTo(array, 0);
        }
    }
}