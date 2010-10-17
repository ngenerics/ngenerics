/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.GraphTests
{
    [TestFixture]
    public class Count : GraphTest
    {
        [Test]
        public void Directed()
        {
            var graph = new Graph<int>(true);
            ICollection<int> visitableCollection = graph;

            for (var i = 0; i < 20; i++)
            {
                var vertex = new Vertex<int>(i);
                graph.AddVertex(vertex);

                Assert.AreEqual(visitableCollection.Count, i * 2 + 1);

                graph.AddVertex(i);

                Assert.AreEqual(visitableCollection.Count, i * 2 + 2);
            }
        }

        [Test]
        public void Undirected()
        {
            var graph = new Graph<int>(false);
            ICollection<int> c = graph;

            for (var i = 0; i < 20; i++)
            {
                var vertex = new Vertex<int>(i);
                graph.AddVertex(vertex);

                Assert.AreEqual(c.Count, i * 2 + 1);

                graph.AddVertex(i);

                Assert.AreEqual(c.Count, i * 2 + 2);
            }
        }
    }
}