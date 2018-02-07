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
    public class ContainsVertex : GraphTest
    {
        [Test]
        public void Simple()
        {
            var graph = new Graph<int>(false);

            for (var i = 0; i < 20; i++)
            {
                var vertex = new Vertex<int>(i);
                graph.AddVertex(vertex);

                Assert.IsTrue(graph.ContainsVertex(i));
                Assert.IsTrue(graph.ContainsVertex(vertex));
            }

            Assert.IsFalse(graph.ContainsVertex(new Vertex<int>(3)));
            Assert.IsFalse(graph.ContainsVertex(21));
        }
    }
}