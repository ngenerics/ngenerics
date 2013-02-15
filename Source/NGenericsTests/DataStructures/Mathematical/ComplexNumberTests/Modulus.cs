/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.ComplexNumberTests
{
    [TestFixture]
    public class Modulus
    {

        [Test]
        public void Simple()
        {
            var complex = new ComplexNumber(0, 10);
            var modulus = complex.Modulus;

            Assert.AreEqual(modulus, 10);

            complex = new ComplexNumber(10, 0);
            modulus = complex.Modulus;

            Assert.AreEqual(modulus, 10);

            complex = new ComplexNumber(1.576, -53.47);
            modulus = complex.Modulus;

            var answer = Math.Sqrt(1.576 * 1.576 + (-53.47 * -53.47));
            Assert.AreEqual(modulus, answer);
        }

    }
}