/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System.Collections.Generic;
using NGenerics.DataStructures.Graphs;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.VertexTests
{
  
    public class VertexTest
    {   

        internal static void AssertContainsEdges(ICollection<Edge<int>> edgeList, bool containsValue, params Edge<int>[] edges)
        {
            foreach (var edge in edges)
            {
                Assert.AreEqual(edgeList.Contains(edge), containsValue);
            }
        }

    }
}
