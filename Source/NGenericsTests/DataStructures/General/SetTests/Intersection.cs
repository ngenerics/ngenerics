/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

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
    public class Intersection
    {

        [Test]
        public void Simple()
        {
            var s1 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });
            var s2 = new PascalSet(0, 50, new[] { 20, 25, 30, 35, 40 });

            var intersection = s1.Intersection(s2);

            for (var i = 0; i <= 50; i++)
            {
                if ((i == 20) || (i == 30) || (i == 40))
                {
                    Assert.IsTrue(intersection[i]);
                }
                else
                {
                    Assert.IsFalse(intersection[i]);
                }
            }

            var intersection2 = s1 * s2;
            Assert.IsTrue(intersection.Equals(intersection2));
        }

        [Test]
        public void Interface()
        {
            var s1 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });
            var s2 = new PascalSet(0, 50, new[] { 20, 25, 30, 35, 40 });

            var intersection = (PascalSet)((ISet)s1).Intersection(s2);

            for (var i = 0; i <= 50; i++)
            {
                if ((i == 20) || (i == 30) || (i == 40))
                {
                    Assert.IsTrue(intersection[i]);
                }
                else
                {
                    Assert.IsFalse(intersection[i]);
                }
            }
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionInvalidIntersectionOperator1()
        {
            var pascalSet = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });
            var a = pascalSet * null;
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullSet()
        {
            var pascalSet = new PascalSet(500);
            pascalSet.Intersection(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExcetionNullOperator()
        {
            var pascalSet = new PascalSet(500);
            var newSet = null * pascalSet;
        }

    }
}