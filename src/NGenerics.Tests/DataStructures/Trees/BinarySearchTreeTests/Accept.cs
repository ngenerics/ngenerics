/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using System.Collections.Generic;
using NGenerics.DataStructures.Trees;
using NGenerics.Patterns.Visitor;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinarySearchTreeTests
{
    [TestFixture]
    public class Accept : BinarySearchTreeTest
    {

        [Test]
        public void Simple()
        {
            var tree = GetTestTree();
            var visitor = new TrackingVisitor<KeyValuePair<int, string>>();

            tree.AcceptVisitor(visitor);

            Assert.IsTrue(visitor.TrackingList.Contains(new KeyValuePair<int, string>(4, "4")));
            Assert.IsTrue(visitor.TrackingList.Contains(new KeyValuePair<int, string>(6, "6")));
            Assert.IsTrue(visitor.TrackingList.Contains(new KeyValuePair<int, string>(2, "2")));
            Assert.IsTrue(visitor.TrackingList.Contains(new KeyValuePair<int, string>(5, "5")));
            Assert.IsTrue(visitor.TrackingList.Contains(new KeyValuePair<int, string>(19, "19")));
            Assert.IsTrue(visitor.TrackingList.Contains(new KeyValuePair<int, string>(1, "1")));

            Assert.AreEqual(6, visitor.TrackingList.Count);
        }

        [Test]
        public void CompletedVisitor()
        {
            var tree = GetTestTree();
            var visitor = new CompletedTrackingVisitor<KeyValuePair<int, string>>();

            tree.AcceptVisitor(visitor);
        }

        [Test]
        public void ExceptionNullVisitor()
        {
            var tree = new BinarySearchTree<int, string>();
            Assert.Throws<ArgumentNullException>(() => tree.AcceptVisitor(null));
        }

    }
}