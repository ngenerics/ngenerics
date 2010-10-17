/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.ComplexNumberTests
{
    [TestFixture]
    public class Times
    {

        [Test]
        public void Simple()
        {
            var complexNumber1 = new ComplexNumber(1, 2);
            var complexNumber2 = new ComplexNumber(3, 4);
            var multiplyComplexNumber = complexNumber1.Multiply(complexNumber2);

            Assert.AreEqual(1 * 3 - 2 * 4, multiplyComplexNumber.Real);
            Assert.AreEqual(2 * 3 + 1 * 4, multiplyComplexNumber.Imaginary);

            multiplyComplexNumber = complexNumber1.Multiply(5);
            Assert.AreEqual(5 * 1, multiplyComplexNumber.Real);
            Assert.AreEqual(5 * 2, multiplyComplexNumber.Imaginary);

            multiplyComplexNumber = 6 * complexNumber1;
            Assert.AreEqual(6 * 1, multiplyComplexNumber.Real);
            Assert.AreEqual(6 * 2, multiplyComplexNumber.Imaginary);

            multiplyComplexNumber = complexNumber1 * 7;
            Assert.AreEqual(7 * 1, multiplyComplexNumber.Real);
            Assert.AreEqual(7 * 2, multiplyComplexNumber.Imaginary);

            complexNumber1 *= 1;
            Assert.AreEqual(1, complexNumber1.Real);
            Assert.AreEqual(2, complexNumber1.Imaginary);

            complexNumber1 *= 5;
            Assert.AreEqual(5, complexNumber1.Real);
            Assert.AreEqual(10, complexNumber1.Imaginary);

            complexNumber1 *= complexNumber2;
            Assert.AreEqual(5 * 3 - 10 * 4, complexNumber1.Real);
            Assert.AreEqual(10 * 3 + 5 * 4, complexNumber1.Imaginary);
        }

    }
}