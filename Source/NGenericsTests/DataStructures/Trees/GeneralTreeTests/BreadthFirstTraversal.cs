/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.Patterns.Visitor;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.GeneralTreeTests
{
    [TestFixture]
    public class BreadthFirstTraversal : GeneralTreeTest
    {
        [Test]
        public void Simple()
        {
            var generalTree = GetTestTree();
            var trackingVisitor = new TrackingVisitor<int>();

            generalTree.BreadthFirstTraversal(trackingVisitor);

            var tracks = trackingVisitor.TrackingList;

            Assert.AreEqual(tracks[0], 5);
            Assert.AreEqual(tracks[1], 2);
            Assert.AreEqual(tracks[2], 3);
            Assert.AreEqual(tracks[3], 1);
            Assert.AreEqual(tracks[4], 9);
            Assert.AreEqual(tracks[5], 12);
            Assert.AreEqual(tracks[6], 13);
        }

    }
}