/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.GraphTests
{
    [TestFixture]
    public class GetEnumerator : GraphTest
    {
        [Test]
        public void Undirected()
        {
            TestEnumerator(GetTestUndirectedGraph());
        }

        [Test]
        public void Directed()
        {
            TestEnumerator(GetTestDirectedGraph());
        }

        [Test]
        public void Interface()
        {
            var graph = GetTestUndirectedGraph();
            var enumerator = ((IEnumerable)graph).GetEnumerator();

            var list = new List<int>();

            while (enumerator.MoveNext())
            {
                list.Add((int)enumerator.Current);
            }

            Assert.AreEqual(list.Count, 20);

            for (var i = 0; i < list.Count; i++)
            {
                Assert.IsTrue(list.Contains(i));
            }
        }
    }
}