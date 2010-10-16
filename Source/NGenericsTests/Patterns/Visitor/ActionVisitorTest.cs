/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Collections.Generic;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;
using Rhino.Mocks;

namespace NGenerics.Tests.Patterns.Visitor.ActionVisitorTest
{
    [TestFixture]
    public class Visit
    {
        [Test]
        public void ActionShouldBeCalledOnEveryObject()
        {
            var list = new List<int>
                           {
                               1, 2, -3
                           };

            var mockRepository = new MockRepository();

            // Just looking for an interface with a method that matches Action<T> - temporarily settled on list.
            var recorder = mockRepository.StrictMock<IList<int>>();
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