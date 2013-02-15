/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


namespace NGenerics.Tests.Comparers.ReverseComparerTests
{
    using System;
    using System.Collections.Generic;
    using NGenerics.Comparers;
    using Util;
    using NUnit.Framework;

    [TestFixture]
    public class Comparer
    {
        [Test]
        public void Set()
        {
            var comparer = new ReverseComparer<int>();

            IComparer<int> newComparer = new IntComparer();
            comparer.Comparer = newComparer;

            Assert.AreEqual(comparer.Comparer, newComparer);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullComparer()
        {
            new ReverseComparer<int>
            {
                Comparer = null
            };
        }
    }
}
