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
    public class Data:VertexTest
    {
        [Test]
        public void Simple()
        {
            var vertex = new Vertex<int>(5);
            Assert.AreEqual(vertex.Data, 5);

            vertex.Data = 2;
            Assert.AreEqual(vertex.Data, 2);

            vertex.Data = 10;
            Assert.AreEqual(vertex.Data, 10);
        }
    }
}