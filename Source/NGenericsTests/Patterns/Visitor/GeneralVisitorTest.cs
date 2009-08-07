/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/

using System;
using System.Collections.Generic;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;
using Rhino.Mocks;

namespace NGenerics.Tests.Patterns.Visitor
{
    [TestFixture]
    public class GeneralVisitorTest
    {
        [TestFixture]
        public class Construction
        {
            [Test]
            public void Simple()
            {
                new GeneralVisitor<int>(
                    delegate {
                                 return false;
                    }
                    );
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullPredicate()
            {
                new GeneralVisitor<int>(null);
            }
        }

        [TestFixture]
        public class Visit
        {
            [Test]
            public void Simple()
            {
                var list = GetTestList();

                var mockRepository = new MockRepository();
                var trackingList = mockRepository.CreateMock<IList<int>>();
                                
                // All items should be visited...
                trackingList.Add(1);
                trackingList.Add(2);
                trackingList.Add(3);
                trackingList.Add(8);
                trackingList.Add(5);

                mockRepository.ReplayAll();

                var generalVisitor = new GeneralVisitor<int>(
                    delegate (int value) {
                                             trackingList.Add(value);
                                             return false;
                    }
                    );
                                
                list.AcceptVisitor(generalVisitor);

                mockRepository.VerifyAll();
            }

            [Test]
            public void StoppingVisitor()
            {
                var list = GetTestList();

                var mockRepository = new MockRepository();
                var trackingList = mockRepository.CreateMock<IList<int>>();
                
                // Only the first item should be visited.
                trackingList.Add(1);
                
                mockRepository.ReplayAll();

                var generalVisitor = new GeneralVisitor<int>(
                    delegate (int value) {
                                             trackingList.Add(value);
                                             return true;
                    }
                    );

                list.AcceptVisitor(generalVisitor);

                mockRepository.VerifyAll();
            }

            [Test]
            public void StoppedVisitor()
            {
                var visitableList = GetTestList();

                var mockRepository = new MockRepository();
                var trackingList = mockRepository.CreateMock<IList<int>>();
                                
                // No items should be visited.

                mockRepository.ReplayAll();

                var generalVisitor = new GeneralVisitor<int>(
                    delegate (int value) {
                                             trackingList.Add(value);
                                             return true;
                    }
                    ) {HasCompleted = true};

                visitableList.AcceptVisitor(generalVisitor);

                mockRepository.VerifyAll();
            }
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