/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.Patterns.Visitor;
using NUnit.Framework;

namespace NGenerics.Tests.Patterns.Visitor.ComparableFindingVisitorTests
{
    [TestFixture]
    public class Construction
    {
        [Test]
        public void Simple()
        {
            var visitor = new ComparableFindingVisitor<int>(50);
            Assert.AreEqual(visitor.SearchValue, 50);
            Assert.IsFalse(visitor.HasCompleted);
            Assert.IsFalse(visitor.Found);
        }
    }
}