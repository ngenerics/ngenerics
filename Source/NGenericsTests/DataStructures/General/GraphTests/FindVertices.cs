/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.GraphTests
{
    [TestFixture]
    public class FindVertices : GraphTest
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullPredicateDirected()
        {
            var graph = GetTestDirectedGraph();
            graph.FindVertices(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullPredicateUndirected()
        {
            var graph = GetTestUndirectedGraph();
            graph.FindVertices(null);
        }

        [Test]
        public void Directed()
        {
            var graph = GetTestDirectedGraph();

            var list = graph.FindVertices(value => value == 5 || value == 10);

            Assert.AreEqual(list.Count, 2);
            Assert.IsTrue(((list[0].Data == 5) || (list[0].Data == 10)));
            Assert.IsTrue(((list[1].Data == 5) || (list[1].Data == 10)));
            Assert.AreNotEqual(list[0].Data, list[1].Data);
        }

        [Test]
        public void Undirected()
        {
            var graph = GetTestUndirectedGraph();

            var list = graph.FindVertices(value => value == 5 || value == 10);

            Assert.AreEqual(list.Count, 2);
            Assert.IsTrue(((list[0].Data == 5) || (list[0].Data == 10)));
            Assert.IsTrue(((list[1].Data == 5) || (list[1].Data == 10)));
            Assert.AreNotEqual(list[0].Data, list[1].Data);
        }
    }
}