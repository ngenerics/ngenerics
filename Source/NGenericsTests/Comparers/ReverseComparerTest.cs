/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/


using System;
using System.Collections.Generic;
using NGenerics.Tests.Util;
using NUnit.Framework;
using NGenerics.Comparers;

namespace NGenerics.Tests.Comparers
{
    [TestFixture]
    public class ReverseComparerTest
    {
        [TestFixture]
        public class Construction
        {
            [Test]
			public void Simple()
            {
                var comparer = new ReverseComparer<int>();

                Assert.AreEqual(comparer.Comparer, Comparer<int>.Default);

                IComparer<int> newComparer = new IntComparer();

                comparer = new ReverseComparer<int>(newComparer);

                Assert.AreEqual(comparer.Comparer, newComparer);
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullComparer()
            {
                new ReverseComparer<int>(null);
            }
        }

        [TestFixture]
        public class Compare
        {
            [Test]
			public void Simple()
            {
                var comparer = new ReverseComparer<int>();

                Assert.AreEqual(comparer.Compare(2, 3), 1);
                Assert.AreEqual(comparer.Compare(3, 2), -1);
                Assert.AreEqual(comparer.Compare(0, 0), 0);
                Assert.AreEqual(comparer.Compare(0, 1), 1);
                Assert.AreEqual(comparer.Compare(1, 0), -1);
            }
        }
                
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
                var comparer = new ReverseComparer<int>();
                comparer.Comparer = null;
            }
        }
    }
}
