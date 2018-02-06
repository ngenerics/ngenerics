/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System.Collections.Generic;
using System.Linq;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.GraphTests
{
    [TestFixture]
    public class FindCycles : GraphTest
    {
        [Test]
        public void NotCyclic()
        {
            var graph = new Graph<int>(true);
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);
            var vertex3 = graph.AddVertex(3);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex2, vertex3);

            var cycles = graph.FindCycles();

            Assert.AreEqual(0, cycles.Count, "There should not be any cycles");
        }

        [Test]
        public void SingleCycle()
        {
            var graph = new Graph<int>(true);
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);
            var vertex3 = graph.AddVertex(3);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex2, vertex3);
            graph.AddEdge(vertex3, vertex1);

            var cycles = graph.FindCycles();

            Assert.AreEqual(1, cycles.Count, "There is a single cycle");

            IList<Vertex<int>> cycle1 = cycles[0];
            Assert.IsTrue(cycle1.Any(v => v.Data == 1), "Vertex 1 missing from the cycle");
            Assert.IsTrue(cycle1.Any(v => v.Data == 2), "Vertex 2 missing from the cycle");
            Assert.IsTrue(cycle1.Any(v => v.Data == 3), "Vertex 3 missing from the cycle");
            Assert.AreEqual(3, cycle1.Count, "There should be three items in the cycle");
        }

        [Test]
        public void SingleCycleWithManyEdgesDirected()
        {
            var graph = new Graph<int>(true);
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);
            var vertex3 = graph.AddVertex(3);
            var vertex4 = graph.AddVertex(4);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex2, vertex3);
            graph.AddEdge(vertex3, vertex1);
            graph.AddEdge(vertex3, vertex4);
            graph.AddEdge(vertex4, vertex1);
            graph.AddEdge(vertex4, vertex2);


            var cycles = graph.FindCycles();

            Assert.AreEqual(1, cycles.Count, "There is a single cycle");

            IList<Vertex<int>> cycle1 = cycles[0];
            Assert.IsTrue(cycle1.Any(v => v.Data == 1), "Vertex 1 missing from the cycle");
            Assert.IsTrue(cycle1.Any(v => v.Data == 2), "Vertex 2 missing from the cycle");
            Assert.IsTrue(cycle1.Any(v => v.Data == 3), "Vertex 3 missing from the cycle");
            Assert.IsTrue(cycle1.Any(v => v.Data == 3), "Vertex 4 missing from the cycle");
            Assert.AreEqual(4, cycle1.Count, "There should be four items in the cycle");
        }

        [Test]
        public void SingleCycleWithManyEdgesUndirected()
        {
            var graph = new Graph<int>(false);
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);
            var vertex3 = graph.AddVertex(3);
            var vertex4 = graph.AddVertex(4);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex2, vertex3);
            graph.AddEdge(vertex3, vertex1);
            graph.AddEdge(vertex3, vertex4);
            graph.AddEdge(vertex4, vertex1);
            graph.AddEdge(vertex4, vertex2);


            var cycles = graph.FindCycles();

            Assert.AreEqual(1, cycles.Count, "There is a single cycle");

            IList<Vertex<int>> cycle1 = cycles[0];
            Assert.IsTrue(cycle1.Any(v => v.Data == 1), "Vertex 1 missing from the cycle");
            Assert.IsTrue(cycle1.Any(v => v.Data == 2), "Vertex 2 missing from the cycle");
            Assert.IsTrue(cycle1.Any(v => v.Data == 3), "Vertex 3 missing from the cycle");
            Assert.IsTrue(cycle1.Any(v => v.Data == 3), "Vertex 4 missing from the cycle");
            Assert.AreEqual(4, cycle1.Count, "There should be four items in the cycle");
        }

        [Test]
        public void MultipleCyclesDirected()
        {
            var graph = new Graph<int>(true);
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);
            var vertex3 = graph.AddVertex(3);
            var vertex4 = graph.AddVertex(4);
            var vertex5 = graph.AddVertex(5);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex2, vertex3);
            graph.AddEdge(vertex3, vertex1);

            graph.AddEdge(vertex4, vertex5);
            graph.AddEdge(vertex5, vertex4);


            var cycles = graph.FindCycles();

            Assert.AreEqual(2, cycles.Count, "There are two cycles");

            IList<Vertex<int>> cycle1 = cycles[0];
            IList<Vertex<int>> cycle2 = cycles[1];

            Assert.IsTrue(cycle1.Count == 3 && cycle2.Count == 2 || cycle1.Count == 2 && cycle2.Count == 3, "Wrong number of items in the cycles");

            var index = cycle1.Count == 3 ? 0 : 1;
            Assert.IsTrue(cycles[index].Any(v => v.Data == 1), "Vertex 1 missing from the cycle");
            Assert.IsTrue(cycles[index].Any(v => v.Data == 2), "Vertex 2 missing from the cycle");
            Assert.IsTrue(cycles[index].Any(v => v.Data == 3), "Vertex 3 missing from the cycle");

            index = cycle1.Count == 2 ? 0 : 1;
            Assert.IsTrue(cycles[index].Any(v => v.Data == 4), "Vertex 1 missing from the cycle");
            Assert.IsTrue(cycles[index].Any(v => v.Data == 5), "Vertex 2 missing from the cycle");
        }

        [Test]
        public void MultipleCyclesUndirected()
        {
            var graph = new Graph<int>(false);
            var vertex1 = graph.AddVertex(1);
            var vertex2 = graph.AddVertex(2);
            var vertex3 = graph.AddVertex(3);
            var vertex4 = graph.AddVertex(4);
            var vertex5 = graph.AddVertex(5);

            graph.AddEdge(vertex1, vertex2);
            graph.AddEdge(vertex2, vertex3);
            graph.AddEdge(vertex3, vertex1);

            graph.AddEdge(vertex4, vertex5);

            var cycles = graph.FindCycles();

            Assert.AreEqual(1, cycles.Count, "There are two cycles");

            IList<Vertex<int>> cycle1 = cycles[0];

            Assert.IsTrue((cycle1.Count == 3) || (cycle1.Count == 2), "Wrong number of items in the cycles");

            Assert.IsTrue(cycles[0].Any(v => v.Data == 1), "Vertex 1 missing from the cycle");
            Assert.IsTrue(cycles[0].Any(v => v.Data == 2), "Vertex 2 missing from the cycle");
            Assert.IsTrue(cycles[0].Any(v => v.Data == 3), "Vertex 3 missing from the cycle");
        }

        [Test]
        public void IncludeSingleItems()
        {
            var graph = new Graph<int>(true);
            graph.AddVertex(1);

            var cycles = graph.FindCycles(false);

            Assert.AreEqual(1, cycles.Count, "Wrong number of cycles");
            Assert.AreEqual(1, cycles[0].Length, "Wrong number of nodes in the cycle");
            Assert.AreEqual(1, cycles[0][0].Data, "Wrong number of nodes in the cycle");
        }

        [Test]
        public void ExcludeSingleItems()
        {
            var graph = new Graph<int>(true);
            graph.AddVertex(1);

            var cycles = graph.FindCycles();

            Assert.AreEqual(0, cycles.Count, "Wrong number of cycles");
        }
    }
}