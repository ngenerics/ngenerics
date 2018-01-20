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

namespace NGenerics.Tests.Patterns.Visitor.ActionVisitorTests
{
    [TestFixture]
    public class Visit
    {
        [Test]
        public void ActionShouldBeCalledOnEveryObject()
        {
            var list = new List<int> { 1, 2, -3 };


            var recorded = new List<int>();
            var visitor = new ActionVisitor<int>(x => recorded.Add(x));
            list.AcceptVisitor(visitor);

            Assert.Contains(1, recorded);
            Assert.Contains(2, recorded);
            Assert.Contains(-3, recorded);
        }
    }

}