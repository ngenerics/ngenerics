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