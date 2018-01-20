/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.GraphTests
{
    [TestFixture]
    public class IsEmpty : GraphTest
    {
        [Test]
        public void Simple()
        {
            var graph = new Graph<int>(true);
            Assert.IsTrue(graph.IsEmpty);

            graph.AddVertex(5);
            Assert.IsFalse(graph.IsEmpty);

            graph.AddVertex(3);
            Assert.IsFalse(graph.IsEmpty);

            graph.Clear();
            Assert.IsTrue(graph.IsEmpty);
        }
    }
}