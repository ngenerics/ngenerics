/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/


using System;
using System.Collections.Generic;
using NGenerics.Comparers;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.Comparers.ReverseComparerTests
{
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
        public void ExceptionNullComparer()
        {
            Assert.Throws<ArgumentNullException>(() =>  
                new ReverseComparer<int>
                {
                    Comparer = null
                }
            );
        }
    }
}
