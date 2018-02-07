/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.DataStructures.Graphs;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Graphs
{
    [TestFixture]
    public class Construction : GraphTest
    {
        [Test]
        public void Simple()
        {
            var graph = new Graph<int>(false);

            Assert.AreEqual(0, graph.Vertices.Count);
            Assert.AreEqual(0, graph.Edges.Count);
            Assert.IsFalse(graph.IsDirected);

            graph = new Graph<int>(true);

            Assert.AreEqual(0, graph.Vertices.Count);
            Assert.AreEqual(0, graph.Edges.Count);
            Assert.IsTrue(graph.IsDirected);
        }
    }
}