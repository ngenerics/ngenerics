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
    public class Union
    {

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionInvalid1()
        {
            var s1 = new PascalSet(0, 50, new[] { 15, 20, 30 });
            var s2 = new PascalSet(10, 60, new[] { 15, 20, 60 });

            s1.Union(s2);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullOperatorS1()
        {
            var pascalSet = new PascalSet(0, 50, new[] { 15, 20, 30 });

            var union = null + pascalSet;
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptioNullS2()
        {
            var pascalSet = new PascalSet(0, 50, new[] { 15, 20, 30 });
            var union = pascalSet + null;
        }

        [Test]
        public void Interface()
        {
            var s1 = new PascalSet(0, 50, new[] { 15, 20, 30 });
            var s2 = new PascalSet(0, 50, new[] { 15, 25, 30 });
            var s3 = new PascalSet(0, 50, new[] { 1, 2, 3, 4 });

            var union = (PascalSet)((ISet)s1).Union(s2);

            Assert.AreEqual(union.Count, 4);

            for (var i = 0; i <= 50; i++)
            {
                if ((i == 15) || (i == 20) || (i == 25) || (i == 30))
                {
                    Assert.IsTrue(union[i]);
                }
                else
                {
                    Assert.IsFalse(union[i]);
                }
            }

            union = (PascalSet)((ISet)s2).Union(s3);

            Assert.AreEqual(union.Count, 7);

            for (var i = 0; i <= 50; i++)
            {
                if ((i == 15) || (i == 25) || (i == 30) || (i == 1) || (i == 2) || (i == 3) || (i == 4))
                {
                    Assert.IsTrue(union[i]);
                }
                else
                {
                    Assert.IsFalse(union[i]);
                }
            }
        }

        [Test]
        public void Simple()
        {
            var s1 = new PascalSet(0, 50, new[] { 15, 20, 30 });
            var s2 = new PascalSet(0, 50, new[] { 15, 25, 30 });
            var s3 = new PascalSet(0, 50, new[] { 1, 2, 3, 4 });

            var union = s1.Union(s2);

            Assert.AreEqual(union.Count, 4);

            for (var i = 0; i <= 50; i++)
            {
                if ((i == 15) || (i == 20) || (i == 25) || (i == 30))
                {
                    Assert.IsTrue(union[i]);
                }
                else
                {
                    Assert.IsFalse(union[i]);
                }
            }

            union = s2.Union(s3);

            Assert.AreEqual(union.Count, 7);

            for (var i = 0; i <= 50; i++)
            {
                if ((i == 15) || (i == 25) || (i == 30) || (i == 1) || (i == 2) || (i == 3) || (i == 4))
                {
                    Assert.IsTrue(union[i]);
                }
                else
                {
                    Assert.IsFalse(union[i]);
                }
            }

            var union2 = s2 + s3;
            Assert.IsTrue(union2.Equals(union));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullSet()
        {
            var pascalSet = new PascalSet(500);
            pascalSet.Union(null);
        }

    }

}