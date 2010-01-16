/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using NGenerics.Comparers;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.Comparers
{
    [TestFixture]
    public class EdgeWeightComparerTest
    {
        [TestFixture]
        public class Construction
        {
            [Test]
            public void Simple()
            {
                new EdgeWeightComparer<int>();
            }
        }

        [TestFixture]
        public class Compare
        {
            [Test]
			public void Simple()
            {
                var comparer = new EdgeWeightComparer<int>();

                var vertex1 = new Vertex<int>(5);
                var vertex2 = new Vertex<int>(6);

                var edge1 = new Edge<int>(vertex1, vertex2, 12, true);
                var edge2 = new Edge<int>(vertex1, vertex2, 12.2, false);
                var edge3 = new Edge<int>(vertex1, vertex2, -4, true);
                var edge4 = new Edge<int>(vertex1, vertex2, 12, true);

                Assert.AreEqual(comparer.Compare(edge1, edge2), -1);
                Assert.AreEqual(comparer.Compare(edge1, edge3), 1);
                Assert.AreEqual(comparer.Compare(edge1, edge4), 0);

                Assert.AreEqual(comparer.Compare(edge2, edge1), 1);
                Assert.AreEqual(comparer.Compare(edge3, edge1), -1);
                Assert.AreEqual(comparer.Compare(edge4, edge1), 0);
            }

        }
    }
}
