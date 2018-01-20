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

namespace NGenerics.Tests.DataStructures.General.SkipListTests
{
    [TestFixture]
    public class Accept
    {

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullVisitor()
        {
            var skipList = new SkipList<int, string>();
            skipList.AcceptVisitor(null);
        }

        [Test]
        public void Simple()
        {
            var skipList = new SkipList<int, string>();

            for (var i = 0; i < 100; i++)
            {
                skipList.Add(i, i.ToString());
            }

            var visitor = new TrackingVisitor<KeyValuePair<int, string>>();

            skipList.AcceptVisitor(visitor);

            Assert.AreEqual(visitor.TrackingList.Count, 100);

            using (var enumerator = skipList.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Assert.IsTrue(visitor.TrackingList.Contains(enumerator.Current));
                }
            }
        }

        [Test]
        public void DoneVisitor()
        {
            var skipList = new SkipList<int, string>();

            for (var i = 0; i < 20; i++)
            {
                skipList.Add(i, i.ToString());
            }

            var completedTrackingVisitor = new CompletedTrackingVisitor<KeyValuePair<int, string>>();

            skipList.AcceptVisitor(completedTrackingVisitor);
        }

    }
}