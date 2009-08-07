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
    public class VisitorExtensionsTest
    {
        [TestFixture]
        public class AcceptVisitor
        {
            [Test]
            public void Simple()
            {
                var mocks = new MockRepository();
                var visitor = mocks.CreateMock<IVisitor<int>>();

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
                var visitor = mocks.CreateMock<IVisitor<int>>();

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
}