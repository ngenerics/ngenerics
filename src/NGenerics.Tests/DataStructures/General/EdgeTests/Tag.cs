/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.EdgeTests
{
    [TestFixture]
    public class Tag
    {
        [Test]
        public void Simple()
        {
            var edge = new Edge<int>(new Vertex<int>(5), new Vertex<int>(4), true);
            Assert.IsNull(edge.Tag);

            const string tag = "NGenerics";

            edge.Tag = tag;

            Assert.AreSame(edge.Tag, tag);
        }
    }
}