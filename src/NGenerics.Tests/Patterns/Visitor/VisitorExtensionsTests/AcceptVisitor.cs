/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/


namespace NGenerics.Tests.Patterns.Visitor.VisitorExtensionsTests
{
    using System;
    using System.Collections.Generic;
    using Moq;
    using NGenerics.Patterns.Visitor;
    using NUnit.Framework;

    [TestFixture]
    public class AcceptVisitor
    {
        [Test]
        public void Simple()
        {
            var visitor = new Mock<IVisitor<int>>();

            visitor.Setup(x => x.HasCompleted).Returns(false);

            var l = new List<int> { 1, 2, 3, 4 };
            l.AcceptVisitor(visitor.Object);
            visitor.Verify(x => x.Visit(1));
            visitor.Verify(x => x.Visit(2));
            visitor.Verify(x => x.Visit(3));
            visitor.Verify(x => x.Visit(4));
        }

        [Test]
        public void Null_Visitor()
        {
            var l = new List<int> { 1, 2, 3, 4 };
            Assert.Throws<ArgumentNullException>(() => l.AcceptVisitor(null));
        }
    }

}