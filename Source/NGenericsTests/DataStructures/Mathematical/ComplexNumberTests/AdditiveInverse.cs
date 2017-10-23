/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.ComplexNumberTests
{
    [TestFixture]
    public class AdditiveInverse
    {

        [Test]
        public void Simple()
        {
            var complexNumber1 = new ComplexNumber(4, -2);
            var complexNumber2 = new ComplexNumber(-2, 6);

            var resultComplexNumber = complexNumber1.AdditiveInverse;

            Assert.AreEqual(-4, resultComplexNumber.Real);
            Assert.AreEqual(2, resultComplexNumber.Imaginary);

            resultComplexNumber = complexNumber2.AdditiveInverse;

            Assert.AreEqual(2, resultComplexNumber.Real);
            Assert.AreEqual(-6, resultComplexNumber.Imaginary);
        }

    }
}