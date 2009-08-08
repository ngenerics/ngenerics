/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using NGenerics.Comparers;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.Comparers
{
    [TestFixture]
    public class ComparisonComparerTest
    {
        #region Tests

        [TestFixture]
        public class Construction
        {
            [Test]
            public void Simple()
            {
                var comparer = GetTestComparer();

                Assert.IsNotNull(comparer.Comparison);

                comparer.Comparison = ((x, y) => x.TestProperty.CompareTo(y.TestProperty));
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullComparison()
            {
                new ComparisonComparer<SimpleClass>(null);
            }
        }
        
        [TestFixture]
        public class Compare
        {
            [Test]
            public void Simple()
            {
                var s1 = new SimpleClass("a");
                var s2 = new SimpleClass("b");
                var s3 = new SimpleClass("c");
                var s4 = new SimpleClass("a");

                var comparer = GetTestComparer();

                Assert.AreEqual(comparer.Compare(s1, s2), -1);
                Assert.AreEqual(comparer.Compare(s1, s3), -1);
                Assert.AreEqual(comparer.Compare(s1, s4), 0);

                Assert.AreEqual(comparer.Compare(s2, s1), 1);
                Assert.AreEqual(comparer.Compare(s3, s1), 1);
                Assert.AreEqual(comparer.Compare(s4, s1), 0);
            }
        }
            
        [TestFixture]
        public class Comparison
        {
            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullComparer()
            {
                var comparer = GetTestComparer();
                comparer.Comparison = null;
            }
        }

        #endregion

        #region Private Members

        private static ComparisonComparer<SimpleClass> GetTestComparer()
        {
            return new ComparisonComparer<SimpleClass>((x, y) => x.TestProperty.CompareTo(y.TestProperty));
        }

        #endregion
    }
}
