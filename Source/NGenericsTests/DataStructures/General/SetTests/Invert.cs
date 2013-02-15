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
    public class Invert
    {

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null()
        {
            var newSet = !(PascalSet)null;
        }

        [Test]
        public void Interface()
        {
            var pascalSet = new PascalSet(0, 50, new[] { 15, 20, 30 });

            var inverse = (PascalSet)((ISet)pascalSet).Inverse();

            for (var i = 0; i <= 50; i++)
            {
                if ((i == 15) || (i == 20) || (i == 30))
                {
                    Assert.IsFalse(inverse[i]);
                }
                else
                {
                    Assert.IsTrue(inverse[i]);
                }
            }
        }

        [Test]
        public void Simple()
        {
            var pascalSet = new PascalSet(0, 50, new[] { 15, 20, 30 });

            var inverse = pascalSet.Inverse();

            for (var i = 0; i <= 50; i++)
            {
                if ((i == 15) || (i == 20) || (i == 30))
                {
                    Assert.IsFalse(inverse[i]);
                }
                else
                {
                    Assert.IsTrue(inverse[i]);
                }
            }

            var inverse2 = !pascalSet;
            Assert.IsTrue(inverse.Equals(inverse2));
        }

    }
}