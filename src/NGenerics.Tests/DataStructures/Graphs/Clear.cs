/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Graphs
{
    [TestFixture]
    public class Clear : GraphTest
    {
        [Test]
        public void Simple()
        {
            var graph = GetTestUndirectedGraph();
            graph.Clear();

            Assert.AreEqual(graph.Vertices.Count, 0);
            Assert.AreEqual(graph.Vertices.Count, 0);
            Assert.AreEqual(graph.Edges.Count, 0);
        }
    }
}