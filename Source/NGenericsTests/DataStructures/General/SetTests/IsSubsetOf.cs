/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SetTests
{
    [TestFixture]
    public class IsSubsetOf
    {

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullSet()
        {
            var pascalSet = new PascalSet(500);
            pascalSet.IsSubsetOf(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullS1()
        {
            var pascalSet = new PascalSet(0, 50, new[] { 15, 20, 30 });
            var b = null <= pascalSet;
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullS2()
        {
            var pascalSet = new PascalSet(0, 50, new[] { 15, 20, 30 });
            var b = pascalSet <= null;
        }

        [Test]
        public void Interface()
        {
            var s1 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });
            var s2 = new PascalSet(0, 50, new[] { 15, 20, 30 });
            var s3 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });

            Assert.IsFalse(((ISet)s1).IsSubsetOf(s2));
            Assert.IsTrue(((ISet)s2).IsSubsetOf(s1));
            Assert.IsTrue(((ISet)s3).IsSubsetOf(s1));
            Assert.IsTrue(((ISet)s1).IsSubsetOf(s3));
        }

        [Test]
        public void Simple()
        {
            var s1 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });
            var s2 = new PascalSet(0, 50, new[] { 15, 20, 30 });
            var s3 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });

            Assert.IsFalse(s1.IsSubsetOf(s2));
            Assert.IsTrue(s2.IsSubsetOf(s1));
            Assert.IsTrue(s3.IsSubsetOf(s1));
            Assert.IsTrue(s1.IsSubsetOf(s3));

            Assert.IsFalse(s1 <= s2);
            Assert.IsTrue(s2 <= s1);
            Assert.IsTrue(s3 <= s1);
            Assert.IsTrue(s1 <= s3);
        }

    }
}