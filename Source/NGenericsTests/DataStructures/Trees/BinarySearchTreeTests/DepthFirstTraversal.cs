/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System.Collections.Generic;
using NGenerics.DataStructures.Trees;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinarySearchTreeTests
{
    [TestFixture]
    public class DepthFirstTraversal : BinarySearchTreeTest
    {

        [Test]
        public void Simple()
        {
            var tree = new BinarySearchTree<string, int>
                           {
                               new KeyValuePair<string, int>("horse", 4),
                               new KeyValuePair<string, int>("cat", 1),
                               new KeyValuePair<string, int>("dog", 2),
                               new KeyValuePair<string, int>("canary", 3)
                           };

            var visitor = new TrackingVisitor<KeyValuePair<string, int>>();

            var inOrderVisitor =
                new InOrderVisitor<KeyValuePair<string, int>>(visitor);

            tree.DepthFirstTraversal(inOrderVisitor);

            Assert.AreEqual(visitor.TrackingList[0].Key, "canary");
            Assert.AreEqual(visitor.TrackingList[1].Key, "cat");
            Assert.AreEqual(visitor.TrackingList[2].Key, "dog");
            Assert.AreEqual(visitor.TrackingList[3].Key, "horse");
        }

    }
}