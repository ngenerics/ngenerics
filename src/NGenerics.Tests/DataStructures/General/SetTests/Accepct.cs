/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NGenerics.DataStructures.General;
using NGenerics.Patterns.Visitor;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SetTests
{
    [TestFixture]
    public class Accepct
    {

        [Test]
        public void Simple()
        {
            var pascalSet = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });

            var trackingVisitor = new TrackingVisitor<int>();

            pascalSet.AcceptVisitor(trackingVisitor);

            Assert.AreEqual(trackingVisitor.TrackingList.Count, 5);
            Assert.IsTrue(trackingVisitor.TrackingList.Contains(15));
            Assert.IsTrue(trackingVisitor.TrackingList.Contains(20));
            Assert.IsTrue(trackingVisitor.TrackingList.Contains(30));
            Assert.IsTrue(trackingVisitor.TrackingList.Contains(40));
            Assert.IsTrue(trackingVisitor.TrackingList.Contains(34));
        }

        [Test]
        public void CompletedVisitor()
        {
            var pascalSet = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });

            var completedTrackingVisitor = new CompletedTrackingVisitor<int>();

            pascalSet.AcceptVisitor(completedTrackingVisitor);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVisitor()
        {
            var pascalSet = new PascalSet(10);
            pascalSet.AcceptVisitor(null);
        }

    }
}