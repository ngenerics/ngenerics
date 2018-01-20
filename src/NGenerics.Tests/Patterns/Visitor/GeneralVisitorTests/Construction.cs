/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;

namespace NGenerics.Tests.Patterns.Visitor.GeneralVisitorTests
{
    [TestFixture]
    public class Construction
    {
        [Test]
        public void Simple()
        {
            new GeneralVisitor<int>(
                delegate {
                             return false;
                }
                );
        }

        [Test]
        public void ExceptionNullPredicate()
        {
            Assert.Throws<ArgumentNullException>(() => new GeneralVisitor<int>(null));
        }
    }
}