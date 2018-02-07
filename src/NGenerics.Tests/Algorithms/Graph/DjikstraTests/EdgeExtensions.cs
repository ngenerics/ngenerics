/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.DataStructures.Graphs;
using NUnit.Framework;

namespace NGenerics.Tests.Algorithms.Graph.DjikstraTests
{
    public static class EdgeExtensions
    {
        public static void AssertWeights<T>(this Edge<T> edge, double edgeWeight, double fromVertexWeight, double toVertexWeight)
        {
            Assert.AreEqual(edgeWeight, edge.Weight);
            Assert.AreEqual(fromVertexWeight, edge.FromVertex.Weight);
            Assert.AreEqual(toVertexWeight, edge.ToVertex.Weight);
        }
    }
}
