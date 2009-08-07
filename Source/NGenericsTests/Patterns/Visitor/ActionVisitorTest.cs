/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/

using System.Collections.Generic;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;
using Rhino.Mocks;

namespace NGenerics.Tests.Patterns.Visitor
{
    [TestFixture]
    public class ActionVisitorTest
    {
        [TestFixture]
        public class Visit
        {
            [Test]
            public void ActionShouldBeCalledOnEveryObject()
            {
                var list = new List<int>();

                list.Add(1);
                list.Add(2);
                list.Add(-3);

                var mockRepository = new MockRepository();

                // Just looking for an interface with a method that matches Action<T> - temporarily settled on list.
                var recorder = mockRepository.CreateMock<IList<int>>();
                recorder.Add(1);
                recorder.Add(2);
                recorder.Add(-3);

                mockRepository.ReplayAll();

                var visitor = new ActionVisitor<int>(recorder.Add);
                list.AcceptVisitor(visitor);

                mockRepository.VerifyAll();
            }
        }
    }
}