/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SetTests
{
    [TestFixture]
    public class Subtract
    {

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullSet()
        {
            var pascalSet = new PascalSet(500);
            pascalSet.Subtract(null);
        }

        [Test]
        public void Simple()
        {
            var s1 = new PascalSet(0, 50, new[] { 20, 30, 40 });
            var s2 = new PascalSet(0, 50, new[] { 20, 25, 30, 35, 40 });

            var difference = s1.Subtract(s2);

            for (var i = 0; i < 50; i++)
            {
                if ((i == 25) || (i == 35))
                {
                    Assert.IsTrue(difference[i]);
                }
                else
                {
                    Assert.IsFalse(difference[i]);
                }
            }

            var difference2 = s1 - s2;
            Assert.IsTrue(difference.Equals(difference2));
        }

        [Test]
        public void Interface()
        {
            var s1 = new PascalSet(0, 50, new[] { 20, 30, 40 });
            var s2 = new PascalSet(0, 50, new[] { 20, 25, 30, 35, 40 });

            var difference = (PascalSet)((ISet)s1).Subtract(s2);

            for (var i = 0; i < 50; i++)
            {
                if ((i == 25) || (i == 35))
                {
                    Assert.IsTrue(difference[i]);
                }
                else
                {
                    Assert.IsFalse(difference[i]);
                }
            }
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullSetOperator2()
        {
            var pascalSet = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });
            var a = null - pascalSet;
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullSetOperator1()
        {
            var pascalSet = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });
            var a = pascalSet - null;
        }

    }
}