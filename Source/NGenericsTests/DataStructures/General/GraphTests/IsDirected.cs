/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.GraphTests
{
    [TestFixture]
    public class IsDirected : GraphTest
    {
        [Test]
        public void Simple()
        {
            var graph = new Graph<int>(true);
            Assert.IsTrue(graph.IsDirected);

            graph = new Graph<int>(false);
            Assert.IsFalse(graph.IsDirected);
        }
    }
}