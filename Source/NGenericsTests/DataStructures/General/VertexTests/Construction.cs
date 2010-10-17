/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.VertexTests
{
    [TestFixture]
    public class Construction:VertexTest
    {
        [Test]
        public void Simple()
        {
            var vertex = new Vertex<int>(4);
            Assert.AreEqual(vertex.Data, 4);
            Assert.AreEqual(vertex.Degree, 0);
            Assert.AreEqual(vertex.IncidentEdges.Count, 0);
            Assert.AreEqual(vertex.Weight, 0);

            vertex = new Vertex<int>(999);
            Assert.AreEqual(vertex.Data, 999);
            Assert.AreEqual(vertex.Degree, 0);
            Assert.AreEqual(vertex.IncidentEdges.Count, 0);
            Assert.AreEqual(vertex.Weight, 0);

            vertex = new Vertex<int>(4, 6.2);
            Assert.AreEqual(vertex.Data, 4);
            Assert.AreEqual(vertex.Degree, 0);
            Assert.AreEqual(vertex.IncidentEdges.Count, 0);
            Assert.AreEqual(vertex.Weight, 6.2);

            vertex = new Vertex<int>(999, 32.45);
            Assert.AreEqual(vertex.Data, 999);
            Assert.AreEqual(vertex.Degree, 0);
            Assert.AreEqual(vertex.IncidentEdges.Count, 0);
            Assert.AreEqual(vertex.Weight, 32.45);

            vertex.Weight = 55;
            Assert.AreEqual(vertex.Weight, 55);
        }

    }
}