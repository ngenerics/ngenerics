/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.ComplexNumberTests
{
    [TestFixture]
    public class Plus
    {
        [Test]
        public void Simple2()
        {
            var complexNumber1 = new ComplexNumber(4, 3);
            var complexNumber2 = new ComplexNumber(6, 2);
            var complexNumber3 = new ComplexNumber(-2, -4);
            var complexNumber4 = new ComplexNumber(3, -8);
            var complexNumber5 = new ComplexNumber(8, 3);

            var resultComplexNumber = complexNumber1 + complexNumber2;

            Assert.AreEqual(10, resultComplexNumber.Real);
            Assert.AreEqual(5, resultComplexNumber.Imaginary);

            resultComplexNumber = complexNumber1 + complexNumber3;

            Assert.AreEqual(2, resultComplexNumber.Real);
            Assert.AreEqual(-1, resultComplexNumber.Imaginary);

            resultComplexNumber = complexNumber1 + complexNumber4;

            Assert.AreEqual(7, resultComplexNumber.Real);
            Assert.AreEqual(-5, resultComplexNumber.Imaginary);


            resultComplexNumber = complexNumber1 + complexNumber5;

            Assert.AreEqual(12, resultComplexNumber.Real);
            Assert.AreEqual(6, resultComplexNumber.Imaginary);
        }

        [Test]
        public void Simple1()
        {
            var complexNumber1 = new ComplexNumber(4, 3);
            var complexNumber2 = new ComplexNumber(6, 2);
            var complexNumber3 = new ComplexNumber(-2, -4);
            var complexNumber4 = new ComplexNumber(3, -8);
            var complexNumber5 = new ComplexNumber(8, 3);

            var resultComplexNumber = complexNumber1.Add(complexNumber2);

            Assert.AreEqual(10, resultComplexNumber.Real);
            Assert.AreEqual(5, resultComplexNumber.Imaginary);

            resultComplexNumber = complexNumber1.Add(complexNumber3);

            Assert.AreEqual(2, resultComplexNumber.Real);
            Assert.AreEqual(-1, resultComplexNumber.Imaginary);

            resultComplexNumber = complexNumber1.Add(complexNumber4);

            Assert.AreEqual(7, resultComplexNumber.Real);
            Assert.AreEqual(-5, resultComplexNumber.Imaginary);


            resultComplexNumber = complexNumber1.Add(complexNumber5);

            Assert.AreEqual(12, resultComplexNumber.Real);
            Assert.AreEqual(6, resultComplexNumber.Imaginary);
        }

    }
}