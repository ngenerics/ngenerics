/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
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
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullPredicate()
        {
            new GeneralVisitor<int>(null);
        }
    }
}