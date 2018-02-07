/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/


using Moq;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;

namespace NGenerics.Tests.Patterns.Visitor.OrderedVisitorTests
{
    [TestFixture]
    public class Visit
    {
        [Test]
        public void InnerVisitorShouldBeCalledOnEachVisi_Method()
        {
            var innerVisitor = new Mock<IVisitor<int>>();
            var orderedVisitor = new OrderedVisitor<int>(innerVisitor.Object);


            orderedVisitor.Visit(1);
            orderedVisitor.VisitInOrder(0);
            orderedVisitor.VisitPostOrder(-3);
            orderedVisitor.VisitPreOrder(5);

            innerVisitor.Verify(x => x.Visit(1));
            innerVisitor.Verify(x => x.Visit(0));
            innerVisitor.Verify(x => x.Visit(-3));
            innerVisitor.Verify(x => x.Visit(5));
        }
    }
}