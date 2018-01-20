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
    public class IsProperSubsetOf
    {

        [Test]
        public void ExceptionInvalidProperSubsetOf()
        {
            var s1 = new PascalSet(0, 50, new[] { 15, 20, 30 });
            var s2 = new PascalSet(10, 60, new[] { 15, 20, 60 });

            Assert.Throws<ArgumentException>(() => s1.IsProperSubsetOf(s2));
        }

        [Test]
        public void ExceptionNullS1()
        {
            var pascalSet = new PascalSet(0, 50, new[] { 15, 20, 30 });
            bool b;
            Assert.Throws<ArgumentNullException>(() => b = null < pascalSet);
        }

        [Test]
        public void ExceptionNullS2()
        {
            var pascalSet = new PascalSet(0, 50, new[] { 15, 20, 30 });
            bool b;
            Assert.Throws<ArgumentNullException>(() => b = pascalSet < null);
        }

        [Test]
        public void ExceptionNullSet()
        {
            var pascalSet = new PascalSet(500);
            Assert.Throws<ArgumentNullException>(() => pascalSet.IsProperSubsetOf(null));
        }

        [Test]
        public void Simple()
        {
            var s1 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });
            var s2 = new PascalSet(0, 50, new[] { 15, 20, 30 });
            var s3 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });

            Assert.IsFalse(s1.IsProperSubsetOf(s2));
            Assert.IsTrue(s2.IsProperSubsetOf(s1));
            Assert.IsFalse(s3.IsProperSubsetOf(s1));
            Assert.IsFalse(s1.IsProperSubsetOf(s3));

            Assert.IsFalse(s1 < s2);
            Assert.IsTrue(s2 < s1);
            Assert.IsFalse(s3 < s1);
            Assert.IsFalse(s1 < s3);
        }

        [Test]
        public void Interface()
        {
            var s1 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });
            var s2 = new PascalSet(0, 50, new[] { 15, 20, 30 });
            var s3 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });

            Assert.IsFalse(((ISet)s1).IsProperSubsetOf(s2));
            Assert.IsTrue(((ISet)s2).IsProperSubsetOf(s1));
            Assert.IsFalse(((ISet)s3).IsProperSubsetOf(s1));
            Assert.IsFalse(((ISet)s1).IsProperSubsetOf(s3));
        }

        [Test]
        public void ExceptionNullS3()
        {
            var pascalSet = new PascalSet(500);
            bool p;
            Assert.Throws<ArgumentNullException>(() => p = null < pascalSet);
        }
    }
}