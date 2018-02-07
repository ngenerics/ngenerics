/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.DataStructures.Graphs;
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
            Assert.AreEqual(4, vertex.Data);
            Assert.AreEqual(0, vertex.Degree);
            Assert.AreEqual(0, vertex.IncidentEdges.Count);
            Assert.AreEqual(0, vertex.Weight);

            vertex = new Vertex<int>(999);
            Assert.AreEqual(999, vertex.Data);
            Assert.AreEqual(0, vertex.Degree);
            Assert.AreEqual(0, vertex.IncidentEdges.Count);
            Assert.AreEqual(0, vertex.Weight);

            vertex = new Vertex<int>(4, 6.2);
            Assert.AreEqual(4, vertex.Data);
            Assert.AreEqual(0, vertex.Degree);
            Assert.AreEqual(0, vertex.IncidentEdges.Count);
            Assert.AreEqual(6.2, vertex.Weight);

            vertex = new Vertex<int>(999, 32.45);
            Assert.AreEqual(999, vertex.Data);
            Assert.AreEqual(0, vertex.Degree);
            Assert.AreEqual(0, vertex.IncidentEdges.Count);
            Assert.AreEqual(32.45, vertex.Weight);

            vertex.Weight = 55;
            Assert.AreEqual(55, vertex.Weight);
        }
    }
}