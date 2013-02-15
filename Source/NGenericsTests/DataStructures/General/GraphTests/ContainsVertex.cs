/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.GraphTests
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