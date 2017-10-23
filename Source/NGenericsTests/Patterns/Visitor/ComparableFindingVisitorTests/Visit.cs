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

namespace NGenerics.Tests.Patterns.Visitor.ComparableFindingVisitorTests
{
    [TestFixture]
    public class Visit
    {
        [Test]
        public void Find()
        {
            var list = new List<int>();
            list.AddRange(new[] { 3, 4, 76, 34, 50, 23, 45 });

            var visitor = new ComparableFindingVisitor<int>(50);

            list.AcceptVisitor(visitor);
            Assert.IsTrue(visitor.Found);
            Assert.IsTrue(visitor.HasCompleted);

            visitor = new ComparableFindingVisitor<int>(50);
            list.Clear();
            list.AddRange(new[] { 50, 3, 4, 76, 34, 23, 45 });

            list.AcceptVisitor(visitor);
            Assert.IsTrue(visitor.Found);
            Assert.IsTrue(visitor.HasCompleted);

            visitor = new ComparableFindingVisitor<int>(50);
            list.Clear();
            list.AddRange(new[] { 3, 4, 76, 34, 23, 45, 50 });

            list.AcceptVisitor(visitor);
            Assert.IsTrue(visitor.Found);
            Assert.IsTrue(visitor.HasCompleted);

            visitor = new ComparableFindingVisitor<int>(50);
            list.Clear();
            list.AddRange(new[] { 3, 4, 76, 34, 23, 45 });

            list.AcceptVisitor(visitor);
            Assert.IsFalse(visitor.Found);
            Assert.IsFalse(visitor.HasCompleted);
        }
    }

}