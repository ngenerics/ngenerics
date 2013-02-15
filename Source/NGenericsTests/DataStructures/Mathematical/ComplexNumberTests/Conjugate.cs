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