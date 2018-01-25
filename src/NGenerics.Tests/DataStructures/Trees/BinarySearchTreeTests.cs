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
using NGenerics.Tests.DataStructures.Trees.BinarySearchTreeTests;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees
{
    [TestFixture]
    public class BinarySearchTreeTestsCollection : BinarySearchTreeTest
    {
        [Test]
        public void Clear_Removes_Items_From_Tree()
        {
            var tree = new BinarySearchTree<int, string>();
            tree.Clear();

            Assert.AreEqual(0, tree.Count);

            tree = GetTestTree();
            Assert.IsTrue(tree.ContainsKey(19));

            tree.Clear();
            Assert.AreEqual(0, tree.Count);
            Assert.IsFalse(tree.ContainsKey(19));
        }

        [Test]
        public void DepthFirstTraversal_Simple()
        {

            var visitor = new TrackingVisitor<KeyValuePair<string, int>>();
            var inOrderVisitor = new InOrderVisitor<KeyValuePair<string, int>>(visitor);

            var tree = new BinarySearchTree<string, int>
                           {
                               new KeyValuePair<string, int>("horse", 4),
                               new KeyValuePair<string, int>("cat", 1),
                               new KeyValuePair<string, int>("dog", 2),
                               new KeyValuePair<string, int>("canary", 3)
                           }; 

            tree.DepthFirstTraversal(inOrderVisitor);

            Assert.AreEqual("canary", visitor.TrackingList[0].Key);
            Assert.AreEqual("cat", visitor.TrackingList[1].Key);
            Assert.AreEqual("dog", visitor.TrackingList[2].Key);
            Assert.AreEqual("horse", visitor.TrackingList[3].Key);
        }

        [Test]
        public void DepthFirstTraversal_Stops_After_Visitor_Completes()
        {
            var visitor = new InOrderVisitor<KeyValuePair<int, string>>(
                new StoppingVisitor<KeyValuePair<int, string>>());

            GetTestTree().DepthFirstTraversal(visitor);
        }
    }
}
