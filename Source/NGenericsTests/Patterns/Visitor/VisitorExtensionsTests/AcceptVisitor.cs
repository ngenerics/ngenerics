/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Collections.Generic;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;
using Rhino.Mocks;

namespace NGenerics.Tests.Patterns.Visitor.VisitorExtensionsTests
{

    [TestFixture]
    public class AcceptVisitor
    {
        [Test]
        public void Simple()
        {
            var mocks = new MockRepository();
            var visitor = mocks.StrictMock<IVisitor<int>>();

            Expect.Call(visitor.HasCompleted).Return(false);
            visitor.Visit(1);

            Expect.Call(visitor.HasCompleted).Return(false);
            visitor.Visit(2);

            Expect.Call(visitor.HasCompleted).Return(false);
            visitor.Visit(3);

            Expect.Call(visitor.HasCompleted).Return(false);
            visitor.Visit(4);

            mocks.ReplayAll();

            var l = new List<int> { 1, 2, 3, 4 };
            l.AcceptVisitor(visitor);

            mocks.VerifyAll();
        }

        [Test]
        public void Stopping_Visitor()
        {
            var mocks = new MockRepository();
            var visitor = mocks.StrictMock<IVisitor<int>>();

            Expect.Call(visitor.HasCompleted).Return(false);
            visitor.Visit(1);

            Expect.Call(visitor.HasCompleted).Return(false);
            visitor.Visit(2);

            Expect.Call(visitor.HasCompleted).Return(true);

            mocks.ReplayAll();

            var l = new List<int> { 1, 2, 3, 4 };
            l.AcceptVisitor(visitor);

            mocks.VerifyAll();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Visitor()
        {
            var l = new List<int> { 1, 2, 3, 4 };
            l.AcceptVisitor(null);
        }
    }

}