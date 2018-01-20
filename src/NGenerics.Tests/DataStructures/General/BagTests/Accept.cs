/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NGenerics.Patterns.Visitor;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.BagTests
{
    [TestFixture]
    public class Accept : BagTest
    {

        [Test]
        public void Simple()
        {
            var bag = new Bag<string> { "5", "4", "3", "2" };

            var visitor = new TrackingVisitor<string>();
            bag.AcceptVisitor<string>(visitor);

            Assert.AreEqual(visitor.TrackingList.Count, 4);
            Assert.IsTrue(visitor.TrackingList.Contains("5"));
            Assert.IsTrue(visitor.TrackingList.Contains("4"));
            Assert.IsTrue(visitor.TrackingList.Contains("3"));
            Assert.IsTrue(visitor.TrackingList.Contains("2"));
        }

        [Test]
        public void CompletedVisitor1()
        {
            var bag = new Bag<string> { "5", "4", "3", "2" };

            var visitor = new CompletedTrackingVisitor<KeyValuePair<string, int>>();
            bag.AcceptVisitor<KeyValuePair<string, int>>(visitor);
        }

        [Test]
        public void CompletedVisitor2()
        {
            var bag = new Bag<string> { "5", "4", "3", "2" };

            var visitor = new CompletedTrackingVisitor<string>();
            bag.AcceptVisitor<string>(visitor);
        }

        [Test]
        public void Simple2()
        {
            var bag = new Bag<string> { "5", "4", "3", "2" };

            var visitor = new TrackingVisitor<KeyValuePair<string, int>>();
            bag.AcceptVisitor<KeyValuePair<string, int>>(visitor);

            Assert.AreEqual(visitor.TrackingList.Count, 4);
            Assert.IsTrue(visitor.TrackingList.Contains(new KeyValuePair<string, int>("5", 1)));
            Assert.IsTrue(visitor.TrackingList.Contains(new KeyValuePair<string, int>("4", 1)));
            Assert.IsTrue(visitor.TrackingList.Contains(new KeyValuePair<string, int>("3", 1)));
            Assert.IsTrue(visitor.TrackingList.Contains(new KeyValuePair<string, int>("2", 1)));
        }

        [Test]
        public void ExceptionNullVisitor1()
        {
            var bag = new Bag<string>();
            Assert.Throws<ArgumentNullException>(() => bag.AcceptVisitor<string>(null));
        }



        [Test]
        public void ExceptionInvalid1()
        {
            var bag = new Bag<string>();
            Assert.Throws<ArgumentNullException>(() => bag.AcceptVisitor<string>(null));
        }



    }
}