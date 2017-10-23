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
    public class Conjugate
    {

        [Test]
        public void Simple()
        {
            var complexNumber1 = new ComplexNumber(1, 2);
            var conjugateComplexNumber = complexNumber1.Conjugate;

            Assert.AreEqual(1, conjugateComplexNumber.Real);
            Assert.AreEqual(-2, conjugateComplexNumber.Imaginary);

            complexNumber1.Imaginary = -1;
            conjugateComplexNumber = complexNumber1.Conjugate;
            Assert.AreEqual(1, conjugateComplexNumber.Real);
            Assert.AreEqual(1, conjugateComplexNumber.Imaginary);

        }

    }
}