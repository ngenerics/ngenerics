/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;
using Rhino.Mocks;

namespace NGenerics.Tests.Patterns.Visitor
{
    [TestFixture]
    public class OrderedVisitorTest
    {
        [TestFixture]
        public class Construction
        {
            [Test]
            public void Simple()
            {
                var visitor = new TrackingVisitor<int>();
                var orderedVisitor = new OrderedVisitor<int>(visitor);

                Assert.IsFalse(orderedVisitor.HasCompleted);
                Assert.AreSame(orderedVisitor.VisitorToUse, visitor);
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullVisitor()
            {
                new OrderedVisitor<int>(null);
            }
        }

        [TestFixture]
        public class Visit
        {
            [Test]
            public void InnerVisitorShouldBeCalledOnEachVisi_Method()
            {
                var mockRepository = new MockRepository();
                var innerVisitor = mockRepository.StrictMock<IVisitor<int>>();

                var orderedVisitor = new OrderedVisitor<int>(innerVisitor);

                innerVisitor.Visit(1);
                innerVisitor.Visit(0);
                innerVisitor.Visit(-3);
                innerVisitor.Visit(5);

                mockRepository.ReplayAll();

                orderedVisitor.Visit(1);
                orderedVisitor.VisitInOrder(0);
                orderedVisitor.VisitPostOrder(-3);
                orderedVisitor.VisitPreOrder(5);

                mockRepository.VerifyAll();
            }
        }
    }
}