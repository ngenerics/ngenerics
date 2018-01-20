/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System.Collections.Generic;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;

namespace NGenerics.Tests.Patterns.Visitor.GeneralVisitorTests
{
    [TestFixture]
        public class Visit
        {
            [Test]
            public void Simple()
            {
                var list = GetTestList();

                var trackingList = new List<int>();
                                
                // All items should be visited...
                trackingList.Add(1);
                trackingList.Add(2);
                trackingList.Add(3);
                trackingList.Add(8);
                trackingList.Add(5);

                var generalVisitor = new GeneralVisitor<int>(
                    delegate (int value) {
                                             trackingList.Add(value);
                                             return false;
                    }
                    );
                                
                list.AcceptVisitor(generalVisitor);

                Assert.AreEqual(1, trackingList[0]);
                Assert.AreEqual(2, trackingList[1]);
                Assert.AreEqual(3, trackingList[2]);
                Assert.AreEqual(8, trackingList[3]);
                Assert.AreEqual(5, trackingList[4]);
            }

            [Test]
            public void StoppingVisitor()
            {
                var list = GetTestList();

                var trackingList = new List<int>();

                var generalVisitor = new GeneralVisitor<int>(
                    delegate (int value) {
                                             trackingList.Add(value);
                                             return true;
                    }
                    );

                list.AcceptVisitor(generalVisitor);
                Assert.AreEqual(1, trackingList.Count);
                Assert.AreEqual(1, trackingList[0]);
            }

            [Test]
            public void StoppedVisitor()
            {
                var visitableList = GetTestList();
                var trackingList = new List<int>();
                                
                // No items should be visited.
                var generalVisitor = new GeneralVisitor<int>(
                    delegate (int value) {
                                             trackingList.Add(value);
                                             return true;
                    }
                    ) {HasCompleted = true};

                visitableList.AcceptVisitor(generalVisitor);

                Assert.IsEmpty(trackingList);
            }
            #region Private Members

            private static List<int> GetTestList()
            {
                var list = new List<int>(new[] { 1, 2, 3, 8, 5 });

                return list;
            }

            #endregion
 
        }

 
}