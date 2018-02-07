/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Graphs
{
    [TestFixture]
    public class FindVertices : GraphTest
    {
        [Test]
        public void ExceptionNullPredicateDirected()
        {
            var graph = GetTestDirectedGraph();
            Assert.Throws<ArgumentNullException>(() => graph.FindVertices(null));
        }

        [Test]
        public void ExceptionNullPredicateUndirected()
        {
            var graph = GetTestUndirectedGraph();
            Assert.Throws<ArgumentNullException>(() => graph.FindVertices(null));
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